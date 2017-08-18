using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarinos.AdMob.Forms.Abstractions;

namespace Xamarinos.AdMob.Forms
{
    public class CrossAdmobManager<T> where T : class
    {
		private static List<string> testDevicesId;
		public static void Init(List<string> testDevices = null )
        {
			testDevicesId = testDevices;
            IsInitialized = true;
        }

        public static bool IsInitialized
        {
            get;
            private set;
        }

        static Lazy<T> Implementation = new Lazy<T>(() => CreateGameCenterManager(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        public static T Current
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

        static T CreateGameCenterManager()
        {
#if PORTABLE
			return null;
#else
            return Activator.CreateInstance(typeof(T), new Object[] { testDevicesId }) as T;
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}
