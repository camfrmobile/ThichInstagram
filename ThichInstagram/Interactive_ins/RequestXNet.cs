

using xNet;

namespace Interactive_ins
{
	public class RequestXNet
	{
		public xNet.HttpRequest request;

		public RequestXNet(string userAgent)
		{
			if (userAgent == "")
			{
				userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.131 Safari/537.36";
			}
			request = new xNet.HttpRequest
			{
				KeepAlive = true,
				AllowAutoRedirect = true,
				Cookies = new CookieDictionary(),
				UserAgent = userAgent
			};
			request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
			request.AddHeader("Accept-Language", "en-US,en;q=0.9");
		}

		public string RequestPost(string url, string data = "", string contentType = "application/x-www-form-urlencoded")
		{
			if (data == "" || contentType == "")
			{
				return request.Post(url).ToString();
			}
			return request.Post(url, data, contentType).ToString();
		}

		public string RequestGet(string url)
		{
			return request.Get(url).ToString();
		}
	}
}
