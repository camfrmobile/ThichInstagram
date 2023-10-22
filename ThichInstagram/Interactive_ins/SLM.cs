using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AE.Net.Mail;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
 

namespace Interactive_ins
{
	public class SLM
	{
		private ThongTin thongtin = new ThongTin();

		private Random r = new Random();

		private bool User_Proxy;

		private SQLite sqlite = new SQLite();

		private Thongso_Proxy Thongso_Proxy = new Thongso_Proxy();

		private bool Stop_thread = false;

		private FirefoxDriver driver { get; set; }

		public SLM(ThongTin thongtin, bool Use_Proxy = false)
		{
			this.thongtin = thongtin;
			User_Proxy = Use_Proxy;
		}

		private bool check_element(By by)
		{
			try
			{
				driver?.FindElement(by);
				return true;
			}
			catch
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

		private bool Thaotac_Click(By by)
		{
			for (int i = 0; i < 5; i++)
			{
				try
				{
					FindElement(by)?.Click();
					return true;
				}
				catch
				{
					Deley(2, 4);
				}
			}
			return false;
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
			if (tt_kk.day > int.Parse(Has.DecryptHas("2cbeA9bszfc=", useHasing: true, "g28tuq")))
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

		private FirefoxDriverService FirefoxService()
		{
			FirefoxDriverService firefoxDriverService = FirefoxDriverService.CreateDefaultService();
			firefoxDriverService.HideCommandPromptWindow = true;
			firefoxDriverService.SuppressInitialDiagnosticInformation = true;
			return firefoxDriverService;
		}

		private FirefoxOptions FirefoxOptions()
		{
			string[] array = File.ReadAllLines("data\\render.txt");
			string preferenceValue = array[new Random().Next(0, array.Length)];
			string[] array2 = File.ReadAllLines("data\\userAgent.txt");
			string preferenceValue2 = array2[new Random().Next(0, array2.Length)];
			if (string.IsNullOrWhiteSpace(U_ke.ke_U.ToString()))
			{
				return new FirefoxOptions();
			}
			FirefoxOptions firefoxOptions = new FirefoxOptions();
			FirefoxProfile firefoxProfile = new FirefoxProfile();
			firefoxOptions.SetPreference(Has.DecryptHas("Iird41MDLvfJX0IAewxyDHZWbSNwEgYGf/O0rUielfNNsJuJYdVdYA==", useHasing: true, "kft28uh"), preferenceValue: true);
			firefoxOptions.AddArguments("--window-size=320,480");
			firefoxOptions.AddArguments("--app=https://instagram.com/");
			firefoxOptions.AddArguments("--width=320");
			firefoxOptions.AddArguments("--height=480");
			firefoxOptions.SetPreference(Has.DecryptHas("6uC4dZ+7WGigq2acQh7uU+4v/mdk0NICajPKe1Ev1Ug=", useHasing: true, Has.DeCryptWithKey("HKvTFc3WddybyCh2hWAl6A==", "jboh5gv")), preferenceValue2);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("c9UtL6ekD1y98jpqtTO1U4+rsEg0+rmYAGXCr0BCQ/0g/+h5TIHsn4Yk+jrbvt9s", "jboh5gv"), useHasing: true, Has.DeCryptWithKey("HKvTFc3WddybyCh2hWAl6A==", "jboh5gv")), preferenceValue);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("WpOVDqEYM0lbZ5bZRg83eWFOH5r+TjnyYV3mbMfltg36xqEZjzMiQg==", "jboh5gv"), useHasing: true, Has.DeCryptWithKey("t9+JMN21rUD6xqEZjzMiQg==", "jboh5gv")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("WImisIOMbFRbaNKyKdwckKpvMcFLqqsU034ksukAc0X6xqEZjzMiQg==", "jboh5gv"), useHasing: true, Has.DeCryptWithKey("t9+JMN21rUD6xqEZjzMiQg==", "jboh5gv")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("Fg1PCBXGnw3Jx6iaItUpJd3C0WjEak88Xy8i10ddu/lDtgHFkOyo0Z7whK7beu/0", "jboh5gv"), useHasing: true, Has.DeCryptWithKey("t9+JMN21rUD6xqEZjzMiQg==", "jboh5gv")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("NUlH9f6gjPZLs8PfEp1bFxWYP1A+TNa4MaEE0kcoxTukXOgRCOQI9g==", useHasing: true, Has.DeCryptWithKey("t9+JMN21rUD6xqEZjzMiQg==", "jboh5gv")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("edal+1wTU45QjSRjBi9D+KTT4KlmzaZqGQfy8MmDvs4F8LgEBW79nQ==", useHasing: true, Has.DeCryptWithKey("t9+JMN21rUD6xqEZjzMiQg==", "jboh5gv")), preferenceValue: true);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("iaTclgYzkglGvg8MuawS/V8bT8ImtIbYRRI8J9Mt5ta1LGQF3J9/uV8nrTbpEo9/", "jboh5gv"), useHasing: true, Has.DeCryptWithKey("t9+JMN21rUD6xqEZjzMiQg==", "jboh5gv")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("edal+1wTU45QjSRjBi9D+KUPOwpVKvk+", useHasing: true, Has.DeCryptWithKey("t9+JMN21rUD6xqEZjzMiQg==", "jboh5gv")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("uf51gkUyAHriWF5fUOcxJgYTJNBfXipkubEumd+LMXz6xqEZjzMiQg==", "jboh5gv"), useHasing: true, Has.DeCryptWithKey("t9+JMN21rUD6xqEZjzMiQg==", "jboh5gv")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("ypwh1LhIVfkYl8mMo+ci8F9meiXhEYljVM3xJ1WaKb8=", useHasing: true, Has.DeCryptWithKey("t9+JMN21rUD6xqEZjzMiQg==", "jboh5gv")), "skia,cairo");
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("uf51gkUyAHoe9jUN1XvY3gG89lcfZmsXZUH7tOiFSab6xqEZjzMiQg==", "jboh5gv"), useHasing: true, Has.DeCryptWithKey("t9+JMN21rUD6xqEZjzMiQg==", "jboh5gv")), RandomNumber(5));
			firefoxOptions.SetPreference(Has.DecryptHas("KbGm4QO9Td9IuNZ6+uJ5EqQCKVUxOSieSBGXDzdNf35+Z5QTJJ0P6BtelJs7BNUJmA32JDpxIx2kkqk1lIguIVNoT4ttOfy8", useHasing: true, Has.DeCryptWithKey("czkITS4iz6s=", "jboh5gv")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("KbGm4QO9Td8rskrVgVOtv9auMjqG7714xitZr7IBt43EVVoGEE5o+Cm9beWidELR", useHasing: true, Has.DeCryptWithKey("gaysji80s10=", "w0uwdg12p3w")), Has.DecryptHas(Has.DeCryptWithKey("kLZJqB+1U62ppAT6IPkV3Q==", "w0uwdg12p3w"), useHasing: true, Has.DeCryptWithKey("gaysji80s10=", "w0uwdg12p3w")));
			firefoxOptions.SetPreference(Has.DecryptHas("KbGm4QO9Td8rskrVgVOtv9auMjqG7714Fhf7+kHif6QdMbzc78WmKDRDcZsGkDFYYOdoNSfJlTpzeG9dzA4JFA==", useHasing: true, Has.DeCryptWithKey("gaysji80s10=", "w0uwdg12p3w")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("D9pFOHLGMXxzB+mCskDDGzt0fag5pPOsS53DnzzdZ9EnMQngG75MyQ==", useHasing: true, Has.DeCryptWithKey("gaysji80s10=", "w0uwdg12p3w")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("uomeTfTZKtzG8XxnNPWouKhAbzF/45JyACrWspKFmT6Kt8+YQcvbm17fUTp+YmkCHclgT0mE+lQ=", useHasing: true, Has.DeCryptWithKey("gaysji80s10=", "w0uwdg12p3w")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("uomeTfTZKtxMPPIeFCyqI4+czpf3wygNdE0qCoAjowwE7Spcou1Sdy/Djoh3pVBLcoUX0zlFuDc=", useHasing: true, Has.DeCryptWithKey("gaysji80s10=", "w0uwdg12p3w")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("5ueAYNEIYBJBlhjDGFiXf3LT/GP2gqZTbqsn4t6i96MWKVAAjDXOYiiwK/QQe+mzWULw4ZHqRjY=", useHasing: true, Has.DeCryptWithKey("gaysji80s10=", "w0uwdg12p3w")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("5ueAYNEIYBJBlhjDGFiXf3LT/GP2gqZTbqsn4t6i96MWKVAAjDXOYiiwK/QQe+mz/sOfr+Q+59uLl8iKJ6mdZzOYwTRGKRZ+1K9tva2zl0upEd15yF2Hdg==", useHasing: true, Has.DeCryptWithKey("gaysji80s10=", "w0uwdg12p3w")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("KsognUB3gjrQ1V4nerdIHCz+F6jCtXHDd/+WWW1XUW/5n6pMWIwP+F5RFlJipLQEYjRy9T8hq+eQTsxOIXNV9hy3QsPvgDwZ63M+oYeP8IZX46j7ExfN+Q==", useHasing: true, Has.DeCryptWithKey("XFS2k+8s4JgYHntbA/C2TA==", "w0uwdg12p3w")), preferenceValue: true);
			firefoxOptions.SetPreference(Has.DecryptHas("KsognUB3gjrQ1V4nerdIHCz+F6jCtXHDd/+WWW1XUW9bIgQS2lnXIJW/g9Vmyzt+FDMAAMlSSX5MSOvyXIjP8jL5NGy0Nnc8qsDxERd1JyY=", useHasing: true, Has.DeCryptWithKey("XFS2k+8s4JgYHntbA/C2TA==", "w0uwdg12p3w")), preferenceValue: true);
			firefoxOptions.SetPreference(Has.DecryptHas("/98IwZdoiUSxru01nz+gXHVZkrkZFZj4XlEWUmKktASzgzS/1Y1YdchallsSkD0aYYsnwm30HARE0/pgTLJj3A==", useHasing: true, Has.DeCryptWithKey("XFS2k+8s4JgYHntbA/C2TA==", "w0uwdg12p3w")), Has.DecryptHas("n+lt+FXmV3c=", useHasing: true, Has.DeCryptWithKey("XFS2k+8s4JgYHntbA/C2TA==", "w0uwdg12p3w")));
			firefoxOptions.SetPreference(Has.DecryptHas("/98IwZdoiUSxru01nz+gXHVZkrkZFZj4XlEWUmKktASzgzS/1Y1YdQEKWfvIrTxhzGhptt+6Pl1E0/pgTLJj3A==", useHasing: true, Has.DeCryptWithKey("XFS2k+8s4JgYHntbA/C2TA==", "w0uwdg12p3w")), Has.DecryptHas("n+lt+FXmV3c=", useHasing: true, Has.DeCryptWithKey("XFS2k+8s4JgYHntbA/C2TA==", "w0uwdg12p3w")));
			firefoxOptions.SetPreference(Has.DecryptHas("/98IwZdoiUSxru01nz+gXHVZkrkZFZj4XlEWUmKktATrZex9RM11Gj3DIYDVJAFB6P6XYnazZnQ=", useHasing: true, Has.DeCryptWithKey("XFS2k+8s4JgYHntbA/C2TA==", "w0uwdg12p3w")), Has.DecryptHas("n+lt+FXmV3c=", useHasing: true, Has.DeCryptWithKey("XFS2k+8s4JgYHntbA/C2TA==", "w0uwdg12p3w")));
			firefoxOptions.SetPreference(Has.DecryptHas("/98IwZdoiUSxru01nz+gXHVZkrkZFZj4XlEWUmKktASzltAjsA8sL04YKplDCpHQ6P6XYnazZnQ=", useHasing: true, Has.DeCryptWithKey("cCKd5B949yKDcVYLyZzu5Q==", "qfc34krlk")), Has.DecryptHas("n+lt+FXmV3c=", useHasing: true, Has.DeCryptWithKey("cCKd5B949yKDcVYLyZzu5Q==", "qfc34krlk")));
			firefoxOptions.SetPreference(Has.DecryptHas("gmHnQdnWryhtTDQYFUdJW7P7c/+MsHp8H9nCOkZtKGI=", useHasing: true, Has.DeCryptWithKey("cCKd5B949yKDcVYLyZzu5Q==", "qfc34krlk")), "Apple Computer, Inc.");
			firefoxOptions.SetPreference(Has.DecryptHas("/DwqBkg34WQR3IWijdtItXVq7O+sfWb7", useHasing: true, Has.DeCryptWithKey("cCKd5B949yKDcVYLyZzu5Q==", "qfc34krlk")), Has.DecryptHas(Has.DeCryptWithKey("OlLbhq0zSCMyj2/DoVmebQ==", "qfc34krlk"), useHasing: true, Has.DeCryptWithKey("cCKd5B949yKDcVYLyZzu5Q==", "qfc34krlk")));
			firefoxOptions.AddArguments(Has.DecryptHas("85Xr7QXMdtnnIEUdD9+JWw==", useHasing: true, Has.DeCryptWithKey("cCKd5B949yKDcVYLyZzu5Q==", "qfc34krlk")), Has.DecryptHas(Has.DeCryptWithKey("JtEnvnHfEx0nozn4HaHtag==", "qfc34krlk"), useHasing: true, Has.DeCryptWithKey("cCKd5B949yKDcVYLyZzu5Q==", "qfc34krlk")));
			firefoxOptions.SetPreference(Has.DecryptHas("MYX43NQdDK1NOnk+b5+2YnWesD13Mh0F", useHasing: true, Has.DeCryptWithKey("fYSplgIsYRT9jdIYa55g7w==", "qfc34krlk")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("+9F6P/h9IBOoOr9zwTKwzorYF49IHezm671nrNF+vTM=", useHasing: true, Has.DeCryptWithKey("fYSplgIsYRT9jdIYa55g7w==", "qfc34krlk")), Has.DecryptHas(Has.DeCryptWithKey("aWCDzninrEFB4iIpaBOXzQ==", "qfc34krlk"), useHasing: true, Has.DeCryptWithKey("fYSplgIsYRT9jdIYa55g7w==", "qfc34krlk")));
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("/qYwE5L7WneUCEiE2P2W8AYmoLW6QAVXRtI5JqupHYkpqhM7Qt0py6T6Ygevsdze", "qfc34krlk"), useHasing: true, Has.DeCryptWithKey("fYSplgIsYRT9jdIYa55g7w==", "qfc34krlk")), Has.DecryptHas("FdlYa4+thqI=", useHasing: true, Has.DeCryptWithKey("fYSplgIsYRT9jdIYa55g7w==", "qfc34krlk")));
			firefoxOptions.SetPreference(Has.DecryptHas("8kMQbDNaJfyrZ8j0mXopp9Ch2HXC0m+aprxfZs5hCy/WHcMkgGGFgQ==", useHasing: true, Has.DeCryptWithKey("D9v5/xGrEYM3b1/OIh65/w==", "34iicjxmjjqzr")), preferenceValue: true);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("RQguW7ByrRg6R2vzASxK7503CsqoQ9cMC0eGgV0QNVMq7bmAna6F0A==", "8cgwxgq2h875qx"), useHasing: true, Has.DeCryptWithKey("08pp/Q4vo0i43MCE63K4QA==", "8cgwxgq2h875qx")), Has.DecryptHas(Has.DeCryptWithKey("R+aWp+BH9jX1Tmb1lQaM3A==", "8cgwxgq2h875qx"), useHasing: true, Has.DeCryptWithKey("08pp/Q4vo0i43MCE63K4QA==", "8cgwxgq2h875qx")));
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("NAQuXNsE4rKSHBXIj3+hPJ1D3mG27g6xFge8MJBa4vMx7fR6njrMPJVX/5yW84k8", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("fkAvBuL+ngTC7EfVl5FtIw==", "l1mb5gw3")), value: true);
			firefoxProfile.SetPreference(Has.DecryptHas("/DLKzzmH6E90RA1sfh/BGZ72t79Um1ZQYiI2PG+2kIo=", useHasing: true, Has.DeCryptWithKey("fkAvBuL+ngTC7EfVl5FtIw==", "l1mb5gw3")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("2Il8saNizCcukn3Lm9jICHXZsHpGD4UEfJPfbC1ZocezUeTloJsfOKqeqnEExVOYHYY3D1Q85HIQZiU9melYrA==", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("fkAvBuL+ngTC7EfVl5FtIw==", "l1mb5gw3")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("2Il8saNizCcukn3Lm9jICHXZsHpGD4UEfJPfbC1ZoccQFumKWezIuPrGbXsxmFfd1Yl3QLfl18wQZiU9melYrA==", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("fkAvBuL+ngTC7EfVl5FtIw==", "l1mb5gw3")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("2Il8saNizCcukn3Lm9jICHXZsHpGD4UEfJPfbC1ZocdZWM7os3O8AQ24UjUHv6Oe", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("fkAvBuL+ngTC7EfVl5FtIw==", "l1mb5gw3")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("2Il8saNizCcukn3Lm9jICHXZsHpGD4UEfJPfbC1ZoceuxTmVrWljqYHTzojPbM5t1Yl3QLfl18wQZiU9melYrA==", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("fkAvBuL+ngTC7EfVl5FtIw==", "l1mb5gw3")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas("/DLKzzmH6E+JOwp20aKgn55aZ1pPWxDf", useHasing: true, Has.DeCryptWithKey("fkAvBuL+ngTC7EfVl5FtIw==", "l1mb5gw3")), value: true);
			firefoxProfile.SetPreference(Has.DecryptHas("nZVwLLv+MycWYqO8PUt8TkEE324VBBtnXH1F2S+/NkEdmEg2hSEE4g==", useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")), value: true);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("dTamZ8O4Y40VyPxnb0cbBDdrRRqLDsujWaW2e3mP3+B9P5e020sV+lZAIw30c5DV", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")), value: true);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("dTamZ8O4Y41iljTN3l0hr9VEtxdqt6ZTrYjmPx6jOZKytuWjjsIhnnAIUZcUycu5", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("dTamZ8O4Y42Z8iouHnLHidTX2PxKdcLTf1SOYlZAFTgQZiU9melYrA==", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")), Has.DecryptHas(Has.DeCryptWithKey("JzBNCbtevoNoGM21kQlJAo6LVZkSJkWkEGYlPZnpWKw=", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")));
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("dTamZ8O4Y41P7WJRPyFRA53S1CA7YBwa42MyWZ2naFeFf6RsYUHYqh7QssDYLQG1", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("dTamZ8O4Y40YDeKDbwp7qj/1yVjQKkiO8SxThsepc6jr5wYe8/SAly45f2qybBH7NsgOg5RV7ptZ7whfqenCGxBmJT2Z6Vis", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("dTamZ8O4Y40YDeKDbwp7qqEp6a7CsIu6+I1XzZ5WGAI/cVJD2VlpzRnxVoD0taLy/hMHsmV8dboQZiU9melYrA==", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas("jwdI7QR16hJGv3XNUrD1azuD9bvLL8Y+kvtwWeTftYxa3T9UAT4pJw==", useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas("jwdI7QR16hJGv3XNUrD1a8ZRNkyeEvyS2ND8AXO+N44KnGoOAYFMKg==", useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("dTamZ8O4Y42so6U3FBFhZdhawIjlF+bWX1pGBKhgXYci9/b0SBpxYr7jnkM+3gx2gUpIkkKXtW1IufI9jV5LDxBmJT2Z6Vis", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas("jwdI7QR16hKsUOrJI594Lv31SxkAOm45Hsq2Nq+0aN/pfia1nTSLjg==", useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("dTamZ8O4Y424wPlxQTnrrcQG9VZ+41tdfifFmHJhsEu1fY4llRRSiZbEJq+ANtXv1qFr1LfxynFZ7whfqenCGxBmJT2Z6Vis", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")), Has.DecryptHas(Has.DeCryptWithKey("tofCG8/AIspPhUCta+H6ZQ==", "l1mb5gw3"), useHasing: true, Has.DeCryptWithKey("w1RVjmOz4qyMevzUbyLYHQ==", "l1mb5gw3")));
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("wQ1Evv+CjRzFblt/p489fd6UVBSF9hTQONRAhEI8X6EpBEk1oBCa0w==", "fg4ixk"), useHasing: true, Has.DeCryptWithKey("8E2j756gpIpTSd9WVdz8Hw==", "fg4ixk")), 1);
			firefoxProfile.SetPreference(Has.DecryptHas("jwdI7QR16hJ4Yn+vrJwwGnTZXFuuF9m3MGsv/ypgfMTCkBDPhZNqrw==", useHasing: true, Has.DeCryptWithKey("8E2j756gpIpTSd9WVdz8Hw==", "fg4ixk")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas("jwdI7QR16hKEUNp+CjKncERAT3o/59tk3f8IPNnXq1r0oETg7ZoQUg==", useHasing: true, Has.DeCryptWithKey("8E2j756gpIpTSd9WVdz8Hw==", "fg4ixk")), Has.DecryptHas(Has.DeCryptWithKey("fXe5YVE7T4fKKj9afAoRrCNaiWVEESXdKQRJNaAQmtM=", "fg4ixk"), useHasing: true, Has.DeCryptWithKey("8E2j756gpIpTSd9WVdz8Hw==", "fg4ixk")));
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("wQ1Evv+CjRwJQoMSvzID6vdxmkImeHsmTuOm/X2AYNkpBEk1oBCa0w==", "fg4ixk"), useHasing: true, Has.DeCryptWithKey("8E2j756gpIpTSd9WVdz8Hw==", "fg4ixk")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas("ltslxVUQr2Q2DtvvVGi+/2aAdbO9/RZfyVhL3K+Kzfm0xbyssSXMGLzV4CDqDSBT", useHasing: true, Has.DeCryptWithKey("8E2j756gpIpTSd9WVdz8Hw==", "fg4ixk")), Has.DecryptHas("QPp/UlvOPHJ4yTYWABQddd3exxK2ZqP+Cg2VCOY4XrG1hw+FBRXTgnqccx7zu8ys", useHasing: true, Has.DeCryptWithKey("8E2j756gpIpTSd9WVdz8Hw==", "fg4ixk")));
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("GUJQcR1fwrb7k6atq1jmUXu5n/gCmyHSQgX9eyVmSmEfymxGjKAuSRkSIOreyXvsiBMlyuZkX5we9ydQCUVPNykESTWgEJrT", "fg4ixk"), useHasing: true, Has.DeCryptWithKey("VyJ1Z3OAet8=", "fg4ixk")), Has.DecryptHas("BrGVc1ZbMPLyB65udp/hNdK8LF3zQU+UzxDL5oFU4uXKS9m3onrWtQ==", useHasing: true, Has.DeCryptWithKey("VyJ1Z3OAet8=", "fg4ixk")));
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("4mSpWZSieB6XuV39cZuihTbrxtHRTjNqoXg6T1B+IsEUzaNprHF3KM4s+Vqw4BFZ", "fg4ixk"), useHasing: true, Has.DeCryptWithKey("VyJ1Z3OAet8=", "fg4ixk")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("Pdl/em/KLZTSNhJhv3kpMeHR+uQjO/3Twpq+1Fjn6Y6RTviwxOW5G3iGcYhTdows", "fg4ixk"), useHasing: true, Has.DeCryptWithKey("VyJ1Z3OAet8=", "fg4ixk")), 30);
			firefoxProfile.SetPreference(Has.DecryptHas("9lvzHfM7kY9jfO+hOqV+RP5h4BgPg2Ja", useHasing: true, Has.DeCryptWithKey("VyJ1Z3OAet8=", "fg4ixk")), 30);
			firefoxProfile.SetPreference(Has.DecryptHas("DAXNesFfvmyH13sutmcitv3NAFF14+KWbbT+N2gXeJA=", useHasing: true, Has.DeCryptWithKey("VyJ1Z3OAet8=", "fg4ixk")), value: true);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("KF1ijcFlQq0ozlAv1LvYHoYoD3MqvmLJDaScHABehwwpBEk1oBCa0w==", "fg4ixk"), useHasing: true, Has.DeCryptWithKey("VyJ1Z3OAet8=", "fg4ixk")), value: true);
			firefoxProfile.SetPreference(Has.DecryptHas("S+D5wciaG9TiPY8BYYXRvLYn4xecrFOwDX94hZu1jRKl7lJEQTlRQw==", useHasing: true, Has.DeCryptWithKey("VyJ1Z3OAet8=", "fg4ixk")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas("q0MVRhC+zzCB/nbzzEmjt3X0qmQ4q3iD", useHasing: true, Has.DeCryptWithKey("RhQjTGN+bv3rRHL3UD/SZw==", "s5ax5jsnak")), value: true);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("nCe6urYZIu4h44w8y9eo9pR2PTYarlSgF3YouA4VykQ=", "s5ax5jsnak"), useHasing: true, Has.DeCryptWithKey("RhQjTGN+bv3rRHL3UD/SZw==", "s5ax5jsnak")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("2/X/Wgy1R6dH3Cl7FtVSdC0eK+Sk7GiERZ96Jl17M54Xdii4DhXKRA==", "s5ax5jsnak"), useHasing: true, Has.DeCryptWithKey("RhQjTGN+bv3rRHL3UD/SZw==", "s5ax5jsnak")), 0);
			firefoxProfile.SetPreference(Has.DecryptHas("XsHG8Wf+/VFsAyOoVMK6/BGo9LdMfmLGMEbKJVWD6y6k0v0OGtC1OQ==", useHasing: true, Has.DeCryptWithKey("RhQjTGN+bv3rRHL3UD/SZw==", "s5ax5jsnak")), value: true);
			firefoxProfile.SetPreference(Has.DecryptHas("eVhf59QMZoMwcYE3NB4VNAEApqb8UfuBWe78IHaj+Mc=", useHasing: true, Has.DeCryptWithKey("ICf8is/i00D7deG0BiiaTg==", "mjs5xni6")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("JbvzVcVridJUQW+2j5DtGDr/wd8pcyDZQInb8kpNz5F9MilaowWg4L/YhIEtT6fM4pUaq0aLFoHr9T0HDt+jgg==", "mjs5xni6"), useHasing: true, Has.DeCryptWithKey("ICf8is/i00D7deG0BiiaTg==", "mjs5xni6")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas("p69+tYBTZltR0TED7DeGdw5CHGRfyHWkV2XVMDqIwoo=", useHasing: true, Has.DeCryptWithKey("ICf8is/i00D7deG0BiiaTg==", "mjs5xni6")), Has.DecryptHas(Has.DeCryptWithKey("jX8O+FG8FMUhg7WF8twP1w==", "mjs5xni6"), useHasing: true, Has.DeCryptWithKey("ICf8is/i00D7deG0BiiaTg==", "mjs5xni6")));
			firefoxProfile.SetPreference(Has.DecryptHas("p69+tYBTZltR0TED7DeGdw5CHGRfyHWkR/Wn7AuZ+d8EhOr1IZjvpA==", useHasing: true, Has.DeCryptWithKey("ICf8is/i00D7deG0BiiaTg==", "mjs5xni6")), Has.DecryptHas("p+LjndD/zdIdoBRVsCH/Iw==", useHasing: true, Has.DeCryptWithKey("ICf8is/i00D7deG0BiiaTg==", "mjs5xni6")));
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("yS+SjCX98zpYnOMqf64YdXq9ypvwfLJf+/t8RI0VsRj080vdrYVLqhmJEdpCm0tg", "mjs5xni6"), useHasing: true, Has.DeCryptWithKey("ICf8is/i00D7deG0BiiaTg==", "mjs5xni6")), value: false);
			firefoxProfile.SetPreference(Has.DecryptHas("HqHAzl2phvGFxTSbIFxvT+ilUmgh2w/SBWbMWq7vaFI=", useHasing: true, Has.DeCryptWithKey("ICf8is/i00D7deG0BiiaTg==", "mjs5xni6")), Has.DecryptHas(Has.DeCryptWithKey("xlVJZZGpXUYhKcK2xwq0AQ==", "mjs5xni6"), useHasing: true, Has.DeCryptWithKey("ICf8is/i00D7deG0BiiaTg==", "mjs5xni6")));
			firefoxProfile.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("m+lJCofmvc1SQQ7e2iJa9g/z0qK3ZASXx9SCqiAsGt7r9T0HDt+jgg==", "mjs5xni6"), useHasing: true, Has.DeCryptWithKey("YuBlT15NXufr9T0HDt+jgg==", "mjs5xni6")), Has.DecryptHas(Has.DeCryptWithKey("mbkFN5fH93f/F7wDx2dK1g==", "mjs5xni6"), useHasing: true, Has.DeCryptWithKey("YuBlT15NXufr9T0HDt+jgg==", "mjs5xni6")));
			firefoxProfile.SetPreference(Has.DecryptHas("O0FpEH8lWS+v988a3prFiTyH7KEckzd8ke0IH0zwwUY=", useHasing: true, Has.DeCryptWithKey("YuBlT15NXufr9T0HDt+jgg==", "mjs5xni6")), 32);
			firefoxProfile.SetPreference(Has.DecryptHas("O0FpEH8lWS+v988a3prFiUhqq9fhd9nBGxEWHxzmSYJm8TRiyl7kDptpsVXZCF6Dtjon15JcUBM=", useHasing: true, Has.DeCryptWithKey("YuBlT15NXufr9T0HDt+jgg==", "mjs5xni6")), 16);
			firefoxProfile.SetPreference(Has.DecryptHas("Pjqch5UNA+xYy8Kfeu1tQUk3EO6cZhuQCYYXANY5+Xg=", useHasing: true, Has.DeCryptWithKey("ytd9fDvtiaaDY/WdKIWr6w==", "z8yk5mo74zo")), 1);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("Kyu/BRf4bJuUgtT1CpLvznBy/yNkpsYXk2SM/pAUSpDXyKtoYYksBS7dwc6TN9wP", "z8yk5mo74zo"), useHasing: true, Has.DeCryptWithKey("ytd9fDvtiaaDY/WdKIWr6w==", "z8yk5mo74zo")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("I+1yqIJdyjjN3SVFMDhfwuyj/8lknYfDg2P1nSiFq+s=", "z8yk5mo74zo"), useHasing: true, Has.DeCryptWithKey("ytd9fDvtiaaDY/WdKIWr6w==", "z8yk5mo74zo")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("u8bWCFzDc7G2pngUC+bntFbbrDQTqQKR3ot4kFrn0dF1UuGrwK7b5ighGc3Aasim", "z8yk5mo74zo"), useHasing: true, Has.DeCryptWithKey("ytd9fDvtiaaDY/WdKIWr6w==", "z8yk5mo74zo")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("I+1yqIJdyjg1K6SYHtzHEdnLQTUHsUCDdS7ntyHrLhgx4ox0XHcc+28XOlhRQcnc", "z8yk5mo74zo"), useHasing: true, Has.DeCryptWithKey("ytd9fDvtiaaDY/WdKIWr6w==", "z8yk5mo74zo")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("NfixwncXCZMJj4hSI80TyxEw0ddm+CQ3EqCRDSn8EIk=", useHasing: true, Has.DeCryptWithKey("ytd9fDvtiaaDY/WdKIWr6w==", "z8yk5mo74zo")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("gqbrfcsDw9fTwVKHDUg+nWLtKTA/5OF6CvHhTUOMHq88rF9aa9f8cQ==", useHasing: true, Has.DeCryptWithKey("ytd9fDvtiaaDY/WdKIWr6w==", "z8yk5mo74zo")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("lKvb/BMDkTNWj3krUdxtR0CjjazKrGmsfmeCdPJnlZRwvfK+IMl4zg==", useHasing: true, Has.DeCryptWithKey("2tn3Ouc1CVssKoMTWZM41g==", "cx5zd")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("lKvb/BMDkTO1m6RgkLdSQKcOxr4t7XYw6d+ZRLuVzdc=", useHasing: true, Has.DeCryptWithKey("2tn3Ouc1CVssKoMTWZM41g==", "cx5zd")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("lKvb/BMDkTPD+PvpTh/wP2GY+EdSQ5Of5mytLzG6/vo=", useHasing: true, Has.DeCryptWithKey("2tn3Ouc1CVssKoMTWZM41g==", "cx5zd")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("lKvb/BMDkTPD+PvpTh/wP89khRBxoTR2TM10ANSsW40=", useHasing: true, Has.DeCryptWithKey("2tn3Ouc1CVssKoMTWZM41g==", "cx5zd")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("lKvb/BMDkTN0iPc+0Abuv+DJOMS5Ng4MJfOE5K82reI=", useHasing: true, Has.DeCryptWithKey("2tn3Ouc1CVssKoMTWZM41g==", "cx5zd")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("HYlN24t+mwjwlQOxX0OPR0clVS3p6C0iiXy2rwR/7bdJbSXsiTCgyslejiZAY62W", "cx5zd"), useHasing: true, Has.DeCryptWithKey("2tn3Ouc1CVssKoMTWZM41g==", "cx5zd")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("ETtGIZ2gzhGHECWifENTWCDi4xzEAN9mYcCJKC7YPJoeJrEu7HK3vDIYQDKDpS5SFqhzYonpnplQWmmrjVeFiPzK9v+EPXFG", "cx5zd"), useHasing: true, Has.DeCryptWithKey("2tn3Ouc1CVssKoMTWZM41g==", "cx5zd")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("MEXpyqS2oUl1/LZve8QSYwx0Avs+g1I3vcvTDGVFHHrMO8c1jzLzRtl2d+Wy649cHJdKjS2lbsQ=", useHasing: true, Has.DeCryptWithKey("2tn3Ouc1CVssKoMTWZM41g==", "cx5zd")), Has.DecryptHas(Has.DeCryptWithKey("q1U2DzVNxMa014iah2NAxA==", "cx5zd"), useHasing: true, Has.DeCryptWithKey("2tn3Ouc1CVssKoMTWZM41g==", "cx5zd")));
			firefoxOptions.SetPreference(Has.DecryptHas("MEXpyqS2oUl1/LZve8QSYwx0Avs+g1I3vcvTDGVFHHoBth/MsMymmSHrTH0s13od", useHasing: true, Has.DeCryptWithKey("YTAcVwxA8a5wOEXv3Y2o3w==", "6cm65qkryfi8o")), Has.DecryptHas(Has.DeCryptWithKey("1e/b1cD/D60D9lHMPzyNpw==", "6cm65qkryfi8o"), useHasing: true, Has.DeCryptWithKey("YTAcVwxA8a5wOEXv3Y2o3w==", "6cm65qkryfi8o")));
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("9dK91S2M6is43w4uuWTsUdaext1o3JIfAL/wBbvQL9Q7nm5KyjZ1vyhllPvgbv9kt7lX6V5XTN8VnSopZrf8Nw==", "6cm65qkryfi8o"), useHasing: true, Has.DeCryptWithKey("kGPjDY79v4oIvWNCBr6Ptg==", "6cm65qkryfi8o")), Has.DecryptHas("Q5Zls/+ZxQc=", useHasing: true, Has.DeCryptWithKey("kGPjDY79v4oIvWNCBr6Ptg==", "6cm65qkryfi8o")));
			firefoxOptions.SetPreference(Has.DecryptHas("DgNb+2nyUQarxxXnciVyVoWZRg0VjlaX", useHasing: true, Has.DeCryptWithKey("kGPjDY79v4oIvWNCBr6Ptg==", "6cm65qkryfi8o")), Has.DecryptHas("Q5Zls/+ZxQc=", useHasing: true, Has.DeCryptWithKey("kGPjDY79v4oIvWNCBr6Ptg==", "6cm65qkryfi8o")));
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("Jpmr8hZnTtpIAEzHmLh5lkWMX2ZAuYk80UztLwlXCGgVnSopZrf8Nw==", "6cm65qkryfi8o"), useHasing: true, Has.DeCryptWithKey("kGPjDY79v4oIvWNCBr6Ptg==", "6cm65qkryfi8o")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("uGswFZvVimYeTIInr4XZJDqtBvoDhWpeYIX2PS2wr519zcHVPmcjfkY4mJVv1z+J", "6cm65qkryfi8o"), useHasing: true, Has.DeCryptWithKey("kGPjDY79v4oIvWNCBr6Ptg==", "6cm65qkryfi8o")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas("l9bMFPamtA1CojHJ441zJ+IRvmw9PfsSsizqkjumDbHA8iiS3PcDsg==", useHasing: true, Has.DeCryptWithKey("kGPjDY79v4oIvWNCBr6Ptg==", "6cm65qkryfi8o")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("fpwVsr3esg2qVieTEiJH3GQYxojZqhQI1cOfdyDjn6yNbhSDj96aeCU7MTYJbvjF", "j1tldpq"), useHasing: true, Has.DeCryptWithKey("Pw+rxSXW7K5M2yKhETqPuQ==", "j1tldpq")), preferenceValue: false);
			firefoxOptions.SetPreference(Has.DecryptHas(Has.DeCryptWithKey("jnFl8cqT20ME/BqWfRJQP6bOisJ4+FDbB2SNQ7tBMWDHBgF7UAvqnYxGLsvWwTO4FT184c9a7rEig4r/GXVltw==", "j1tldpq"), useHasing: true, Has.DeCryptWithKey("Pw+rxSXW7K5M2yKhETqPuQ==", "j1tldpq")), preferenceValue: true);
			firefoxOptions.SetPreference(Has.DecryptHas("l9bMFPamtA1SUx0cfKtYC2DhAx0Zc+jF", useHasing: true, Has.DeCryptWithKey("Pw+rxSXW7K5M2yKhETqPuQ==", "j1tldpq")), Application.StartupPath + Has.DecryptHas(Has.DeCryptWithKey("LzMQkmZyXNjqRxt9TUb3ubqTevAngp/bjUXbmLEqX/wig4r/GXVltw==", "j1tldpq"), useHasing: true, Has.DeCryptWithKey("Pw+rxSXW7K5M2yKhETqPuQ==", "j1tldpq")));
			firefoxOptions.BrowserExecutableLocation = Has.DecryptHas("YZ+obBFcq0vHoMg08hU6jBqIgcCYgVKUNT/Of7IKjqENKOw+IfD2jgE9Wcmep8efCCUBxLjPQzk=", useHasing: true, Has.DeCryptWithKey("Pw+rxSXW7K5M2yKhETqPuQ==", "j1tldpq"));
			firefoxProfile.AddExtension(Application.StartupPath + Has.DecryptHas(Has.DeCryptWithKey("yCSBi7G5kpy6ff85+vUwVFh0cEn0MUZ3h6q9ICNIVbPLGZTyO/3DIabmYKeAdnot+0aWoqpnSTgig4r/GXVltw==", "j1tldpq"), useHasing: true, Has.DeCryptWithKey("r9j+QBWJ4hNxekNqMpsV8Q==", "j1tldpq")));
			firefoxOptions.Profile = firefoxProfile;
			firefoxOptions.Profile = firefoxProfile;
			if (User_Proxy && !string.IsNullOrEmpty(thongtin.proxy) && tt_kk._key.Length.ToString() == Has.DecryptHas("dCcBopYUZog=", useHasing: true, "rtusmh12d"))
			{
				if (thongtin.proxy.Contains('|'))
				{
					string text = thongtin.proxy.Split('|')[1];
					Thongso_Proxy.ip = text.Split(':')[0];
					Thongso_Proxy.port = text.Split(':')[1];
					if (text.Split(':').ToList().Count > 2)
					{
						Thongso_Proxy.proxy_user = text.Split(':')[2];
						Thongso_Proxy.proxy_pass = text.Split(':')[3];
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
				string preferenceValue3 = (thongtin.proxy.Contains('|') ? thongtin.proxy.Split('|')[1].Split(':')[0] : thongtin.proxy.Split(':')[0]);
				string value = (thongtin.proxy.Contains('|') ? thongtin.proxy.Split('|')[1].Split(':')[1] : thongtin.proxy.Split(':')[1]);
				firefoxOptions.SetPreference("network.proxy.type", 1);
				firefoxOptions.SetPreference("network.proxy.http", preferenceValue3);
				firefoxOptions.SetPreference("network.proxy.http_port", Convert.ToInt32(value));
				firefoxOptions.SetPreference("network.proxy.ssl", preferenceValue3);
				firefoxOptions.SetPreference("network.proxy.ssl_port", Convert.ToInt32(value));
			}
			return firefoxOptions;
		}

		private string RandomNumber(int numberRD)
		{
			string text = "";
			try
			{
				int[] array = new int[numberRD];
				Random random = new Random();
				for (int i = 0; i < numberRD; i++)
				{
					array[i] = Convert.ToInt32(random.Next(1, 9));
					text += array[i];
				}
			}
			catch
			{
				text = "error";
			}
			return text;
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

		private string get_cookie()
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
				thongtin.cookie = text;
				sqlite.Update_Data_FB(thongtin);
			}
			catch
			{
			}
			return text;
		}

		private void Deley(int min, int max)
		{
			Thread.Sleep(TimeSpan.FromSeconds(r.Next(min, max)));
		}

		private bool Url()
		{
			try
			{
				Poin poin = new Poin();
				string url = Has.DecryptHas("gZcQ9Q5efHxdpsDpxGcaFbi+vCWqRr5D", useHasing: true, "q3k1khz9m");
				FirefoxDriverService service = FirefoxService();
				FirefoxOptions options = FirefoxOptions();
				driver = new FirefoxDriver(service, options);
				driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120.0);
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3.0);
				driver.Manage().Window.Position = new Point(poin.X(), poin.Y());
				driver?.Navigate().GoToUrl(url);
				return true;
			}
			catch (Exception ex)
			{
				thongtin.TrangThai = ex.Message;
				Stop_thread = true;
				return false;
			}
		}

		private bool login_cookie(string cookie)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (string.IsNullOrEmpty(cookie) && tt_kk._key.Contains(Has.DecryptHas("Co4OJJOw89Q=", useHasing: true, "52hec17jzleqd")))
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
			if (!Stop_thread)
			{
				driver?.Navigate()?.Refresh();
			}
			return true;
		}

		private void Change_Total()
		{
			Task task = new Task(delegate
			{
				while (!Stop_thread && !Stop.stop_FB && tt_kk._key.Length.ToString() == Has.DecryptHas("o2I9rYDS7AE=", useHasing: true, "yzq1kdwtmet") && driver != null)
				{
					Inswfb.remote.Change_Row(thongtin);
					Thread.Sleep(1000);
				}
				if (Stop.stop_FB || tt_kk._key.Length.ToString() == Has.DecryptHas("o2I9rYDS7AE=", useHasing: true, "yzq1kdwtmet") || driver == null)
				{
					Stop_thread = true;
					thongtin.TrangThai = "Stop !";
				}
				Inswfb.remote.Change_Row(thongtin);
			});
			task.Start();
		}

		public static string _2FA(string _2FA)
		{
			string text = Has.DeCryptWithKey("NmY0BUG/Bhu7LRHcREZonH9VtDryRsyF", "zge7lhhi2bgd");
			xNet.HttpRequest httpRequest = new xNet.HttpRequest();
			try
			{
				string text2 = httpRequest.Get(text + _2FA?.Replace(Has.DeCryptWithKey("Y9GFr3X7d7k=", "zge7lhhi2bgd"), Has.DeCryptWithKey("KgHNNxLkyT0=", "zge7lhhi2bgd")).Trim()).ToString();
				if (text2.Contains(Has.DeCryptWithKey("VwfYdiWEA/4=", "c5lmt")) && tt_kk._key.Contains(Has.DecryptHas("Co4OJJOw89Q=", useHasing: true, "52hec17jzleqd")))
				{
					JObject jObject = JObject.Parse(text2);
					text2 = jObject[Has.DeCryptWithKey("VwfYdiWEA/4=", "c5lmt")]!.ToString().Trim();
				}
				return text2;
			}
			catch
			{
				return null;
			}
		}

		private string random(int a)
		{
			string text = "abcdefghijklmnopqrstuvwxyz0123456789";
			char[] array = new char[a];
			Random random = new Random();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = text[random.Next(text.Length)];
			}
			return new string(array);
		}

		private string random_int(int a)
		{
			string text = "0123456789";
			char[] array = new char[a];
			Random random = new Random();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = text[random.Next(text.Length)];
			}
			return new string(array);
		}

