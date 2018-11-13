using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public class PlainTextOutputSpeech : IOutputSpeech
    {
        [JsonProperty("type")]
        [JsonRequired]
        public string Type => "PlainText";
        
        [JsonRequired]
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
