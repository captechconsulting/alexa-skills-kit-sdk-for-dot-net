using Alexa.NET.Request;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Ask.Sdk.Core.Attributes.Persistence;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Ask.Sdk.DynamoDb.Persistence.Adapter.Attributes.Persistence
{
    public static class DynamoDbPersistenceAdapterFactory
    {
        public static async Task<IPersistenceAdapter> Init(string tableName,
            AmazonDynamoDBClient dynamoDBClient,
            string partitionKeyName = "id",
            string attributesName = "attributes",
            bool createTable = true,
            Func<SkillRequest, string> partitionKeyGenerator = null)
        {
            var adapter = new DynamoDbPersistenceAdapter(tableName,
                dynamoDBClient,
                partitionKeyName,
                attributesName,
                partitionKeyGenerator);

            if (createTable)
            {
                var request = new CreateTableRequest
                {
                    AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition
                        {
                            AttributeName = partitionKeyName,
                            AttributeType = ScalarAttributeType.S
                        }
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = partitionKeyName,
                            KeyType = KeyType.HASH
                        }
                    },
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 5,
                        WriteCapacityUnits = 5
                    },
                    TableName = tableName
                };
                try
                {
                    var result = await dynamoDBClient.CreateTableAsync(request);
                }
                // We want to catch this exception because it means our table already exists
                // and doesn't need created
                catch (ResourceInUseException) { }
            }
            return adapter;
        }

        internal class DynamoDbPersistenceAdapter : IPersistenceAdapter
        {
            private readonly Func<SkillRequest, string> _partitionKeyGenerator;
            private readonly string _partitionKeyName;
            private readonly string _tableName;
            private readonly string _attributesName;
            private readonly Table _table;
            private readonly JsonSerializerSettings _settings;

            public DynamoDbPersistenceAdapter(string tableName,
                AmazonDynamoDBClient dynamoDBClient,
                string partitionKeyName,
                string attributesName,
                Func<SkillRequest, string> partitionKeyGenerator = null)
            {
                if (partitionKeyGenerator == null)
                {
                    _partitionKeyGenerator = PartitionKeyGenerator.UserId;
                }
                else
                {
                    _partitionKeyGenerator = partitionKeyGenerator;
                }
                _tableName = tableName;
                _partitionKeyName = partitionKeyName;
                _attributesName = attributesName;
                _table = Table.LoadTable(dynamoDBClient, _tableName);
                _settings = new JsonSerializerSettings
                {
                    ContractResolver = new DynamoDbDocumentResolver(_partitionKeyName, _attributesName)
                };
            }

            public async Task<IDictionary<string, object>> GetAttributes(SkillRequest SkillRequest)
            {
                var attributesId = _partitionKeyGenerator(SkillRequest);

                try
                {
                    var document = await _table.GetItemAsync(attributesId, new GetItemOperationConfig
                    {
                        ConsistentRead = true
                    });

                    var dbDocument = JsonConvert.DeserializeObject<DynamoDbDocument>(document.ToJson(), _settings);

                    return dbDocument.Attributes;
                }
                catch (Exception)
                {
                    return new Dictionary<string, object>();
                }
            }

            public async Task SaveAttributes(SkillRequest SkillRequest, IDictionary<string, object> attributes)
            {
                var attributesId = _partitionKeyGenerator(SkillRequest);

                var document = new DynamoDbDocument
                {
                    Id = attributesId,
                    Attributes = attributes
                };

                var item = Document.FromJson(JsonConvert.SerializeObject(document, _settings));

                await _table.PutItemAsync(item);
            }
        }
    }

    internal class DynamoDbDocumentResolver : DefaultContractResolver
    {
        private readonly string _partitionKeyName;
        private readonly string _attributesName;

        internal DynamoDbDocumentResolver(string partitionKeyName, string attributesName)
        {
            _partitionKeyName = partitionKeyName;
            _attributesName = attributesName;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (member.DeclaringType == typeof(DynamoDbDocument))
            {
                if (member.Name == "Id")
                    property.PropertyName = _partitionKeyName;
                if (member.Name == "Attributes")
                    property.PropertyName = _attributesName;
            }

            return property;
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            if (propertyName == _partitionKeyName)
            {
                return "Id";
            }
            if (propertyName == _attributesName)
            {
                return "Attributes";
            }
            return base.ResolvePropertyName(propertyName);
        }
    }
    internal class DynamoDbDocument
    {
        public string Id { get; set; }

        public IDictionary<string, object> Attributes { get; set; }
    }
}
