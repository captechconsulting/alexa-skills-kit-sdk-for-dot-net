using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Response
{
    public enum CanFulfillSlotValues
    {
        [EnumMember(Value = "YES")]
        Yes,

        [EnumMember(Value = "NO")]
        No
    }
}