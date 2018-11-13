using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public class RenderTemplateDirective : IDirective
    {
        [JsonProperty("type")]
        public string Type => "Display.RenderTemplate";

        [JsonProperty("template", Required = Required.Always)]
        public ITemplate Template { get; set; }
    }
}
