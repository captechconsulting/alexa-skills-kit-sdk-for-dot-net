using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ask.Sdk.Core.Skill;
using Ask.Sdk.Model.Request;
using Ask.Sdk.Model.Response;
using Ask.Sdk.Core.Service;
using Amazon.Lambda.Core;
using DeviceAddressLambda.Handlers;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace DeviceAddressLambda
{
    public class DeviceAddressFunction
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<ResponseEnvelope> FunctionHandler(RequestEnvelope request, ILambdaContext context)
        {
            var builder = SkillBuilders.Custom();

            return await builder.AddRequestHandlers(new CancelAndStopIntentHandler(),
                new DeviceAddressIntentHandler(context),
                new HelpIntentHandler(),
                new LaunchRequestHandler(),
                new SessionEndedRequestHandler(),
                new FallbackIntentHandler())
                .AddErrorHandlers(new ServiceErrorHandler())
                .WithApiClient(new DefaultApiClient())
                .Execute(request);
        }
    }
}
