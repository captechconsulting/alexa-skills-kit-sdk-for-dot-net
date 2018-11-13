using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ask.Sdk.Model.Service
{
    public class ShortAddress
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }

    
}