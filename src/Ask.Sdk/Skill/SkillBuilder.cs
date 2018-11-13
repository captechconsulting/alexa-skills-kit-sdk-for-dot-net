using Ask.Sdk.Skill.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Skill
{
    public static class SkillBuilder
    {
        public static StandardSkillBuilder Standard()
        {
            return StandardSkillFactory.Init();
        }
    }
}
