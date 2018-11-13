using Ask.Sdk.Core.Dispatcher.Error;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection.Extensions
{
    public static class AlexaSkillBuilderExtensionsError
    {
        public static IAlexaSkillBuilder AddErrorHandler<THandler>(this IAlexaSkillBuilder builder)
            where THandler : class, IErrorHandler
        {
            builder.Services.AddScoped<IErrorHandler, THandler>();
            return builder;
        }
        public static IAlexaSkillBuilder AddErrorHandlers(this IAlexaSkillBuilder builder, params Type[] handlers)
        {
            foreach (var handler in handlers.Where(h => h.GetInterfaces().Any(i => i == typeof(IErrorHandler))))
            {
                builder.Services.AddScoped(typeof(IErrorHandler), handler);
            }
            return builder;
        }
    }
}
