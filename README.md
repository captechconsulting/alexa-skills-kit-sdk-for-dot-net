# Alexa Skills Kit for .Net Core

The ASK SDK v1 for .Net Core is based on the [NodeJS version](https://github.com/alexa/alexa-skills-kit-sdk-for-nodejs) and the [Alexa Skills SDK for .Net](https://github.com/timheuer/alexa-skills-dotnet). This version was created to provide greater feature parity with the NodeJS and Java versions of the SDK.


## Package Versions
| Package       | Nuget         | Build         |
| ------------- | ------------- | ------------- |
|[Ask.Sdk](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/src/Ask.Sdk)|[![NuGet Badge](https://buildstats.info/nuget/ask.sdk)](https://www.nuget.org/packages/Ask.Sdk/)|[![Build Status](https://ncipollina.visualstudio.com/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_apis/build/status/Ask.Sdk-CI)](https://ncipollina.visualstudio.com/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_build/latest?definitionId=9)|
|[Ask.Sdk.Asp.Net.Core](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/src/Ask.Sdk.Asp.Net.Core)|[![NuGet Badge](https://buildstats.info/nuget/ask.sdk.asp.net.core)](https://www.nuget.org/packages/Ask.Sdk.Asp.Net.Core/)|[![Build Status](https://ncipollina.visualstudio.com/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_apis/build/status/Ask.Sdk.Asp.Net.Core-CI)](https://ncipollina.visualstudio.com/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_build/latest?definitionId=7)|
|[Ask.Sdk.Core](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/src/Ask.Sdk.Core)|[![NuGet Badge](https://buildstats.info/nuget/ask.sdk.core)](https://www.nuget.org/packages/Ask.Sdk.Core/)|[![Build Status](https://dev.azure.com/captechconsulting/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_apis/build/status/Ask.Sdk.Core-CI)](https://dev.azure.com/captechconsulting/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_build/latest?definitionId=1)|
|[Ask.Sdk.Runtime](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/src/Ask.Sdk.Runtime)|[![NuGet Badge](https://buildstats.info/nuget/ask.sdk.runtime)](https://www.nuget.org/packages/Ask.Sdk.Runtime/)|[![Build Status](https://dev.azure.com/captechconsulting/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_apis/build/status/Ask.Sdk.Runtime-CI)](https://dev.azure.com/captechconsulting/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_build/latest?definitionId=2)|
|[Ask.Sdk.Model](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/src/Ask.Sdk.Model)|[![NuGet Badge](https://buildstats.info/nuget/ask.sdk.model)](https://www.nuget.org/packages/Ask.Sdk.Model/)|[![Build Status](https://ncipollina.visualstudio.com/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_apis/build/status/Ask.Sdk.Model-CI)](https://ncipollina.visualstudio.com/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_build/latest?definitionId=5)|
|[Ask.Sdk.CosmosDb.Persistence.Adapter](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/src/Ask.Sdk.CosmosDb.Persistence.Adapter)|[![NuGet Badge](https://buildstats.info/nuget/ask.sdk.cosmosdb.persistence.adapter)](https://www.nuget.org/packages/Ask.Sdk.CosmosDb.Persistence.Adapter/)|[![Build Status](https://ncipollina.visualstudio.com/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_apis/build/status/Ask.Sdk.CosmosDb.Persistence.Adapter-CI)](https://ncipollina.visualstudio.com/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_build/latest?definitionId=6)|
|[Ask.Sdk.DynamoDb.Persistence.Adapter](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/src/Ask.Sdk.DynamoDb.Persistence.Adapter)|[![NuGet Badge](https://buildstats.info/nuget/ask.sdk.dynamodb.persistence.adapter)](https://www.nuget.org/packages/Ask.Sdk.DynamoDb.Persistence.Adapter/)|[![Build Status](https://ncipollina.visualstudio.com/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_apis/build/status/Ask.Sdk.DynamoDb.Persistence.Adapter-CI)](https://ncipollina.visualstudio.com/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_build/latest?definitionId=8)|
|[Ask.Sdk.Azure.WebJobs](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/src/Ask.Sdk.Azure.WebJobs)|[![NuGet Badge](https://buildstats.info/nuget/ask.sdk.azure.webjobs)](https://www.nuget.org/packages/Ask.Sdk.Azure.WebJobs/)|[![Build Status](https://ncipollina.visualstudio.com/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_apis/build/status/Ask.Sdk.Azure.WebJobs-CI)](https://ncipollina.visualstudio.com/Alexa%20Skills%20Kit%20SDK%20.Net%20Core/_build/latest?definitionId=9)|

## Samples

### [Hello World Lambda](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/samples/HelloWorldLambda)
Sample that familiarizes you with the Alexa Skills Kit and AWS Lambda by allowing you to hear a response from Alexa when you trigger the sample.

### [Device Address Lambda](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/samples/DeviceAddressLambda)
Sample that demonstrates the Device Address API to retrieve user location information as well as requesting permissions from a user.

### [Hello World Web](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/samples/HelloWorldWeb)
Sample that familiarizes you with the Alexa Skills Kit and ASP.Net Core by allowing you to hear a response from Alexa when you trigger the sample.

### [DynamoDB Persistence](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/samples/DynamoDbLambda)
Sample that demostrates using DynamoDB as a persistent store for an Alexa Skill.

### [Fact Lambda](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/samples/FactLambda)
Template for a basic fact skill. You’ll provide a list of interesting facts about a topic, Alexa will select a fact at random and tell it to the user when the skill is invoked.

### [Progressive Response Lambda](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/samples/ProgressiveResponseLambda)
Sample that demonstrates the Directive API to provide progressive responses for the user.

### [Customer Settings Lambda](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/samples/CustomerSettingsLambda)
Sample that demonstrates the Alexa Settings API to provide customer settings for the user.

### [Hello World Function](https://github.com/captechconsulting/alexa-skills-kit-sdk-for-dotnet/tree/master/samples/HelloWorldFunction)
Sample that familiarizes you with the Alexa Skills Kit and Azure Functions by allowing you to hear a response from Alexa when you trigger the sample.
