using Ask.Sdk.Core.Attributes.Persistence;
using Ask.Sdk.Model.Request;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.CosmosDb.Persistence.Adapter.Attributes.Persistence
{
    public static class CosmosDbPersistenceAdapterFactory
    {
        public static async Task<IPersistenceAdapter> Init(string collectionName,
            string databaseName,
            IDocumentClient documentClient,
            string attributesName = "attributes",
            bool createTable = true,
            Func<RequestEnvelope,string> partitionKeyGenerator = null)
        {
            var adapter = new CosmosDbPersistenceAdapter(collectionName,databaseName, documentClient, attributesName,  partitionKeyGenerator);

            if (createTable)
            {
                var db = await documentClient.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseName });

                var collection = new DocumentCollection { Id = collectionName };

                await documentClient.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(databaseName),
                    collection);
            }
            return adapter;
        }
    }

    internal class CosmosDbPersistenceAdapter : IPersistenceAdapter
    {
        private readonly IDocumentClient _documentClient;
        private readonly Func<RequestEnvelope, string> _partitionKeyGenerator;
        private readonly string _databaseName;
        private readonly string _collectionName;
        private readonly string _attributesName;
        private readonly Uri _collectionUri;

        internal CosmosDbPersistenceAdapter(string collectionName,
            string databaseName,
            IDocumentClient documentClient,
            string attributesName = "attributes",
            Func<RequestEnvelope, string> partitionKeyGenerator = null)
        {
            _databaseName = databaseName;
            _collectionName = collectionName;
            _attributesName = attributesName;
            if (partitionKeyGenerator == null)
            {
                _partitionKeyGenerator = PartitionKeyGenerator.UserId;
            } else
            {
                _partitionKeyGenerator = partitionKeyGenerator;
            }
            _documentClient = documentClient;
            _collectionUri = UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName);
        }

        public async Task<IDictionary<string, object>> GetAttributes(RequestEnvelope requestEnvelope)
        {
            var document = await GetExistingDocument(requestEnvelope);
            
            if (document == null)
            {
                document = await CreateNewDocument(requestEnvelope);
            }

            return document.Attributes;
        }

        public async Task SaveAttributes(RequestEnvelope requestEnvelope, IDictionary<string, object> attributes)
        {
            var documentId = _partitionKeyGenerator(requestEnvelope);

            var document = GenerateDocument(documentId, attributes);

            await _documentClient.ReplaceDocumentAsync(GenerateDocumentUri(documentId), document: document);
        }

        private async Task<CosmosDbDocument> CreateNewDocument(RequestEnvelope requestEnvelope)
        {
            var documentId = _partitionKeyGenerator(requestEnvelope);

            var document = GenerateDocument(documentId);

            await _documentClient.CreateDocumentAsync(_collectionUri, document);

            return document;
        }

        private CosmosDbDocument GenerateDocument(string documentId, IDictionary<string, object> attributes = null)
        {
            return new CosmosDbDocument
            {
                Id = documentId,
                Attributes = attributes ?? new Dictionary<string, object>()
            };
        }

        private async Task<CosmosDbDocument> GetExistingDocument(RequestEnvelope requestEnvelope)
        {
            var documentId = _partitionKeyGenerator(requestEnvelope);
            CosmosDbDocument document = null;

            try
            {
                document = await _documentClient.ReadDocumentAsync<CosmosDbDocument>(GenerateDocumentUri(documentId));
            } 
            catch (DocumentClientException)
            {
                // Document doesn't exist, return null
            }

            return document;
        }

        private Uri GenerateDocumentUri(string documentId)
        {
            return UriFactory.CreateDocumentUri(_databaseName, _collectionName, documentId);
        } 
    }

    internal class CosmosDbDocument
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public IDictionary<string, object> Attributes { get; set; }
    }
}