		private string FullName()
		{
			string path = "ten.txt";
			string[] array = File.ReadAllLines(path);
			return array[r.Next(0, array.Length)];
		}

		private bool login_acc()
		{
			try
			{
				driver.Manage().Cookies.DeleteAllCookies();
				driver?.Navigate().GoToUrl("https://m.facebook.com/");
				if (Stop_thread)
				{
					return true;
				}
				thongtin.TrangThai = Has.DeCryptWithKey("rhqrPoE/Vm57dPaZq5lBtQ==", "k8fiikr");
				FindElement(By.Name(Has.DeCryptWithKey("cVHGE8jLm9w=", "k8fiikr")))?.SendKeys(thongtin.User);
				Deley(1, 3);
				FindElement(By.Name(Has.DeCryptWithKey("CFR1bNdTYhw=", "k8fiikr")))?.SendKeys(thongtin.Pass);
				Deley(1, 3);
				Thaotac_Click(By.Name(Has.DeCryptWithKey("rYrHtTxp5R0=", "k8fiikr")));
				Deley(4, 7);
				if (check_element(By.XPath(Has.DeCryptWithKey("ur9UpJRTX35RbetNxH3IFvNdoDwoDvw/P9VZfxFo+ouozvOR6fj9w5mnfrVZZVasZUgwu7w3fkE=", "k8fiikr"))) || check_element(By.XPath(Has.DeCryptWithKey("ur9UpJRTX35RbetNxH3IFvNdoDwoDvw/vpRV3p7qs/qozvOR6fj9w2V276Wa1ZtI0NeIEqYFJJk=", "k8fiikr"))))
				{
					thongtin.TrangThai = Has.DeCryptWithKey("mTDZvAKVutwXZFwLbu2vEw==", "wxmxqkyxxcl");
					return false;
				}
				if (driver.Url.Contains(Has.DeCryptWithKey("Hx9RtLerk46K4z6iSUAg+KEvvDMiZF+I", "wxmxqkyxxcl")))
				{
					thongtin.TrangThai = Has.DeCryptWithKey("9rseyem7t+VCiAW47QcPSw==", "wxmxqkyxxcl");
					thongtin.Color = 0;
					return false;
				}
				if (string.IsNullOrEmpty(thongtin._2FA))
				{
					Thaotac_Click(By.CssSelector(Has.DeCryptWithKey("nqHS9jJiZIsnbERV8Lb8Qw==", "wxmxqkyxxcl")));
				}
				else
				{
					for (int i = 0; i < 5; i++)
					{
						thongtin.TrangThai = Has.DeCryptWithKey("8E3c5vw1qYO8jy8OlJCjKJLQtMqc++Fw", "wxmxqkyxxcl");
						if (check_element(By.XPath(Has.DeCryptWithKey("IGIfirfesbDHRk+kdgQIoDio+XFhHmSD3jAvYFd60+zu3+VdpW1pCmehLu/RtDJgz5JdI7f5w4F0RHbHkoW+1Nfxy7h5R+8s9bdMo7iCyM9+J8jMkIGN/g==", "wxmxqkyxxcl"))) && !check_element(By.Name(Has.DeCryptWithKey("7p8IyGdNgguhteLm5pEXiyjFy/30RfHn", "wxmxqkyxxcl"))))
						{
							thongtin.TrangThai = Has.DeCryptWithKey("WJByEOSK4LDZn/k81vfkbw==", "rb34iongs");
							return false;
						}
						if (!check_element(By.Name(Has.DeCryptWithKey("WYMqOdyusBoAKv1K+2zsnw==", "30ajqnuhrrfvz"))))
						{
							break;
						}
						string text = _2FA(thongtin._2FA);
						if (text != null)
						{
							FindElement(By.Name(Has.DeCryptWithKey("WYMqOdyusBoAKv1K+2zsnw==", "30ajqnuhrrfvz")))?.SendKeys(text);
							Deley(1, 3);
							Thaotac_Click(By.Name(Has.DeCryptWithKey("pq8bR59g7jp72Krj355oPv8TSgoA4V3u", "yfrrirk0mah")));
							Deley(2, 4);
						}
					}
					if (check_element(By.Name(Has.DeCryptWithKey("HDQnZPIxkFSZeErWKnBOGg==", "yfrrirk0mah"))))
					{
						thongtin.TrangThai = Has.DeCryptWithKey("VVBUFS7i8lDjs1SvBit7Kw==", "yfrrirk0mah");
						return false;
					}
					if (!check_element(By.Name(Has.DeCryptWithKey("Z/LUU7FRgOxFohS321pTQXilVMqBTHj5", "yfrrirk0mah"))))
					{
						thongtin.TrangThai = Has.DeCryptWithKey("OOexQg+8NvE=", "b4y6q");
						return false;
					}
					Thaotac_Click(By.Name(Has.DeCryptWithKey("IV4n1ZeJa8M7ynzwqD5rREcGBDfoGkIK", "b4y6q")));
					Deley(9, 15);
					if (driver.Url.Contains(Has.DeCryptWithKey("RvtUMGJ7zDaUm0pg5xfB8A==", "b4y6q")))
					{
						thongtin.TrangThai = Has.DeCryptWithKey("vNf1DcDpanNY8/bqN78FzQ==", "nt4lyqw2");
						thongtin.Color = 0;
						return false;
					}
				}
				thongtin.TrangThai = Has.DeCryptWithKey("Nibd8ovj2QhH7WGJXZGNF2nYhv9GEdgb", "nt4lyqw2");
				thongtin.Color = 1;
				return true;
			}
			catch
			{
				return false;
			}
		}

