using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using FactLambda.Resources;
using System;
using System.Threading.Tasks;

namespace FactLambda.Handlers
{
    public class GetNewFactHandler : ICustomSkillRequestHandler
    {
        private readonly Random _random = new Random();

        public Task<bool> CanHandle(IHandlerInput input)
        {
            return Task.FromResult(input.RequestEnvelope.Request is LaunchRequest ||
                (input.RequestEnvelope.Request is IntentRequest intent && intent.Intent.Name == "GetNewFactIntent"));
        }

        public Task<ResponseBody> Handle(IHandlerInput input)
        {
            var randomFact = GetRandomFact();
            var speakOutput = string.Format("{0}{1}", LanguageStrings.GetFactMessage, randomFact);

            return Task.FromResult(input.ResponseBuilder
                .Speak(speakOutput)
                .WithSimpleCard(LanguageStrings.SkillName, randomFact)
                .GetResponse());
        }

        private string GetRandomFact()
        {
            var facts = LanguageStrings.Facts.Split('|');
            return facts[_random.Next(facts.Length)];
        }
    }
}
