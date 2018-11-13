using Newtonsoft.Json;

namespace Ask.Sdk.Model.Response.Directive
{
    public class Stream
    {
        [JsonRequired]
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonRequired]
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expectedPreviousToken", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpectedPreviousToken { get; set; }

        [JsonRequired]
        [JsonProperty("offsetInMilliseconds")]
        public int OffsetInMilliseconds { get; set; }
    }
}