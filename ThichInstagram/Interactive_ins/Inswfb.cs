using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interactive_ins.Properties;
using Newtonsoft.Json.Linq;

namespace Interactive_ins
{
	public class Inswfb : Form
	{
		public static Inswfb remote;

		private IContainer components = null;

		private Button btn_setting;

		private Button btnPause;

		private Button btnStart;

		private DataGridView dgv_acc;

		private Button btn_addfb;

		private OpenFileDialog openFileDialog1;

		private ContextMenuStrip ctxmain;

		private ToolStripMenuItem ctx_Delete;

		private ToolStripMenuItem ctx_DeleteAll;

		private Label lb_notlive;

		private Label label1;

		private Label lb_Live;

		private Label label3;

		private ToolStripMenuItem toolStripMenuItem4;

		private ToolStripMenuItem ctx_Save_Cookie;

		private ToolStripMenuItem ctx_Save_UserPass;

		private ToolStripMenuItem ctx_Save_UserPassCookie;

		private ToolStripMenuItem ctx_Save_UserPassCookie2FA;

		private ToolStripMenuItem ctx_chon;

		private ToolStripMenuItem ctx_Chon_BoiDen;

		private ToolStripMenuItem ctx_Chon_All;

		private ToolStripMenuItem ctx_BoChon;

		private ToolStripMenuItem ctx_BoChon_BoiDen;

		private ToolStripMenuItem ctx_BoChon_All;

		private SaveFileDialog saveFileDialog1;

		private DataGridViewTextBoxColumn STT;

		private DataGridViewTextBoxColumn User;

		private DataGridViewTextBoxColumn Pass;

		private DataGridViewTextBoxColumn Cookie;

		private DataGridViewTextBoxColumn _2FA;

		private DataGridViewTextBoxColumn proxy;

		private DataGridViewTextBoxColumn TrangThai;

		private DataGridViewTextBoxColumn Khoa_ID;

		private DataGridViewTextBoxColumn _Color;

		private DataGridViewCheckBoxColumn checkselec;

		private ToolStripMenuItem loadToolStripMenuItem;

		private JSON_Settings CauHinhDoiIP { get; set; }

		public Inswfb()
		{
			InitializeComponent();
			remote = this;
		}

		private void Load_Data_dgv()
		{
			SQLite sQLite = new SQLite();
			sQLite.Check_table();
			Load_dgvacc();
		}

		public void Change_Row(ThongTin thongtin)
		{
			dgv_acc.BeginInvoke((MethodInvoker)delegate
			{
				Color color = default(Color);
				color = thongtin.Color switch
				{
					1 => Color.Green, 
					0 => Color.Red, 
					_ => Color.Black, 
				};
				try
				{
					dgv_acc.Rows[thongtin.Row_Select].DefaultCellStyle.ForeColor = color;
					dgv_acc.Rows[thongtin.Row_Select].Cells[Has.DecryptHas("2wfQ3jx4J7w=", useHasing: true, "bs9jm")].Value = thongtin.User;
					dgv_acc.Rows[thongtin.Row_Select].Cells[Has.DecryptHas("MjRNTD+YWcw=", useHasing: true, "bs9jm")].Value = thongtin.Pass;
					dgv_acc.Rows[thongtin.Row_Select].Cells[Has.DecryptHas("knqMbcG5VF0=", useHasing: true, "bs9jm")].Value = thongtin.cookie;
					dgv_acc.Rows[thongtin.Row_Select].Cells[Has.DecryptHas("4Rc6pCB/l+4=", useHasing: true, "bs9jm")].Value = thongtin.proxy;
					dgv_acc.Rows[thongtin.Row_Select].Cells[Has.DecryptHas("NntwqDv3aQ8=", useHasing: true, "bs9jm")].Value = thongtin.Color;
					dgv_acc.Rows[thongtin.Row_Select].Cells[Has.DecryptHas("WXUQxe5B/9qdWznnbzAL4Q==", useHasing: true, "bs9jm")].Value = thongtin.TrangThai;
				}
				catch
				{
				}
			});
		}

		public void Load_dgvacc()
		{
			SQLite sQLite = new SQLite();
			DataTable dataTable = sQLite.LoadData_fb();
			dgv_acc.Invoke((MethodInvoker)delegate
			{
				dgv_acc.Rows.Clear();
			});
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow row = dataTable.Rows[i];
				Color color = default(Color);
				switch ((int)row["Color"])
				{
				case 1:
					color = Color.Green;
					break;
				case 0:
					color = Color.Red;
					break;
				default:
					color = Color.Black;
					break;
				}
				bool checkselec = (((int)row["checkselec"] == 1) ? true : false);
				dgv_acc.Invoke((MethodInvoker)delegate
				{
					dgv_acc.Rows.Add(dgv_acc.RowCount + 1, row["User"], row["Pass"], row["Cookie"], row["_2FA"], row["proxy"], row["TrangThai"], row["Khoa_ID"], row["Color"], checkselec);
					dgv_acc.Rows[i].DefaultCellStyle.ForeColor = color;
				});
			}
			dgv_acc.EndEdit();
			List<ThongTin> So_live = sQLite.Select_Data_checkselec_FB(enum_thongtin.Color.ToString(), 1.ToString());
			List<ThongTin> So_Notlive = sQLite.Select_Data_checkselec_FB(enum_thongtin.Color.ToString(), 0.ToString());
			dgv_acc.Invoke((MethodInvoker)delegate
			{
				lb_Live.Text = So_live.Count.ToString();
				lb_notlive.Text = So_Notlive.Count.ToString();
			});
		}

		public string CheckLiveWall(string uid)
		{
			RequestXNet requestXNet = new RequestXNet(Has.DecryptHas("2VlQrazWfiI=", useHasing: true, "mj02vuc5"));
			try
			{
				string text = requestXNet.RequestGet(Has.DecryptHas("eSHGqa1tZInrTE6xiqh7Y4bbdfM3VARrqqDUmO0HeVU=", useHasing: true, "mj02vuc5") + uid + Has.DecryptHas("9IvudAw7dAfnNMxtQnNYTqcQCym/qlOA", useHasing: true, "mj02vuc5"));
				if (!string.IsNullOrEmpty(text))
				{
					if (text.Contains(Has.DecryptHas("UWzPmrgK30s=", useHasing: true, "mj02vuc5")) && text.Contains(Has.DecryptHas("pwPBj+giOvo=", useHasing: true, "mj02vuc5")))
					{
						return Has.DecryptHas("elGcpIpTddQ=", useHasing: true, "mj02vuc5");
					}
					return Has.DecryptHas("Wx5w0GUyRKw=", useHasing: true, "mj02vuc5");
				}
			}
			catch
			{
			}
			return Has.DecryptHas("STzbFQnsRJU=", useHasing: true, "y86h4ti6osp");
		}

