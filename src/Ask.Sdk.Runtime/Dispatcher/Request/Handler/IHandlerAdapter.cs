using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Dispatcher.Request.Handler
{
    public interface IHandlerAdapter<TInput, TOutput>
    {
        Task<TOutput> Execute(TInput input, IRequestHandler<TInput, TOutput> handler);
    }
}
