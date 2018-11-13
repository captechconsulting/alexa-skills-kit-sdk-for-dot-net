using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ask.Sdk.Runtime.Dispatcher.Error.Handler;

namespace Ask.Sdk.Runtime.Dispatcher.Error.Mapper
{
    public class GenericErrorMapper<TInput, TOutput> : IErrorMapper<TInput, TOutput>
    {
        protected IEnumerable<IErrorHandler<TInput, TOutput>> _errorHandlers;

        public GenericErrorMapper(IEnumerable<IErrorHandler<TInput, TOutput>> errorHandlers)
        {
            _errorHandlers = errorHandlers;
        }

        public async Task<IErrorHandler<TInput, TOutput>> GetErrorHandler(TInput input, Exception ex)
        {
            foreach (var errorHandler in _errorHandlers)
            {
                if (await errorHandler.CanHandle(input, ex))
                {
                    return errorHandler;
                }
            }

            return null;
        }
    }
}