		public string CheckInfoUsingUid(string uid)
		{
			_RequestHttp requestHttp = new _RequestHttp();
			try
			{
				string text = "";
				string text2 = "";
				string text3 = "";
				string text4 = "";
				string text5 = "";
				string text6 = "";
				string text7 = "";
				string text8 = requestHttp.RequestPost("https://www.facebook.com/api/graphql", "q=user(" + uid + "){friends{count},groups{count},id,name,gender,birthday,email_addresses,username}&access_token=6628568379|c1e620fa708a1d5696fb991c1bde5662");
				if (!string.IsNullOrEmpty(text8))
				{
					JObject jObject = JObject.Parse(text8);
					if (string.IsNullOrEmpty(jObject[uid]!.ToString()))
					{
						return "0|";
					}
					if (jObject[uid]!["name"] != null)
					{
						if (jObject[uid]!["friends"]!["count"] != null)
						{
							text = jObject[uid]!["friends"]!["count"]!.ToString();
						}
						if (jObject[uid]!["groups"]!["count"] != null)
						{
							text2 = jObject[uid]!["groups"]!["count"]!.ToString();
						}
						if (jObject[uid]!["name"] != null)
						{
							text3 = jObject[uid]!["name"]!.ToString();
						}
						if (jObject[uid]!["gender"] != null)
						{
							text4 = jObject[uid]!["gender"]!.ToString();
						}
						if (jObject[uid]!["username"] != null)
						{
							text5 = jObject[uid]!["username"]!.ToString();
						}
						if (jObject[uid]!["birthday"] != null)
						{
							text6 = jObject[uid]!["birthday"]!.ToString();
						}
						if (jObject[uid]!["email_addresses"]!.ToString() != "[]")
						{
							text7 = jObject[uid]!["email_addresses"]!.ToString();
						}
						return "1|" + text5 + "|" + text3 + "|" + text4 + "|" + text6 + "|" + text + "|" + text2 + "|" + text7;
					}
				}
			}
			catch (Exception)
			{
			}
			return "2|";
		}

		private new_IP changeIP(API_Tinsoft tins, ThongTin thongTin)
		{
			check_ip check_ip2 = tins.checkip();
			if (req._req == 0)
			{
				return tins.NewIP();
			}
			if (!string.IsNullOrEmpty(check_ip2.next_change) && int.Parse(check_ip2.next_change) > 0)
			{
				int num = int.Parse(check_ip2.next_change) + 5;
				while (num > 0 && !Stop.stop_FB)
				{
					num--;
					Thread.Sleep(1000);
					thongTin.TrangThai = "Reset IP : " + num + " s";
					Change_Row(thongTin);
				}
				return tins.NewIP();
			}
			return tins.NewIP();
		}

		private bool ChangeIP_Xproxy(string proxy)
		{
			API_Xproxy aPI_Xproxy = new API_Xproxy(ThongSo_CauHinhDoiIP.txt_Service_Url, proxy);
			return aPI_Xproxy.changeip_xproxy();
		}

		private Minproxy changeIP_Min(API_Minproxy API_Minproxy, ThongTin thongTin)
		{
			Minproxy minproxy = ((ThongSo_CauHinhDoiIP.cbb_SelecTypeIP == 1) ? API_Minproxy.CheckIP_V6() : API_Minproxy.CheckIP_dancu());
			if (req._req == 0)
			{
				return null;
			}
			if (minproxy.data.next_request > 0)
			{
				int num = minproxy.data.next_request + 5;
				while (num > 0 && !Stop.stop)
				{
					num--;
					Thread.Sleep(1000);
					thongTin.TrangThai = "Reset IP : " + num + " s";
					Change_Row(thongTin);
				}
				return (ThongSo_CauHinhDoiIP.cbb_SelecTypeIP == 1) ? API_Minproxy.NewIP_V6() : API_Minproxy.NewIP_dancu();
			}
			return (ThongSo_CauHinhDoiIP.cbb_SelecTypeIP == 1) ? API_Minproxy.NewIP_V6() : API_Minproxy.NewIP_dancu();
		}

