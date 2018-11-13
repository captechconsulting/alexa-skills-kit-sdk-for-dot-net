using Newtonsoft.Json;

namespace Ask.Sdk.Model.Request
{
    public class DisplayState
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}