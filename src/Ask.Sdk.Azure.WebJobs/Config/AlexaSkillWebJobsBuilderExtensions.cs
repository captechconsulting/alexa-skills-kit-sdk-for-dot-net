using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Azure.WebJobs.Config
{
    public static class AlexaSkillWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddAlexaSkill(this IWebJobsBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.AddExtension<AlexaSkillExtensionConfigProvider>();

            return builder;
        }
    }
}