		private string changeIP_shoplike(ShopLike shoplike, bool check, ThongTin thongtin = null)
		{
			string text = "";
			new_IP_Shoplike new_IP_Shoplike2 = shoplike.NewIP();
			if (new_IP_Shoplike2 == null)
			{
				return null;
			}
			if (new_IP_Shoplike2.status == "error")
			{
				Regex regex = new Regex("\\d");
				Match match = regex.Match(new_IP_Shoplike2.mess);
				do
				{
					text += match.ToString();
					match = match.NextMatch();
				}
				while (match != Match.Empty);
				if (text == "")
				{
					return null;
				}
				int num = int.Parse(text) + 2;
				if (check)
				{
					MessageBox.Show("Waiting Get proxy : " + num + " s");
				}
				while (num > 0 && !Stop.stop_FB)
				{
					num--;
					Thread.Sleep(1000);
					if (!check)
					{
						thongtin.TrangThai = Has.DecryptHas("0gzQDXIrlpQr22NgLWQzpQ==", useHasing: true, "qht25xx1e") + num + Has.DecryptHas("Im6khsSdjZY=", useHasing: true, "qht25xx1e");
						Change_Row(thongtin);
					}
				}
				return shoplike.NewIP()?.data?.proxy;
			}
			if (new_IP_Shoplike2.status == Has.DecryptHas("6JOmpnxVje8=", useHasing: true, "qht25xx1e"))
			{
				return new_IP_Shoplike2.data?.proxy;
			}
			return null;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			Poin.dem = 0;
			Stop.stop_FB = false;
			Form1.remote.Load_CauHinhDoiIP();
			Load_setting();
			SQLite sQLite = new SQLite();
			ChangeIP changip = new ChangeIP();
			int dem_thread = 0;
			List<ThongTin> L_Thongtin = sQLite.Select_Data_checkselec_FB(enum_thongtin.checkselec.ToString(), 1.ToString());
			btnStart.Enabled = false;
			btnPause.Enabled = true;
			Task task = new Task(delegate
			{
				if (ThongSo_CauHinhDoiIP.rad_ChangIP_Proxy)
				{
					List<Task> list = new List<Task>();
					foreach (ThongTin item7 in L_Thongtin)
					{
						ThongTin item6 = item7;
						if (Stop.stop_FB)
						{
							break;
						}
						if (string.IsNullOrEmpty(item6.proxy))
						{
							item6.TrangThai = "No Proxy !";
							Change_Row(item6);
						}
						else
						{
							dem_thread++;
							Task task2 = new Task(delegate
							{
								SLM sLM6 = new SLM(item6, Use_Proxy: true);
								sLM6.RuInsw();
							});
							task2.Start();
							list.Add(task2);
							Deley(5, 10);
							if (!Stop.stop_FB && dem_thread == ThongSo_CauHinhDoiIP.num_Thread_ChangeIP)
							{
								Task.WaitAll(list.ToArray());
								list.Clear();
								dem_thread = 0;
							}
						}
					}
					Task.WaitAll(list.ToArray());
				}
				else if (ThongSo_CauHinhDoiIP.rad_ChangIP_Tinsoft)
				{
					int dem_key = -1;
					int dem_acc4 = -1;
					int time4 = new Random().Next(10, 20);
					List<Task> L_Task4 = new List<Task>();
					foreach (string item8 in ThongSo_CauHinhDoiIP.rtb_KeyTinsoft)
					{
						if (Stop.stop_FB || dem_key == L_Thongtin.Count)
						{
							break;
						}
						int num = dem_key;
						dem_key = num + 1;
						string item5 = item8;
						Task task3 = new Task(delegate
						{
							string proxy3 = "";
							API_Tinsoft aPI_Tinsoft = new API_Tinsoft(item5);
							check_ip check_ip2 = aPI_Tinsoft.checkip();
							if (check_ip2 == null)
							{
								MessageBox.Show("check key tinsoft ( kiểm tra lại key tinsoft ) ! \nKey : " + item5);
								Stop.stop_FB = true;
							}
							if (check_ip2.success && check_ip2.next_change == "0")
							{
								proxy3 = aPI_Tinsoft.NewIP().proxy;
							}
							else if (check_ip2.success)
							{
								int num18 = int.Parse(check_ip2.next_change) + 5;
								while (!Stop.stop_FB && num18 > 0 && !Stop.stop_FB)
								{
									num18--;
									Thread.Sleep(1000);
									try
									{
										L_Thongtin[dem_key].TrangThai = Has.DecryptHas("rAyzDy1/omGsW0NnHovm24ohUfxl8jJi", useHasing: true, "rcyylfi4v") + num18 + Has.DecryptHas("NEB7EJcWh4U=", useHasing: true, "rcyylfi4v");
										Change_Row(L_Thongtin[dem_key]);
									}
									catch
									{
										break;
									}
								}
								proxy3 = aPI_Tinsoft.NewIP()?.proxy;
							}
							else
							{
								proxy3 = aPI_Tinsoft.NewIP()?.proxy;
							}
							if (string.IsNullOrEmpty(proxy3))
							{
								MessageBox.Show(Has.DecryptHas("gpFK+zxbzvYv2ZmGBzC32csaQtNctho771ZbWkLKUDhtSNZ+7ohNJO8029kYERl9VPoCIesxZ2HaIDUqR+DxaQ==", useHasing: true, "rcyylfi4v") + item5);
								Stop.stop_FB = true;
							}
							while (dem_thread < L_Thongtin.Count && !Stop.stop_FB)
							{
								List<Task> list6 = new List<Task>();
								for (int l = 0; l < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; l++)
								{
									if (Stop.stop_FB)
									{
										break;
									}
									if (dem_thread >= L_Thongtin.Count)
									{
										break;
									}
									int num19 = dem_thread;
									dem_thread = num19 + 1;
									Task task11 = new Task(delegate
									{
										int num21 = dem_acc4;
										dem_acc4 = num21 + 1;
										L_Thongtin[dem_acc4].proxy = proxy3;
										SLM sLM5 = new SLM(L_Thongtin[dem_acc4], Use_Proxy: true);
										sLM5.RuInsw();
									});
									task11.Start();
									list6.Add(task11);
									L_Task4.Add(task11);
									int num20 = time4;
									while (num20 > 0)
									{
										num20--;
										Thread.Sleep(1000);
										try
										{
											L_Thongtin[dem_acc4 + 1].TrangThai = Has.DeCryptWithKey("zfZNRvMmgNmtq6U7czK+qg==", "m6lgupd1") + num20 + Has.DeCryptWithKey("JdRv5vKJ4e8=", "m6lgupd1");
											Change_Row(L_Thongtin[dem_acc4 + 1]);
										}
										catch
										{
											break;
										}
									}
								}
								Task.WaitAll(list6.ToArray());
								if (!Stop.stop_FB && dem_acc4 + 1 != L_Thongtin.Count)
								{
									proxy3 = changeIP(aPI_Tinsoft, L_Thongtin[dem_acc4])?.proxy;
									if (string.IsNullOrEmpty(proxy3))
									{
										L_Thongtin[dem_acc4].TrangThai = Has.DeCryptWithKey("fj6Y0z3EuSKrIVmb/2hrW2L7HfnARKYl6XV4fijlIms=", "gk2nmt") + item5;
										Change_Row(L_Thongtin[dem_acc4]);
										break;
									}
								}
							}
						});
						task3.Start();
						L_Task4.Add(task3);
						Thread.Sleep(TimeSpan.FromSeconds(time4 * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP));
						int num2 = time4;
						while (!Stop.stop_FB && num2 > 0 && dem_acc4 + 1 != L_Thongtin.Count)
						{
							num2--;
							Thread.Sleep(1000);
							try
							{
								L_Thongtin[dem_acc4 + 1].TrangThai = Has.DeCryptWithKey("ySEGkrxIGfNd4EAGz/mV1w==", "gk2nmt") + num2 + Has.DeCryptWithKey("O8nmKszusTQ=", "gk2nmt");
								Change_Row(L_Thongtin[dem_acc4 + 1]);
							}
							catch
							{
								goto IL_0330;
							}
						}
						IL_0330:;
					}
					Task.WaitAll(L_Task4.ToArray());
				}
				else if (ThongSo_CauHinhDoiIP.rad_ChangIP_ShopLike)
				{
					int num3 = 0;
					int dem_acc3 = -1;
					int time3 = new Random().Next(10, 20);
					List<Task> L_Task3 = new List<Task>();
					foreach (string item9 in ThongSo_CauHinhDoiIP.rtb_KeyShoplike)
					{
						if (Stop.stop_FB || num3 == L_Thongtin.Count)
						{
							break;
						}
						num3++;
						string item4 = item9;
						Task task4 = new Task(delegate
						{
							ShopLike shoplike = new ShopLike(item4);
							string proxy2 = changeIP_shoplike(shoplike, check: true);
							if (string.IsNullOrEmpty(proxy2))
							{
								MessageBox.Show("Lấy proxy thất bại (Proxy fetch failed) ! \nKey : " + item4);
								Stop.stop_FB = true;
							}
							while (dem_thread < L_Thongtin.Count && !Stop.stop_FB)
							{
								List<Task> list5 = new List<Task>();
								for (int k = 0; k < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; k++)
								{
									if (Stop.stop_FB)
									{
										break;
									}
									if (dem_thread >= L_Thongtin.Count)
									{
										break;
									}
									int num15 = dem_thread;
									dem_thread = num15 + 1;
									Task task10 = new Task(delegate
									{
										int num17 = dem_acc3;
										dem_acc3 = num17 + 1;
										L_Thongtin[dem_acc3].proxy = proxy2;
										SLM sLM4 = new SLM(L_Thongtin[dem_acc3], Use_Proxy: true);
										sLM4.RuInsw();
									});
									task10.Start();
									list5.Add(task10);
									L_Task3.Add(task10);
									int num16 = time3;
									while (!Stop.stop_FB && num16 > 0 && !Stop.stop_FB)
									{
										num16--;
										Thread.Sleep(1000);
										try
										{
											L_Thongtin[dem_acc3 + 1].TrangThai = "Waiting Run => " + num16 + " s";
											Change_Row(L_Thongtin[dem_acc3 + 1]);
										}
										catch
										{
											break;
										}
									}
								}
								Task.WaitAll(list5.ToArray());
								if (!Stop.stop_FB && dem_acc3 + 1 != L_Thongtin.Count)
								{
									proxy2 = changeIP_shoplike(shoplike, check: false, L_Thongtin[dem_acc3]);
									if (string.IsNullOrEmpty(proxy2))
									{
										L_Thongtin[dem_acc3].TrangThai = "Error getting proxy key => " + item4;
										Change_Row(L_Thongtin[dem_acc3]);
										break;
									}
								}
							}
						});
						task4.Start();
						L_Task3.Add(task4);
						Thread.Sleep(TimeSpan.FromSeconds(time3 * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP));
						int num4 = time3;
						while (!Stop.stop_FB && num4 > 0 && dem_acc3 + 1 != L_Thongtin.Count)
						{
							num4--;
							Thread.Sleep(1000);
							try
							{
								L_Thongtin[dem_acc3 + 1].TrangThai = Has.DeCryptWithKey("I6FhAAvLoJSAb4nEK+rxVg==", "drr0tj") + num4 + Has.DeCryptWithKey("bvFH2CJ3H5g=", "drr0tj");
								Change_Row(L_Thongtin[dem_acc3 + 1]);
							}
							catch
							{
								goto IL_052f;
							}
						}
						IL_052f:;
					}
					Task.WaitAll(L_Task3.ToArray());
				}
				else if (ThongSo_CauHinhDoiIP.rad_ChangIP_Xproxy)
				{
					int num5 = -1;
					int dem_acc2 = -1;
					int time2 = new Random().Next(10, 20);
					List<Task> L_Task2 = new List<Task>();
					foreach (string item10 in ThongSo_CauHinhDoiIP.rtb_Xproxy_Proxy)
					{
						num5++;
						if (Stop.stop_FB || num5 == L_Thongtin.Count)
						{
							break;
						}
						string item3 = (ThongSo_CauHinhDoiIP.rad_Xproxy_Sock5 ? ("1|" + item10) : item10);
						Task task5 = new Task(delegate
						{
							while (dem_thread < L_Thongtin.Count && !Stop.stop)
							{
								List<Task> list4 = new List<Task>();
								for (int j = 0; j < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; j++)
								{
									if (Stop.stop)
									{
										break;
									}
									if (dem_thread >= L_Thongtin.Count)
									{
										break;
									}
									int num12 = dem_thread;
									dem_thread = num12 + 1;
									Task task9 = new Task(delegate
									{
										int num14 = dem_acc2;
										dem_acc2 = num14 + 1;
										L_Thongtin[dem_acc2].proxy = item3;
										SLM sLM3 = new SLM(L_Thongtin[dem_acc2], Use_Proxy: true);
										sLM3.RuInsw();
									});
									task9.Start();
									list4.Add(task9);
									L_Task2.Add(task9);
									int num13 = time2;
									while (!Stop.stop_FB && num13 > 0 && dem_acc2 + 1 != L_Thongtin.Count)
									{
										num13--;
										Thread.Sleep(1000);
										try
										{
											L_Thongtin[dem_acc2 + 1].TrangThai = "Waiting Run => " + num13 + " s";
											Change_Row(L_Thongtin[dem_acc2 + 1]);
										}
										catch
										{
											break;
										}
									}
								}
								Task.WaitAll(list4.ToArray());
								if (!Stop.stop_FB && dem_acc2 + 1 != L_Thongtin.Count && !ChangeIP_Xproxy(item3))
								{
									L_Thongtin[dem_acc2].TrangThai = "Error Reset proxy => " + item3;
									Change_Row(L_Thongtin[dem_acc2]);
									break;
								}
							}
						});
						task5.Start();
						Thread.Sleep(TimeSpan.FromSeconds(time2 * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP));
						int num6 = time2;
						while (!Stop.stop_FB && num6 > 0 && dem_acc2 + 1 != L_Thongtin.Count)
						{
							num6--;
							Thread.Sleep(1000);
							try
							{
								L_Thongtin[dem_acc2 + 1].TrangThai = "Waiting Run => " + num6 + " s";
								Change_Row(L_Thongtin[dem_acc2 + 1]);
							}
							catch
							{
								goto IL_0718;
							}
						}
						IL_0718:;
					}
					Task.WaitAll(L_Task2.ToArray());
				}
				else if (ThongSo_CauHinhDoiIP.rad_ChangIP_Minproxy)
				{
					int num7 = 0;
					int dem_acc = -1;
					int time = new Random().Next(10, 20);
					List<Task> L_Task = new List<Task>();
					foreach (string item11 in ThongSo_CauHinhDoiIP.rtb_KeyMinproxy)
					{
						if (Stop.stop_FB || num7 == L_Thongtin.Count)
						{
							break;
						}
						num7++;
						string item2 = item11;
						Task task6 = new Task(delegate
						{
							API_Minproxy aPI_Minproxy = new API_Minproxy(item2);
							string proxy = ((ThongSo_CauHinhDoiIP.cbb_SelecTypeIP != 1) ? aPI_Minproxy.NewIP_dancu()?.data.http_proxy_ipv4 : aPI_Minproxy.NewIP_V6()?.data.http_proxy);
							if (string.IsNullOrEmpty(proxy))
							{
								MessageBox.Show("Lấy proxy thất bại (Proxy fetch failed) ! \nKey : " + item2);
								Stop.stop_FB = true;
							}
							while (dem_thread < L_Thongtin.Count && !Stop.stop_FB)
							{
								List<Task> list3 = new List<Task>();
								for (int i = 0; i < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; i++)
								{
									if (Stop.stop_FB)
									{
										break;
									}
									if (dem_thread >= L_Thongtin.Count)
									{
										break;
									}
									int num9 = dem_thread;
									dem_thread = num9 + 1;
									Task task8 = new Task(delegate
									{
										int num11 = dem_acc;
										dem_acc = num11 + 1;
										L_Thongtin[dem_acc].proxy = proxy;
										SLM sLM2 = new SLM(L_Thongtin[dem_acc], Use_Proxy: true);
										sLM2.RuInsw();
									});
									task8.Start();
									list3.Add(task8);
									L_Task.Add(task8);
									int num10 = time;
									while (num10 > 0 && !Stop.stop_FB && dem_acc + 1 != L_Thongtin.Count && !Stop.stop_FB)
									{
										num10--;
										Thread.Sleep(1000);
										try
										{
											L_Thongtin[dem_acc + 1].TrangThai = "Waiting Run => " + num10 + " s";
											Change_Row(L_Thongtin[dem_acc + 1]);
										}
										catch
										{
											break;
										}
									}
								}
								Task.WaitAll(list3.ToArray());
								if (!Stop.stop_FB && dem_acc + 1 != L_Thongtin.Count)
								{
									proxy = changeIP_Min(aPI_Minproxy, L_Thongtin[dem_acc])?.data.http_proxy;
									if (string.IsNullOrEmpty(proxy))
									{
										L_Thongtin[dem_acc].TrangThai = "Error getting proxy key => " + item2;
										Change_Row(L_Thongtin[dem_acc]);
										break;
									}
								}
							}
						});
						task6.Start();
						L_Task.Add(task6);
						Thread.Sleep(TimeSpan.FromSeconds(time * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP));
						int num8 = time;
						while (num8 > 0 && !Stop.stop_FB && dem_acc + 1 != L_Thongtin.Count)
						{
							num8--;
							Thread.Sleep(1000);
							try
							{
								L_Thongtin[dem_acc + 1].TrangThai = Has.DeCryptWithKey("I6FhAAvLoJSAb4nEK+rxVg==", "drr0tj") + num8 + Has.DeCryptWithKey("bvFH2CJ3H5g=", "drr0tj");
								Change_Row(L_Thongtin[dem_acc + 1]);
							}
							catch
							{
								goto IL_0917;
							}
						}
						IL_0917:;
					}
					Task.WaitAll(L_Task.ToArray());
				}
				else
				{
					List<Task> list2 = new List<Task>();
					foreach (ThongTin item12 in L_Thongtin)
					{
						if (Stop.stop_FB)
						{
							break;
						}
						dem_thread++;
						ThongTin item = item12;
						Task task7 = new Task(delegate
						{
							SLM sLM = new SLM(item);
							sLM.RuInsw();
						});
						task7.Start();
						list2.Add(task7);
						Deley(4, 7);
						if (!Stop.stop_FB && dem_thread == ThongSo_CauHinhDoiIP.num_Thread_ChangeIP)
						{
							Task.WaitAll(list2.ToArray());
							changip.change();
							list2.Clear();
							dem_thread = 0;
						}
					}
					Task.WaitAll(list2.ToArray());
				}
				BeginInvoke((MethodInvoker)delegate
				{
					btnStart.Enabled = true;
					btnPause.Enabled = false;
				});
			});
			task.Start();
		}

