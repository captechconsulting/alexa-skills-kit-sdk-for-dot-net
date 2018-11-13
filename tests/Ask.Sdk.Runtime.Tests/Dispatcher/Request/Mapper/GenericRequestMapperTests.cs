using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using Ask.Sdk.Runtime.Dispatcher.Request.Mapper;
using Ask.Sdk.Runtime.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ask.Sdk.Runtime.Tests.Dispatcher.Request.Mapper
{
    public class GenericRequestMapperTests : IClassFixture<RequestHandlerChainFixture>
    {
        private readonly RequestHandlerChainFixture _fixture;

        public GenericRequestMapperTests(RequestHandlerChainFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Get_Request_Handler_That_Can_Handle_The_Input()
        {
            var type = _fixture.AlwaysTrueRequestHandler.GetType();
            var mapper = new GenericRequestMapper<string, string>(new List<GenericRequestHandlerChain<string, string>>
            {
                _fixture.AlwaysTrueRequestHandlerChain,
                _fixture.AlwaysFalseRequestHandlerChain
            });

            var handlerChain = await mapper.GetRequestHandlerChain(null);

            Assert.IsType(type, handlerChain.GetRequestHandler());
        }

        [Fact]
        public async Task Return_Null_If_No_Request_Handler_Can_Handle_The_Input()
        {
            var mapper = new GenericRequestMapper<string, string>(new List<GenericRequestHandlerChain<string, string>>
            {
                _fixture.AlwaysFalseRequestHandlerChain
            });

            var handlerChain = await mapper.GetRequestHandlerChain(null);

            Assert.Null(handlerChain);
        }
    }
}
