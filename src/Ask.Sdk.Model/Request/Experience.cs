using Newtonsoft.Json;

namespace Ask.Sdk.Model.Request
{
    public class Experience
    {
        [JsonProperty("arcMinuteWidth", NullValueHandling = NullValueHandling.Ignore)]
        public int? ArcMinuteWidth { get; set; }

        [JsonProperty("arcMinuteHeight", NullValueHandling = NullValueHandling.Ignore)]
        public int? ArcMinuteHeight { get; set; }

        [JsonProperty("canRotate", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CanRotate { get; set; }

        [JsonProperty("canResize", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CanResize { get; set; }
    }
}