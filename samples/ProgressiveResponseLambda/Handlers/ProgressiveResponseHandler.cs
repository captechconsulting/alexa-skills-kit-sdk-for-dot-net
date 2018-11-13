using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Directive;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveResponseLambda.Handlers
{
    public class ProgressiveResponseHandler : IRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput input)
        {
            return Task.FromResult(input.RequestEnvelope.Request is LaunchRequest ||
                (input.RequestEnvelope.Request is IntentRequest intent && intent.Intent.Name == "ProgressiveResponseIntent"));
        }

        public async Task<Response> Handle(IHandlerInput input)
        {
            try
            {
                var client = input.ServiceClientFactory.GetDirectiveServiceClient();

                var request = new SendDirectiveRequest
                {
                    Header = new Header
                    {
                        RequestId = input.RequestEnvelope.Request?.RequestId
                    },
                    Directive = new SpeakDirective("This is a progressive response message")
                };

                await client.Enqueue(request);
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
