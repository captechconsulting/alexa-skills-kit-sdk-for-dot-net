using System;
using System.Threading.Tasks;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Request.Handler;

namespace Ask.Sdk.Core.Dispatcher.Error
{
    public class FunctionErrorHandler : ICustomSkillErrorHandler
    {
        private readonly Func<IHandlerInput, Exception, Task<bool>> _canHandle;
        private readonly Func<IHandlerInput, Exception, Task<ResponseBody>> _handle;

        public FunctionErrorHandler(Func<IHandlerInput, Exception, Task<bool>> canHandle,
            Func<IHandlerInput, Exception, Task<ResponseBody>> handle)
        {
            _canHandle = canHandle;
            _handle = handle;
        }

        public Task<bool> CanHandle(IHandlerInput handlerInput, Exception ex)
        {
            return _canHandle(handlerInput, ex);
        }

        public Task<ResponseBody> Handle(IHandlerInput handlerInput, Exception ex)
        {
            return _handle(handlerInput, ex);
        }
    }
}
