using System;
using System.Collections.Generic;
using System.Text;
using Ask.Sdk.Core.Attributes.Persistence;
using Ask.Sdk.Model.Service;

namespace Ask.Sdk.Core.Skill.Factory
{
    public static class CustomSkillFactory
    {
        public static CustomSkillBuilder Init()
        {
            return new CustomSkillBuilder();
        }
    }
}
