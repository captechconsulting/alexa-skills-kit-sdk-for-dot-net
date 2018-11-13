using Newtonsoft.Json;

namespace Ask.Sdk.Model.Service.Ups
{
    public class PhoneNumber
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("phoneNumber")]
        public string Number { get; set; }
    }
}