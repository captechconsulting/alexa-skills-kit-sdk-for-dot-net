using Ask.Sdk.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Core.Attributes.Persistence
{
    public interface IPersistenceAdapter
    {
        Task<IDictionary<string, object>> GetAttributes(RequestEnvelope requestEnvelope);

        Task SaveAttributes(RequestEnvelope requestEnvelope, IDictionary<string, object> attributes);
    }
}
