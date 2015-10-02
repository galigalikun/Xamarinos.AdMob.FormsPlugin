using System;
using AdMobXamarinForms_iOS;
using GoogleAdMobAds;
using UIKit;
using AdmobXamarin.Plugin;



[assembly: Xamarin.Forms.Dependency(typeof(iOSAdsInterstitial))]
namespace AdMobXamarinForms_iOS
{
	public class iOSAdsInterstitial : IAdsInterstitial
	{
		public iOSAdsInterstitial ()
		{
		}

		#region IAdsInterstitial implementation

		GADInterstitial adsInterstitial;

		public void Show (string adUnit)
		{
			adsInterstitial = new GADInterstitial(adUnit);
			var request = GADRequest.Request;
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

