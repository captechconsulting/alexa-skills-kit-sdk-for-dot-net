using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Request.Type
{
    public enum DialogState
    {
        [EnumMember(Value = "STARTED")]
        Started,
        [EnumMember(Value = "IN_PROGRESS")]
        InProgress,
        [EnumMember(Value = "COMPLETED")]
        Completed
    }
}