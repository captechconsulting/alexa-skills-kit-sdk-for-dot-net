using Newtonsoft.Json;

namespace Ask.Sdk.Model.Response
{
    public class UiImage
    {
        [JsonProperty("smallImageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string SmallImageUrl { get; set; }

        [JsonProperty("largeImageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string LargeImageUrl { get; set; }
    }
}