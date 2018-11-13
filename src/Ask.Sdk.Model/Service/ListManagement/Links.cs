using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Service.ListManagement
{
    public class Links
    {
        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
