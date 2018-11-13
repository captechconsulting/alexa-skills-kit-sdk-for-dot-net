using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public class AskForPermissionsConsentCard : ICard
    {
        [JsonProperty("type")]
        [JsonRequired]
        public string Type => "AskForPermissionsConsent";

        [JsonProperty("permissions")]
        [JsonRequired]
        public List<string> Permissions { get; set; } = new List<string>();
    }
}
