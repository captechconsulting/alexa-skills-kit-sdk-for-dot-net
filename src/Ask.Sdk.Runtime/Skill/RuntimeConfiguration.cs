using Ask.Sdk.Runtime.Dispatcher.Error.Mapper;
using Ask.Sdk.Runtime.Dispatcher.Request.Handler;
using Ask.Sdk.Runtime.Dispatcher.Request.Interceptor;
using Ask.Sdk.Runtime.Dispatcher.Request.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Runtime.Skill
{
    public class RuntimeConfiguration<TInput, TOutput>
    {
        public IEnumerable<IRequestMapper<TInput, TOutput>> RequestMappers { get; set; }
        public IEnumerable<IHandlerAdapter<TInput, TOutput>> HandlerAdapters { get; set; }
        public IErrorMapper<TInput, TOutput> ErrorMapper { get; set; }
        public IEnumerable<IRequestInterceptor<TInput>> RequestInterceptors { get; set; }
        public IEnumerable<IResponseInterceptor<TInput, TOutput>> ResponseInterceptors { get; set; }
    }
}
