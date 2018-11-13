using Ask.Sdk.Core.Attributes;
using Ask.Sdk.Core.Response;
using Ask.Sdk.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using Ask.Sdk.Model.Service;

namespace Ask.Sdk.Core.Dispatcher.Request.Handler
{
    public interface IHandlerInput
    {
        RequestEnvelope RequestEnvelope { get; set; }

        object Context { get; set; }

        IAttributesManager AttributesManager { get; set; }

        IResponseBuilder ResponseBuilder { get; set; }

        ServiceClientFactory ServiceClientFactory { get; set; }
    }
}

