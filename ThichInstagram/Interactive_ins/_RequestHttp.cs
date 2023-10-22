using System.Net;
using System.Text;
using HttpRequest;

namespace Interactive_ins
{
	public class _RequestHttp
	{
		private RequestHTTP request;

		public _RequestHttp()
		{
			string text = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.131 Safari/537.36";
			request = new RequestHTTP();
			request.SetSSL(SecurityProtocolType.Tls12);
			request.SetKeepAlive(k: true);
			request.SetDefaultHeaders(new string[2]
			{
				"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
				"user-agent: " + text
			});
		}

		public string RequestPost(string url, string data = "")
		{
			return request.Request("POST", url, null, Encoding.ASCII.GetBytes(data)).ToString();
		}
	}
}
