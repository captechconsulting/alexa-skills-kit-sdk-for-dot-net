using Alexa.NET.Response;
using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Core.Dispatcher.Request.Handler
{
    public interface ICustomSkillRequestHandler : IRequestHandler<IHandlerInput, ResponseBody>
    {
    }
}
