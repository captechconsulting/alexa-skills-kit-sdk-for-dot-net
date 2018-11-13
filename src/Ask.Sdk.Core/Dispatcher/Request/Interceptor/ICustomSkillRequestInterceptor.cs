using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Runtime.Dispatcher.Request.Interceptor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Core.Dispatcher.Request.Interceptor
{
    public interface IRequestInterceptor : IRequestInterceptor<IHandlerInput>
    {
    }
}
