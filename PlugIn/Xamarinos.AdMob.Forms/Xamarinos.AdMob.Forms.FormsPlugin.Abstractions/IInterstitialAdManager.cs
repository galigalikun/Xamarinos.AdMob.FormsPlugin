using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarinos.AdMob.Forms.Abstractions
{
    public interface IInterstitialAdManager
    {
        /// <summary>
        /// Show Interstitial Ad.
        /// </summary>
        Task Show(string AdmobKey, Action OnPresented = null);
    }
}
