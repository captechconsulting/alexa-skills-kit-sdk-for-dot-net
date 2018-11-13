using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Dispatcher.Request.Mapper
{
    public interface IRequestMapper<TInput, TOutput>
    {
        Task<IRequestHandlerChain<TInput, TOutput>> GetRequestHandlerChain(TInput input);
    }
}
