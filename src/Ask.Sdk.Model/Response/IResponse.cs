using Newtonsoft.Json;

namespace Ask.Sdk.Model.Response
{
    public interface IResponse
    {
        [JsonRequired]
        string Type { get; }
    }
}