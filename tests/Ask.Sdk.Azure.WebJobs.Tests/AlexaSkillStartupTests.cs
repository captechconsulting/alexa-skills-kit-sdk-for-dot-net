using Ask.Sdk.Azure.WebJobs.Config;
using Microsoft.Azure.WebJobs;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ask.Sdk.Azure.WebJobs.Tests
{
    public class AlexaSkillStartupTests
    {
        [Fact]
        public void Should_Throw_Exception_If_No_Buildewr()
        {
            Assert.Throws<ArgumentNullException>(() => new AlexaSkillStartup().Configure(null));
        }

    }
}
