using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ask.Sdk.Model.Service.Monetization
{
    public class InSkillProductsResponse
    {
        [JsonProperty("inSkillProducts")]
        public List<InSkillProduct> InSkillProducts { get; set; }

        [JsonProperty("isTruncated")]
        public bool IsTruncated { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}