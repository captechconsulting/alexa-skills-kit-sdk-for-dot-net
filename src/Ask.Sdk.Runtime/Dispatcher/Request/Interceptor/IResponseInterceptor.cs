using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Dispatcher.Request.Interceptor
{
    public interface IResponseInterceptor<TInput, TOutput>
    {
        Task Process(TInput input, TOutput output = default(TOutput));
    }
}
