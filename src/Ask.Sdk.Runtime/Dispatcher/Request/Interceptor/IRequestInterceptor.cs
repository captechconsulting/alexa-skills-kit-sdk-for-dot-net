using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Dispatcher.Request.Interceptor
{
    public interface IRequestInterceptor<TInput>
    {
        Task Process(TInput input);
    }
}
