using Ask.Sdk.Model.Response.Directive.Templates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public class AudioItemMetadata
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("art")]
        public Image Art { get; set; } = new Image();

        [JsonProperty("backgroundImage")]
        public Image BackgroundImage { get; set; } = new Image();
    }
}
