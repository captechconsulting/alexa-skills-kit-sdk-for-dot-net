using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Dispatcher.Request.Handler
{
    public class GenericHandlerAdapter<TInput, TOutput> : IHandlerAdapter<TInput, TOutput>
    {
        public Task<TOutput> Execute(TInput input, IRequestHandler<TInput, TOutput> handler)
        {
            return handler.Handle(input);
        }
    }
}
