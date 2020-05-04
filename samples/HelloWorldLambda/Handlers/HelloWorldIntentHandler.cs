using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using System.Threading.Tasks;

namespace HelloWorldLambda.Handlers
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

        public Task<ResponseBody> Handle(IHandlerInput handlerInput)
        {
            var speechText = "Hello World";
            return Task.FromResult(handlerInput.ResponseBuilder
                .Speak(speechText)
                .WithSimpleCard("HelloWorld", speechText)
                .GetResponse());
        }
    }
}
