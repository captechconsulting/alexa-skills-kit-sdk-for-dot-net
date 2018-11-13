using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using Ask.Sdk.Runtime.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ask.Sdk.Runtime.Tests.Dispatcher.Request.Handler
{
    public class GenericHandlerAdapterTests : IClassFixture<RuntimeFixture>
    {
        private readonly RuntimeFixture _fixture;

        public GenericHandlerAdapterTests(RuntimeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Invoke_The_Execute_Function_On_Supported_Handler_Object()
        {
            var adapter = new GenericHandlerAdapter<string, string>();

            var response = await adapter.Execute("test", _fixture.AlwaysTrueRequestHandler);

            Assert.Equal("Input (test) received.", response);
        }
    }
}
