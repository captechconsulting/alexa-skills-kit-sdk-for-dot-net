using Alexa.NET.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Core.Attributes.Persistence
{
    public interface IPersistenceAdapter
    {
        Task<IDictionary<string, object>> GetAttributes(SkillRequest requestEnvelope);

        Task SaveAttributes(SkillRequest requestEnvelope, IDictionary<string, object> attributes);
    }
}
