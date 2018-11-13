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
    public class ExitHandler : IRequestHandler
    {
        public Task<bool> CanHandle(IHandlerInput input)
        {
            if (input.RequestEnvelope.Request is IntentRequest intent)
            {
                return Task.FromResult(intent.Intent.Name == BuiltInIntent.Cancel ||
                    intent.Intent.Name == BuiltInIntent.Stop);
            }

            return Task.FromResult(false);
        }

        public Task<Response> Handle(IHandlerInput input)
        {
            return Task.FromResult(input.ResponseBuilder
                .Speak(LanguageStrings.StopMessage)
                .GetResponse());
        }
    }
}
