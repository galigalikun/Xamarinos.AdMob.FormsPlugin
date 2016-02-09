using System;
using System.Diagnostics;
#if __IOS__
using AdmobXamarin.Plugin.iOS;
#elif __ANDROID__
using AdmobXamarin.Plugin.Droid;
#endif

namespace AdmobXamarin.Plugin.Shared
{
	public class CrossAdmobManager
	{
		public static void Init(string admobKey)
		{
			AdmobKey = admobKey;
			IsInitialized = true;
		}

		public static string AdmobKey {
			get;
			private set;
		}

		public static bool IsInitialized {
			get;
			private set;
		}

		static Lazy<IAdsInterstitial> Implementation = new Lazy<IAdsInterstitial>(() => CreateGameCenterManager(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

		public static IAdsInterstitial Instance
		{
			get
			{
				if (!IsInitialized) {
					Debug.WriteLine ("You Must Call AdmobXamarin.Plugin.Shared.Init() before to use it");
					throw new NotImplementedException ("You Must Call AdmobXamarin.Plugin.Shared.Init() before to use it");
				}
				var ret = Implementation.Value;
				if (ret == null)
				{
					throw NotImplementedInReferenceAssembly();
				}
				return ret;
			}
		}

		public CrossAdmobManager ()
		{
		}

		static IAdsInterstitial CreateGameCenterManager()
		{
			#if PORTABLE
			return null;
			#else
			return new AdsInterstitialImplementation();
			#endif
		}

		internal static Exception NotImplementedInReferenceAssembly()
		{
			return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
		}
	}
}

