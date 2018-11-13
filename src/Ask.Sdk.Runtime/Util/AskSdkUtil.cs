using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Runtime.Util
{
    public static class AskSdkUtil
    {
        public static string CreateAskSdkUserAgent(string packageVersion, string customUserAgent)
        {
            var customUserAgentString = !string.IsNullOrEmpty(customUserAgent) ? $" {customUserAgent}" : "";

            return $"ask-dotnet/{packageVersion} .Net/{Environment.Version}{customUserAgentString}";
        }
    }
}
