using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Ask.Sdk.Model.Request
{
    public class ViewPortState
    {
        [JsonProperty("experiences", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Experience> Experiences { get; set; }

        [JsonProperty("shape", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Shape? Shape { get; set; }

        [JsonProperty("pixelWidth", NullValueHandling = NullValueHandling.Ignore)]
        public int? PixelWidth { get; set; }

        [JsonProperty("pixelHeight", NullValueHandling = NullValueHandling.Ignore)]
        public int? PixelHeight { get; set; }

        [JsonProperty("dpi", NullValueHandling = NullValueHandling.Ignore)]
        public int? Dpi { get; set; }

        [JsonProperty("currentPixelWidth", NullValueHandling = NullValueHandling.Ignore)]
        public int? CurrentPixelWidth { get; set; }

        [JsonProperty("currentPixelHeight", NullValueHandling = NullValueHandling.Ignore)]
        public int? CurrentPixelHeight { get; set; }

        [JsonProperty("touch", NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
        public IEnumerable<Touch> Touch { get; set; }

        [JsonProperty("keyboard", NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
        public IEnumerable<Keyboard> Keyboard { get; set; }
    }
}