namespace Ask.Sdk.Model.Service
{
    public class ApiConfiguration
    {
        public IApiClient ApiClient { get; set; }
        public string AuthorizationValue { get; set; }
        public string ApiEndpoint { get; set; }
    }
}