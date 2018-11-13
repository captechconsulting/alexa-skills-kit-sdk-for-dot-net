namespace Ask.Sdk.Model.Request.Type
{
    public class DefaultRequestTypeConverter : IRequestTypeConverter
    {
        public bool CanConvert(string requestType)
        {
            return requestType == "IntentRequest" || requestType == "LaunchRequest" || requestType == "SessionEndedRequest" || requestType == "CanFulfillIntentRequest";
        }

        public Request Convert(string requestType)
        {
            switch (requestType)
            {
                case "IntentRequest":
                    return new IntentRequest();
                case "LaunchRequest":
                    return new LaunchRequest();
                case "SessionEndedRequest":
                    return new SessionEndedRequest();
                case "System.ExceptionEncountered":
                    return new SystemExceptionRequest();
                case "CanFulfillIntentRequest":
                    return new CanFulfillIntentRequest();
            }
            return null;
        }
    }
}