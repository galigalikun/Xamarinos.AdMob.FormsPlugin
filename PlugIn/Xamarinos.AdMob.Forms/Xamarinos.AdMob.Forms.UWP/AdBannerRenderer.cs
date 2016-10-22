
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Xamarinos.AdMob.Forms.UWP;

[assembly: ExportRenderer(typeof(Xamarinos.AdMob.Forms.AdBanner), typeof(AdBannerRenderer))]
namespace Xamarinos.AdMob.Forms.UWP
{
    public class AdBannerRenderer : ViewRenderer<StackLayout, Windows.UI.Xaml.Controls.StackPanel>
    {
        public static void Init()
        {
        }

        public AdBannerRenderer()
        {

        }
    }
}
