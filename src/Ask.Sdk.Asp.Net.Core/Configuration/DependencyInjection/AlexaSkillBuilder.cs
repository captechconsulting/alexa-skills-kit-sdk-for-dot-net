using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection
{
    public class AlexaSkillBuilder : IAlexaSkillBuilder
    {
        public AlexaSkillBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }
        
        public IServiceCollection Services { get; }
    }
}
