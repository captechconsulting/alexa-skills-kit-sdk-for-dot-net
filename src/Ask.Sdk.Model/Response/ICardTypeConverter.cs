using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public interface ICardTypeConverter
    {
        bool CanConvert(string cardType);
        ICard Convert(string cardType);
    }
}
