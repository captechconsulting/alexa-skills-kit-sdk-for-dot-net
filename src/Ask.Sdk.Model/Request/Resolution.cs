using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Request
{
    public class Resolution
    {
        [JsonProperty("authority")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public ResolutionStatus Status { get; set; }

        [JsonProperty("values")]
        public ValueWrapper[] Values { get; set; }
    }
}
