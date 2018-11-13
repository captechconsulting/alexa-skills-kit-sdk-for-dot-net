using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public class CanFulfillIntent
    {
        [JsonProperty("canFulfill")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CanFulfillIntentValues CanFulfill { get; set; }

        [JsonProperty("slots", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, CanFulFillSlot> Slots { get; set; }
    }
}
