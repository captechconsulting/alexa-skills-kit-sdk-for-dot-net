using Newtonsoft.Json;

namespace Ask.Sdk.Model.Request.Type
{
    public class Permission
    {
        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}