using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Ask.Sdk.Core.Dispatcher.Error;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Core.Dispatcher.Request.Interceptor;
using Ask.Sdk.Runtime.Skill;
using System;
using System.Threading.Tasks;

namespace Ask.Sdk.Core.Skill.Factory
{
    public abstract class BaseSkillBuilder<TBuilder>
        where TBuilder : BaseSkillBuilder<TBuilder>
    {
        private RuntimeConfigurationBuilder<IHandlerInput, ResponseBody> _runtimeConfigurationBuilder
        = new RuntimeConfigurationBuilder<IHandlerInput, ResponseBody>();
        private string _customUserAgent;
        private string _skillId;

        public TBuilder AddErrorHandler(Func<IHandlerInput, Exception, Task<bool>> matcher,
            Func<IHandlerInput, Exception, Task<ResponseBody>> executor)
        {
            _runtimeConfigurationBuilder.AddErrorHandler(matcher, executor);
            return AddErrorHandlers(new FunctionErrorHandler(matcher, executor));
        }

        public TBuilder AddErrorHandlers(params ICustomSkillErrorHandler[] errorHandlers)
        {
            _runtimeConfigurationBuilder.AddErrorHandlers(errorHandlers);

            return (TBuilder)this;
        }

        public TBuilder AddRequestHandler(string matcher, Func<IHandlerInput, Task<ResponseBody>> executor)
        {
            _runtimeConfigurationBuilder.AddRequestHandler((handlerInput) =>
            {
                return Task.FromResult(matcher == (handlerInput.RequestEnvelope.Request.Type == "IntentRequest" ?
                    ((IntentRequest)handlerInput.RequestEnvelope.Request).Intent.Name :
                    handlerInput.RequestEnvelope.Request.Type
                ));
            }, executor);
            return (TBuilder)this;
        }

        public TBuilder AddRequestHandler(Func<IHandlerInput, Task<bool>> matcher,
            Func<IHandlerInput, Task<ResponseBody>> executor)
        {
            _runtimeConfigurationBuilder.AddRequestHandler(matcher, executor);

            return (TBuilder)this;
        }

        public TBuilder AddRequestHandlers(params ICustomSkillRequestHandler[] requestHandlers)
        {
            _runtimeConfigurationBuilder.AddRequestHandlers(requestHandlers);

            return (TBuilder)this;
        }

        public TBuilder AddRequestInterceptors(params Func<IHandlerInput, Task>[] executors)
        {

            _runtimeConfigurationBuilder.AddRequestInterceptors(executors);

            return (TBuilder)this;
        }

        public TBuilder AddRequestInterceptors(params ICustomSkillRequestInterceptor[] executors)
        {
            _runtimeConfigurationBuilder.AddRequestInterceptors(executors);

            return (TBuilder)this;
        }

        public TBuilder AddResponseInterceptors(params Func<IHandlerInput, ResponseBody, Task>[] executors)
        {
            _runtimeConfigurationBuilder.AddResponseInterceptors(executors);

            return (TBuilder)this;
        }

        public TBuilder AddResponseInterceptors(params ICustomSkillResponseInterceptor[] executors)
        {
            _runtimeConfigurationBuilder.AddResponseInterceptors(executors);

            return (TBuilder)this;
        }

        public CustomSkill Create()
        {
            return new CustomSkill(GetSkillConfiguration());
        }

        public virtual CustomSkillConfiguration GetSkillConfiguration()
        {
            var runtimeConfiguration = new CustomSkillConfiguration(_runtimeConfigurationBuilder.GetRuntimeConfiguration())
            {
                CustomUserAgent = _customUserAgent,
                SkillId = _skillId
            };
            return runtimeConfiguration;
        }

        public Task<SkillResponse> Execute(SkillRequest request, object context = null)
        {
            var skill = new CustomSkill(GetSkillConfiguration());


            return skill.Invoke(request, context);
        }

        public TBuilder WithCustomUserAgent(string customUserAgent)
        {
            _customUserAgent = customUserAgent;

            return (TBuilder)this;
        }

        public TBuilder WithSkillId(string skillId)
        {
            _skillId = skillId;

            return (TBuilder)this;
        }

    }
}
