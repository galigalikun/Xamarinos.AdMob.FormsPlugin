using System;
using Android.Gms.Ads;

namespace AdmobXamarin.Plugin.Droid
{
	public class AdListenerInterstitial : AdListener
	{
		readonly InterstitialAd AdInterstitial;
		public AdListenerInterstitial (InterstitialAd adInterstitial)
		{
			AdInterstitial = adInterstitial;
		}

		public override void OnAdLoaded()
		{
			base.OnAdLoaded();

			if (AdInterstitial.IsLoaded)
				AdInterstitial.Show();
		}
	}
}

