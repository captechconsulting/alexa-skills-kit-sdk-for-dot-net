using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using System.Threading.Tasks;

namespace ProgressiveResponseLambda.Handlers
{
    public class FallbackHandler : IRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput input)
        {
            if (input.RequestEnvelope.Request is IntentRequest intent)
            {
                return Task.FromResult(intent.Intent.Name == BuiltInIntent.Fallback);
            }

            return Task.FromResult(false);
        }

        public Task<Response> Handle(IHandlerInput input)
        {
            return Task.FromResult(input.ResponseBuilder
                .Speak("I didn't understand that")
                .GetResponse());
        }
    }
}
