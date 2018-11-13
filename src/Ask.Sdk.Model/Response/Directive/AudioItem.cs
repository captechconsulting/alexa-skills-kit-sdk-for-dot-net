using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public class AudioItem
    {
        [JsonRequired]
        [JsonProperty("stream")]
        public Stream Stream { get; set; }

        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public AudioItemMetadata Metadata { get; set; }
    }
}
