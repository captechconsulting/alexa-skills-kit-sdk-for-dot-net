using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Directive
{
    public class SendDirectiveRequest
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("directive")]
        public IDirective Directive { get; set; }
    }
}