		private bool Dangbai_sln()
		{
			List<string> list = (string.IsNullOrEmpty(ThongSo_Inswfb.txt_PathImg) ? null : (from s in Directory.GetFiles(ThongSo_Inswfb.txt_PathImg, "*.*", SearchOption.AllDirectories)
				where s.EndsWith(".png") || s.EndsWith(".jpg")
				select s).ToList());
			if (list == null)
			{
				return true;
			}
			int num = r.Next(ThongSo_Inswfb.num_Post_SLMin, ThongSo_Inswfb.num_Post_SLMax);
			if (driver?.Url != "https://www.instagram.com/")
			{
				driver?.Navigate()?.GoToUrl("https://www.instagram.com/");
			}
			for (int i = 0; i < num; i++)
			{
				int num2 = 30;
				try
				{
					driver.ExecuteScript(Has.DecryptHas(Has.DecryptHas("SxNu8Pe0HMV74Sh0JqisMPc3QLM9sfsCc+ykjjRCQDGVZyWSN2da/PjE7dFRqP1Mxq1NuB6jKJVpoo6nGhKQ/o/tFPdN7nkTLKvn35s1rWCBbx2YB9wBiRMhlq/Cm3pbObT8CHoVzZbldejgTSyoQChdQRbd1CcktlkFpDYxSooqCw2h5Fj8V7ok8gSeDnR6iyPzW6XtjBAuH0AT2aCAhLojNg3oB2y0", useHasing: true, "uug2tu7xlk"), useHasing: true, Has.DecryptHas("EGrj9pmSig0=", useHasing: true, "uug2tu7xlk")));
					Deley(1, 2);
					driver.FindElements(By.CssSelector("[data-testid=\"new-post-button\"]"))?[0]?.Click();
					Deley(1, 2);
					try
					{
						driver.FindElement(By.CssSelector("section>nav:nth-child(4) form input"))?.Click();
					}
					catch
					{
					}
					driver.FindElement(By.CssSelector("section>nav:nth-child(4) form input")).SendKeys(list[r.Next(0, list.Count)]);
					Deley(1, 2);
					Thaotac_Click(By.CssSelector("button.UP43G"));
					Deley(1, 2);
					Thaotac_Click(By.CssSelector("button.UP43G"));
					Deley(2, 3);
					while (driver.Url != "https://www.instagram.com/")
					{
						num2--;
						if (num2 <= 15)
						{
							try
							{
								FindElement(By.CssSelector("button.UP43G"))?.Click();
							}
							catch
							{
							}
						}
						if (num2 <= 0)
						{
							driver?.Navigate()?.GoToUrl("https://www.instagram.com/");
							break;
						}
					}
					Deley(9, 15);
				}
				catch
				{
				}
			}
			return true;
		}

