using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection
{
    public interface IAlexaSkillBuilder
    {
        IServiceCollection Services { get; }
    }
}
