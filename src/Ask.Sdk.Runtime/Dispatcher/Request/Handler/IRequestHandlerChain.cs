using Ask.Sdk.Runtime.Dispatcher.Request.Interceptor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Runtime.Dispatcher.Request.Handler
{
    public interface IRequestHandlerChain<TInput, TOutput>
    {
        IRequestHandler<TInput, TOutput> GetRequestHandler();

        IEnumerable<IRequestInterceptor<TInput>> GetRequestInterceptors();

        IEnumerable<IResponseInterceptor<TInput, TOutput>> GetResponseInterceptors();
    }
}
