using Android.Gms.Ads;
using Android.Gms.Ads.Reward;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarinos.AdMob.Forms.Abstractions;

namespace Xamarinos.AdMob.Forms.Android
{
    public class AdsVideoImplementation : VideoAdManager
    {
        private AdRequest.Builder requestBuilder;
		public AdsVideoImplementation(List<string> testDevices = null)
		{
			requestBuilder = new AdRequest.Builder();
			if (testDevices != null)
			{
				foreach (var id in testDevices)
					requestBuilder.AddTestDevice(id);
				requestBuilder.AddTestDevice(AdRequest.DeviceIdEmulator);
			}
		}


		#region IAdsInterstitial implementation
		IRewardedVideoAd AdVideo;

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
            AdVideo = MobileAds.GetRewardedVideoAdInstance(Xamarin.Forms.Forms.Context);
            var listner = new AdVideoListener();


            listner.Rewarded += (reward) => 
            {
                
            };
            listner.RewardedVideoAdClosed += () => 
            {
				if (showTask != null)
				{
					showTask.TrySetResult(AdVideo.IsLoaded);
					showTask = null;
				}
            };
            listner.RewardedVideoAdFailedToLoad += (errorCode) => 
            {
				OnPresented?.Invoke();
				if (showTask != null)
				{
					showTask.TrySetResult(AdVideo.IsLoaded);
					showTask = null;
				}
            };
            listner.RewardedVideoAdLeftApplication += () => 
            {
                
            };
            listner.RewardedVideoAdLoaded += () => 
            {
                
            };
            listner.RewardedVideoAdOpened += () => 
            {
                
            };
            listner.RewardedVideoStarted += () => 
            {
                
            };

			AdVideo.RewardedVideoAdListener = listner;
            AdVideo.LoadAd(AdmobKey, requestBuilder.Build());


			return Task.WhenAll(showTask.Task);
		}

		#endregion
	}
}
