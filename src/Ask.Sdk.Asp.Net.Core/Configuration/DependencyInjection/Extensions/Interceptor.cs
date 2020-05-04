using Ask.Sdk.Core.Dispatcher.Request.Interceptor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection.Extensions
{
    public static class AlexaSkillBuilderExtensionsInterceptor
    {
        public static IAlexaSkillBuilder AddRequestInterceptor<TInterceptor>(this IAlexaSkillBuilder builder)
            where TInterceptor : class, ICustomSkillRequestInterceptor
        {
            builder.Services.AddScoped<ICustomSkillRequestInterceptor, TInterceptor>();

            return builder;
        }

        public static IAlexaSkillBuilder AddRequestInterceptors(this IAlexaSkillBuilder builder, params Type[] handlers)
        {
            foreach (var handler in handlers.Where(h => h.GetInterfaces().Any(i => i == typeof(ICustomSkillRequestInterceptor))))
            {
                builder.Services.AddScoped(typeof(ICustomSkillRequestInterceptor), handler);
            }
            return builder;
        }

        public static IAlexaSkillBuilder AddResponseInterceptor<TInterceptor>(this IAlexaSkillBuilder builder)
            where TInterceptor : class, ICustomSkillResponseInterceptor
        {
            builder.Services.AddScoped<ICustomSkillResponseInterceptor, TInterceptor>();

            return builder;
        }

        public static IAlexaSkillBuilder AddResponseInterceptors(this IAlexaSkillBuilder builder, params Type[] handlers)
        {
            foreach (var handler in handlers.Where(h => h.GetInterfaces().Any(i => i == typeof(ICustomSkillResponseInterceptor))))
            {
                builder.Services.AddScoped(typeof(ICustomSkillResponseInterceptor), handler);
            }
            return builder;
        }
    }
}
