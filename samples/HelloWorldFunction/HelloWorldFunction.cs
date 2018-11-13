using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ask.Sdk.Azure.WebJobs;
using Ask.Sdk.Core.Skill.Factory;
using Ask.Sdk.Model.Request;
using HelloWorldFunction.Handlers;
using Ask.Sdk.Azure.WebJobs.Validation;

namespace HelloWorldFunction
{
    public static class HelloWorldFunction
    {
        [FunctionName("HelloWorldFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [AlexaSkill(RequestHandlers = new [] { typeof(CancelAndStopIntentHandler),
                typeof(HelloWorldIntentHandler),
                typeof(HelpIntentHandler),
                typeof(LaunchRequestHandler),
                typeof(SessionEndedRequestHandler),
                typeof(FallbackIntentHandler)
            })] CustomSkillBuilder builder,
            ILogger log)
        {
            var requestEnvelope = await RequestValidator.ValidateRequest(req);
            if (requestEnvelope == null)
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(await builder.Execute(requestEnvelope));
        }
    }
}
