using Newtonsoft.Json;

namespace Ask.Sdk.Model.Request.Type
{
    public class ErrorCause
    {
        [JsonProperty("requestId")]
        public string requestId { get; set; }
    }
}