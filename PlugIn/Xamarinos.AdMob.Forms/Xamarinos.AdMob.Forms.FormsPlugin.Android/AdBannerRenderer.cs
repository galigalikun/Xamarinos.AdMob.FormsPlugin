using Xamarinos.AdMob.Forms.Abstractions;
using System;
using Xamarin.Forms;
using Xamarinos.AdMob.Forms.Android;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Ads;

[assembly: ExportRenderer(typeof(Xamarinos.AdMob.Forms.AdBanner), typeof(Xamarinos.AdMob.Forms.Android.AdBannerRenderer))]
namespace Xamarinos.AdMob.Forms.Android
{
    public class AdBannerRenderer : ViewRenderer
    {
        public AdBannerRenderer()
        {
        }

        public static void Init()
        {
            var debug = true;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var adsbanner = (AdBanner)Element;
                var adview = new AdView(Context);
                adview.AdSize = AdSize.Banner;
                adview.AdUnitId = adsbanner.AdID;
                var requestbuilder = new AdRequest.Builder();
                adview.LoadAd(requestbuilder.Build());
                base.SetNativeControl(adview);
            }

        }
    }
}