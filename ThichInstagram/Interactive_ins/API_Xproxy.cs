using System.Threading;
 

namespace Interactive_ins
{
	public class API_Xproxy
	{
		private string service = "";

		private string proxy = "";

		public API_Xproxy(string service, string proxy)
		{
			this.service = service;
			this.proxy = proxy;
		}

		private string Get_html(string url)
		{
			xNet.HttpRequest httpRequest = new xNet.HttpRequest();
			try
			{
				return httpRequest.Get(url).ToString();
			}
			catch
			{
				return null;
			}
		}

		private string Check_proxy()
		{
			string url = service + "/proxy_check?proxy=" + proxy;
			return Get_html(url);
		}

		private string proxy_reset()
		{
			string url = service + "/proxy_check?proxy=" + proxy;
			return Get_html(url);
		}

		public bool changeip_xproxy()
		{
			int num = 300;
			string text = proxy_reset();
			while (num > 0)
			{
				num--;
				string text2 = Check_proxy();
				Thread.Sleep(1000);
				if (text2 == null || text2.Contains("PROXY_DISCONNECT") || text2.Contains("PROXY_FALSE"))
				{
					return false;
				}
				if (text2.Contains("PROXY_OK"))
				{
					return true;
				}
				if (!text2.Contains("PROXY_RELOAD"))
				{
				}
			}
			return false;
		}
	}
}
