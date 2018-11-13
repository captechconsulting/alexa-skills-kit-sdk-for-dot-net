using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public enum CanFulfillIntentValues
    {
        [EnumMember(Value = "YES")]
        Yes,

        [EnumMember(Value = "NO")]
        No,

        [EnumMember(Value = "MAYBE")]
        Maybe
    }
}
