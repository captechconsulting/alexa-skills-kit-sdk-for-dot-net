using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using System;
using System.Threading.Tasks;

namespace ProgressiveResponseLambda.Handlers
{
    public class ProgressiveResponseHandler : ICustomSkillRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput input)
        {
            return Task.FromResult(input.RequestEnvelope.Request is LaunchRequest ||
                (input.RequestEnvelope.Request is IntentRequest intent && intent.Intent.Name == "ProgressiveResponseIntent"));
        }

        public async Task<ResponseBody> Handle(IHandlerInput input)
        {
            try
            {
                var progressiveResponse = new ProgressiveResponse(input.RequestEnvelope);
                await progressiveResponse.SendSpeech("This is a progressive response message");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message} {ex.StackTrace}");
                return input.ResponseBuilder
                    .Speak("That didn't go as planned")
                    .GetResponse();
            }

            return input.ResponseBuilder
                .Speak("You should have gotten a progressive response")
                .GetResponse();
        }
    }
}
