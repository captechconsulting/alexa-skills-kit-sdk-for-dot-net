using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ask.Sdk.Model.Service.Monetization
{
    public class InSkillProduct
    {
        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("referenceName")]
        public string ReferenceName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProductType Type { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("purchasable")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PurchasableState Purchasable { get; set; }

        [JsonProperty("entitled")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EntitledState Entitled { get; set; }

        [JsonProperty("activeEntitlementCount")]
        public int ActiveEntitlementCount { get; set; }

        [JsonProperty("purchaseMode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PurchaseMode PurchaseMode { get; set; }

    }
}