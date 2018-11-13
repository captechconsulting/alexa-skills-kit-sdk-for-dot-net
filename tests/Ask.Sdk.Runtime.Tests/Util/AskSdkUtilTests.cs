using Ask.Sdk.Runtime.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ask.Sdk.Runtime.Tests.Util
{
    public class AskSdkUtilTests
    {
        [Fact]
        public void Create_User_Agent_String()
        {
            var userAgent = AskSdkUtil.CreateAskSdkUserAgent("2.0.0", string.Empty);

            Assert.Equal($"ask-dotnet/2.0.0 .Net/{Environment.Version}", userAgent);
        }

        [Fact]
        public void Create_User_Agent_String_With_Custom_Agent()
        {
            var userAgent = AskSdkUtil.CreateAskSdkUserAgent("2.0.0", "custom user agent");

            Assert.Equal($"ask-dotnet/2.0.0 .Net/{Environment.Version} custom user agent", userAgent);
        }
    }
}
