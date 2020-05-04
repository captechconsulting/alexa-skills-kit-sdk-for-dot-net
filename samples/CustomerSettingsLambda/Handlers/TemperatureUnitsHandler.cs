using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using System;
using System.Threading.Tasks;

namespace CustomerSettingsLambda.Handlers
{
    public class TemperatureUnitsHandler : ICustomSkillRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput input)
        {
            if (input.RequestEnvelope.Request is IntentRequest intent)
            {
                return Task.FromResult(intent.Intent.Name == "TemperatureUnitsIntent");
            }

            return Task.FromResult(false);
        }

        public async Task<ResponseBody> Handle(IHandlerInput input)
        {
            try
            {
                var client = input.ServiceClientFactory.GetUpsServiceClient();

                var temperatureUnits = await client.TemperatureUnit();

                return input.ResponseBuilder
                    .Speak($"Your temperature units are {temperatureUnits}")
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
