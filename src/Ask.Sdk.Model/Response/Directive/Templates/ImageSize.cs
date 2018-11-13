using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive.Templates
{
    public enum ImageSize
    {
        [EnumMember(Value = "X_SMALL")]
        ExtraSmall,
        [EnumMember(Value = "SMALL")]
        Small,
        [EnumMember(Value = "MEDIUM")]
        Medium,
        [EnumMember(Value = "LARGE")]
        Large,
        [EnumMember(Value = "X_LARGE")]
        ExtraLarge
    }
}
