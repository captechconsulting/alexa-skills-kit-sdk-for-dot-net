using Ask.Sdk.Core.Dispatcher.Error;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveResponseLambda.Handlers
{
    public class ErrorHandler : IErrorHandler
    {
        public Task<bool> CanHandle(IHandlerInput handlerInput, Exception ex)
        {
            return Task.FromResult(true);
        }

        public Task<Response> Handle(IHandlerInput handlerInput, Exception ex)
        {
            Console.WriteLine($"Error handled: {ex.Message}");
            Console.WriteLine($"Error stack: {ex.StackTrace}");
            return Task.FromResult(handlerInput.ResponseBuilder
                .Speak("Something unexpected happened.")
                .GetResponse());

        }
    }
}
