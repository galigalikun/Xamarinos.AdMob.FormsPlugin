using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Ads;
using AdmobXamarin.Plugin;
using AdmobXamarin.Plugin.Droid;

[assembly: ExportRenderer(typeof(AdsBanner), typeof(AndroidAdsBannerRenderer))]
namespace AdmobXamarin.Plugin.Droid
{
	public class AndroidAdsBannerRenderer : ViewRenderer
	{
		public AndroidAdsBannerRenderer ()
		{
		}

		public static void Init (){
			var debug = true;
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);
			if (Control == null) {
				var adsbanner = (AdsBanner)Element;
				var adview = new AdView (Context);
				adview.AdSize = Android.Gms.Ads.AdSize.Banner;
				adview.AdUnitId = adsbanner.AdID;
				var requestbuilder = new Android.Gms.Ads.AdRequest.Builder ();
				adview.LoadAd (requestbuilder.Build ());
				base.SetNativeControl (adview);
			}

		}
	}
}

