using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Request
{

    public enum IntentConfirmationStatus
    {
        [EnumMember(Value = "NONE")]
        None,
        [EnumMember(Value = "DENIED")]
        Denied,
        [EnumMember(Value = "CONFIRMED")]
        Confirmed
    }
}