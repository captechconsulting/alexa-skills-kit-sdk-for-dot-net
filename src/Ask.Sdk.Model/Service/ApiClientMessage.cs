using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ask.Sdk.Model.Service
{
    public abstract class ApiClientMessage
    {
        [JsonProperty("headers")]
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}