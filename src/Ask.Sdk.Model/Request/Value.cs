using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Request
{
    public class Value
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
