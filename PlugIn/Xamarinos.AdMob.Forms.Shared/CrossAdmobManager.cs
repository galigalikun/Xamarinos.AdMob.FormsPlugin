using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarinos.AdMob.Forms.Abstractions;

namespace Xamarinos.AdMob.Forms
{
    public class CrossAdmobManager
    {
        public static void Init(string admobKey)
        {
            AdmobKey = admobKey;
            IsInitialized = true;
        }

        public static string AdmobKey
        {
            get;
            private set;
        }

        public static bool IsInitialized
        {
            get;
            private set;
        }

        static Lazy<IInterstitialAdManager> Implementation = new Lazy<IInterstitialAdManager>(() => CreateGameCenterManager(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        public static IInterstitialAdManager Current
        {
            get
            {
                if (!IsInitialized)
                {
                    Debug.WriteLine("You Must Call Xamarinos.AdMob.Forms.Current.Init() before to use it");
                    throw new NotImplementedException("You Must Call Xamarinos.AdMob.Forms.Current.Init() before to use it");
                }
                var ret = Implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        public CrossAdmobManager()
        {
        }

        static IInterstitialAdManager CreateGameCenterManager()
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
