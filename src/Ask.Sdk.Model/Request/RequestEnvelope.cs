using Ask.Sdk.Model.Request.Type;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Request
{
    public class RequestEnvelope
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("session")]
        public Session Session { get; set; }

        [JsonProperty("context")]
        public Context Context { get; set; }

        [JsonProperty("request")]
        [JsonConverter(typeof(RequestConverter))]
        public Request Request { get; set; }

        public System.Type GetRequestType()
        {
            return Request?.GetType();
        }
    }
}
