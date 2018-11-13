using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Request.Type;
using Ask.Sdk.Model.Response;
using FactLambda.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactLambda.Handlers
{
    public class GetNewFactHandler : IRequestHandler
    {
        private readonly Random _random = new Random();

        public Task<bool> CanHandle(IHandlerInput input)
        {
            return Task.FromResult(input.RequestEnvelope.Request is LaunchRequest ||
                (input.RequestEnvelope.Request is IntentRequest intent && intent.Intent.Name == "GetNewFactIntent"));
        }

        public Task<Response> Handle(IHandlerInput input)
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
