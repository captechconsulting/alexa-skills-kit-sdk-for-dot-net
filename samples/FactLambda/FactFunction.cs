using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ask.Sdk.Model.Response;
using Amazon.Lambda.Core;
using Ask.Sdk.Core.Skill;
using Ask.Sdk.Model.Request;
using FactLambda.Handlers;
using FactLambda.Interceptors.Request;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace FactLambda
{
    public class FactFunction
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

            return await builder
                .AddRequestHandlers(new GetNewFactHandler(),
                new HelpHandler(),
                new ExitHandler(),
                new FallbackHandler(),
                new SessionEndedRequestHandler())
                .AddRequestInterceptors(new LocalizationRequestInterceptor())
                .AddErrorHandlers(new ErrorHandler())
                .Execute(request);
        }
    }
}