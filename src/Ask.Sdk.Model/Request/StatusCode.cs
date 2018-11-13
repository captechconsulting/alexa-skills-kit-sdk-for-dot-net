using System.Runtime.Serialization;

namespace Ask.Sdk.Model.Request
{
    public enum StatusCode
    {
        [EnumMember(Value = "ER_SUCCESS_MATCH")]
        SuccessfulMatch,
        [EnumMember(Value = "ER_SUCCESS_NO_MATCH")]
        NoMatch,
        [EnumMember(Value = "ER_ERROR_TIMEOUT")]
        Timeout,
        [EnumMember(Value = "ER_ERROR_EXCEPTION")]
        Exception
    }
}