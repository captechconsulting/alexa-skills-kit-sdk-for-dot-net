﻿using Ask.Sdk.Model.Request;
using Ask.Sdk.Model.Request.Type;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Ask.Sdk.Model.Tests
{
    public class RequestTests
    {
        private const string ExamplesPath = "Examples";
        private const string IntentRequestFile = "IntentRequest.json";

        [Fact]
        public void Can_Convert_As_Object()
        {
            var expected = File.ReadAllText(Path.Combine(ExamplesPath, IntentRequestFile));
            using (var reader = new StringReader(expected))
            {
                var serializer = JsonSerializer.CreateDefault();
                var reqeust = serializer.Deserialize(reader, typeof(object)) as RequestEnvelope;
            }
        }

        [Fact]
        public void Can_read_IntentRequest_example()
        {
            var convertedObj = Utility.ExampleFileContent<RequestEnvelope>(IntentRequestFile);

            Assert.NotNull(convertedObj);
            Assert.Equal(typeof(IntentRequest), convertedObj.GetRequestType());
        }

        [Fact]
        public void IntentRequest_Generates_Correct_Name_and_Signature()
        {
            var convertedObj = Utility.ExampleFileContent<RequestEnvelope>(IntentRequestFile);
            var intent = ((IntentRequest)convertedObj.Request).Intent;
            Assert.Equal("GetZodiacHoroscopeIntent", intent.Name);
            Assert.Equal("GetZodiacHoroscopeIntent", intent.Signature);
            Assert.Equal("GetZodiacHoroscopeIntent", intent.Signature.Action);
        }

        [Fact]
        public void BuiltInRequest_Generates_Correct_Signature()
        {
            //Multiple asserts as the IntentSignature state is a single output that should be treated as an immutable object - either all right or wrong.
            //AMAZON.AddAction<object@Book,targetCollection@ReadingList>
            var convertedObj = Utility.ExampleFileContent<RequestEnvelope>("BuiltInIntentRequest.json");
            var signature = ((IntentRequest)convertedObj.Request).Intent.Signature;
            Assert.Equal("AddAction", signature.Action);
            Assert.Equal("AMAZON", signature.Namespace);
            Assert.Equal(2, signature.Properties.Count);

            var first = signature.Properties.First();
            var second = signature.Properties.Skip(1).First();

            Assert.Equal("object", first.Key);
            Assert.Equal("Book", first.Value.Entity);
            Assert.True(string.IsNullOrWhiteSpace(first.Value.Property));

            Assert.Equal("targetCollection", second.Key);
            Assert.Equal("ReadingList", second.Value.Entity);
            Assert.True(string.IsNullOrWhiteSpace(first.Value.Property));
        }

        [Fact]
        public void Can_read_LaunchRequest_example()
        {
            var convertedObj = Utility.ExampleFileContent<RequestEnvelope>("LaunchRequest.json");

            Assert.NotNull(convertedObj);
            Assert.Equal(typeof(LaunchRequest), convertedObj.GetRequestType());
        }

        [Fact]
        public void Can_read_LaunchRequestWithEpochTimestamp_example()
        {
            var convertedObj = Utility.ExampleFileContent<RequestEnvelope>("LaunchRequestWithEpochTimestamp.json");

            Assert.NotNull(convertedObj);
            Assert.Equal(typeof(LaunchRequest), convertedObj.GetRequestType());
        }

        [Fact]
        public void Can_read_SessionEndedRequest_example()
        {
            var convertedObj = Utility.ExampleFileContent<RequestEnvelope>("SessionEndedRequest.json");

            Assert.NotNull(convertedObj);
            Assert.Equal(typeof(SessionEndedRequest), convertedObj.GetRequestType());
        }

        [Fact]
        public void Can_read_slot_example()
        {
            var convertedObj = Utility.ExampleFileContent<RequestEnvelope>("GetUtterance.json");

            var request = Assert.IsAssignableFrom<IntentRequest>(convertedObj.Request);
            var slot = request.Intent.Slots["Utterance"];
            Assert.Equal("how are you", slot.Value);
        }

        [Fact]
        public void Can_accept_new_versions()
        {
            var convertedObj = Utility.ExampleFileContent<RequestEnvelope>("SessionEndedRequest.json");

            Assert.NotNull(convertedObj);
            Assert.Equal(typeof(SessionEndedRequest), convertedObj.GetRequestType());
        }

        [Fact]
        public void Can_read_resolution()
        {
            var actual = new Resolutions
            {
                ResolutionsPerAuthority = new[]{
                    new Resolution{
                        Name="amzn1.er-authority.echo-sdk.<skill_id>.MEDIA_TYPE",
                        Status=new ResolutionStatus{Code=StatusCode.SuccessfulMatch},
                        Values=new []{
                            new ValueWrapper{Value=
                                new Value{Name="song",Id="SONG"}
                            }
                        }
                    }
                }
            };

            Assert.True(Utility.CompareJson(actual, "Resolution.json"));
        }

        [Fact]
        public void Can_read_intent_with_entity_resolution()
        {
            var intentRequest = Utility.ExampleFileContent<IntentRequest>("IntentWithResolution.json");
            var mediaTypeSlot = intentRequest.Intent.Slots["MediaType"];
            var mediaTitleSlot = intentRequest.Intent.Slots["MediaTitle"];

            var mediaTypeResolutionAuthority = new Resolutions
            {
                ResolutionsPerAuthority = new[]{
                    new Resolution{
                        Name="amzn1.er-authority.echo-sdk.<skill_id>.MEDIA_TYPE",
                        Status = new ResolutionStatus{Code=StatusCode.SuccessfulMatch},
                        Values= new[]{
                            new ValueWrapper{Value = new Value{
                                    Name="song",
                                    Id="SONG"
                                }
                            }
                    }
                }
                }
            };

            var mediaTitleResolutionAuthority = new Resolutions
            {
                ResolutionsPerAuthority = new[]{
                    new Resolution{
                        Name="amzn1.er-authority.echo-sdk.<skill_id>.MEDIA_TITLE",
                        Status = new ResolutionStatus{Code=StatusCode.SuccessfulMatch},
                        Values= new[]{
                            new ValueWrapper{Value = new Value{
                                    Name="Rolling in the Deep",
                                    Id="song_id_456"
                                }
                            }
                    }
                }
                }
            };
                       
            Assert.True(Utility.CompareObjectJson(mediaTypeSlot.Resolutions, mediaTypeResolutionAuthority));
            Assert.True(Utility.CompareObjectJson(mediaTitleSlot.Resolutions, mediaTitleResolutionAuthority));
        }

        [Fact]
        public void Can_Read_SkillEventAccountLink()
        {
            var convertedObj = Utility.ExampleFileContent<RequestEnvelope>("SkillEventAccountLink.json");
            var request = Assert.IsAssignableFrom<AccountLinkSkillEventRequest>(convertedObj.Request);
            Assert.Equal("testToken", request.Body.AccessToken);
        }

        [Fact]
        public void Can_Read_SkillEventPermissionChange()
        {
            var convertedObj = Utility.ExampleFileContent<RequestEnvelope>("SkillEventPermissionChange.json");
            var request = Assert.IsAssignableFrom<PermissionSkillEventRequest>(convertedObj.Request);
            Assert.Equal("testScope", request.Body.AcceptedPermissions.First().Scope);
        }

        [Fact]
        public void Can_Read_NonSpecialisedSkillEvent()
        {
            var convertedObj = Utility.ExampleFileContent<RequestEnvelope>("SkillEventEnabled.json");
            var request = Assert.IsAssignableFrom<SkillEventRequest>(convertedObj.Request);
        }

        [Fact]
        public void DialogState_appears_in_IntentRequest()
        {
            var request = Utility.ExampleFileContent<RequestEnvelope>(IntentRequestFile);

            var actual = (IntentRequest)request.Request;


            Assert.Equal(DialogState.InProgress, actual.DialogState);
        }

        [Fact]
        public void ConfirmationState_appears_in_Intent()
        {
            var request = Utility.ExampleFileContent<RequestEnvelope>(IntentRequestFile);
            var intentRequest = (IntentRequest)request.Request;
            var expected = intentRequest.Intent;


            Assert.Equal(IntentConfirmationStatus.Denied, expected.ConfirmationStatus);
        }

        [Fact]
        public void ConfirmationState_appears_in_Slot()
        {
            var request = Utility.ExampleFileContent<RequestEnvelope>(IntentRequestFile);
            var intentRequest = (IntentRequest)request.Request;
            var expected = intentRequest.Intent.Slots["Date"];


            Assert.Equal(IntentConfirmationStatus.Confirmed, expected.ConfirmationStatus);
        }

        [Fact]
        public void Can_Handle_New_Intent()
        {
            if (!RequestConverter.RequestConverters.Any(c => c is NewIntentRequestTypeConverter))
            {
                RequestConverter.RequestConverters.Add(new NewIntentRequestTypeConverter());
            }

            var request = Utility.ExampleFileContent<RequestEnvelope>("NewIntent.json");
            Assert.IsType<NewIntentRequest>(request.Request);
            Assert.True(((NewIntentRequest)request.Request).TestProperty);
        }

        [Fact]
        public void New_Request_Timestamp_validated_By_RequestVerification()
        {
            var request = new RequestEnvelope
            {
                Request = new LaunchRequest { Timestamp = DateTime.Now.AddMinutes(1) }
            };
            Assert.True(RequestVerification.RequestTimestampWithinTolerance(request));
        }

        [Fact]
        public void Replay_Attack_Timestamp_Invalidated_By_RequestVerification()
        {
            var request = new RequestEnvelope
            {
                Request = new LaunchRequest { Timestamp = DateTime.Now.AddMinutes(3) }
            };
            Assert.False(RequestVerification.RequestTimestampWithinTolerance(request));
        }
    }
}