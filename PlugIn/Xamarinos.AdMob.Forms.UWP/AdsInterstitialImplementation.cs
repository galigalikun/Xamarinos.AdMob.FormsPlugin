using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarinos.AdMob.Forms.Abstractions;

namespace Xamarinos.AdMob.Forms
{
    public class AdsInterstitialImplementation : IInterstitialAdManager
    {
        public AdsInterstitialImplementation()
        {
        }

        public Task Show(Action OnPresented = null)
        {
            return Task.CompletedTask;
        }
    }
}
