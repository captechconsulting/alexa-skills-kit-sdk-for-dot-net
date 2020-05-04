using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Alexa.NET.Response.Directive;
using Alexa.NET.Response.Ssml;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ask.Sdk.Core.Response
{
    public static class ResponseFactory
    {
        public static IResponseBuilder Init()
        {
            return new ResponseBuilder();
        }
    }

    internal class ResponseBuilder : IResponseBuilder
    {
        private ResponseBody _response = new ResponseBody();

        public IResponseBuilder AddAudioPlayerClearQueueDirective(ClearBehavior clearBehavior)
        {
            return AddDirective(new ClearQueueDirective
            {
                ClearBehavior = clearBehavior
            });
        }

        public IResponseBuilder AddAudioPlayerPlayDirective(PlayBehavior playBehavior, string url, string token, int offsetInMilliseconds, string expectedPreviousToken = null, AudioItemMetadata audioItemMetadata = null)
        {
            var stream = new AudioItemStream
            {
                Url = url,
                Token = token,
                OffsetInMilliseconds = offsetInMilliseconds
            };

            if (!string.IsNullOrEmpty(expectedPreviousToken))
                stream.ExpectedPreviousToken = expectedPreviousToken;

            var audioItem = new AudioItem
            {
                Stream = stream
            };

            if (audioItemMetadata != null)
            {
                audioItem.Metadata = audioItemMetadata;
            }

            var playDirective = new AudioPlayerPlayDirective
            {
                PlayBehavior = playBehavior,
                AudioItem = audioItem
            };

            return AddDirective(playDirective);
        }

        public IResponseBuilder AddAudioPlayerStopDirective()
        {
            return AddDirective(new StopDirective());
        }

        public IResponseBuilder AddConfirmIntentDirective(Intent updatedIntent = null)
        {
            var confirmIntentDirective = new DialogConfirmIntent();
            if (updatedIntent != null)
            {
                confirmIntentDirective.UpdatedIntent = updatedIntent;
            }

            return AddDirective(confirmIntentDirective);
        }

        public IResponseBuilder AddConfirmSlotDirective(string slotToConfirm, Intent updatedIntent = null)
        {
            var confirmSlotDirective = new DialogConfirmSlot(slotToConfirm);
            if (updatedIntent != null)
            {
                confirmSlotDirective.UpdatedIntent = updatedIntent;
            }

            return AddDirective(confirmSlotDirective);
        }

        public IResponseBuilder AddDelegateDirective(Intent updatedIntent = null)
        {
            var delegateDirective = new DialogDelegate();

            if (updatedIntent != null)
            {
                delegateDirective.UpdatedIntent = updatedIntent;
            }

            return AddDirective(delegateDirective);
        }

        public IResponseBuilder AddDirective(IDirective directive)
        {
            if (_response.Directives == null)
                _response.Directives = new List<IDirective>();

            _response.Directives.Add(directive);

            return this;
        }

        public IResponseBuilder AddElicitSlotDirective(string slotToElicit, Intent updatedIntent = null)
        {
            var elicitSlotDirective = new DialogElicitSlot(slotToElicit);

            if (updatedIntent != null)
            {
                elicitSlotDirective.UpdatedIntent = updatedIntent;
            }

            return AddDirective(elicitSlotDirective);
        }

        public IResponseBuilder AddHintDirective(string text)
        {
            return AddDirective(new HintDirective
            {
                Hint = new Hint
                {
                    Type = "PlainText",
                    Text = text
                }
            });
        }

        public IResponseBuilder AddRenderTemplateDirective(ITemplate template)
        {
            return AddDirective(new DisplayRenderTemplateDirective
            {
                Template = template
            });
        }

        public IResponseBuilder AddVideoAppLaunchDirective(string source, string title = null, string subtitle = null)
        {
            var videoItem = new VideoItem(source);

            if (!string.IsNullOrEmpty(title) || !string.IsNullOrEmpty(subtitle))
            {
                videoItem.Metadata = new VideoItemMetadata
                {
                    Subtitle = subtitle,
                    Title = title
                };
            }

            _response.ShouldEndSession = null;

            return AddDirective(new VideoAppDirective
            {
                VideoItem = videoItem
            });
        }

        public ResponseBody GetResponse()
        {
            return _response;
        }

        public IResponseBuilder Reprompt(string repromptSpeechOutput)
        {
            return Reprompt(new PlainText(repromptSpeechOutput));
        }
        public IResponseBuilder Reprompt(params ISsml[] elements)
        {
            _response.Reprompt = new Reprompt
            {
                OutputSpeech = new SsmlOutputSpeech
                {
                    Ssml = new Speech(elements).ToXml()
                }
            };

            if (!IsVideoAppLaunchDirectivePresent())
            {
                _response.ShouldEndSession = false;
            }

            return this;
        }

        public IResponseBuilder Speak(string speechOutput)
        {
            speechOutput = TrimOutputSpeech(speechOutput);
            return Speak(new PlainText(speechOutput.Trim()));
        }

        public IResponseBuilder Speak(params ISsml[] elements)
        {
            _response.OutputSpeech = new SsmlOutputSpeech
            {
                Ssml = new Speech(elements).ToXml()
            };

            return this;
        }

        public IResponseBuilder WithAskForPermissionsConsentCard(List<string> permissionArray)
        {
            _response.Card = new AskForPermissionsConsentCard
            {
                Permissions = permissionArray
            };

            return this;
        }

        public IResponseBuilder WithCanFulfillIntent(CanFulfillIntent canFulfillIntent)
        {
            _response = _response.CanFulfill(canFulfillIntent);

            return this;
        }

        public IResponseBuilder WithLinkAccountCard()
        {
            _response.Card = new LinkAccountCard();

            return this;
        }

        public IResponseBuilder WithShouldEndSession(bool val)
        {
            if (!IsVideoAppLaunchDirectivePresent())
                _response.ShouldEndSession = val;

            return this;
        }

        public IResponseBuilder WithSimpleCard(string cardTitle, string cardContent)
        {
            _response.Card = new SimpleCard
            {
                Title = cardTitle,
                Content = cardContent
            };

            return this;
        }

        public IResponseBuilder WithStandardCard(string cardTitle, string cardContent, string smallImageUrl = null, string largeImageUrl = null)
        {
            var card = new StandardCard
            {
                Title = cardTitle,
                Content = cardContent
            };

            if (!string.IsNullOrEmpty(smallImageUrl) || !string.IsNullOrEmpty(largeImageUrl))
            {
                card.Image = new CardImage
                {
                    SmallImageUrl = smallImageUrl,
                    LargeImageUrl = largeImageUrl
                };
            }

            _response.Card = card;

            return this;
        }

        private bool IsVideoAppLaunchDirectivePresent()
        {
            return _response.Directives?.Any(d => d is VideoAppDirective) ?? false;
        }

        private string TrimOutputSpeech(string speechOutput)
        {
            if (string.IsNullOrEmpty(speechOutput))
                return speechOutput ?? string.Empty;

            var speech = speechOutput.Trim();
            if (speech.StartsWith("<speak>") && speech.EndsWith("</speak>"))
            {
                try
                {
                    return XElement.Parse(speech).Value.Trim();
                }
                catch
                {
                }
            }

            return speech;
        }
    }
}
