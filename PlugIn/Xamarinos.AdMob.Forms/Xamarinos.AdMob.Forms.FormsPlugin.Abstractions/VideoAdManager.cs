using System;
using System.Threading.Tasks;

namespace Xamarinos.AdMob.Forms.Abstractions
{
    public interface VideoAdManager
    {
		/// <summary>
		/// Show RewardBasedVideo Ad.
		/// </summary>
		Task Show(string AdmobKey, Action OnPresented = null);
    }
}
