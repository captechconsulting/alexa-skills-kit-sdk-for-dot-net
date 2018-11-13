using Newtonsoft.Json;

namespace Ask.Sdk.Model.Response.Directive.Templates
{
    public class TextField
    {
        [JsonProperty("text", Required = Required.Always)]
        public string Text { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }
    }
}