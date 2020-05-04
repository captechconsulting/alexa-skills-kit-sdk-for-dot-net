using Ask.Sdk.Core.Attributes;
using Ask.Sdk.Core.Response;
using Alexa.NET.Request;
using Ask.Sdk.Core.Model.Service;

namespace Ask.Sdk.Core.Dispatcher.Request.Handler
{
    public interface IHandlerInput
    {
        SkillRequest RequestEnvelope { get; set; }

        object Context { get; set; }

        IAttributesManager AttributesManager { get; set; }

        IResponseBuilder ResponseBuilder { get; set; }

        ServiceClientFactory ServiceClientFactory { get; set; }
    }
}

