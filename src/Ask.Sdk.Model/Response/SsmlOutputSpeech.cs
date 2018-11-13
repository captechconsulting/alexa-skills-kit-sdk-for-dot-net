using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public class SsmlOutputSpeech : IOutputSpeech
    {
        [JsonRequired]
        [JsonProperty("type")]
        public string Type => "SSML";

        [JsonRequired]
        [JsonProperty("ssml")]
        public string Ssml { get; set; }
    }
}
