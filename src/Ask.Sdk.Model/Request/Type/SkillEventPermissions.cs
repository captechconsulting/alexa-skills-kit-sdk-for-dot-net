using Newtonsoft.Json;

namespace Ask.Sdk.Model.Request.Type
{
    public class SkillEventPermissions
    {
        [JsonProperty("acceptedPermissions")]
        public Permission[] AcceptedPermissions { get; set; }
    }
}