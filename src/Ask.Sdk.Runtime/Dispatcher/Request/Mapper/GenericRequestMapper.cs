using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ask.Sdk.Runtime.Dispatcher.Request.Handler;

namespace Ask.Sdk.Runtime.Dispatcher.Request.Mapper
{
    public class GenericRequestMapper<TInput, TOutput> : IRequestMapper<TInput, TOutput>
    {
        protected IEnumerable<GenericRequestHandlerChain<TInput, TOutput>> _requestHandlerChains;

        public GenericRequestMapper(IEnumerable<GenericRequestHandlerChain<TInput, TOutput>> requestHandlerChains)
        {
            _requestHandlerChains = requestHandlerChains;
        }

        public async Task<IRequestHandlerChain<TInput, TOutput>> GetRequestHandlerChain(TInput input)
        {
            foreach (var requestHandlerChain in _requestHandlerChains)
            {
                var requestHandler = requestHandlerChain.GetRequestHandler();
                if (await requestHandler.CanHandle(input))
                {
                    return requestHandlerChain;
                }
            }

            return null;
        }
    }
}
