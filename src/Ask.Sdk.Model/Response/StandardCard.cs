using Ask.Sdk.Model.Response.Directive.Templates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public class StandardCard : ICard
    {
        [JsonProperty("type")]
        [JsonRequired]
        public string Type => "Standard";

        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonRequired]
        [JsonProperty("text")]
        public string Content { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public UiImage Image { get; set; }
    }
}
