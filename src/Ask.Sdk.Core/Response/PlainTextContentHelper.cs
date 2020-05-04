using Alexa.NET.Response.Directive.Templates;

namespace Ask.Sdk.Core.Response
{
    public class PlainTextContentHelper : TextContentHelper
    {

        public override TemplateContent GetTextContent()
        {
            var textContent = new TemplateContent();

            if (!string.IsNullOrEmpty(_primaryText))
                textContent.Primary = new TemplateText
                {
                    Type = "PlainText",
                    Text = _primaryText
                };

            if (!string.IsNullOrEmpty(_secondaryText))
                textContent.Secondary = new TemplateText
                {
                    Type = "PlainText",
                    Text = _secondaryText
                };

            if (!string.IsNullOrEmpty(_tertiaryText))
                textContent.Tertiary = new TemplateText
                {
                    Type = "PlainText",
                    Text = _tertiaryText
                };

            return textContent;
        }
    }
}
