using System;
using System.Collections.Generic;
using System.Text;
using Ask.Sdk.Core.Attributes;
using Ask.Sdk.Core.Response;
using Ask.Sdk.Model.Request;
using Ask.Sdk.Model.Service;

namespace Ask.Sdk.Core.Dispatcher.Request.Handler
{
    public class DefaultHandlerInput : IHandlerInput
    {
        public RequestEnvelope RequestEnvelope { get; set; }
        public object Context { get; set; }
        public IAttributesManager AttributesManager { get; set; }
        public IResponseBuilder ResponseBuilder { get; set; }

        public ServiceClientFactory ServiceClientFactory { get; set; }
    }
}
