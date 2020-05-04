using Alexa.NET.Request;
using Ask.Sdk.Core.Attributes;
using Ask.Sdk.Core.Model.Service;
using Ask.Sdk.Core.Response;

namespace Ask.Sdk.Core.Dispatcher.Request.Handler
{
    public class DefaultHandlerInput : IHandlerInput
    {
        public SkillRequest RequestEnvelope { get; set; }
        public object Context { get; set; }
        public IAttributesManager AttributesManager { get; set; }
        public IResponseBuilder ResponseBuilder { get; set; }

        public ServiceClientFactory ServiceClientFactory { get; set; }
    }
}
