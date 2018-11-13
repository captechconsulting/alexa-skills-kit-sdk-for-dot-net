using Amazon.Lambda.Core;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDbLambda.Handlers
{
    public class HelloWorldIntentHandler : IRequestHandler
    {

        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            if (handlerInput.RequestEnvelope.Request is IntentRequest intent)
            {
                return Task.FromResult(intent.Intent.Name == "HelloWorldIntent");
            }

            return Task.FromResult(false);
        }

        public async Task<Response> Handle(IHandlerInput handlerInput)
        {
            var attributes = await handlerInput.AttributesManager.GetPersistentAttributes();
            attributes["TimeCalled"] = DateTime.Now;
            await handlerInput.AttributesManager.SetPersistentAttributes(attributes);
            await handlerInput.AttributesManager.SavePersistentAttributes();
            var speechText = "Hello World";
            return handlerInput.ResponseBuilder
                .Speak(speechText)
                .WithSimpleCard("HelloWorld", speechText)
                .GetResponse();
        }
    }
}
