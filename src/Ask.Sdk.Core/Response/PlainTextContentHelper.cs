using System;
using System.Collections.Generic;
using System.Text;
using Ask.Sdk.Model.Response.Directive.Templates;

namespace Ask.Sdk.Core.Response
{
    public class PlainTextContentHelper : TextContentHelper
    {

        public override TextContent GetTextContent()
        {
            var textContent = new TextContent();

            if (!string.IsNullOrEmpty(_primaryText))
                textContent.Primary = new TextField
                {
                    Type = "PlainText",
                    Text = _primaryText
                };

            if (!string.IsNullOrEmpty(_secondaryText))
                textContent.Secondary = new TextField
                {
                    Type = "PlainText",
                    Text = _secondaryText
                };

            if (!string.IsNullOrEmpty(_tertiaryText))
                textContent.Tertiary = new TextField
                {
                    Type = "PlainText",
                    Text = _tertiaryText
                };

            return textContent;
        }
    }
}
