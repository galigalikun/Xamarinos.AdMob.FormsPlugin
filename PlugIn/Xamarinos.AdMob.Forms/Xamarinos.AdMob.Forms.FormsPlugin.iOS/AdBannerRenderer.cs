using Xamarinos.AdMob.Forms.Abstractions;
using System;
using Xamarin.Forms;
using Xamarinos.AdMob.Forms.iOS;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Google.MobileAds;
using CoreGraphics;

[assembly: ExportRenderer(typeof(Xamarinos.AdMob.Forms.AdBanner), typeof(Xamarinos.AdMob.Forms.iOS.AdBannerRenderer))]
namespace Xamarinos.AdMob.Forms.iOS
{
    public class AdBannerRenderer : ViewRenderer
    {
        public static void Init()
        {
            var init = true;
        }

        public AdBannerRenderer()
        {

        }

        BannerView adView;
        bool viewOnScreen = false;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var adsbanner = (AdBanner)Element;
                adView = new BannerView(size: AdSizeCons.Banner, origin: new CGPoint(0, 0))
                {
                    AdUnitID = adsbanner.AdID,
                    RootViewController = UIApplication.SharedApplication.Windows[0].RootViewController
                };

                adView.AdReceived += (sender, args) => {
                    if (!viewOnScreen)
                        this.AddSubview(adView);
                    viewOnScreen = true;
                };

                adView.LoadRequest(Request.GetDefaultRequest());
                base.SetNativeControl(adView);
            }

        }
    }
}
