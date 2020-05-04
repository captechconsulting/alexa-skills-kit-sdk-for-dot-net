using Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection.Options;
using Ask.Sdk.Core.Attributes.Persistence;
using Ask.Sdk.Core.Dispatcher.Error;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Core.Dispatcher.Request.Interceptor;
using Ask.Sdk.Core.Skill.Factory;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Sdk.Asp.Net.Core.Skill
{
    public class BuilderMiddleware : IMiddleware
    {
        private readonly CustomSkillBuilder _customSkillBuilder;
        private readonly IEnumerable<ICustomSkillRequestHandler> _requestHandlers;
        private readonly IEnumerable<ICustomSkillErrorHandler> _errorHandlers;
        private readonly IEnumerable<ICustomSkillRequestInterceptor> _requestInterceptors;
        private readonly IEnumerable<ICustomSkillResponseInterceptor> _responseInterceptors;
        private readonly AlexaSkillOptions _alexaSkillOptions;
        private readonly IPersistenceAdapter _persistenceAdapter;
        private readonly bool _withCanFulfillIntentRequest;
        private readonly bool _withAPL;
        private readonly bool _withInSkillPricing;

        public BuilderMiddleware(CustomSkillBuilder customSkillkBuilder,
            AlexaSkillOptions alexaSkillOptions = null,
            IEnumerable<ICustomSkillRequestHandler> requestHandlers = null,
            IEnumerable<ICustomSkillErrorHandler> errorHandlers = null,
            IEnumerable<ICustomSkillRequestInterceptor> requestInterceptors = null,
            IEnumerable<ICustomSkillResponseInterceptor> responseInterceptors = null,
            IPersistenceAdapter persistenceAdapter = null,
            bool withCanFulfillIntentRequest = false,
            bool withAPL = false,
            bool withInSkillPricing = false)
        {
            _customSkillBuilder = customSkillkBuilder;
            _requestHandlers = requestHandlers;
            _alexaSkillOptions = alexaSkillOptions;
            _errorHandlers = errorHandlers;
            _requestInterceptors = requestInterceptors;
            _responseInterceptors = responseInterceptors;
            _persistenceAdapter = persistenceAdapter;
            _withCanFulfillIntentRequest = withCanFulfillIntentRequest;
            _withAPL = withAPL;
            _withInSkillPricing = withInSkillPricing;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!string.IsNullOrEmpty(_alexaSkillOptions?.CustomUserAgent))
            {
                _customSkillBuilder.WithCustomUserAgent(_alexaSkillOptions.CustomUserAgent);
            }

            if (!string.IsNullOrEmpty(_alexaSkillOptions?.SkillId))
            {
                _customSkillBuilder.WithSkillId(_alexaSkillOptions.SkillId);
            }

            if (_requestHandlers?.Count() > 0)
            {
                _customSkillBuilder.AddRequestHandlers(_requestHandlers.ToArray());
            }

            if (_errorHandlers?.Count() > 0)
            {
                _customSkillBuilder.AddErrorHandlers(_errorHandlers.ToArray());
            }

            if (_requestInterceptors?.Count() > 0)
            {
                _customSkillBuilder.AddRequestInterceptors(_requestInterceptors.ToArray());
            }

            if (_responseInterceptors?.Count() > 0)
            {
                _customSkillBuilder.AddResponseInterceptors(_responseInterceptors.ToArray());
            }

            if (_persistenceAdapter != null)
            {
                _customSkillBuilder.WithPersistenceAdapter(_persistenceAdapter);
            }

            if (_withCanFulfillIntentRequest)
            {
                _customSkillBuilder.WithCanFulfillIntentRequest();
            }

            if (_withAPL)
            {
                _customSkillBuilder.WithAPL();
            }

            if (_withInSkillPricing)
            {
                _customSkillBuilder.WithInSkillPricing();
            }

            await next(context);
        }
    }
}
