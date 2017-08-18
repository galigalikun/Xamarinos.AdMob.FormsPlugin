using Android.Gms.Ads.Reward;
using System;
using Android.App;
using Android.OS;
using Android.Views;

namespace Xamarinos.AdMob.Forms.Android
{
    [Activity(Label = "AdVideoListener")]
    public class AdVideoListener : Activity, IRewardedVideoAdListener
    {

        public Action<IRewardItem> Rewarded;
        public Action RewardedVideoAdClosed;
        public Action<int> RewardedVideoAdFailedToLoad;
        public Action RewardedVideoAdLeftApplication;
        public Action RewardedVideoAdLoaded;
        public Action RewardedVideoAdOpened;
        public Action RewardedVideoStarted;

        public void OnRewarded(IRewardItem reward)
        {
            Rewarded?.Invoke(reward);
        }

        public void OnRewardedVideoAdClosed()
        {
            RewardedVideoAdClosed?.Invoke();
        }

        public void OnRewardedVideoAdFailedToLoad(int errorCode)
        {
            RewardedVideoAdFailedToLoad?.Invoke(errorCode);
        }

        public void OnRewardedVideoAdLeftApplication()
        {
            RewardedVideoAdLeftApplication?.Invoke();
        }

        public void OnRewardedVideoAdLoaded()
        {
            RewardedVideoAdLoaded?.Invoke();
        }

        public void OnRewardedVideoAdOpened()
        {
            RewardedVideoAdOpened?.Invoke();
        }

        public void OnRewardedVideoStarted()
        {
            RewardedVideoStarted?.Invoke();
        }
    }
}
