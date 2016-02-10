using System;
using UIKit;
using AdmobXamarin.Plugin;
using Google.MobileAds;
using AdmobXamarin.Plugin.Shared;
using System.Threading.Tasks;

namespace AdmobXamarin.Plugin.iOS
{
	public class AdsInterstitialImplementation : IAdsInterstitial
	{
		public AdsInterstitialImplementation ()
		{
		}

		#region IAdsInterstitial implementation

		Interstitial adsInterstitial;

		TaskCompletionSource<bool> showTask;

		public Task Show (Action OnPresented = null)
		{
			if (showTask != null) {
				showTask.TrySetResult (false);
				showTask.TrySetCanceled ();
			} else {
				showTask = new TaskCompletionSource<bool> ();
			}

			adsInterstitial = new Interstitial(CrossAdmobManager.AdmobKey);
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
					OnPresented?.Invoke();
				}
			};
			adsInterstitial.ScreenDismissed += (sender, e) => {
				if (showTask != null) {
					showTask.TrySetResult (adsInterstitial.IsReady);
				}
			};
			adsInterstitial.LoadRequest(request);
			return Task.WhenAll (showTask.Task);
		}

		#endregion
	}
}

