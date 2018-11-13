# ASK SDK Azure WebJobs

ASK SDK Azure WebJobs contains the Middleware for handling Alexa Skills requests in an Azure Function.

## What is ASK SDK for .Net Core

The ASK SDK for .Net Core is an open-source Alexa Skills Development Kit. ASK SDK for .Net Core makes it easier for you to build highly engaging skills, by allowing you to spend more time on implementing features and less on writing boiler-plate code.

## Installing

To use the ASK SDK Azure WebJobs package, simply run the following commands in PowerShell or Nuget Package Manger:

```powershell
Install-Package Ask.Sdk.Azure.WebJobs -Version 1.0.0
```

Or you can install via the dotnet cli with this command:

```
dotnet add package Ask.Sdk.Azure.WebJobs --version 1.0.0
```
## Getting Started

After creating a new Azure Functions solution, you can configure your Function to use the ASK SDK by opening up the `Function1.cs` file and making the following changes. In the `Run` method, add the `AlexaSkillAttribute` input binding to create an instance of the CustomSkillBuilder to pass in to your function.  It will look something like this:

```cs
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
        //...Handler logic goes here.
    }
```

This will register the `CustomSkillBuilder` with your `SkillId` and allow you to add your `IRequestHandler`, `IErrorHandler`, `IRequestInterceptor`, and `IResponseInterceptor` implementations while leveraging Azure WebJob's `InputBinding` functionality. By default, this will look for your SkillId as an application setting called `SkillId`.  You can specify a differenet setting name by changing your signature slightly to looke something like this:

```cs
    [FunctionName("HellowWorldFunction")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
        [AlexaSkill(SkillId = "SomeOtherKeyValue)] CustomSkillBuilder builder,
        ILoger log)
    {
        //...Handler logic goes here.
    }
```

### Request Verification

As required by the [Alexa Documentation](https://developer.amazon.com/docs/custom-skills/host-a-custom-skill-as-a-web-service.html#requirements-for-your-web-service), since you are hosting your own Web Service to handle the Alexa Skills requests, you must verify the requests on your own.  When using AWS Lambda functions, this is handled for you.  To ensure that this happens with your Azure Function, you simply need to use the `RequestValidator` like this:

```cs
    var requestEnvelope = await RequestValidator.ValidateRequest(req);
    if (requestEnvelope == null)
    {
        return new BadRequestResult();
    }

    return new OkObjectResult(await builder.Execute(requestEnvelope));
```

This will verify the request and return the `RequestEnvelope` for processing.