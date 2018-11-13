using Ask.Sdk.Model.Response.Directive.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Core.Response
{
    public class ImageHelper
    {
        protected Image _image;

        public Image Image
        {
            get
            {
                if (_image == null)
                    _image = new Image();
                return _image;
            }
        }

        public ImageHelper WithDescription(string description)
        {
            Image.ContentDescription = description;

            return this;
        }

        public ImageHelper AddImageInstance(string url, ImageSize? size = null, int widthPixels = 0, int heightPixels = 0)
        {
            var imageInstance = new ImageInstance
            {
                Url = url
            };

            if (size != null)
                imageInstance.Size = size;

            imageInstance.Height = heightPixels;

            imageInstance.Width = widthPixels;

            if (Image.Sources == null)
            {
                Image.Sources = new List<ImageInstance> { imageInstance };
            }
            else
            {
                Image.Sources.Add(imageInstance);
            }

            return this;
        }
    }
}
