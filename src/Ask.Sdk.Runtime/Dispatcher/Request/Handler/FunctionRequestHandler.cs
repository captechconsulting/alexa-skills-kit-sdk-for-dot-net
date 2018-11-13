using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Dispatcher.Request.Handler
{
    public class FunctionRequestHandler<TInput, TOutput> : IRequestHandler<TInput, TOutput>
    {
        private readonly Func<TInput, Task<bool>> _canHandle;
        private readonly Func<TInput, Task<TOutput>> _handle;

        public FunctionRequestHandler(Func<TInput, Task<bool>> canHandle,
            Func<TInput, Task<TOutput>> handle)
        {
            _canHandle = canHandle;
            _handle = handle;
        }

        public Task<bool> CanHandle(TInput input)
        {
            return _canHandle(input);
        }

        public Task<TOutput> Handle(TInput input)
        {
            return _handle(input);
        }
    }
}
