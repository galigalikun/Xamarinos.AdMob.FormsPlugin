using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Ads;

namespace Xamarinos.AdMob.Forms.Android
{
    public class AdInterstitialListener : AdListener
    {
        readonly InterstitialAd AdInterstitial;
        public AdInterstitialListener(InterstitialAd adInterstitial)
        {
            AdInterstitial = adInterstitial;
        }

        public Action AdLoaded;
        public Action AdClosed;
		public Action AdFailed;

        public override void OnAdLoaded()
        {
            base.OnAdLoaded();

            if (AdInterstitial.IsLoaded)
            {
                AdInterstitial.Show();
            }
            AdLoaded?.Invoke();
        }

        public override void OnAdClosed()
        {
            base.OnAdClosed();
            AdClosed?.Invoke();
        }

		public override void OnAdFailedToLoad(int errorCode)
		{
			base.OnAdFailedToLoad(errorCode);
			AdFailed?.Invoke();
		}
    }
}