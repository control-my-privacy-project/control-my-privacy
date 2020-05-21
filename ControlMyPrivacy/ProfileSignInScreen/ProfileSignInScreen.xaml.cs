using CefSharp;
using CefSharp.Handler;
using ControlMyPrivacy.Models;
using PostSharp.Patterns.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlMyPrivacy.ProfileSignInScreen
{
	/// <summary>
	/// Interaction logic for ProfileSignInScreen.xaml
	/// </summary>
	public partial class ProfileSignInScreen : UserControl
	{
		[DependencyProperty]
		public SocialMedia SocialMedia { get; set; }

		public event EventHandler<ProfileSignedInEventArgs> ProfileSignedIn;

		public ProfileSignInScreen() => InitializeComponent();

		public void OnSocialMediaChanged()
		{
			InitCookieSniffer();
			InitDefaultAddress();
		}

		private void InitCookieSniffer()
		{
			var cookieSniffer = new CookieSnifferRequestHandler();
			cookieSniffer.CookieSniffed += CookieSniffer_CookieSniffed;
			Browser.RequestHandler = cookieSniffer;
		}

		private void InitDefaultAddress()
		{
			if (SocialMedia == SocialMedia.VK)
				Browser.Address = "https://m.vk.com";
			else
				Browser.Address = null;
		}

		private void CookieSniffer_CookieSniffed(object sender, CookieSniffedEventArgs e)
		{
			Application.Current.Dispatcher.Invoke(() =>
			{
				if (SocialMedia == SocialMedia.VK)
				{
					if (
						e.Cookie.Name.ToLower() == SocialMediaProvider.Providers.VK.Constants.SessionCookie.ToLower() &&
						e.Cookie.Domain.Contains("vk.com")
					)
					{
						var value = e.Cookie.Value;
						ProfileSignedIn?.Invoke(this, new ProfileSignedInEventArgs(SocialMedia, new { session = value }));
						SocialMedia = null;
					}
				}
			});
		}
	}

	
}
