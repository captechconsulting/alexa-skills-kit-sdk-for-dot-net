using System.Threading.Tasks;
using Ask.Sdk.Core.Skill;
using Amazon.Lambda.Core;
using DeviceAddressLambda.Handlers;
using Alexa.NET.Request;
using Alexa.NET.Response;

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
        public async Task<SkillResponse> FunctionHandler(SkillRequest request, ILambdaContext context)
        {
            var builder = SkillBuilders.Custom();

            return await builder.AddRequestHandlers(new CancelAndStopIntentHandler(),
                new DeviceAddressIntentHandler(context),
                new HelpIntentHandler(),
                new LaunchRequestHandler(),
                new SessionEndedRequestHandler(),
                new FallbackIntentHandler())
                .AddErrorHandlers(new ServiceErrorHandler())
                .Execute(request);
        }
    }
}
