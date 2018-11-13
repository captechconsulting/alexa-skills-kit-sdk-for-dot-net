using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Service.ListManagement
{
    public class UpdateListRequest
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ListState State { get; set; }

        [JsonProperty("verson")]
        public string Version { get; set; }
    }
}
