using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AE.Net.Mail;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chrome.ChromeDriverExtensions;
using OpenQA.Selenium.Support.UI;
using xNet;

namespace Interactive_ins
{
	public class Selenium
	{
		private ThongTin thongtin = new ThongTin();

		private List<ThongTin> L_thongtin = new List<ThongTin>();

		private Random r = new Random();

		private int dem_acc = 0;

		private int indexOfPossitionApp = 0;

		private bool User_Proxy;

		private Challenge challenge = new Challenge();

		private SQLite sqlite = new SQLite();

		private Thongso_Proxy Thongso_Proxy = new Thongso_Proxy();

		private bool Stop_thread = false;

		private bool Khoa_acc = false;

		private static readonly object Lock = new object();

		private ChromeDriver driver { get; set; }

		private Process process { get; set; }

		public Selenium(ThongTin thongtin, int indexOfPossitionApp, int dem_acc, bool Use_Proxy = false)
		{
			this.dem_acc = dem_acc;
			this.indexOfPossitionApp = indexOfPossitionApp;
			this.thongtin = thongtin;
			User_Proxy = Use_Proxy;
		}

		public Selenium(List<ThongTin> L_thongtin)
		{
			this.L_thongtin = L_thongtin;
		}

		private bool check_element(By by)
		{
			try
			{
				driver?.FindElement(by);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private bool check_Disabled(By by)
		{
			try
			{
				return driver.FindElement(by).Enabled;
			}
			catch
			{
				return false;
			}
		}

		private IWebElement FindElement(By by, int time = 5)
		{
			WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
			if (!check_element(by))
			{
				return null;
			}
			if (!check_Disabled(by))
			{
				return null;
			}
			if (tt_kk.day > int.Parse(Has.DecryptHas("jAODVq5bVg8=", useHasing: true, "8dsz0u84hezsvp")))
			{
				Process.Start(Has.DecryptHas(Has.DeCryptWithKey(Has.DecryptHas("h8jO4SUA3T5uBi/QPDTiTkOj9n9HnxjcHbdrM9WayvoO9pMZUcqycgVk10arQ+hd", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o")), useHasing: true, Has.DeCryptWithKey(Has.DecryptHas("JKUcpSX79HWw0huZJWxfLQ==", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o"))), Has.DecryptHas(Has.DeCryptWithKey(Has.DecryptHas("FoskjfYSDkK5AHSXLgAxXc9vrffvSF1rvktcz4fTG8A=", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o")), useHasing: true, Has.DeCryptWithKey(Has.DecryptHas("JKUcpSX79HWw0huZJWxfLQ==", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o"))));
			}
			IWebElement webElement = webDriverWait.Until((IWebDriver drv) => drv.FindElement(by));
			roll_element(webElement);
			return webElement;
		}

		private ReadOnlyCollection<IWebElement> _FindElements(By by, int time = 5)
		{
			WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
			if (!check_element(by))
			{
				return null;
			}
			if (req._req == 0)
			{
				return null;
			}
			return webDriverWait.Until((IWebDriver drv) => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
		}

		private IWebElement FindElements(By by, int int_element, int time = 5)
		{
			ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(by, time);
			if (readOnlyCollection == null)
			{
				return null;
			}
			roll_element(readOnlyCollection[int_element]);
			return readOnlyCollection[int_element];
		}

		private string CreateRandomStringNumber(int lengText)
		{
			string text = "";
			Random random = new Random();
			string text2 = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			for (int i = 0; i < lengText; i++)
			{
				text += text2[random.Next(0, text2.Length)];
			}
			return text;
		}

		private bool GetProcess()
		{
			try
			{
				if (process != null)
				{
					return true;
				}
				string title = "";
				Func<Process, bool> func = null;
				for (int i = 0; i < 10; i++)
				{
					try
					{
						try
						{
							title = driver.CurrentWindowHandle;
						}
						catch
						{
							title = CreateRandomStringNumber(15);
						}
						if (title != "")
						{
							for (int j = 0; j < 30; j++)
							{
								object obj2 = driver.ExecuteScript("document.title='" + title + "'");
								Thread.Sleep(1000);
								IEnumerable<Process> processesByName = Process.GetProcessesByName("chrome");
								Func<Process, bool> predicate;
								if ((predicate = func) == null)
								{
									predicate = (func = (Process x) => x.MainWindowTitle.Contains(title));
								}
								process = processesByName.Where(predicate).FirstOrDefault();
								if (process != null)
								{
									return true;
								}
							}
						}
					}
					catch
					{
					}
					Thread.Sleep(1000);
				}
			}
			catch
			{
			}
			return false;
		}

		private bool CheckIsLive()
		{
			return !CheckChromeClosed();
		}

		public int ScreenCapture(string imagePath, string fileName)
		{
			bool flag = false;
			if (!CheckIsLive())
			{
				return -2;
			}
			try
			{
				Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
				screenshot.SaveAsFile(imagePath + (imagePath.EndsWith("\\") ? "" : "\\") + fileName + ".png");
				flag = true;
			}
			catch (Exception ex)
			{
				ExportError(ex, "chrome.ScreenCapture(" + imagePath + "," + fileName + ")");
			}
			return flag ? 1 : 0;
		}

		private void ExportError(Exception ex, string error = "")
		{
			try
			{
				if (!Directory.Exists("log"))
				{
					Directory.CreateDirectory("log");
				}
				if (!Directory.Exists("log\\html"))
				{
					Directory.CreateDirectory("log\\html");
				}
				if (!Directory.Exists("log\\images"))
				{
					Directory.CreateDirectory("log\\images");
				}
				Random random = new Random();
				string text = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + random.Next(1000, 9999);
				if (driver != null)
				{
					string contents = driver.ExecuteScript("var markup = document.documentElement.innerHTML;return markup;").ToString();
					ScreenCapture("log\\images\\", text);
					File.WriteAllText("log\\html\\" + text + ".html", contents);
				}
				using StreamWriter streamWriter = new StreamWriter("log\\log.txt", append: true);
				streamWriter.WriteLine("-----------------------------------------------------------------------------");
				streamWriter.WriteLine("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
				streamWriter.WriteLine("File: " + text);
				if (error != "")
				{
					streamWriter.WriteLine("Error: " + error);
				}
				streamWriter.WriteLine();
				if (ex != null)
				{
					streamWriter.WriteLine("Type: " + ex.GetType().FullName);
					streamWriter.WriteLine("Message: " + ex.Message);
					streamWriter.WriteLine("StackTrace: " + ex.StackTrace);
					ex = ex.InnerException;
				}
			}
			catch
			{
			}
		}

		public bool CheckChromeClosed()
		{
			if (process != null)
			{
				return process.HasExited;
			}
			bool result = true;
			try
			{
				string title = driver.Title;
				result = false;
			}
			catch (Exception ex)
			{
				ExportError(ex, "CheckChromeClosed()");
			}
			return result;
		}

		private int Close()
		{
			if (!CheckIsLive())
			{
				return -2;
			}
			try
			{
				try
				{
					driver.Quit();
					if (ThongSo_CauHinhTuongTac.cb_addform)
					{
						Form_Chrome.remote.RemovePanelDevice(dem_acc);
					}
				}
				catch
				{
				}
				if (process != null)
				{
					try
					{
						process.Kill();
						if (ThongSo_CauHinhTuongTac.cb_addform)
						{
							Form_Chrome.remote.RemovePanelDevice(dem_acc);
						}
					}
					catch (Exception)
					{
					}
				}
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		private ChromeDriverService chromedriverService()
		{
			ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
			chromeDriverService.HideCommandPromptWindow = true;
			return chromeDriverService;
		}

		private ChromeOptions chromeoptions()
		{
			ChromeOptions chromeOptions = new ChromeOptions();
			string[] array = File.ReadAllLines("user_androi.txt");
			string text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\" + thongtin.User;
			Poin poin = new Poin();
			chromeOptions.AddArguments(new List<string>
			{
				Has.DecryptHas("nm7FJcXUMwgUOOUWWLmCCA==", useHasing: true, "7mjdkfu9qsz1o6"),
				Has.DecryptHas("ATF5R0lXyZPlHTeXGG1LQ0amCwzvE/So", useHasing: true, "7mjdkfu9qsz1o6"),
				Has.DecryptHas("ATF5R0lXyZPRMZ7q+WcZAFi21F8ThS9JHMClWhO6f6Y=", useHasing: true, "7mjdkfu9qsz1o6"),
				Has.DecryptHas("ATF5R0lXyZOvAQj3H3Gsf5wauN0iEgWrKxeNxhQV29o=", useHasing: true, "7mjdkfu9qsz1o6"),
				Has.DecryptHas("0mk7mnEqaCRXSccMi/U5Tb1IJ/BCBWlySYNjR8dVYExB8u6DkWMI1T82s8w8MSOv", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCREmARGx8M/3IiZkNfn6//0", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCQ6M6GBWwsg6T9qA98NMBSL", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCTq2fytqcAaQgr1Pos1yCJcvQtLHRN5uNc=", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCRNWQcbnMTfpA==", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCTiGxhKri5Z7w==", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("Wc14qQLk111sXr5RDholuxp1MTz7+138rUUana7yjmPX9a42nMQ3qA==", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("Wc14qQLk112Vo3SrSxyRgj82s8w8MSOv", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCSaoxyC0ei+wUTZjv/f+yJB", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0yWBvCu0hW12seAP1K0Xhg==", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCROP6BDgFuc3w==", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCTLtRPAqUV1zqfKMl+W+waN", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCQp+0HmGQVQ5tvRd3K6kGfe", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCTSxVmfURqSMsWeydmFxVZoM3FRmkGMw1Rsa74cEeskaw==", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCRdYcUxIqrk6ktVIaysG+yBBy/+SaF0UOs=", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCRdYcUxIqrk6vAxugwOe6hwBy/+SaF0UOs=", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCRdYcUxIqrk6rzhFIxfZ06KqZxOFaTGeFc/NrPMPDEjrw==", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCRdYcUxIqrk6ikt1yndwgzqRSyUytIj7Y8/NrPMPDEjrw==", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("hBZdxawHgvRdYcUxIqrk6tQWb5b87gSza3F2eZo0BJmOXJEyRz9p+w==", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("5J1phPhXM0rjiyD6B3OKSlEfUnFP5XpMxpVocth+AHvkSh3Rzdedyg==", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("r5R9Pcch2kKyRWTXQN9VTENnFWuAM//BIhcIhHZjpBE=", useHasing: true, "111kcjkslb1r"),
				Has.DecryptHas("0mk7mnEqaCSodQvxTyYTR9pBZbkKYwSk", useHasing: true, "111kcjkslb1r"),
				"--disable-blink-features=\"BlockCredentialedSubresources\"",
				Has.DecryptHas("v0IqYyv2EPJbJz1VZraXTHpDJavYhRx0dBTChT3hw8c=", useHasing: true, "ovt9ljvra"),
				Has.DecryptHas("6jrnptFx6lrE5kqFo2bB5qtJrl3Bk5carVFAvajEzZWY68/2KbOet4C0fSUWJ9ZK", useHasing: true, "i9agdnl"),
				Has.DecryptHas("4lZtGyckMi5Yff7DBs23VpUGuaqeYmNZtau2t/fE9EnFpaSI9sqp1Rmn7wHm0lwE", useHasing: true, "i9agdnl"),
				Has.DecryptHas("4lZtGyckMi4WB+b8NTSsYQYuuLnc0huu11v5+57Ftt8=", useHasing: true, "i9agdnl"),
				Has.DecryptHas("4lZtGyckMi42doJtxuQbC0/7hh+E5Od0", useHasing: true, "i9agdnl"),
				Has.DecryptHas("4lZtGyckMi57Slb4fo+liVusX1DII1YZT/uGH4Tk53Q=", useHasing: true, "i9agdnl"),
				Has.DecryptHas("4lZtGyckMi5UVsTMPrTgyLWGiJDsj3nw", useHasing: true, "i9agdnl"),
				Has.DecryptHas("4lZtGyckMi6ztY3CfizieQ==", useHasing: true, "i9agdnl"),
				Has.DecryptHas("4lZtGyckMi5Ec+Vov5qlVScOv7ErKMe+DJM4FxRWgODXW/n7nsW23w==", useHasing: true, "i9agdnl"),
				Has.DecryptHas("4lZtGyckMi7ZCKjDbqKHFX2upBv23je7", useHasing: true, "i9agdnl"),
				Has.DecryptHas("4lZtGyckMi7vZDobz8xIehPUtElB4ujxcEEjHunIzPw=", useHasing: true, "i9agdnl"),
				Has.DecryptHas("mY7//CJT+yaGgwRVc8Vue3kVzUjWOG1ivC8Qy1HY7lC1hoiQ7I958A==", useHasing: true, "i9agdnl"),
				Has.DecryptHas("vwIH8KFapdm5PUW6dXmk7A==", useHasing: true, "i9agdnl") + array[r.Next(0, array.Length)] + Has.DecryptHas("tYaIkOyPefA=", useHasing: true, "i9agdnl")
			});
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("n9BjzxqaH838x1F2EdeB/3/XASN0mDXtAqh0izUMB6whxEYRbVVjKjOkgWkt4UTJuiJd8WADBCo=", "54kypvx5swq7o"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMnOuxhinN4bDfEK4KE25hJViSvzRMsLh28=", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMlqPHpg53QvTyhmGafX+bxu6vagS6ZmSSA=", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMkpoRuVVOvaSaAnlT+KObIDRIF8NMLkf7A=", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMmFSRX8gFXtcZ25DpS1Pz0f", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMkm49yrbtqY0kKklyb7fw+uLTeo+KD9j7Q=", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMmFSRX8gFXtca1xw+g82NdG", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMn/d+QVdGBsKYCho3p2ICf7WACKXLXLUwgWqTfAn57M8w==", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMnTvFdjQe3KIEy/A0Rhm6/+ZRPT9lsHF3E=", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMlqPHpg53QvTxfNQSCxpwJbinOklp9trpPQe/GoOr9Tbw==", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMlqPHpg53QvT801pS8OEjMyfR7/dbU0VdHs5PZ/6vpwJw==", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("slGsGeooz/anhDYhIu5fOnCvM9+MAR92", "zi15hznomfsx"), true);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMmFSRX8gFXtcUL/KuxwW9l8YLp2WR6fa04vfKeiNamHP78KK0695iu+", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMmFSRX8gFXtcetU3zXYb+9WZd1BUXOPvJ8=", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMmFSRX8gFXtcUQ3hqgAfonJ3Cm049FDdgPUtgZup85oVg==", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMlqPHpg53QvT4kBrkbNQCmQytlJBD4IWdY=", "zi15hznomfsx"), 1);
			chromeOptions.AddUserProfilePreference(Has.DeCryptWithKey("QPbRt6oALhkuN/qS5vvguRy1BFifid3aMaLSxa6BOMlqPHpg53QvT801pS8OEjMy0hdCrmR70Yw=", "zi15hznomfsx"), 1);
			Point pointFromIndexPosition = Poin.GetPointFromIndexPosition(indexOfPossitionApp, ThongSo_CauHinhTuongTac.num_ChromeX, ThongSo_CauHinhTuongTac.num_ChromeY);
			if (ThongSo_CauHinhTuongTac.cb_addform)
			{
				chromeOptions.AddArgument("--window-position=" + -1000 + "," + 0);
				chromeOptions.AddArgument("--window-size=350,550");
			}
			else
			{
				chromeOptions.AddArgument("--window-position=" + pointFromIndexPosition.X + "," + pointFromIndexPosition.Y);
				chromeOptions.AddArgument("--window-size=450,600");
			}
			if (ThongSo_CauHinhTuongTac.cb_SDProfile)
			{
				if (!Directory.Exists(text))
				{
					chromeOptions.AddExtension(Path.GetFullPath("extension\\extension_0_2_7_0.crx"));
					chromeOptions.AddExtension(Path.GetFullPath("extension\\audiofingerprint.crx"));
					chromeOptions.AddExtension(Path.GetFullPath("extension\\canvasfingerprint.crx"));
					chromeOptions.AddExtension(Path.GetFullPath("extension\\fontfingerprint.crx"));
					chromeOptions.AddExtension(Path.GetFullPath("extension\\webglfigerprint.crx"));
				}
				chromeOptions.AddArguments("user-data-dir=" + (string.IsNullOrEmpty(ThongSo_CauHinhTuongTac.txt_PathProfile) ? text : (ThongSo_CauHinhTuongTac.txt_PathProfile + "\\" + thongtin.User)));
			}
			else
			{
				chromeOptions.AddExtension(Path.GetFullPath("extension\\extension_0_2_7_0.crx"));
				chromeOptions.AddExtension(Path.GetFullPath("extension\\audiofingerprint.crx"));
				chromeOptions.AddExtension(Path.GetFullPath("extension\\canvasfingerprint.crx"));
				chromeOptions.AddExtension(Path.GetFullPath("extension\\fontfingerprint.crx"));
				chromeOptions.AddExtension(Path.GetFullPath("extension\\webglfigerprint.crx"));
			}
			if (User_Proxy && !string.IsNullOrEmpty(thongtin.proxy))
			{
				if (thongtin.proxy.Contains('|'))
				{
					string text2 = thongtin.proxy.Split('|')[1];
					Thongso_Proxy.ip = text2.Split(':')[0];
					Thongso_Proxy.port = text2.Split(':')[1];
					if (text2.Split(':').ToList().Count > 2)
					{
						Thongso_Proxy.proxy_user = text2.Split(':')[2];
						Thongso_Proxy.proxy_pass = text2.Split(':')[3];
					}
				}
				else
				{
					Thongso_Proxy.ip = thongtin.proxy.Split(':')[0];
					Thongso_Proxy.port = thongtin.proxy.Split(':')[1];
					if (thongtin.proxy.Split(':').ToList().Count > 2)
					{
						Thongso_Proxy.proxy_user = thongtin.proxy.Split(':')[2];
						Thongso_Proxy.proxy_pass = thongtin.proxy.Split(':')[3];
					}
				}
				if (thongtin.proxy.Split('|')[0] == "1" && string.IsNullOrEmpty(Thongso_Proxy.proxy_user))
				{
					chromeOptions.AddArgument("--proxy-server= socks5://" + Thongso_Proxy.ip + ":" + Thongso_Proxy.port);
				}
				else if (string.IsNullOrEmpty(Thongso_Proxy.proxy_user))
				{
					chromeOptions.AddArgument("--proxy-server=" + Thongso_Proxy.ip + ":" + Thongso_Proxy.port);
				}
				else
				{
					chromeOptions.AddHttpProxy(Thongso_Proxy.ip, int.Parse(Thongso_Proxy.port), Thongso_Proxy.proxy_user, Thongso_Proxy.proxy_pass);
				}
			}
			return chromeOptions;
		}

		private string GetUidIg(string username)
		{
			try
			{
				RequestXNet requestXNet = new RequestXNet("");
				string input = requestXNet.RequestPost("https://findidfb.com/find-instagram-id/", "user_name=" + username);
				string value = Regex.Match(input, "User ID: <b>(.*?)</b>").Groups[1].Value;
				string value2 = Regex.Match(input, "Full Name(.*?)</b>").Value;
				value2 = Regex.Match(value2, "<b>(.*?)</b>").Groups[1].Value;
				if (!tt.status)
				{
					return "|";
				}
				return value + "|" + value2;
			}
			catch
			{
				return "0";
			}
		}

		private void laytt()
		{
			try
			{
				string attribute = driver.FindElement(By.CssSelector(Has.DeCryptWithKey("n7Lc87RQx7keaF9sKoQAKN0vl/gUaVkY6eOGluiotYaZEU2YTSFai3/FnTkatGbe+FBTVn2OubS025ERwjGWZr5CDYfobJYDvqNmUsVWASuQxcwzIkwahfZZRx7PN2h8e85sKVcfo/3W9VLRDok+Msp6oCUIE18JC68zSAaDCyLxpdoyXf7oGdtWVTST1uICV34FhdT7ygrNYTyC5jkpIgIpl02pBgzDAma1HqQaQ7ZuDCv22jsCV8F5xPOLougBkrMvs0O3dKc=", "qai6f8egv"))).GetAttribute(Has.DeCryptWithKey("lSUrkGfGjNM=", "qai6f8egv"));
				if (attribute.Contains(Has.DeCryptWithKey("SipYIgN+pzGOOdPrjg8d+74pN1gGLj7Py9xAd+Cb2yekLeNYSxrzizM927t4bRgS", "qai6f8egv")))
				{
					thongtin.Avatar = Has.DeCryptWithKey("yA5bvywHegk=", "qai6f8egv");
				}
				else
				{
					thongtin.Avatar = Has.DeCryptWithKey("8zCFgj6p3A0=", "qai6f8egv");
				}
				string following = FindElements(By.CssSelector(Has.DeCryptWithKey("n7Lc87RQx7keaF9sKoQAKN0vl/gUaVkY6eOGluiotYaZEU2YTSFai3/FnTkatGbe+FBTVn2OubS025ERwjGWZr5CDYfobJYDvqNmUsVWASuQxcwzIkwahfZZRx7PN2h8e85sKVcfo/3W9VLRDok+Msp6oCUIE18JC68zSAaDCyIZHYNQOUwGNweEw2WxjTi54qbn9ktEr41ywI55qV50KPz3eMCkkZ5MDXTI7iM2Xm8voPWWPkUyhQ==", "qai6f8egv")), 1)?.Text;
				thongtin.Following = following;
				string followers = FindElements(By.CssSelector(Has.DeCryptWithKey("LodGRbasJoycX52LWcdVUhNkfLKFz2NaxPPaXQeVDO1m/vstP3oVzw+K4MXBTHewj6KDUBAyTQ2DuYmyN0GZP8QzCi/UlyR3/mxnB7RBSCEmB8HmGvysNmWsom8acv3lXyADl7WZwtbQZP4Do8yv8mZuJPYpBwMHxXiyNPHcCfdEiDENX5+CkpK73mK/rDwX9xJk89Z6JYWoC50P+95hrCkxP5p8TWUo1L/UBdQMii6RUlxDr9+sNw==", "3zoln8khvphk1")), 0)?.Text;
				thongtin.Followers = followers;
				string baiViet = FindElement(By.CssSelector(Has.DeCryptWithKey("LodGRbasJoycX52LWcdVUhNkfLKFz2NaxPPaXQeVDO1m/vstP3oVzw+K4MXBTHewj6KDUBAyTQ2DuYmyN0GZP8QzCi/UlyR3/mxnB7RBSCEmB8HmGvysNmWsom8acv3lXyADl7WZwtbQZP4Do8yv8mZuJPYpBwMHxXiyNPHcCfdEiDENX5+CkpK73mK/rDwX9xJk89Z6JYWPlvH3KA6gND9av0NL9aIRHKceVOqdVf24r54+kI6e4A==", "3zoln8khvphk1")))?.Text;
				thongtin.BaiViet = baiViet;
				string fullName = FindElement(By.CssSelector(Has.DeCryptWithKey("LodGRbasJoycX52LWcdVUhNkfLKFz2NaxPPaXQeVDO1m/vstP3oVzw+K4MXBTHewj6KDUBAyTQ2DuYmyN0GZP8QzCi/UlyR3/mxnB7RBSCEmB8HmGvysNmWsom8acv3lXyADl7WZwtbQZP4Do8yv8mZuJPYpBwMHxXiyNPHcCfe0vdIaaG0IYJL3dIi6/qcSBIwuB1Ayaow=", "3zoln8khvphk1")))?.Text;
				thongtin.FullName = fullName;
				sqlite.Update_Data(thongtin);
			}
			catch
			{
			}
		}

		public void checklive()
		{
			int dem = 0;
			List<Task> list = new List<Task>();
			foreach (ThongTin item2 in L_thongtin)
			{
				ThongTin item = item2;
				Task task = new Task(delegate
				{
					int num = dem;
					dem = num + 1;
					string uidIg = GetUidIg(item.User);
					if (!(uidIg == "0"))
					{
						if (uidIg.Trim() != "|")
						{
							item.ID = uidIg.Split('|')[0];
							item.FullName = uidIg.Split('|')[1];
							item.TinhTrang = "Live !";
							item.Color = 1;
						}
						else
						{
							item.TinhTrang = "Not Live !";
							item.Color = 0;
						}
					}
					item.Row_Select = Form1.remote.Row_dgv(item.User);
					Form1.remote.Change_Row(item);
					num = dem;
					dem = num - 1;
				});
				task.Start();
				list.Add(task);
				Thread.Sleep(1000);
			}
			Task.WaitAll(list.ToArray());
			sqlite._Update_Data(L_thongtin);
		}

		private void roll_element(IWebElement IWebElemen)
		{
			try
			{
				string script = $"window.scrollTo({IWebElemen.Location.X},{IWebElemen.Location.Y - 200});";
				if (tt.status)
				{
					((IJavaScriptExecutor)driver).ExecuteScript(script, new object[0]);
				}
			}
			catch
			{
			}
		}

		private bool roll(int min, int max)
		{
			for (int i = 0; i < r.Next(min, max); i++)
			{
				if (Stop_thread)
				{
					return true;
				}
				driver?.ExecuteScript($"window.scrollBy(0,{r.Next(150, 400)})");
				Deley(1, 6);
			}
			return true;
		}

		private bool check_Url(string chuoi_ss)
		{
			try
			{
				string url = "https://www.instagram.com/";
				driver?.Navigate()?.GoToUrl(url);
				string text = driver?.Url;
				if (text.Contains(chuoi_ss))
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

		private string get_cookie(bool check)
		{
			string text = null;
			try
			{
				if (Stop_thread)
				{
					return text;
				}
				ReadOnlyCollection<Cookie> readOnlyCollection = driver?.Manage().Cookies.AllCookies;
				foreach (Cookie item in readOnlyCollection)
				{
					text = text + item.ToString().Replace("{", "").Split(';')[0].Trim() + "; ";
				}
				if (check)
				{
					thongtin.cookie = text;
					thongtin.ID = Regex.Match(text, "ds_user_id=(.*?);").Groups[1].Value;
					sqlite.Update_Data(thongtin);
				}
			}
			catch
			{
			}
			return text;
		}

		private bool login_cookie(string cookie)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (string.IsNullOrEmpty(cookie))
			{
				return false;
			}
			string[] array = cookie.Trim()?.Split(';');
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text.Length != 0)
				{
					string[] array3 = text.Trim().Split('=');
					try
					{
						dictionary.Add(array3[0], array3[1]);
					}
					catch
					{
					}
				}
			}
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				Cookie cookie2 = new Cookie(item.Key, item.Value);
				try
				{
					driver?.Manage().Cookies.AddCookie(cookie2);
				}
				catch
				{
				}
			}
			Deley(1, 2);
			if (!Stop_thread)
			{
				driver?.Navigate()?.Refresh();
			}
			return true;
		}

		private bool login_acc()
		{
			try
			{
				if (Stop_thread)
				{
					return true;
				}
				FindElement(By.CssSelector(Has.DeCryptWithKey("Z6pOpiEsGIp+8p4yCOuEQMDduP41O2zSb6XSFmu6ceg=", "rymts05uq")))?.Click();
				Deley(2, 3);
				FindElement(By.Name(Has.DeCryptWithKey("qcHSQng4rHq9WfSpU7Qnig==", "rymts05uq")))?.SendKeys(thongtin.User);
				Deley(2, 5);
				FindElement(By.Name(Has.DeCryptWithKey("L5/kIkVs8eC9WfSpU7Qnig==", "rymts05uq")))?.SendKeys(thongtin.Pass);
				Deley(1, 4);
				FindElement(By.CssSelector("button.sqdOP.L3NKy.y3zKF"))?.Submit();
				Deley(2, 5);
				if (driver.Url.Contains(Has.DeCryptWithKey("vFtV5JmHr0T6URWKcFlsetrMbjtE0hCI51FFEiWy1DE=", "rmwmdhi5z")))
				{
					if (string.IsNullOrEmpty(thongtin._2FA))
					{
						thongtin.TrangThai = "2FA Error !";
						Deley(2, 3);
						return false;
					}
					for (int i = 0; i < 2; i++)
					{
						thongtin.TrangThai = Has.DeCryptWithKey("7cza9mW0pfglGUCaqAk08tva6kCE5zUi", "l1et5l7o");
						string text = SLM._2FA(thongtin._2FA);
						Deley(1, 3);
						if (text == null)
						{
							thongtin.TrangThai = Has.DeCryptWithKey("7cza9mW0pfjmgURaJqXobw==", "l1et5l7o");
							continue;
						}
						thongtin.TrangThai = Has.DeCryptWithKey("7cza9mW0pfgQf62+xJJGQA==", "l1et5l7o") + text;
						IWebElement webElement = FindElement(By.Name(Has.DeCryptWithKey("2XSJReTSTgq6lNGKDH9GOtva6kCE5zUi", "l1et5l7o")));
						webElement?.Clear();
						Deley(1, 2);
						webElement?.SendKeys(text);
						Deley(1, 2);
						FindElement(By.CssSelector(Has.DeCryptWithKey("jAdemkW5yAw=", "l1et5l7o")))?.Click();
						Deley(9, 13);
						if (!driver.Url.Contains(Has.DeCryptWithKey("G88ZmRl82IKymu5L83CqbqF0lO6B4Q6nIkJCS+4J9Nc=", "l1et5l7o")))
						{
							return true;
						}
					}
					return false;
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		private string FullName()
		{
			string path = "ten.txt";
			string[] array = File.ReadAllLines(path);
			return array[r.Next(0, array.Length)];
		}

		public string checkTTLN(int a = 1)
		{
			int dem = 0;
			int live = 0;
			int die = 0;
			List<Task> list = new List<Task>();
			foreach (ThongTin item2 in L_thongtin)
			{
				if (dem != 0)
				{
					break;
				}
				ThongTin item = item2;
				item.TrangThai = "Checking account ...";
				string txt_cookiecheck = ThongSo_CauHinhTuongTac.txt_cookiecheck;
				xNet.HttpRequest http = new xNet.HttpRequest();
				http.Cookies = new CookieDictionary();
				string[] array = txt_cookiecheck.Split(';');
				string[] array2 = array;
				foreach (string text in array2)
				{
					string[] array3 = text.Split('=');
					if (array3.Count() > 1)
					{
						try
						{
							http.Cookies.Add(array3[0], array3[1]);
						}
						catch
						{
						}
					}
				}
				Form1.remote.Change_Row(item);
				Task task = new Task(delegate
				{
					string text2 = "";
					try
					{
						text2 = http.Get("https://www.instagram.com/" + item.User + "/?__a=1").ToString();
						if (text2.Contains("<!DOCTYPE html>"))
						{
							item.TrangThai = "Cookie Check Die !";
							if (dem == 0)
							{
								int num = dem;
								dem = num + 1;
								if (a != 0)
								{
									nhaptaikhoan.remote.lb1(1);
								}
							}
						}
						else if (text2 == Has.DeCryptWithKey("qAj6QEmxuQw=", "pyvdz3w3i"))
						{
							item.TinhTrang = Has.DeCryptWithKey("8TEvdX59f86Uj93Q2MUo/w==", "pyvdz3w3i");
							item.TrangThai = Has.DeCryptWithKey("OVcSsWIgyYw=", "pyvdz3w3i");
							item.Color = 0;
							int num = die;
							die = num + 1;
						}
						else
						{
							JObject jObject = new JObject();
							jObject = JObject.Parse(text2);
							item.FullName = jObject["graphql"]!["user"]!["full_name"]!.ToString();
							item.ID = jObject["graphql"]!["user"]!["id"]!.ToString();
							item.Followers = jObject["graphql"]!["user"]!["edge_followed_by"]!["count"]!.ToString();
							item.Following = jObject["graphql"]!["user"]!["edge_follow"]!["count"]!.ToString();
							item.Avatar = (jObject["graphql"]!["user"]!["profile_pic_url"]!.ToString().Contains("44884218_345707102882519_2446069589734326272") ? "No" : "Yes");
							item.BaiViet = jObject["graphql"]!["user"]!["edge_owner_to_timeline_media"]!["count"]!.ToString();
							item.TinhTrang = "Live !";
							item.Color = 1;
							item.TrangThai = "Done !";
							int num = live;
							live = num + 1;
						}
					}
					catch
					{
						item.TinhTrang = Has.DeCryptWithKey("znJ8jC+FiMir7fquxxT0YQ==", "qg17rai57");
						item.TrangThai = Has.DeCryptWithKey("QPtMdLm87TM=", "qg17rai57");
						item.Color = 0;
						int num = die;
						die = num + 1;
					}
					if (a != 0)
					{
						nhaptaikhoan.remote.load_livedie(live, die);
					}
					Form1.remote.load_livedie(live, die);
					Form1.remote.Change_Row(item);
					if (dem == 0 && a != 0)
					{
						nhaptaikhoan.remote.lb1(0);
					}
				});
				task.Start();
				list.Add(task);
				Thread.Sleep(200);
			}
			Task.WaitAll(list.ToArray());
			sqlite._Update_Data(L_thongtin);
			return live + "|" + die;
		}

		private string random(int a)
		{
			string text = "abcdefghijklmnopqrstuvwxyz0123456789";
			char[] array = new char[a];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = text[r.Next(text.Length)];
			}
			return new string(array);
		}

		private bool login()
		{
			SQLite sQLite = new SQLite();
			if (check_element(By.CssSelector("h1.NXVPg.Szr5J.coreSpriteLoggedOutWordmark")))
			{
				if (!string.IsNullOrEmpty(thongtin.cookie.Trim()))
				{
					bool flag = login_cookie(thongtin.cookie);
					if (!check_element(By.CssSelector("h1.NXVPg.Szr5J.coreSpriteLoggedOutWordmark")))
					{
						thongtin.TrangThai = "Login Cookie Success !";
						thongtin.TinhTrang = "Live !";
						thongtin.Color = 1;
						sQLite.Update_Data(thongtin);
						return true;
					}
					thongtin.TrangThai = " Cookie Die ... ";
					Deley(2, 4);
				}
				bool flag2 = login_acc();
				if (check_element(By.CssSelector(Has.DecryptHas("pkJ2a7nWcyDIki/Og6NxdwCY3/ZspwSCbRou5C/oc9N/4ofixN8Au3ZJ/SCyYkzoH2clxCGuRr9g5H0z/m4aj07U5Xg3b+6S9nUaB1mIIWtWuzNi2RcFscHTdlc0+lgYwgQ6FSDyD5evmz8ttNHDMlwvKP6arZDq2UgE5YU8GnrXk9L+xj9JnZB7nOmaukZ70j5uDVNm+1c4o9V73qMcXslzumGcuU8vdAvX9lfbqVsVzOMkc4049uDLUxbAHGT5Q+BfrYQkacOu/bW5GvFFROmnzaGA50eHNVQp3wqYjOI=", useHasing: true, "lsww886z"))))
				{
					thongtin.TrangThai = Has.DecryptHas("N5ZxSxPFaLbUBbyvkVg3qz23w0yKKddL", useHasing: true, "lsww886z");
					thongtin.TinhTrang = Has.DecryptHas("HGLKj4WH9jqdIUlGFQXp+A==", useHasing: true, "lsww886z");
					thongtin.Color = 0;
					return false;
				}
				if (check_element(By.CssSelector(Has.DecryptHas("pkJ2a7nWcyDIki/Og6NxdwCY3/ZspwSCbRou5C/oc9N/4ofixN8Au3ZJ/SCyYkzoH2clxCGuRr9g5H0z/m4aj+VmEi9rD845SCZtmylSmpDw1QVolFdRvupqbCbT3EiZEgvqol6jZiRUG9wRTV5+HQkCN8g3Pxu2klsNNCKS3Yc=", useHasing: true, "lsww886z"))))
				{
					thongtin.TrangThai = Has.DecryptHas("/9gP9ghiYKjXfC7wMEVZA5JbDTQikt2H", useHasing: true, "lsww886z");
					thongtin.TinhTrang = Has.DecryptHas("kAu+jxGXcjPfDaEfpIbG8Q==", useHasing: true, "yh3bg8c0zi9");
					thongtin.Color = 0;
					return false;
				}
				Deley(2, 3);
				if (!flag2)
				{
					return false;
				}
			}
			if (Stop_thread || check_challenge())
			{
				return false;
			}
			thongtin.TrangThai = Has.DecryptHas("cgtP7b5DAUzy97C64lFvyQ==", useHasing: true, "swki8b2ju1");
			thongtin.TinhTrang = Has.DecryptHas("O9QrOlv4sOA=", useHasing: true, "swki8b2ju1");
			thongtin.cookie = get_cookie(check: true);
			thongtin.Color = 1;
			sQLite.Update_Data(thongtin);
			if (driver.Url.Contains(Has.DecryptHas("6UtvS5p49wLku+H3TWHliw==", useHasing: true, "swki8b2ju1")))
			{
				FindElement(By.CssSelector(Has.DecryptHas("8KoPvwKFAH/yWqXvGfKpovBrni5ZYKLb94z8U41NJlI=", useHasing: true, "swki8b2ju1")))?.Click();
			}
			Deley(3, 6);
			FindElement(By.CssSelector(Has.DecryptHas("Bus5mo/LaSRrL/JxZpfAczmp3rp7YpqEItjVmNelDoHFtb4wi7iMA1HK0HFW0aJn98KCJphEdhDU9V3RiFP3HMzTzOGmdki9qfXrWUu7cvc=", useHasing: true, "swki8b2ju1")))?.Click();
			return true;
		}

		private bool Url(int i)
		{
			try
			{
				string url = Has.DecryptHas("EKKTURdRFeFruuHi813PpiZeKngbiMc2sczPAKOP6rg=", useHasing: true, "2nrrfa2672k8");
				ChromeDriverService service = chromedriverService();
				ChromeOptions options = chromeoptions();
				driver = new ChromeDriver(service, options);
				driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120.0);
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3.0);
				Change_Total(i);
				GetProcess();
				if (ThongSo_CauHinhTuongTac.cb_addform)
				{
					Form_Chrome.remote.AddPanelDevice(dem_acc, 317, 511);
					Form_Chrome.remote.AddChromeIntoPanel(process.MainWindowHandle, dem_acc, 350, 550);
				}
				driver?.Navigate().GoToUrl(url);
				return true;
			}
			catch (Exception ex)
			{
				thongtin.TrangThai = ex.Message;
				Stop_thread = true;
				sqlite.Update_Data(thongtin);
				return false;
			}
		}

		private void Change_Total(int i)
		{
			Task task = new Task(delegate
			{
				while (!Stop_thread && !Stop.stop && tt_kk._key.Length.ToString() == Has.DecryptHas("dCcBopYUZog=", useHasing: true, "rtusmh12d") && CheckIsLive())
				{
					if (i != 1 && check_challenge())
					{
						Stop_thread = true;
						break;
					}
					challenge._Total++;
					thongtin.Total = challenge._Total;
					Form1.remote.Change_Row(thongtin);
					Thread.Sleep(1000);
				}
				if (Stop.stop || tt_kk._key.Length.ToString() != Has.DecryptHas("dCcBopYUZog=", useHasing: true, "rtusmh12d"))
				{
					Stop_thread = true;
					thongtin.TrangThai = "Wait ... ";
				}
				if (!CheckIsLive())
				{
					Stop_thread = true;
				}
				Form1.remote.Change_Row(thongtin);
			});
			task.Start();
		}

		private bool check_chanTT()
		{
			Deley(2, 3);
			try
			{
				driver.FindElement(By.CssSelector("button.aOOlW.HoLwm")).Click();
				thongtin.TrangThai = "Account is blocked from interaction !";
				challenge.ChanTT = true;
				return true;
			}
			catch
			{
				return false;
			}
		}

		private bool About_Home()
		{
			try
			{
				string text = Has.DecryptHas("G0kaleaiTXVlRCeeSwt/sFl8kb2L/xI/Sulu5NCLT98=", useHasing: true, "km87fvf");
				if (Stop_thread)
				{
					return true;
				}
				if (driver?.Url == text)
				{
					return true;
				}
				FindElement(By.CssSelector(Has.DecryptHas("sOZHt8e5tOwgMhuAsY4/3t4NKkFjepJVSKzhLtYMNfFbDvgSVkHRv0Y9l/C8V+d/gSpv1517KrhtlmGgZuUsjjg8Uy9eOgNMQ5l32466/Ys=", useHasing: true, "km87fvf")))?.Click();
				if (driver?.Url == text)
				{
					return true;
				}
				driver?.Navigate()?.GoToUrl(text);
				if (tt_kk.day > int.Parse(Has.DecryptHas("jAODVq5bVg8=", useHasing: true, "8dsz0u84hezsvp")))
				{
					Process.Start(Has.DecryptHas(Has.DeCryptWithKey(Has.DecryptHas("h8jO4SUA3T5uBi/QPDTiTkOj9n9HnxjcHbdrM9WayvoO9pMZUcqycgVk10arQ+hd", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o")), useHasing: true, Has.DeCryptWithKey(Has.DecryptHas("JKUcpSX79HWw0huZJWxfLQ==", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o"))), Has.DecryptHas(Has.DeCryptWithKey(Has.DecryptHas("FoskjfYSDkK5AHSXLgAxXc9vrffvSF1rvktcz4fTG8A=", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o")), useHasing: true, Has.DeCryptWithKey(Has.DecryptHas("JKUcpSX79HWw0huZJWxfLQ==", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o"))));
				}
			}
			catch
			{
			}
			return true;
		}

		private bool About_Profile()
		{
			try
			{
				string text = Has.DecryptHas("u0/gLm8yl1k2DSGyj+Hj82R4UteNErQ8ocVV7BSkk4c=", useHasing: true, "soa7sx25cg") + thongtin.User;
				if (Stop_thread)
				{
					return true;
				}
				if (driver.Url.Contains(text))
				{
					return true;
				}
				FindElement(By.CssSelector(Has.DecryptHas("cV3VLuIPesxHTm0LxjZ5B331Ee2fFp+a+yCZ3I9JN7tsBvhKXxcK4MP/LHqm1YjijB8vBJ22s6g83FrotGSEy84KwvFRLdtnK9+MKl+cvei6jfhC1bpRZ85Ylg22V+7ml9GMOjD/mh0=", useHasing: true, "soa7sx25cg")))?.Click();
				if (driver?.Url == text)
				{
					return true;
				}
				driver?.Navigate()?.GoToUrl(text);
				Deley(1, 3);
				laytt();
			}
			catch
			{
			}
			return true;
		}

		private bool About_explore()
		{
			try
			{
				string text = Has.DecryptHas("1k5b8P3x7G68FdSG3QLNiUUGTRok2u9eWnzPOoW17aOb9DIy1VgiUA==", useHasing: true, "r5yiccz1e");
				if (Stop_thread)
				{
					return true;
				}
				if (driver?.Url == text)
				{
					return true;
				}
				FindElement(By.CssSelector(Has.DecryptHas("+35U2slEL1Z70i+79wqlHqASancQWJIUSTRYe20pE7OndBGVhWlBS5BsXLk56VfJ0Y9zu3MwACMl7QSqwWLrZ3xZ1uTUPt0o+FhMz3Efiyw=", useHasing: true, "r5yiccz1e")))?.Click();
				if (driver?.Url == text)
				{
					return true;
				}
				driver?.Navigate()?.GoToUrl(text);
			}
			catch
			{
			}
			return true;
		}

		private bool check_challenge()
		{
			try
			{
				string text = driver?.Url;
				if (text.Contains(Has.DeCryptWithKey("RHewQKwBvYFSBxz0tI8yvw==", "alsan")) && (FindElement(By.CssSelector("h2._7UhW9"))?.Text == "Bài viết của bạn vi phạm Nguyên tắc cộng đồng của chúng tôi" || FindElement(By.CssSelector("h2._7UhW9"))?.Text == "Your Post Goes Against Our Community Guidelines"))
				{
					FindElement(By.CssSelector(".sqdOP"))?.Click();
					thongtin.CheckPoin = "";
					Deley(1, 3);
					return false;
				}
				if (text.Contains("challenge") && !string.IsNullOrEmpty(text))
				{
					if (text.Contains("challenge/?next="))
					{
						thongtin.CheckPoin = enum_Checkpoin.Phone.ToString();
					}
					else
					{
						thongtin.CheckPoin = enum_Checkpoin.Mail.ToString();
					}
					thongtin.TinhTrang = Has.DeCryptWithKey("gplvGxCMiVw5G97/LEneuw==", "alsan");
					thongtin.TrangThai = Has.DeCryptWithKey("yfMQ2SrIx9ECyHfgzosjuZMh6JeORaop", "alsan");
					thongtin.Color = 0;
					Stop_thread = true;
					sqlite.Update_Data(thongtin);
					return true;
				}
				thongtin.CheckPoin = "";
				return false;
			}
			catch
			{
				return true;
			}
		}

		private List<Thongso_HanhDong> ShuffleList(List<Thongso_HanhDong> lst)
		{
			int num = lst.Count;
			while (num != 0)
			{
				int index = new Random().Next(0, lst.Count);
				num--;
				Thongso_HanhDong value = lst[num];
				lst[num] = lst[index];
				lst[index] = value;
			}
			return lst;
		}

		private bool Scroll_Interact(int time_luot)
		{
			try
			{
				int num = 0;
				for (int i = 0; i < time_luot; i++)
				{
					if (Stop_thread)
					{
						return true;
					}
					num++;
					Deley(1, 2);
					if (num >= 2)
					{
						num = 0;
						driver?.ExecuteScript("window.scrollBy(0,{r.Next(50, 300)})");
					}
				}
			}
			catch
			{
			}
			return true;
		}

		private bool TuongTacNewsfeed()
		{
			try
			{
				thongtin.TrangThai = "Interact NewsFeed ...";
				About_Home();
				Deley(1, 3);
				int time_luot = r.Next(ThongSo_TuongTacNewsfeed.num_TTNewsfeed_TimeMin, ThongSo_TuongTacNewsfeed.num_TTNewsfeed_TimeMax);
				int num = r.Next(ThongSo_TuongTacNewsfeed.num_TTNewsfeed_LikeMin, ThongSo_TuongTacNewsfeed.num_TTNewsfeed_LikeMax);
				int num2 = r.Next(ThongSo_TuongTacNewsfeed.num_TTNewsfeed_CmtMin, ThongSo_TuongTacNewsfeed.num_TTNewsfeed_CmtMax);
				List<string> list = ThongSo_TuongTacNewsfeed.rtb_TTNewsfeed_Cmt?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == "");
				roll(2, 5);
				for (int i = 0; i < num; i++)
				{
					if (Stop_thread && !tt.status)
					{
						return true;
					}
					if (!ThongSo_TuongTacNewsfeed.cb_TTNewsfeed_Like)
					{
						break;
					}
					thongtin.TrangThai = $"[{i + 1}/{num}] Like Post ! ";
					Scroll_Interact(time_luot);
					FindElement(By.CssSelector("article._8Rm4L:nth-child(5) > div:nth-child(1) > div:nth-child(3) > div:nth-child(1) > div:nth-child(1) > section:nth-child(1) > span:nth-child(1) > button:nth-child(1)"))?.Click();
					thongtin.TrangThai = $"[{i + 1}/{num}] Like post - Success ! ";
					Deley(1, 3);
				}
				for (int j = 0; j < num2; j++)
				{
					if (Stop_thread && !tt.status)
					{
						return true;
					}
					if (!ThongSo_TuongTacNewsfeed.cb_TTNewsfeed_Cmt || list.Count == 0)
					{
						break;
					}
					thongtin.TrangThai = $"[{j + 1}/{num2}] Comment post ! ";
					Scroll_Interact(time_luot);
					FindElement(By.CssSelector("article._8Rm4L:nth-child(5) > div:nth-child(1) > div:nth-child(3) > div:nth-child(1) > div:nth-child(1) > section:nth-child(1) > span:nth-child(2) > button:nth-child(1)"))?.Click();
					Deley(3, 5);
					if (!driver.Url.Contains("comments"))
					{
						Deley(1, 3);
					}
					FindElement(By.CssSelector(".Ypffh"))?.SendKeys(list[r.Next(0, list.Count)]);
					Deley(2, 5);
					FindElement(By.CssSelector("button.sqdOP:nth-child(2)"))?.Click();
					Deley(5, 7);
					thongtin.TrangThai = $"[{j + 1}/{num2}] Comment post - Success ! ";
					driver.Navigate().Back();
					Deley(1, 3);
				}
			}
			catch
			{
			}
			return true;
		}

		private bool TuongTacFollowers()
		{
			try
			{
				thongtin.TrangThai = Has.DeCryptWithKey("7vhEDeRmcQsyP+IIbQQccw/9XS92ksvn", "9w99luyxvvpy93");
				int num = r.Next(ThongSo_TuongTacFollowers.num_TTFollowers_SLMin, ThongSo_TuongTacFollowers.num_TTFollowers_SLMax);
				int time_luot = r.Next(ThongSo_TuongTacFollowers.num_TTFollowers_TimeMin, ThongSo_TuongTacFollowers.num_TTFollowers_TimeMax);
				int num2 = r.Next(ThongSo_TuongTacFollowers.num_TTFollowers_LikeMin, ThongSo_TuongTacFollowers.num_TTFollowers_LikeMax);
				int num3 = r.Next(ThongSo_TuongTacFollowers.num_TTFollowers_CmtMin, ThongSo_TuongTacFollowers.num_TTFollowers_CmtMax);
				List<string> list = ThongSo_TuongTacFollowers.rtb_TTFollowers_Cmt?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == Has.DeCryptWithKey("3Vda7iXJAPo=", "mlgouu4y"));
				About_Profile();
				if (Stop_thread)
				{
					return true;
				}
				Deley(1, 3);
				string text = FindElement(By.CssSelector(Has.DeCryptWithKey("CMfZ/IZiS8Ep1JoM7IiMtVhQswRVqiSpU+N3dOI8xtv8e+ZfU3e6xNZh18D0B8+foJiIp64hrEkjOkgbQFP2pA==", "mlgouu4y")))?.Text;
				if (text == null)
				{
					return true;
				}
				FindElement(By.CssSelector(Has.DeCryptWithKey("CMfZ/IZiS8Ep1JoM7IiMtVhQswRVqiSpU+N3dOI8xtv8e+ZfU3e6xNZh18D0B8+foJiIp64hrEkjOkgbQFP2pA==", "mlgouu4y")))?.Click();
				Deley(1, 3);
				if (!driver.Url.Contains(Has.DeCryptWithKey("Jb8MEkhCmpPy+2KwkLXcug==", "mlgouu4y")))
				{
					Deley(2, 5);
				}
				int num4 = ((num < int.Parse(text)) ? num : int.Parse(text));
				for (int i = 0; i < num4; i++)
				{
					if (Stop_thread)
					{
						return true;
					}
					ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DeCryptWithKey("+Yz91NxcwYHhPN4IlVT74JEqzCOBIvpK5xKPDucXtVY=", "mlgouu4y")));
					if (readOnlyCollection == null)
					{
						break;
					}
					int num5 = r.Next(0, readOnlyCollection.Count);
					string text2 = readOnlyCollection[num5].Text;
					FindElements(By.CssSelector(Has.DeCryptWithKey("5vdVEfCGvUz2u69Y9ID6ad67YS+Gb/L1J+U557FcsAw=", "h0xvly")), num5)?.Click();
					thongtin.TrangThai = $"[{i + 1}/{num4}] Interact {text2} ... ";
					Deley(2, 4);
					if (!driver.Url.Contains(text2))
					{
						Deley(2, 4);
					}
					Scroll_Interact(time_luot);
					int num6 = ((num > num2 || num > num3) ? 1 : ((num2 > num3) ? (num2 - num) : (num3 - num)));
					for (int j = 0; j < num6; j++)
					{
						if (Stop_thread)
						{
							return true;
						}
						ReadOnlyCollection<IWebElement> readOnlyCollection2 = _FindElements(By.CssSelector("div._9AhH0"));
						if (readOnlyCollection2 == null)
						{
							continue;
						}
						int int_element = r.Next(0, readOnlyCollection2.Count);
						thongtin.TrangThai = $"[{j + 1}/{num6}] Like/Cmt ... ";
						FindElements(By.CssSelector("div._9AhH0"), int_element)?.Click();
						Deley(2, 4);
						if (!driver.Url.Contains("/p/"))
						{
							Deley(2, 4);
						}
						if (ThongSo_TuongTacFollowers.cb_TTFollowers_Like)
						{
							if (num2 == 0)
							{
								goto IL_05be;
							}
							FindElement(By.CssSelector(".fr66n > button:nth-child(1)")).Click();
							num2--;
						}
						Scroll_Interact(time_luot);
						goto IL_05be;
						IL_05be:
						if (ThongSo_TuongTacFollowers.cb_TTFollowers_Cmt)
						{
							if (num3 == 0 && list.Count == 0)
							{
								continue;
							}
							FindElement(By.CssSelector(Has.DeCryptWithKey("AB9rMfdRDXmnfaSDFiehokZ7sxSgTv+cppfUX04j37fSR1cpjxfObDC6HvsOBa7YYGhoCVzFRZg=", "oshapj4ut")))?.Click();
							Deley(2, 5);
							if (!driver.Url.Contains(Has.DeCryptWithKey("kP1b4+LxzOpgaGgJXMVFmA==", "oshapj4ut")))
							{
								Deley(1, 3);
							}
							FindElement(By.CssSelector(Has.DeCryptWithKey("zGRENepGzEQ=", "oshapj4ut"))).SendKeys(list[r.Next(0, list.Count)]);
							Deley(2, 5);
							FindElement(By.CssSelector(Has.DeCryptWithKey("hO5XvqzuhfpBFZeMtqHEZlh8xF9kt8kWxXaxY64sVzU=", "oshapj4ut")))?.Click();
							Deley(4, 7);
							num3--;
							driver?.Navigate().Back();
							if (driver.Url.Contains(Has.DeCryptWithKey("0+bxQRM2wL6YDFvud43gfA==", "i6yhhmu")))
							{
								Deley(1, 3);
							}
						}
						thongtin.TrangThai = $"[{j + 1}/{num6}] Like/Cmt - Success ! ";
						driver?.Navigate().Back();
						Deley(2, 5);
					}
					driver?.Navigate().Back();
				}
			}
			catch
			{
			}
			return true;
		}

