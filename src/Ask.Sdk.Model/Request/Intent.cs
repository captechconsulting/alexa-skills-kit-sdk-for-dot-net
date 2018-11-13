using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Request
{
    public class Intent
    {
        private string _name;

        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Signature = value;
            }
        }

        [JsonProperty("confirmationStatus")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IntentConfirmationStatus ConfirmationStatus { get; set; }

        [JsonProperty("slots")]
        public Dictionary<string, Slot> Slots { get; set; }

        [JsonIgnore]
        public IntentSignature Signature { get; private set; }
    }
}
