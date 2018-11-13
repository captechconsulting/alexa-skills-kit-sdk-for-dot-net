using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Service.Monetization
{
    public enum PurchasableState
    {
        [EnumMember(Value = "PURCHASABLE")]
        Purchasable,

        [EnumMember(Value = "NOT_PURCHASABLE")]
        NonPurchasable
    }
}