using Newtonsoft.Json;

namespace Interactive_ins
{
    public class API_Minproxy
	{
		private string apiKey { get; set; }

		public API_Minproxy(string apiKey)
		{
			this.apiKey = apiKey;
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

		public Minproxy CheckIP_dancu()
		{
			string url = "https://dash.minproxy.vn/api/rotating/v1/proxy_v4/get-current-proxy?api_key=" + apiKey;
			string text = Get_html(url);
			try
			{
				if (text.Contains("error"))
				{
					return null;
				}
				Minproxy minproxy = JsonConvert.DeserializeObject<Minproxy>(text);
				if (minproxy.code == 2 || minproxy.code == 1)
				{
					return minproxy;
				}
				return null;
			}
			catch
			{
				return null;
			}
		}

		public Minproxy NewIP_dancu()
		{
			string url = "https://dash.minproxy.vn/api/rotating/v1/proxy_v4/get-new-proxy?api_key=" + apiKey;
			string text = Get_html(url);
			try
			{
				if (text.Contains("error"))
				{
					return null;
				}
				Minproxy minproxy = JsonConvert.DeserializeObject<Minproxy>(text);
				if (minproxy.code == 2 || minproxy.code == 1)
				{
					return minproxy;
				}
				return null;
			}
			catch
			{
				return null;
			}
		}

		public Minproxy CheckIP_V6()
		{
			string url = "https://dash.minproxy.vn/api/rotating/v1/proxy/get-current-proxy?api_key=" + apiKey;
			string text = Get_html(url);
			try
			{
				if (text.Contains("error"))
				{
					return null;
				}
				Minproxy minproxy = JsonConvert.DeserializeObject<Minproxy>(text);
				if (minproxy.code == 2 || minproxy.code == 1)
				{
					return minproxy;
				}
				return null;
			}
			catch
			{
				return null;
			}
		}

		public Minproxy NewIP_V6()
		{
			string url = "https://dash.minproxy.vn/api/rotating/v1/proxy/get-new-proxy?api_key=" + apiKey;
			string text = Get_html(url);
			try
			{
				if (text.Contains("error"))
				{
					return null;
				}
				Minproxy minproxy = JsonConvert.DeserializeObject<Minproxy>(text);
				if (minproxy.code == 2 || minproxy.code == 1)
				{
					return minproxy;
				}
				return null;
			}
			catch
			{
				return null;
			}
		}
	}
}
