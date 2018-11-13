using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Dispatcher.Request.Handler
{
    public interface IRequestHandler<TInput, TOutput>
    {
        Task<bool> CanHandle(TInput input);

        Task<TOutput> Handle(TInput input);
    }
}
