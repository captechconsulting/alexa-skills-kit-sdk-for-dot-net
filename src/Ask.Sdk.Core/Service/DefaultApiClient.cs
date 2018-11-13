using Ask.Sdk.Model.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Core.Service
{
    public class DefaultApiClient : IApiClient
    {
        public async Task<ApiClientResponse> Invoke(ApiClientRequest request)
        {
            var client = new HttpClient();
            var uri = new Uri(request.Url);
            client.BaseAddress = uri;

            if (!string.IsNullOrEmpty(request.Token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.Token);
            if (!string.IsNullOrEmpty(request.ContentType))
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(request.ContentType));

            HttpResponseMessage responseMessage;
            foreach (var header in request.Headers)
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }

            HttpContent content;

            switch (request.Method.ToLower())
            {
                case "get":
                    responseMessage = await client.GetAsync(request.Url);
                    break;
                case "put":
                    content = new StringContent(request.Body);
                    if (!string.IsNullOrEmpty(request.ContentType))
                        content.Headers.ContentType = new MediaTypeHeaderValue(request.ContentType);
                    responseMessage = await client.PutAsync(request.Url, content);
                    break;
                case "post":
                    content = new StringContent(request.Body);
                    if (!string.IsNullOrEmpty(request.ContentType))
                        content.Headers.ContentType = new MediaTypeHeaderValue(request.ContentType);
                    responseMessage = await client.PostAsync(request.Url, content);
                    break;
                case "delete":
                    responseMessage = await client.DeleteAsync(request.Url);
                    break;
                default:
                    throw new HttpRequestException($"Unsupported Method: {request.Method}");
            }

            responseMessage.EnsureSuccessStatusCode();

            return new ApiClientResponse()
            {
                Body = await responseMessage.Content.ReadAsStringAsync(),
                StatusCode = (int)responseMessage.StatusCode
            };
        }
    }
}