		private void Deley(int timemin, int timemax)
		{
			Random random = new Random();
			Thread.Sleep(TimeSpan.FromSeconds(random.Next(timemin, timemax)));
		}

		private void btn_addfb_Click(object sender, EventArgs e)
		{
			nhaptaikhoan nhaptaikhoan2 = new nhaptaikhoan(1);
			nhaptaikhoan2.Show();
		}

		private void Inswfb_Load(object sender, EventArgs e)
		{
			Load_setting();
			Load_Data_dgv();
		}

		private void Load_setting()
		{
			JSON_Settings jSON_Settings = new JSON_Settings(Load_file.path_Setting_FB);
			try
			{
				ThongSo_Inswfb.num_ACC = jSON_Settings.GetValueInt("num_ACC");
				ThongSo_Inswfb.num_Follow_SLMin = jSON_Settings.GetValueInt("num_Follow_SLMin");
				ThongSo_Inswfb.num_Follow_SLMax = jSON_Settings.GetValueInt("num_Follow_SLMax");
				ThongSo_Inswfb.num_Post_SLMin = jSON_Settings.GetValueInt("num_Post_SLMin");
				ThongSo_Inswfb.num_Post_SLMax = jSON_Settings.GetValueInt("num_Post_SLMax");
				ThongSo_Inswfb.cb_DoiTen = jSON_Settings.GetValueBool("cb_DoiTen");
				ThongSo_Inswfb.cb_LockAcc = jSON_Settings.GetValueBool("cb_LockAcc");
				ThongSo_Inswfb.cb_UpAvt = jSON_Settings.GetValueBool("cb_UpAvt");
				ThongSo_Inswfb.cb_follow = jSON_Settings.GetValueBool("cb_follow");
				ThongSo_Inswfb.cb_post = jSON_Settings.GetValueBool("cb_post");
				ThongSo_Inswfb.rad_ChangePass_Random = jSON_Settings.GetValueBool("rad_ChangePass_Random");
				ThongSo_Inswfb.rad_FakeEmail = jSON_Settings.GetValueBool("rad_FakeEmail");
				ThongSo_Inswfb.rad_hotmail = jSON_Settings.GetValueBool("rad_hotmail");
				ThongSo_Inswfb.rad_domain = jSON_Settings.GetValueBool("rad_domain");
				ThongSo_Inswfb.rtb_Pass = jSON_Settings.GetValue("rtb_Pass").Split('\n').ToList();
				ThongSo_Inswfb.rtb_hotmail = jSON_Settings.GetValue("rtb_hotmail").Split('\n').ToList();
				ThongSo_Inswfb.txt_PathImg = jSON_Settings.GetValue("txt_PathImg");
				ThongSo_Inswfb.txt_domain = jSON_Settings.GetValue("txt_domain");
				ThongSo_Inswfb.txt_hotmail = jSON_Settings.GetValue("txt_hotmail");
				ThongSo_Inswfb.txt_PassHotmail = jSON_Settings.GetValue("txt_PassHotmail");
			}
			catch
			{
			}
		}

