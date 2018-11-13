using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Directive
{
    public class Header
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }
    }
}
