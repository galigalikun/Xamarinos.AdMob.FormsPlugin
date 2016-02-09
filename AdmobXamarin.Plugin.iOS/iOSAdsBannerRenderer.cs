using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;
using AdmobXamarin.Plugin;
using AdmobXamarin.Plugin.iOS;
using Google.MobileAds;

[assembly: ExportRenderer(typeof(AdsBanner), typeof(iOSAdsBannerRenderer))]
namespace AdmobXamarin.Plugin.iOS
{
	public class iOSAdsBannerRenderer : ViewRenderer
	{
		public static void Init ()
		{
			var init = true;
		}

		public iOSAdsBannerRenderer ()
		{

		}

		BannerView adView;
		bool viewOnScreen = false;

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);
			if (Control == null ) {
				var adsbanner = (AdsBanner)Element;
				adView = new BannerView (size: AdSizeCons.Banner, origin: new CGPoint (0, 0)) {
					AdUnitID = adsbanner.AdID,
					RootViewController = UIApplication.SharedApplication.Windows [0].RootViewController
				};

				adView.AdReceived += (sender, args) => {
					if (!viewOnScreen)
						this.AddSubview (adView);
					viewOnScreen = true;
				};

				adView.LoadRequest (Request.GetDefaultRequest ());
				base.SetNativeControl (adView);
			}

		}
	}
}

