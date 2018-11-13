using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public interface IDirective
    {
        [JsonRequired]
        string Type { get; }
    }
}
