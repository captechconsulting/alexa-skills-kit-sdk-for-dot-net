using Ask.Sdk.Core.Dispatcher.Error;
using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Core.Dispatcher.Request.Interceptor;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ask.Sdk.Azure.WebJobs.Tests
{
    public class AlexaSkillAttributeTests
    {
        [Fact]
        public void Should_Have_Skill_Id()
        {
            var attribute = new AlexaSkillAttribute()
            {
                SkillId = "SkillId"
            };

            Assert.Equal("SkillId", attribute.SkillId);
        }

        [Fact]
        public void Should_Have_Request_Handlers()
        {
            var attribute = new AlexaSkillAttribute
            {
                RequestHandlers = new[] { typeof(ICustomSkillRequestHandler) }
            };

            Assert.NotEmpty(attribute.RequestHandlers);
        }

        [Fact]
        public void Should_Have_Request_Interceptors()
        {
            var attribute = new AlexaSkillAttribute
            {
                RequestInterceptors = new[] { typeof(ICustomSkillRequestInterceptor) }
            };

            Assert.NotEmpty(attribute.RequestInterceptors);
        }

        [Fact]
        public void Should_Have_Response_Interceptors()
        {
            var attribute = new AlexaSkillAttribute
            {
                ResponseInterceptors = new[] { typeof(ICustomSkillResponseInterceptor) }
            };

            Assert.NotEmpty(attribute.ResponseInterceptors);
        }

        [Fact]
        public void Should_Have_Error_Handlers()
        {
            var attribute = new AlexaSkillAttribute
            {
                ErrorHandlers = new[] { typeof(ICustomSkillErrorHandler) }
            };

            Assert.NotEmpty(attribute.ErrorHandlers);
        }
    }
}
