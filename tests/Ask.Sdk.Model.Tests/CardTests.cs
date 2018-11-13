using Ask.Sdk.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ask.Sdk.Model.Tests
{
    public class CardTests
    {
        private const string ExampleTitle = "Example Title";
        private const string ExampleBodyText = "Example Body Text";

        [Fact]
        public void Create_Valid_SimpleCard()
        {
            var actual = new SimpleCard() { Title = ExampleTitle, Content = ExampleBodyText };

            Assert.True(Utility.CompareJson(actual, "SimpleCard.json"));
        }

        [Fact]
        public void Creates_Valid_StandardCard()
        {
            var cardImages = new UiImage { SmallImageUrl = "https://example.com/smallImage.png", LargeImageUrl = "https://example.com/largeImage.png" };
            var actual = new StandardCard { Title = ExampleTitle, Content = ExampleBodyText, Image = cardImages };

            Assert.True(Utility.CompareJson(actual, "StandardCard.json"));
        }

        [Fact]
        public void Creates_Valid_AskForPermissionConsent()
        {
            var actual = new AskForPermissionsConsentCard();
            actual.Permissions.Add(RequestedPermission.ReadHouseholdList);

            Assert.True(Utility.CompareJson(actual, "AskForPermissionsConsent.json"));
        }
    }
}
