using Ask.Sdk.Model.Response.Directive.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Core.Response
{
    public abstract class TextContentHelper
    {
        protected string _primaryText;
        protected string _secondaryText;
        protected string _tertiaryText;

        public virtual TextContentHelper WithPrimaryText(string primaryText)
        {
            _primaryText = primaryText;

            return this;
        }

        public virtual TextContentHelper WithSecondaryText(string secondaryText)
        {
            _secondaryText = secondaryText;

            return this;
        }

        public virtual TextContentHelper WithTertiaryText(string tertiaryText)
        {
            _tertiaryText = tertiaryText;

            return this;
        }

        public abstract TextContent GetTextContent();
    }
}
