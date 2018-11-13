using Ask.Sdk.Runtime.Dispatcher.Error.Handler;
using Ask.Sdk.Runtime.Dispatcher.Error.Mapper;
using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using Ask.Sdk.Runtime.Dispatcher.Request.Interceptor;
using Ask.Sdk.Runtime.Dispatcher.Request.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Skill
{
    public class RuntimeConfigurationBuilder<TInput, TOutput>
    {
        protected readonly IList<GenericRequestHandlerChain<TInput, TOutput>> _requestHandlerChains = new List<GenericRequestHandlerChain<TInput, TOutput>>();
        protected readonly IList<IRequestInterceptor<TInput>> _requestInterceptors = new List<IRequestInterceptor<TInput>>();
        protected readonly IList<IResponseInterceptor<TInput, TOutput>> _responseInterceptors = new List<IResponseInterceptor<TInput, TOutput>>();
        protected readonly IList<IErrorHandler<TInput, TOutput>> _errorHandlers = new List<IErrorHandler<TInput, TOutput>>();

        public RuntimeConfigurationBuilder<TInput, TOutput> AddRequestHandler(Func<TInput, Task<bool>> matcher,
            Func<TInput, Task<TOutput>> executor)
        {
            return AddRequestHandler(new FunctionRequestHandler<TInput, TOutput>(matcher, executor));
        }

        private RuntimeConfigurationBuilder<TInput, TOutput> AddRequestHandler(IRequestHandler<TInput, TOutput> requestHandler)
        {
            _requestHandlerChains.Add(new GenericRequestHandlerChain<TInput, TOutput>(requestHandler));

            return this;
        }

        public RuntimeConfigurationBuilder<TInput, TOutput> AddRequestHandlers(params IRequestHandler<TInput, TOutput>[] requestHandlers)
        {
            foreach(var requestHandler in requestHandlers)
            {
                AddRequestHandler(requestHandler);
            }

            return this;
        }

        public RuntimeConfigurationBuilder<TInput, TOutput> AddRequestInterceptors(params Func<TInput, Task>[] executors)
        {
            foreach(var executor in executors)
            {
                _requestInterceptors.Add(new FunctionInterceptor<TInput, TOutput>(executor));
            }

            return this;
        }

        public RuntimeConfigurationBuilder<TInput, TOutput> AddRequestInterceptors(params IRequestInterceptor<TInput>[] requestInterceptors)
        {
            foreach(var requestInterceptor in requestInterceptors)
            {
                _requestInterceptors.Add(requestInterceptor);
            }

            return this;
        }

        public RuntimeConfigurationBuilder<TInput, TOutput> AddResponseInterceptors(params Func<TInput, TOutput, Task>[] executors)
        {
            foreach (var executor in executors)
            {
                _responseInterceptors.Add(new FunctionInterceptor<TInput, TOutput>(responseProcess: executor));
            }

            return this;
        }

        public RuntimeConfigurationBuilder<TInput, TOutput> AddResponseInterceptors(params IResponseInterceptor<TInput, TOutput>[] responseInterceptors)
        {
            foreach (var responseInterceptor in responseInterceptors)
            {
                _responseInterceptors.Add(responseInterceptor);
            }

            return this;
        }

        public RuntimeConfigurationBuilder<TInput, TOutput> AddErrorHandler(Func<TInput, Exception, Task<bool>> matcher,
            Func<TInput, Exception, Task<TOutput>> executor)
        {
            return AddErrorHandler(new FunctionErrorHandler<TInput, TOutput>(matcher, executor));
        }

        private RuntimeConfigurationBuilder<TInput, TOutput> AddErrorHandler(IErrorHandler<TInput, TOutput> errorHandler)
        {
            _errorHandlers.Add(errorHandler);

            return this;
        }

        public RuntimeConfigurationBuilder<TInput, TOutput> AddErrorHandlers(params IErrorHandler<TInput, TOutput>[] errorHandlers)
        {
            foreach(var errorHandler in errorHandlers)
            {
                _errorHandlers.Add(errorHandler);
            }

            return this;
        }

        public RuntimeConfiguration<TInput, TOutput> GetRuntimeConfiguration()
        {
            var requestMapper = new GenericRequestMapper<TInput, TOutput>(_requestHandlerChains);

            var errorMapper = _errorHandlers.Count > 0 ? new GenericErrorMapper<TInput, TOutput>(_errorHandlers) :
                null;

            return new RuntimeConfiguration<TInput, TOutput>
            {
                RequestMappers = new[] { requestMapper },
                HandlerAdapters = new[] { new GenericHandlerAdapter<TInput, TOutput>() },
                ErrorMapper = errorMapper,
                RequestInterceptors = _requestInterceptors,
                ResponseInterceptors = _responseInterceptors
            };
        }
    }
}
