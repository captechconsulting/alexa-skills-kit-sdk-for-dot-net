using Ask.Sdk.Runtime.Dispatcher;
using Ask.Sdk.Runtime.Dispatcher.Error.Handler;
using Ask.Sdk.Runtime.Dispatcher.Error.Mapper;
using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using Ask.Sdk.Runtime.Dispatcher.Request.Interceptor;
using Ask.Sdk.Runtime.Dispatcher.Request.Mapper;
using Ask.Sdk.Runtime.Skill;
using Ask.Sdk.Runtime.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ask.Sdk.Runtime.Tests.Dispatcher
{
    public class GenericRequestDispatcherTests : IClassFixture<RequestHandlerChainFixture>
    {
        private readonly RequestHandlerChainFixture _fixture;

        public GenericRequestDispatcherTests(RequestHandlerChainFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Send_Input_To_Correct_Request_Handler()
        {
            var dispatcher = new GenericRequestDispatcher<string, string>(new RuntimeConfiguration<string, string>
            {
                RequestMappers = new List<GenericRequestMapper<string, string>>
                {
                    new GenericRequestMapper<string, string>(new [] {_fixture.AlwaysTrueRequestHandlerChain,
                        _fixture.AlwaysFalseRequestHandlerChain})
                },
                HandlerAdapters = new List<GenericHandlerAdapter<string, string>>
                {
                    new GenericHandlerAdapter<string, string>()
                }
            });

            var response = await dispatcher.Dispatch("Test Request");

            Assert.Equal($"Input (Test Request) received.", response);
        }

        [Fact]
        public async Task Send_Input_To_Interceptors_And_Handler_In_Correct_Order()
        {
            var handler = new FunctionRequestHandler<StringBuilder, StringBuilder>((input) =>
            {
                input.Append("_handlerMatcher_");
                return Task.FromResult(true);
            }, (input) =>
            {
                input.Append("_handlerExecutor_");
                return Task.FromResult(input);
            });

            var firstGlobalRequestInterceptor = new FunctionInterceptor<StringBuilder, StringBuilder>((input) =>
            {
                input.Append("_firstGlobalRequestInterceptor_");
                return Task.CompletedTask;
            });

            var secondGlobalRequestInterceptor = new FunctionInterceptor<StringBuilder, StringBuilder>((input) =>
            {
                input.Append("_secondGlobalRequestInterceptor_");
                return Task.CompletedTask;
            });

            var firstLocalRequestInterceptor = new FunctionInterceptor<StringBuilder, StringBuilder>((input) =>
            {
                input.Append("_firstLocalRequestInterceptor_");
                return Task.CompletedTask;
            });

            var secondLocalRequestInterceptor = new FunctionInterceptor<StringBuilder, StringBuilder>((input) =>
            {
                input.Append("_secondLocalRequestInterceptor_");
                return Task.CompletedTask;
            });

            var firstGlobalResponseInterceptor = new FunctionInterceptor<StringBuilder, StringBuilder>(responseProcess: (input, output) =>
            {
                input.Append("_firstGlobalResponseInterceptor_");
                return Task.CompletedTask;
            });

            var secondGlobalResponseInterceptor = new FunctionInterceptor<StringBuilder, StringBuilder>(responseProcess: (input, output) =>
            {
                input.Append("_secondGlobalResponseInterceptor_");
                return Task.CompletedTask;
            });

            var firstLocalResponseInterceptor = new FunctionInterceptor<StringBuilder, StringBuilder>(responseProcess: (input, output) =>
            {
                input.Append("_firstLocalResponseInterceptor_");
                return Task.CompletedTask;
            });

            var secondLocalResponseInterceptor = new FunctionInterceptor<StringBuilder, StringBuilder>(responseProcess: (input, output) =>
            {
                input.Append("_secondLocalResponseInterceptor_");
                return Task.CompletedTask;
            });

            var dispatcher = new GenericRequestDispatcher<StringBuilder, StringBuilder>(new RuntimeConfiguration<StringBuilder, StringBuilder>
            {
                RequestMappers = new List<GenericRequestMapper<StringBuilder, StringBuilder>>
                {
                    new GenericRequestMapper<StringBuilder, StringBuilder>(new List<GenericRequestHandlerChain<StringBuilder, StringBuilder>>
                    {
                        new GenericRequestHandlerChain<StringBuilder, StringBuilder>(handler, new List<IRequestInterceptor<StringBuilder>>{
                            firstLocalRequestInterceptor,
                            secondLocalRequestInterceptor
                        }, new List<IResponseInterceptor<StringBuilder, StringBuilder>>{
                            firstLocalResponseInterceptor,
                            secondLocalResponseInterceptor
                        })
                    })
                },
                HandlerAdapters = new List<GenericHandlerAdapter<StringBuilder, StringBuilder>>
                {
                    new GenericHandlerAdapter<StringBuilder, StringBuilder>()
                },
                RequestInterceptors = new List<IRequestInterceptor<StringBuilder>>
                {
                    firstGlobalRequestInterceptor,
                    secondGlobalRequestInterceptor
                },
                ResponseInterceptors = new List<IResponseInterceptor<StringBuilder, StringBuilder>>
                {
                    firstGlobalResponseInterceptor,
                    secondGlobalResponseInterceptor
                }
            });

            var response = await dispatcher.Dispatch(new StringBuilder());

            Assert.Equal("_firstGlobalRequestInterceptor__secondGlobalRequestInterceptor__handlerMatcher__firstLocalRequestInterceptor__secondLocalRequestInterceptor__handlerExecutor__firstLocalResponseInterceptor__secondLocalResponseInterceptor__firstGlobalResponseInterceptor__secondGlobalResponseInterceptor_", response.ToString());
        }

        [Fact]
        public async Task Send_Input_And_Error_To_Correct_Error_Handler()
        {
            var dispatcher = new GenericRequestDispatcher<string, string>(new RuntimeConfiguration<string, string>
            {
                RequestMappers = new List<GenericRequestMapper<string, string>>
                {
                    new GenericRequestMapper<string, string>(new [] {_fixture.AlwaysFalseRequestHandlerChain})
                },
                HandlerAdapters = new List<GenericHandlerAdapter<string, string>>
                {
                    new GenericHandlerAdapter<string, string>()
                },
                ErrorMapper = new GenericErrorMapper<string, string>(new List<IErrorHandler<string, string>>{
                    _fixture.AlwaysTrueErrorHandler,
                    _fixture.AlwaysFalseErrorHandler
                })
            });

            var response = await dispatcher.Dispatch("Test Request");

            Assert.Equal("NotImplementedException received", response);
        }

        [Fact]
        public async Task Throw_Exception_If_No_Request_Handler_Chain_Found()
        {
            var dispatcher = new GenericRequestDispatcher<string, string>(new RuntimeConfiguration<string, string>
            {
                RequestMappers = new List<GenericRequestMapper<string, string>>
                {
                    new GenericRequestMapper<string, string>(new [] {_fixture.AlwaysFalseRequestHandlerChain})
                },
                HandlerAdapters = new List<GenericHandlerAdapter<string, string>>
                {
                    new GenericHandlerAdapter<string, string>()
                }
            });

            await Assert.ThrowsAsync<NotImplementedException>(() => dispatcher.Dispatch("Test Request"));

        }

        [Fact]
        public async Task Rethrow_Exception_If_No_Error_Handler_Is_Found_To_Handle_Error()
        {
            var dispatcher = new GenericRequestDispatcher<string, string>(new RuntimeConfiguration<string, string>
            {
                RequestMappers = new List<GenericRequestMapper<string, string>>
                {
                    new GenericRequestMapper<string, string>(new [] {_fixture.AlwaysFalseRequestHandlerChain})
                },
                HandlerAdapters = new List<GenericHandlerAdapter<string, string>>
                {
                    new GenericHandlerAdapter<string, string>()
                },
                ErrorMapper = new GenericErrorMapper<string, string>(new List<IErrorHandler<string, string>>{
                    _fixture.AlwaysFalseErrorHandler
                })
            });

            await Assert.ThrowsAsync<NotImplementedException>(() => dispatcher.Dispatch("Test Request"));
        }
    }
}
