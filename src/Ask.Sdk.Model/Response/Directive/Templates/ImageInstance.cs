using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ask.Sdk.Model.Response.Directive.Templates
{
    public class ImageInstance
    {
        public ImageInstance() { }

        public ImageInstance(string url)
        {
            Url = url;
        }

        [JsonProperty("url", Required = Required.Always)]
        public string Url { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ImageSize? Size { get; set; }

        [JsonProperty("widthPixels")]
        public int Width { get; set; }

        [JsonProperty("heightPixels")]
        public int Height { get; set; }

        public bool ShouldSerializeWidth()
        {
            return Width > 0;
        }

        public bool ShouldSerializeHeight()
        {
            return Height > 0;
        }
    }
}