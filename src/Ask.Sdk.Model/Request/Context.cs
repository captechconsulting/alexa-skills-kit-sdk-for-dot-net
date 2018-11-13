using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Request
{
    public class Context
    {
        [JsonProperty("System")]
        public SystemState System { get; set; }

        [JsonProperty("AudioPlayer")]
        public AudioPlayerState AudioPlayer { get; set; }

        [JsonProperty("Display")]
        public DisplayState Display { get; set; }

        [JsonProperty("ViewPort")]
        public ViewPortState ViewPort { get; set; }
    }
}
