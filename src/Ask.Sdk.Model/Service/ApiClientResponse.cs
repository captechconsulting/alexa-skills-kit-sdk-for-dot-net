using Newtonsoft.Json;
using System.Net;

namespace Ask.Sdk.Model.Service
{
    public class ApiClientResponse : ApiClientMessage
    {
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

    }
}