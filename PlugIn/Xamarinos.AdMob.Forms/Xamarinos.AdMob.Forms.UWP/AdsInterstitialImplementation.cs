using System;
using System.Threading.Tasks;
using Xamarinos.AdMob.Forms.Abstractions;

namespace Xamarinos.AdMob.Forms
{
    public class AdsInterstitialImplementation : IInterstitialAdManager
    {
        public AdsInterstitialImplementation()
        {
        }

        public async Task Show(Action OnPresented = null)
        {
            await Task.Delay(1);
        }
    }
}
