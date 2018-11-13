using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response.Directive
{
    public interface IListTemplate : ITemplate
    {
        [JsonProperty("listItems", Required = Required.Always)]
        List<ListItem> Items { get; set; }
    }
}
