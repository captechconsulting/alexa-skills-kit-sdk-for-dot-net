using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public class LaunchDirective : IDirective
    {
        public LaunchDirective()
        {
        }

        public LaunchDirective(string source)
        {
            VideoItem = new VideoItem(source);
        }

        [JsonProperty("type")]
        public string Type => "VideoApp.Launch";

        [JsonProperty("videoItem", Required = Required.Always)]
        public VideoItem VideoItem { get; set; }
    }
}
