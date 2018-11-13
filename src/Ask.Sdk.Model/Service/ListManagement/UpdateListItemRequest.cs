using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Service.ListManagement
{
    public class UpdateListItemRequest
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ListItemState Status { get; set; }

        [JsonProperty("verson")]
        public string Version { get; set; }
    }
}
