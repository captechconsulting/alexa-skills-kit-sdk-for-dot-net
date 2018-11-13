using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public class StopDirective : IDirective
    {
        [JsonProperty("type")]
        public string Type => "AudioPlayer.Stop";
    }
}
