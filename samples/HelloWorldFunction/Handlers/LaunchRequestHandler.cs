using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using System.Threading.Tasks;

namespace HelloWorldFunction.Handlers
{
    public class LaunchRequestHandler : ICustomSkillRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput input)
        {
            return Task.FromResult(input.RequestEnvelope.Request is LaunchRequest);
        }

        public Task<ResponseBody> Handle(IHandlerInput input)
        {
            var speechText = "Welcome to the Alexa Skills Kit, you can say hello";
            return Task.FromResult(input.ResponseBuilder
                .Speak(speechText)
                .WithSimpleCard("HelloWorld", speechText)
                .GetResponse());

        }
    }
}
