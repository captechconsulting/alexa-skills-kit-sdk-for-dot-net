using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public enum ClearBehavior
    {
        [EnumMember(Value = "CLEAR_ENQUEUED")]
        ClearEnqueued,
        [EnumMember(Value = "CLEAR_ALL")]
        ClearAll
    }
}
