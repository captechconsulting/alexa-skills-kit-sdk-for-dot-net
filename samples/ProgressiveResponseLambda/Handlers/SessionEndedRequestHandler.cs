using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveResponseLambda.Handlers
{
    public class SessionEndedRequestHandler : IRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput input)
        {
            return Task.FromResult(input.RequestEnvelope.Request is SessionEndedRequest);
        }

        public Task<Response> Handle(IHandlerInput input)
        {
            var request = input.RequestEnvelope.Request as SessionEndedRequest;
            Console.WriteLine($"Session ended with reason: {request.Reason}");
            return Task.FromResult(input.ResponseBuilder.GetResponse());
        }
    }
}
