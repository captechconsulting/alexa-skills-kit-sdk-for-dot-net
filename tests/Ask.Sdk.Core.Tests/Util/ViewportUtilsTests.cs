using Alexa.NET.APL;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Ask.Sdk.Core.Util;
using System;
using Xunit;

namespace Ask.Sdk.Core.Tests.Util
{
    public class ViewportUtilsTests : BaseTests
    {
        protected new APLSkillRequest Request { get; set; }

        public ViewportUtilsTests() : base()
        {
            Request = new APLSkillRequest
            {
                Context = new APLContext
                {
                    System = new AlexaSystem
                    {
                        Application = new Application(),
                        Device = new Device(),
                        User = new User()
                    }
                },
                Request = new LaunchRequest(),
                Session = new Session
                {
                    Application = new Application(),
                    New = true,
                    User = new User
                    {
                        Permissions = new Permissions()
                    }
                },
                Version = "1.0"
            };
        }

        [Theory]
        [InlineData(0, 1, ViewPortOrientation.PORTRAIT)]
        [InlineData(1, 1, ViewPortOrientation.EQUAL)]
        [InlineData(1, 0, ViewPortOrientation.LANDSCAPE)]
        public void Resolve_Viewport_Orientation(int width, int height, ViewPortOrientation expectedOrientation)
        {
            Assert.Equal(expectedOrientation, ViewportUtils.GetViewportOrientation(width, height));
        }

        [Theory]
        [InlineData(0, ViewportSizeGroup.XSMALL)]
        [InlineData(600, ViewportSizeGroup.SMALL)]
        [InlineData(960, ViewportSizeGroup.MEDIUM)]
        [InlineData(1280, ViewportSizeGroup.LARGE)]
        [InlineData(1920, ViewportSizeGroup.XLARGE)]
        public void Resolve_Viewport_Size_Group(int size, ViewportSizeGroup expectedSizeGroup)
        {
            Assert.Equal(expectedSizeGroup, ViewportUtils.GetViewportSizeGroup(size));
        }

        [Fact]
        public void Invalid_Viewport_Size_Group_Should_Throw_Exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ViewportUtils.GetViewportSizeGroup(-1));
        }

        [Theory]
        [InlineData(120, ViewportDpiGroup.XLOW)]
        [InlineData(160, ViewportDpiGroup.LOW)]
        [InlineData(240, ViewportDpiGroup.MEDIUM)]
        [InlineData(320, ViewportDpiGroup.HIGH)]
        [InlineData(480, ViewportDpiGroup.XHIGH)]
        [InlineData(481, ViewportDpiGroup.XXHIGH)]
        public void Reslove_Viewport_Dpi_Group(int dpi, ViewportDpiGroup expectedDpiGroup)
        {
            Assert.Equal(expectedDpiGroup, ViewportUtils.GetViewportDpiGroup(dpi));
        }

        [Fact]
        public void Invalid_Viewport_Dpi_Group_Should_Throw_Exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ViewportUtils.GetViewportDpiGroup(-1));
        }

        [Fact]
        public void Return_Unkonwn_Profile_If_Viewport_Is_Not_Present()
        {
            Assert.Equal(ViewportProfile.UnkownViewportProfile, ViewportUtils.GetViewportProfile(Request));
        }

        [Theory]
        [InlineData(ViewportShape.Round, 300, 300, 160, ViewportProfile.HubRoundSmall)]
        [InlineData(ViewportShape.Rectangle, 600, 960, 160, ViewportProfile.HubLandscapeMedium)]
        [InlineData(ViewportShape.Rectangle, 960, 1280, 160, ViewportProfile.HubLandscapeLarge)]
        [InlineData(ViewportShape.Rectangle, 300, 600, 240, ViewportProfile.MobileLandscapeSmall)]
        [InlineData(ViewportShape.Rectangle, 600, 300, 240, ViewportProfile.MobilePortraitSmall)]
        [InlineData(ViewportShape.Rectangle, 600, 960, 240, ViewportProfile.MobileLandscapeMedium)]
        [InlineData(ViewportShape.Rectangle, 960, 600, 240, ViewportProfile.MobilePortraitMedium)]
        [InlineData(ViewportShape.Rectangle, 960, 1920, 320, ViewportProfile.TvLandscapeXLarge)]
        [InlineData(ViewportShape.Rectangle, 1920, 300, 320, ViewportProfile.TvPortraitMedium)]
        [InlineData(ViewportShape.Rectangle, 600, 960, 320, ViewportProfile.TvLandscapeMedium)]
        [InlineData(ViewportShape.Round, 600, 600, 240, ViewportProfile.UnkownViewportProfile)]
        public void Resolve_Viewport_Profile(ViewportShape shape, int currentPixelHeight, int currentPixelWidth, int dpi, ViewportProfile expectedProfile)
        {
            Request.Context.Viewport = new AlexaViewport
            {
                Experiences = Array.Empty<ViewportExperience>(),
                Keyboard = Array.Empty<string>(),
                Touch = Array.Empty<string>(),
                Shape = shape,
                CurrentPixelHeight = currentPixelHeight,
                CurrentPixelWidth = currentPixelWidth,
                DPI = dpi
            };

            Assert.Equal(expectedProfile, ViewportUtils.GetViewportProfile(Request));
        }
    }
}
