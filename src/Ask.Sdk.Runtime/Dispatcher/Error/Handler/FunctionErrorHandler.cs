using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Dispatcher.Error.Handler
{
    public class FunctionErrorHandler<TInput, TOutput> : IErrorHandler<TInput, TOutput>
    {
        private readonly Func<TInput, Exception, Task<bool>> _canHandle;
        private readonly Func<TInput, Exception, Task<TOutput>> _handle;

        public FunctionErrorHandler(Func<TInput, Exception, Task<bool>> canHandle,
            Func<TInput, Exception, Task<TOutput>> handle)
        {
            _canHandle = canHandle;
            _handle = handle;
        }
        public Task<bool> CanHandle(TInput handlerInput, Exception ex)
        {
            return _canHandle(handlerInput, ex);
        }

        public Task<TOutput> Handle(TInput handlerInput, Exception ex)
        {
            return _handle(handlerInput, ex);
        }
    }
}
