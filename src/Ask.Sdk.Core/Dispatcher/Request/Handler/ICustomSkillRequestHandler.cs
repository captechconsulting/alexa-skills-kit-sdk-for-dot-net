using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Core.Dispatcher.Request.Handler
{
    public interface IRequestHandler : IRequestHandler<IHandlerInput, Model.Response.Response>
    {
    }
}
