using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Request.Type
{
    public class CanFulfillIntentRequest : Request
    {
        [JsonProperty("dialogState", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public DialogState? DialogState { get; set; }

        public Intent Intent { get; set; }
    }
}
