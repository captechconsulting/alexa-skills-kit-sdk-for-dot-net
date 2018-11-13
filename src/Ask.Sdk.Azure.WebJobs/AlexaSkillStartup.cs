using Ask.Sdk.Azure.WebJobs;
using Ask.Sdk.Azure.WebJobs.Config;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: WebJobsStartup(typeof(AlexaSkillStartup))]
namespace Ask.Sdk.Azure.WebJobs
{
    public class AlexaSkillStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddAlexaSkill();
        }
    }
}
