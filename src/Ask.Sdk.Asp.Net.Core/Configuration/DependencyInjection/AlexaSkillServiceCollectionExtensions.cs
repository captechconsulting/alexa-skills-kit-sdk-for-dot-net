using Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection.Extensions;
using Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection
{
    public static class AlexaSkillServiceCollectionExtensions
    {
        public static IAlexaSkillBuilder AddAlexaSkillBuilder(this IServiceCollection services)
        {
            return new AlexaSkillBuilder(services);
        }

        public static IAlexaSkillBuilder AddAlexaSkill(this IServiceCollection services)
        {
            var builder = services.AddAlexaSkillBuilder();

            builder.AddRequiredServices();

            return builder;
        }

        public static IAlexaSkillBuilder AddAlexaSkill(this IServiceCollection services, Action<AlexaSkillOptions> setupAction)
        {
            services.Configure(setupAction);
            return services.AddAlexaSkill();
        }

        public static IAlexaSkillBuilder AddAlexaSkill(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AlexaSkillOptions>(configuration);
            return services.AddAlexaSkill();
        }
    }
}
