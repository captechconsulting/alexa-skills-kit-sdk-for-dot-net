# ASK SDK ASP.NET Core

ASK SDK ASP.NET Core contains the Middleware for handling Alexa Skills requests in an ASP.NET Core WebAPI.

## What is ASK SDK for .Net Core

The ASK SDK for .Net Core is an open-source Alexa Skills Development Kit. ASK SDK for .Net Core makes it easier for you to build highly engaging skills, by allowing you to spend more time on implementing features and less on writing boiler-plate code.

## Installing

To use the ASK SDK ASP.NET Core package, simply run the following commands in PowerShell or Nuget Package Manger:

```powershell
Install-Package Ask.Sdk.Asp.Net.Core -Version 1.0.1
```

Or you can install via the dotnet cli with this command:

```
dotnet add package Ask.Sdk.Asp.Net.Core --version 1.0.1
```

## Getting Started

After creating a new ASP.NET Core WebApi solution, you can configure your WebApi to use the ASK SDK by opening up the `Startup.cs` file and making the following changes. In the `ConfigureServices` method, add the following after `services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)`:

```cs
    services.AddAlexaSkill(options =>
    {
        options.SkillId = "<<Your Skill ID goes here>>";
    })
        .AddRequestHandlers(typeof(CancelAndStopIntentHandler),
            typeof(HelloWorldIntentHandler),
            typeof(HelpIntentHandler),
            typeof(LaunchRequestHandler),
            typeof(SessionEndedRequestHandler),
            typeof(FallbackIntentHandler));
```

This will register the `CustomSkillBuilder` with your `SkillId` and allow you to add your `IRequestHandler`, `IErrorHandler`, `IRequestInterceptor`, and `IResponseInterceptor` implementations while leveraging ASP.NET Core's built in Dependency Injection framework.

After configuring your Skill, you need to tell your application to use the ASk SDK.  Do this by adding the following in `Configure` before the call to `app.UseMvc()`:

```cs
    app.UseAlexaSkill(env.IsDevelopment());
```

This will tell your application to use the ASK SDK, as well as Validate that you have your application configured appropriately to handle Alexa Skills Kit Requests.

### Request Verification

As required by the [Alexa Documentation](https://developer.amazon.com/docs/custom-skills/host-a-custom-skill-as-a-web-service.html#requirements-for-your-web-service), since you are hosting your own Web Service to handle the Alexa Skills requests, you must verify the requests on your own.  When using AWS Lambda functions, this is handled for you.  To ensure that this happens with your ASP.NET Core Api, you simply need to decorate your `SkillController` with the appropriate attribute like this:

```cs
    [Route("api/[controller]")]
    [ApiController]
    [AlexaRequestValidation]
    public class SkillController : ControllerBase
```

This will wire up the appropriate Middleware so that requests to your Controller are verified before handling the request.