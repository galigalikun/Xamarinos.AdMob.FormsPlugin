using System;

namespace AdmobXamarin.Plugin
{
	public interface IAdsInterstitial
	{
		/// <summary>
		/// Show Interstitial Ad.
		/// </summary>
		/// <param name="AdIdInterstitial"> Set Ad identifier interstitial android/iOS.</param>
		void Show(string AdIdInterstitial);
	}
}

