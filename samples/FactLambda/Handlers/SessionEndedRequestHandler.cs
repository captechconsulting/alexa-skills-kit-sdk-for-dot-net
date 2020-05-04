using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using System;
using System.Threading.Tasks;

namespace FactLambda.Handlers
{
    public class SessionEndedRequestHandler : ICustomSkillRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput input)
        {
            return Task.FromResult(input.RequestEnvelope.Request is SessionEndedRequest);
        }

        public Task<ResponseBody> Handle(IHandlerInput input)
        {
            var request = input.RequestEnvelope.Request as SessionEndedRequest;
            Console.WriteLine($"Session ended with reason: {request.Reason}");
            return Task.FromResult(input.ResponseBuilder.GetResponse());
        }
    }
}
