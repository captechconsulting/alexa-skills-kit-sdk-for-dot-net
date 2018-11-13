using Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection.Options;
using Ask.Sdk.Asp.Net.Core.Skill;
using Ask.Sdk.Core.Skill;
using Ask.Sdk.Core.Skill.Factory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection.Extensions
{
    public static class AlexaSkillBuilderExtensionsCore
    {
        public static IAlexaSkillBuilder AddRequiredServices(this IAlexaSkillBuilder builder)
        {
            builder.Services.AddScoped<BuilderMiddleware>();
            builder.Services.AddScoped<RequestValidationMiddleware>();
            builder.Services.AddScoped(factory => SkillBuilders.Custom());
            builder.Services.AddSingleton(
                resolver => resolver.GetRequiredService<IOptions<AlexaSkillOptions>>().Value);

            return builder;
        }
    }
}
