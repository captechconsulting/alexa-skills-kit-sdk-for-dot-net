using Newtonsoft.Json;

namespace Ask.Sdk.Model.Response.Directive
{
    public class VideoItemMetadata
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("subtitle", NullValueHandling = NullValueHandling.Ignore)]
        public string Subtitle { get; set; }
    }
}