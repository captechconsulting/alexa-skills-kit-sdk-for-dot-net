using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace Ask.Sdk.Model.Service
{
    public abstract class BaseServiceClient
    {
        protected ApiConfiguration ApiConfiguration;

        protected BaseServiceClient(ApiConfiguration apiConfiguration)
        {
            ApiConfiguration = apiConfiguration;
        }

        private bool IsSuccessStatusCode(int statusCode)
        {
            return (statusCode >= 200 && statusCode <= 299);
        }

        private string BuildUrl(string endpoint, string path, Dictionary<string, string> queryParameters)
        {
            var processedEndpoint = endpoint[endpoint.Length - 1] == '/' ? endpoint.Substring(0, endpoint.Length - 1) : endpoint;
            var isConstantQueryPresent = path.Contains("?");
            var queryString = BuildQueryString(queryParameters, isConstantQueryPresent);
            return $"{processedEndpoint}{path}{queryString}";
        }

        private string BuildQueryString(Dictionary<string, string> @params, bool queryPresent)
        {
            if (@params.Count == 0)
            {
                return string.Empty;
            }
            var queries = new List<string>();

            foreach(var p in @params)
            {
                queries.Add($"{p.Key}={p.Value}");
            }

            return $"{(queryPresent ? "?" : "")}{string.Join("&", queries.ToArray())}";
        }

        protected async Task<string> Invoke(string method, string endpoint, string path,
            Dictionary<string, string> queryParams,
            Dictionary<string, string> headerParams,
            string bodyParam = null)
        {
            var url = BuildUrl(endpoint, path, queryParams);
            var request = new ApiClientRequest()
            {
                Url = url,
                Method = method,
                Headers = headerParams,
                Token = ApiConfiguration.AuthorizationValue
            };

            if (bodyParam != null)
            {
                request.Body = bodyParam;
            }

            var result = await ApiConfiguration.ApiClient.Invoke(request);
            if (!IsSuccessStatusCode(result.StatusCode))
            {
                throw new HttpRequestException(result.StatusCode.ToString());
            }
            return result.Body;
        }

        protected async Task<T> Invoke<T>(string method, string endpoint, string path, 
            Dictionary<string, string> queryParams, 
            Dictionary<string, string> headerParams, 
            string bodyParam = null)
        {
            return JsonConvert.DeserializeObject<T>(await Invoke(method, endpoint, path, 
                queryParams, headerParams, bodyParam));
        }
    }
}
