using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive.Templates
{
    public class Image
    {
        [JsonProperty("contentDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string ContentDescription { get; set; }

        [JsonProperty("sources")]
        public List<ImageInstance> Sources { get; set; } = new List<ImageInstance>();
    }
}
