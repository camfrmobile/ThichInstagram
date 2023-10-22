using Newtonsoft.Json;
 

namespace Interactive_ins
{
	public class ShopLike
	{
		private string Token = null;

		public ShopLike(string Token)
		{
			this.Token = Token;
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

		public new_IP_Shoplike NewIP()
		{
			string url = "http://proxy.shoplike.vn/Api/getNewProxy?access_token=" + Token;
			string value = Get_html(url);
			try
			{
				return JsonConvert.DeserializeObject<new_IP_Shoplike>(value);
			}
			catch
			{
				return null;
			}
		}
	}
}
