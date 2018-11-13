using Newtonsoft.Json;

namespace Ask.Sdk.Model.Request
{
    public class DisplayInterface
    {
        [JsonProperty("templateVersion")]
        public string TemplateVersion { get; set; }

        [JsonProperty("markupVersion")]
        public string MarkupVersion { get; set; }
    }
}