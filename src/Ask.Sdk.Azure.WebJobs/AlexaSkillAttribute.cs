using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Azure.WebJobs
{
    [Binding]
    public class AlexaSkillAttribute : Attribute
    {
        [AppSetting(Default = "SkillId")]
        public string SkillId { get; set; }

        public Type[] RequestHandlers { get; set; } = new Type[] { };

        public Type[] RequestInterceptors { get; set; } = new Type[] { };

        public Type[] ResponseInterceptors { get; set; } = new Type[] { };

        public Type[] ErrorHandlers { get; set; } = new Type[] { };
    }
}
