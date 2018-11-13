using Ask.Sdk.Core.Attributes.Persistence;
using Ask.Sdk.Model.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Core.Skill.Factory
{
    public class CustomSkillBuilder : BaseSkillBuilder<CustomSkillBuilder>
    {
        private IPersistenceAdapter _persistenceAdapter;
        private IApiClient _apiClient;

       internal CustomSkillBuilder() { }

        public override SkillConfiguration GetSkillConfiguration()
        {
            var skillConfiguration = base.GetSkillConfiguration();
            skillConfiguration.PersistenceAdapter = _persistenceAdapter;
            skillConfiguration.ApiClient = _apiClient;

            return skillConfiguration;
        }

        public CustomSkillBuilder WithApiClient(IApiClient apiClient)
        {
            _apiClient = apiClient;

            return this;
        }

        public CustomSkillBuilder WithPersistenceAdapter(IPersistenceAdapter persistenceAdapter)
        {
            _persistenceAdapter = persistenceAdapter;

            return this;
        }
    }
}
