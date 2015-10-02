using System;
using Xamarin.Forms;

namespace AdmobXamarin.Plugin
{
	public class AdsBanner : View
	{
		public AdsBanner ()
		{
		}

		/// <summary>
		/// Gets or sets the ad identifier.
		/// </summary>
		/// <value>The ad identifier</value>
		public string AdID
		{
			get { return (string)GetValue(AdIDProperty); }
			set { 
				if (value != AdID)
					this.SetValue(AdIDProperty, value); 
			}
		}
		public static readonly BindableProperty AdIDProperty =
			BindableProperty.Create<AdsBanner, string>(
				p => p.AdID, string.Empty);
	}
}

