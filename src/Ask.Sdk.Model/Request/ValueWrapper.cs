using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Request
{
    public class ValueWrapper
    {
        [JsonProperty("value")]
        public Value Value { get; set; }
    }
}
