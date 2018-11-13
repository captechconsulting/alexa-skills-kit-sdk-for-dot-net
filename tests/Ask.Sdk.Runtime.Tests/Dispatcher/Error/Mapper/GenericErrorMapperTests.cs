using Ask.Sdk.Runtime.Dispatcher.Error.Handler;
using Ask.Sdk.Runtime.Dispatcher.Error.Mapper;
using Ask.Sdk.Runtime.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ask.Sdk.Runtime.Tests.Dispatcher.Error.Mapper
{
    public class GenericErrorMapperTests : IClassFixture<RuntimeFixture>
    {
        private readonly RuntimeFixture _fixture;

        public GenericErrorMapperTests(RuntimeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Get_Error_Handler_To_Handle_Error()
        {
            var type = _fixture.AlwaysTrueErrorHandler.GetType();
            var mapper = new GenericErrorMapper<string, string>(new List<IErrorHandler<string, string>>
            {
                _fixture.AlwaysTrueErrorHandler,
                _fixture.AlwaysFalseErrorHandler
            });

            var handler = await mapper.GetErrorHandler(null, new Exception("Test Error"));

            Assert.IsType(type, handler);
        }

        [Fact]
        public async Task Return_Null_If_No_Error_Handler_Found()
        {
            var mapper = new GenericErrorMapper<string, string>(new List<IErrorHandler<string, string>>
            {
                _fixture.AlwaysFalseErrorHandler
            });

            var handler = await mapper.GetErrorHandler(null, new Exception("Test Error"));

            Assert.Null(handler);
        }
    }
}
