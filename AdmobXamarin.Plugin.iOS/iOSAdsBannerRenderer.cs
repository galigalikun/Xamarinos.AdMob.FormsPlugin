using System;
using GoogleAdMobAds;
using Xamarin.Forms;
using AdMobXamarinForms_iOS;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;
using AdmobXamarin.Plugin;
using AdmobXamarin.Plugin.iOS;

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

		GADBannerView adView;
		bool viewOnScreen = false;

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);
			if (Control == null ) {
				var adsbanner = (AdsBanner)Element;
				adView = new GADBannerView (size: GADAdSizeCons.Banner, origin: new CGPoint (0, 0)) {
					AdUnitID = adsbanner.AdID,
					RootViewController = UIApplication.SharedApplication.Windows [0].RootViewController
				};

				adView.AdReceived += (sender, args) => {
					if (!viewOnScreen)
						this.AddSubview (adView);
					viewOnScreen = true;
				};

				adView.LoadRequest (GADRequest.Request);
				base.SetNativeControl (adView);
			}

		}
	}
}

