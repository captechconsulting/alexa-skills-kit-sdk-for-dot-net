using Ask.Sdk.Core.Util;
using Ask.Sdk.Model.Request;
using Ask.Sdk.Model.Request.Type;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Ask.Sdk.Core.Tests.Util
{
    public class ViewportUtilsTests : BaseTests
    {
        public ViewportUtilsTests() : base()
        {
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
        [InlineData(Shape.Round, 300, 300, 160, ViewportProfile.HubRoundSmall)]
        [InlineData(Shape.Rectangle, 600, 960, 160, ViewportProfile.HubLandscapeMedium)]
        [InlineData(Shape.Rectangle, 960, 1280, 160, ViewportProfile.HubLandscapeLarge)]
        [InlineData(Shape.Rectangle, 300, 600, 240, ViewportProfile.MobileLandscapeSmall)]
        [InlineData(Shape.Rectangle, 600, 300, 240, ViewportProfile.MobilePortraitSmall)]
        [InlineData(Shape.Rectangle, 600, 960, 240, ViewportProfile.MobileLandscapeMedium)]
        [InlineData(Shape.Rectangle, 960, 600, 240, ViewportProfile.MobilePortraitMedium)]
        [InlineData(Shape.Rectangle, 960, 1920, 320, ViewportProfile.TvLandscapeXLarge)]
        [InlineData(Shape.Rectangle, 1920, 300, 320, ViewportProfile.TvPortraitMedium)]
        [InlineData(Shape.Rectangle, 600, 960, 320, ViewportProfile.TvLandscapeMedium)]
        [InlineData(Shape.Round, 600, 600, 240, ViewportProfile.UnkownViewportProfile)]
        public void Resolve_Viewport_Profile(Shape shape, int currentPixelHeight, int currentPixelWidth, int dpi, ViewportProfile expectedProfile)
        {
            Request.Context.ViewPort = new ViewPortState
            {
                Experiences = Enumerable.Empty<Experience>(),
                Keyboard = Enumerable.Empty<Keyboard>(),
                Touch = Enumerable.Empty<Touch>(),
                Shape = shape,
                CurrentPixelHeight = currentPixelHeight,
                CurrentPixelWidth = currentPixelWidth,
                Dpi = dpi
            };

            Assert.Equal(expectedProfile, ViewportUtils.GetViewportProfile(Request));
        }
    }
}
