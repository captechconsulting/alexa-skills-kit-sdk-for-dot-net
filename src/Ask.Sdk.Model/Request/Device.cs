using Newtonsoft.Json;

namespace Ask.Sdk.Model.Request
{
    public class Device
    {
        [JsonProperty("deviceId")]
        public string DeviceID { get; set; }

        [JsonProperty("supportedInterfaces")]
        public SupportedInterfaces SupportedInterfaces { get; set; }
    }
}