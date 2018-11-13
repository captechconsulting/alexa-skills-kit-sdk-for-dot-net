using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldFunction.Handlers
{
    public class LaunchRequestHandler : IRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput input)
        {
            return Task.FromResult(input.RequestEnvelope.Request is LaunchRequest);
        }

        public Task<Response> Handle(IHandlerInput input)
        {
            var speechText = "Welcome to the Alexa Skills Kit, you can say hello";
            return Task.FromResult(input.ResponseBuilder
                .Speak(speechText)
                .WithSimpleCard("HelloWorld", speechText)
                .GetResponse());

        }
    }
}
