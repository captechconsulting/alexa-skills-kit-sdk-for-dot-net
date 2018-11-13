using System;
using System.Collections.Generic;
using System.Text;
using Ask.Sdk.Model.Response.Directive.Templates;

namespace Ask.Sdk.Core.Response
{
    public class RichTextContentHelper : TextContentHelper
    {
        public override TextContent GetTextContent()
        {
            var textContent = new TextContent();

            if (!string.IsNullOrEmpty(_primaryText))
                textContent.Primary = new TextField
                {
                    Type = "RichText",
                    Text = _primaryText
                };

            if (!string.IsNullOrEmpty(_secondaryText))
                textContent.Secondary = new TextField
                {
                    Type = "RichText",
                    Text = _secondaryText
                };

            if (!string.IsNullOrEmpty(_tertiaryText))
                textContent.Tertiary = new TextField
                {
                    Type = "RichText",
                    Text = _tertiaryText
                };

            return textContent;
        }
    }
}