		private bool check_challenge()
		{
			string url = driver.Url;
			if (url.Contains("challenge"))
			{
				return true;
			}
			return false;
		}

		private bool following()
		{
			int dem = 7;
			bool check = false;
			Task task = new Task(delegate
			{
				while (dem <= 0 && !check)
				{
					dem--;
					Thread.Sleep(1000);
				}
				if (dem <= 0 && !check)
				{
					driver.Navigate().GoToUrl("https://www.instagram.com/explore/people/suggested/");
				}
			});
			task.Start();
			try
			{
				List<IWebElement> list = _FindElements(By.CssSelector("button.sqdOP.L3NKy.y3zKF"))?.ToList();
				if (check_challenge())
				{
					return false;
				}
				try
				{
					FindElement(By.CssSelector("button.aOOlW.HoLwm"), 2)?.Click();
				}
				catch
				{
				}
				FindElements(By.CssSelector("button.sqdOP.L3NKy.y3zKF"), 0)?.Click();
				check = true;
				Thread.Sleep(1000);
				return true;
			}
			catch
			{
				return true;
			}
		}

		private bool url_follow(ThongTin tt)
		{
			int num = r.Next(ThongSo_Inswfb.num_Follow_SLMin, ThongSo_Inswfb.num_Follow_SLMax);
			driver.Navigate().GoToUrl("https://www.instagram.com/explore/people/suggested/");
			FindElement(By.CssSelector("button.aOOlW.HoLwm"), 1)?.Click();
			Deley(1, 3);
			for (int i = 0; i < num; i++)
			{
				if (!following())
				{
					tt.TrangThai = "Acc Checkpoin !";
					tt.TinhTrang = "Not Live !";
					tt.Color = 0;
					return false;
				}
				Deley(1, 3);
			}
			return true;
		}

