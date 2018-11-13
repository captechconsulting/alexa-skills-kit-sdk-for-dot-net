using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public class CardConverter : JsonConverter
    {
        public static readonly List<ICardTypeConverter> CardConverters = new List<ICardTypeConverter>
        {
            new CardTypeConverter()
        };

        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ICard);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            var jObject = JObject.Load(reader);

            // Create target request object based on "type" property
            var target = Create(jObject["type"].Value<string>());

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        private ICard Create(string cardType)
        {
            var converter = CardConverters.FirstOrDefault(c => c.CanConvert(cardType));
            return converter?.Convert(cardType) ?? throw new ArgumentOutOfRangeException(nameof(Type), $"Unknown card type: {cardType}.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
