using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Skill
{
    public interface ISkill<TRequest, TResponse>
    {
        Task<TResponse> Invoke(TRequest eventRequest, object context = null);

        Task<bool> Supports(object eventObject, object context = null);
    }
}
