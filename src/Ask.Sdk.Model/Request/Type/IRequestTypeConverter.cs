namespace Ask.Sdk.Model.Request.Type
{
    public interface IRequestTypeConverter
    {
        bool CanConvert(string requestType);
        Request Convert(string requestType);
    }
}