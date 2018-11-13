using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public class LinkAccountCard : ICard
    {
        [JsonProperty("type")]
        public string Type => "LinkAccount";
    }
}
