using Alexa.NET.Request;
using Alexa.NET.Response;
using Ask.Sdk.Core.Attributes;
using Ask.Sdk.Core.Attributes.Persistence;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Core.Model.Service;
using Ask.Sdk.Core.Response;
using Ask.Sdk.Runtime.Dispatcher;
using Ask.Sdk.Runtime.Skill;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ask.Sdk.Core.Skill
{
    public class CustomSkill : ISkill<SkillRequest, SkillResponse>
    {
        protected IRequestDispatcher<IHandlerInput, ResponseBody> _requestDispatcher;
        protected IPersistenceAdapter _persistenceAdapter;
        protected string _customUserAgent;
        protected string _skillId;

        public CustomSkill(CustomSkillConfiguration configuration)
        {
            _persistenceAdapter = configuration.PersistenceAdapter;
            _customUserAgent = configuration.CustomUserAgent;
            _skillId = configuration.SkillId;

            _requestDispatcher = new GenericRequestDispatcher<IHandlerInput, ResponseBody>(configuration);
        }
        public async Task<SkillResponse> Invoke(SkillRequest eventRequest, object context = null)
        {
            if (!string.IsNullOrEmpty(_skillId) && eventRequest.Context.System.Application.ApplicationId != _skillId)
            {
                throw new ArgumentException("Skill ID verification failed!");
            }

            var handlerInput = new DefaultHandlerInput
            {
                RequestEnvelope = eventRequest,
                Context = context,
                AttributesManager = AttributesManagerFactory.Init(eventRequest, _persistenceAdapter),
                ResponseBuilder = ResponseFactory.Init(),
                ServiceClientFactory = new ServiceClientFactory(eventRequest)
            };

            var response = await _requestDispatcher.Dispatch(handlerInput);

            return new SkillResponse
            {
                Version = "1.0",
                //UserAgent = AskSdkUtil.CreateAskSdkUserAgent(Assembly.GetExecutingAssembly().GetName().Version.ToString(), _customUserAgent),
                Response = response,
                SessionAttributes = eventRequest.Session != null ?
                    new Dictionary<string, object>((await handlerInput.AttributesManager.GetSessionAttributes())) :
                    new Dictionary<string, object>()
            };
        }

        public Task<bool> Supports(object eventObject, object context = null)
        {
            return Task.FromResult(eventObject != null);
        }
    }
}
