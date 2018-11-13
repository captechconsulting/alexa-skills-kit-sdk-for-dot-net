using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ask.Sdk.Model.Response
{
    public class CanFulFillSlot
    {
        [JsonProperty("canUnderstand")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CanUnderstandSlotValues CanUnderstand { get; set; }

        [JsonProperty("canFulfill", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public CanFulfillSlotValues? CanFulfill { get; set; }
    }
}