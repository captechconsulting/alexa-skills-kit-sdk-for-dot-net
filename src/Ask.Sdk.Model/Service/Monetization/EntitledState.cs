using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Service.Monetization
{
    public enum EntitledState
    {
        [EnumMember(Value = "ENTITLED")]
        Entitled,

        [EnumMember(Value = "NOT_ENTITLED")]
        NotEntitled
    }
}