using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceAddressLambda.Handlers
{
    public class CancelAndStopIntentHandler : IRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            if (handlerInput.RequestEnvelope.Request is IntentRequest intent)
            {
                return Task.FromResult(intent.Intent.Name == BuiltInIntent.Stop 
                    || intent.Intent.Name == BuiltInIntent.Cancel);
            }

            return Task.FromResult(false);
        }

        public Task<Response> Handle(IHandlerInput handlerInput)
        {
            var speechText = "Goodbye";

            return Task.FromResult(handlerInput.ResponseBuilder
                .Speak(speechText)
                .WithSimpleCard("HelloWorld", speechText)
                .GetResponse());
        }
    }
}
