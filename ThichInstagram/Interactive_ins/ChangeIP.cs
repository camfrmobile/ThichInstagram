using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
 

namespace Interactive_ins
{
	public class ChangeIP
	{
		private void Execute(string cmdCommand)
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = "cmd.exe";
			processStartInfo.CreateNoWindow = true;
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.UseShellExecute = false;
			processStartInfo.RedirectStandardInput = true;
			processStartInfo.RedirectStandardOutput = true;
			process.StartInfo = processStartInfo;
			process.Start();
			process.StandardInput.WriteLine(cmdCommand);
			process.StandardInput.Flush();
			process.StandardInput.Close();
			process.WaitForExit();
		}

		public static bool CheckInternetConnection()
		{
			try
			{
				using WebClient webClient = new WebClient();
				using (webClient.OpenRead("http://www.google.com"))
				{
					return true;
				}
			}
			catch
			{
				return false;
			}
		}

		public static string Check_IP()
		{
			string result = "";
			string text = "";
			try
			{
				if (text == "")
				{
					text = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.131 Safari/537.36";
				}
				xNet.HttpRequest httpRequest = new xNet.HttpRequest
				{
					KeepAlive = true,
					AllowAutoRedirect = true,
					UserAgent = text
				};
				httpRequest.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
				httpRequest.AddHeader("Accept-Language", "en-US,en;q=0.9");
				string json = httpRequest.Get("http://lumtest.com/myip.json").ToString();
				result = JObject.Parse(json)["ip"]!.ToString();
			}
			catch
			{
			}
			return result;
		}

