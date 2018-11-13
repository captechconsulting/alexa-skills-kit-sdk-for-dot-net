using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ask.Sdk.Model.Request
{
    public class AudioPlayerState
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("offsetInMilliseconds")]
        public long OffsetInMilliseconds { get; set; }

        [JsonProperty("playerActivity")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PlayerActivity PlayerActivity { get; set; }
    }
}