using Newtonsoft.Json;

namespace Ask.Sdk.Model.Request.Type
{
    public class AccountLinkSkillEventRequest : Request
    {
        [JsonProperty("body")]
        public AccountLinkSkillEventDetail Body { get; set; }
    }

    public class AccountLinkSkillEventDetail
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }
}