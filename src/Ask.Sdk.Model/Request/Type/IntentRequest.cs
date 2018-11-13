using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ask.Sdk.Model.Request.Type
{
    public class IntentRequest : Request
    {
        [JsonProperty("dialogState")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DialogState DialogState { get; set; }

        public Intent Intent { get; set; }
    }
}