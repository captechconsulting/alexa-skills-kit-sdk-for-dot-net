using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Error;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeviceAddressLambda.Handlers
{
    public class ServiceErrorHandler : ICustomSkillErrorHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput, Exception exception)
        {
            return Task.FromResult(exception is HttpRequestException);
        }

        public Task<ResponseBody> Handle(IHandlerInput handlerInput, Exception exception)
        {
            var serviceException = (HttpRequestException) exception;

            // TODO: Alexa.NET.Settings does not currently provide enough information to handle this. Hopefully will be
            // added in the future.
            //if (serviceException.StatusCode == 403) {
            //    return Task.FromResult(handlerInput.ResponseBuilder
            //        .Speak(Messages.MISSING_PERMISSIONS)
            //        .WithAskForPermissionsConsentCard(new List<string>(Messages.PERMISSIONS))
            //        .GetResponse());
            //}

            return Task.FromResult(handlerInput.ResponseBuilder
                .Speak(Messages.LOCATION_FAILURE)
                .GetResponse());
        }
    }
}
