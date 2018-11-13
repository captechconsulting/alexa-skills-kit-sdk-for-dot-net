using Newtonsoft.Json;

namespace Ask.Sdk.Model.Request.Type
{
    public class DisplayElementSelectedRequest : Request
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}