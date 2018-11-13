using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public class ResponseEnvelope
    {
        [JsonRequired]
        [JsonProperty("version")]
        public string Version { get; set; } = "1.0";

        [JsonProperty("sessionAttributes", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, object> SessionAttributes { get; set; }

        [JsonRequired]
        [JsonProperty("response")]
        public Response Response { get; set; }

        [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAgent { get; set; }
    }
}
