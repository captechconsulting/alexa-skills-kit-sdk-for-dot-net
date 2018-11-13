using Ask.Sdk.Core.Dispatcher.Error;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Core.Dispatcher.Request.Interceptor;
using Ask.Sdk.Core.Skill;
using Ask.Sdk.Core.Skill.Factory;
using Ask.Sdk.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            foreach (var type in attribute.RequestHandlers.Where(t => t.GetInterfaces().Any(i => i == typeof(IRequestHandler))))
            {
                builder.AddRequestHandlers(Activator.CreateInstance(type) as IRequestHandler);
            }

            foreach (var type in attribute.RequestInterceptors.Where(t => t.GetInterfaces().Any(i => i == typeof(IRequestInterceptor))))
            {
                builder.AddRequestInterceptors(Activator.CreateInstance(type) as IRequestInterceptor);
            }

            foreach (var type in attribute.ResponseInterceptors.Where(t => t.GetInterfaces().Any(i => i == typeof(IResponseInterceptor))))
            {
                builder.AddResponseInterceptors(Activator.CreateInstance(type) as IResponseInterceptor);
            }

            foreach (var type in attribute.ErrorHandlers.Where(t => t.GetInterfaces().Any(i => i == typeof(IErrorHandler))))
            {
                builder.AddErrorHandlers(Activator.CreateInstance(type) as IErrorHandler);
            }

            return builder;
        }
    }
}
