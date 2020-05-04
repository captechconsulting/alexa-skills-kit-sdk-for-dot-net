using Ask.Sdk.Core.Dispatcher.Error;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Core.Dispatcher.Request.Interceptor;
using Ask.Sdk.Core.Skill;
using Ask.Sdk.Core.Skill.Factory;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using System;
using System.Linq;

namespace Ask.Sdk.Azure.WebJobs.Config
{
    [Extension("AlexaSkill")]
    public class AlexaSkillExtensionConfigProvider : IExtensionConfigProvider, IConverter<AlexaSkillAttribute, CustomSkillBuilder>
    {
        public CustomSkillBuilder Convert(AlexaSkillAttribute input)
        {
            return BuildCustomSkillBuilderFromAttribute(input);
        }

        public void Initialize(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<AlexaSkillAttribute>();

            rule.BindToInput(BuildCustomSkillBuilderFromAttribute);
        }

        private CustomSkillBuilder BuildCustomSkillBuilderFromAttribute(AlexaSkillAttribute attribute)
        {
            var builder = SkillBuilders.Custom();

            builder.WithSkillId(attribute.SkillId);

            foreach (var type in attribute.RequestHandlers.Where(t => t.GetInterfaces().Any(i => i == typeof(ICustomSkillRequestHandler))))
            {
                builder.AddRequestHandlers(Activator.CreateInstance(type) as ICustomSkillRequestHandler);
            }

            foreach (var type in attribute.RequestInterceptors.Where(t => t.GetInterfaces().Any(i => i == typeof(ICustomSkillRequestInterceptor))))
            {
                builder.AddRequestInterceptors(Activator.CreateInstance(type) as ICustomSkillRequestInterceptor);
            }

            foreach (var type in attribute.ResponseInterceptors.Where(t => t.GetInterfaces().Any(i => i == typeof(ICustomSkillResponseInterceptor))))
            {
                builder.AddResponseInterceptors(Activator.CreateInstance(type) as ICustomSkillResponseInterceptor);
            }

            foreach (var type in attribute.ErrorHandlers.Where(t => t.GetInterfaces().Any(i => i == typeof(ICustomSkillErrorHandler))))
            {
                builder.AddErrorHandlers(Activator.CreateInstance(type) as ICustomSkillErrorHandler);
            }

            return builder;
        }
    }
}
