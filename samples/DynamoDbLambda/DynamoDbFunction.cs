using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Amazon.DynamoDBv2;
using Amazon.Lambda.Core;
using Ask.Sdk.Core.Skill;
using Ask.Sdk.DynamoDb.Persistence.Adapter.Attributes.Persistence;
using DynamoDbLambda.Handlers;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace DynamoDbLambda
{
    public class DynamoDbFunction
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<SkillResponse> FunctionHandler(SkillRequest request, ILambdaContext context)
        {
            var persistenceAdapter = await DynamoDbPersistenceAdapterFactory.Init("DynamoDbLambda", new AmazonDynamoDBClient());
            var builder = SkillBuilders.Custom()
                .AddRequestHandlers(new CancelAndStopIntentHandler(),
                new DynamoDbIntentHandler(),
                new HelloWorldIntentHandler(),
                new HelpIntentHandler(),
                new LaunchRequestHandler(),
                new SessionEndedRequestHandler(),
                new FallbackIntentHandler())
                .WithPersistenceAdapter(persistenceAdapter);

            return await builder.Execute(request);

        }
    }
}
