using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Service.Ups
{
    public enum DistanceUnits
    {
        [EnumMember(Value = "METRIC")]
        Metric,

        [EnumMember(Value = "IMPERIAL")]
        Imperial
    }
}