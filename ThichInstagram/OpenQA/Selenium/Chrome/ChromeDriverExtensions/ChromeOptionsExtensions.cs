using System;
using System.IO;
using System.IO.Compression;

namespace OpenQA.Selenium.Chrome.ChromeDriverExtensions
{
	public static class ChromeOptionsExtensions
	{
		private const string background_js = "\r\nvar config = {\r\n\tmode: \"fixed_servers\",\r\n    rules: {\r\n        singleProxy: {\r\n            scheme: \"http\",\r\n            host: \"{HOST}\",\r\n            port: parseInt({PORT})\r\n        },\r\n        bypassList: []\r\n\t}\r\n};\r\nchrome.proxy.settings.set({ value: config, scope: \"regular\" }, function() { });\r\nfunction callbackFn(details)\r\n{\r\n\treturn {\r\n\t\tauthCredentials:\r\n\t\t{\r\n\t\t\tusername: \"{USERNAME}\",\r\n\t\t\tpassword: \"{PASSWORD}\"\r\n\t\t}\r\n\t};\r\n}\r\nchrome.webRequest.onAuthRequired.addListener(\r\n\tcallbackFn,\r\n\t{ urls:[\"<all_urls>\"] },\r\n    ['blocking']\r\n);";

		private const string manifest_json = "\r\n{\r\n    \"version\": \"1.0.0\",\r\n    \"manifest_version\": 2,\r\n    \"name\": \"Chrome Proxy\",\r\n    \"permissions\": [\r\n        \"proxy\",\r\n        \"tabs\",\r\n        \"unlimitedStorage\",\r\n        \"storage\",\r\n        \"<all_urls>\",\r\n        \"webRequest\",\r\n        \"webRequestBlocking\"\r\n    ],\r\n    \"background\": {\r\n        \"scripts\": [\"background.js\"]\r\n\t},\r\n    \"minimum_chrome_version\":\"22.0.0\"\r\n}";

		public static void AddHttpProxy(this ChromeOptions options, string host, int port, string userName, string password)
		{
			string contents = ReplaceTemplates("\r\nvar config = {\r\n\tmode: \"fixed_servers\",\r\n    rules: {\r\n        singleProxy: {\r\n            scheme: \"http\",\r\n            host: \"{HOST}\",\r\n            port: parseInt({PORT})\r\n        },\r\n        bypassList: []\r\n\t}\r\n};\r\nchrome.proxy.settings.set({ value: config, scope: \"regular\" }, function() { });\r\nfunction callbackFn(details)\r\n{\r\n\treturn {\r\n\t\tauthCredentials:\r\n\t\t{\r\n\t\t\tusername: \"{USERNAME}\",\r\n\t\t\tpassword: \"{PASSWORD}\"\r\n\t\t}\r\n\t};\r\n}\r\nchrome.webRequest.onAuthRequired.addListener(\r\n\tcallbackFn,\r\n\t{ urls:[\"<all_urls>\"] },\r\n    ['blocking']\r\n);", host, port, userName, password);
			if (!Directory.Exists("Plugins"))
			{
				Directory.CreateDirectory("Plugins");
			}
			string text = Guid.NewGuid().ToString();
			string text2 = "Plugins/manifest_" + text + ".json";
			string text3 = "Plugins/background_" + text + ".js";
			string text4 = "Plugins/proxy_auth_plugin_" + text + ".zip";
			File.WriteAllText(text2, "\r\n{\r\n    \"version\": \"1.0.0\",\r\n    \"manifest_version\": 2,\r\n    \"name\": \"Chrome Proxy\",\r\n    \"permissions\": [\r\n        \"proxy\",\r\n        \"tabs\",\r\n        \"unlimitedStorage\",\r\n        \"storage\",\r\n        \"<all_urls>\",\r\n        \"webRequest\",\r\n        \"webRequestBlocking\"\r\n    ],\r\n    \"background\": {\r\n        \"scripts\": [\"background.js\"]\r\n\t},\r\n    \"minimum_chrome_version\":\"22.0.0\"\r\n}");
			File.WriteAllText(text3, contents);
			using (ZipArchive destination = ZipFile.Open(text4, ZipArchiveMode.Create))
			{
				destination.CreateEntryFromFile(text2, "manifest.json");
				destination.CreateEntryFromFile(text3, "background.js");
			}
			File.Delete(text2);
			File.Delete(text3);
			options.AddExtension(text4);
		}

		private static string ReplaceTemplates(string str, string host, int port, string userName, string password)
		{
			return str.Replace("{HOST}", host).Replace("{PORT}", port.ToString()).Replace("{USERNAME}", userName)
				.Replace("{PASSWORD}", password);
		}
	}
}
