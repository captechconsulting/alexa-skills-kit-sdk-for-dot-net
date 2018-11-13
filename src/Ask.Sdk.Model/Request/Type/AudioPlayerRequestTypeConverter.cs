namespace Ask.Sdk.Model.Request.Type
{
    internal class AudioPlayerRequestTypeConverter : IRequestTypeConverter
    {
        public bool CanConvert(string requestType)
        {
            return requestType.StartsWith("AudioPlayer");
        }

        public Request Convert(string requestType)
        {
            return new AudioPlayerRequest();
        }
    }
}