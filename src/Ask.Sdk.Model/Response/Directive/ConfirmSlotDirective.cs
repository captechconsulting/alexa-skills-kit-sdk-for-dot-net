using Ask.Sdk.Model.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public class ConfirmSlotDirective : IDirective
    {
        [JsonProperty("type")]
        public string Type => "Dialog.ConfirmSlot";

        [JsonProperty("slotToConfirm"), JsonRequired]
        public string SlotName { get; set; }

        [JsonProperty("updatedIntent", NullValueHandling = NullValueHandling.Ignore)]
        public Intent UpdatedIntent { get; set; }

        public ConfirmSlotDirective(string slotName)
        {
            SlotName = slotName;
        }
    }
}
