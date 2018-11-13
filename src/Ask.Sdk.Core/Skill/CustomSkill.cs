using Ask.Sdk.Core.Attributes;
using Ask.Sdk.Core.Attributes.Persistence;
using Ask.Sdk.Core.Dispatcher;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Core.Response;
using Ask.Sdk.Model.Request;
using Ask.Sdk.Model.Response;
using Ask.Sdk.Model.Service;
using Ask.Sdk.Runtime.Dispatcher;
using Ask.Sdk.Runtime.Skill;
using Ask.Sdk.Runtime.Util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Core.Skill
{
    public class CustomSkill : ISkill<RequestEnvelope, ResponseEnvelope>
    {
        protected IRequestDispatcher<IHandlerInput, Model.Response.Response> _requestDispatcher;
        protected IPersistenceAdapter _persistenceAdapter;
        protected IApiClient _apiClient;
        protected string _customUserAgent;
        protected string _skillId;

        public CustomSkill(SkillConfiguration configuration)
        {
            _persistenceAdapter = configuration.PersistenceAdapter;
            _apiClient = configuration.ApiClient;
            _customUserAgent = configuration.CustomUserAgent;
            _skillId = configuration.SkillId;

            _requestDispatcher = new GenericRequestDispatcher<IHandlerInput, Model.Response.Response>(configuration);
        }

        public async Task<ResponseEnvelope> Invoke(RequestEnvelope requestEnvelope, object context = null)
        {
            if (!string.IsNullOrEmpty(_skillId) && requestEnvelope.Context.System.Application.ApplicationId != _skillId)
            {
                throw new ArgumentException("Skill ID verification failed!");
            }

            ApiConfiguration apiConfiguration = new ApiConfiguration() {ApiClient = _apiClient, ApiEndpoint = requestEnvelope.Context.System.ApiEndpoint, AuthorizationValue = requestEnvelope.Context.System.ApiAccessToken };

            var handlerInput = new DefaultHandlerInput
            {
                RequestEnvelope = requestEnvelope,
                Context = context,
                AttributesManager = AttributesManagerFactory.Init(requestEnvelope,
                _persistenceAdapter),
                ResponseBuilder = ResponseFactory.Init(),
                ServiceClientFactory = _apiClient != null ? new ServiceClientFactory(apiConfiguration) : null
            };

            var response = await _requestDispatcher.Dispatch(handlerInput);

            return new ResponseEnvelope
            {
                Version = "1.0",
                UserAgent = AskSdkUtil.CreateAskSdkUserAgent(Assembly.GetExecutingAssembly().GetName().Version.ToString(), _customUserAgent),
                Response = response,
                SessionAttributes = requestEnvelope.Session != null ? (await handlerInput.AttributesManager.GetSessionAttributes()) : null
            };
        }

        public Task<bool> Supports(object eventObject, object context = null)
        {
            return Task.FromResult(eventObject != null);
        }
    }
}
