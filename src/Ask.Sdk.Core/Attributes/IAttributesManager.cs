using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Core.Attributes
{
    public interface IAttributesManager
    {
        Task<IDictionary<string, object>> GetRequestAttributes();

        Task<IDictionary<string, object>> GetSessionAttributes();

        Task<IDictionary<string, object>> GetPersistentAttributes();

        Task SetRequestAttributes(IDictionary<string, object> requestAttributes);

        Task SetSessionAttributes(IDictionary<string, object> sessionAttributes);

        Task SetPersistentAttributes(IDictionary<string, object> persistentAttributes);

        Task SavePersistentAttributes();
    }
}
