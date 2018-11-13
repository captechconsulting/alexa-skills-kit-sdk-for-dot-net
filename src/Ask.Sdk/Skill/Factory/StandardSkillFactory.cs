using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Skill.Factory
{
    public static class StandardSkillFactory
    {
        public static StandardSkillBuilder Init()
        {
            return new StandardSkillBuilder();
        }
    }
}
