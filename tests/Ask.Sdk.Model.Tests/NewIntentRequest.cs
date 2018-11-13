using Newtonsoft.Json;

namespace Ask.Sdk.Model.Tests
{
    public class NewIntentRequest : Model.Request.Request
    {
        [JsonProperty("testProperty")]
        public bool TestProperty { get; set; }
    }
}