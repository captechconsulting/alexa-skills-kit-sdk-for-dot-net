using Alexa.NET.Request;
using Alexa.NET.Response;
using Alexa.NET.Response.Directive;
using Alexa.NET.Response.Ssml;
using System.Collections.Generic;

namespace Ask.Sdk.Core.Response
{
    public interface IResponseBuilder
    {
        IResponseBuilder Speak(string speechOutput);

        IResponseBuilder Speak(ISsml[] elements);

        IResponseBuilder Reprompt(string repromptSpeechOutput);

        IResponseBuilder Reprompt(ISsml[] elements);

        IResponseBuilder WithSimpleCard(string cardTitle, 
            string cardContent);

        IResponseBuilder WithStandardCard(string cardTitle, 
            string cardContent, 
            string smallImageUrl = null, 
            string largeImageUrl = null);

        IResponseBuilder WithLinkAccountCard();

        IResponseBuilder WithAskForPermissionsConsentCard(List<string> permissionArray);

        IResponseBuilder AddDelegateDirective(Intent updatedIntent = null);

        IResponseBuilder AddElicitSlotDirective(string slotToElicit,
            Intent updatedIntent = null);

        IResponseBuilder AddConfirmSlotDirective(string slotToConfirm,
            Intent updatedIntent = null);

        IResponseBuilder AddConfirmIntentDirective(Intent updatedIntent = null);

        IResponseBuilder AddAudioPlayerPlayDirective(PlayBehavior playBehavior,
            string url,
            string token,
            int offsetInMilliseconds,
            string expectedPreviousToken = null,
            AudioItemMetadata audioItemMetadata = null);

        IResponseBuilder AddAudioPlayerStopDirective();

        IResponseBuilder AddAudioPlayerClearQueueDirective(ClearBehavior clearBehavior);

        IResponseBuilder AddRenderTemplateDirective(ITemplate template);

        IResponseBuilder AddHintDirective(string text);

        IResponseBuilder AddVideoAppLaunchDirective(string source,
            string title = null,
            string subtitle = null);

        IResponseBuilder WithCanFulfillIntent(CanFulfillIntent canFulfillIntent);

        IResponseBuilder WithShouldEndSession(bool val);

        IResponseBuilder AddDirective(IDirective directive);

        ResponseBody GetResponse();
    }
}
