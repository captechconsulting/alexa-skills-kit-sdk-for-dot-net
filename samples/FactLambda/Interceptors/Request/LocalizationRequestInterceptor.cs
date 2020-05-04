using Ask.Sdk.Core.Dispatcher.Request.Handler;
using Ask.Sdk.Core.Dispatcher.Request.Interceptor;
using FactLambda.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactLambda.Interceptors.Request
{
    public class LocalizationRequestInterceptor : ICustomSkillRequestInterceptor
    {
        public Task Process(IHandlerInput input)
        {
            LanguageStrings.Culture = new System.Globalization.CultureInfo(input.RequestEnvelope.Request.Locale);

            return Task.CompletedTask;
        }
    }
}
