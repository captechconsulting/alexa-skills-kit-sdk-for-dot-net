using System;

namespace Ask.Sdk.Model.Service {
    public class ServiceException: Exception {
        public int StatusCode { get; }

        public ServiceException() {}
        public ServiceException(string message, int statusCode): base(message) {
            StatusCode = statusCode;
        }
        public ServiceException(string message): base(message) {}
        public ServiceException(string message, Exception inner): base(message, inner) {}

    }
}