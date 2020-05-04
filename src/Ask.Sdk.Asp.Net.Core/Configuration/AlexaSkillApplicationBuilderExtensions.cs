using Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection.Options;
using Ask.Sdk.Asp.Net.Core.Extensions;
using Ask.Sdk.Asp.Net.Core.Skill;
using Ask.Sdk.Core.Skill.Factory;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Asp.Net.Core.Configuration
{
    public static class AlexaSkillApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAlexaSkill(this IApplicationBuilder app, bool isDevelopment = false)
        {
            app.Validate(isDevelopment);

            app.UseMiddleware<RequestValidationMiddleware>();

            app.UseMiddleware<BuilderMiddleware>();

            return app;
        }

        internal static void Validate(this IApplicationBuilder app, bool isDevelopment)
        {
            var loggerFactory = app.ApplicationServices.GetService(typeof(ILoggerFactory)) as ILoggerFactory;
            if (loggerFactory == null) throw new ArgumentNullException(nameof(loggerFactory));

            var logger = loggerFactory.CreateLogger("Ask.Sdk.Asp.Net.Core.Startup");

            var scopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                TestService(serviceProvider, typeof(CustomSkillBuilder), logger, "No Skill Builder Registered.  Use AddAlexaSkill extension method to register a valid Skill Builder.");

                var options = serviceProvider.GetRequiredService<AlexaSkillOptions>();
                ValidateOptions(options, logger, isDevelopment);
            }
        }

        private static void ValidateOptions(AlexaSkillOptions options, ILogger logger, bool isDevelopment)
        {
            if (options.SkillId.IsPresent()) logger.LogDebug("SkillId set to {0}", options.SkillId);

            if (options.CustomUserAgent.IsPresent()) logger.LogDebug("CustomUserAgent set to {0}", options.CustomUserAgent);

            if (options.SkillId.IsMissing() && !isDevelopment) throw new InvalidOperationException("SkillId parameter is not configured");
        }

        internal static object TestService(IServiceProvider serviceProvider, Type service, ILogger logger, string message = null, bool doThrow = true)
        {
            var appService = serviceProvider.GetService(service);

            if (appService == null)
            {
                var error = message ?? $"Required service {service.FullName} is not registered in the DI container. Aborting startup";

                logger.LogCritical(error);

                if (doThrow)
                {
                    throw new InvalidOperationException(error);
                }
            }

            return appService;
        }
    }
}
