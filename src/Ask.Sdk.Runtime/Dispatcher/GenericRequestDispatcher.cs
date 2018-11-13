using Ask.Sdk.Runtime.Dispatcher.Error.Mapper;
using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using Ask.Sdk.Runtime.Dispatcher.Request.Interceptor;
using Ask.Sdk.Runtime.Dispatcher.Request.Mapper;
using Ask.Sdk.Runtime.Skill;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Dispatcher
{
    public class GenericRequestDispatcher<TInput, TOutput> : IRequestDispatcher<TInput, TOutput>
    {
        protected IEnumerable<IRequestMapper<TInput, TOutput>> _requestMappers;
        protected IErrorMapper<TInput, TOutput> _errorMapper;
        protected IEnumerable<IHandlerAdapter<TInput, TOutput>> _handlerAdapters;
        protected IEnumerable<IRequestInterceptor<TInput>> _requestInterceptors;
        protected IEnumerable<IResponseInterceptor<TInput, TOutput>> _responseInterceptors;

        public GenericRequestDispatcher(RuntimeConfiguration<TInput, TOutput> configuration)
        {
            _requestMappers = configuration.RequestMappers;
            _handlerAdapters = configuration.HandlerAdapters;
            _errorMapper = configuration.ErrorMapper;
            _requestInterceptors = configuration.RequestInterceptors;
            _responseInterceptors = configuration.ResponseInterceptors;
        }

        public async Task<TOutput> Dispatch(TInput input)
        {
            TOutput output;

            try
            {
                if (_requestInterceptors != null)
                {
                    foreach(var interceptor in _requestInterceptors)
                    {
                        await interceptor.Process(input);
                    }
                }

                output = await DispatchRequest(input);

                if (_responseInterceptors != null)
                {
                    foreach(var interceptor in _responseInterceptors)
                    {
                        await interceptor.Process(input, output);
                    }
                }
            }
            catch(Exception ex)
            {
                output = await DispatchError(input, ex);
            }

            return output;
        }

        protected async Task<TOutput> DispatchError(TInput input, Exception ex)
        {
            if (_errorMapper != null)
            {
                var handler = await _errorMapper.GetErrorHandler(input, ex);
                if (handler != null)
                {
                    return await handler.Handle(input, ex);
                }
            }

            throw ex;
        }

        protected async Task<TOutput> DispatchRequest(TInput input)
        {
            IRequestHandlerChain<TInput, TOutput> handlerChain = null;
            foreach(var requestMapper in _requestMappers)
            {
                handlerChain = await requestMapper.GetRequestHandlerChain(input);

                if (handlerChain != null)
                    break;
            }
            if (handlerChain == null)
            {
                throw new NotImplementedException("Unable to find a suitable request handler.");
            }

            var handler = handlerChain.GetRequestHandler();
            var requestInterceptors = handlerChain.GetRequestInterceptors();
            var responseInterceptors = handlerChain.GetResponseInterceptors();

            IHandlerAdapter<TInput, TOutput> adapter = null;

            foreach(var handlerAdapter in _handlerAdapters)
            {
                adapter = handlerAdapter;
                break;
            }

            if (adapter == null)
            {
                throw new NotImplementedException("Unable to find a suitable handler adapter.");
            }

            if (requestInterceptors != null)
            {
                foreach (var interceptor in requestInterceptors)
                {
                    await interceptor.Process(input);
                }
            }

            var output = await adapter.Execute(input, handler);

            if (responseInterceptors != null)
            {
                foreach (var interceptor in responseInterceptors)
                {
                    await interceptor.Process(input, output);
                }
            }

            return output;
        }
    }
}
