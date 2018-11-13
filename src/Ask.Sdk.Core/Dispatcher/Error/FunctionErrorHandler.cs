using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Response;

namespace Ask.Sdk.Core.Dispatcher.Error
{
    public class FunctionErrorHandler : IErrorHandler
    {
        private readonly Func<IHandlerInput, Exception, Task<bool>> _canHandle;
        private readonly Func<IHandlerInput, Exception, Task<Model.Response.Response>> _handle;

        public FunctionErrorHandler(Func<IHandlerInput, Exception, Task<bool>> canHandle,
            Func<IHandlerInput, Exception, Task<Model.Response.Response>> handle)
        {
            _canHandle = canHandle;
            _handle = handle;
        }

        public Task<bool> CanHandle(IHandlerInput handlerInput, Exception ex)
        {
            return _canHandle(handlerInput, ex);
        }

        public Task<Model.Response.Response> Handle(IHandlerInput handlerInput, Exception ex)
        {
            return _handle(handlerInput, ex);
        }
    }
}
