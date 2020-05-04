using Alexa.NET.Request;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Ask.Sdk.Azure.WebJobs.Validation
{
    public static class RequestValidator
    {
        public async static Task<SkillRequest> ValidateRequest(HttpRequest request)
        {
            request.Headers.TryGetValue("SignatureCertChainUrl", out var signatureChainUrl);
            if (string.IsNullOrEmpty(signatureChainUrl))
                return null;

            Uri certUrl;
            try
            {
                certUrl = new Uri(signatureChainUrl);
            }
            catch
            {
                return null;
            }

            request.Headers.TryGetValue("Signature", out var signature);

            if (string.IsNullOrEmpty(signature))
                return null;

            var body = await new StreamReader(request.Body).ReadToEndAsync();

            if (string.IsNullOrEmpty(body))
                return null;

            var valid = await RequestVerification.Verify(signature, certUrl, body);

            if (!valid)
                return null;

            var requestEnvelope = JsonConvert.DeserializeObject<SkillRequest>(body);

            return requestEnvelope;
        }
    }
}
