using Ask.Sdk.Core.Response;
using Ask.Sdk.Model.Response;
using Ask.Sdk.Model.Response.Directive;
using Ask.Sdk.Model.Response.Directive.Templates;
using Ask.Sdk.Model.Response.Directive.Templates.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Ask.Sdk.Core.Tests.Response
{
    public class ResponseFactoryTests : BaseTests
    {
        private const string _speechOutput = "HelloWorld!";
        private const string _exampleFolder = "Examples";

        [Theory]
        [InlineData("HelloWorld!", "<speak>HelloWorld!</speak>")]
        [InlineData("<speak>  HelloWorld!  </speak>", "<speak>HelloWorld!</speak>")]
        [InlineData("    <speak>  HelloWorld!  </speak>     ", "<speak>HelloWorld!</speak>")]
        [InlineData("<speak>HelloWorld!</speak>", "<speak>HelloWorld!</speak>")]
        [InlineData("", "<speak></speak>")]
        [InlineData(null, "<speak></speak>")]
        public void Should_Build_Response_With_Ssml_Output_Speech(string speechOutput, string expectedOutput)
        {
            var responseBuilder = ResponseFactory.Init();

            var response = responseBuilder.Speak(speechOutput).GetResponse();

            Assert.IsType<SsmlOutputSpeech>(response.OutputSpeech);

            if (response.OutputSpeech is SsmlOutputSpeech outputSpeech)
            {
                Assert.Equal(expectedOutput, outputSpeech.Ssml);
            }
        }

        [Fact]
        public void Should_Build_Response_With_Ssml_Reprompt()
        {
            var responseBuilder = ResponseFactory.Init();

            var response = responseBuilder.Reprompt(_speechOutput).GetResponse();

            Assert.NotNull(response.Reprompt?.OutputSpeech);
            Assert.IsType<SsmlOutputSpeech>(response.Reprompt.OutputSpeech);
            Assert.Equal($"<speak>{_speechOutput}</speak>", ((SsmlOutputSpeech)response.Reprompt.OutputSpeech).Ssml);
            Assert.False(response.ShouldEndSession);
        }

        [Theory]
        [InlineData("Card Title", "Card Content", null, null, "StandardCardOnlyContent.json")]
        [InlineData("Card Title", "Card Content", "https://url-to-small-card-image...", null, "StandardCardSmallImage.json")]
        [InlineData("Card Title", "Card Content", null, "https://url-to-large-card-image...", "StandardCardLargeImage.json")]
        [InlineData("Card Title", "Card Content", "https://url-to-small-card-image...", "https://url-to-large-card-image...", "StandardCardSmallAndLargeImage.json")]
        public void Should_Build_Response_With_Standard_Card(string cardTitle, string cardContent, string smallImageUrl, string largeImageUrl, string expectedFile)
        {
            var responseBuilder = ResponseFactory.Init();

            var response = responseBuilder.WithStandardCard(cardTitle, cardContent, smallImageUrl, largeImageUrl).GetResponse();

            Assert.True(CompareJson(response, expectedFile));
        }

        [Fact]
        public void Should_Build_Response_With_Link_Account_Card()
        {
            var responseBuilder = ResponseFactory.Init();

            var response = responseBuilder.WithLinkAccountCard().GetResponse();

            Assert.True(CompareJson(response, "LinkAccountCard.json"));
        }

        [Fact]
        public void Should_Build_Response_With_Permissions_Consent_Card()
        {
            var responseBuilder = ResponseFactory.Init();

            var response = responseBuilder.WithAskForPermissionsConsentCard(new List<string>
            {
                "permission1",
                "permission2"
            }).GetResponse();

            Assert.True(CompareJson(response, "PermissionsConsentCard.json"));
        }

        [Fact]
        public void Should_Build_Response_With_Dialog_Delegate_Directive()
        {
            var responseBuilder = ResponseFactory.Init();

            var slot = Slot;
            slot.Name = "slot1";
            slot.Value = "value1";
            slot.ConfirmationStatus = Model.Request.IntentConfirmationStatus.None;

            var intent = Intent;
            intent.Name = "intentName";
            intent.Slots = new Dictionary<string, Model.Request.Slot>
            {
                {"slot1", slot }
            };
            intent.ConfirmationStatus = Model.Request.IntentConfirmationStatus.None;

            var response = responseBuilder.AddDelegateDirective(intent).GetResponse();

            Assert.True(CompareJson(response, "DialogDelegateDirectiveCard.json"));
        }

        [Fact]
        public void Should_Build_Response_With_Dialog_Elicit_Slot_Directive()
        {
            var responseBuilder = ResponseFactory.Init();

            var slot = Slot;
            slot.Name = "slot1";
            slot.Value = "value1";
            slot.ConfirmationStatus = Model.Request.IntentConfirmationStatus.None;

            var intent = Intent;
            intent.Name = "intentName";
            intent.Slots = new Dictionary<string, Model.Request.Slot>
            {
                {"slot1", slot }
            };
            intent.ConfirmationStatus = Model.Request.IntentConfirmationStatus.None;

            var response = responseBuilder.AddElicitSlotDirective("slotName", intent).GetResponse();

            Assert.True(CompareJson(response, "DialogElicitSlotDirectiveCard.json"));
        }

        [Fact]
        public void Should_Build_Response_With_Dialog_Confirm_Slot_Directive()
        {
            var responseBuilder = ResponseFactory.Init();

            var slot = Slot;
            slot.Name = "slot1";
            slot.Value = "value1";
            slot.ConfirmationStatus = Model.Request.IntentConfirmationStatus.None;

            var intent = Intent;
            intent.Name = "intentName";
            intent.Slots = new Dictionary<string, Model.Request.Slot>
            {
                {"slot1", slot }
            };
            intent.ConfirmationStatus = Model.Request.IntentConfirmationStatus.None;

            var response = responseBuilder.AddConfirmSlotDirective("slotName", intent).GetResponse();

            Assert.True(CompareJson(response, "DialogConfirmSlotDirectiveCard.json"));
        }

        [Fact]
        public void Should_Build_Response_With_Dialog_Confirm_Intent_Directive()
        {
            var responseBuilder = ResponseFactory.Init();

            var slot = Slot;
            slot.Name = "slot1";
            slot.Value = "value1";
            slot.ConfirmationStatus = Model.Request.IntentConfirmationStatus.None;

            var intent = Intent;
            intent.Name = "intentName";
            intent.Slots = new Dictionary<string, Model.Request.Slot>
            {
                {"slot1", slot }
            };
            intent.ConfirmationStatus = Model.Request.IntentConfirmationStatus.None;

            var response = responseBuilder.AddConfirmIntentDirective(intent).GetResponse();

            Assert.True(CompareJson(response, "DialogConfirmIntentDirectiveCard.json"));
        }

        [Theory]
        [InlineData(PlayBehavior.Enqueue, "https://url/to/audiosource", "audio token", 10000, "previous token", false, "AudioPlayerPlayDirectiveNoMetadata.json")]
        [InlineData(PlayBehavior.Enqueue, "https://url/to/audiosource", "audio token", 10000, null, false, "AudioPlayerPlayDirectiveNoMetadataNoToken.json")]
        [InlineData(PlayBehavior.Enqueue, "https://url/to/audiosource", "audio token", 10000, "previous token", true, "AudioPlayerPlayDirective.json")]
        public void Should_Build_Response_With_Audio_Player_Play_Directive(PlayBehavior behavior, string audioSource, string audioToken, int offset, string previousToken, bool includeMetadata, string expectedFile)
        {
            var responseBuilder = ResponseFactory.Init();

            AudioItemMetadata metadata = includeMetadata ? new AudioItemMetadata
            {
                Title = "title",
                Subtitle = "subtitle",
                Art = new ImageHelper().WithDescription("description").AddImageInstance("fakeUrl.com").Image,
                BackgroundImage = new ImageHelper().WithDescription("description").AddImageInstance("fakeUrl.com").Image
            } : null;

            var response = responseBuilder.AddAudioPlayerPlayDirective(behavior, audioSource, audioToken, offset, previousToken, metadata)
                .GetResponse();

            Assert.True(CompareJson(response, expectedFile));
        }

        [Fact]
        public void Should_Build_Response_With_Audio_Player_Stop_Directive()
        {
            var responseBuilder = ResponseFactory.Init();

            var response = responseBuilder.AddAudioPlayerStopDirective().GetResponse();

            Assert.True(CompareJson(response, "AudioPlayerStopDirective.json"));
        }

        [Fact]
        public void Should_Build_Response_With_Audio_Player_Clear_Queue_Directive()
        {
            var responseBuilder = ResponseFactory.Init();

            var behavior = ClearBehavior.ClearAll;

            var response = responseBuilder.AddAudioPlayerClearQueueDirective(behavior).GetResponse();

            Assert.True(CompareJson(response, "AudioPlayerClearQueueDirective.json"));
        }

        [Fact]
        public void Should_Build_Response_With_Rendering_Body_Template1_Directive()
        {
            var responseBuilder = ResponseFactory.Init();

            var backgroundImage = new ImageHelper()
                .WithDescription("description")
                .AddImageInstance("https://url/to/imagesource", ImageSize.Medium, 100, 100)
                .Image;

            var textContent = new RichTextContentHelper()
                .WithPrimaryText("primary text")
                .WithSecondaryText("secondary text")
                .WithTertiaryText("tertiary text")
                .GetTextContent();

            var displayTemplate = new BodyTemplate1
            {
                Token = "token",
                BackButton = BackButtonBehavior.Visible,
                BackgroundImage = backgroundImage,
                Title = "title",
                Content = textContent
            };

            var response = responseBuilder.AddRenderTemplateDirective(displayTemplate).GetResponse();

            Assert.True(CompareJson(response, "BodyTemplate1Directive.json"));
        }

        [Fact]
        public void Should_Build_Response_With_Plain_Text_Hint_Directive()
        {
            var responseBuilder = ResponseFactory.Init();
            var hintText = "This is plainText hint";

            var response = responseBuilder.AddHintDirective(hintText).GetResponse();

            Assert.True(CompareJson(response, "PlainTextHintDirective.json"));
        }

        [Theory]
        [InlineData("https://url/to/videosource", "Secondary Title for Sample Video", "Title for Sample Video", "VideoAppLaunchDirective.json")]
        [InlineData("https://url/to/videosource", "Secondary Title for Sample Video", null, "VideoAppLaunchNoTitleDirective.json")]
        [InlineData("https://url/to/videosource", null, "Title for Sample Video", "VideoAppLaunchNoSubTitleDirective.json")]
        [InlineData("https://url/to/videosource", null, null, "VideoAppLaunchNoTitlesDirective.json")]
        public void Should_Build_Response_With_Video_App_Launch_Directive(string videoSource, string subTitle, string title, string expectedFile)
        {
            var responseBuilder = ResponseFactory.Init();
            
            var response = responseBuilder.AddVideoAppLaunchDirective(videoSource, title, subTitle)
                .GetResponse();


            Assert.True(CompareJson(response, expectedFile));
        }

        [Fact]
        public void Should_Omit_Should_End_Session_Flag_If_Video_App_Launch_Directive_Added()
        {
            var videoSource = "https://url/to/videosource";
            var title = "Title for Sample Video";
            var subTitle = "Secondary Title for Sample Video";

            var response = ResponseFactory.Init().WithShouldEndSession(true)
                .AddVideoAppLaunchDirective(videoSource, title, subTitle)
                .GetResponse();

            Assert.True(CompareJson(response, "VideoAppLaunchDirective.json"));

            response = ResponseFactory.Init().AddVideoAppLaunchDirective(videoSource, title, subTitle)
                .WithShouldEndSession(true)
                .GetResponse();

            Assert.True(CompareJson(response, "VideoAppLaunchDirective.json"));

            var speechOutput = "HelloWorld!";

            response = ResponseFactory.Init().Reprompt(speechOutput)
                .AddVideoAppLaunchDirective(videoSource, title, subTitle)
                .GetResponse();

            Assert.True(CompareJson(response, "VideoAppLaunchWithRepromptDirective.json"));

            response = ResponseFactory.Init().AddVideoAppLaunchDirective(videoSource, title, subTitle)
                .Reprompt(speechOutput)
                .GetResponse();

            Assert.True(CompareJson(response, "VideoAppLaunchWithRepromptDirective.json"));
        }

        [Fact]
        public void Should_Build_Response_With_Can_Fulfill_Intent()
        {
            var responseBuilder = ResponseFactory.Init();
            var canFulfillIntent = new CanFulfillIntent
            {
                CanFulfill = CanFulfillIntentValues.Yes,
                Slots = new Dictionary<string, CanFulFillSlot>
                {
                    { "foo", new CanFulFillSlot
                    {
                        CanUnderstand = CanUnderstandSlotValues.Maybe,
                        CanFulfill = CanFulfillSlotValues.Yes
                    }
                    }
                }
            };

            var response = responseBuilder.WithCanFulfillIntent(canFulfillIntent).GetResponse();

            Assert.True(CompareJson(response, "CanFulfillIntent.json"));
        }

        [Fact]
        public void Should_Build_Response_With_Should_End_Session_Value()
        {
            var responseBuilder = ResponseFactory.Init();

            var response = responseBuilder.WithShouldEndSession(true).GetResponse();

            Assert.True(CompareJson(response, "ShouldEndSession.json"));
        }

        [Fact]
        public void Should_Build_Response_With_Output_And_Card()
        {
            var responseBuilder = ResponseFactory.Init();

            var speechOutput = "HelloWorld!";
            var cardTitle = "Card Title";
            var cardContent = "Card Content";

            var response = responseBuilder.Speak(speechOutput)
                .WithSimpleCard(cardTitle, cardContent)
                .WithShouldEndSession(false)
                .GetResponse();

            Assert.True(CompareJson(response, "SpeechWithSimpleCard.json"));
        }

        [Fact]
        public void Should_Build_Response_With_Template_Directive_And_Hint_Directive()
        {
            var speechOutput = "HelloWorld!";
            var backgroundImage = new ImageHelper()
                    .WithDescription("description")
                    .AddImageInstance("https://url/to/imagesource", ImageSize.Medium, 100, 100)
                    .Image;
                                                                        ;
            var textContent = new RichTextContentHelper()
                .WithPrimaryText("primary text")
                .WithSecondaryText("secondary text")
                .WithTertiaryText("teritiary text")
                .GetTextContent();

            var displayTemplate = new BodyTemplate1 {
                Token = "token",
                BackButton = BackButtonBehavior.Visible,
                BackgroundImage = backgroundImage,
                Title = "title",
                Content = textContent
            };

            var hintText = "This is plainText hint";

            var response = ResponseFactory.Init()
                .AddRenderTemplateDirective(displayTemplate)
                .AddHintDirective(hintText)
                .Speak(speechOutput)
                .Reprompt(speechOutput)
                .GetResponse();

            Assert.True(CompareJson(response, "TemplateAndHintDirective.json"));

            response = ResponseFactory.Init()
                .AddDirective(new RenderTemplateDirective
                {
                    Template = displayTemplate
                })
                .AddDirective(new HintDirective
                {
                    Hint = new Hint
                    {
                        Text = hintText
                    }
                })
                .Speak(speechOutput)
                .Reprompt(speechOutput)
                .GetResponse();

            Assert.True(CompareJson(response, "TemplateAndHintDirective.json"));
        }

        public static bool CompareJson(object actual, string expectedFile)
        {
            var actualJObject = JObject.FromObject(actual);
            var expected = File.ReadAllText(Path.Combine(_exampleFolder, expectedFile));
            var expectedJObject = JObject.Parse(expected);
            Console.WriteLine(actualJObject);
            return JToken.DeepEquals(expectedJObject, actualJObject);
        }
    }
}
