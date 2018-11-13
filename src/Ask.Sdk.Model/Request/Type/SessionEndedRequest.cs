using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ask.Sdk.Model.Request.Type
{
    public class SessionEndedRequest : Request
    {
        [JsonProperty("reason")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Reason Reason { get; set; }
    }
}