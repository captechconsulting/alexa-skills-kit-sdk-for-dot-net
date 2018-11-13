using Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection.Options;
using Ask.Sdk.Core.Attributes.Persistence;
using Ask.Sdk.Core.Dispatcher.Error;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Core.Dispatcher.Request.Interceptor;
using Ask.Sdk.Core.Skill.Factory;
using Ask.Sdk.Model.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Asp.Net.Core.Skill
{
    public class BuilderMiddleware : IMiddleware
    {
        private readonly CustomSkillBuilder _customSkillBuilder;
        private readonly IEnumerable<IRequestHandler> _requestHandlers;
        private readonly IEnumerable<IErrorHandler> _errorHandlers;
        private readonly IEnumerable<IRequestInterceptor> _requestInterceptors;
        private readonly IEnumerable<IResponseInterceptor> _responseInterceptors;
        private readonly AlexaSkillOptions _alexaSkillOptions;
        private readonly IPersistenceAdapter _persistenceAdapter;
        private readonly IApiClient _apiClient;

        public BuilderMiddleware(CustomSkillBuilder customSkillkBuilder,
            AlexaSkillOptions alexaSkillOptions = null,
            IEnumerable<IRequestHandler> requestHandlers = null,
            IEnumerable<IErrorHandler> errorHandlers = null,
            IEnumerable<IRequestInterceptor> requestInterceptors = null,
            IEnumerable<IResponseInterceptor> responseInterceptors = null,
            IPersistenceAdapter persistenceAdapter = null,
            IApiClient apiClient = null)
        {
            _customSkillBuilder = customSkillkBuilder;
            _requestHandlers = requestHandlers;
            _alexaSkillOptions = alexaSkillOptions;
            _errorHandlers = errorHandlers;
            _requestInterceptors = requestInterceptors;
            _responseInterceptors = responseInterceptors;
            _persistenceAdapter = persistenceAdapter;
            _apiClient = apiClient;
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

            if (_apiClient != null)
            {
                _customSkillBuilder.WithApiClient(_apiClient);
            }

            await next(context);
        }
    }
}
