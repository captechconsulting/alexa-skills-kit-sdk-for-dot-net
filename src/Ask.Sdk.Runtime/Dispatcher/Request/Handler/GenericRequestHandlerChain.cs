using System;
using System.Collections.Generic;
using System.Text;
using Ask.Sdk.Runtime.Dispatcher.Request.Interceptor;

namespace Ask.Sdk.Runtime.Dispatcher.Request.Handler
{
    public class GenericRequestHandlerChain<TInput, TOutput> : IRequestHandlerChain<TInput, TOutput>
    {
        protected IRequestHandler<TInput, TOutput> _requestHandler;
        protected IEnumerable<IRequestInterceptor<TInput>> _requestInterceptors;
        protected IEnumerable<IResponseInterceptor<TInput, TOutput>> _responseInterceptors;

        public GenericRequestHandlerChain(IRequestHandler<TInput, TOutput> requestHandler,
            IEnumerable<IRequestInterceptor<TInput>> requestInterceptors = null,
            IEnumerable<IResponseInterceptor<TInput, TOutput>> responseInterceptors = null)
        {
            _requestHandler = requestHandler;
            _requestInterceptors = requestInterceptors;
            _responseInterceptors = responseInterceptors;
        }

        public IRequestHandler<TInput, TOutput> GetRequestHandler()
        {
            return _requestHandler;
        }

        public IEnumerable<IRequestInterceptor<TInput>> GetRequestInterceptors()
        {
            return _requestInterceptors;
        }

        public IEnumerable<IResponseInterceptor<TInput, TOutput>> GetResponseInterceptors()
        {
            return _responseInterceptors;
        }
    }
}
