using System;
using AdMobXamarinForms_iOS;
using UIKit;
using AdmobXamarin.Plugin;
using Google.MobileAds;



[assembly: Xamarin.Forms.Dependency(typeof(iOSAdsInterstitial))]
namespace AdMobXamarinForms_iOS
{
	public class iOSAdsInterstitial : IAdsInterstitial
	{
		public iOSAdsInterstitial ()
		{
		}

		#region IAdsInterstitial implementation

		Interstitial adsInterstitial;

		public void Show (string adUnit)
		{
			adsInterstitial = new Interstitial(adUnit);
			var request = Request.GetDefaultRequest ();
			adsInterstitial.AdReceived += (sender, args) =>
			{
				if (adsInterstitial.IsReady)
				{                     
					var window = UIApplication.SharedApplication.KeyWindow;
					var vc = window.RootViewController;
					while (vc.PresentedViewController != null)
					{
						vc = vc.PresentedViewController;
					}
					adsInterstitial.PresentFromRootViewController(vc);
				}
			};
			adsInterstitial.LoadRequest(request);

		}

		#endregion
	}
}

