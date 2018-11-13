using Ask.Sdk.Model.Request.Type;

namespace Ask.Sdk.Model.Tests
{
    public class NewIntentRequestTypeConverter : IRequestTypeConverter
    {
        public bool CanConvert(string requestType)
        {
            return requestType == "AlexaNet.CustomIntent";
        }

        public Request.Request Convert(string requestType)
        {
            return new NewIntentRequest();
        }
    }
}