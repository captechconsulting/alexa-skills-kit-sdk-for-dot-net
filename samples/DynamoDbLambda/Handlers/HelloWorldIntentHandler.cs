using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using System;
using System.Threading.Tasks;

namespace DynamoDbLambda.Handlers
{
    public class HelloWorldIntentHandler : ICustomSkillRequestHandler
    {

        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            if (handlerInput.RequestEnvelope.Request is IntentRequest intent)
            {
                return Task.FromResult(intent.Intent.Name == "HelloWorldIntent");
            }

            return Task.FromResult(false);
        }

        public async Task<ResponseBody> Handle(IHandlerInput handlerInput)
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
