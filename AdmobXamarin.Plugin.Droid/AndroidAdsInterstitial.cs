using System;
using Xamarin.Forms;
using Android.Gms.Ads;
using AdmobXamarin.Plugin.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidAdsInterstitial))]

namespace AdmobXamarin.Plugin.Droid
{
	public class AndroidAdsInterstitial : IAdsInterstitial
	{
		public AndroidAdsInterstitial ()
		{
		}

		#region IAdsInterstitial implementation
		InterstitialAd AdInterstitial;
		public void Show (string AdIdInterstitial)
		{
			AdInterstitial = new InterstitialAd(Forms.Context);
			AdInterstitial.AdUnitId = AdIdInterstitial;

			var intlistener = new AdListenerInterstitial(AdInterstitial);
			intlistener.OnAdLoaded();
			AdInterstitial.AdListener = intlistener;

			var requestbuilder = new AdRequest.Builder();
			AdInterstitial.LoadAd(requestbuilder.Build());
		}

		#endregion
	}
}

