using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Response
{
    public enum CanUnderstandSlotValues
    {
        [EnumMember(Value = "YES")]
        Yes,

        [EnumMember(Value = "NO")]
        No,

        [EnumMember(Value = "MAYBE")]
        Maybe
    }
}