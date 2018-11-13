using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSettingsLambda.Handlers
{
    public class DistanceUnitsHandler : IRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput input)
        {
            if (input.RequestEnvelope.Request is IntentRequest intent)
            {
                return Task.FromResult(intent.Intent.Name == "DistanceUnitsIntent");
            }

            return Task.FromResult(false);
        }

        public async Task<Response> Handle(IHandlerInput input)
        {
            try
            {
                var client = input.ServiceClientFactory.GetUpsServiceClient();

                var distanceUnits = await client.GetSystemDistanceUnits(input.RequestEnvelope?.Context?.System?.Device?.DeviceID);

                return input.ResponseBuilder
                    .Speak($"Your distance unites are {distanceUnits}")
                    .GetResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message} {ex.StackTrace}");
                return input.ResponseBuilder
                    .Speak("That didn't go as planned")
                    .GetResponse();
            }
        }
    }
}
