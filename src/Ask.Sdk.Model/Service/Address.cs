using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ask.Sdk.Model.Service
{
    public class Address : ShortAddress
    {
        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set;}
        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set;}
        [JsonProperty("addressLine3")]
        public string AddressLine3 { get; set;}
        [JsonProperty("stateOrRegion")]
        public string StateOrRegion { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("districtOrCounty")]
        public string DistrictOrCounty { get; set; }
    }

    
}