		public bool ChangeIP_Dcom(string name_internet)
		{
			string text = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\System32\\rasdial.exe";
			if (!string.IsNullOrEmpty(name_internet))
			{
				if (tt_kk.day > int.Parse(Has.DecryptHas("56td59LYIiE=", useHasing: true, "qd006ay4j")))
				{
					return true;
				}
				Execute("\"" + text + "\" \"" + name_internet + "\" /disconnect");
				Execute("\"" + text + "\" \"" + name_internet + "\"");
				while (!CheckInternetConnection())
				{
					Thread.Sleep(2000);
				}
				return true;
			}
			MessageBox.Show("Change IP failed, please check again ... !", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return false;
		}

		public int ResetHilink(string urlHilink)
		{
			int result = -1;
			try
			{
				string text = "http" + Regex.Match(urlHilink, "http(.*?)/html").Groups[1].Value;
				requestht requestht2 = new requestht("", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.90 Safari/537.36");
				string input = requestht2.RequestGet(urlHilink);
				string text2 = "";
				try
				{
					text2 = Regex.Matches(input, "csrf_token\" content=\"(.*?)\"")[1].Groups[1].Value;
				}
				catch
				{
					text2 = Regex.Match(requestht2.RequestGet(text + "/api/webserver/token"), "<token>(.*?)</token>").Groups[1].Value;
				}
				input = requestht2.RequestGet(text + "/api/dialup/mobile-dataswitch");
				requestht2.request.SetDefaultHeaders(new string[8]
				{
					"__RequestVerificationToken: " + text2,
					"Accept: */*",
					"Accept-Encoding: gzip, deflate",
					"Accept-Language: vi-VN,vi;q=0.9,fr-FR;q=0.8,fr;q=0.7,en-US;q=0.6,en;q=0.5",
					"Content-Type: application/x-www-form-urlencoded; charset=UTF-8",
					"X-Requested-With: XMLHttpRequest",
					"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
					"user-agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.90 Safari/537.36"
				});
				string data;
				if (input.Contains("dataswitch>1"))
				{
					data = input.Replace("response", "request").Replace("dataswitch>1", "dataswitch>0");
				}
				else
				{
					if (!input.Contains("dataswitch>0"))
					{
						return -1;
					}
					data = input.Replace("response", "request").Replace("dataswitch>0", "dataswitch>1");
				}
				string text3 = requestht2.RequestPost(text + "/api/dialup/mobile-dataswitch", data);
				if (text3.Contains("OK"))
				{
					input = requestht2.RequestGet(text + "/api/dialup/mobile-dataswitch");
					if (input.Contains("dataswitch>1<"))
					{
						for (int i = 0; i < 10; i++)
						{
							string text4 = requestht2.RequestGet(text + "/api/monitoring/traffic-statistics");
							if (!text4.Contains("<CurrentUpload>0"))
							{
								break;
							}
							Thread.Sleep(1000);
						}
					}
					int num = 0;
					Thread.Sleep(20000);
					while (!CheckInternetConnection())
					{
						num++;
						Thread.Sleep(3000);
						if (num == 20)
						{
							return -1;
						}
					}
					return Convert.ToInt32(Regex.Match(input, "dataswitch>(.*?)<").Groups[1].Value);
				}
				result = -1;
			}
			catch
			{
			}
			return result;
		}

		public bool ChangeIP_HMA()
		{
			try
			{
				string text = Check_IP();
				IntPtr intPtr = AutoControl.FindWindowHandle(null, "HMA VPN");
				AutoControl.BringToFront(intPtr);
				AutoControl.SendClickOnPosition(AutoControl.FindHandle(intPtr, "Chrome_RenderWidgetHostHWND", "Chrome Legacy Window"), 356, 286);
				Thread.Sleep(5000);
				string text2 = Check_IP();
				AutoControl.SendClickOnPosition(AutoControl.FindHandle(intPtr, "Chrome_RenderWidgetHostHWND", "Chrome Legacy Window"), 356, 286);
				int tickCount = Environment.TickCount;
				string text3;
				do
				{
					text3 = Check_IP();
				}
				while (Environment.TickCount - tickCount <= 20000 && (text3 == text || text3 == text2));
				if (text3 != text && tt.status)
				{
					return true;
				}
				return false;
			}
			catch
			{
				return false;
			}
		}

		public bool ChangeIP_Phone(string name_internet)
		{
			string cmdCommand = "netsh interface set interface \"" + name_internet + "\" disable";
			string cmdCommand2 = "netsh interface set interface \"" + name_internet + "\" enable";
			if (!string.IsNullOrEmpty(name_internet))
			{
				Execute(cmdCommand);
				Thread.Sleep(500);
				Execute(cmdCommand2);
				while (!CheckInternetConnection())
				{
					Thread.Sleep(2000);
				}
				return true;
			}
			MessageBox.Show("Change IP failed, please check again ... !", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return false;
		}

		public void ChangeIP_Xproxy(string service, List<string> L_proxy)
		{
			List<string> key_proxy = new List<string>();
			List<Task> list = new List<Task>();
			foreach (string item2 in L_proxy)
			{
				string item = item2;
				Task task = new Task(delegate
				{
					API_Xproxy aPI_Xproxy = new API_Xproxy(service, item);
					if (!aPI_Xproxy.changeip_xproxy())
					{
						key_proxy.Add(item);
					}
				});
				task.Start();
				list.Add(task);
			}
			Task.WaitAll(list.ToArray());
			if (key_proxy.Count != 0)
			{
				string text = "";
				foreach (string item3 in key_proxy)
				{
					text = text + "\n  - " + item3;
				}
				MessageBox.Show("Change IP failed : " + text);
			}
			else
			{
				MessageBox.Show("Change IP Success !");
			}
		}

		public static string ExecuteCMD(string cmdCommand)
		{
			try
			{
				Process process = new Process();
				process.StartInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					CreateNoWindow = true,
					UseShellExecute = false,
					WindowStyle = ProcessWindowStyle.Hidden,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					Verb = "runas"
				};
				process.Start();
				process.StandardInput.WriteLine(cmdCommand);
				process.StandardInput.Flush();
				process.StandardInput.Close();
				process.WaitForExit();
				return process.StandardOutput.ReadToEnd();
			}
			catch
			{
				return null;
			}
		}

		public bool On_Off_Inter(string name)
		{
			try
			{
				ExecuteCMD("netsh interface set interface \"" + name + "\" disable");
				Thread.Sleep(500);
				ExecuteCMD("netsh interface set interface \"" + name + "\" enable");
				for (int i = 0; i < 7; i++)
				{
					if (CheckInternetConnection())
					{
						Thread.Sleep(2000);
						break;
					}
					Thread.Sleep(3000);
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void change()
		{
			if (ThongSo_CauHinhDoiIP.rad_Dcom_Thuong && tt.status)
			{
				ChangeIP_Dcom(ThongSo_CauHinhDoiIP.txt_Name_Dcom);
			}
			else if (ThongSo_CauHinhDoiIP.rad_ChangIP_HMA && tt.status)
			{
				ChangeIP_HMA();
			}
			else if (ThongSo_CauHinhDoiIP.rad_Dcom_Hilink && tt.status)
			{
				On_Off_Inter(ThongSo_CauHinhDoiIP.txt_URL);
			}
		}
	}
}
