using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Service.Monetization
{
    public enum ProductType
    {
        [EnumMember(Value = "SUBSCRIPTION")]
        Subscription,

        [EnumMember(Value = "ENTITLEMENT")]
        Entitlement,

        [EnumMember(Value = "CONSUMABLE")]
        Consumable,
    }
}