using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public class HintDirective: IDirective
    {
        [JsonProperty("type")]
        public string Type => "Hint";

        [JsonProperty("hint")]
        public Hint Hint { get; set; }
    }
}
