using System.Collections.Generic;
using Ask.Sdk.Core.Attributes.Persistence;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Core.Dispatcher.Request.Interceptor;
using Ask.Sdk.Model.Response;
using Ask.Sdk.Model.Service;
using Ask.Sdk.Runtime.Dispatcher.Error.Mapper;
using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using Ask.Sdk.Runtime.Dispatcher.Request.Interceptor;
using Ask.Sdk.Runtime.Dispatcher.Request.Mapper;
using Ask.Sdk.Runtime.Skill;

namespace Ask.Sdk.Core.Skill
{
    public class SkillConfiguration : RuntimeConfiguration<IHandlerInput, Model.Response.Response>
    {
        public SkillConfiguration(RuntimeConfiguration<IHandlerInput, Model.Response.Response> config)
        {
            RequestMappers = config.RequestMappers;
            HandlerAdapters = config.HandlerAdapters;
            RequestInterceptors = config.RequestInterceptors;
            ErrorMapper = config.ErrorMapper;
            ResponseInterceptors = config.ResponseInterceptors;
        }

        public IPersistenceAdapter PersistenceAdapter { get; set; }
        public IApiClient ApiClient { get; set; }
        public string CustomUserAgent { get; set; }
        public string SkillId { get; set; }
    }
}
