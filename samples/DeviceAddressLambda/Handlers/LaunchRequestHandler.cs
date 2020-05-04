using Ask.Sdk.Core.Dispatcher.Request.Handler;
using System.Threading.Tasks;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;

namespace DeviceAddressLambda.Handlers
{
    public class LaunchRequestHandler : ICustomSkillRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            return Task.FromResult(handlerInput.RequestEnvelope.Request is LaunchRequest);
        }

        public Task<ResponseBody> Handle(IHandlerInput handlerInput)
        {
            return Task.FromResult(handlerInput.ResponseBuilder
                .Speak(Messages.WELCOME)
                .WithSimpleCard("Device Address API", Messages.WELCOME)
                .GetResponse());
        }
    }
}
