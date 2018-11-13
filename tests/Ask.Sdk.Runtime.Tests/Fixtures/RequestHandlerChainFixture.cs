using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Runtime.Tests.Fixtures
{
    public class RequestHandlerChainFixture : RuntimeFixture
    {
        public GenericRequestHandlerChain<string, string> AlwaysTrueRequestHandlerChain { get; private set; }
        public GenericRequestHandlerChain<string, string> AlwaysFalseRequestHandlerChain { get; private set; }

        public RequestHandlerChainFixture() : base()
        {
            AlwaysTrueRequestHandlerChain = new GenericRequestHandlerChain<string, string>(AlwaysTrueRequestHandler);
            AlwaysFalseRequestHandlerChain = new GenericRequestHandlerChain<string, string>(AlwaysFalseRequestHandler);
        }

        public override void Dispose()
        {
            base.Dispose();

            AlwaysTrueRequestHandlerChain = null;
            AlwaysFalseRequestHandlerChain = null;
        }
    }
}
