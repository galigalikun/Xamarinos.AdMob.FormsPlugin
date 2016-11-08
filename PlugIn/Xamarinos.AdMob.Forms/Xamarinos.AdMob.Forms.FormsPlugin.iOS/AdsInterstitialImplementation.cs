using Google.MobileAds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarinos.AdMob.Forms.Abstractions;

namespace Xamarinos.AdMob.Forms
{
    public class AdsInterstitialImplementation : IInterstitialAdManager
    {
		private List<string> testDevicesId;
		public AdsInterstitialImplementation(List<string>testDevices = null)
        {
			testDevicesId = testDevices;
        }

        #region IAdsInterstitial implementation
        Interstitial adsInterstitial;
        TaskCompletionSource<bool> showTask;
        public Task Show(Action OnPresented = null)
        {
            if (showTask != null)
            {
                showTask.TrySetResult(false);
                showTask.TrySetCanceled();
            }
            else {
                showTask = new TaskCompletionSource<bool>();
            }
            adsInterstitial = new Interstitial(CrossAdmobManager.AdmobKey);
            var request = Request.GetDefaultRequest();
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
                if (showTask != null)
                {
                    showTask.TrySetResult(adsInterstitial.IsReady);
					showTask = null;

                }
			};

			adsInterstitial.ReceiveAdFailed += (sender, e) =>
			{
				OnPresented?.Invoke();
				showTask.TrySetResult(false);
				showTask.TrySetCanceled();
				showTask = null;
			};

			if (testDevicesId != null)
			{
				testDevicesId.Add(Request.SimulatorId);
				request.TestDevices = testDevicesId.ToArray();
			}
            adsInterstitial.LoadRequest(request);
            return Task.WhenAll(showTask.Task);
        }

        #endregion
    }
}
