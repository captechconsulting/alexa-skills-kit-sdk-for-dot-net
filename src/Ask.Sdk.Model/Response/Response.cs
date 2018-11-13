using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public class Response
    {
        [JsonProperty("outputSpeech", NullValueHandling = NullValueHandling.Ignore)]
        public IOutputSpeech OutputSpeech { get; set; }

        [JsonProperty("card", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(CardConverter))]
        public ICard Card { get; set; }

        [JsonProperty("reprompt", NullValueHandling = NullValueHandling.Ignore)]
        public Reprompt Reprompt { get; set; }

        [JsonProperty("shouldEndSession", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShouldEndSession { get; set; }

        [JsonProperty("directives", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IDirective> Directives { get; set; } = new List<IDirective>();

        [JsonProperty("canFullfillIntent", NullValueHandling = NullValueHandling.Ignore)]
        public CanFulfillIntent CanFulfillIntent { get; set; }

        public bool ShouldSerializeDirectives()
        {
            return Directives.Count > 0;
        }
    }
}
