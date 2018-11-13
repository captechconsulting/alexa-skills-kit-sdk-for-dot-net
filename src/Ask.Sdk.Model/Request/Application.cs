using Newtonsoft.Json;

namespace Ask.Sdk.Model.Request
{
    public class Application
    {
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }
    }
}