using Ask.Sdk.Runtime.Dispatcher.Error.Handler;
using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using Ask.Sdk.Runtime.Dispatcher.Request.Interceptor;
using Ask.Sdk.Runtime.Skill;
using Ask.Sdk.Runtime.Tests.Fixtures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ask.Sdk.Runtime.Tests.Skill
{
    public class RuntimeConfigurationBuilderTests : IClassFixture<RuntimeFixture>
    {
        private readonly RuntimeFixture _fixture;

        public RuntimeConfigurationBuilderTests(RuntimeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Add_Single_Request_Handle_Using_Matcher_And_Executor()
        {
            var runtimeConfiguration = new RuntimeConfigurationBuilder<string, string>()
                .AddRequestHandler((input) =>
                {
                    return Task.FromResult(input == "Test Request");
                },
                (input) =>
                {
                    return Task.FromResult("Event Received");
                })
                .GetRuntimeConfiguration();

            var requestMapper = runtimeConfiguration.RequestMappers.ToArray()[0];
            var requestHandlerChain = await requestMapper.GetRequestHandlerChain("Test Request");
            var requestHandler = requestHandlerChain.GetRequestHandler();

            Assert.Equal("Event Received", await requestHandler.Handle(""));
        }

        [Fact]
        public async Task Add_Multiple_Request_Handlers()
        {
            var trueRequestHandler = _fixture.AlwaysTrueRequestHandler;
            var falseRequestHandler = _fixture.AlwaysFalseRequestHandler;

            var runtimeConfiguration = new RuntimeConfigurationBuilder<string, string>()
                .AddRequestHandlers(trueRequestHandler,
                falseRequestHandler)
                .GetRuntimeConfiguration();

            var requestMapper = runtimeConfiguration.RequestMappers.ToArray()[0];
            var requestHandlerChain = await requestMapper.GetRequestHandlerChain("Test Request");
            var requestHandler = requestHandlerChain.GetRequestHandler();

            Assert.Equal($"Input (Test request) received.", await requestHandler.Handle("Test request"));
        }

        [Fact]
        public async Task Add_Multiple_Request_Interceptors_As_Object_Or_Function()
        {
            var trueRequestHandler = _fixture.AlwaysTrueRequestHandler;
            var falseRequestHandler = _fixture.AlwaysFalseRequestHandler;

            var requestInterceptor = new Mock<IRequestInterceptor<string>>();
            requestInterceptor.Setup(i => i.Process(It.IsAny<string>()))
                .Returns((string input) =>
                {
                    Assert.Equal("Test Request?", input);
                    return Task.CompletedTask;
                });

            var runtimeConfiguration = new RuntimeConfigurationBuilder<string, string>()
                .AddRequestHandlers(trueRequestHandler,
                falseRequestHandler)
                .AddRequestInterceptors((input) =>
                {
                    Assert.Equal("Test Request", input);
                    return Task.CompletedTask;
                })
                .AddRequestInterceptors(requestInterceptor.Object)
                .GetRuntimeConfiguration();

            var requestMapper = runtimeConfiguration.RequestMappers.ToArray()[0];
            var requestHandlerChain = await requestMapper.GetRequestHandlerChain("Test Request");
            var requestHandler = requestHandlerChain.GetRequestHandler();

            Assert.Equal($"Input (Test request) received.", await requestHandler.Handle("Test request"));
            Assert.Equal(2, runtimeConfiguration.RequestInterceptors.Count());
        }

        [Fact]
        public async Task Add_Multiple_Response_Interceptors_As_Object_Or_Function()
        {
            var trueRequestHandler = _fixture.AlwaysTrueRequestHandler;
            var falseRequestHandler = _fixture.AlwaysFalseRequestHandler;

            var responseInterceptor = new Mock<IResponseInterceptor<string, string>>();
            responseInterceptor.Setup(i => i.Process(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string input, string output) =>
                {
                    Assert.Equal("Test Request?", input);
                    return Task.CompletedTask;
                });

            var runtimeConfiguration = new RuntimeConfigurationBuilder<string, string>()
                .AddRequestHandlers(trueRequestHandler,
                falseRequestHandler)
                .AddResponseInterceptors((input, output) =>
                {
                    Assert.Equal("Test Request", input);
                    return Task.CompletedTask;
                })
                .AddResponseInterceptors(responseInterceptor.Object)
                .GetRuntimeConfiguration();

            var requestMapper = runtimeConfiguration.RequestMappers.ToArray()[0];
            var requestHandlerChain = await requestMapper.GetRequestHandlerChain("Test Request");
            var requestHandler = requestHandlerChain.GetRequestHandler();

            Assert.Equal($"Input (Test request) received.", await requestHandler.Handle("Test request"));
            Assert.Equal(2, runtimeConfiguration.ResponseInterceptors.Count());
        }

        [Fact]
        public async Task Add_Single_Error_Handler_Using_Matcher_And_Executor()
        {
            var runtimeConfiguration = new RuntimeConfigurationBuilder<string, string>()
                .AddErrorHandler((input, error) => Task.FromResult(input == "Test Request" && error.Message == "Test Error"),
                (input, error) => Task.FromResult("Error received"))
                .GetRuntimeConfiguration();

            var errorHandler = await runtimeConfiguration.ErrorMapper.GetErrorHandler("Test Request", new Exception("Test Error"));

            Assert.Equal("Error received", await errorHandler.Handle(null, null));
        }

        [Fact]
        public async Task Add_Multiple_Error_Handlers()
        {
            var trueErrorHandler = _fixture.AlwaysTrueErrorHandler;
            var falseErrorHandler = _fixture.AlwaysFalseErrorHandler;

            var runtimeConfiguration = new RuntimeConfigurationBuilder<string, string>()
                .AddErrorHandlers(trueErrorHandler, falseErrorHandler)
                .GetRuntimeConfiguration();

            var errorHandler = await runtimeConfiguration.ErrorMapper.GetErrorHandler("Test Request", new Exception("Test Error"));

            Assert.Equal("Exception received", await errorHandler.Handle("Test Request", new Exception("Test Error")));
        }

    }
}
