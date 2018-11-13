using Ask.Sdk.Model.Response.Ssml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Directive
{
    public class SpeakDirective : IDirective
    {
        public SpeakDirective(string speech)
        {
            Speech = speech;
        }

        public SpeakDirective(Speech speech) : this(speech.ToXml())
        {
        }

        [JsonProperty("type")]
        public string Type => "VoicePlayer.Speak";

        [JsonProperty("speech")]
        public string Speech { get; }
    }
}
