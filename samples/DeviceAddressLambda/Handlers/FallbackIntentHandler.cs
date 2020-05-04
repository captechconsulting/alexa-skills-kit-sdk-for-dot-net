using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using System.Threading.Tasks;

namespace DeviceAddressLambda.Handlers
{
    public class FallbackIntentHandler : ICustomSkillRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            if (handlerInput.RequestEnvelope.Request is IntentRequest intent)
            {
                return Task.FromResult(intent.Intent.Name == BuiltInIntent.Fallback);
            }

            return Task.FromResult(false);
        }

        public Task<ResponseBody> Handle(IHandlerInput handlerInput)
        {
            return Task.FromResult(handlerInput.ResponseBuilder
                .Speak(Messages.HELP)
                .GetResponse());
        }
    }
}
