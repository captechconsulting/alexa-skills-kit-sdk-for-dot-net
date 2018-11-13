using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Service.ListManagement
{
    public class AlexaListMetadata
    {
        [JsonProperty("listId")]
        public string ListId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ListState State { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("statusMap")]
        public List<ListStatus> StatusMap { get; set; }
    }
}
