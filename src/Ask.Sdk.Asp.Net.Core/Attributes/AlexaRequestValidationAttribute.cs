using Ask.Sdk.Asp.Net.Core.Skill;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Asp.Net.Core.Attributes
{
    public class AlexaRequestValidationAttribute : MiddlewareFilterAttribute
    {
        public AlexaRequestValidationAttribute() : base(typeof(RequestValidationPipeline))
        {
        }
    }
}
