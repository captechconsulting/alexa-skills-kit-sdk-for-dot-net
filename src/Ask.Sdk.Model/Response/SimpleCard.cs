using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public class SimpleCard : ICard
    {
        [JsonProperty("type")]
        [JsonRequired]
        public string Type => "Simple";

        [JsonProperty("title")]
        [JsonRequired]
        public string Title { get; set; }

        [JsonRequired]
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
