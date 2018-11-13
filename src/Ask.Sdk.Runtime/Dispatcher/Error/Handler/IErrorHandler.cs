using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Dispatcher.Error.Handler
{
    public interface IErrorHandler<TInput, TOutput>
    {
        Task<bool> CanHandle(TInput handlerInput, Exception ex);

        Task<TOutput> Handle(TInput handlerInput, Exception ex);
    }
}
