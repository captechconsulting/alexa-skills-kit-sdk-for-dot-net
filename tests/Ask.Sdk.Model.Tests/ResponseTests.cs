using Ask.Sdk.Model.Response;
using Ask.Sdk.Model.Response.Directive;
using Ask.Sdk.Model.Response.Directive.Templates;
using Ask.Sdk.Model.Response.Ssml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace Ask.Sdk.Model.Tests
{
    public class ResponseTests
    {
        private const string ExamplesPath = @"Examples";

        [Fact]
        public void Should_create_same_json_response_as_example()
        {
            var skillResponse = new ResponseEnvelope
            {
                SessionAttributes = new Dictionary<string, object>
                {
                    {
                        "supportedHoriscopePeriods", new
                        {
                            daily = true,
                            weekly = false,
                            monthly = false
                        }
                    }
                },
                Response = new Response.Response
                {
                    OutputSpeech = new PlainTextOutputSpeech
                    {
                        Text =
                            "Today will provide you a new learning opportunity. Stick with it and the possibilities will be endless. Can I help you with anything else?"
                    },
                    Card = new SimpleCard
                    {
                        Title = "Horoscope",
                        Content =
                            "Today will provide you a new learning opportunity. Stick with it and the possibilities will be endless."
                    },
                    ShouldEndSession = false
                }
            };

            var json = JsonConvert.SerializeObject(skillResponse, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            const string example = "Response.json";
            var workingJson = File.ReadAllText(Path.Combine(ExamplesPath, example));

            workingJson = Regex.Replace(workingJson, @"\s", "");
            json = Regex.Replace(json, @"\s", "");

            Assert.Equal(workingJson, json);
        }

        [Fact]
        public void Create_VideoAppDirective_FromSource()
        {
            var actual = new LaunchDirective("https://www.example.com/video/sample-video-1.mp4");
            Assert.True(Utility.CompareJson(actual, "VideoAppDirective.json"));
        }

        [Fact]
        public void Create_HintDirective()
        {
            var actual = new HintDirective { Hint = new Hint { Text = "sample text" } };
            var expected = JObject.Parse(@"{
            ""type"": ""Hint"",
            ""hint"": {
                ""type"": ""PlainText"",
                ""text"": ""sample text""
            }
        }");
            Assert.True(Utility.CompareObjectJson(actual, expected));
        }

        [Fact]
        public void AudioPlayerGeneratesCorrectJson()
        {
            var directive = new PlayDirective
            {
                PlayBehavior = PlayBehavior.Enqueue,
                AudioItem = new AudioItem
                {
                    Stream = new Response.Directive.Stream
                    {
                        Url = "https://url-of-the-stream-to-play",
                        Token = "opaque token representing this stream",
                        ExpectedPreviousToken = "opaque token representing the previous stream"
                    }
                }
            };
            Assert.True(Utility.CompareJson(directive, "AudioPlayerWithoutMetadata.json"));
        }

        [Fact]
        public void AudioPlayerWithMetadataGeneratesCorrectJson()
        {
            var directive = new PlayDirective
            {
                PlayBehavior = PlayBehavior.Enqueue,
                AudioItem = new AudioItem
                {
                    Stream = new Response.Directive.Stream
                    {
                        Url = "https://url-of-the-stream-to-play",
                        Token = "opaque token representing this stream",
                        ExpectedPreviousToken = "opaque token representing the previous stream"
                    },
                    Metadata = new AudioItemMetadata
                    {
                        Title = "title of the track to display",
                        Subtitle = "subtitle of the track to display",
                        Art = new Image
                        {
                            Sources = new[] { new ImageInstance("https://url-of-the-album-art-image.png") }.ToList()
                        },
                        BackgroundImage = new Image { Sources = new[] { new ImageInstance("https://url-of-the-background-image.png") }.ToList() }
                    }
                }
            };
            Assert.True(Utility.CompareJson(directive, "AudioPlayerWithMetadata.json"));
        }
        
        [Fact]
        public void AudioPlayerWithMetadataDeserializesCorrectly()
        {
            var audioPlayer = Utility.ExampleFileContent<PlayDirective>("AudioPlayerWithMetadata.json");
            Assert.Equal("title of the track to display", audioPlayer.AudioItem.Metadata.Title);
            Assert.Equal("subtitle of the track to display", audioPlayer.AudioItem.Metadata.Subtitle);
            Assert.Single(audioPlayer.AudioItem.Metadata.Art.Sources);
            Assert.Single(audioPlayer.AudioItem.Metadata.BackgroundImage.Sources);
            Assert.Equal("https://url-of-the-album-art-image.png", audioPlayer.AudioItem.Metadata.Art.Sources.First().Url);
            Assert.Equal("https://url-of-the-background-image.png", audioPlayer.AudioItem.Metadata.BackgroundImage.Sources.First().Url);
        }

        [Fact]
        public void AudioPlayerIgnoresMetadataWhenNull()
        {
            var audioPlayer = Utility.ExampleFileContent<PlayDirective>("AudioPlayerWithoutMetadata.json");
            Assert.Null(audioPlayer.AudioItem.Metadata);
            Assert.Equal("https://url-of-the-stream-to-play", audioPlayer.AudioItem.Stream.Url);
        }

        [Fact]
        public void RepromptStringGeneratesPlainTextOutput()
        {
            var result = new Reprompt("text");
            Assert.IsType<PlainTextOutputSpeech>(result.OutputSpeech);
            var plainText = (PlainTextOutputSpeech)result.OutputSpeech;
            Assert.Equal("text", plainText.Text);
        }

        [Fact]
        public void RepromptSsmlGeneratesPlainTextOutput()
        {
            var speech = new Speech(new PlainText("text"));
            var result = new Reprompt(speech);
            Assert.IsType<SsmlOutputSpeech>(result.OutputSpeech);
            var ssmlText = (SsmlOutputSpeech)result.OutputSpeech;
            Assert.Equal(speech.ToXml(), ssmlText.Ssml);
        }
    }
}
