using Newtonsoft.Json;

namespace Interactive_ins
{
    public class API_Tinsoft
	{
		private string apiKey { get; set; }

		public API_Tinsoft(string apiKey)
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

		public check_ip checkip()
		{
			string url = "http://proxy.tinsoftsv.com/api/getProxy.php?key=" + apiKey;
			string value = Get_html(url);
			try
			{
				check_ip check_ip2 = JsonConvert.DeserializeObject<check_ip>(value);
				if (check_ip2.success)
				{
					check_ip check_ip3 = new check_ip();
					check_ip3.success = check_ip2.success;
					check_ip3.proxy = check_ip2.proxy;
					check_ip3.next_change = check_ip2.next_change;
					check_ip3.timeout = check_ip2.timeout;
					return check_ip3;
				}
				check_ip check_ip4 = new check_ip();
				check_ip4.success = check_ip2.success;
				check_ip4.description = check_ip2.description;
				return check_ip4;
			}
			catch
			{
				return null;
			}
		}

		public new_IP NewIP()
		{
			string url = "http://proxy.tinsoftsv.com/api/changeProxy.php?key=" + apiKey + "&location=0";
			string value = Get_html(url);
			try
			{
				new_IP new_IP2 = JsonConvert.DeserializeObject<new_IP>(value);
				if (new_IP2.success)
				{
					new_IP new_IP3 = new new_IP();
					new_IP3.success = new_IP2.success;
					new_IP3.proxy = new_IP2.proxy;
					new_IP3.next_change = new_IP2.next_change;
					new_IP3.timeout = new_IP2.timeout;
					return new_IP3;
				}
				new_IP new_IP4 = new new_IP();
				new_IP4.success = new_IP2.success;
				new_IP4.description = new_IP2.description;
				return new_IP4;
			}
			catch
			{
				return null;
			}
		}
	}
}
