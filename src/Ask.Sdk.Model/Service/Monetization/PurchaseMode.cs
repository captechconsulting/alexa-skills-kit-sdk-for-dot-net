using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Service.Monetization
{
    public enum PurchaseMode
    {
        [EnumMember(Value = "TEST")]
        Test,

        [EnumMember(Value = "LIVE")]
        Live
    }
}