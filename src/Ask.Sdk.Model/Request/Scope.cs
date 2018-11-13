using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ask.Sdk.Model.Request
{
    public class Scope
    {
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PermissionStatus Status { get; set; }
    }
}