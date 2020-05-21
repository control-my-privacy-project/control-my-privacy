using CefSharp;
using CefSharp.Handler;
using System;

namespace ControlMyPrivacy.ProfileSignInScreen
{
	public class CookieSniffedEventArgs : EventArgs
	{
		public IWebBrowser ChromiumWebBrowser { get; }
		public IBrowser Browser { get; }
		public IFrame Frame { get; }
		public IRequest Request { get; }
		public IResponse Response { get; }
		public Cookie Cookie { get; }

		public CookieSniffedEventArgs(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, Cookie cookie)
		{
			ChromiumWebBrowser = chromiumWebBrowser;
			Browser = browser;
			Frame = frame;
			Request = request;
			Response = response;
			Cookie = cookie;
		}
	}

	public class CookieSniffer : ICookieAccessFilter
	{
		public event EventHandler<CookieSniffedEventArgs> CookieSniffed;

		public bool CanSaveCookie(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, Cookie cookie)
			=> SendCookieSniffed(chromiumWebBrowser, browser, frame, request, response, cookie);

		public bool CanSendCookie(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, Cookie cookie)
			=> SendCookieSniffed(chromiumWebBrowser, browser, frame, request, null, cookie);

		private bool SendCookieSniffed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, Cookie cookie)
		{
			CookieSniffed?.Invoke(this, new CookieSniffedEventArgs(chromiumWebBrowser, browser, frame, request, response, cookie));
			return true;
		}
	}

	public class CookieSnifferResourceRequestHandler : ResourceRequestHandler
	{
		public event EventHandler<CookieSniffedEventArgs> CookieSniffed;

		public CookieSniffer CookieSniffer { get; }

		public CookieSnifferResourceRequestHandler()
		{
			CookieSniffer = new CookieSniffer();
			CookieSniffer.CookieSniffed += CookieSniffer_CookieSniffedEventArgs;
		}

		private void CookieSniffer_CookieSniffedEventArgs(object sender, CookieSniffedEventArgs e)
			=> CookieSniffed?.Invoke(this, e);

		protected override ICookieAccessFilter GetCookieAccessFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
			=> CookieSniffer;
	}

	public class CookieSnifferRequestHandler : RequestHandler
	{
		public event EventHandler<CookieSniffedEventArgs> CookieSniffed;

		public CookieSnifferResourceRequestHandler ResourceRequestHandler { get; }

		public CookieSnifferRequestHandler()
		{
			ResourceRequestHandler = new CookieSnifferResourceRequestHandler();
			ResourceRequestHandler.CookieSniffed += ResourceRequestHandler_CookieSniffed;
		}

		private void ResourceRequestHandler_CookieSniffed(object sender, CookieSniffedEventArgs e)
			=> CookieSniffed?.Invoke(this, e);

		protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
			=> ResourceRequestHandler;
	}
}
