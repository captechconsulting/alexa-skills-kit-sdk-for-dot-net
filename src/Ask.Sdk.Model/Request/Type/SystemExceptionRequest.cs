using Newtonsoft.Json;

namespace Ask.Sdk.Model.Request.Type
{
    public class SystemExceptionRequest : Request
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
        [JsonProperty("cause")]
        public ErrorCause ErrorCause { get; set; }
    }
}