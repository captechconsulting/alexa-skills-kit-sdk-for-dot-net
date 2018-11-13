using Ask.Sdk.Core.Dispatcher.Error;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using Ask.Sdk.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceAddressLambda.Handlers
{
    public class ServiceErrorHandler : IErrorHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput, Exception exception)
        {
            return Task.FromResult(exception is ServiceException);
        }

        public Task<Response> Handle(IHandlerInput handlerInput, Exception exception)
        {
            var serviceException = (ServiceException) exception;

            if (serviceException.StatusCode == 403) {
                return Task.FromResult(handlerInput.ResponseBuilder
                    .Speak(Messages.MISSING_PERMISSIONS)
                    .WithAskForPermissionsConsentCard(new List<string>(Messages.PERMISSIONS))
                    .GetResponse());
            }

            return Task.FromResult(handlerInput.ResponseBuilder
                .Speak(Messages.LOCATION_FAILURE)
                .GetResponse());
        }
    }
}