		private bool login()
		{
			SQLite sQLite = new SQLite();
			if (Stop_thread)
			{
				return false;
			}
			if (!string.IsNullOrEmpty(thongtin.cookie.Trim()) || Stop_thread)
			{
				thongtin.TrangThai = Has.DeCryptWithKey("gkHk/h6adEfhbfHZ5Mk/Ytf0warH/Mec", "527yfx5vutp8w");
				bool flag = login_cookie(thongtin.cookie);
				if (!check_element(By.CssSelector(Has.DeCryptWithKey("UflbLo/q/fvUCCQbp+nRGw==", "527yfx5vutp8w"))))
				{
					thongtin.TrangThai = Has.DeCryptWithKey("orLRO9fuD0nflHl31p9qEHWcVu45HJ4U", "irddowb");
					thongtin.Color = 1;
					sQLite.Update_Data_FB(thongtin);
					return true;
				}
				thongtin.TrangThai = Has.DeCryptWithKey("9EsUjmgOk+fG+HKD17WssxBc3iN45fn2", "527yfx5vutp8w");
			}
			bool flag2 = login_acc();
			if (Stop_thread)
			{
				return false;
			}
			Deley(2, 3);
			if (!flag2)
			{
				return false;
			}
			thongtin.cookie = get_cookie();
			sQLite.Update_Data_FB(thongtin);
			return true;
		}

