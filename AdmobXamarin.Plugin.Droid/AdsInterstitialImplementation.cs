using System;
using Xamarin.Forms;
using Android.Gms.Ads;
using AdmobXamarin.Plugin.Droid;
using AdmobXamarin.Plugin.Shared;
using System.Threading.Tasks;

namespace AdmobXamarin.Plugin.Droid
{
	public class AdsInterstitialImplementation : IAdsInterstitial
	{
		public AdsInterstitialImplementation ()
		{
		}

		#region IAdsInterstitial implementation
		InterstitialAd AdInterstitial;

		TaskCompletionSource<bool> showTask;

		public Task Show ()
		{
			if (showTask != null) {
				showTask.TrySetResult (false);
				showTask.TrySetCanceled ();
			} else {
				showTask = new TaskCompletionSource<bool> ();
			}

			AdInterstitial = new InterstitialAd(Forms.Context);
			AdInterstitial.AdUnitId = CrossAdmobManager.AdmobKey;

			var intlistener = new AdListenerInterstitial(AdInterstitial);
			intlistener.AdLoaded = () => {
				if (showTask != null) {
					showTask.TrySetResult (AdInterstitial.IsLoaded);
				}
			};
			intlistener.OnAdLoaded();
			AdInterstitial.AdListener = intlistener;

			var requestbuilder = new AdRequest.Builder();
			AdInterstitial.LoadAd(requestbuilder.Build());
			return Task.WhenAll (showTask.Task);
		}

		#endregion
	}
}

