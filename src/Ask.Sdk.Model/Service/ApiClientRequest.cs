using Newtonsoft.Json;

namespace Ask.Sdk.Model.Service
{
    public class ApiClientRequest : ApiClientMessage
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("contentType")]
        public string ContentType => "application/json";
    }
}