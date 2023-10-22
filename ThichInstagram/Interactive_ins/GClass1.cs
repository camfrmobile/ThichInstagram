using System;
using System.Globalization;
using System.Net;
using System.Net.Cache;
using System.Windows.Forms;
 

namespace Interactive_ins
{
	public static class GClass1
	{
		public static int method1(string import)
		{
			try
			{
				time();
				return 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi xảy ra vui lòng nhập lại ! (2) \n " + ex.Message);
				Environment.Exit(0);
				return 1;
			}
		}

		private static DateTime time()
		{
			try
			{
				DateTime minValue = DateTime.MinValue;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
				httpWebRequest.Method = "GET";
				httpWebRequest.Accept = "text/html, application/xhtml+xml, */*";
				httpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				httpWebRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				if (httpWebResponse.StatusCode == System.Net.HttpStatusCode.OK)
				{
					string s = httpWebResponse.Headers["date"];
					return DateTime.ParseExact(s, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
				}
				return DateTime.Now;
			}
			catch
			{
				return DateTime.Now;
			}
		}

		private static string Get_html(string url)
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
	}
}
