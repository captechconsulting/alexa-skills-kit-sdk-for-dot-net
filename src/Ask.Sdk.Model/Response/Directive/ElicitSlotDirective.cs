using Ask.Sdk.Model.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public class ElicitSlotDirective : IDirective
    {
        [JsonProperty("type")]
        public string Type => "Dialog.ElicitSlot";

        [JsonProperty("slotToElicit"), JsonRequired]
        public string SlotName { get; set; }

        [JsonProperty("updatedIntent", NullValueHandling = NullValueHandling.Ignore)]
        public Intent UpdatedIntent { get; set; }

        public ElicitSlotDirective() { }

        public ElicitSlotDirective(string slotName)
        {
            SlotName = slotName;
        }
    }
}