		private void btn_setting_Click(object sender, EventArgs e)
		{
			Setting_FB setting_FB = new Setting_FB();
			setting_FB.ShowDialog();
			Load_dgvacc();
		}

		private void btnPause_Click(object sender, EventArgs e)
		{
			Stop.stop_FB = true;
			btnPause.Enabled = false;
		}

		private void ctx_Delete_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			sQLite.Delete_Data_FB(enum_thongtin.checkselec, 1.ToString());
			Load_dgvacc();
		}

		private void ctx_DeleteAll_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			sQLite.Delete_Data_FB();
			Load_dgvacc();
		}

		private void dgv_acc_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}
			DataGridView.HitTestInfo hitTestInfo = dgv_acc.HitTest(e.X, e.Y);
			if (dgv_acc.SelectedCells.Count < 2)
			{
				dgv_acc.ClearSelection();
				try
				{
					dgv_acc[hitTestInfo.ColumnIndex, hitTestInfo.RowIndex].Selected = true;
				}
				catch
				{
				}
			}
			ctxmain.Show(dgv_acc, new Point(e.X, e.Y));
		}

		private void ctx_Chon_BoiDen_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = new List<ThongTin>();
			foreach (DataGridViewCell selectedCell in dgv_acc.SelectedCells)
			{
				dgv_acc.Rows[selectedCell.RowIndex].Cells["checkselec"].Value = true;
				DataTable dataTable = sQLite.LoadData_fb();
				DataRow dataRow = dataTable.Rows[selectedCell.RowIndex];
				object obj = dataRow["Khoa_ID"];
				list.Add(new ThongTin
				{
					Khoa_ID = int.Parse(obj.ToString()),
					checkselec = 1,
					Row_Select = selectedCell.RowIndex
				});
			}
			sQLite.Update_Data_FB(list);
		}

		private void ctx_Chon_All_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec_FB();
			sQLite.Update_Data_FB(0.ToString(), "");
			if (list.Count != 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					list[i].checkselec = 1;
					list[i].Row_Select = i;
				}
				sQLite.Update_Data_FB(list);
				Load_dgvacc();
			}
		}

		private void ctx_BoChon_BoiDen_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec_FB();
			sQLite.Update_Data_FB(0.ToString(), "");
			if (list.Count != 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					list[i].checkselec = 1;
					list[i].Row_Select = i;
				}
				sQLite.Update_Data_FB(list);
				Load_dgvacc();
			}
		}

		private void ctx_BoChon_All_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec_FB();
			sQLite.Update_Data_FB(0.ToString(), "");
			if (list.Count == 0)
			{
				return;
			}
			foreach (ThongTin item in list)
			{
				item.checkselec = 0;
				item.Row_Select = -1;
			}
			sQLite.Update_Data_FB(list);
			Load_dgvacc();
		}

		private void ctx_Save_Cookie_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec_FB(enum_thongtin.checkselec.ToString(), 1.ToString());
			using StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
			foreach (ThongTin item in list)
			{
				if (!string.IsNullOrEmpty(item.cookie))
				{
					streamWriter.WriteLine(item.cookie);
				}
			}
		}

		private void ctx_Save_UserPass_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec_FB(enum_thongtin.checkselec.ToString(), 1.ToString());
			using StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
			foreach (ThongTin item in list)
			{
				streamWriter.WriteLine(item.User + "|" + item.Pass);
			}
		}

		private void ctx_Save_UserPassCookie_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec_FB(enum_thongtin.checkselec.ToString(), 1.ToString());
			using StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
			foreach (ThongTin item in list)
			{
				streamWriter.WriteLine(item.User + "|" + item.Pass + "|" + item.cookie);
			}
		}

		private void ctx_Save_UserPassCookie2FA_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec_FB(enum_thongtin.checkselec.ToString(), 1.ToString());
			using StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
			foreach (ThongTin item in list)
			{
				streamWriter.WriteLine(item.User + "|" + item.Pass + "|" + item.cookie + "|" + item._2FA);
			}
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Load_dgvacc();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.Inswfb));
			dgv_acc = new System.Windows.Forms.DataGridView();
			STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
			User = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Cookie = new System.Windows.Forms.DataGridViewTextBoxColumn();
			_2FA = new System.Windows.Forms.DataGridViewTextBoxColumn();
			proxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
			TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Khoa_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			_Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
			checkselec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			ctxmain = new System.Windows.Forms.ContextMenuStrip(components);
			ctx_chon = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Chon_BoiDen = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Chon_All = new System.Windows.Forms.ToolStripMenuItem();
			ctx_BoChon = new System.Windows.Forms.ToolStripMenuItem();
			ctx_BoChon_BoiDen = new System.Windows.Forms.ToolStripMenuItem();
			ctx_BoChon_All = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Save_Cookie = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Save_UserPass = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Save_UserPassCookie = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Save_UserPassCookie2FA = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Delete = new System.Windows.Forms.ToolStripMenuItem();
			ctx_DeleteAll = new System.Windows.Forms.ToolStripMenuItem();
			btn_addfb = new System.Windows.Forms.Button();
			btn_setting = new System.Windows.Forms.Button();
			btnPause = new System.Windows.Forms.Button();
			btnStart = new System.Windows.Forms.Button();
			lb_notlive = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			lb_Live = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)dgv_acc).BeginInit();
			ctxmain.SuspendLayout();
			SuspendLayout();
			dgv_acc.AllowUserToAddRows = false;
			dgv_acc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			dgv_acc.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			dgv_acc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgv_acc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dgv_acc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv_acc.Columns.AddRange(STT, User, Pass, Cookie, _2FA, proxy, TrangThai, Khoa_ID, _Color, checkselec);
			dgv_acc.EnableHeadersVisualStyles = false;
			dgv_acc.Location = new System.Drawing.Point(14, 15);
			dgv_acc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			dgv_acc.Name = "dgv_acc";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75f);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgv_acc.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgv_acc.RowHeadersVisible = false;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dgv_acc.RowsDefaultCellStyle = dataGridViewCellStyle3;
			dgv_acc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			dgv_acc.Size = new System.Drawing.Size(869, 375);
			dgv_acc.TabIndex = 140;
			dgv_acc.MouseUp += new System.Windows.Forms.MouseEventHandler(dgv_acc_MouseUp);
			STT.DataPropertyName = "STT";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			STT.DefaultCellStyle = dataGridViewCellStyle4;
			STT.HeaderText = "STT";
			STT.Name = "STT";
			STT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			STT.Width = 30;
			User.DataPropertyName = "User";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			User.DefaultCellStyle = dataGridViewCellStyle5;
			User.HeaderText = "User";
			User.Name = "User";
			User.Width = 140;
			Pass.DataPropertyName = "Pass";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			Pass.DefaultCellStyle = dataGridViewCellStyle6;
			Pass.HeaderText = "Pass";
			Pass.Name = "Pass";
			Pass.Width = 40;
			Cookie.DataPropertyName = "Cookie";
			Cookie.HeaderText = "Cookie";
			Cookie.Name = "Cookie";
			Cookie.Width = 120;
			_2FA.DataPropertyName = "_2FA";
			_2FA.HeaderText = "2FA";
			_2FA.Name = "_2FA";
			proxy.DataPropertyName = "proxy";
			proxy.HeaderText = "proxy";
			proxy.Name = "proxy";
			TrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			TrangThai.DataPropertyName = "TrangThai";
			TrangThai.HeaderText = "Status";
			TrangThai.Name = "TrangThai";
			Khoa_ID.DataPropertyName = "Khoa_ID";
			Khoa_ID.HeaderText = "Khoa_ID";
			Khoa_ID.Name = "Khoa_ID";
			Khoa_ID.Visible = false;
			_Color.DataPropertyName = "_Color";
			_Color.HeaderText = "Color";
			_Color.Name = "_Color";
			_Color.Visible = false;
			checkselec.DataPropertyName = "checkselec";
			checkselec.HeaderText = "Selec";
			checkselec.Name = "checkselec";
			checkselec.ReadOnly = true;
			checkselec.Width = 50;
			openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			openFileDialog1.InitialDirectory = "C:\\Users\\Admin\\Desktop\\";
			openFileDialog1.RestoreDirectory = true;
			ctxmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[6] { ctx_chon, ctx_BoChon, toolStripMenuItem4, ctx_Delete, ctx_DeleteAll, loadToolStripMenuItem });
			ctxmain.Name = "ctxmain";
			ctxmain.Size = new System.Drawing.Size(181, 158);
			ctx_chon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { ctx_Chon_BoiDen, ctx_Chon_All });
			ctx_chon.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_chon.Image = (System.Drawing.Image)resources.GetObject("ctx_chon.Image");
			ctx_chon.Name = "ctx_chon";
			ctx_chon.Size = new System.Drawing.Size(180, 22);
			ctx_chon.Text = "Select";
			ctx_Chon_BoiDen.Image = Interactive_ins.Properties.Resources.check;
			ctx_Chon_BoiDen.Name = "ctx_Chon_BoiDen";
			ctx_Chon_BoiDen.Size = new System.Drawing.Size(136, 22);
			ctx_Chon_BoiDen.Text = "blacked out";
			ctx_Chon_BoiDen.Click += new System.EventHandler(ctx_Chon_BoiDen_Click);
			ctx_Chon_All.Image = (System.Drawing.Image)resources.GetObject("ctx_Chon_All.Image");
			ctx_Chon_All.Name = "ctx_Chon_All";
			ctx_Chon_All.Size = new System.Drawing.Size(136, 22);
			ctx_Chon_All.Text = "All";
			ctx_Chon_All.Click += new System.EventHandler(ctx_Chon_All_Click);
			ctx_BoChon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { ctx_BoChon_BoiDen, ctx_BoChon_All });
			ctx_BoChon.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_BoChon.Image = (System.Drawing.Image)resources.GetObject("ctx_BoChon.Image");
			ctx_BoChon.Name = "ctx_BoChon";
			ctx_BoChon.Size = new System.Drawing.Size(180, 22);
			ctx_BoChon.Text = "UnSelect";
			ctx_BoChon_BoiDen.Image = (System.Drawing.Image)resources.GetObject("ctx_BoChon_BoiDen.Image");
			ctx_BoChon_BoiDen.Name = "ctx_BoChon_BoiDen";
			ctx_BoChon_BoiDen.Size = new System.Drawing.Size(136, 22);
			ctx_BoChon_BoiDen.Text = "blacked out";
			ctx_BoChon_BoiDen.Click += new System.EventHandler(ctx_BoChon_BoiDen_Click);
			ctx_BoChon_All.Image = (System.Drawing.Image)resources.GetObject("ctx_BoChon_All.Image");
			ctx_BoChon_All.Name = "ctx_BoChon_All";
			ctx_BoChon_All.Size = new System.Drawing.Size(136, 22);
			ctx_BoChon_All.Text = "All";
			ctx_BoChon_All.Click += new System.EventHandler(ctx_BoChon_All_Click);
			toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { ctx_Save_Cookie, ctx_Save_UserPass, ctx_Save_UserPassCookie, ctx_Save_UserPassCookie2FA });
			toolStripMenuItem4.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			toolStripMenuItem4.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem4.Image");
			toolStripMenuItem4.Name = "toolStripMenuItem4";
			toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
			toolStripMenuItem4.Text = "Save";
			ctx_Save_Cookie.Image = Interactive_ins.Properties.Resources.floppy_disk__1_;
			ctx_Save_Cookie.Name = "ctx_Save_Cookie";
			ctx_Save_Cookie.Size = new System.Drawing.Size(185, 22);
			ctx_Save_Cookie.Text = "Cookie";
			ctx_Save_Cookie.Click += new System.EventHandler(ctx_Save_Cookie_Click);
			ctx_Save_UserPass.Image = (System.Drawing.Image)resources.GetObject("ctx_Save_UserPass.Image");
			ctx_Save_UserPass.Name = "ctx_Save_UserPass";
			ctx_Save_UserPass.Size = new System.Drawing.Size(185, 22);
			ctx_Save_UserPass.Text = "User|Pass";
			ctx_Save_UserPass.Click += new System.EventHandler(ctx_Save_UserPass_Click);
			ctx_Save_UserPassCookie.Image = (System.Drawing.Image)resources.GetObject("ctx_Save_UserPassCookie.Image");
			ctx_Save_UserPassCookie.Name = "ctx_Save_UserPassCookie";
			ctx_Save_UserPassCookie.Size = new System.Drawing.Size(185, 22);
			ctx_Save_UserPassCookie.Text = "User|Pass|Cookie";
			ctx_Save_UserPassCookie.Click += new System.EventHandler(ctx_Save_UserPassCookie_Click);
			ctx_Save_UserPassCookie2FA.Image = (System.Drawing.Image)resources.GetObject("ctx_Save_UserPassCookie2FA.Image");
			ctx_Save_UserPassCookie2FA.Name = "ctx_Save_UserPassCookie2FA";
			ctx_Save_UserPassCookie2FA.Size = new System.Drawing.Size(185, 22);
			ctx_Save_UserPassCookie2FA.Text = "User|Pass|Cookie|2FA";
			ctx_Save_UserPassCookie2FA.Click += new System.EventHandler(ctx_Save_UserPassCookie2FA_Click);
			ctx_Delete.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_Delete.Image = (System.Drawing.Image)resources.GetObject("ctx_Delete.Image");
			ctx_Delete.Name = "ctx_Delete";
			ctx_Delete.Size = new System.Drawing.Size(180, 22);
			ctx_Delete.Text = "Delete";
			ctx_Delete.Click += new System.EventHandler(ctx_Delete_Click);
			ctx_DeleteAll.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_DeleteAll.Image = (System.Drawing.Image)resources.GetObject("ctx_DeleteAll.Image");
			ctx_DeleteAll.Name = "ctx_DeleteAll";
			ctx_DeleteAll.Size = new System.Drawing.Size(180, 22);
			ctx_DeleteAll.Text = "Delete All";
			ctx_DeleteAll.Click += new System.EventHandler(ctx_DeleteAll_Click);
			btn_addfb.Cursor = System.Windows.Forms.Cursors.Hand;
			btn_addfb.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			btn_addfb.Image = (System.Drawing.Image)resources.GetObject("btn_addfb.Image");
			btn_addfb.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btn_addfb.Location = new System.Drawing.Point(495, 400);
			btn_addfb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btn_addfb.Name = "btn_addfb";
			btn_addfb.Size = new System.Drawing.Size(103, 49);
			btn_addfb.TabIndex = 141;
			btn_addfb.Text = " ADD FB";
			btn_addfb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btn_addfb.UseVisualStyleBackColor = false;
			btn_addfb.Click += new System.EventHandler(btn_addfb_Click);
			btn_setting.Cursor = System.Windows.Forms.Cursors.Hand;
			btn_setting.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			btn_setting.Image = (System.Drawing.Image)resources.GetObject("btn_setting.Image");
			btn_setting.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btn_setting.Location = new System.Drawing.Point(356, 400);
			btn_setting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btn_setting.Name = "btn_setting";
			btn_setting.Size = new System.Drawing.Size(103, 49);
			btn_setting.TabIndex = 137;
			btn_setting.Text = "SETTING";
			btn_setting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btn_setting.UseVisualStyleBackColor = false;
			btn_setting.Click += new System.EventHandler(btn_setting_Click);
			btnPause.Cursor = System.Windows.Forms.Cursors.Hand;
			btnPause.Enabled = false;
			btnPause.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			btnPause.Image = (System.Drawing.Image)resources.GetObject("btnPause.Image");
			btnPause.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnPause.Location = new System.Drawing.Point(179, 400);
			btnPause.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnPause.Name = "btnPause";
			btnPause.Size = new System.Drawing.Size(135, 49);
			btnPause.TabIndex = 136;
			btnPause.Text = "       STOP";
			btnPause.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnPause.UseVisualStyleBackColor = false;
			btnPause.Click += new System.EventHandler(btnPause_Click);
			btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
			btnStart.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			btnStart.Image = (System.Drawing.Image)resources.GetObject("btnStart.Image");
			btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnStart.Location = new System.Drawing.Point(12, 400);
			btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnStart.Name = "btnStart";
			btnStart.Size = new System.Drawing.Size(132, 49);
			btnStart.TabIndex = 135;
			btnStart.Text = "      START";
			btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnStart.UseVisualStyleBackColor = false;
			btnStart.Click += new System.EventHandler(btnStart_Click);
			lb_notlive.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			lb_notlive.AutoSize = true;
			lb_notlive.BackColor = System.Drawing.Color.Crimson;
			lb_notlive.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			lb_notlive.ForeColor = System.Drawing.Color.White;
			lb_notlive.Location = new System.Drawing.Point(854, 429);
			lb_notlive.Name = "lb_notlive";
			lb_notlive.Size = new System.Drawing.Size(16, 16);
			lb_notlive.TabIndex = 144;
			lb_notlive.Text = "0";
			label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label1.Location = new System.Drawing.Point(700, 429);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(69, 16);
			label1.TabIndex = 145;
			label1.Text = "Not Live :";
			lb_Live.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			lb_Live.AutoSize = true;
			lb_Live.BackColor = System.Drawing.Color.DarkGreen;
			lb_Live.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			lb_Live.ForeColor = System.Drawing.Color.White;
			lb_Live.Location = new System.Drawing.Point(854, 403);
			lb_Live.Name = "lb_Live";
			lb_Live.Size = new System.Drawing.Size(16, 16);
			lb_Live.TabIndex = 146;
			lb_Live.Text = "0";
			label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label3.Location = new System.Drawing.Point(700, 403);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(47, 16);
			label3.TabIndex = 147;
			label3.Text = "Live : ";
			saveFileDialog1.Filter = "txt files |* .txt| All files (*. *) | *. *";
			saveFileDialog1.Title = "Save";
			loadToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			loadToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("loadToolStripMenuItem.Image");
			loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			loadToolStripMenuItem.Text = "Reload Data";
			loadToolStripMenuItem.Click += new System.EventHandler(loadToolStripMenuItem_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(895, 459);
			base.Controls.Add(lb_Live);
			base.Controls.Add(label3);
			base.Controls.Add(lb_notlive);
			base.Controls.Add(label1);
			base.Controls.Add(btn_addfb);
			base.Controls.Add(dgv_acc);
			base.Controls.Add(btn_setting);
			base.Controls.Add(btnPause);
			base.Controls.Add(btnStart);
			Font = new System.Drawing.Font("Tahoma", 9.75f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.MaximizeBox = false;
			base.Name = "Inswfb";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Register Instagram with facebook";
			base.Load += new System.EventHandler(Inswfb_Load);
			((System.ComponentModel.ISupportInitialize)dgv_acc).EndInit();
			ctxmain.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