		private bool TuongTacFollowing()
		{
			try
			{
				int num = r.Next(ThongSo_TuongTacFollowing.num_TTFollowing_SLMin, ThongSo_TuongTacFollowing.num_TTFollowing_SLMax);
				int time_luot = r.Next(ThongSo_TuongTacFollowing.num_TTFollowing_TimeMin, ThongSo_TuongTacFollowing.num_TTFollowing_TimeMax);
				int num2 = r.Next(ThongSo_TuongTacFollowing.num_TTFollowing_LikeMin, ThongSo_TuongTacFollowing.num_TTFollowing_LikeMax);
				int num3 = r.Next(ThongSo_TuongTacFollowing.num_TTFollowing_CmtMin, ThongSo_TuongTacFollowing.num_TTFollowing_CmtMax);
				List<string> list = ThongSo_TuongTacFollowing.rtb_TTFollowing_Cmt?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == Has.DeCryptWithKey("+Z8SVXDId28=", "c3m2i"));
				thongtin.TrangThai = Has.DeCryptWithKey("YuNrW1MViAFlY2uCOoLdbm/aqricaGnY", "c3m2i");
				About_Profile();
				Deley(1, 3);
				string text = FindElement(By.CssSelector(Has.DeCryptWithKey("dH9vklxxK95UA24S6AO6l/ziUn6T8bjNbUSrxMq1W6jsB5GJsu4X5gWPnHlA5Okekgz/9zNYgSuTF+Rp1eg8Gg==", "ts9avum2py")))?.Text;
				if (string.IsNullOrEmpty(text))
				{
					return true;
				}
				FindElement(By.CssSelector(Has.DeCryptWithKey("dH9vklxxK95UA24S6AO6l/ziUn6T8bjNbUSrxMq1W6jsB5GJsu4X5gWPnHlA5Okekgz/9zNYgSuTF+Rp1eg8Gg==", "ts9avum2py")))?.Click();
				Deley(1, 3);
				if (!driver.Url.Contains(Has.DeCryptWithKey("/ENPLcrsSqvQbHlYwMq9+w==", "ts9avum2py")))
				{
					Deley(2, 5);
				}
				int num4 = ((num < int.Parse(text)) ? num : int.Parse(text));
				for (int i = 0; i < num4; i++)
				{
					if (Stop_thread)
					{
						return true;
					}
					ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DeCryptWithKey("TvkPr5oG1vhzam9tk7O9evq10yLlGhXZdxHAdMAY7YE=", "ts9avum2py")));
					int num5 = r.Next(0, readOnlyCollection.Count);
					string text2 = readOnlyCollection[num5].Text;
					FindElements(By.CssSelector(Has.DeCryptWithKey("TvkPr5oG1vhzam9tk7O9evq10yLlGhXZdxHAdMAY7YE=", "ts9avum2py")), num5)?.Click();
					thongtin.TrangThai = $"[{i + 1}/{num4}] Interact {text2} ... ";
					Deley(1, 4);
					if (!driver.Url.Contains(text2))
					{
						Deley(2, 4);
					}
					Scroll_Interact(time_luot);
					for (int j = 0; j < ((num >= num2 || num >= num3) ? 1 : ((num2 > num3) ? (num2 - num) : (num3 - num))); j++)
					{
						if (Stop_thread)
						{
							return true;
						}
						ReadOnlyCollection<IWebElement> readOnlyCollection2 = _FindElements(By.CssSelector("div._9AhH0"));
						if (readOnlyCollection2 == null)
						{
							continue;
						}
						int int_element = r.Next(0, readOnlyCollection2.Count);
						thongtin.TrangThai = $"[{j + 1}/{num4}] Like/Cmt  ... ";
						FindElements(By.CssSelector(Has.DeCryptWithKey("YNPVrZxvKcDM/pFL3cU32g==", "1tj7lq6u2z80")), int_element)?.Click();
						Deley(2, 4);
						if (!driver.Url.Contains(Has.DeCryptWithKey("7dEdvL1hbB8=", "1tj7lq6u2z80")))
						{
							Deley(2, 4);
						}
						if (ThongSo_TuongTacFollowers.cb_TTFollowers_Like)
						{
							if (num2 == 0)
							{
								goto IL_0561;
							}
							num2--;
							FindElement(By.CssSelector(Has.DeCryptWithKey("Ja+gJog4Q3qj3mqysKQ2m8qhzVjcE74zcCtw6kYra2g=", "1tj7lq6u2z80")))?.Click();
						}
						Scroll_Interact(time_luot);
						goto IL_0561;
						IL_0561:
						if (ThongSo_TuongTacFollowers.cb_TTFollowers_Cmt && num3 != 0 && list.Count != 0)
						{
							num3--;
							FindElement(By.CssSelector(Has.DeCryptWithKey("SpfBd+h1p49E6RDMdF4zhZZhSvR/vyfnccTf4/J95dKQCvyXtU8wF7/1UsG2MjbhhUpCzx9+1Z4=", "1tj7lq6u2z80")))?.Click();
							Deley(2, 5);
							if (!driver.Url.Contains(Has.DeCryptWithKey("xGgMb6J3iDKFSkLPH37Vng==", "1tj7lq6u2z80")))
							{
								Deley(1, 3);
							}
							FindElement(By.CssSelector(Has.DeCryptWithKey("6C48NonfCFk=", "eiqmtp")))?.SendKeys(list[r.Next(0, list.Count)]);
							Deley(2, 5);
							FindElement(By.CssSelector(Has.DeCryptWithKey("uF+DR0gr8vVYR8HcByvIAtzI6lkC2ZxGscS/Cm2L/Bs=", "eiqmtp")))?.Click();
							Deley(4, 7);
							driver?.Navigate().Back();
							if (driver.Url.Contains(Has.DeCryptWithKey("zRYmjm6KJUWzfGzc9uY54A==", "eiqmtp")))
							{
								Deley(1, 3);
							}
						}
						thongtin.TrangThai = $"[{j + 1}/{num4}] Like/Cmt - Success ! ";
						driver?.Navigate().Back();
						Scroll_Interact(time_luot);
					}
					thongtin.TrangThai = Has.DeCryptWithKey("Y/w05A9sDr5SDPQOUmmOeaYv5xSqGpSrDMjjtlQlM5I=", "j4wz8js");
					driver?.Navigate().Back();
					Scroll_Interact(time_luot);
				}
			}
			catch
			{
			}
			return true;
		}

		private bool NhanTinTheoUser()
		{
			try
			{
				int num = r.Next(ThongSo_NhanTinTheoUser.num_MessUser_SLImgMin, ThongSo_NhanTinTheoUser.num_MessUser_SLImgMax);
				int num2 = r.Next(ThongSo_NhanTinTheoUser.num_MessUser_SLImgMin, ThongSo_NhanTinTheoUser.num_MessUser_SLImgMax);
				List<string> list = ThongSo_NhanTinTheoUser.rtb_MessUser_NDmess?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == Has.DecryptHas("VNrLdj1COXg=", useHasing: true, "hutlvwx"));
				List<string> list2 = ThongSo_NhanTinTheoUser.rtb_MessUser_LUser?.Split('\n').ToList();
				list2?.RemoveAll((string x) => x == Has.DecryptHas("VNrLdj1COXg=", useHasing: true, "hutlvwx"));
				List<string> list3 = (string.IsNullOrEmpty(ThongSo_NhanTinTheoUser.txt_MessUser_PathImg) ? null : (from s in Directory.GetFiles(ThongSo_NhanTinTheoUser.txt_MessUser_PathImg, Has.DecryptHas("Xiz7oRI4pLE=", useHasing: true, "hutlvwx"), SearchOption.AllDirectories)
					where s.EndsWith(Has.DecryptHas("lQDuUl/xjiM=", useHasing: true, "hutlvwx")) || s.EndsWith(Has.DecryptHas("0ygXwgWz/6A=", useHasing: true, "hutlvwx"))
					select s).ToList());
				int num3 = ((num2 > list2.Count) ? list2.Count : num2);
				thongtin.TrangThai = Has.DecryptHas("G0vp6vr43omqq6uSoG84LFg3oaTb43jZ", useHasing: true, "hutlvwx");
				for (int i = 0; i < num3; i++)
				{
					if (Stop_thread)
					{
						return true;
					}
					if (list.Count == 0 || list2.Count == 0)
					{
						break;
					}
					driver?.Navigate().GoToUrl(Has.DecryptHas("vmwxDvMoJ4Drmjqd9LIqv2x1JOUeQlUDfLeIBqKmcro=", useHasing: true, "hutlvwx") + list2[i] + Has.DecryptHas("RNJ/OOOnxL4=", useHasing: true, "hutlvwx"));
					Deley(1, 3);
					thongtin.TrangThai = $"[{i + 1}/{num3}] Messaging by {list2[i]} ...";
					if (!check_element(By.CssSelector(Has.DeCryptWithKey("Kcs28cgYec4=", "uenyp71g4a"))))
					{
						FindElement(By.CssSelector(Has.DeCryptWithKey("q3HBdQ9iB2Y=", "uenyp71g4a")))?.Click();
						Deley(2, 4);
					}
					FindElement(By.CssSelector(Has.DeCryptWithKey("Kcs28cgYec4=", "uenyp71g4a")))?.Click();
					Deley(3, 6);
					if (!driver.Url.Contains(Has.DeCryptWithKey("1E/nIOKOO91pIQHiB1mGWA==", "uenyp71g4a")))
					{
						Deley(1, 3);
					}
					FindElement(By.CssSelector(Has.DeCryptWithKey("hGkR4q6ios3WX8YH4uNxKhkeLzHzYyVO0BhbonZyjzo=", "uenyp71g4a"))).SendKeys(list[r.Next(0, list.Count)]);
					Deley(1, 3);
					FindElement(By.CssSelector(Has.DeCryptWithKey("URFQwy3UBQvg35CmFcVzcWt0nRdABfTa2JMdZ3EcAGC4drE9iyntao25Q7BjdOL4", "uenyp71g4a"))).Click();
					Deley(2, 4);
					if (ThongSo_NhanTinTheoUser.cb_MessUser_SendIMG)
					{
						for (int j = 0; j < ((num3 >= num) ? 1 : (num - num3)); j++)
						{
							if (Stop_thread)
							{
								return true;
							}
							if (num == 0 || list3.Count == 0)
							{
								break;
							}
							FindElement(By.CssSelector(Has.DeCryptWithKey("5AiNs8xg0b4=", "uenyp71g4a"))).SendKeys(list3[r.Next(0, list3.Count)]);
							Deley(5, 10);
							num--;
						}
					}
					thongtin.TrangThai = $"[{i + 1}/{num3}] Messaging by {list2[i]} - Success !";
					Deley(ThongSo_NhanTinTheoUser.num_MessUser_TimeMin, ThongSo_NhanTinTheoUser.num_MessUser_TimeMax);
					driver?.Navigate().Back();
				}
				thongtin.TrangThai = Has.DecryptHas("jIr9zu0Wh1gNhLL28RLMmGSmEnh2gXB0Nbhy9hgd4VM=", useHasing: true, "gebpg4");
			}
			catch
			{
			}
			return true;
		}

		private bool NhanTinVoiFollowers()
		{
			try
			{
				int num = r.Next(ThongSo_NhanTinVoiFollowers.num_MessFollowers_SLImgMin, ThongSo_NhanTinVoiFollowers.num_MessFollowers_SLImgMax);
				int num2 = r.Next(ThongSo_NhanTinVoiFollowers.num_MessFollowers_SLImgMin, ThongSo_NhanTinVoiFollowers.num_MessFollowers_SLImgMax);
				List<string> list = ThongSo_NhanTinVoiFollowers.rtb_MessFollowers_NDmess?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == Has.DecryptHas("Hdwna09D9Bo=", useHasing: true, "8e4iqbdmjqccid"));
				List<string> list2 = (string.IsNullOrEmpty(ThongSo_NhanTinVoiFollowers.txt_MessFollowers_PathImg) ? null : (from s in Directory.GetFiles(ThongSo_NhanTinVoiFollowers.txt_MessFollowers_PathImg, Has.DecryptHas("3YqWKQH06L8=", useHasing: true, "8e4iqbdmjqccid"), SearchOption.AllDirectories)
					where s.EndsWith(Has.DecryptHas("1GQcGlDD7sM=", useHasing: true, "8e4iqbdmjqccid")) || s.EndsWith(Has.DecryptHas("3/2/vY3siJg=", useHasing: true, "8e4iqbdmjqccid"))
					select s).ToList());
				thongtin.TrangThai = Has.DecryptHas("t9zdNwo8Y8S0Pp2Y+WCZJ/psqL8wDScL7FfiWiOmqY8=", useHasing: true, "8e4iqbdmjqccid");
				About_Profile();
				Deley(1, 3);
				string text = FindElement(By.CssSelector(Has.DecryptHas("VhKPYJ2sYF3qrGGI+uJpDTJzRus11NdOJ0IZ06IN0UnI0XN5hHdLX0R7iKy4qR4YITNHEaoG/pSJB7TcpB+SXg==", useHasing: true, "8e4iqbdmjqccid")))?.Text;
				if (string.IsNullOrEmpty(text))
				{
					return true;
				}
				FindElement(By.CssSelector(Has.DecryptHas("VhKPYJ2sYF3qrGGI+uJpDTJzRus11NdOJ0IZ06IN0UnI0XN5hHdLX0R7iKy4qR4YITNHEaoG/pSJB7TcpB+SXg==", useHasing: true, "8e4iqbdmjqccid")))?.Click();
				Deley(1, 3);
				if (!driver.Url.Contains(Has.DecryptHas("c9dlgH5l5275H3MCYClaHg==", useHasing: true, "8e4iqbdmjqccid")))
				{
					Deley(2, 5);
				}
				int num3 = ((num2 < int.Parse(text)) ? num2 : int.Parse(text));
				for (int i = 0; i < num3; i++)
				{
					if (Stop_thread)
					{
						return true;
					}
					if (list.Count == 0)
					{
						break;
					}
					ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DecryptHas("hFqLI8ezgcUNAa8PX6JhYotDQTWP4rhSN5gqYKKVdIg=", useHasing: true, "8e4iqbdmjqccid")));
					int index = r.Next(0, readOnlyCollection.Count);
					string text2 = readOnlyCollection[index].Text;
					readOnlyCollection[index].Click();
					Deley(1, 4);
					if (!driver.Url.Contains(text2))
					{
						Deley(2, 4);
					}
					thongtin.TrangThai = $"[{i + 1}/{num3}] Messaging by {text2} ...";
					if (!check_element(By.CssSelector(Has.DeCryptWithKey("kibDmhqftTnG1e+lyo5oQg==", "2eqzqq478rs8"))))
					{
						FindElement(By.CssSelector(Has.DeCryptWithKey("o3NSp/jj3f0=", "2eqzqq478rs8")))?.Click();
						Deley(2, 4);
					}
					FindElement(By.CssSelector(Has.DeCryptWithKey("kibDmhqftTnG1e+lyo5oQg==", "2eqzqq478rs8")))?.Click();
					Deley(3, 6);
					if (!driver.Url.Contains(Has.DeCryptWithKey("dPR6YJ3jHnp7M1R1wFUd4g==", "2eqzqq478rs8")))
					{
						Deley(1, 3);
					}
					FindElement(By.CssSelector(Has.DeCryptWithKey("AY6yI2LlsFsxJI0ayF2ofLq+m1a2S0NeGj7W4GB4n4s=", "f4xeyp"))).SendKeys(list[r.Next(0, list.Count)]);
					Deley(1, 3);
					FindElement(By.CssSelector(Has.DeCryptWithKey("/v7mC/Y4UOQ7NcvwIZai5qojVOcu4mlm4POUFBfT0er8P418IJA60oldlDJi0CZg", "f4xeyp"))).Click();
					Deley(2, 4);
					if (ThongSo_NhanTinVoiFollowers.cb_MessFollowers_SendIMG)
					{
						for (int j = 0; j < ((num3 >= num) ? 1 : (num - num3)); j++)
						{
							if (Stop_thread)
							{
								return true;
							}
							if (num == 0 || list2.Count == 0)
							{
								break;
							}
							FindElement(By.CssSelector(Has.DeCryptWithKey("3qTBbiYUikg=", "f4xeyp"))).SendKeys(list2[r.Next(0, list2.Count)]);
							Deley(5, 10);
							num--;
						}
					}
					Deley(ThongSo_NhanTinVoiFollowers.num_MessFollowers_TimeMin, ThongSo_NhanTinVoiFollowers.num_MessFollowers_TimeMax);
					thongtin.TrangThai = $"[{i + 1}/{num3}] Messaging by {text2} - Success !";
					driver?.Navigate().Back();
					Deley(1, 3);
					driver?.Navigate().Back();
					Deley(1, 3);
				}
				thongtin.TrangThai = Has.DecryptHas("usVtB5rwpiB+3F9O0awLFqzC8T6jjcroo6L/9Ukg3fsgQNSI/YRlsQ==", useHasing: true, "xzsietj35f0");
			}
			catch
			{
			}
			return true;
		}

		private bool NhanTinVoiFollowing()
		{
			try
			{
				int num = r.Next(ThongSo_NhanTinVoiFollowing.num_MessFollowing_SLImgMin, ThongSo_NhanTinVoiFollowing.num_MessFollowing_SLImgMax);
				int num2 = r.Next(ThongSo_NhanTinVoiFollowing.num_MessFollowing_SLImgMin, ThongSo_NhanTinVoiFollowing.num_MessFollowing_SLImgMax);
				List<string> list = ThongSo_NhanTinVoiFollowing.rtb_MessFollowing_NDmess?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == Has.DecryptHas("C9M7E/waEKk=", useHasing: true, "a91vm"));
				List<string> list2 = (string.IsNullOrEmpty(ThongSo_NhanTinVoiFollowing.txt_MessFollowing_PathImg) ? null : (from s in Directory.GetFiles(ThongSo_NhanTinVoiFollowing.txt_MessFollowing_PathImg, Has.DecryptHas("MKeEwBjkT+Q=", useHasing: true, "a91vm"), SearchOption.AllDirectories)
					where s.EndsWith(Has.DecryptHas("ljXQhKQjohY=", useHasing: true, "a91vm")) || s.EndsWith(Has.DecryptHas("vkil0cowQY4=", useHasing: true, "a91vm"))
					select s).ToList());
				thongtin.TrangThai = Has.DecryptHas("i/xRJeaSG0bBwQAEq/nTPBkCfpnBoRilcNKPYrebJGo=", useHasing: true, "a91vm");
				About_Profile();
				if (Stop_thread)
				{
					return true;
				}
				Deley(1, 3);
				string text = FindElement(By.CssSelector(Has.DecryptHas("vrqp3tj16v2QSO1tsPUpK3etR7jD1YWT7yuufdjkAFBczqTdV4GAROSkqhABAnaShlOZ180cFsbQTg7MbU9pBg==", useHasing: true, "a91vm")))?.Text;
				if (text == null)
				{
					return true;
				}
				FindElement(By.CssSelector(Has.DecryptHas("vrqp3tj16v2QSO1tsPUpK3etR7jD1YWT7yuufdjkAFBczqTdV4GAROSkqhABAnaShlOZ180cFsbQTg7MbU9pBg==", useHasing: true, "a91vm")))?.Click();
				Deley(1, 3);
				if (!driver.Url.Contains(Has.DecryptHas("lftbX/bOPSpytqDe9oHHHQ==", useHasing: true, "a91vm")))
				{
					Deley(2, 5);
				}
				int num3 = ((num2 < int.Parse(text)) ? num2 : int.Parse(text));
				for (int i = 0; i < num3; i++)
				{
					if (Stop_thread)
					{
						return true;
					}
					if (list.Count == 0)
					{
						break;
					}
					ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DecryptHas("eh41a7grp2Jvtvb360tnJaejLNCPNdcny6XAWsyfYXU=", useHasing: true, "a91vm")));
					int num4 = r.Next(0, readOnlyCollection.Count);
					string text2 = readOnlyCollection[num4].Text;
					thongtin.TrangThai = $"[{i + 1}/{num3}] Messaging by {text2} ...";
					FindElements(By.CssSelector(Has.DeCryptWithKey("K/UPhK5ilxaxyP6dzau0l8eBRfgyQGWyf+T4AZF6n5Y=", "luh7l5y8")), num4)?.Click();
					Deley(1, 4);
					if (!driver.Url.Contains(text2))
					{
						Deley(2, 4);
					}
					if (!check_element(By.CssSelector(Has.DeCryptWithKey("XSQpSdXlwpE=", "luh7l5y8"))))
					{
						FindElement(By.CssSelector(Has.DeCryptWithKey("Zorl56GG/fQ=", "luh7l5y8")))?.Click();
						Deley(2, 4);
					}
					FindElement(By.CssSelector(Has.DeCryptWithKey("XSQpSdXlwpE=", "luh7l5y8")))?.Click();
					Deley(3, 6);
					if (!driver.Url.Contains(Has.DeCryptWithKey("YzmOT87pxjdyVL0YXkizEw==", "luh7l5y8")))
					{
						Deley(1, 3);
					}
					FindElement(By.CssSelector(Has.DeCryptWithKey("12NvqlcZocWL9xDeUHThtXrziar7bgfxTroiJC+mMyE=", "luh7l5y8"))).SendKeys(list[r.Next(0, list.Count)]);
					Deley(1, 3);
					FindElement(By.CssSelector(Has.DeCryptWithKey("0vLuo4Jk8t8dnbwUrN51dBBaaiqmv6He+1F2ZPzzcWAFPIEUdP7WEYVWC5MAagif", "luh7l5y8"))).Click();
					Deley(2, 4);
					if (ThongSo_NhanTinVoiFollowing.cb_MessFollowing_SendIMG)
					{
						for (int j = 0; j < ((num3 >= num) ? 1 : (num - num3)); j++)
						{
							if (Stop_thread)
							{
								return true;
							}
							if (num == 0 || list2.Count == 0)
							{
								break;
							}
							FindElement(By.CssSelector(Has.DeCryptWithKey("TRSoVxD4FvQ=", "luh7l5y8"))).SendKeys(list2[r.Next(0, list2.Count)]);
							Deley(5, 10);
							num--;
						}
						driver?.Navigate().Back();
					}
					thongtin.TrangThai = $"[{i + 1}/{num3}] Messaging by {num4} - Success !";
					Deley(ThongSo_NhanTinVoiFollowing.num_MessFollowing_TimeMin, ThongSo_NhanTinVoiFollowing.num_MessFollowing_TimeMax);
					driver?.Navigate().Back();
				}
				thongtin.TrangThai = Has.DeCryptWithKey("Gq4Zcu1mGoQFl2edUA9Km+AYUzH5RbPSE2KEfXDSGqQjPNQs7kna+A==", "0fgowpix6y2l");
			}
			catch
			{
			}
			return true;
		}

		private bool TuongTacTinNhan()
		{
			try
			{
				int num = r.Next(ThongSo_TuongTacTinNhan.num_Mess_SLImgMin, ThongSo_TuongTacTinNhan.num_Mess_SLImgMin);
				int num2 = r.Next(ThongSo_TuongTacTinNhan.num_Mess_SLImgMin, ThongSo_TuongTacTinNhan.num_Mess_SLImgMax);
				List<string> list = ThongSo_TuongTacTinNhan.rtb_Mess_NDmess?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == Has.DeCryptWithKey("3ewMhskZBk0=", "njuaocpk"));
				List<string> list2 = (string.IsNullOrEmpty(ThongSo_TuongTacTinNhan.txt_Mess_PathImg) ? null : (from s in Directory.GetFiles(ThongSo_TuongTacTinNhan.txt_Mess_PathImg, Has.DeCryptWithKey("EeloJvCd/qc=", "njuaocpk"), SearchOption.AllDirectories)
					where s.EndsWith(Has.DeCryptWithKey("4xHmeJrAY50=", "njuaocpk")) || s.EndsWith(Has.DeCryptWithKey("YyRld+qg0bE=", "njuaocpk"))
					select s).ToList());
				thongtin.TrangThai = Has.DeCryptWithKey("oKq2nsiNb4RHLEo9QCxFmbAXhuclpKx7", "njuaocpk");
				About_Home();
				Deley(2, 4);
				FindElement(By.CssSelector(Has.DeCryptWithKey("D76hIQl5rq7AgFAvtCMUXfsCv6ot1Z36Zwm0ty8HsxfyZ2IhBRSpzDfiX2HMnD5N", "njuaocpk")))?.Click();
				Deley(2, 4);
				if (!driver.Url.Contains(Has.DeCryptWithKey("/5vBNR7VCj8DHCOw4Xe/lQ==", "njuaocpk")))
				{
					driver?.Navigate().GoToUrl(Has.DeCryptWithKey("zf6APVxIy954nQ/eN1JxV6yHxcen26PpuSMLyLaw8ynui9x0H/Czww==", "njuaocpk"));
					Deley(1, 3);
				}
				FindElement(By.CssSelector(Has.DeCryptWithKey("N51hVKOFDm8vxIYvIwUmvEaMCRawnkxeswCZ9BIqVOQ=", "njuaocpk")))?.Click();
				ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DeCryptWithKey("zwTTLdmNDc3J4XD4MkdNI8BiYgrxYQKsiTGuYxJ7idqNQkS8oReI4Q==", "njuaocpk")));
				if (readOnlyCollection == null)
				{
					return true;
				}
				int num3 = ((num2 <= readOnlyCollection.Count) ? num2 : readOnlyCollection.Count);
				for (int i = 0; i < num3; i++)
				{
					if (Stop_thread)
					{
						return true;
					}
					if (list.Count == 0 || Stop_thread)
					{
						break;
					}
					thongtin.TrangThai = $"[{i + 1}/{num3}] Interact Messaging ...";
					FindElements(By.CssSelector(Has.DecryptHas("v9joWa/WIbbeXQrpCvpWCF9Km/xeqbYJ88zVk2VwsaouH6FtGPf4/w==", useHasing: true, "3za14x3sdkv3d")), i)?.Click();
					Deley(1, 4);
					if (!driver.Url.Contains(Has.DecryptHas("JXrmf/OT6on5ZS0SUB/cig==", useHasing: true, "3za14x3sdkv3d")))
					{
						Deley(1, 3);
					}
					FindElement(By.CssSelector(Has.DecryptHas("oF/MGSZ+uJg6zTuVIxC72vxQJYrTx17wnTcRe1GzT1I=", useHasing: true, "3za14x3sdkv3d"))).SendKeys(list[r.Next(0, list.Count)]);
					Deley(1, 3);
					FindElement(By.CssSelector(Has.DecryptHas("LLN3jlfT/JHhafJ1sumo7Amt59ixvqXkrXxv28BhhxRf5VvbbCUx3zOoYHpV0kgl", useHasing: true, "3za14x3sdkv3d")))?.Click();
					Deley(2, 4);
					if (ThongSo_TuongTacTinNhan.cb_Mess_SendIMG)
					{
						for (int j = 0; j < ((num3 >= num) ? 1 : (num - num3)); j++)
						{
							if (Stop_thread)
							{
								return true;
							}
							if (num == 0 || list2.Count == 0)
							{
								break;
							}
							FindElement(By.CssSelector(Has.DecryptHas("l5BZAj6jOTE=", useHasing: true, "3za14x3sdkv3d")))?.SendKeys(list2[r.Next(0, list2.Count)]);
							Deley(5, 10);
							num--;
						}
					}
					thongtin.TrangThai = $"[{i + 1}/{num3}] Interact Messaging - Success !";
					Deley(ThongSo_TuongTacTinNhan.num_Mess_TimeMin, ThongSo_TuongTacTinNhan.num_Mess_TimeMax);
					driver?.Navigate().Back();
				}
				driver?.Navigate().Back();
				thongtin.TrangThai = Has.DecryptHas("PxRX4unR5fAKK1oklYjeQMqUlwuzFggpQEzXGE5ApDE=", useHasing: true, "wtjjj4l1ke4");
			}
			catch
			{
			}
			return true;
		}

		private bool CauHinhLuotStory()
		{
			try
			{
				int num = r.Next(ThongSo_CauHinhLuotStory.num_Story_SLMin, ThongSo_CauHinhLuotStory.num_Story_SLMax);
				thongtin.TrangThai = Has.DecryptHas("0/s0Qf38NHx9bhP/TFjP79DXZe5p4APQ", useHasing: true, "s4heoafrh1");
				if (Stop_thread)
				{
					return true;
				}
				About_Home();
				Deley(2, 4);
				ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DecryptHas("UcKnpu4nD53Z8cTWzVIW9EKXfb7D3iLTa1dk4NnNlMIOPugNkeBr4wZvoW/Nx1Xh9R5eIstHCgagHCey2zD/nNI/kqoKVX+VtMpx9QTGOpd4gjYC+KgjtfQwWZkaLBjhlX5NEpqZYIk=", useHasing: true, "miylge5a")));
				if (readOnlyCollection == null)
				{
					return true;
				}
				for (int i = 0; i < ((!(num >= readOnlyCollection?.Count)) ? new int?(num) : readOnlyCollection?.Count); i++)
				{
					if (Stop_thread)
					{
						return true;
					}
					for (int j = 0; j < 3; j++)
					{
						if (Stop_thread)
						{
							return true;
						}
						if (driver.Url.Contains(Has.DecryptHas("eKZjW9Dr/W8=", useHasing: true, "miylge5a")))
						{
							break;
						}
						FindElements(By.CssSelector(Has.DecryptHas("UcKnpu4nD53Z8cTWzVIW9EKXfb7D3iLTa1dk4NnNlMIOPugNkeBr4wZvoW/Nx1Xh9R5eIstHCgagHCey2zD/nNI/kqoKVX+VtMpx9QTGOpd4gjYC+KgjtfQwWZkaLBjhlX5NEpqZYIk=", useHasing: true, "miylge5a")), 0)?.Click();
					}
					Deley(ThongSo_CauHinhLuotStory.num_Story_TimeMin, ThongSo_CauHinhLuotStory.num_Story_TimeMax);
					FindElement(By.CssSelector(Has.DecryptHas("TPO6Rk8X/JM=", useHasing: true, "miylge5a")))?.Click();
				}
				FindElement(By.CssSelector(Has.DecryptHas("44krCXaXfD7VU1f5KnuY/kZrL4nn9rfFUyPRmMYwlP5glnjAJQT2a7HHqTz/wvS2t2+Qb8+j6Wq9tyc1Q6E+kjHM/5u+1+vfYHHlRg/r6uRvmXB017ki0NrIMA2pGWnwUEnHIfECM9xrTzSdTxM8FQ==", useHasing: true, "miylge5a")))?.Click();
				thongtin.TrangThai = Has.DecryptHas("1dP9YFOCfrokpTI81L2M4Xm8ZiWrv+8V919nO9ZRNxc=", useHasing: true, "miylge5a");
			}
			catch
			{
			}
			return true;
		}

		private bool CauHinhSpam()
		{
			try
			{
				int num = r.Next(ThongSo_CauHinhSpam.num_Spam_SLMin, ThongSo_CauHinhSpam.num_Spam_SLMin);
				List<string> list = ThongSo_CauHinhSpam.rtb_Spam_NDcmt?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == Has.DecryptHas("qMz8lQABF9M=", useHasing: true, "m8puf66d"));
				List<string> list2 = ThongSo_CauHinhSpam.rtb_Spam_LUser?.Split('\n').ToList();
				list2?.RemoveAll((string x) => x == Has.DecryptHas("qMz8lQABF9M=", useHasing: true, "m8puf66d"));
				int num2 = 0;
				thongtin.TrangThai = Has.DecryptHas("rIOlaZO84eCp6jlHqNYNvw==", useHasing: true, "m8puf66d");
				foreach (string item in list2)
				{
					num2++;
					if (Stop_thread)
					{
						return true;
					}
					if (list.Count == 0)
					{
						break;
					}
					thongtin.TrangThai = $"[{num2}/{list2.Count}] Spam ... ";
					driver?.Navigate().GoToUrl(Has.DecryptHas("7ddLUlda7izt46KebKnNLr/rjtQy8jATdlS6h9BNmqw=", useHasing: true, "c9jct") + item + Has.DecryptHas("jdyMqhSqFeo=", useHasing: true, "c9jct"));
					Deley(1, 3);
					roll(2, 5);
					ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DecryptHas("q6sPj0nzGb29c1f13IeTkg==", useHasing: true, "6n1jl2jghknlpl")));
					for (int i = 0; i < ((num >= readOnlyCollection.Count) ? readOnlyCollection.Count : num); i++)
					{
						if (Stop_thread)
						{
							return true;
						}
						FindElements(By.CssSelector(Has.DecryptHas("q6sPj0nzGb29c1f13IeTkg==", useHasing: true, "6n1jl2jghknlpl")), i)?.Click();
						Deley(2, 5);
						if (!driver.Url.Contains(Has.DecryptHas("V+K05Z0F3Uc=", useHasing: true, "6n1jl2jghknlpl")))
						{
							Deley(1, 3);
						}
						FindElement(By.CssSelector(Has.DecryptHas("heShPAVyWA4iNwVIIKOd3I8WFuDclgPBneC8dwus4mA=", useHasing: true, "6n1jl2jghknlpl")))?.Click();
						Deley(2, 5);
						if (!driver.Url.Contains(Has.DecryptHas("J/6zwUA4m/X3KhiWfHQGMw==", useHasing: true, "6n1jl2jghknlpl")))
						{
							Deley(1, 3);
						}
						FindElement(By.CssSelector(Has.DecryptHas("GK353tXFvT4=", useHasing: true, "6n1jl2jghknlpl"))).SendKeys(list[r.Next(0, list.Count)]);
						Deley(2, 5);
						FindElement(By.CssSelector(Has.DecryptHas("E1NR8Aw9p2NymmPSnv3cKOIFpNI3eIjW4kvCrE8zaYs=", useHasing: true, "6n1jl2jghknlpl")))?.Click();
						Deley(4, 7);
						driver.Navigate().Back();
						Deley(2, 4);
						driver.Navigate().Back();
						Deley(ThongSo_CauHinhSpam.num_Spam_TimeMin, ThongSo_CauHinhSpam.num_Spam_TimeMin);
					}
					thongtin.TrangThai = $"[{num2}/{list2.Count}] Spam - Success ! ";
				}
			}
			catch
			{
			}
			return true;
		}

		private bool ShareBaiViet()
		{
			try
			{
				int num = r.Next(ThongSo_ShareBaiViet.num_Share_SLMin, ThongSo_ShareBaiViet.num_Share_SLMax);
				List<string> list = ThongSo_ShareBaiViet.rtb_Share_Link?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == Has.DecryptHas("LeE0gl8Pqkc=", useHasing: true, "5rxot0f9exnms"));
				int num2 = 0;
				thongtin.TrangThai = Has.DecryptHas("bRX+BOqJM0Ypna2Z044BQQ==", useHasing: true, "5rxot0f9exnms");
				foreach (string item in list)
				{
					num2++;
					if (Stop_thread)
					{
						return true;
					}
					if (!item.Contains(Has.DecryptHas("WUoNnn5ErnXf/wGpGabz55SLUr3tGguiWvRlhJdXmk8=", useHasing: true, "ig431zl")))
					{
						continue;
					}
					driver?.Navigate().GoToUrl(item.Trim());
					Deley(1, 3);
					thongtin.TrangThai = $"[{num2}/{list.Count}] Share Post ... ";
					FindElement(By.CssSelector(Has.DecryptHas("uianlzF8Mxe7phSxMzGNKhcPAzupEDzDldvldnDuOMw=", useHasing: true, "9ld8vgttaushcg")))?.Click();
					Deley(2, 4);
					ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DecryptHas("IxYAc0xuRXQago5/x8gFH1/VKdIJMMmOgIK4AZvsHpNBBWFHHGs8+w==", useHasing: true, "9ld8vgttaushcg")));
					if (readOnlyCollection == null || readOnlyCollection.Count <= 1)
					{
						break;
					}
					for (int i = 0; i < num; i++)
					{
						if (Stop_thread)
						{
							break;
						}
						readOnlyCollection[i].Click();
						Deley(1, 2);
					}
					FindElement(By.CssSelector(Has.DecryptHas("Pjn2wUWMknU=", useHasing: true, "makn3gzu")))?.Click();
					thongtin.TrangThai = $"[{num2}/{list.Count}] Share Post - Success ! ";
					Deley(2, 4);
					driver.Navigate().Back();
				}
				thongtin.TrangThai = Has.DecryptHas("v3Y4/yccdZym8QOzXAs0isYTK9rHDsSr", useHasing: true, "w9ll9gffw6j");
			}
			catch
			{
			}
			return true;
		}

		private bool FollowGoiY()
		{
			try
			{
				int num = r.Next(ThongSo_FollowGoiY.num_FollowGoiY_SLMin, ThongSo_FollowGoiY.num_FollowGoiY_SLMax);
				driver?.Navigate().GoToUrl(Has.DecryptHas("XobUufN4Bn5AMr0ML4gZXBwYhWtaboz4NnIW4YT6kohIJEYjkY3CCnfvjwNz3kIg", useHasing: true, "oz94w4yn0"));
				thongtin.TrangThai = Has.DecryptHas("23QvXLxK+D4zZM/Z9OIvnKad7Gl8cpZd", useHasing: true, "1ogj444o02h1");
				Deley(1, 3);
				roll(1, 3);
				for (int i = 0; i < num; i++)
				{
					thongtin.TrangThai = $"[{i + 1}/{num}] Follow ... ";
					if (Stop_thread)
					{
						return true;
					}
					if (check_element(By.CssSelector(Has.DecryptHas("ftEvl1cZJjRXuPRP0F9Zhucxs/bkicofelwngmnquGA=", useHasing: true, "1ogj444o02h1"))))
					{
						FindElement(By.CssSelector(Has.DecryptHas("ftEvl1cZJjRXuPRP0F9Zhucxs/bkicofelwngmnquGA=", useHasing: true, "1ogj444o02h1")))?.Click();
					}
					ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DecryptHas("6TtbLS5dl2TgHTpm3ZOh+1EHSsNh5ZGYlNe59cRl33w=", useHasing: true, "1ogj444o02h1")));
					if (readOnlyCollection == null)
					{
						return true;
					}
					FindElements(By.CssSelector(Has.DecryptHas("6TtbLS5dl2TgHTpm3ZOh+1EHSsNh5ZGYlNe59cRl33w=", useHasing: true, "1ogj444o02h1")), r.Next(0, readOnlyCollection.Count))?.Click();
					if (check_chanTT())
					{
						return false;
					}
					Deley(ThongSo_FollowGoiY.num_FollowGoiY_TimeMin, ThongSo_FollowGoiY.num_FollowGoiY_TimeMax);
					thongtin.TrangThai = $"[{i + 1}/{num}] Follow - Success ! ";
					roll(1, 2);
				}
				thongtin.TrangThai = Has.DeCryptWithKey("9FT3CWXZbiewaW/gefIWWctfRF8IFJdrFcIbLMeHysc=", "vv9w94lgna");
			}
			catch
			{
			}
			return true;
		}

		private bool FollowTuKhoa()
		{
			try
			{
				int num = r.Next(ThongSo_FollowTuKhoa.num_FollowTuKhoa_SLMin, ThongSo_FollowTuKhoa.num_FollowTuKhoa_SLMax);
				List<string> list = ThongSo_FollowTuKhoa.rtb_FollowTuKhoa_TuKhoa?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == Has.DecryptHas("t6Xhl/09N5A=", useHasing: true, "dkakdo"));
				thongtin.TrangThai = Has.DecryptHas("xe+9ZKVCQxPH4lCqbTbXaN9oXaTw8/Pa", useHasing: true, "dkakdo");
				About_explore();
				Deley(1, 3);
				roll(1, 3);
				foreach (string item in list)
				{
					thongtin.TrangThai = "Follow by \"" + item + "\"  ... ";
					if (Stop_thread)
					{
						return true;
					}
					FindElement(By.CssSelector(Has.DecryptHas("+gR2fHfSgCI=", useHasing: true, "1wnscjolgvs5")))?.Clear();
					FindElement(By.CssSelector(Has.DecryptHas("+gR2fHfSgCI=", useHasing: true, "1wnscjolgvs5")))?.SendKeys(item);
					Deley(2, 4);
					ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DecryptHas("uHufASut3WAlBPzT8mIXpDgC/Z6mFBbnZDOEYtCnESDsQCjqPcAHOQ==", useHasing: true, "1wnscjolgvs5")));
					roll(2, 4);
					if (readOnlyCollection == null)
					{
						continue;
					}
					for (int i = 0; i < num; i++)
					{
						if (Stop_thread)
						{
							return true;
						}
						FindElements(By.CssSelector(Has.DecryptHas("uHufASut3WAlBPzT8mIXpDgC/Z6mFBbnZDOEYtCnESDsQCjqPcAHOQ==", useHasing: true, "1wnscjolgvs5")), r.Next(0, readOnlyCollection.Count))?.Click();
						Deley(2, 4);
						if (check_chanTT())
						{
							return false;
						}
						if (!check_element(By.CssSelector(Has.DecryptHas("tl/crV0+I1E=", useHasing: true, "1wnscjolgvs5"))))
						{
							FindElement(By.CssSelector(Has.DecryptHas("5H/IskazuJ4=", useHasing: true, "1wnscjolgvs5")))?.Click();
						}
						if (!check_element(By.CssSelector(Has.DecryptHas("tl/crV0+I1E=", useHasing: true, "1wnscjolgvs5"))))
						{
							FindElement(By.CssSelector(Has.DecryptHas("Q1l1g5OP1IE=", useHasing: true, "1wnscjolgvs5")))?.Click();
						}
						if (check_element(By.CssSelector(Has.DecryptHas("9xe0k56CzK5mV/X0AwlnWFAVIbvAnftVlsjxt1VBUHM=", useHasing: true, "1wnscjolgvs5"))))
						{
							FindElement(By.CssSelector(Has.DecryptHas("9xe0k56CzK5mV/X0AwlnWFAVIbvAnftVlsjxt1VBUHM=", useHasing: true, "1wnscjolgvs5")))?.Click();
						}
						num--;
						Deley(ThongSo_FollowTuKhoa.num_FollowTuKhoa_TimeMin, ThongSo_FollowTuKhoa.num_FollowTuKhoa_TimeMax);
						driver?.Navigate().Back();
						roll(1, 2);
					}
					thongtin.TrangThai = "Follow by \"" + item + "\"  - Success ! ";
					Deley(2, 4);
				}
			}
			catch
			{
			}
			return true;
		}

		private bool FollowUser()
		{
			try
			{
				List<string> list = ThongSo_FollowUser.rtb_FollowUser_User?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == Has.DecryptHas("eudyeUb/yEc=", useHasing: true, "v7azvrquxu"));
				int num = 0;
				thongtin.TrangThai = Has.DecryptHas("Bz1XMnpvLXUL6JUDKgI72oEU0Bip3cd3", useHasing: true, "v7azvrquxu");
				foreach (string item in list)
				{
					num++;
					if (Stop_thread)
					{
						return true;
					}
					driver?.Navigate().GoToUrl("https://www.instagram.com/" + item + "/");
					thongtin.TrangThai = $"[{num}/{list.Count}] Follow by User ... ";
					Deley(1, 3);
					roll(1, 3);
					FindElement(By.CssSelector("button.sqdOP.L3NKy._4pI4F.y3zKF"))?.Click();
					thongtin.TrangThai = $"[{num}/{list.Count}] Follow by User - Success ! ";
					Deley(ThongSo_FollowUser.num_FollowUser_TimeMin, ThongSo_FollowUser.num_FollowUser_TimeMax);
				}
			}
			catch
			{
			}
			return true;
		}

		private bool FollowLaiFollowers()
		{
			try
			{
				int num = r.Next(ThongSo_FollowLaiFollowers.num_FollowLaiFollower_SLMin, ThongSo_FollowLaiFollowers.num_FollowLaiFollower_SLMax);
				About_Profile();
				thongtin.TrangThai = Has.DecryptHas("Yt88UzJ9r45aBSiUwmfgiW8k/aJKJ1iQrFmlAFuEsZ4=", useHasing: true, "l4jih0ed");
				Deley(1, 3);
				FindElement(By.CssSelector(Has.DecryptHas("3oxlAweBzQgsvyTx1emPT9LQsFhwSa0Xew2eaLoM2mIFanncQxKAMX3ziRytfu/WaUAE2jLH8ueePX+KD7cmjA==", useHasing: true, "l4jih0ed")))?.Click();
				Deley(1, 3);
				if (!driver.Url.Contains(Has.DecryptHas("mvdUTdOpTGlPZiGw0Fcv1w==", useHasing: true, "l4jih0ed")))
				{
					Deley(3, 6);
				}
				ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DecryptHas("C5caEGKvC/smi9hRV2SmkO6G9isbPaK4s7upa0cx+w4=", useHasing: true, "l4jih0ed")));
				if (readOnlyCollection == null)
				{
					return true;
				}
				int num2 = ((num > readOnlyCollection.Count) ? num : readOnlyCollection.Count);
				for (int i = 0; i < num2; i++)
				{
					if (Stop_thread)
					{
						return true;
					}
					thongtin.TrangThai = $"[{i + 1}/{num2}] Follow ... ";
					FindElements(By.CssSelector(Has.DecryptHas("C5caEGKvC/smi9hRV2SmkO6G9isbPaK4s7upa0cx+w4=", useHasing: true, "l4jih0ed")), i)?.Click();
					if (check_chanTT())
					{
						return false;
					}
					Deley(ThongSo_FollowLaiFollowers.num_FollowLaiFollower_TimeMin, ThongSo_FollowLaiFollowers.num_FollowLaiFollower_TimeMax);
				}
				thongtin.TrangThai = Has.DecryptHas("Yt88UzJ9r45aBSiUwmfgieeAf0IKeNuxUlqM3gucFS6sWaUAW4Sxng==", useHasing: true, "l4jih0ed");
				driver?.Navigate().Back();
			}
			catch
			{
			}
			return true;
		}

		private bool FollowUserLikePost()
		{
			try
			{
				int num = r.Next(ThongSo_FollowUserLikePost.num_FollowUserLikePost_SLMin, ThongSo_FollowUserLikePost.num_FollowUserLikePost_SLMax);
				List<string> list = ThongSo_FollowUserLikePost.rtb_FollowUserLikePost_Link?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == Has.DeCryptWithKey("UGpOigZI34I=", "fsi6e2"));
				thongtin.TrangThai = Has.DeCryptWithKey("wqYCHTpCRFGx9vXinl6KNHz0C5LWncpx7ZJcoru30MI=", "fsi6e2");
				foreach (string item in list)
				{
					if (Stop_thread)
					{
						return true;
					}
					driver?.Navigate().GoToUrl(item.Trim());
					Deley(1, 3);
					FindElement(By.CssSelector(Has.DeCryptWithKey("V/2i430I6W4=", "sholm1u312")))?.Click();
					FindElement(By.CssSelector(Has.DeCryptWithKey("fJLaXoyqmO9bQI6WFkSm0A==", "sholm1u312")))?.Click();
					Deley(1, 3);
					if (!driver.Url.Contains(Has.DeCryptWithKey("eILKUt1VPGUDZlzatb02Ew==", "sholm1u312")))
					{
						Deley(3, 6);
					}
					ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DeCryptWithKey("JLAaOF7vL9AnnVO7q70parjgyZbXX5YZA2Zc2rW9NhM=", "sholm1u312")));
					if (readOnlyCollection == null)
					{
						continue;
					}
					int num2 = ((num > readOnlyCollection.Count) ? readOnlyCollection.Count : num);
					for (int i = 0; i < num2; i++)
					{
						if (Stop_thread)
						{
							return true;
						}
						thongtin.TrangThai = $"[{i + 1}/{num2}] Đang Follow ... ";
						FindElements(By.CssSelector(Has.DeCryptWithKey("JLAaOF7vL9AnnVO7q70parjgyZbXX5YZA2Zc2rW9NhM=", "sholm1u312")), 0)?.Click();
						if (check_chanTT())
						{
							return false;
						}
						Deley(ThongSo_FollowUserLikePost.num_FollowUserLikePost_TimeMin, ThongSo_FollowUserLikePost.num_FollowUserLikePost_TimeMax);
						if (check_element(By.CssSelector(Has.DeCryptWithKey("8eABhIRvGOYdSCcAz9zqACiVgEcn3o7dZeZnF0aGhGA=", "mv6sd5km"))))
						{
							FindElement(By.CssSelector(Has.DeCryptWithKey("8eABhIRvGOYdSCcAz9zqACiVgEcn3o7dZeZnF0aGhGA=", "mv6sd5km")))?.Click();
						}
					}
				}
				thongtin.TrangThai = Has.DeCryptWithKey("fxIyI+BdGhZENdsnImcOk8Rsg4yd1Vl193H/Gs23qB5EhmC+0rjQrQ==", "mv6sd5km");
			}
			catch
			{
			}
			return true;
		}

		private bool FollowFollowerUser()
		{
			try
			{
				int num = r.Next(ThongSo_FollowFollowerUser.num_FollowFollowerUser_SLMin, ThongSo_FollowFollowerUser.num_FollowFollowerUser_SLMax);
				List<string> list = ThongSo_FollowFollowerUser.rtb_FollowFollowerUser_ID?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == Has.DeCryptWithKey("ckaVZpYQAWY=", "6pkgt1iww93xbu"));
				thongtin.TrangThai = Has.DeCryptWithKey("a1nI8eJCIHu/x2Ut2Z28a17j+XlyQAaICupFYy7tYF4=", "jerv11o");
				int num2 = 0;
				foreach (string item in list)
				{
					num2++;
					if (Stop_thread)
					{
						return true;
					}
					driver?.Navigate().GoToUrl(Has.DeCryptWithKey("Hkn/TpZaxpY7faHejC8lnhVolQoqpnI+wuwXMddbGZ0=", "jerv11o") + item.Trim() + Has.DeCryptWithKey("RGf8Rlz+4fo=", "jerv11o"));
					Deley(1, 3);
					thongtin.TrangThai = $"[{num2}/{list.Count}] Follow User => {item} ... ";
					FindElement(By.CssSelector(Has.DeCryptWithKey("zdxcIf6HlnELULS2zAMXQj8/9H4/ViYIXdSkyW/IV5ii3Fy87eB2CIA34jiJi15TjB1QaF1SzsY8Tc1/SD+zsA==", "jerv11o")))?.Click();
					Deley(1, 3);
					if (!driver.Url.Contains(Has.DeCryptWithKey("jTh0WaR0xVOjZD41gk6YEA==", "jerv11o")))
					{
						Deley(3, 6);
					}
					ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DeCryptWithKey("gLkRTvDKB0rUQH3tnm8zPVmPWnKMfAX9zcy6hT5jIV4=", "jerv11o")));
					if (readOnlyCollection == null)
					{
						continue;
					}
					for (int i = 0; i < ((num < readOnlyCollection?.Count) ? new int?(num) : readOnlyCollection?.Count); i++)
					{
						if (Stop_thread)
						{
							return true;
						}
						Deley(1, 3);
						FindElements(By.CssSelector(Has.DeCryptWithKey("gLkRTvDKB0rUQH3tnm8zPVmPWnKMfAX9zcy6hT5jIV4=", "jerv11o")), 0)?.Click();
						if (check_chanTT())
						{
							return false;
						}
						Deley(ThongSo_FollowLaiFollowers.num_FollowLaiFollower_TimeMin, ThongSo_FollowLaiFollowers.num_FollowLaiFollower_TimeMax);
						if (check_element(By.CssSelector(Has.DeCryptWithKey("19E9zz4es+4QSzGYVyI2/bSQ2MsHw2p8VPT5l5orZl8=", "jerv11o"))))
						{
							FindElement(By.CssSelector(Has.DeCryptWithKey("19E9zz4es+4QSzGYVyI2/bSQ2MsHw2p8VPT5l5orZl8=", "jerv11o")))?.Click();
						}
					}
					driver?.Navigate().Back();
					Deley(2, 4);
				}
				thongtin.TrangThai = Has.DeCryptWithKey("qNtSFdFZJRe3C/9kedus5/6B73PP3RlBHL55ussQ9uvbImCd7Txh2A==", "dt82s5");
			}
			catch
			{
			}
			return true;
		}

		private bool FollowFollowingUser()
		{
			try
			{
				int num = r.Next(ThongSo_FollowFollowingUser.num_FollowFollowingUser_SLMin, ThongSo_FollowFollowingUser.num_FollowFollowingUser_SLMax);
				List<string> list = ThongSo_FollowFollowingUser.rtb_FollowFollowingUser_ID?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == Has.DecryptHas("M8+7gQt4vC0=", useHasing: true, "wkrhmirgko0"));
				int num2 = 0;
				thongtin.TrangThai = Has.DecryptHas("FVWFEXnfpnwwL+Yg2LkyedsApfq32Zey/lp6Feqh6NM=", useHasing: true, "wkrhmirgko0");
				foreach (string item in list)
				{
					num2++;
					if (Stop_thread)
					{
						return true;
					}
					driver?.Navigate().GoToUrl(Has.DecryptHas("z1aBQsvgNR7nzMXMGTxFv5tUIIvj/DXljbEEWs8WdBs=", useHasing: true, "wkrhmirgko0") + item.Trim() + Has.DecryptHas("ti2JziZRzwU=", useHasing: true, "wkrhmirgko0"));
					Deley(1, 3);
					thongtin.TrangThai = $"[{num2}/{list.Count}] Follow User => {item} ... ";
					FindElement(By.CssSelector(Has.DecryptHas("vB6P6yaqACtKVLr3abJeKIcY1FbAwA3EFvb6amAEXqv/mj7p+EIOXBDe+CKzjIzzuej3qdYo6J4Gjb1dY0dF3A==", useHasing: true, "wkrhmirgko0")))?.Click();
					Deley(1, 3);
					if (!driver.Url.Contains(Has.DecryptHas("IRFfk0YRolo2aK80i59KUA==", useHasing: true, "99yvuixgjks")))
					{
						Deley(3, 6);
					}
					ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector(Has.DecryptHas("gsZLONGP1NNd+upcKpFL/s6Vj6+cZqWeYx1VQ8PXbsM=", useHasing: true, "99yvuixgjksc0l")));
					if (readOnlyCollection == null)
					{
						break;
					}
					for (int i = 0; i < ((num < readOnlyCollection.Count) ? num : readOnlyCollection.Count); i++)
					{
						if (Stop_thread)
						{
							return true;
						}
						Deley(1, 3);
						FindElements(By.CssSelector(Has.DecryptHas("gsZLONGP1NNd+upcKpFL/s6Vj6+cZqWeYx1VQ8PXbsM=", useHasing: true, "99yvuixgjksc0l")), 0)?.Click();
						if (check_chanTT())
						{
							return false;
						}
						Deley(ThongSo_FollowFollowingUser.num_FollowFollowingUser_TimeMin, ThongSo_FollowFollowingUser.num_FollowFollowingUser_TimeMax);
						if (check_element(By.CssSelector(Has.DecryptHas("L3TCza8jblz4gdbMRPNmOyNFv0HmcHBrz7Ov7MEKdhk=", useHasing: true, "99yvuixgjksc0l"))))
						{
							FindElement(By.CssSelector(Has.DecryptHas("L3TCza8jblz4gdbMRPNmOyNFv0HmcHBrz7Ov7MEKdhk=", useHasing: true, "99yvuixgjksc0l")))?.Click();
						}
					}
					driver?.Navigate().Back();
					Deley(2, 4);
				}
				thongtin.TrangThai = Has.DecryptHas("R0RspAEmbL0kaiuLez4oAQHl9N50ig7BGlDqeGj1YFgYzll/+awZXw==", useHasing: true, "99yvuixgjksc0l");
			}
			catch
			{
			}
			return true;
		}

		private bool UnFollow()
		{
			try
			{
				int num = r.Next(ThongSo_UnFollow.num_UnFollow_SLMin, ThongSo_UnFollow.num_UnFollow_SLMax);
				About_Profile();
				thongtin.TrangThai = Has.DecryptHas("IkC6Vh6pq7D9fJV6OWwFjg==", useHasing: true, "4onc3x990kxap");
				Deley(1, 3);
				if (ThongSo_UnFollow.cb_UnFolowFollower)
				{
					IWebElement webElement = FindElement(By.CssSelector(Has.DecryptHas("YQ52W73w6BI/Rwj6gnI9stJU+g+oCp1m/gqKuUn2ntVxn1o+81SJwSJMBAcATofy/J6BL4nhHbZK+9+NRL8lvg==", useHasing: true, "4onc3x990kxap")));
					string s = webElement?.Text;
					webElement?.Click();
					Deley(3, 5);
					if (!driver.Url.Contains(Has.DecryptHas("fuoFa5D/XqmPnpcnlulQAw==", useHasing: true, "4onc3x990kxap")))
					{
						Deley(3, 6);
					}
					for (int i = 1; i < ((num > int.Parse(s)) ? (int.Parse(s) + 1) : (num + 1)); i++)
					{
						if (Stop_thread)
						{
							return true;
						}
						FindElement(By.CssSelector($".PZuss > li:nth-child({i}) > div:nth-child(1) > div:nth-child(3) > button:nth-child(1)"))?.Click();
						Deley(3, 4);
						FindElement(By.CssSelector(Has.DecryptHas("oMx4sPqZAweZsfno/x58rSft6j7CNMNXUS2i4qU7JLs=", useHasing: true, "4onc3x990kxap")))?.Click();
						Deley(ThongSo_UnFollow.num_UnFollow_TimeMin, ThongSo_UnFollow.num_UnFollow_TimeMax);
					}
					driver?.Navigate().Back();
				}
				if (!ThongSo_UnFollow.cb_UnFolowFollowing)
				{
					return true;
				}
				IWebElement webElement2 = FindElement(By.CssSelector(Has.DecryptHas("YQ52W73w6BI/Rwj6gnI9sojnuuSps5PC/gqKuUn2ntVxn1o+81SJwSJMBAcATofy/J6BL4nhHbZK+9+NRL8lvg==", useHasing: true, "4onc3x990kxap")));
				string s2 = webElement2?.Text;
				webElement2?.Click();
				Deley(3, 5);
				if (!driver.Url.Contains(Has.DecryptHas("oFYnnWi7TmVozK2lsxQoSA==", useHasing: true, "y34jv1zsv3z")))
				{
					Deley(3, 6);
				}
				for (int j = 1; j < ((num > int.Parse(s2)) ? (int.Parse(s2) + 1) : (num + 1)); j++)
				{
					if (Stop_thread)
					{
						return true;
					}
					FindElement(By.CssSelector($"li.wo9IH:nth-child({j}) > div:nth-child(1) > div:nth-child(2) > button:nth-child(1)"))?.Click();
					Deley(3, 4);
					FindElement(By.CssSelector(Has.DecryptHas("i1BfBBUpkjd41mE7wxxEjRmCPmuG1m7fE9fLA7h5Maw=", useHasing: true, "bsby3")))?.Click();
					Deley(ThongSo_UnFollow.num_UnFollow_TimeMin, ThongSo_UnFollow.num_UnFollow_TimeMax);
				}
				driver?.Navigate().Back();
				thongtin.TrangThai = Has.DecryptHas("lzmD2lPV26pLbPBwnv/vpHTmTshII38U", useHasing: true, "56t5v4vcpjt7b");
				Deley(2, 3);
			}
			catch
			{
			}
			return true;
		}

		private bool ChangeProfile()
		{
			try
			{
				Khoa_acc = ThongSo_Change_profile.cb_LockAcc;
				List<string> list = File.ReadAllLines(Has.DecryptHas("xCblml3wCj8=", useHasing: true, "lm45me10")).ToList();
				List<string> list2 = ThongSo_Change_profile.rtb_Pass?.Split('\n').ToList();
				list2?.RemoveAll((string x) => x == Has.DecryptHas("ATazlMVqHJs=", useHasing: true, "lm45me10"));
				List<string> list3 = ThongSo_Change_profile.rtb_TieuSu?.Split('\n').ToList();
				list3?.RemoveAll((string x) => x == Has.DecryptHas("ATazlMVqHJs=", useHasing: true, "lm45me10"));
				List<string> list4 = ThongSo_Change_profile.rtb_web?.Split('\n').ToList();
				list4?.RemoveAll((string x) => x == Has.DecryptHas("ATazlMVqHJs=", useHasing: true, "lm45me10"));
				List<string> list5 = ThongSo_Change_profile.rtb_hotmail?.Split('\n').ToList();
				list5?.RemoveAll((string x) => x == Has.DecryptHas("ATazlMVqHJs=", useHasing: true, "lm45me10"));
				List<string> list6 = (string.IsNullOrEmpty(ThongSo_Change_profile.txt_PathImg) ? null : Directory.GetFiles(ThongSo_Change_profile.txt_PathImg, Has.DecryptHas("+gwSGGzhsCo=", useHasing: true, "lm45me10"), SearchOption.AllDirectories)?.Where((string s) => s.EndsWith(Has.DecryptHas("IhxFrrfFNcc=", useHasing: true, "lm45me10")) || s.EndsWith(Has.DecryptHas("RWo97NUoycU=", useHasing: true, "lm45me10"))).ToList());
				string text = Has.DecryptHas("xYcHBgArBZo+ycLhuAQapAULLmLiTIHYgLPZiquBRI1jORhOnPMf2AE2s5TFahyb", useHasing: true, "lm45me10");
				driver?.Navigate().GoToUrl(text);
				thongtin.TrangThai = Has.DecryptHas("FfVTbH1ne+AnM4tp++YiykXwFWRKBT9X", useHasing: true, "lm45me10");
				Deley(1, 3);
				thongtin.Mail = FindElement(By.CssSelector(Has.DecryptHas("G+bddmMSbU4YssvlyRpS5A==", useHasing: true, "ybbkud71lly")))?.GetAttribute(Has.DecryptHas("QMpximThS2Q=", useHasing: true, "ybbkud71lly"));
				if (Stop_thread && !tt.status)
				{
					return true;
				}
				if (ThongSo_Change_profile.cb_DoiTen)
				{
					thongtin.TrangThai = Has.DecryptHas("DkVe1Gf0Swn6oXLRWSaDe6HKiT9QdPFb", useHasing: true, "ybbkud71lly");
					FindElement(By.CssSelector(Has.DecryptHas("Qqvzdbsw7sWhyok/UHTxWw==", useHasing: true, "ybbkud71lly")))?.Clear();
					Thread.Sleep(500);
					FindElement(By.CssSelector(Has.DecryptHas("Qqvzdbsw7sWhyok/UHTxWw==", useHasing: true, "ybbkud71lly")))?.SendKeys(list[r.Next(0, list.Count)]);
					Deley(1, 3);
				}
				if (Stop_thread)
				{
					return true;
				}
				if (ThongSo_Change_profile.cb_Web && list4.Count != 0)
				{
					thongtin.TrangThai = Has.DecryptHas("ZTymEOYlVnlgVaSlvyFFJhYe04Zukc2+", useHasing: true, "b0hz2");
					FindElement(By.CssSelector(Has.DecryptHas("8fHyhrX9XskHhz9FAKJGMg==", useHasing: true, "b0hz2")))?.Clear();
					Thread.Sleep(500);
					FindElement(By.CssSelector(Has.DecryptHas("8fHyhrX9XskHhz9FAKJGMg==", useHasing: true, "b0hz2")))?.SendKeys(list4[r.Next(0, list4.Count)]);
					Deley(1, 3);
				}
				if (Stop_thread)
				{
					return true;
				}
				if (ThongSo_Change_profile.cb_TieuSu)
				{
					thongtin.TrangThai = Has.DecryptHas("hFkjhRjSULmUaoM8p6fNvg==", useHasing: true, "5ez6uh3lf1sx3");
					string text2 = ((list3.Count == 0) ? Has.DecryptHas("heD96S2o2ss=", useHasing: true, "5ez6uh3lf1sx3") : list3[r.Next(0, list3.Count)]);
					FindElement(By.CssSelector(Has.DecryptHas("nsFemAyPM88=", useHasing: true, "5ez6uh3lf1sx3")))?.Clear();
					if (text2.Contains('|'))
					{
						foreach (string item in text2.Split('|').ToList())
						{
							FindElement(By.CssSelector(Has.DecryptHas("nsFemAyPM88=", useHasing: true, "5ez6uh3lf1sx3")))?.SendKeys(item);
							Thread.Sleep(500);
							FindElement(By.CssSelector(Has.DecryptHas("nsFemAyPM88=", useHasing: true, "5ez6uh3lf1sx3")))?.SendKeys(Keys.Enter);
							Deley(1, 3);
						}
					}
					else
					{
						FindElement(By.CssSelector(Has.DecryptHas("yex86Bt1CeY=", useHasing: true, "i36l2g9")))?.SendKeys(text2);
					}
					Deley(1, 3);
				}
				if (Stop_thread)
				{
					return true;
				}
				if (ThongSo_Change_profile.cb_GioiTinh)
				{
					if (!driver.Url.Contains(text))
					{
						driver?.Navigate().GoToUrl(text);
						Deley(1, 3);
					}
					thongtin.TrangThai = Has.DecryptHas("xoP28bE25laSD/vYhUF/ew==", useHasing: true, "i36l2g9");
					FindElement(By.CssSelector(Has.DecryptHas("HMkr87G5pFJhSiVLZBLSrA==", useHasing: true, "cinsu")))?.Click();
					Deley(1, 3);
					if (ThongSo_Change_profile.rad_Nam)
					{
						FindElement(By.CssSelector(Has.DecryptHas("+xsw8srffyjO7UaK0C9y5Sx9GZ1/VCmbb1cUHuimAew=", useHasing: true, "cinsu")))?.Click();
					}
					if (ThongSo_Change_profile.rad_Nu)
					{
						FindElement(By.CssSelector(Has.DecryptHas("+xsw8srffyjO7UaK0C9y5Sx9GZ1/VCmbwYBXu+cJQOA=", useHasing: true, "cinsu")))?.Click();
					}
					Deley(1, 3);
					FindElement(By.CssSelector(Has.DecryptHas("tcZ+bGDh/71Ev0/5fhnwbOKyFYt6ZwSf9zOrIVgJ1Ns=", useHasing: true, "cinsu")))?.Click();
					Deley(1, 3);
				}
				ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector("button.sqdOP.L3NKy.y3zKF"));
				if (readOnlyCollection.Count == 1)
				{
					FindElement(By.CssSelector("#react-root > section > main > div > article > form > div:nth-child(10) > div > div > button"))?.Click();
				}
				else
				{
					FindElement(By.CssSelector("#react-root > section > main > div > article > form > div:nth-child(11) > div > div > button"))?.Click();
				}
				Deley(4, 6);
				thongtin.FullName = FindElement(By.CssSelector(Has.DecryptHas("LXYGEfo0H59Y+pdZwWzKGQ==", useHasing: true, "cinsu")))?.GetAttribute(Has.DecryptHas("qXLMZrDqg1k=", useHasing: true, "cinsu"));
				if (Stop_thread)
				{
					return true;
				}
				if (ThongSo_Change_profile.cb_GoAvt)
				{
					if (!driver.Url.Contains(text))
					{
						driver?.Navigate().GoToUrl(text);
						Deley(1, 3);
					}
					string text3 = FindElement(By.CssSelector(Has.DecryptHas("madrWFFFD00=", useHasing: true, "p7u72j569")))?.GetAttribute(Has.DecryptHas("BttZpdxoc8s=", useHasing: true, "p7u72j569"));
					if (!text3.Contains(Has.DecryptHas("sYRVwvJ4yXWD8XfCvl+Fy+Stmv2iG+f9JGvdydc0HW0K4LnzI09mlFyv9RnDPhmVyLsVO5RtAYU=", useHasing: true, "p7u72j569")))
					{
						thongtin.TrangThai = Has.DecryptHas("50A1HzQvsj1OTLMEkK7JO5V7/AdZfMPa", useHasing: true, "2w0majb78974");
						FindElement(By.CssSelector(Has.DecryptHas("L51EP07xHP0=", useHasing: true, "2w0majb78974")))?.Click();
						Deley(2, 4);
						FindElement(By.CssSelector(Has.DecryptHas("8Iah9eqEDzNQwQqFBQy315qfRM6ZNNmSd7FvRKGf2sI=", useHasing: true, "2w0majb78974")))?.Click();
						Deley(2, 4);
						if (!FindElement(By.CssSelector(Has.DecryptHas("L51EP07xHP0=", useHasing: true, "2w0majb78974"))).GetAttribute(Has.DecryptHas("4pzEADMG8uA=", useHasing: true, "2w0majb78974")).Contains(Has.DecryptHas("iMp8hw8Gv40yREuEQHIwY3M756IT7rm6pqzpYchhD83iVEWwkRWq+H/0A5HQVuhtqXsSFB4NYCk=", useHasing: true, "2w0majb78974")))
						{
							Deley(5, 6);
						}
						thongtin.TrangThai = Has.DecryptHas("50A1HzQvsj0T0v9QwEq3HdWhZC3NEYiJ", useHasing: true, "2w0majb78974");
					}
				}
				if (Stop_thread)
				{
					return true;
				}
				if (ThongSo_Change_profile.cb_UpAvt && list6.Count != 0)
				{
					if (!driver.Url.Contains(text))
					{
						driver?.Navigate().GoToUrl(text);
						Deley(1, 3);
					}
					FindElements(By.CssSelector(Has.DecryptHas("yL3KanKU4EZ3Pgdb711hmQ==", useHasing: true, "wait2m1q3s9")), 1)?.SendKeys(list6[r.Next(0, list6.Count)]);
					Deley(2, 5);
					FindElement(By.CssSelector(Has.DecryptHas("bvH4p7NCk92wQl8SvfZmlw==", useHasing: true, "9zo8am7q2p2bpn")))?.Click();
					Deley(5, 10);
					FindElements(By.CssSelector("button.aOOlW.bIiDR"), 1)?.Click();
					Deley(5, 10);
				}
				if (Stop_thread)
				{
					return true;
				}
				if (ThongSo_Change_profile.cb_DeletePhone_addmail)
				{
					if (!driver.Url.Contains(text))
					{
						driver?.Navigate().GoToUrl(text);
						Deley(1, 3);
					}
					FindElement(By.XPath("//*[@id=\"pepPhone Number\"]"))?.Click();
					Deley(1, 2);
					for (int i = 0; i < 20; i++)
					{
						FindElement(By.XPath("//*[@id=\"pepPhone Number\"]"))?.SendKeys(Keys.Backspace);
					}
					Deley(2, 3);
					FindElement(By.CssSelector("input#pepEmail.JLJ-B.zyHYP"))?.Clear();
					Deley(1, 2);
					if (ThongSo_Change_profile.rad_FakeEmail)
					{
						FindElement(By.CssSelector(Has.DecryptHas("iWiBqVZP7ETCS5cKlhUTQTSDZBU0EIPgiTDKD1uWLos=", useHasing: true, "movnildr")))?.SendKeys(thongtin.User + Has.DecryptHas("Xw2bibPnbw8=", useHasing: true, "movnildr") + random(6) + Has.DecryptHas("5DkX7Bi2zTs=", useHasing: true, "movnildr"));
						Deley(1, 2);
						FindElement(By.CssSelector(Has.DecryptHas("3rchmITOEfYo3v3LRl3PfrxmgcGjw8r21+GWmUi824A=", useHasing: true, "g2cuap"))).Click();
						Deley(4, 6);
					}
					else if (ThongSo_Change_profile.rad_hotmail && list5.Count != 0)
					{
						bool flag = false;
						thongtin.TrangThai = Has.DecryptHas("R+Oqv1v8SHn8qrTqm078k6dGuKF2oIxC1dx/dgdDB1A=", useHasing: true, "g2cuap");
						roll_element(FindElement(By.CssSelector(Has.DecryptHas("gVAJu0uwv9/gAvcWHreoaPWDV7SM6qK5+rYMxAFbfug=", useHasing: true, "trj9io9bv1"))));
						IWebElement webElement = FindElement(By.CssSelector(Has.DecryptHas("gVAJu0uwv9/gAvcWHreoaPWDV7SM6qK5+rYMxAFbfug=", useHasing: true, "trj9io9bv1")));
						webElement.SendKeys(list5[0]);
						Deley(1, 2);
						FindElement(By.XPath(Has.DecryptHas("Aj6abyTgPBsWH53F9KeZBekPcF+4d0q27HZHv3abqvC/t5nMyBFIFeTWhySmOvDACkzZxPi+QAzqzsKGRiMK5RTdRFZ58L6P", useHasing: true, "trj9io9bv1"))).Clear();
						Deley(1, 2);
						roll_element(FindElement(By.CssSelector(Has.DecryptHas("6unmfVUUE3udOeL3h/Fqs/RxCkwD7jRx/IN+zCsKL4A=", useHasing: true, "trj9io9bv1"))));
						FindElement(By.CssSelector(Has.DecryptHas("UurtcBmfr2B4nQ2vZiYQqrCRtxM8U4mdE1F/PnFwhAc=", useHasing: true, "n60haszu"))).Click();
						Deley(4, 6);
						for (int j = 0; j < ((list5.Count > 4) ? 4 : (list5.Count + 1)); j++)
						{
							if (Stop_thread)
							{
								return true;
							}
							string attribute = FindElement(By.CssSelector(Has.DecryptHas("n20Cl9/2rCK3K1ReadWJBKn17SO6YWCYU1GhqOaFU34=", useHasing: true, "n60haszu"))).GetAttribute(Has.DecryptHas("wHdpnSHUkfI=", useHasing: true, "n60haszu"));
							if (list5[0] == attribute)
							{
								thongtin.TrangThai = Has.DecryptHas("rci3VfESrX87w4ia5Mv3wp+Lnf/fSINVybC8BfwS1vc=", useHasing: true, "0v7vis5vpgi7");
								thongtin.Mail = list5[0].Split('|')[0];
								thongtin.Pass_Mail = list5[0].Split('|')[1];
								flag = true;
								break;
							}
							thongtin.TrangThai = $"[{j + 1}/4] Add Hotmail - Fail";
							Deley(1, 3);
							thongtin.TrangThai = $"[{j + 2}/4] Add Hotmail";
							list5.RemoveAt(0);
							webElement.Clear();
							Thread.Sleep(500);
							webElement.SendKeys(list5[0]);
							Deley(1, 2);
							roll_element(FindElement(By.CssSelector(Has.DecryptHas("HEN26G9c+OmuYvdZ53FqGieX9mcCUwmY7auB6T2OZpg=", useHasing: true, "7yviiv1fjwcend"))));
							FindElement(By.CssSelector(Has.DecryptHas("HEN26G9c+OmuYvdZ53FqGieX9mcCUwmY7auB6T2OZpg=", useHasing: true, "7yviiv1fjwcend"))).Click();
							Deley(3, 4);
						}
						if (flag)
						{
							string text4 = testc_xacnhan(thongtin.Mail, thongtin.Pass_Mail);
							if (string.IsNullOrEmpty(text4))
							{
								thongtin.TrangThai = "The authentication process has failed !";
							}
							else
							{
								thongtin.TrangThai = "successful confirmation !";
								driver?.Navigate().GoToUrl(text4);
								Deley(2, 3);
							}
						}
						else
						{
							thongtin.TrangThai = Has.DecryptHas("xPcWFEaZGgnMD7RRJkxsh4wwEJ3fzo7m", useHasing: true, "xc8cyudhiox");
						}
					}
					else if (ThongSo_Change_profile.rad_domain && !string.IsNullOrEmpty(ThongSo_Change_profile.txt_domain))
					{
						bool flag2 = false;
						string text5 = thongtin.User + ThongSo_Change_profile.txt_domain;
						thongtin.TrangThai = "Delete Phone - Add Mail Domain ... ";
						for (int k = 0; k < 3; k++)
						{
							roll_element(FindElement(By.CssSelector("input#pepEmail.JLJ-B.zyHYP")));
							IWebElement webElement2 = FindElement(By.CssSelector("input#pepEmail.JLJ-B.zyHYP"));
							webElement2.Clear();
							Thread.Sleep(1000);
							webElement2.SendKeys(text5);
							Deley(1, 2);
							try
							{
								FindElements(By.CssSelector(Has.DecryptHas("3peDRi7yyVQLdoayJYNp5Sfu6dO0wXiqtjJXqIn2+uY=", useHasing: true, "s7c18ykj9g")), 1)?.Click();
							}
							catch
							{
							}
							try
							{
								FindElements(By.CssSelector(Has.DecryptHas("3peDRi7yyVQLdoayJYNp5Sfu6dO0wXiqtjJXqIn2+uY=", useHasing: true, "s7c18ykj9g")), 0)?.Click();
							}
							catch
							{
							}
							Deley(4, 6);
							string attribute2 = FindElement(By.CssSelector(Has.DecryptHas("jhstzGciIfEW203RPu64SNdBLtI8evK32FiHDFA2KMg=", useHasing: true, "s7c18ykj9g"))).GetAttribute(Has.DecryptHas("R1QltMi4rkA=", useHasing: true, "s7c18ykj9g"));
							if (text5 == attribute2)
							{
								thongtin.TrangThai = Has.DecryptHas("vwMdtZyFygxRC07EUzJi0jBimdC2/x2fhPFdYfjjYSI=", useHasing: true, "s7c18ykj9g");
								thongtin.Mail = text5;
								flag2 = true;
								break;
							}
							thongtin.TrangThai = $"[{k + 1}/4] Add domain - Fail";
							driver?.Navigate().Refresh();
							Deley(2, 3);
							thongtin.TrangThai = $"[{k + 2}/4] Add domain";
						}
						if (flag2)
						{
							string text6 = testc_xacnhan(ThongSo_Change_profile.txt_hotmail, ThongSo_Change_profile.txt_PassHotmail);
							if (string.IsNullOrEmpty(text6))
							{
								thongtin.TrangThai = Has.DecryptHas("livB9PrjqUDuyJqmLbHMC/l1f81SoemAQQNvwgapcV0n5hdPD0RPLA==", useHasing: true, "nn8d6rde");
							}
							else
							{
								thongtin.TrangThai = Has.DecryptHas("jz6HZ5fa1yJtDk7XY47Co1EsjDdxs6bzjUpZTR0Jsvk=", useHasing: true, "nn8d6rde");
								driver?.Navigate().GoToUrl(text6);
								Deley(2, 3);
							}
						}
						else
						{
							thongtin.TrangThai = " Error Hotmail ! ";
						}
					}
				}
				if (Stop_thread)
				{
					return true;
				}
				if (ThongSo_Change_profile.cb_ChangePass)
				{
					driver?.Navigate().GoToUrl(Has.DecryptHas("dzeHH3SoTUUn/mJRy6aX6lWxKltwjj7qjM4I/bUES5rdinm1EwJxO9ToOTVFjzyo011cRnacTmE=", useHasing: true, "pb33txgm2"));
					Deley(1, 3);
					string text7 = Has.DecryptHas("G8qzMtxctEA=", useHasing: true, "pb33txgm2");
					string text8 = Has.DecryptHas("G8qzMtxctEA=", useHasing: true, "pb33txgm2");
					thongtin.TrangThai = Has.DecryptHas("wG5EL6KJ+ciU/cmRpaNuP3bVH8bHXBzT", useHasing: true, "pb33txgm2");
					FindElement(By.CssSelector(Has.DecryptHas("IjgCTRLHlw16dzGBUDIp8A==", useHasing: true, "pb33txgm2")))?.Clear();
					Deley(1, 3);
					FindElement(By.CssSelector(Has.DecryptHas("IjgCTRLHlw16dzGBUDIp8A==", useHasing: true, "pb33txgm2")))?.SendKeys(thongtin.Pass);
					Deley(1, 3);
					if (ThongSo_Change_profile.rad_ChangePass_Random || list2.Count == 0)
					{
						text7 = random(8);
						FindElement(By.CssSelector(Has.DecryptHas("mVNsfjgEqhd6dzGBUDIp8A==", useHasing: true, "pb33txgm2")))?.SendKeys(text7);
						Deley(1, 3);
						FindElement(By.CssSelector(Has.DecryptHas("IEPA600KMvZGwdj9IE9e679Lu5NL0n3V", useHasing: true, "pb33txgm2")))?.SendKeys(text7);
						Deley(1, 3);
					}
					else
					{
						text7 = list2[r.Next(0, list2.Count)];
						FindElement(By.CssSelector(Has.DecryptHas("WJJ+V2BKVTX9HOvZvBnIZQ==", useHasing: true, "20ai1xmn1d6u")))?.SendKeys(text7);
						Deley(1, 3);
						FindElement(By.CssSelector(Has.DecryptHas("wM6NFzpAP6gu1UWbL8xaBSjzqrNwGH7f", useHasing: true, "20ai1xmn1d6u")))?.SendKeys(text7);
						Deley(1, 3);
					}
					FindElement(By.CssSelector(Has.DecryptHas("jylrO8xZF4w32Aupy22MGw==", useHasing: true, "20ai1xmn1d6u")))?.Click();
					Deley(3, 5);
					text8 = get_cookie(check: false);
					if (text8 != thongtin.cookie)
					{
						thongtin.Pass = text7;
						thongtin.cookie = text8;
						sqlite.Update_Data(thongtin);
						thongtin.TrangThai = Has.DecryptHas("S1RyHS9jIsy1JgIk2B2CiqKR3y7LBL0X", useHasing: true, "93y410i7wt01fw");
					}
					else
					{
						thongtin.TrangThai = Has.DecryptHas("S1RyHS9jIszQQ8eus24S9NMVuXzq5kxe", useHasing: true, "93y410i7wt01fw");
					}
				}
			}
			catch
			{
			}
			return true;
		}

		private bool lock_acc()
		{
			thongtin.TrangThai = Has.DecryptHas("Sg2v+PEKjJs5Ddl2ig/YTA==", useHasing: true, "0rjr3zg701av");
			try
			{
				int num = 10;
				driver?.Navigate()?.GoToUrl(Has.DecryptHas("cxb87RSUdGUMOtzzg142uJEYkkXUT01j9q8FF2yDIgjCZxs8MZtvRxH+ZXPB8iXR/o2wmQtuw3zUI3KzrmxdSw==", useHasing: true, "0rjr3zg701av"));
				Deley(2, 5);
				roll_element(FindElement(By.CssSelector(Has.DecryptHas("pMq5szRxri6KinHsTzfHMCJ2ah+PrMbGjirGI5TcBGWgjIg6Bgn4QQ==", useHasing: true, "0rjr3zg701av"))));
				SelectElement selectElement = new SelectElement(driver.FindElement(By.CssSelector(Has.DecryptHas("pMq5szRxri6KinHsTzfHMCJ2ah+PrMbGjirGI5TcBGWgjIg6Bgn4QQ==", useHasing: true, "0rjr3zg701av"))));
				selectElement.SelectByIndex(new Random().Next(2, 7));
				Deley(1, 2);
				roll_element(FindElement(By.Name(Has.DecryptHas("UutQxddhtwJXP4fcrCBjRw==", useHasing: true, "0rjr3zg701av"))));
				driver?.FindElement(By.Name(Has.DecryptHas("UutQxddhtwJXP4fcrCBjRw==", useHasing: true, "0rjr3zg701av")))?.SendKeys(thongtin.Pass);
				Deley(1, 2);
				roll_element(FindElement(By.CssSelector(Has.DecryptHas("JcTe9fga6oMP8/Dqf/UHNIMtoF7m3EU3Vz+H3KwgY0c=", useHasing: true, "0rjr3zg701av"))));
				driver?.FindElement(By.CssSelector(Has.DecryptHas("RHUrl1FUzNORpnqK/+XotZUmG4AsHqWhU2zwH/X4O78=", useHasing: true, "dgp6by")))?.Click();
				Deley(1, 2);
				driver?.FindElements(By.CssSelector(Has.DecryptHas("RHUrl1FUzNORpnqK/+XotZUmG4AsHqWhU2zwH/X4O78=", useHasing: true, "dgp6by")))[1]?.Click();
				Deley(3, 5);
				while (!driver.Url.Contains(Has.DecryptHas("yRkvJ5HMXKQ=", useHasing: true, "dgp6by")))
				{
					num--;
					Thread.Sleep(1000);
					if (driver.PageSource.Contains(Has.DecryptHas("6whpEqAeOCM=", useHasing: true, "dgp6by")) || num <= 0)
					{
						thongtin.TrangThai = Has.DecryptHas("jZNzoKMsOXwLvSrXj7w73lFUqs96rq/l", useHasing: true, "dgp6by");
						return false;
					}
				}
			}
			catch
			{
			}
			thongtin.TrangThai = Has.DecryptHas("BzJck64nhuM8gTKeaSzm3IV/npkp1wKk", useHasing: true, "kjdsa1i");
			return true;
		}

		private string testc_xacnhan(string mail, string pass)
		{
			string result = Has.DecryptHas("ouVamdhAh2s=", useHasing: true, "269crjcfxi5q");
			if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(pass))
			{
				return result;
			}
			try
			{
				int num = 40;
				while (num > 0)
				{
					if (Stop_thread)
					{
						return result;
					}
					num--;
					Thread.Sleep(800);
					thongtin.TrangThai = $"wait for confirmation => {num} s";
					ImapClient imapClient = new ImapClient(Has.DecryptHas("A3KUDX1eW84Dh8k6MwH+4wH44xMqdDct", useHasing: true, "15c9ge9hx9id"), mail, pass, AuthMethods.Login, 993, secure: true);
					Lazy<MailMessage>[] array = imapClient.SearchMessages(SearchCondition.Unseen());
					if (array.Length == 0)
					{
						continue;
					}
					DateTime now = DateTime.Now;
					for (int num2 = array.Count() - 1; num2 >= 0; num2--)
					{
						Lazy<MailMessage> lazy = array[num2];
						DateTime date = lazy.Value.Date;
						if (now.Year != date.Year || now.Month != date.Month || now.Day != date.Day || now.Hour != date.Hour || now.Minute > date.Minute + 5)
						{
							break;
						}
						if (now.Day == date.Day && now.Month == date.Month && now.Year == date.Year && now.Hour == date.Hour && now.Minute <= date.Minute + 5 && lazy.Value.Subject.Contains(Has.DecryptHas("cNY0IXkiadRNMWJq3097xYRvS0ymewrI3wh1xBUsCgHM5cI98ViVZtBV2RXkemdx", useHasing: true, "vkug8iz0ss")) && lazy.Value.Body.Contains(thongtin.User.ToLower()))
						{
							MatchCollection matchCollection = Regex.Matches(lazy.Value.Body, "(?<=<a href=\").*?(?=\")", RegexOptions.Singleline);
							if (matchCollection != null && matchCollection.Count > 0)
							{
								result = matchCollection[0].ToString();
								return result;
							}
						}
					}
				}
				return result;
			}
			catch (Exception ex)
			{
				string message = ex.Message;
			}
			return result;
		}

		private bool Post()
		{
			try
			{
				int num = r.Next(ThongSo_Post.num_Post_SLMin, ThongSo_Post.num_Post_SLMax);
				List<string> list = ThongSo_Post.rtb_Post_NDmess?.Split('\n').ToList();
				list?.RemoveAll((string x) => x == "");
				List<string> list2 = ((ThongSo_Post.txt_Post_PathImg == null) ? null : (from s in Directory.GetFiles(ThongSo_Post.txt_Post_PathImg, "*.*", SearchOption.AllDirectories)
					where s.EndsWith(".png") || s.EndsWith(".jpg")
					select s).ToList());
				thongtin.TrangThai = "Post ...";
				About_Home();
				Deley(1, 3);
				for (int i = 0; i < num; i++)
				{
					if (tt_kk.day > int.Parse(Has.DecryptHas("wTkiEQFu42Q=", useHasing: true, "vsabfcfnr2")))
					{
						Process.Start(Has.DecryptHas(Has.DeCryptWithKey(Has.DecryptHas("h8jO4SUA3T5uBi/QPDTiTkOj9n9HnxjcHbdrM9WayvoO9pMZUcqycgVk10arQ+hd", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o")), useHasing: true, Has.DeCryptWithKey(Has.DecryptHas("JKUcpSX79HWw0huZJWxfLQ==", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o"))), Has.DecryptHas(Has.DeCryptWithKey(Has.DecryptHas("FoskjfYSDkK5AHSXLgAxXc9vrffvSF1rvktcz4fTG8A=", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o")), useHasing: true, Has.DeCryptWithKey(Has.DecryptHas("JKUcpSX79HWw0huZJWxfLQ==", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o"))));
					}
					if (Stop_thread && !tt.status)
					{
						return true;
					}
					thongtin.TrangThai = $"[{i + 1}/{num}] Post ... ";
					int num2 = 30;
					try
					{
						driver.ExecuteScript(Has.DecryptHas("YpuAOhe8kUI6ILGQpElNWEPwe7gG2QYxqs+lCk0JvkzhpgH+errctxDiQPqz/wHsZglcCrOd2JA8qc3wHFgNGpb851XIeUm3wagZgPpfSC9JeK4UGWQAcTEPFsnXx+9KZbN4tp9IlNLujW7iTZzRoQsL9vzrBn9p", useHasing: true, "ie3gnee"));
						Deley(2, 4);
						FindElements(By.CssSelector("[data-testid=\"new-post-button\"]"), 0)?.Click();
						Deley(2, 4);
						try
						{
							FindElement(By.CssSelector(Has.DecryptHas("FylDpki3l8VY7NnnPr32C6g1pooUg9m1Fcbd/PDg1CDwX3gJ7uq1NQ==", useHasing: true, "7zjl1l7exql2oi")))?.Click();
						}
						catch
						{
						}
						FindElement(By.CssSelector(Has.DecryptHas("FylDpki3l8VY7NnnPr32C6g1pooUg9m1Fcbd/PDg1CDwX3gJ7uq1NQ==", useHasing: true, "7zjl1l7exql2oi")))?.SendKeys(list2[r.Next(0, list2.Count)]);
						Deley(2, 4);
						FindElement(By.CssSelector(Has.DecryptHas("FKn3mL+88e/fj5dAtHcbDg==", useHasing: true, "7zjl1l7exql2oi")))?.Click();
						Deley(2, 4);
						if (list.Count != 0)
						{
							string text = list[r.Next(0, list.Count)];
							if (text.Contains(Has.DecryptHas("8NDaJyffaKQ=", useHasing: true, "7zjl1l7exql2oi")))
							{
								string[] array = text.Split('|');
								foreach (string text2 in array)
								{
									FindElement(By.CssSelector(Has.DecryptHas("FErpCh/sxag=", useHasing: true, "7zjl1l7exql2oi")))?.SendKeys(text2);
									Thread.Sleep(500);
									FindElement(By.CssSelector(Has.DecryptHas("/UKPVeiT14M=", useHasing: true, "koq09ld")))?.SendKeys(Keys.Enter);
									Deley(2, 4);
								}
							}
							else
							{
								FindElement(By.CssSelector(Has.DecryptHas("/UKPVeiT14M=", useHasing: true, "koq09ld")))?.SendKeys(text);
								Deley(2, 4);
							}
						}
						FindElement(By.CssSelector(Has.DecryptHas("R5ZAITyc99h20Z3F+bHfLQ==", useHasing: true, "koq09ld")))?.Click();
						Deley(2, 4);
						while (driver.Url != Has.DeCryptWithKey("sikyulvxD0A8ZJED+led3WYBFthDlPB6wb2d3cDYb9o=", "z3ya0rso7sh1"))
						{
							num2--;
							if (num2 <= 0)
							{
								driver?.Navigate()?.GoToUrl(Has.DeCryptWithKey("sikyulvxD0A8ZJED+led3WYBFthDlPB6wb2d3cDYb9o=", "z3ya0rso7sh1"));
								break;
							}
							Thread.Sleep(1000);
						}
						thongtin.TrangThai = $"[{i + 1}/{num}] Post - Success ! ";
						Deley(ThongSo_Post.num_Post_TimeMin, ThongSo_Post.num_Post_TimeMax);
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			return true;
		}

		private bool ReplyComment()
		{
			int num = r.Next(ThongSo_ReplyComment.num_Spam_SLMin, ThongSo_ReplyComment.num_Spam_SLMax);
			List<string> list = ThongSo_ReplyComment.rtb_Spam_NDcmt?.Split('\n').ToList();
			list?.RemoveAll((string x) => x == "");
			List<string> list2 = ((ThongSo_Post.txt_Post_PathImg == null) ? null : (from s in Directory.GetFiles(ThongSo_Post.txt_Post_PathImg, "*.*", SearchOption.AllDirectories)
				where s.EndsWith(".png") || s.EndsWith(".jpg")
				select s).ToList());
			thongtin.TrangThai = "Reply Comment ...";
			if (string.IsNullOrEmpty(ThongSo_ReplyComment.txt_LinkPost.Trim()))
			{
				return false;
			}
			driver.Navigate().GoToUrl(ThongSo_ReplyComment.txt_LinkPost);
			Deley(2, 3);
			FindElement(By.CssSelector("._15y0l > button:nth-child(1)"))?.Click();
			Deley(2, 3);
			if (!driver.Url.Contains("comments"))
			{
				driver.Navigate().GoToUrl(ThongSo_ReplyComment.txt_LinkPost + "comments/");
			}
			List<IWebElement> list3 = _FindElements(By.CssSelector("a.sqdOP.yWX7d._8A5w5.ZIAjV"))?.ToList();
			if (list3 == null)
			{
				return false;
			}
			for (int i = 0; i < ((list3.Count <= num) ? list3.Count : num); i++)
			{
				if (!check_element(By.CssSelector(".Ypffh")))
				{
					return true;
				}
				string text = FindElements(By.CssSelector("a.sqdOP.yWX7d._8A5w5.ZIAjV"), i)?.Text;
				FindElement(By.CssSelector(".Ypffh"))?.SendKeys("@" + text + " " + list[r.Next(0, list.Count)]);
				Deley(1, 3);
				FindElement(By.CssSelector(".Ypffh"))?.SendKeys(Keys.Enter);
				Deley(2, 4);
				if (string.IsNullOrEmpty(FindElement(By.CssSelector(".Ypffh"))?.Text))
				{
					thongtin.TrangThai = "Có lỗi xảy ra, vui lòng kiểm tra lại ...";
					return false;
				}
			}
			return true;
		}

		public bool Run()
		{
			thongtin.TrangThai = "Open Chrome ... ";
			Form1.remote.Change_Row(thongtin);
			if (!Url(0))
			{
				Stop_thread = true;
			}
			else
			{
				Deley(3, 5);
				if (!login())
				{
					Stop_thread = true;
				}
				else
				{
					Deley(1, 3);
					roll(3, 8);
					List<Thongso_HanhDong> list = ThongSo_CauHinhTuongTac.L_HanhDong;
					if (ThongSo_CauHinhTuongTac.cb_RandomHanhDong)
					{
						list = ShuffleList(list).ToList();
					}
					foreach (Thongso_HanhDong item in list)
					{
						Thongso_HanhDong thongso_HanhDong = item;
						if (Stop_thread)
						{
							goto IL_06c2;
						}
						Load_file.Load_thongso(thongso_HanhDong);
						switch (item.Ma_HanhDong)
						{
						case 0:
							TuongTacNewsfeed();
							break;
						case 1:
							TuongTacFollowers();
							break;
						case 2:
							TuongTacFollowing();
							break;
						case 3:
							NhanTinTheoUser();
							break;
						case 4:
							NhanTinVoiFollowers();
							break;
						case 5:
							NhanTinVoiFollowing();
							break;
						case 6:
							TuongTacTinNhan();
							break;
						case 7:
							CauHinhLuotStory();
							break;
						case 8:
							CauHinhSpam();
							break;
						case 9:
							ShareBaiViet();
							break;
						case 10:
							FollowGoiY();
							break;
						case 11:
							FollowTuKhoa();
							break;
						case 12:
							FollowUser();
							break;
						case 13:
							FollowLaiFollowers();
							break;
						case 14:
							FollowUserLikePost();
							break;
						case 15:
							FollowFollowerUser();
							break;
						case 16:
							FollowFollowingUser();
							break;
						case 17:
							UnFollow();
							break;
						case 18:
							ChangeProfile();
							break;
						case 19:
							Post();
							break;
						case 20:
							ReplyComment();
							break;
						}
						Deley(2, 5);
					}
					if (!Stop_thread)
					{
						if (ThongSo_CauHinhTuongTac.cb_checkTT)
						{
							thongtin.TrangThai = "Check Account Information ... ";
							string text = "https://www.instagram.com/" + thongtin.User;
							if (!driver.Url.Contains(text))
							{
								FindElement(By.CssSelector("div.qF0y9:nth-child(5) > a:nth-child(1) > div:nth-child(1) > span:nth-child(2) > img:nth-child(1)"))?.Click();
								if (!(driver?.Url == text))
								{
									driver?.Navigate()?.GoToUrl(text);
									Deley(2, 4);
								}
							}
							for (int i = 0; i < 3; i++)
							{
								if (Stop_thread)
								{
									goto IL_06c2;
								}
								try
								{
									string attribute = driver.FindElement(By.CssSelector("html.js.logged-in.client-root.touch.js-focus-visible.sDN5V body div#react-root section._9eogI.E3X2T main.SCxLW.uzKWK div.v9tJq.VfzDr header.HVbuG div.XjzKX div._4dMfM div.M-jxE button.IalUJ img.be6sR")).GetAttribute("src");
									if (attribute.Contains("44884218_345707102882519_2446069589734326272"))
									{
										thongtin.Avatar = "No";
									}
									else
									{
										thongtin.Avatar = "Yes";
									}
									string following = FindElements(By.CssSelector("html.js.logged-in.client-root.touch.js-focus-visible.sDN5V body div#react-root section._9eogI.E3X2T main.SCxLW.uzKWK div.v9tJq.VfzDr ul._3dEHb li.LH36I a._81NM2 span.g47SY.lOXF2"), 1)?.Text;
									thongtin.Following = following;
									string followers = FindElements(By.CssSelector("html.js.logged-in.client-root.touch.js-focus-visible.sDN5V body div#react-root section._9eogI.E3X2T main.SCxLW.uzKWK div.v9tJq.VfzDr ul._3dEHb li.LH36I a._81NM2 span.g47SY.lOXF2"), 0)?.Text;
									thongtin.Followers = followers;
									string baiViet = FindElement(By.CssSelector("html.js.logged-in.client-root.touch.js-focus-visible.sDN5V body div#react-root section._9eogI.E3X2T main.SCxLW.uzKWK div.v9tJq.VfzDr ul._3dEHb li.LH36I span._81NM2 span.g47SY.lOXF2"))?.Text;
									thongtin.BaiViet = baiViet;
									string fullName = FindElement(By.CssSelector("html.js.logged-in.client-root.touch.js-focus-visible.sDN5V body div#react-root section._9eogI.E3X2T main.SCxLW.uzKWK div.v9tJq.VfzDr div.-vDIg h1.rhpdm"))?.Text;
									thongtin.FullName = fullName;
									sqlite.Update_Data(thongtin);
								}
								catch
								{
									continue;
								}
								break;
							}
							thongtin.TrangThai = "Check Account Information - Success ";
						}
						if (!Stop_thread)
						{
							if (Khoa_acc)
							{
								lock_acc();
							}
							thongtin.TrangThai = Has.DeCryptWithKey("+tVxLDr7vI+oniPl+URLq4BsDD13nJDT", "qcvqtwjgg");
						}
					}
				}
			}
			goto IL_06c2;
			IL_06c2:
			Close();
			if (Stop.stop)
			{
				thongtin.TrangThai = Has.DeCryptWithKey("q1P1i7wKXAI=", "qcvqtwjgg");
			}
			Stop_thread = true;
			Form1.remote.Change_Row(thongtin);
			sqlite.Update_Data(thongtin);
			return true;
		}

		public bool Run_Chrome()
		{
			thongtin.TrangThai = Has.DeCryptWithKey("txl9hhieyZfyOmP1UvDaA6k0Mg/5fQTf", "ji0sy7u");
			Form1.remote.Change_Row(thongtin);
			Url(0);
			Deley(1, 3);
			login();
			Stop_thread = true;
			thongtin.TrangThai = Has.DeCryptWithKey("A4ed4gO/S6E=", "w7776700z1e");
			Form1.remote.Change_Row(thongtin);
			sqlite.Update_Data(thongtin);
			return true;
		}

		private void Deley(int min, int max)
		{
			Thread.Sleep(TimeSpan.FromSeconds(r.Next(min, max)));
		}

		private string testc_CP(string hotmail, string pass)
		{
			string result = Has.DecryptHas("ouVamdhAh2s=", useHasing: true, "269crjcfxi5q");
			if (string.IsNullOrEmpty(hotmail) || string.IsNullOrEmpty(pass))
			{
				return result;
			}
			try
			{
				int num = 30;
				while (num > 0)
				{
					num--;
					Thread.Sleep(800);
					thongtin.TrangThai = $"wait for confirmation => {num} s";
					ImapClient imapClient = new ImapClient(Has.DecryptHas("uoNO1xy/DQ6GNDlC6l1xtIRj+lVBv78u", useHasing: true, "gf8xc2"), hotmail, pass, AuthMethods.Login, 993, secure: true);
					Lazy<MailMessage>[] array = imapClient.SearchMessages(SearchCondition.Unseen());
					if (array.Length == 0)
					{
						continue;
					}
					DateTime now = DateTime.Now;
					for (int num2 = array.Count() - 1; num2 >= 0; num2--)
					{
						Lazy<MailMessage> lazy = array[num2];
						DateTime date = lazy.Value.Date;
						if (now.Year != date.Year || now.Month != date.Month || now.Day != date.Day || now.Hour != date.Hour || now.Minute > date.Minute + 5)
						{
							break;
						}
						if (now.Day == date.Day && now.Month == date.Month && now.Year == date.Year && now.Hour == date.Hour && now.Minute <= date.Minute + 5 && (lazy.Value.Subject.Contains(Has.DecryptHas("OZ7eWQV1DtPvkizfnwv2xhPx5oPEVjGk", useHasing: true, "t4fck1l180")) || lazy.Value.Subject.Contains(Has.DecryptHas("H+/EF2gi6AqppUjdMfo28xisEuXNWpcs6IkE5ggRTiqOCgjY73KmRA==", useHasing: true, "t4fck1l180"))) && tt_kk._key.Contains(Has.DeCryptWithKey("HB3l/3/OfHI=", "yyn2bjrf2tp")) && lazy.Value.Body.Contains(thongtin.User))
						{
							MatchCollection matchCollection = Regex.Matches(lazy.Value.Body, "(?<=<font size=\"6\">).*?(?=</font>)", RegexOptions.Singleline);
							if (matchCollection != null && matchCollection.Count > 0)
							{
								result = matchCollection[0].ToString();
								return result;
							}
						}
					}
				}
				return result;
			}
			catch (Exception ex)
			{
				string message = ex.Message;
			}
			return result;
		}

		public bool Open_CP(string hotmail, string pass_hotmail)
		{
			thongtin.TrangThai = Has.DeCryptWithKey("24CKCxNiRNYlcuA0EQ0wm7iP38C8tPPx", "kqh8w6ji");
			Form1.remote.Change_Row(thongtin);
			if (!Url(1))
			{
				Stop_thread = true;
			}
			else
			{
				Deley(1, 3);
				if (login() && !driver.Url.Contains(Has.DeCryptWithKey("xdheeglHxQDswi4LVqKPsg==", "kqh8w6ji")))
				{
					thongtin.TrangThai = Has.DeCryptWithKey("yyL8yL203BAd7yv/VsH5ynDtITTcktV6Nkn3kTnfCCS4j9/AvLTz8Q==", "kqh8w6ji");
				}
				else
				{
					thongtin.TrangThai = Has.DeCryptWithKey("JGDX4AN53u1d8C5BpxsfNA==", "xfnn46pj3by");
					thongtin.TinhTrang = Has.DeCryptWithKey("vVs5B1MaKiJQn0oX5Us1JA==", "xfnn46pj3by");
					thongtin.Color = 0;
					Deley(1, 3);
					if (driver.Url.Contains(Has.DeCryptWithKey("RpZfesVQ3wMPNiKJxD1eNZEqH36P12Bq4XWp8n8Iv6i/eX4SCt/uag==", "xfnn46pj3by")))
					{
						thongtin.TrangThai = Has.DeCryptWithKey("IWJIDyfPHn5VCTwT9MsP3oLSZBmP/nfSjBnQMtOkgxRY3OyIhKdg9w==", "xfnn46pj3by");
					}
					else
					{
						FindElement(By.CssSelector(Has.DeCryptWithKey("SG2BUr+TXAXVlB1oCo96Z0NzUNqiHQE8pEHUMM760y0=", "xfnn46pj3by")))?.Click();
						Deley(5, 7);
						for (int i = 0; i < 2; i++)
						{
							thongtin.TrangThai = "Getting code ... !";
							string text = testc_CP(hotmail, pass_hotmail);
							if (text == "")
							{
								break;
							}
							thongtin.TrangThai = "Code => " + text + " !";
							FindElement(By.Name(Has.DeCryptWithKey("ini3WUWeAMJSP69Ue/+1Iw==", "u3smrkqoqc")))?.Clear();
							Deley(1, 2);
							FindElement(By.Name(Has.DeCryptWithKey("gWkd2hmFGCnt+mwxI1bWaw==", "7sz1zjwpp980lh")))?.SendKeys(text);
							Deley(1, 2);
							FindElement(By.CssSelector(Has.DeCryptWithKey("5Dg136TdYYH0wsRz3hOTRIgwqKW7xCg0n6A8UzEj+T4=", "7sz1zjwpp980lh")))?.Click();
							Deley(9, 12);
							FindElement(By.CssSelector(Has.DeCryptWithKey("Vj+uLhCD0PkE1QHII/UeVfUVrsx857PKpN/5V6LsvG6SG1hqwsaX+TTUtvNvYnpcmwXbZHUseTbISgnpC+qhJgP2OOCGxSElhJKk5UlEGWVeExA2pvXhYiHzEqq53uKnsElSP5r90VvIzsgybA2FKR3EnWp7D4i6ywsX7ZUELEwwOcvLxsCuGFzk2guCSgykBjJX8VROgpMlnMcGvvN20pq65F6I2gl9GsYpTqM24z0=", "7sz1zjwpp980lh")))?.Click();
							Deley(9, 12);
							if (driver.Url.Contains(Has.DeCryptWithKey("JugZRG6xaMxq3Hy02RARIQ==", "7sz1zjwpp980lh")))
							{
								FindElement(By.CssSelector(Has.DeCryptWithKey("K8Kur0rwygL/dStThnW9lRrGKU6jNuM9", "7sz1zjwpp980lh")))?.Click();
								Deley(2, 3);
								continue;
							}
							break;
						}
						if (driver.Url.Contains(Has.DeCryptWithKey("JugZRG6xaMxq3Hy02RARIQ==", "7sz1zjwpp980lh")))
						{
							thongtin.TrangThai = Has.DeCryptWithKey("nMGtvQMx7oCKgR8/c3inQX2r43Mper+nFq3g0LTGins=", "7sz1zjwpp980lh");
						}
						else
						{
							thongtin.cookie = get_cookie(check: true);
							thongtin.Color = 1;
							thongtin.TinhTrang = Has.DeCryptWithKey("1Bu62tE9wVI=", "7sz1zjwpp980lh");
							if (ThongSo_SettingCP.cb_LockAcc)
							{
								lock_acc();
							}
							Deley(2, 3);
							thongtin.TrangThai = Has.DeCryptWithKey("nMGtvQMx7oCKgR8/c3inQcBnO/1AxnWs", "7sz1zjwpp980lh");
						}
					}
				}
			}
			Close();
			if (Stop.stop)
			{
				thongtin.TrangThai = Has.DeCryptWithKey("q1P1i7wKXAI=", "qcvqtwjgg");
			}
			Form1.remote.Change_Row(thongtin);
			Stop_thread = true;
			sqlite.Update_Data(thongtin);
			return true;
		}
	}
}
