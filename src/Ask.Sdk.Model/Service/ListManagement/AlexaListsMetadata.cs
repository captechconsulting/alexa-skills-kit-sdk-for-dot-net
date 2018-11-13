using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Service.ListManagement
{
    public class AlexaListsMetadata
    {
        [JsonProperty("lists")]
        public List<AlexaListMetadata> Lists { get; set; }
    }
}
