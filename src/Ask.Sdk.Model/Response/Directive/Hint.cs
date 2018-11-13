using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public class Hint
    {
        [JsonProperty("type")]
        public string Type => "PlainText";

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
