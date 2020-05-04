using System;
using System.Threading.Tasks;
using Alexa.NET.Response;

namespace Ask.Sdk.Core.Dispatcher.Request.Handler
{
    public class FunctionRequestHandler : ICustomSkillRequestHandler
    {
        private readonly Func<IHandlerInput, Task<bool>> _canHandle;
        private readonly Func<IHandlerInput, Task<ResponseBody>> _handle;

        public FunctionRequestHandler(Func<IHandlerInput, Task<bool>> canHandle,
            Func<IHandlerInput, Task<ResponseBody>> handle)
        {
            _canHandle = canHandle;
            _handle = handle;
        }

        public Task<bool> CanHandle(IHandlerInput handlerInput)
        {
            return _canHandle(handlerInput);
        }

        public Task<ResponseBody> Handle(IHandlerInput handlerInput)
        {
            return _handle(handlerInput);
        }
    }
}
