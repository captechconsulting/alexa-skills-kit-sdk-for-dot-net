using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using System.Threading.Tasks;

namespace DynamoDbLambda.Handlers
{
    class DynamoDbIntentHandler : ICustomSkillRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            if (handlerInput.RequestEnvelope.Request is IntentRequest intent)
            {
                return Task.FromResult(intent.Intent.Name == "DynamoDbIntent");
            }

            return Task.FromResult(false);
        }

        public async Task<ResponseBody> Handle(IHandlerInput handlerInput)
        {
            var attributes = await handlerInput.AttributesManager.GetPersistentAttributes();
            var speechText = $"The last time you used this skill was {attributes["TimeCalled"]}";
            return handlerInput.ResponseBuilder
                .Speak(speechText)
                .WithSimpleCard("HelloWorld", speechText)
                .GetResponse();
        }
    }
}
