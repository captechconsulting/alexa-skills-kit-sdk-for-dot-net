using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Ask.Sdk.Core.Service;
using Ask.Sdk.Core.Skill;
using Ask.Sdk.Model.Request;
using Ask.Sdk.Model.Response;
using CustomerSettingsLambda.Handlers;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace CustomerSettingsLambda
{
    public class CustomerSettingsFunction
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

            return await builder.AddRequestHandlers(new TimeZoneHandler(),
                new DistanceUnitsHandler(),
                new TemperatureUnitsHandler())
                .WithApiClient(new DefaultApiClient())
                .Execute(request);
        }
    }
}
