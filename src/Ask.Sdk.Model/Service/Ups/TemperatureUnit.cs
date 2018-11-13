using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Service.Ups
{
    public enum TemperatureUnit
    {
        [EnumMember(Value = "CELSIUS")]
        Celsius,

        [EnumMember(Value = "FAHRENHEIT")]
        Fahrenheit
    }
}