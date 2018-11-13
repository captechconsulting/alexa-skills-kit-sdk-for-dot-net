using Newtonsoft.Json;

namespace Ask.Sdk.Model.Request.Type
{
    public class PermissionSkillEventRequest : Request
    {
        [JsonProperty("body")]
        public SkillEventPermissions Body { get; set; }
    }
}