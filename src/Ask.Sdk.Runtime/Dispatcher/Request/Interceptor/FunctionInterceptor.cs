using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Dispatcher.Request.Interceptor
{
    public class FunctionInterceptor<TInput, TOutput> : IRequestInterceptor<TInput>, IResponseInterceptor<TInput, TOutput>
    {
        private readonly Func<TInput, Task> _requestProcess;
        private readonly Func<TInput, TOutput, Task> _responseProcess;

        public FunctionInterceptor(Func<TInput, Task> requestProcess = null,
            Func<TInput, TOutput, Task> responseProcess = null)
        {
            _requestProcess = requestProcess;
            _responseProcess = responseProcess;
        }

        public Task Process(TInput input, TOutput output = default(TOutput))
        {
            return _responseProcess(input, output);
        }

        public Task Process(TInput input)
        {
            return _requestProcess(input);
        }
    }
}
