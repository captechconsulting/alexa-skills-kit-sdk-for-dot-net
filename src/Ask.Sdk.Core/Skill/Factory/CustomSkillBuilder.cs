using Alexa.NET.APL;
using Alexa.NET.InSkillPricing.Directives;
using Alexa.NET.InSkillPricing.Responses;
using Alexa.NET.Request.Type;
using Ask.Sdk.Core.Attributes.Persistence;

namespace Ask.Sdk.Core.Skill.Factory
{
    public class CustomSkillBuilder : BaseSkillBuilder<CustomSkillBuilder>
    {
        private IPersistenceAdapter _persistenceAdapter;

       internal CustomSkillBuilder() { }

        public override CustomSkillConfiguration GetSkillConfiguration()
        {
            var skillConfiguration = base.GetSkillConfiguration();
            skillConfiguration.PersistenceAdapter = _persistenceAdapter;

            return skillConfiguration;
        }

        public CustomSkillBuilder WithPersistenceAdapter(IPersistenceAdapter persistenceAdapter)
        {
            _persistenceAdapter = persistenceAdapter;

            return this;
        }
        public CustomSkillBuilder WithCanFulfillIntentRequest()
        {
            CanFulfillIntentRequestConverter.AddToRequestConverter();

            return this;
        }

        public CustomSkillBuilder WithAPL()
        {
            APLSupport.Add();

            return this;
        }

        public CustomSkillBuilder WithInSkillPricing()
        {
            PaymentDirective.AddSupport();
            ConnectionRequestHandler.AddToRequestConverter();

            return this;
        }
    }
}
