using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Asp.Net.Core.Skill
{
    public class RequestValidationPipeline
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<RequestValidationMiddleware>();

        }
    }
}
