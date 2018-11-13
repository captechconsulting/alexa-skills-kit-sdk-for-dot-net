using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Request
{
    public class Resolutions
    {
        [JsonProperty("resolutionsPerAuthority")]
        public IEnumerable<Resolution> ResolutionsPerAuthority { get; set; }
    }
}
