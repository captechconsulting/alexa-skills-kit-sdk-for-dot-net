using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Model.Service
{
    public interface IApiClient
    {
        Task<ApiClientResponse> Invoke(ApiClientRequest request);
    }
}
