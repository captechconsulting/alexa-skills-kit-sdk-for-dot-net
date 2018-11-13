using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public enum BackButtonBehavior
    {
        [EnumMember(Value = "HIDDEN")]
        Hidden,
        [EnumMember(Value = "VISIBLE")]
        Visible
    }
}
