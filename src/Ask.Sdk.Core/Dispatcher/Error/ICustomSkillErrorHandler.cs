using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Runtime.Dispatcher.Error.Handler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Core.Dispatcher.Error
{
    public interface IErrorHandler : IErrorHandler<IHandlerInput, Model.Response.Response>
    {
    }
}
