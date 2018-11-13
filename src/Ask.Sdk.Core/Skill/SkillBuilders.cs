using Ask.Sdk.Core.Skill.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Core.Skill
{
    public static class SkillBuilders
    {
        public static CustomSkillBuilder Custom()
        {
            return CustomSkillFactory.Init();
        }
    }
}
