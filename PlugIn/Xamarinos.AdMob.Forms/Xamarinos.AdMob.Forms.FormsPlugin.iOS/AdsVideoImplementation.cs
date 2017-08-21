using Google.MobileAds;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;
using Xamarinos.AdMob.Forms.Abstractions;

namespace Xamarinos.AdMob.Forms.iOS
{
    public class AdsVideoImplementation : VideoAdManager
    {
        private List<string> testDevicesId;
        public AdsVideoImplementation(List<string> testDevices = null)
        {
            testDevicesId = testDevices;
        }

        #region IAdsInterstitial implementation
        RewardBasedVideoAd adsVideo;
		TaskCompletionSource<bool> showTask;
		public Task Show(string AdmobKey, Action OnPresented = null)
		{
			if (showTask != null)
			{
				showTask.TrySetResult(false);
				showTask.TrySetCanceled();
			}
			else
			{
				showTask = new TaskCompletionSource<bool>();
			}
            var request = Request.GetDefaultRequest();


            RewardBasedVideoAd.SharedInstance.AdReceived += (sender, e) => 
            {
				if (RewardBasedVideoAd.SharedInstance.Ready)
				{
					var window = UIApplication.SharedApplication.KeyWindow;
					var vc = window.RootViewController;
					while (vc.PresentedViewController != null)
					{
						vc = vc.PresentedViewController;
					}
					RewardBasedVideoAd.SharedInstance.PresentFromRootViewController(vc);
					OnPresented?.Invoke();
				}
            };
			
            RewardBasedVideoAd.SharedInstance.Closed += (sender, e) => 
            {
				if (showTask != null)
				{
                    showTask.TrySetResult(RewardBasedVideoAd.SharedInstance.Ready);
					showTask = null;

				}
            };

            RewardBasedVideoAd.SharedInstance.FailedToLoad += (sender, e) => 
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

			RewardBasedVideoAd.SharedInstance.LoadRequest(request, AdmobKey);

			return Task.WhenAll(showTask.Task);
		}

        #endregion
    }
}
