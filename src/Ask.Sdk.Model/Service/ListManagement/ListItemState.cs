using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ask.Sdk.Model.Service.ListManagement
{
    public enum ListItemState
    {
        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "completed")]
        Completed
    }
}
