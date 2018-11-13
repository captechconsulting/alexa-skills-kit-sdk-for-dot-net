using System.Xml.Linq;

namespace Ask.Sdk.Model.Response.Ssml
{
    public interface ISsml
    {
        XNode ToXml();
    }
}