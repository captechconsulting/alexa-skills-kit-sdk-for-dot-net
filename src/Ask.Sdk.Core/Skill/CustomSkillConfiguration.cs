using Alexa.NET.Response;
using Ask.Sdk.Core.Attributes.Persistence;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Runtime.Skill;

namespace Ask.Sdk.Core.Skill
{
    public class CustomSkillConfiguration : RuntimeConfiguration<IHandlerInput, ResponseBody>
    {
        public CustomSkillConfiguration(RuntimeConfiguration<IHandlerInput, ResponseBody> config)
        {
            RequestMappers = config.RequestMappers;
            HandlerAdapters = config.HandlerAdapters;
            RequestInterceptors = config.RequestInterceptors;
            ErrorMapper = config.ErrorMapper;
            ResponseInterceptors = config.ResponseInterceptors;
        }

        public IPersistenceAdapter PersistenceAdapter { get; set; }
        public string CustomUserAgent { get; set; }
        public string SkillId { get; set; }
    }
}
