using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;

[assembly: ExportRenderer(typeof(Xamarinos.AdMob.Forms.AdBanner), typeof(Xamarinos.AdMob.Forms.Windows.AdBannerRenderer))]
namespace Xamarinos.AdMob.Forms.Windows
{
    public class AdBannerRenderer : ViewRenderer<View, GridView>
    {
        public AdBannerRenderer()
        {
        }

        public static void Init()
        {
        }
    }
}
