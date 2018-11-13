using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ask.Sdk.Model.Response;

namespace Ask.Sdk.Core.Dispatcher.Request.Handler
{
    public class FunctionRequestHandler : IRequestHandler
    {
        private readonly Func<IHandlerInput, Task<bool>> _canHandle;
        private readonly Func<IHandlerInput, Task<Model.Response.Response>> _handle;

        public FunctionRequestHandler(Func<IHandlerInput, Task<bool>> canHandle,
            Func<IHandlerInput, Task<Model.Response.Response>> handle)
        {
            _canHandle = canHandle;
            _handle = handle;
        }

        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            return _canHandle(handlerInput);
        }

        public Task<Model.Response.Response> Handle(IHandlerInput handlerInput)
        {
            return _handle(handlerInput);
        }
    }
}
