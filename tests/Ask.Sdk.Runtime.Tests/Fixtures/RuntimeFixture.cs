using Ask.Sdk.Runtime.Dispatcher.Error.Handler;
using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Tests.Fixtures
{
    public class RuntimeFixture : IDisposable
    {
        public IRequestHandler<string, string> AlwaysTrueRequestHandler { get; private set; }
        public IRequestHandler<string, string> AlwaysFalseRequestHandler { get; private set; }
        public IErrorHandler<string, string> AlwaysTrueErrorHandler { get; private set; }
        public IErrorHandler<string, string> AlwaysFalseErrorHandler { get; private set; }

        public RuntimeFixture()
        {
            AlwaysTrueRequestHandler = GetAlwaysTrueRequestHandler();
            AlwaysFalseRequestHandler = GetAlwaysFalseRequestHandler();
            AlwaysTrueErrorHandler = GetAlwaysTrueErrorHandler();
            AlwaysFalseErrorHandler = GetAlwaysFalseErrorHandler();
        }

        public virtual void Dispose()
        {
            AlwaysTrueRequestHandler = null;
            AlwaysFalseRequestHandler = null;
            AlwaysTrueErrorHandler = null;
            AlwaysFalseErrorHandler = null;
        }

        private IRequestHandler<string, string> GetAlwaysTrueRequestHandler()
        {
            var trueRequestHandler = new Mock<IRequestHandler<string, string>>();
            trueRequestHandler.Setup(h => h.CanHandle(It.IsAny<string>()))
                .Returns(Task.FromResult(true));
            trueRequestHandler.Setup(h => h.Handle(It.IsAny<string>()))
                .Returns((string input) => Task.FromResult($"Input ({input}) received."));

            return trueRequestHandler.Object;
        }


        private IRequestHandler<string, string> GetAlwaysFalseRequestHandler()
        {
            var falseRequestHandler = new Mock<IRequestHandler<string, string>>();
            falseRequestHandler.Setup(h => h.CanHandle(It.IsAny<string>()))
                .Returns(Task.FromResult(false));
            falseRequestHandler.Setup(h => h.Handle(It.IsAny<string>()))
                .Throws(new Exception("This method should never be called"));

            return falseRequestHandler.Object;
        }

        private IErrorHandler<string, string> GetAlwaysTrueErrorHandler()
        {
            var trueErrorHandler = new Mock<IErrorHandler<string, string>>();
            trueErrorHandler.Setup(e => e.CanHandle(It.IsAny<string>(), It.IsAny<Exception>()))
                .Returns((string input, Exception error) => Task.FromResult(true));
            trueErrorHandler.Setup(e => e.Handle(It.IsAny<string>(), It.IsAny<Exception>()))
                .Returns((string input, Exception err) => Task.FromResult($"{err.GetType().Name} received"));

            return trueErrorHandler.Object;
        }
        private IErrorHandler<string, string> GetAlwaysFalseErrorHandler()
        {
            var falseErrorHandler = new Mock<IErrorHandler<string, string>>();
            falseErrorHandler.Setup(e => e.CanHandle(It.IsAny<string>(), It.IsAny<Exception>()))
                .Returns((string input, Exception error) => Task.FromResult(false));
            falseErrorHandler.Setup(e => e.Handle(It.IsAny<string>(), It.IsAny<Exception>()))
                .Throws(new Exception("This method should never be called"));

            return falseErrorHandler.Object;
        }
    }
}
