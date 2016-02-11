using Xamarinos.AdMob.Forms.FormsPlugin.Abstractions;
using System;
using Xamarin.Forms;
using Xamarinos.AdMob.Forms.FormsPlugin.WindowsPhone;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(Xamarinos.AdMob.Forms.FormsPlugin.Abstractions.Xamarinos.AdMob.FormsControl), typeof(Xamarinos.AdMob.FormsRenderer))]
namespace Xamarinos.AdMob.Forms.FormsPlugin.WindowsPhone
{
    /// <summary>
    /// Xamarinos.AdMob.Forms Renderer
    /// </summary>
    public class Xamarinos.AdMob.FormsRenderer //: TRender (replace with renderer type
  {
    /// <summary>
    /// Used for registration with dependency service
    /// </summary>
    public static void Init() { }
}
}
