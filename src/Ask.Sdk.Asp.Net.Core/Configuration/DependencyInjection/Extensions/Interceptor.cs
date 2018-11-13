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
            where TInterceptor : class, IRequestInterceptor
        {
            builder.Services.AddScoped<IRequestInterceptor, TInterceptor>();

            return builder;
        }

        public static IAlexaSkillBuilder AddRequestInterceptors(this IAlexaSkillBuilder builder, params Type[] handlers)
        {
            foreach (var handler in handlers.Where(h => h.GetInterfaces().Any(i => i == typeof(IRequestInterceptor))))
            {
                builder.Services.AddScoped(typeof(IRequestInterceptor), handler);
            }
            return builder;
        }

        public static IAlexaSkillBuilder AddResponseInterceptor<TInterceptor>(this IAlexaSkillBuilder builder)
            where TInterceptor : class, IResponseInterceptor
        {
            builder.Services.AddScoped<IResponseInterceptor, TInterceptor>();

            return builder;
        }

        public static IAlexaSkillBuilder AddResponseInterceptors(this IAlexaSkillBuilder builder, params Type[] handlers)
        {
            foreach (var handler in handlers.Where(h => h.GetInterfaces().Any(i => i == typeof(IResponseInterceptor))))
            {
                builder.Services.AddScoped(typeof(IResponseInterceptor), handler);
            }
            return builder;
        }
    }
}
