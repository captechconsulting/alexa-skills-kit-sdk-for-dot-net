using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Ask.Sdk.Model.Response.Ssml
{
    public class Prosody : ICommonSsml
    {
        public string Rate { get; set; }
        public string Pitch { get; set; }
        public string Volume { get; set; }

        public Prosody() { }

        public Prosody(params ISsml[] elements)
        {
            Elements = elements.ToList();
        }

        public List<ISsml> Elements { get; set; } = new List<ISsml>();

        public XNode ToXml()
        {
            List<XObject> attributes = new List<XObject>();

            if (!string.IsNullOrWhiteSpace(Rate))
            {
                attributes.Add(new XAttribute("rate", Rate));
            }

            if (!string.IsNullOrWhiteSpace(Pitch))
            {
                attributes.Add(new XAttribute("pitch", Pitch));
            }

            if (!string.IsNullOrWhiteSpace(Volume))
            {
                attributes.Add(new XAttribute("volume", Volume));
            }

            return new XElement("prosody", attributes.Concat(Elements.Select(e => e.ToXml())));
        }
    }
}
