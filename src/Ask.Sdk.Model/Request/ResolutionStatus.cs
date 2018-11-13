using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Request
{
    public class ResolutionStatus
    {
        [JsonProperty("code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusCode Code { get; set; }
    }
}
