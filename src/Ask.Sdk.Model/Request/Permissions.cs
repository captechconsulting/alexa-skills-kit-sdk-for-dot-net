using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ask.Sdk.Model.Request
{
    public class Permissions
    {
        [JsonProperty("consentToken")]
        public string ConsentToken { get; set; }

        [JsonProperty("scopes")]
        public Dictionary<string, Scope> Scopes { get; set; }
    }
}