using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using Ask.Sdk.Runtime.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ask.Sdk.Runtime.Tests.Dispatcher.Request.Handler
{
    public class GenericRequestHandlerChainTests : IClassFixture<RuntimeFixture>
    {
        private readonly RuntimeFixture _fixture;

        public GenericRequestHandlerChainTests(RuntimeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Get_Request_Handler()
        {
            var type = _fixture.AlwaysTrueRequestHandler.GetType();
            var handlerChain = new GenericRequestHandlerChain<string, string>(_fixture.AlwaysTrueRequestHandler);

            Assert.IsType(type, handlerChain.GetRequestHandler());
        }
    }
}
