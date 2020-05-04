using System;
using System.Threading.Tasks;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Request.Handler;

namespace Ask.Sdk.Core.Dispatcher.Request.Interceptor
{
    public class FunctionInterceptor : ICustomSkillRequestInterceptor, ICustomSkillResponseInterceptor
    {
        private readonly Func<IHandlerInput, Task> _requestProcess;
        private readonly Func<IHandlerInput, ResponseBody, Task> _responseProcess;

        public FunctionInterceptor(Func<IHandlerInput, Task> requestProcess = null,
            Func<IHandlerInput, ResponseBody, Task> responseProcess = null)
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

        public Task Process(IHandlerInput handlerInput, ResponseBody response = null)
        {
            return _responseProcess(handlerInput, response);
        }
    }
}
