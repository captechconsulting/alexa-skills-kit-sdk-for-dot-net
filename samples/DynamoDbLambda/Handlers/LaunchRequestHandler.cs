using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using System.Threading.Tasks;

namespace DynamoDbLambda.Handlers
{
    public class LaunchRequestHandler : ICustomSkillRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            return Task.FromResult(handlerInput.RequestEnvelope.Request is LaunchRequest);
        }

        public Task<ResponseBody> Handle(IHandlerInput handlerInput)
        {
            var speechText = "Welcome to the Alexa Skills Kit, you can say hello";
            return Task.FromResult(handlerInput.ResponseBuilder
                .Speak(speechText)
                .WithSimpleCard("HelloWorld", speechText)
                .GetResponse());
        }
    }
}
