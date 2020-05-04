using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Error;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using FactLambda.Resources;
using System;
using System.Threading.Tasks;

namespace FactLambda.Handlers
{
    public class ErrorHandler : ICustomSkillErrorHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput, Exception ex)
        {
            return Task.FromResult(true);
        }

        public Task<ResponseBody> Handle(IHandlerInput handlerInput, Exception ex)
        {
            Console.WriteLine($"Error handled: {ex.Message}");
            Console.WriteLine($"Error stack: {ex.StackTrace}");
            return Task.FromResult(handlerInput.ResponseBuilder
                .Speak(LanguageStrings.ErrorMessage)
                .Reprompt(LanguageStrings.ErrorMessage)
                .GetResponse());

        }
    }
}
