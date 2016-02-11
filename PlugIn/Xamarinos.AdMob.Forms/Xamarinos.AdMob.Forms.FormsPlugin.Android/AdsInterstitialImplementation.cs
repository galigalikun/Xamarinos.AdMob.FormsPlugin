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
using Xamarinos.AdMob.Forms.Abstractions;
using Android.Gms.Ads;
using System.Threading.Tasks;
using Xamarinos.AdMob.Forms.Android;

namespace Xamarinos.AdMob.Forms
{
    public class AdsInterstitialImplementation : IInterstitialAdManager
    {
        public AdsInterstitialImplementation()
        {
        }

        #region IAdsInterstitial implementation
        InterstitialAd AdInterstitial;

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

            AdInterstitial = new InterstitialAd(Xamarin.Forms.Forms.Context);
            AdInterstitial.AdUnitId = CrossAdmobManager.AdmobKey;

            var intlistener = new AdInterstitialListener(AdInterstitial);
            intlistener.AdLoaded = () => {
                OnPresented?.Invoke();
            };
            intlistener.AdClosed = () => {
                if (showTask != null)
                {
                    showTask.TrySetResult(AdInterstitial.IsLoaded);
                }
            };
            //intlistener.OnAdLoaded();
            AdInterstitial.AdListener = intlistener;

            var requestbuilder = new AdRequest.Builder();
            AdInterstitial.LoadAd(requestbuilder.Build());
            return Task.WhenAll(showTask.Task);
        }

        #endregion
    }
}