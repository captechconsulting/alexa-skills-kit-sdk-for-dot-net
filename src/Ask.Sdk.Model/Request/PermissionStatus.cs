using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Request
{
    public enum PermissionStatus
    {
        [EnumMember(Value = "GRANTED")]
        Granted,
        [EnumMember(Value = "DENIED")]
        Denied
    }
}