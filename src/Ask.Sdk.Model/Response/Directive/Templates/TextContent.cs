using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive.Templates
{
    public class TextContent
    {
        [JsonProperty("primaryText", Required = Required.Always)]
        public TextField Primary { get; set; }

        [JsonProperty("secondaryText", NullValueHandling = NullValueHandling.Ignore)]
        public TextField Secondary { get; set; }

        [JsonProperty("tertiaryText", NullValueHandling = NullValueHandling.Ignore)]
        public TextField Tertiary { get; set; }
    }
}
