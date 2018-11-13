using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Request
{
    public enum Shape
    {
        [EnumMember(Value = "RECTANGLE")]
        Rectangle,

        [EnumMember(Value = "ROUND")]
        Round
    }
}