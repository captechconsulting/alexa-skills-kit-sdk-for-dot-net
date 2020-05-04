using Ask.Sdk.Core.Dispatcher.Request.Handler;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using System.Net.Http;

namespace DeviceAddressLambda.Handlers
{
    public class DeviceAddressIntentHandler : ICustomSkillRequestHandler
    {
        ILambdaContext Context;
        public DeviceAddressIntentHandler(ILambdaContext context)
        {
            Context = context;
        }
        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            if (handlerInput.RequestEnvelope.Request is IntentRequest intent)
            {
                return Task.FromResult(intent.Intent.Name == Intents.DEVICE_ADDRESS);
            }

            return Task.FromResult(false);
        }

        public async Task<ResponseBody> Handle(IHandlerInput handlerInput)
        {
            // Console.WriteLine() can be used to log to CloudWatch though they may take a while to propogate
            // Using the instantiated Context.Logger passed into the constructor will immediately write logs to CloudWatch
            Context.Logger.Log("In Device Address Intent Handler!");
            var responseBuilder = handlerInput.ResponseBuilder;
            string consentToken = null;
            if (!string.IsNullOrEmpty(handlerInput?.RequestEnvelope?.Context?.System?.ApiAccessToken))
            {
                consentToken = handlerInput.RequestEnvelope.Context.System.ApiAccessToken;
            }

            if (consentToken == null)
            {
                return responseBuilder.Speak(Messages.MISSING_PERMISSIONS)
                    .WithAskForPermissionsConsentCard(new List<string>(Messages.PERMISSIONS))
                    .GetResponse();
            }

            try
            {
                var deviceAddressClient = handlerInput.ServiceClientFactory.GetDeviceAddressServiceClient();
                var address = await deviceAddressClient.FullAddress();
                var speechText = $"Here is your full address: {address.AddressLine1}, {address.StateOrRegion}, {address.PostalCode}";
                return handlerInput.ResponseBuilder
                    .Speak(speechText)
                    .GetResponse();
            }
            catch (Exception ex)
            {
                // HttpRequestException is thrown by the Device Address Service Client, we throw it here to send it to the ServiceErrorHandler
                if (ex is HttpRequestException) throw ex;
                // If the exception is not a ServiceException than we send a generic error message
                return responseBuilder.Speak(Messages.ERROR).GetResponse();
            }
        }
    }
}
