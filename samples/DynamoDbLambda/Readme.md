# Sample DynamoDB Persistence Skill

The ASK SDK for .Net Core provides an interface for persistent data storage with an Alexa Skill.  This sample project uses the Ask.Sdk.DynamoDb.Persistance.Adapter assembly for Persistent Data.  If you use the project as is, it will create a DynamoDb table called DynamoDbLambda with a partition key of id.  You will need to grant a role that has Lambda execute plus DynamoDb access in AWS.

## Here are some steps to follow from Visual Studio:

To deploy your function to AWS Lambda, right click the project in Solution Explorer and select *Publish to AWS Lambda*.

To view your deployed function open its Function View window by double-clicking the function name shown beneath the AWS Lambda node in the AWS Explorer tree.

To perform testing against your deployed function use the Test Invoke tab in the opened Function View window.

To configure event sources for your deployed function, for example to have your function invoked when an object is created in an Amazon S3 bucket, use the Event Sources tab in the opened Function View window.

To update the runtime configuration of your deployed function use the Configuration tab in the opened Function View window.

To view execution logs of invocations of your function use the Logs tab in the opened Function View window.

## Here are some steps to follow to get started from the command line:

Once you have edited your template and code you can deploy your application using the [Amazon.Lambda.Tools Global Tool](https://github.com/aws/aws-extensions-for-dotnet-cli#aws-lambda-amazonlambdatools) from the command line.

Install Amazon.Lambda.Tools Global Tools if not already installed.
```
    dotnet tool install -g Amazon.Lambda.Tools
```

If already installed check if new version is available.
```
    dotnet tool update -g Amazon.Lambda.Tools
```


Deploy function to AWS Lambda
```
    cd "DynamoDbLambda/src/DynamoDbLambda"
    dotnet lambda deploy-function
```
