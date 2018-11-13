using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Model.Response;

namespace Ask.Sdk.Core.Dispatcher.Request.Interceptor
{
    public class FunctionInterceptor : IRequestInterceptor, IResponseInterceptor
    {
        private readonly Func<IHandlerInput, Task> _requestProcess;
        private readonly Func<IHandlerInput, Model.Response.Response, Task> _responseProcess;

        public FunctionInterceptor(Func<IHandlerInput, Task> requestProcess = null, 
            Func<IHandlerInput, Model.Response.Response, Task> responseProcess = null)
        {
            if (requestProcess != null)
                _requestProcess = requestProcess;

            if (responseProcess != null)
                _responseProcess = responseProcess;
        }

        public Task Process(IHandlerInput handlerInput)
        {
            return _requestProcess(handlerInput);
        }

        public Task Process(IHandlerInput handlerInput, Model.Response.Response response = null)
        {
            return _responseProcess(handlerInput, response);
        }
    }
}
