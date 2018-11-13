using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public class SpeakDirective : IDirective
    {
        public SpeakDirective(Ssml.Speech speech) : this(speech.ToXml())
        {

        }

        public SpeakDirective(string speech)
        {
            Speech = speech;
        }

        [JsonProperty("type")]
        public string Type => "VoicePlayer.Speak";

        [JsonProperty("speech")]
        public string Speech { get; }
    }
}
