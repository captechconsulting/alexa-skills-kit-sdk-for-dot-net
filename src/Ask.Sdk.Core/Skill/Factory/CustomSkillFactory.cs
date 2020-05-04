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
