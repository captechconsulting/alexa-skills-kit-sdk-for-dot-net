using Ask.Sdk.Model.Request;
using Ask.Sdk.Model.Request.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public class CardTypeConverter : ICardTypeConverter
    {
        public bool CanConvert(string cardType)
        {
            return cardType == "Standard";
        }

        public ICard Convert(string cardType)
        {
            switch (cardType)
            {
                case "Standard":
                    return new StandardCard();
            }

            return null;
        }
    }
}
