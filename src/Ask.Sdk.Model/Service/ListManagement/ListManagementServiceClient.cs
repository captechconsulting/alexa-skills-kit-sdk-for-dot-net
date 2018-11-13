using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Model.Service.ListManagement
{
    public class ListManagementServiceClient : BaseServiceClient
    {
        private static string BASEURL = "https://api.amazonalexa.com";
        private static string BASEPATH = "/v2/householdlists/";

        public ListManagementServiceClient(ApiConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        public Task<AlexaListsMetadata> GetListsMetadata()
        {
            return Invoke<AlexaListsMetadata>("GET", BASEURL, BASEPATH, new Dictionary<string, string>(),
                new Dictionary<string, string>());
        }

        public Task DeleteList(string listId)
        {
            return Invoke<string>("DELETE", BASEURL, $"{BASEPATH}{listId}/", new Dictionary<string, string>(),
                new Dictionary<string, string>());
        }
        public Task DeleteListItem(string listId, string itemId)
        {
            return Invoke<string>("DELETE", BASEURL, $"{BASEPATH}{listId}/items/{itemId}/", new Dictionary<string, string>(),
                new Dictionary<string, string>());
        }

        public Task<AlexaListItem> GetListItem(string listId, string itemId)
        {
            if (string.IsNullOrEmpty(listId))
                throw new ArgumentNullException(nameof(listId));

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException(nameof(itemId));

            return Invoke<AlexaListItem>("GET", BASEURL, $"{BASEPATH}{listId}/items/{itemId}/", new Dictionary<string, string>(),
                new Dictionary<string, string>());
        }

        public Task<AlexaListItem> UpdateListItem(string listId, string itemId, UpdateListItemRequest updateListItemRequest)
        {
            if (string.IsNullOrEmpty(listId))
                throw new ArgumentNullException(nameof(listId));

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException(nameof(itemId));

            if (updateListItemRequest == null)
                throw new ArgumentNullException(nameof(updateListItemRequest));

            return Invoke<AlexaListItem>("PUT", BASEURL, $"{BASEPATH}{listId}/items/{itemId}/", new Dictionary<string, string>(),
                new Dictionary<string, string>(), JsonConvert.SerializeObject(updateListItemRequest));
        }

        public Task<AlexaListItem> CreateListItem(string listId, CreateListItemRequest createListItemRequest)
        {
            if (string.IsNullOrEmpty(listId))
                throw new ArgumentNullException(nameof(listId));


            if (createListItemRequest == null)
                throw new ArgumentNullException(nameof(createListItemRequest));

            return Invoke<AlexaListItem>("POST", BASEURL, $"{BASEPATH}{listId}/items/", new Dictionary<string, string>(),
                new Dictionary<string, string>(), JsonConvert.SerializeObject(createListItemRequest));
        }

        public Task<AlexaListMetadata> UpdateList(string listId, UpdateListRequest updateListRequest)
        {
            if (string.IsNullOrEmpty(listId))
                throw new ArgumentNullException(nameof(listId));


            if (updateListRequest == null)
                throw new ArgumentNullException(nameof(updateListRequest));

            return Invoke<AlexaListMetadata>("PUT", BASEURL, $"{BASEPATH}{listId}/", new Dictionary<string, string>(),
                new Dictionary<string, string>(), JsonConvert.SerializeObject(updateListRequest));
        }

        public Task<AlexaList> GetList(string listId, string status)
        {
            if (string.IsNullOrEmpty(listId))
                throw new ArgumentNullException(nameof(listId));

            if (string.IsNullOrEmpty(status))
                throw new ArgumentNullException(nameof(status));

            return Invoke<AlexaList>("GET", BASEURL, $"{BASEPATH}{listId}/{status}/", new Dictionary<string, string>(),
                new Dictionary<string, string>());
        }

        public Task<AlexaListMetadata> CreateList(CreateListRequest createListRequest)
        {
            if (createListRequest == null)
                throw new ArgumentNullException(nameof(createListRequest));

            return Invoke<AlexaListMetadata>("POST", BASEURL, BASEPATH, new Dictionary<string, string>(),
                new Dictionary<string, string>(), JsonConvert.SerializeObject(createListRequest));
        }
    }
}
