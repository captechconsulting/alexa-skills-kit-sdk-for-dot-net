﻿using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection.Extensions
{
    public static class AlexaSkillBuilderExtensionsHandler
    {
        public static IAlexaSkillBuilder AddRequestHandler<THandler>(this IAlexaSkillBuilder builder) where THandler : class, ICustomSkillRequestHandler
        {
            builder.Services.AddScoped<ICustomSkillRequestHandler, THandler>();
            return builder;
        }

        public static IAlexaSkillBuilder AddRequestHandlers(this IAlexaSkillBuilder builder, params Type[] handlers)
        {
            foreach(var handler in handlers.Where(h => h.GetInterfaces().Any(i => i == typeof(ICustomSkillRequestHandler))))
            {
                builder.Services.AddScoped(typeof(ICustomSkillRequestHandler), handler);
            }
            return builder;
        }
    }
}
