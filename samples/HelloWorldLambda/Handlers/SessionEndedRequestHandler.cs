using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using System.Threading.Tasks;

namespace HelloWorldLambda.Handlers
{
    public class SessionEndedRequestHandler : ICustomSkillRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            return Task.FromResult(handlerInput.RequestEnvelope.Request is SessionEndedRequest);
        }

        public Task<ResponseBody> Handle(IHandlerInput handlerInput)
        {
            return Task.FromResult(handlerInput.ResponseBuilder.GetResponse());
        }
    }
}
