using Ask.Sdk.Model.Request;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ask.Sdk.Core.Util
{
    public static class ViewportUtils
    {
        public static List<ViewportSizeGroup> ViewportSizeGroupOrder = new List<ViewportSizeGroup>
        {
            ViewportSizeGroup.XSMALL,
            ViewportSizeGroup.SMALL,
            ViewportSizeGroup.MEDIUM,
            ViewportSizeGroup.LARGE,
            ViewportSizeGroup.XLARGE
        };

        public static List<ViewportDpiGroup> ViewportDpiGroupOrder = new List<ViewportDpiGroup>
        {
            ViewportDpiGroup.XLOW,
            ViewportDpiGroup.LOW,
            ViewportDpiGroup.MEDIUM,
            ViewportDpiGroup.HIGH,
            ViewportDpiGroup.XHIGH,
            ViewportDpiGroup.XXHIGH
        };

        public static ViewPortOrientation GetViewportOrientation(int width, int height)
        {
            return width > height ? ViewPortOrientation.LANDSCAPE : 
                width < height ? ViewPortOrientation.PORTRAIT : 
                ViewPortOrientation.EQUAL;
        }

        public static ViewportSizeGroup GetViewportSizeGroup(int size)
        {
            switch (size)
            {
                case int n when (n >= 0 && n < 600):
                    return ViewportSizeGroup.XSMALL;
                case int n when (n >= 600 && n < 960):
                    return ViewportSizeGroup.SMALL;
                case int n when (n >= 960 && n < 1280):
                    return ViewportSizeGroup.MEDIUM;
                case int n when (n >= 1280 && n < 1920):
                    return ViewportSizeGroup.LARGE;
                case int n when (n >= 1280):
                    return ViewportSizeGroup.XLARGE;
            }

            throw new ArgumentOutOfRangeException(nameof(size));
        }

        public static ViewportDpiGroup GetViewportDpiGroup(int dpi)
        {
            switch (dpi)
            {
                case int n when (n >= 0 && n < 121):
                    return ViewportDpiGroup.XLOW;
                case int n when (n >= 121 && n < 161):
                    return ViewportDpiGroup.LOW;
                case int n when (n >= 161 && n < 241):
                    return ViewportDpiGroup.MEDIUM;
                case int n when (n >= 241 && n < 321):
                    return ViewportDpiGroup.HIGH;
                case int n when (n >= 321 && n < 481):
                    return ViewportDpiGroup.XHIGH;
                case int n when (n >= 481):
                    return ViewportDpiGroup.XXHIGH;
            }

            throw new ArgumentOutOfRangeException(nameof(dpi));
        }

        public static ViewportProfile GetViewportProfile(RequestEnvelope requestEnvelope)
        {
            var viewportState = requestEnvelope.Context?.ViewPort;
            if (viewportState != null)
            {
                var currentPixelWidth = viewportState.CurrentPixelWidth;
                var currentPixelHeight = viewportState.CurrentPixelHeight;
                var dpi = viewportState.Dpi;

                var shape = viewportState.Shape;
                var viewportOrientation = GetViewportOrientation(currentPixelWidth ?? 0, currentPixelHeight ?? 0);
                var viewportDpiGroup = GetViewportDpiGroup(dpi ?? 0);
                var pixelWidthSizeGroup = GetViewportSizeGroup(currentPixelWidth ?? 0);
                var pixelHeightSizeGroup = GetViewportSizeGroup(currentPixelHeight ?? 0);

                if (shape == Shape.Round && 
                    viewportOrientation == ViewPortOrientation.EQUAL &&
                    viewportDpiGroup == ViewportDpiGroup.LOW && 
                    pixelWidthSizeGroup == ViewportSizeGroup.XSMALL &&
                    pixelHeightSizeGroup == ViewportSizeGroup.XSMALL)
                {
                    return ViewportProfile.HubRoundSmall;
                }

                if (shape == Shape.Rectangle &&
                    viewportOrientation == ViewPortOrientation.LANDSCAPE &&
                    viewportDpiGroup == ViewportDpiGroup.LOW &&
                    (int)pixelWidthSizeGroup <= (int)ViewportSizeGroup.MEDIUM &&
                    (int)pixelHeightSizeGroup <= (int)ViewportSizeGroup.SMALL)
                {
                    return ViewportProfile.HubLandscapeMedium;
                }

                if (shape == Shape.Rectangle &&
                    viewportOrientation == ViewPortOrientation.LANDSCAPE &&
                    viewportDpiGroup == ViewportDpiGroup.LOW &&
                    (int)pixelWidthSizeGroup >= (int)ViewportSizeGroup.LARGE &&
                    (int)pixelHeightSizeGroup >= (int)ViewportSizeGroup.SMALL)
                {
                    return ViewportProfile.HubLandscapeLarge;
                }

                if (shape == Shape.Rectangle &&
                    viewportOrientation == ViewPortOrientation.LANDSCAPE &&
                    viewportDpiGroup == ViewportDpiGroup.MEDIUM &&
                    (int)pixelWidthSizeGroup >= (int)ViewportSizeGroup.MEDIUM &&
                    (int)pixelHeightSizeGroup >= (int)ViewportSizeGroup.SMALL)
                {
                    return ViewportProfile.MobileLandscapeMedium;
                }

                if (shape == Shape.Rectangle &&
                    viewportOrientation == ViewPortOrientation.PORTRAIT &&
                    viewportDpiGroup == ViewportDpiGroup.MEDIUM &&
                    (int)pixelWidthSizeGroup >= (int)ViewportSizeGroup.SMALL &&
                    (int)pixelHeightSizeGroup >= (int)ViewportSizeGroup.MEDIUM)
                {
                    return ViewportProfile.MobilePortraitMedium;
                }

                if (shape == Shape.Rectangle &&
                    viewportOrientation == ViewPortOrientation.LANDSCAPE &&
                    viewportDpiGroup == ViewportDpiGroup.MEDIUM &&
                    (int)pixelWidthSizeGroup >= (int)ViewportSizeGroup.SMALL &&
                    (int)pixelHeightSizeGroup >= (int)ViewportSizeGroup.XSMALL)
                {
                    return ViewportProfile.MobileLandscapeSmall;
                }

                if (shape == Shape.Rectangle &&
                    viewportOrientation == ViewPortOrientation.PORTRAIT &&
                    viewportDpiGroup == ViewportDpiGroup.MEDIUM &&
                    (int)pixelWidthSizeGroup >= (int)ViewportSizeGroup.XSMALL &&
                    (int)pixelHeightSizeGroup >= (int)ViewportSizeGroup.SMALL)
                {
                    return ViewportProfile.MobilePortraitSmall;
                }

                if (shape == Shape.Rectangle &&
                    viewportOrientation == ViewPortOrientation.LANDSCAPE &&
                    (int)viewportDpiGroup >= (int)ViewportDpiGroup.HIGH &&
                    (int)pixelWidthSizeGroup >= (int)ViewportSizeGroup.XLARGE &&
                    (int)pixelHeightSizeGroup >= (int)ViewportSizeGroup.MEDIUM)
                {
                    return ViewportProfile.TvLandscapeXLarge;
                }

                if (shape == Shape.Rectangle &&
                    viewportOrientation == ViewPortOrientation.PORTRAIT &&
                    (int)viewportDpiGroup >= (int)ViewportDpiGroup.HIGH &&
                    pixelWidthSizeGroup >= ViewportSizeGroup.XSMALL &&
                    pixelHeightSizeGroup >= ViewportSizeGroup.XLARGE)
                {
                    return ViewportProfile.TvPortraitMedium;
                }

                if (shape == Shape.Rectangle &&
                    viewportOrientation == ViewPortOrientation.LANDSCAPE &&
                    (int)viewportDpiGroup >= (int)ViewportDpiGroup.HIGH &&
                    pixelWidthSizeGroup >= ViewportSizeGroup.MEDIUM &&
                    pixelHeightSizeGroup >= ViewportSizeGroup.SMALL)
                {
                    return ViewportProfile.TvLandscapeMedium;
                }
            }

            return ViewportProfile.UnkownViewportProfile;
        }
    }

    public enum ViewportProfile
    {
        [EnumMember(Value = "HUB-ROUND-SMALL")]
        HubRoundSmall,
        [EnumMember(Value = "HUB-LANDSCAPE-MEDIUM")]
        HubLandscapeMedium,
        [EnumMember(Value = "HUB-LANDSCAPE-LARGE")]
        HubLandscapeLarge,
        [EnumMember(Value = "MOBILE-LANDSCAPE-SMALL")]
        MobileLandscapeSmall,
        [EnumMember(Value = "MOBILE-PORTRAIT-SMALL")]
        MobilePortraitSmall,
        [EnumMember(Value = "MOBILE-LANDSCAPE-MEDIUM")]
        MobileLandscapeMedium,
        [EnumMember(Value = "MOBILE-PORTRAIT-MEDIUM")]
        MobilePortraitMedium,
        [EnumMember(Value = "TV-LANDSCAPE-XLARGE")]
        TvLandscapeXLarge,
        [EnumMember(Value = "TV-PORTRAIT-MEDIUM")]
        TvPortraitMedium,
        [EnumMember(Value = "TV-LANDSCAPE-MEDIUM")]
        TvLandscapeMedium,
        [EnumMember(Value = "UNKNOWN-VIEWPORT-PROFILE")]
        UnkownViewportProfile
    }

    public enum ViewPortOrientation
    {
        EQUAL,
        LANDSCAPE,
        PORTRAIT
    }

    public enum ViewportSizeGroup
    {
        XSMALL,
        SMALL,
        MEDIUM,
        LARGE,
        XLARGE
    }

    public enum ViewportDpiGroup
    {
        XLOW,
        LOW,
        MEDIUM,
        HIGH,
        XHIGH,
        XXHIGH
    }
}
