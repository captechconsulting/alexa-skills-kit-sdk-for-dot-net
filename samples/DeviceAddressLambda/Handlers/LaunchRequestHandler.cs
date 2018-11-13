using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace DeviceAddressLambda.Handlers
{
    public class LaunchRequestHandler : IRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            return Task.FromResult(handlerInput.RequestEnvelope.Request is LaunchRequest);
        }

        public Task<Response> Handle(IHandlerInput handlerInput)
        {
            return Task.FromResult(handlerInput.ResponseBuilder
                .Speak(Messages.WELCOME)
                .WithSimpleCard("Device Address API", Messages.WELCOME)
                .GetResponse());
        }
    }
}
