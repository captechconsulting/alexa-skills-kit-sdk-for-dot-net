using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public enum PlayBehavior
    {
        [EnumMember(Value = "REPLACE_ALL")]
        ReplaceAll,
        [EnumMember(Value = "ENQUEUE")]
        Enqueue,
        [EnumMember(Value = "REPLACE_ENQUEUED")]
        ReplaceEnqueued
    }
}
