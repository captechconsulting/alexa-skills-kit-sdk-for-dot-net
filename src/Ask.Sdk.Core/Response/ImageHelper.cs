using Alexa.NET.Response.Directive.Templates;
using System.Collections.Generic;

namespace Ask.Sdk.Core.Response
{
    public class ImageHelper
    {
        protected TemplateImage _image;

        public TemplateImage Image
        {
            get
            {
                if (_image == null)
                    _image = new TemplateImage();
                return _image;
            }
        }

        public ImageHelper WithDescription(string description)
        {
            Image.ContentDescription = description;

            return this;
        }

        public ImageHelper AddImageInstance(string url, string size = null, int widthPixels = 0, int heightPixels = 0)
        {
            var imageInstance = new ImageSource
            {
                Url = url
            };

            if (size != null)
                imageInstance.Size = size;

            imageInstance.Height = heightPixels;

            imageInstance.Width = widthPixels;

            if (Image.Sources == null)
            {
                Image.Sources = new List<ImageSource> { imageInstance };
            }
            else
            {
                Image.Sources.Add(imageInstance);
            }

            return this;
        }
    }
}
