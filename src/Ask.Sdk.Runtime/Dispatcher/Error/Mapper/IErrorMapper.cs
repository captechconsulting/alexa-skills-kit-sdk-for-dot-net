using Ask.Sdk.Runtime.Dispatcher.Error.Handler;
using System;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Dispatcher.Error.Mapper
{
    public interface IErrorMapper<TInput, TOutput>
    {
        Task<IErrorHandler<TInput, TOutput>> GetErrorHandler(TInput input, Exception ex);
    }
}
