using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Ask.Sdk.Core.Skill;
using ProgressiveResponseLambda.Handlers;
using Alexa.NET.Request;
using Alexa.NET.Response;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace ProgressiveResponseLambda
{
    public class ProgressiveResponseFunction
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<SkillResponse> FunctionHandler(SkillRequest request, ILambdaContext context)
        {
            var builder = SkillBuilders.Custom();

            return await builder.AddRequestHandlers(new ProgressiveResponseHandler(),
                new ExitHandler(),
                new FallbackHandler(),
                new SessionEndedRequestHandler())
                .AddErrorHandlers(new ErrorHandler())
                .Execute(request);
        }
    }
}
