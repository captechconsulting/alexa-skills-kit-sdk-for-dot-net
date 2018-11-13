using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Service.ListManagement
{
    public class CreateListRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ListState State { get; set; }
    }
}
