using Alexa.NET.Response.Directive.Templates;

namespace Ask.Sdk.Core.Response
{
    public class RichTextContentHelper : TextContentHelper
    {
        public override TemplateContent GetTextContent()
        {
            var textContent = new TemplateContent();

            if (!string.IsNullOrEmpty(_primaryText))
                textContent.Primary = new TemplateText
                {
                    Type = "RichText",
                    Text = _primaryText
                };

            if (!string.IsNullOrEmpty(_secondaryText))
                textContent.Secondary = new TemplateText
                {
                    Type = "RichText",
                    Text = _secondaryText
                };

            if (!string.IsNullOrEmpty(_tertiaryText))
                textContent.Tertiary = new TemplateText
                {
                    Type = "RichText",
                    Text = _tertiaryText
                };

            return textContent;
        }
    }
}
