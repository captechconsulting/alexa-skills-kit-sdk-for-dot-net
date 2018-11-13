using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Service.ListManagement
{
    public class ListStatus
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ListItemState Status { get; set; }
    }
}
