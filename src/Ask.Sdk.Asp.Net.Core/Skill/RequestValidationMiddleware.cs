using Alexa.NET.Request;
using Ask.Sdk.Asp.Net.Core.Configuration.DependencyInjection.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Ask.Sdk.Asp.Net.Core.Skill
{
    public class RequestValidationMiddleware : IMiddleware
    {
        private readonly AlexaSkillOptions _options;
        public RequestValidationMiddleware(AlexaSkillOptions options)
        {
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Request.EnableBuffering();

            // Verify SignatureCertChainUrl is present
            context.Request.Headers.TryGetValue("SignatureCertChainUrl", out var signatureChainUrl);
            if (string.IsNullOrWhiteSpace(signatureChainUrl))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            Uri certUrl;
            try
            {
                certUrl = new Uri(signatureChainUrl);
            }
            catch
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            // Verify SignatureCertChainUrl is Signature
            context.Request.Headers.TryGetValue("Signature", out var signature);
            if (string.IsNullOrWhiteSpace(signature))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            string body = new StreamReader(context.Request.Body).ReadToEnd();
            context.Request.Body.Position = 0;

            if (string.IsNullOrWhiteSpace(body))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }
            var valid = await RequestVerification.Verify(signature, certUrl, body);
            if (!valid)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            await next(context);
        }
    }
}
