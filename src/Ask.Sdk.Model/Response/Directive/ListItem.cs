using Ask.Sdk.Model.Response.Directive.Templates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public class ListItem
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("textContent")]
        public TextContent Content { get; set; }
    }
}
