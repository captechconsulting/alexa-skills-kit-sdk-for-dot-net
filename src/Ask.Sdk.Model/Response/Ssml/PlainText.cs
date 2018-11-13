using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ask.Sdk.Model.Response.Ssml
{
    public class PlainText : ICommonSsml
    {
        public PlainText(string text)
        {
            Text = TrimOutputSpeech(text);
        }

        public string Text { get; set; }

        public XNode ToXml()
        {
            return new XText(Text);
        }

        private string TrimOutputSpeech(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            text = text.Trim();

            if (text.StartsWith("<"))
            {
                try
                {
                    var element = XElement.Parse(text);
                    if (element.Name.LocalName.ToLower() == "speak")
                    {
                        return element.Value.Trim();
                    }
                }
                catch (XmlException)
                {
                    return text;
                }
            }

            return text;
        }
    }
}