		public static string convertToUnSign3(string s)
		{
			Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
			string input = s.Normalize(NormalizationForm.FormD);
			return regex.Replace(input, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
		}

		private bool register()
		{
			List<string> rtb_Pass = ThongSo_Inswfb.rtb_Pass;
			rtb_Pass?.RemoveAll((string x) => x == Has.DecryptHas("ATazlMVqHJs=", useHasing: true, "lm45me10"));
			List<string> rtb_hotmail = ThongSo_Inswfb.rtb_hotmail;
			rtb_hotmail?.RemoveAll((string x) => x == Has.DecryptHas("ATazlMVqHJs=", useHasing: true, "lm45me10"));
			List<string> list = (string.IsNullOrEmpty(ThongSo_Inswfb.txt_PathImg) ? null : Directory.GetFiles(ThongSo_Inswfb.txt_PathImg, Has.DecryptHas("+gwSGGzhsCo=", useHasing: true, "lm45me10"), SearchOption.AllDirectories)?.Where((string s) => s.EndsWith(Has.DecryptHas("IhxFrrfFNcc=", useHasing: true, "lm45me10")) || s.EndsWith(Has.DecryptHas("RWo97NUoycU=", useHasing: true, "lm45me10"))).ToList());
			ThongTin thongTin = new ThongTin();
			List<ThongTin> list2 = new List<ThongTin>();
			string text = Has.DecryptHas("i0bxvxghjBKtFk2BS1a+szm+jS4FPjuyM3ol028Moic=", useHasing: true, "dajm3");
			try
			{
				driver?.Navigate().GoToUrl(text);
				Deley(1, 3);
				Thaotac_Click(By.CssSelector(Has.DecryptHas("NknEEANPY5YBy/4pQvTuuUmTv2UASjlKRXt556NWERE=", useHasing: true, "dxk5j")));
				Deley(1, 3);
				if (check_element(By.CssSelector("div.bkEs3:nth-child(1) > button:nth-child(1) > span:nth-child(2)")))
				{
					Thaotac_Click(By.CssSelector(Has.DecryptHas("yGugdksgMikcsSTOi67YZuOvdy7BfrOORK7Ky2ApQHfPBsWmt6XBpF0NkJlbZWV5+QP9PTwKWzDh76/4eoHBOr2d6yz6Eifz", useHasing: true, "dxk5j")));
					Deley(3, 4);
				}
				else
				{
					driver.Navigate().GoToUrl(Has.DecryptHas("abphD3mIt5ALJQMEg0NK5MUY4lqLZR3jC3FDZ5nlpE/ivhKRiWwk+bfGzkDYkTVk", useHasing: true, "11s6xfv4aoun"));
					Deley(2, 3);
					FindElement(By.CssSelector(Has.DecryptHas("noiahJ1+8CY=", useHasing: true, "eqzl5e")))?.Click();
					Deley(2, 3);
				}
				Thaotac_Click(By.CssSelector(Has.DecryptHas("bw0qJl9wa+w=", useHasing: true, "eqzl5e")));
				Deley(3, 4);
				for (int i = 0; i < r.Next(3, 5); i++)
				{
					Thaotac_Click(By.CssSelector(Has.DecryptHas("P6CH4bSW6PQTFoviFnRoYV7IjMQ+EiCSZs7mWobmMUSUrwEvhrqUQKEkeFS4PD+7", useHasing: true, "eqzl5e")));
					Deley(5, 9);
					if (driver.Url.Contains(Has.DecryptHas("rrjFiI45Tok5QyybBf+pdCvnmF5Lw2go", useHasing: true, "7c2cbfhdge6n7b")))
					{
						break;
					}
				}
				if (!driver.Url.Contains(Has.DecryptHas("rrjFiI45Tok5QyybBf+pdCvnmF5Lw2go", useHasing: true, "7c2cbfhdge6n7b")))
				{
					return false;
				}
				Deley(2, 3);
				IWebElement webElement = FindElement(By.Name(Has.DecryptHas("JUCetpmQ4vQkxVewHlxS/g==", useHasing: true, "7c2cbfhdge6n7b")));
				for (int j = 0; j < r.Next(3, 5); j++)
				{
					if (Stop_thread || tt_kk.day > int.Parse(Has.DecryptHas("/W3Tz14T6Gc=", useHasing: true, "xsm4l5zmwnq")))
					{
						return false;
					}
					if (!ThongSo_Inswfb.cb_DoiTen)
					{
						thongTin.FullName = FindElement(By.Name(Has.DecryptHas("JUCetpmQ4vQkxVewHlxS/g==", useHasing: true, "7c2cbfhdge6n7b")))?.GetAttribute(Has.DecryptHas("MKUGNMSxUSI=", useHasing: true, "7c2cbfhdge6n7b"));
						break;
					}
					string text2 = FullName();
					webElement?.Clear();
					webElement?.SendKeys(text2);
					Deley(1, 3);
					thongTin.FullName = FindElement(By.Name(Has.DecryptHas("5fSHFw3naAe6RbPzf+picA==", useHasing: true, "k18rjen")))?.GetAttribute(Has.DecryptHas("RVDK+R7tFzU=", useHasing: true, "k18rjen"));
					if (thongTin.FullName == text2)
					{
						break;
					}
				}
				if (ThongSo_Inswfb.rad_ChangePass_Random || rtb_Pass.Count == 0)
				{
					thongTin.Pass = random(8);
				}
				else
				{
					thongTin.Pass = rtb_Pass[r.Next(0, rtb_Pass.Count)];
				}
				FindElement(By.Name(Has.DecryptHas("sZ/BZ0ZA6PP1kKu8iOSD4w==", useHasing: true, "xqf6rdtff7q")))?.SendKeys(thongTin.Pass);
				Deley(1, 3);
				string[] array = thongTin.FullName.Split(' ');
				if (array.Count() == 1)
				{
					thongTin.User = (convertToUnSign3(array[0]).Trim() + Has.DeCryptWithKey("cCH97k+owFw=", "hfqlpr7") + random_int(4)).ToLower();
					FindElement(By.Name(Has.DeCryptWithKey("hLPL+lOX5Bq+9sO5iOeP2w==", "hfqlpr7")))?.Clear();
					FindElement(By.Name(Has.DeCryptWithKey("hLPL+lOX5Bq+9sO5iOeP2w==", "hfqlpr7")))?.SendKeys(thongTin.User);
				}
				else if (array.Count() == 2)
				{
					thongTin.User = (convertToUnSign3(array[0]).Trim() + Has.DeCryptWithKey("cCH97k+owFw=", "hfqlpr7") + convertToUnSign3(array[1]).Trim() + random_int(4)).ToLower();
					FindElement(By.Name(Has.DeCryptWithKey("hLPL+lOX5Bq+9sO5iOeP2w==", "hfqlpr7")))?.Clear();
					FindElement(By.Name(Has.DeCryptWithKey("hLPL+lOX5Bq+9sO5iOeP2w==", "hfqlpr7")))?.SendKeys(thongTin.User);
				}
				else if (array.Count() == 3)
				{
					thongTin.User = (convertToUnSign3(array[1]).Trim() + Has.DeCryptWithKey("cCH97k+owFw=", "hfqlpr7") + convertToUnSign3(array[2]).Trim() + random_int(4)).ToLower();
					FindElement(By.Name(Has.DeCryptWithKey("hLPL+lOX5Bq+9sO5iOeP2w==", "hfqlpr7")))?.Clear();
					FindElement(By.Name(Has.DeCryptWithKey("hLPL+lOX5Bq+9sO5iOeP2w==", "hfqlpr7")))?.SendKeys(thongTin.User);
				}
				else
				{
					for (int k = 0; k < r.Next(3, 5); k++)
					{
						Thaotac_Click(By.CssSelector(Has.DeCryptWithKey("+IMEUEZwAJDdc7ApuaUF8ZO3d03adp4N", "u4x0xqdmqi")));
						Deley(1, 2);
					}
					thongTin.User = FindElement(By.Name(Has.DeCryptWithKey("O2DwHbsRxJANvby7qGme8w==", "u4x0xqdmqi")))?.GetAttribute(Has.DeCryptWithKey("0guwZX1YvCM=", "u4x0xqdmqi"));
				}
				Deley(2, 4);
				if (Stop_thread)
				{
					return false;
				}
				Thaotac_Click(By.CssSelector(Has.DecryptHas("ls+sEyy8B9s=", useHasing: true, "4t3srhpz9nlti")));
				Deley(15, 20);
				for (int l = 0; l < r.Next(2, 4); l++)
				{
					if (Stop_thread || tt_kk.day > int.Parse(Has.DecryptHas("/W3Tz14T6Gc=", useHasing: true, "xsm4l5zmwnq")))
					{
						return false;
					}
					if (driver.Url.Contains(Has.DecryptHas("5xI/fT9LQ+c1M8TgdovMESYNYhOWyhYF", useHasing: true, "hia7zg")))
					{
						break;
					}
					if (array.Count() == 1)
					{
						thongTin.User = (convertToUnSign3(array[0]).Trim() + "." + random_int(4)).ToLower();
						FindElement(By.Name("username"))?.Clear();
						FindElement(By.Name("username"))?.SendKeys(thongTin.User);
					}
					else if (array.Count() == 2)
					{
						thongTin.User = (convertToUnSign3(array[0]).Trim() + "." + convertToUnSign3(array[1]).Trim() + random_int(4)).ToLower();
						FindElement(By.Name("username"))?.Clear();
						FindElement(By.Name("username"))?.SendKeys(thongTin.User);
					}
					else if (array.Count() == 3)
					{
						thongTin.User = (convertToUnSign3(array[1]).Trim() + "." + convertToUnSign3(array[2]).Trim() + random_int(4)).ToLower();
						FindElement(By.Name("username"))?.Clear();
						FindElement(By.Name("username"))?.SendKeys(thongTin.User);
					}
					else
					{
						for (int m = 0; m < r.Next(3, 5); m++)
						{
							Thaotac_Click(By.CssSelector(".coreSpriteInputRefresh"));
							Deley(1, 2);
						}
						thongTin.User = FindElement(By.Name("username"))?.GetAttribute("value");
					}
					Thaotac_Click(By.CssSelector(Has.DecryptHas("LWqHj6cCK+4=", useHasing: true, "hia7zg")));
					Deley(3, 6);
				}
				if (!driver.Url.Contains(Has.DecryptHas("5xI/fT9LQ+c1M8TgdovMESYNYhOWyhYF", useHasing: true, "hia7zg")))
				{
					return false;
				}
				Thaotac_Click(By.CssSelector(".sqdOP"));
				Deley(2, 3);
			}
			catch (Exception ex)
			{
				thongtin.TrangThai = ex.Message;
				driver.Manage().Cookies.DeleteAllCookies();
				Deley(2, 3);
				driver?.Navigate().GoToUrl(text);
				Deley(1, 3);
				Thaotac_Click(By.CssSelector(Has.DecryptHas("NknEEANPY5YBy/4pQvTuuUmTv2UASjlKRXt556NWERE=", useHasing: true, "dxk5j")));
				Deley(1, 3);
				Thaotac_Click(By.CssSelector(Has.DecryptHas("yGugdksgMikcsSTOi67YZuOvdy7BfrOORK7Ky2ApQHfPBsWmt6XBpF0NkJlbZWV5+QP9PTwKWzDh76/4eoHBOr2d6yz6Eifz", useHasing: true, "dxk5j")));
				Deley(3, 4);
				return false;
			}
			thongTin.cookie = get_cookie();
			if (ThongSo_Inswfb.cb_post)
			{
				Dangbai_sln();
			}
			Deley(2, 4);
			if (ThongSo_Inswfb.cb_follow && !url_follow(thongTin))
			{
				list2.Add(thongTin);
				sqlite.Save_Data(list2);
				Form1.remote.Load_dgvacc();
				return false;
			}
			if (Stop_thread)
			{
				return false;
			}
			driver?.Navigate().GoToUrl(text + Has.DecryptHas("8RgtUIceQRtR6ztEnW83vA==", useHasing: true, "bxrfr"));
			Deley(1, 3);
			FindElement(By.CssSelector("input#pepEmail.JLJ-B.zyHYP"))?.Clear();
			Deley(1, 2);
			if (ThongSo_Inswfb.rad_FakeEmail)
			{
				FindElement(By.CssSelector(Has.DecryptHas("iWiBqVZP7ETCS5cKlhUTQTSDZBU0EIPgiTDKD1uWLos=", useHasing: true, "movnildr")))?.SendKeys(thongTin.User + Has.DecryptHas("Xw2bibPnbw8=", useHasing: true, "movnildr") + random(6) + Has.DecryptHas("5DkX7Bi2zTs=", useHasing: true, "movnildr"));
				Deley(1, 3);
				FindElement(By.XPath(Has.DecryptHas("drMROamQxVSEiuxlDoJocxgLWNMyGhuULthgUUFk9ZJGD04PqXkkbqyPZAv7DsC3HhzPqP6ndRLxHgmsApvrm1Yx1HQGODb3", useHasing: true, "movnildr")))?.Clear();
				Deley(2, 3);
				for (int n = 0; n < 5; n++)
				{
					try
					{
						FindElement(By.CssSelector("button.sqdOP.L3NKy.y3zKF")).Click();
						Deley(1, 4);
					}
					catch
					{
						Deley(2, 4);
						continue;
					}
					break;
				}
				Deley(4, 6);
			}
			else if (ThongSo_Inswfb.rad_hotmail)
			{
				bool flag = false;
				if (rtb_hotmail.Count != 0)
				{
					thongtin.TrangThai = Has.DecryptHas("R+Oqv1v8SHn8qrTqm078k6dGuKF2oIxC1dx/dgdDB1A=", useHasing: true, "g2cuap");
					roll_element(FindElement(By.CssSelector(Has.DecryptHas("gVAJu0uwv9/gAvcWHreoaPWDV7SM6qK5+rYMxAFbfug=", useHasing: true, "trj9io9bv1"))));
					IWebElement webElement2 = FindElement(By.CssSelector(Has.DecryptHas("gVAJu0uwv9/gAvcWHreoaPWDV7SM6qK5+rYMxAFbfug=", useHasing: true, "trj9io9bv1")));
					webElement2.SendKeys(rtb_hotmail[0]);
					Deley(1, 2);
					FindElement(By.XPath(Has.DecryptHas("Aj6abyTgPBsWH53F9KeZBekPcF+4d0q27HZHv3abqvC/t5nMyBFIFeTWhySmOvDACkzZxPi+QAzqzsKGRiMK5RTdRFZ58L6P", useHasing: true, "trj9io9bv1"))).Clear();
					Deley(2, 3);
					roll_element(FindElement(By.CssSelector(Has.DecryptHas("6unmfVUUE3udOeL3h/Fqs/RxCkwD7jRx/IN+zCsKL4A=", useHasing: true, "trj9io9bv1"))));
					FindElement(By.CssSelector(Has.DecryptHas("UurtcBmfr2B4nQ2vZiYQqrCRtxM8U4mdE1F/PnFwhAc=", useHasing: true, "n60haszu"))).Click();
					Deley(4, 6);
					for (int num = 0; num < ((rtb_hotmail.Count > 4) ? 4 : (rtb_hotmail.Count + 1)); num++)
					{
						if (Stop_thread)
						{
							return false;
						}
						string attribute = FindElement(By.CssSelector(Has.DecryptHas("n20Cl9/2rCK3K1ReadWJBKn17SO6YWCYU1GhqOaFU34=", useHasing: true, "n60haszu"))).GetAttribute(Has.DecryptHas("wHdpnSHUkfI=", useHasing: true, "n60haszu"));
						if (rtb_hotmail[0] == attribute)
						{
							thongtin.TrangThai = Has.DecryptHas("rci3VfESrX87w4ia5Mv3wp+Lnf/fSINVybC8BfwS1vc=", useHasing: true, "0v7vis5vpgi7");
							thongTin.Mail = rtb_hotmail[0].Split('|')[0];
							thongTin.Pass_Mail = rtb_hotmail[0].Split('|')[1];
							flag = true;
							break;
						}
						thongtin.TrangThai = $"[{num + 1}/4] Add Hotmail - Fail";
						Deley(1, 3);
						thongtin.TrangThai = $"[{num + 2}/4] Add Hotmail";
						rtb_hotmail.RemoveAt(0);
						webElement2.Clear();
						Thread.Sleep(500);
						webElement2.SendKeys(rtb_hotmail[0]);
						Deley(1, 2);
						FindElement(By.XPath(Has.DecryptHas("y9TG9c9tGqOEP92kRKS74g+HCICdMFLPfkoaCc38RTROsgiySuTqFDkWZ9rlW/u1znG63nu9MjtVjY0zxO+RgLtZGmOSOpDb", useHasing: true, "dkeaq"))).Clear();
						Deley(1, 2);
						for (int num2 = 0; num2 < 5; num2++)
						{
							if (Stop_thread)
							{
								return false;
							}
							try
							{
								FindElement(By.CssSelector("button.sqdOP.L3NKy.y3zKF")).Click();
								Deley(1, 4);
							}
							catch
							{
								Deley(2, 4);
								continue;
							}
							break;
						}
						Deley(3, 4);
					}
					if (flag)
					{
						string text3 = testc_xacnhan(thongTin, thongTin.Mail, thongTin.Pass_Mail);
						if (string.IsNullOrEmpty(text3))
						{
							thongtin.TrangThai = "The authentication process has failed !";
						}
						else
						{
							thongtin.TrangThai = "successful confirmation !";
							driver?.Navigate().GoToUrl(text3);
							Deley(2, 3);
						}
					}
					else
					{
						FindElement(By.CssSelector(Has.DecryptHas("iWiBqVZP7ETCS5cKlhUTQTSDZBU0EIPgiTDKD1uWLos=", useHasing: true, "movnildr")))?.SendKeys(thongTin.User + Has.DecryptHas("Xw2bibPnbw8=", useHasing: true, "movnildr") + random(6) + Has.DecryptHas("5DkX7Bi2zTs=", useHasing: true, "movnildr"));
						Deley(1, 3);
						FindElement(By.XPath(Has.DecryptHas("drMROamQxVSEiuxlDoJocxgLWNMyGhuULthgUUFk9ZJGD04PqXkkbqyPZAv7DsC3HhzPqP6ndRLxHgmsApvrm1Yx1HQGODb3", useHasing: true, "movnildr")))?.Clear();
						Deley(2, 3);
						for (int num3 = 0; num3 < 5; num3++)
						{
							try
							{
								FindElement(By.CssSelector("button.sqdOP.L3NKy.y3zKF")).Click();
								Deley(1, 4);
							}
							catch
							{
								Deley(2, 4);
								continue;
							}
							break;
						}
						Deley(4, 6);
					}
				}
				else
				{
					FindElement(By.CssSelector(Has.DecryptHas("iWiBqVZP7ETCS5cKlhUTQTSDZBU0EIPgiTDKD1uWLos=", useHasing: true, "movnildr")))?.SendKeys(thongTin.User + Has.DecryptHas("Xw2bibPnbw8=", useHasing: true, "movnildr") + random(6) + Has.DecryptHas("5DkX7Bi2zTs=", useHasing: true, "movnildr"));
					Deley(1, 3);
					FindElement(By.XPath(Has.DecryptHas("drMROamQxVSEiuxlDoJocxgLWNMyGhuULthgUUFk9ZJGD04PqXkkbqyPZAv7DsC3HhzPqP6ndRLxHgmsApvrm1Yx1HQGODb3", useHasing: true, "movnildr")))?.Clear();
					Deley(2, 3);
					for (int num4 = 0; num4 < 5; num4++)
					{
						try
						{
							FindElement(By.CssSelector("button.sqdOP.L3NKy.y3zKF")).Click();
							Deley(1, 4);
						}
						catch
						{
							Deley(2, 4);
							continue;
						}
						break;
					}
					Deley(4, 6);
				}
			}
			else if (ThongSo_Inswfb.rad_domain)
			{
				if (!string.IsNullOrEmpty(ThongSo_Inswfb.txt_domain) && !string.IsNullOrEmpty(ThongSo_Inswfb.txt_hotmail) && !string.IsNullOrEmpty(ThongSo_Inswfb.txt_PassHotmail))
				{
					bool flag2 = false;
					string text4 = thongTin.User + ThongSo_Inswfb.txt_domain;
					thongtin.TrangThai = "Delete Phone - Add Mail Domain ... ";
					driver?.Navigate().Refresh();
					Deley(2, 3);
					for (int num5 = 0; num5 < 3; num5++)
					{
						roll_element(FindElement(By.CssSelector("input#pepEmail.JLJ-B.zyHYP")));
						IWebElement webElement3 = FindElement(By.CssSelector("input#pepEmail.JLJ-B.zyHYP"));
						webElement3.Clear();
						Thread.Sleep(500);
						webElement3.SendKeys(text4);
						Deley(1, 2);
						FindElement(By.XPath("//*[@id=\"pepPhone Number\"]"))?.Clear();
						Deley(2, 3);
						ReadOnlyCollection<IWebElement> readOnlyCollection = _FindElements(By.CssSelector("button.sqdOP.L3NKy.y3zKF"));
						if (readOnlyCollection.Count == 1)
						{
							FindElements(By.CssSelector("button.sqdOP.L3NKy.y3zKF"), 0)?.Click();
						}
						else
						{
							FindElements(By.CssSelector("button.sqdOP.L3NKy.y3zKF"), 1)?.Click();
						}
						Deley(4, 6);
						string attribute2 = FindElement(By.CssSelector("input#pepEmail.JLJ-B.zyHYP")).GetAttribute("value");
						if (text4 == attribute2)
						{
							thongtin.TrangThai = " Add Hotmail - Success ! ";
							thongTin.Mail = text4;
							flag2 = true;
							break;
						}
						thongtin.TrangThai = $"[{num5 + 1}/4] Add Hotmail - Fail";
						driver?.Navigate().Refresh();
						Deley(2, 3);
						thongtin.TrangThai = $"[{num5 + 2}/4] Add Hotmail";
					}
					if (flag2)
					{
						string text5 = testc_xacnhan(thongTin, ThongSo_Inswfb.txt_hotmail, ThongSo_Inswfb.txt_PassHotmail);
						if (string.IsNullOrEmpty(text5))
						{
							thongtin.TrangThai = "The authentication process has failed !";
						}
						else
						{
							thongtin.TrangThai = "successful confirmation !";
							driver?.Navigate().GoToUrl(text5);
							Deley(2, 3);
						}
					}
					else
					{
						FindElement(By.CssSelector(Has.DecryptHas("iWiBqVZP7ETCS5cKlhUTQTSDZBU0EIPgiTDKD1uWLos=", useHasing: true, "movnildr")))?.SendKeys(thongTin.User + Has.DecryptHas("Xw2bibPnbw8=", useHasing: true, "movnildr") + random(6) + Has.DecryptHas("5DkX7Bi2zTs=", useHasing: true, "movnildr"));
						Deley(1, 3);
						FindElement(By.XPath(Has.DecryptHas("drMROamQxVSEiuxlDoJocxgLWNMyGhuULthgUUFk9ZJGD04PqXkkbqyPZAv7DsC3HhzPqP6ndRLxHgmsApvrm1Yx1HQGODb3", useHasing: true, "movnildr")))?.Clear();
						Deley(2, 3);
						for (int num6 = 0; num6 < 5; num6++)
						{
							try
							{
								FindElement(By.CssSelector("button.sqdOP.L3NKy.y3zKF")).Click();
								Deley(1, 4);
							}
							catch
							{
								Deley(2, 4);
								continue;
							}
							break;
						}
						Deley(4, 6);
					}
				}
				else
				{
					FindElement(By.CssSelector(Has.DecryptHas("iWiBqVZP7ETCS5cKlhUTQTSDZBU0EIPgiTDKD1uWLos=", useHasing: true, "movnildr")))?.SendKeys(thongTin.User + Has.DecryptHas("Xw2bibPnbw8=", useHasing: true, "movnildr") + random(6) + Has.DecryptHas("5DkX7Bi2zTs=", useHasing: true, "movnildr"));
					Deley(1, 3);
					FindElement(By.XPath(Has.DecryptHas("drMROamQxVSEiuxlDoJocxgLWNMyGhuULthgUUFk9ZJGD04PqXkkbqyPZAv7DsC3HhzPqP6ndRLxHgmsApvrm1Yx1HQGODb3", useHasing: true, "movnildr")))?.Clear();
					Deley(2, 3);
					for (int num7 = 0; num7 < 5; num7++)
					{
						try
						{
							FindElement(By.CssSelector("button.sqdOP.L3NKy.y3zKF")).Click();
							Deley(1, 4);
						}
						catch
						{
							Deley(2, 4);
							continue;
						}
						break;
					}
					Deley(4, 6);
				}
			}
			if (Stop_thread)
			{
				return false;
			}
			if (ThongSo_Inswfb.cb_UpAvt && list.Count != 0)
			{
				if (!driver.Url.Contains(text + Has.DeCryptWithKey("dQ3M1h3EKUBvJ8gt5h1acg==", "4f83zrr144z17")))
				{
					driver?.Navigate().GoToUrl(text + Has.DeCryptWithKey("dQ3M1h3EKUBvJ8gt5h1acg==", "4f83zrr144z17"));
					Deley(1, 3);
				}
				FindElements(By.CssSelector(Has.DecryptHas("yL3KanKU4EZ3Pgdb711hmQ==", useHasing: true, "wait2m1q3s9")), 1)?.SendKeys(list[r.Next(0, list.Count)]);
				Deley(2, 5);
				Thaotac_Click(By.CssSelector(Has.DecryptHas("bvH4p7NCk92wQl8SvfZmlw==", useHasing: true, "9zo8am7q2p2bpn")));
				Deley(5, 10);
				Thaotac_Click(By.CssSelector("div.RnEpo:nth-child(26) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > button:nth-child(1)"));
				Deley(5, 10);
			}
			driver?.Navigate().GoToUrl(Has.DeCryptWithKey("lEZuNb6+JjThjpxsO3YW3CHKNQ0yiOj5KruAW1c26SdhLEKtcZCEaW2YSB2ZjRTh", "fgor36"));
			Deley(2, 4);
			string cssSelectorToFind = Has.DeCryptWithKey("vC+Bx1jBf9YLc8daUqBDvSv+XhRJoEtQwJwElGLxco6lPKaIJdd3AbUv4KKhgi/Dmtq9hpmIddfg+zAuyusasiFuDYp21tVmKBfnh70C+39EtW5YqweZxY1AeVTlCRL77506ukEE5jePiBFuRQgww1q9zpPKaEIvExHLu6AJ+t6lPKaIJdd3AS1lqmCi03xA", "fgor36");
			string cssSelectorToFind2 = Has.DeCryptWithKey("vC+Bx1jBf9YLc8daUqBDvSv+XhRJoEtQSFJcwXFldOelPKaIJdd3AbUv4KKhgi/Dmtq9hpmIddfg+zAuyusasiFuDYp21tVmKBfnh70C+39EtW5YqweZxY1AeVTlCRL77506ukEE5jePiBFuRQgww1q9zpPKaEIvExHLu6AJ+t6lPKaIJdd3AS1lqmCi03xA", "fgor36");
			if (check_element(By.CssSelector(cssSelectorToFind)))
			{
				if (FindElement(By.CssSelector(cssSelectorToFind))?.Text == Has.DeCryptWithKey("ddsbdMwqCsRraPpYjslu/Q==", "fgor36"))
				{
					Thaotac_Click(By.CssSelector(cssSelectorToFind));
				}
				else
				{
					Thaotac_Click(By.CssSelector(cssSelectorToFind2));
				}
				Deley(2, 4);
				Thaotac_Click(By.CssSelector(Has.DeCryptWithKey("WSGRv/ZIcgndfHQKutJ9Fw==", "fgor36")));
				Deley(2, 4);
				Thaotac_Click(By.CssSelector(Has.DeCryptWithKey("oFGL4R3idI02udzsJpJNSQ==", "fgor36")));
				Deley(2, 4);
				Thaotac_Click(By.CssSelector(Has.DeCryptWithKey("gRo3FdhIqMxwStBwnnZswA==", "fgor36")));
				Deley(2, 4);
				Thaotac_Click(By.CssSelector(Has.DeCryptWithKey("jpfLGAfTJEMUo5ds/FcoBo8eR/wsX8S6JvAD47V1+eE=", "s5v6b63hd0")));
				Deley(2, 4);
			}
			if (Stop_thread)
			{
				return false;
			}
			if (ThongSo_Inswfb.cb_LockAcc)
			{
				thongTin.TrangThai = Has.DecryptHas("Sg2v+PEKjJs5Ddl2ig/YTA==", useHasing: true, "0rjr3zg701av");
				try
				{
					int num8 = 30;
					driver?.Navigate()?.GoToUrl(Has.DecryptHas("cxb87RSUdGUMOtzzg142uJEYkkXUT01j9q8FF2yDIgjCZxs8MZtvRxH+ZXPB8iXR/o2wmQtuw3zUI3KzrmxdSw==", useHasing: true, "0rjr3zg701av"));
					Deley(2, 5);
					roll_element(FindElement(By.CssSelector(Has.DecryptHas("pMq5szRxri6KinHsTzfHMCJ2ah+PrMbGjirGI5TcBGWgjIg6Bgn4QQ==", useHasing: true, "0rjr3zg701av"))));
					SelectElement selectElement = new SelectElement(driver.FindElement(By.CssSelector(Has.DecryptHas("pMq5szRxri6KinHsTzfHMCJ2ah+PrMbGjirGI5TcBGWgjIg6Bgn4QQ==", useHasing: true, "0rjr3zg701av"))));
					selectElement.SelectByIndex(new Random().Next(2, 7));
					Deley(1, 2);
					roll_element(FindElement(By.Name(Has.DecryptHas("UutQxddhtwJXP4fcrCBjRw==", useHasing: true, "0rjr3zg701av"))));
					driver?.FindElement(By.Name(Has.DecryptHas("UutQxddhtwJXP4fcrCBjRw==", useHasing: true, "0rjr3zg701av")))?.SendKeys(thongTin.Pass);
					Deley(1, 2);
					roll_element(FindElement(By.CssSelector(Has.DecryptHas("JcTe9fga6oMP8/Dqf/UHNIMtoF7m3EU3Vz+H3KwgY0c=", useHasing: true, "0rjr3zg701av"))));
					driver?.FindElement(By.CssSelector(Has.DecryptHas("RHUrl1FUzNORpnqK/+XotZUmG4AsHqWhU2zwH/X4O78=", useHasing: true, "dgp6by")))?.Click();
					Deley(1, 2);
					driver?.FindElements(By.CssSelector(Has.DecryptHas("RHUrl1FUzNORpnqK/+XotZUmG4AsHqWhU2zwH/X4O78=", useHasing: true, "dgp6by")))[1]?.Click();
					Deley(3, 5);
					while (!driver.Url.Contains(Has.DecryptHas("yRkvJ5HMXKQ=", useHasing: true, "dgp6by")))
					{
						num8--;
						Thread.Sleep(1000);
						if (driver.PageSource.Contains(Has.DecryptHas("6whpEqAeOCM=", useHasing: true, "dgp6by")) || num8 <= 0)
						{
							thongTin.TrangThai = Has.DecryptHas("jZNzoKMsOXwLvSrXj7w73lFUqs96rq/l", useHasing: true, "dgp6by");
							return true;
						}
					}
				}
				catch
				{
				}
				thongTin.TrangThai = Has.DecryptHas("BzJck64nhuM8gTKeaSzm3IV/npkp1wKk", useHasing: true, "kjdsa1i");
			}
			else
			{
				driver.Manage().Cookies.DeleteAllCookies();
				Deley(2, 3);
				driver?.Navigate().GoToUrl(text);
				Deley(2, 3);
				Thaotac_Click(By.CssSelector(Has.DecryptHas("NknEEANPY5YBy/4pQvTuuUmTv2UASjlKRXt556NWERE=", useHasing: true, "dxk5j")));
				Deley(2, 3);
				Thaotac_Click(By.CssSelector(Has.DecryptHas("yGugdksgMikcsSTOi67YZuOvdy7BfrOORK7Ky2ApQHfPBsWmt6XBpF0NkJlbZWV5+QP9PTwKWzDh76/4eoHBOr2d6yz6Eifz", useHasing: true, "dxk5j")));
				Deley(3, 4);
			}
			thongTin.Color = 1;
			thongTin.ID = Regex.Match(thongTin.cookie, "ds_user_id=(.*?);").Groups[1].Value;
			thongTin.TinhTrang = Has.DeCryptWithKey("HD2ByGyykPE=", "frtqx1");
			if (!tt_kk._key.Contains(Has.DeCryptWithKey("rmBw2h5PkyU=", "frtqx1")))
			{
				thongTin.Pass = Has.DeCryptWithKey("1wxM4cPnEHY=", "frtqx1");
			}
			list2.Add(thongTin);
			sqlite.Save_Data(list2);
			Form1.remote.Load_dgvacc();
			return true;
		}

		public bool RuInsw()
		{
			int num = 0;
			thongtin.TrangThai = Has.DecryptHas("7T2MeC7jTClLW2dk38Vhx3kxBz2xz4ue", useHasing: true, "havvrlg");
			Inswfb.remote.Change_Row(thongtin);
			if (Url())
			{
				Change_Total();
				Deley(2, 4);
				if (login())
				{
					Deley(2, 4);
					for (int i = 0; i < ThongSo_Inswfb.num_ACC; i++)
					{
						if (Stop_thread)
						{
							break;
						}
						thongtin.TrangThai = $"[{i + 1}/{ThongSo_Inswfb.num_ACC}] Instagram sign up ...";
						if (register())
						{
							thongtin.TrangThai = $"[{i + 1}/{ThongSo_Inswfb.num_ACC}] Instagram sign up - Success !";
						}
						else
						{
							num++;
							thongtin.TrangThai = $"[{i + 1}/{ThongSo_Inswfb.num_ACC}] Instagram sign up - Fail !";
							if (num == 2)
							{
								break;
							}
						}
						Deley(2, 5);
					}
					thongtin.TrangThai = Has.DecryptHas("w4pBOJzX2qk=", useHasing: true, "8sbyyq3ypwh5ns");
				}
			}
			sqlite.Update_Data_FB(thongtin);
			driver?.Quit();
			return true;
		}

		private string testc_xacnhan(ThongTin tt, string hotmail, string pass_mail)
		{
			string result = Has.DecryptHas("ouVamdhAh2s=", useHasing: true, "269crjcfxi5q");
			if (string.IsNullOrEmpty(hotmail) || string.IsNullOrEmpty(pass_mail))
			{
				return result;
			}
			try
			{
				int num = 40;
				while (num > 0)
				{
					num--;
					Thread.Sleep(600);
					thongtin.TrangThai = $"wait for confirmation => {num} s";
					ImapClient imapClient = new ImapClient(Has.DecryptHas("uJqjUUYESMW3eBciPsSKrkwsTiDAkpVD", useHasing: true, "u2zql1rrvq"), hotmail, pass_mail, AuthMethods.Login, 993, secure: true);
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
						if (now.Day == date.Day && now.Month == date.Month && now.Year == date.Year && now.Hour == date.Hour && now.Minute <= date.Minute + 5 && lazy.Value.Subject.Contains(Has.DecryptHas("nEFxqHLFcRAahUOU6NilBuRECVLSrP2oysjDc8xST4h5i/kEi0Y1kBNs0+piUhpe", useHasing: true, "u2zql1rrvq")) && lazy.Value.Body.Contains(tt.User))
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
	}
}
