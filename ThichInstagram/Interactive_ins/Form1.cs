using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interactive_ins.Properties;
using IWshRuntimeLibrary;

namespace Interactive_ins
{
	public class Form1 : Form
	{
		public static Form1 remote;

		public JSON_Settings CauHinhDoiIP;

		public JSON_Settings CauHinhTuongTac;

		public JSON_Settings SettingCP;

		private IContainer components = null;

		private DataGridView dgv_acc;

		private ToolStrip tstrstatusbar;

		private ToolStripLabel toolStripLabel1;

		private ToolStripLabel lb_IP;

		private ToolStripLabel lb_loadIP;

		private ToolStripLabel toolStripLabel7;

		private ToolStripLabel lb_die;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripLabel label;

		private ToolStripLabel lb_kichhoat;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripLabel lb_HSD;

		private ContextMenuStrip ctxmain;

		private ToolStripMenuItem ctx_Delete;

		private ToolStripMenuItem ctx_DeleteAll;

		private ToolStripMenuItem toolStripMenuItem4;

		private ToolStripMenuItem ctx_Save_UserPassCookie;

		private ToolStripMenuItem ctx_Save_Cookie;

		private OpenFileDialog openFileDialog1;

		private ToolStripLabel toolStripLabel3;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripLabel lb_Live;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem ctx_Save_UserPass;

		private ToolStripMenuItem ctx_chon;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripLabel toolStripLabel4;

		private ToolStripLabel lb_TongAcc;

		private ToolStripButton lb_Loading;

		private ToolStripMenuItem ctx_Chon_BoiDen;

		private ToolStripMenuItem ctx_Chon_Live;

		private ToolStripMenuItem ctx_Chon__NotLive;

		private ToolStripMenuItem ctx_Chon_TLC;

		private ToolStripMenuItem ctx_Chon_All;

		private ToolStripMenuItem ctx_BoChon;

		private ToolStripMenuItem ctx_BoChon_BoiDen;

		private ToolStripMenuItem ctx_BoChon_All;

		private ToolStripMenuItem ctx_ChuaCheckLive;

		private ToolStripMenuItem ctx_SudungCheckLive;

		private SaveFileDialog saveFileDialog1;

		private GroupBox groupBox2;

		private Label lb_setting_CauHinhTuongTac;

		private Button btn_stop;

		private Button btn_start;

		private Panel pnlHeader;

		private PictureBox pictureBox1;

		private Button button2;

		private Button button1;

		private Button btnMinimize;

		private Label label3;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem mnuCauHinhChung;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_29;

		private ToolStripMenuItem toolStripMenuItem_49;

		private ToolStripMenuItem toolStripMenuItem1;

		private ToolStripMenuItem ctx_Profile;

		private ToolStripMenuItem ctx_OpenProfile;

		private ToolStripMenuItem ctx_CreadtSC;

		private ToolStripMenuItem ctx_DeleteProfile;

		private Button btnPost;

		private Button button9;

		private Button button7;

		private ToolStripMenuItem loadToolStripMenuItem;

		private Button button3;

		private ToolStripMenuItem ctx_OpenCP;

		private ToolStripMenuItem ctx_checkpoinHotmail;

		private ToolStripMenuItem ctx_checkpoinMailDomain;

		private ToolStripMenuItem ctx_checkpoinPhone;

		private ToolStripMenuItem ctx_settingCP;

		private DataGridViewTextBoxColumn STT;

		private DataGridViewTextBoxColumn User;

		private DataGridViewTextBoxColumn Pass;

		private DataGridViewTextBoxColumn Cookie;

		private DataGridViewTextBoxColumn Total;

		private DataGridViewTextBoxColumn FullName;

		private DataGridViewTextBoxColumn ID;

		private DataGridViewTextBoxColumn _2FA;

		private DataGridViewTextBoxColumn Mail;

		private DataGridViewTextBoxColumn Pass_Mail;

		private DataGridViewTextBoxColumn proxy;

		private DataGridViewTextBoxColumn Avatar;

		private DataGridViewTextBoxColumn BaiViet;

		private DataGridViewTextBoxColumn Followers;

		private DataGridViewTextBoxColumn Following;

		private DataGridViewTextBoxColumn TinhTrang;

		private DataGridViewTextBoxColumn CheckPoin;

		private DataGridViewTextBoxColumn TrangThai;

		private DataGridViewCheckBoxColumn checkselec;

		private ToolStripMenuItem checkpoinPhoneToolStripMenuItem;

		private ToolStripMenuItem checkpoinMailToolStripMenuItem;

		private Label label1;

		public Form1()
		{
			InitializeComponent();
			remote = this;
		}

		private string Load_IP()
		{
			try
			{
				string text = "";
				WebRequest webRequest = WebRequest.Create("http://checkip.dyndns.org/");
				using (WebResponse webResponse = webRequest.GetResponse())
				{
					using StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
					text = streamReader.ReadToEnd();
				}
				int num = text.IndexOf("Address: ") + 9;
				int num2 = text.LastIndexOf("</body>");
				text = text.Substring(num, num2 - num);
				return text + "  ";
			}
			catch
			{
				return "0.0.0.0  ";
			}
		}

		public int Row_dgv(string user)
		{
			for (int i = 0; i < dgv_acc.Rows.Count; i++)
			{
				int num = i;
				string text = dgv_acc.Rows[i].Cells["User"].Value.ToString();
				if (!(user != text))
				{
					return i;
				}
			}
			return 0;
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
					dgv_acc.Rows[thongtin.Row_Select].Cells["User"].Value = thongtin.User;
					dgv_acc.Rows[thongtin.Row_Select].Cells["Pass"].Value = thongtin.Pass;
					dgv_acc.Rows[thongtin.Row_Select].Cells["Cookie"].Value = thongtin.cookie;
					dgv_acc.Rows[thongtin.Row_Select].Cells["Total"].Value = thongtin.Total;
					dgv_acc.Rows[thongtin.Row_Select].Cells["FullName"].Value = thongtin.FullName;
					dgv_acc.Rows[thongtin.Row_Select].Cells["ID"].Value = thongtin.ID;
					dgv_acc.Rows[thongtin.Row_Select].Cells["_2FA"].Value = thongtin._2FA;
					dgv_acc.Rows[thongtin.Row_Select].Cells["Mail"].Value = thongtin.Mail;
					dgv_acc.Rows[thongtin.Row_Select].Cells["Avatar"].Value = thongtin.Avatar;
					dgv_acc.Rows[thongtin.Row_Select].Cells["BaiViet"].Value = thongtin.BaiViet;
					dgv_acc.Rows[thongtin.Row_Select].Cells["proxy"].Value = thongtin.proxy;
					dgv_acc.Rows[thongtin.Row_Select].Cells["Followers"].Value = thongtin.Followers;
					dgv_acc.Rows[thongtin.Row_Select].Cells["Following"].Value = thongtin.Following;
					dgv_acc.Rows[thongtin.Row_Select].Cells["TinhTrang"].Value = thongtin.TinhTrang;
					dgv_acc.Rows[thongtin.Row_Select].Cells["CheckPoin"].Value = thongtin.CheckPoin;
					dgv_acc.Rows[thongtin.Row_Select].Cells["TrangThai"].Value = thongtin.TrangThai;
				}
				catch
				{
				}
			});
		}

		private void Load_Data_dgv()
		{
			SQLite sQLite = new SQLite();
			JSON_Settings jSON_Settings = new JSON_Settings(Load_file.path_Cauhinhhienthi);
			try
			{
				dgv_acc.Columns["FullName"].Visible = jSON_Settings.GetValueBool("cb_fullname");
				dgv_acc.Columns["ID"].Visible = jSON_Settings.GetValueBool("cb_ID");
				dgv_acc.Columns["_2FA"].Visible = jSON_Settings.GetValueBool("cb_2FA");
				dgv_acc.Columns["Pass_Mail"].Visible = jSON_Settings.GetValueBool("cb_PassMail");
				dgv_acc.Columns["Cookie"].Visible = jSON_Settings.GetValueBool("cb_Cookie");
				dgv_acc.Columns["Mail"].Visible = jSON_Settings.GetValueBool("cb_mail");
				dgv_acc.Columns["proxy"].Visible = jSON_Settings.GetValueBool("cb_proxy");
				dgv_acc.Columns["Followers"].Visible = jSON_Settings.GetValueBool("cb_Followers");
				dgv_acc.Columns["Following"].Visible = jSON_Settings.GetValueBool("cb_Following");
				dgv_acc.Columns["TinhTrang"].Visible = jSON_Settings.GetValueBool("cb_tinhtrang");
				dgv_acc.Columns["CheckPoin"].Visible = jSON_Settings.GetValueBool("cb_CheckPoin");
				dgv_acc.Columns["Avatar"].Visible = jSON_Settings.GetValueBool("cb_avatar");
				dgv_acc.Columns["BaiViet"].Visible = jSON_Settings.GetValueBool("cb_Post");
			}
			catch
			{
			}
			sQLite.Check_table();
			Load_dgvacc();
		}

		public void Load_dgvacc()
		{
			SQLite sQLite = new SQLite();
			DataTable dataTable = sQLite.LoadData();
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
					dgv_acc.Rows.Add(dgv_acc.RowCount + 1, row["User"], row["Pass"], row["Cookie"], row["Total"], row["FullName"], row["ID"], row["_2FA"], row["Mail"], row["Pass_Mail"], row["proxy"], row["Avatar"], row["BaiViet"], row["Followers"], row["Following"], row["TinhTrang"], row["CheckPoin"], row["TrangThai"], checkselec);
					dgv_acc.Rows[i].DefaultCellStyle.ForeColor = color;
				});
			}
			dgv_acc.EndEdit();
			List<ThongTin> list = sQLite.Select_Data_checkselec(enum_thongtin.Color.ToString(), 1.ToString());
			List<ThongTin> list2 = sQLite.Select_Data_checkselec(enum_thongtin.Color.ToString(), 0.ToString());
			lb_Live.Text = list.Count.ToString();
			lb_die.Text = list2.Count.ToString();
			lb_TongAcc.Text = dataTable.Rows.Count.ToString();
		}

		private void CheckLive_chrome(SQLite sqlite)
		{
			Task task = new Task(delegate
			{
				Random random = new Random();
				List<ThongTin> list = sqlite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
				List<Task> list2 = new List<Task>();
				for (int i = 0; i < 1; i++)
				{
					int num = i;
					Task task2 = new Task(delegate
					{
					});
					task2.Start();
					list2.Add(task2);
				}
				Task.WaitAll(list2.ToArray());
				Invoke((MethodInvoker)delegate
				{
					lb_Loading.Enabled = false;
				});
			});
			task.Start();
		}

		private void Chon(string color, string tinhtrang)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec(color, tinhtrang);
			sQLite.Update_Data(0.ToString(), "");
			if (list.Count == 0)
			{
				return;
			}
			foreach (ThongTin item in list)
			{
				item.checkselec = 1;
				item.Row_Select = Row_dgv(item.User);
			}
			sQLite.Update_Data(list);
			Load_dgvacc();
		}

		private void lb_loadIP_Click(object sender, EventArgs e)
		{
			lb_IP.Text = Load_IP();
		}

		private void Load_CauHinhTuongTac()
		{
			CauHinhTuongTac = new JSON_Settings(Load_file.path_CauHinhTuongTac);
			interact_sql interact_sql2 = new interact_sql();
			ThongSo_CauHinhTuongTac.TT_KichBan = interact_sql2.Select_Data_KichBan(CauHinhTuongTac.GetValue("cbb_KieuTuongTac"));
			ThongSo_CauHinhTuongTac.cb_RandomHanhDong = CauHinhTuongTac.GetValueBool("cb_RandomHanhDong");
			ThongSo_CauHinhTuongTac.L_HanhDong = Load_file.Load_hanhdong();
			ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin = CauHinhTuongTac.GetValueInt("num_ThreadTimeout_TimeMin");
			ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax = CauHinhTuongTac.GetValueInt("num_ThreadTimeout_TimeMax");
			ThongSo_CauHinhTuongTac.txt_PathProfile = CauHinhTuongTac.GetValue("txt_PathProfile");
			ThongSo_CauHinhTuongTac.cb_checkTT = CauHinhTuongTac.GetValueBool("cb_checkTT");
			ThongSo_CauHinhTuongTac.txt_cookiecheck = CauHinhTuongTac.GetValue("txt_cookiecheck");
			ThongSo_CauHinhTuongTac.rad_VI = CauHinhTuongTac.GetValueBool("rad_VI");
			ThongSo_CauHinhTuongTac.rad_EN = CauHinhTuongTac.GetValueBool("rad_EN");
			ThongSo_CauHinhTuongTac.num_ChromeX = CauHinhTuongTac.GetValueInt("num_ChromeX");
			ThongSo_CauHinhTuongTac.num_ChromeY = CauHinhTuongTac.GetValueInt("num_ChromeY");
			ThongSo_CauHinhTuongTac.cb_SDProfile = CauHinhTuongTac.GetValueBool("cb_SDProfile");
			ThongSo_CauHinhTuongTac.cb_addform = CauHinhTuongTac.GetValueBool("cb_addform");
		}

		public void Load_CauHinhDoiIP()
		{
			CauHinhDoiIP = new JSON_Settings(Load_file.path_CauHinhDoiIP);
			ThongSo_CauHinhDoiIP.num_Thread_ChangeIP = CauHinhDoiIP.GetValueInt("num_Thread_ChangeIP");
			ThongSo_CauHinhDoiIP.rad_ChangIP_No = CauHinhDoiIP.GetValueBool("rad_ChangIP_No");
			ThongSo_CauHinhDoiIP.rad_ChangIP_HMA = CauHinhDoiIP.GetValueBool("rad_ChangIP_HMA");
			ThongSo_CauHinhDoiIP.rad_ChangIP_Dcom = CauHinhDoiIP.GetValueBool("rad_ChangIP_Dcom");
			ThongSo_CauHinhDoiIP.rad_ChangIP_Proxy = CauHinhDoiIP.GetValueBool("rad_ChangIP_Proxy");
			ThongSo_CauHinhDoiIP.rad_ChangIP_Tinsoft = CauHinhDoiIP.GetValueBool("rad_ChangIP_Tinsoft");
			ThongSo_CauHinhDoiIP.rad_ChangIP_ShopLike = CauHinhDoiIP.GetValueBool("rad_ChangIP_ShopLike");
			ThongSo_CauHinhDoiIP.rad_Dcom_Thuong = CauHinhDoiIP.GetValueBool("rad_Dcom_Thuong");
			ThongSo_CauHinhDoiIP.rad_Dcom_Hilink = CauHinhDoiIP.GetValueBool("rad_Dcom_Hilink");
			ThongSo_CauHinhDoiIP.txt_Name_Dcom = CauHinhDoiIP.GetValue("txt_Name_Dcom");
			ThongSo_CauHinhDoiIP.txt_URL = CauHinhDoiIP.GetValue("txt_URL");
			ThongSo_CauHinhDoiIP.rtb_KeyShoplike = CauHinhDoiIP.GetValue("rtb_KeyShoplike").Split('\n').ToList();
			ThongSo_CauHinhDoiIP.rtb_KeyShoplike?.RemoveAll((string x) => x == "");
			ThongSo_CauHinhDoiIP.rtb_KeyTinsoft = CauHinhDoiIP.GetValue("rtb_KeyTinsoft").Split('\n').ToList();
			ThongSo_CauHinhDoiIP.rtb_KeyTinsoft?.RemoveAll((string x) => x == "");
			ThongSo_CauHinhDoiIP.rad_ChangIP_Xproxy = CauHinhDoiIP.GetValueBool("rad_ChangIP_Xproxy");
			ThongSo_CauHinhDoiIP.rad_Xproxy_Http = CauHinhDoiIP.GetValueBool("rad_Xproxy_Http");
			ThongSo_CauHinhDoiIP.rad_Xproxy_Sock5 = CauHinhDoiIP.GetValueBool("rad_Xproxy_Sock5");
			ThongSo_CauHinhDoiIP.txt_Service_Url = CauHinhDoiIP.GetValue("txt_Service_Url");
			ThongSo_CauHinhDoiIP.rtb_Xproxy_Proxy = CauHinhDoiIP.GetValue("rtb_Xproxy_Proxy").Split('\n').ToList();
			ThongSo_CauHinhDoiIP.rtb_Xproxy_Proxy?.RemoveAll((string x) => x == "");
			ThongSo_CauHinhDoiIP.rad_ChangIP_Minproxy = CauHinhDoiIP.GetValueBool("rad_ChangIP_Minproxy");
			ThongSo_CauHinhDoiIP.rtb_KeyMinproxy = CauHinhDoiIP.GetValue("rtb_KeyMinproxy").Split('\n').ToList();
			ThongSo_CauHinhDoiIP.cbb_SelecTypeIP = CauHinhDoiIP.GetValueInt("cbb_SelecTypeIP");
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Load_Data_dgv();
			Load_CauHinhTuongTac();
			Load_CauHinhDoiIP();
			Load_SettingCP();
			lb_kichhoat.Text = "Crack By Uyennguyen";
			lb_HSD.Text = "Expiry : 1 tỷ days";
			lb_IP.Text = Load_IP();
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label3.Text = "Phần Mềm Quản Lý, Chăm Sóc Tài Khoản Instagram";
				mnuCauHinhChung.Text = "Cấu hình đổi IP";
				toolStripMenuItem_1.Text = "Cấu hình tương tác";
				toolStripMenuItem_29.Text = "Cấu hình hiển thị";
				toolStripMenuItem_49.Text = "Liên hệ";
				btn_start.Text = "Chạy tương tác";
				btn_stop.Text = "Dừng tương tác";
				btnPost.Text = "     Tạo Ins từ Fb";
				button7.Text = "      Nhập Proxy";
				button3.Text = "        Nhập tài khoản";
			}
		}

		private void Load_SettingCP()
		{
			SettingCP = new JSON_Settings(Load_file.path_SettingCP);
			ThongSo_SettingCP.txt_domain = SettingCP.GetValue("txt_domain");
			ThongSo_SettingCP.txt_hotmail = SettingCP.GetValue("txt_hotmail");
			ThongSo_SettingCP.txt_PassHotmail = SettingCP.GetValue("txt_PassHotmail");
			ThongSo_SettingCP.cb_LockAcc = SettingCP.GetValueBool("cb_LockAcc");
		}

		private void btn_UseIP_Click(object sender, EventArgs e)
		{
			CauHinhDoiIP cauHinhDoiIP = new CauHinhDoiIP();
			cauHinhDoiIP.ShowDialog();
		}

		private void lb_setting_CauHinhTuongTac_Click(object sender, EventArgs e)
		{
			CauHinhTuongTac cauHinhTuongTac = new CauHinhTuongTac();
			cauHinhTuongTac.ShowDialog();
		}

		private void btn_add_Click(object sender, EventArgs e)
		{
		}

		private void ctx_Delete_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			sQLite.Delete_Data(enum_thongtin.checkselec, 1.ToString());
			Load_dgvacc();
		}

		private void dgv_acc_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				if (dgv_acc.SelectedCells.Count != 0 && e.Button == MouseButtons.Right)
				{
					DataGridView.HitTestInfo hitTestInfo = dgv_acc.HitTest(e.X, e.Y);
					ctxmain.Show(dgv_acc, new Point(e.X, e.Y));
				}
			}
			catch
			{
			}
		}

		private void dgv_acc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				return;
			}
			SQLite sqlite = new SQLite();
			DataTable dt = sqlite.LoadData();
			enum_thongtin ten_column = (enum_thongtin)e.ColumnIndex;
			List<int> list = new List<int> { 1, 2, 3, 7, 5, 8, 9 };
			list.ForEach(delegate(int item)
			{
				if (item == e.ColumnIndex)
				{
					DataRow dataRow = dt.Rows[e.RowIndex];
					object obj = dataRow["Khoa_ID"];
					string update_thongtin = dgv_acc.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
					sqlite.Update_Data(ten_column.ToString(), update_thongtin, obj.ToString());
				}
			});
		}

		private void dgv_acc_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex != -1 && e.ColumnIndex == 18)
			{
				List<ThongTin> list = new List<ThongTin>();
				SQLite sQLite = new SQLite();
				DataTable dataTable = sQLite.LoadData();
				DataRow dataRow = dataTable.Rows[e.RowIndex];
				object obj = dataRow["Khoa_ID"];
				if ((bool)dgv_acc.Rows[e.RowIndex].Cells["checkselec"].Value)
				{
					dgv_acc.Rows[e.RowIndex].Cells["checkselec"].Value = false;
					list.Add(new ThongTin
					{
						checkselec = 0,
						Row_Select = -1,
						Khoa_ID = int.Parse(obj.ToString())
					});
					sQLite.Update_Data(list);
				}
				else
				{
					dgv_acc.Rows[e.RowIndex].Cells["checkselec"].Value = true;
					list.Add(new ThongTin
					{
						checkselec = 1,
						Row_Select = e.RowIndex,
						Khoa_ID = int.Parse(obj.ToString())
					});
					sQLite.Update_Data(list);
				}
				dgv_acc.EndEdit();
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void ctx_DeleteAll_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			sQLite.Delete_Data();
			Load_dgvacc();
		}

		private void btn_addall_Click(object sender, EventArgs e)
		{
			nhaptaikhoan nhaptaikhoan2 = new nhaptaikhoan(0);
			nhaptaikhoan2.Show();
		}

		private void btn_stop_Click(object sender, EventArgs e)
		{
			Stop.stop = true;
			btn_stop.Enabled = false;
		}

		private void ctx_Chon_BoiDen_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = new List<ThongTin>();
			foreach (DataGridViewCell selectedCell in dgv_acc.SelectedCells)
			{
				dgv_acc.Rows[selectedCell.RowIndex].Cells[18].Value = true;
				DataTable dataTable = sQLite.LoadData();
				DataRow dataRow = dataTable.Rows[selectedCell.RowIndex];
				object obj = dataRow["Khoa_ID"];
				list.Add(new ThongTin
				{
					Khoa_ID = int.Parse(obj.ToString()),
					checkselec = 1,
					Row_Select = selectedCell.RowIndex
				});
			}
			sQLite.Update_Data(list);
		}

		private void ctx_Chon_Live_Click(object sender, EventArgs e)
		{
			Chon(enum_thongtin.Color.ToString(), 1.ToString());
		}

		private void ctx_Chon__NotLive_Click(object sender, EventArgs e)
		{
			Chon(enum_thongtin.Color.ToString(), 0.ToString());
		}

		private void ctx_ChuaCheckLive_Click(object sender, EventArgs e)
		{
			Chon(enum_thongtin.Color.ToString(), 2.ToString());
		}

		private void ctx_Chon_TLC_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec();
			sQLite.Update_Data(0.ToString(), "");
			if (list.Count == 0)
			{
				return;
			}
			foreach (ThongTin item in list)
			{
				if (string.IsNullOrEmpty(item.Avatar) || string.IsNullOrEmpty(item.Following) || string.IsNullOrEmpty(item.BaiViet))
				{
					item.checkselec = 0;
					item.Row_Select = -1;
				}
				else if (item.Avatar == "No" || int.Parse(item.Following) < 10 || int.Parse(item.BaiViet) < 3)
				{
					item.checkselec = 1;
					item.Row_Select = Row_dgv(item.User);
				}
				else
				{
					item.checkselec = 0;
					item.Row_Select = -1;
				}
			}
			sQLite.Update_Data(list);
			Load_dgvacc();
		}

		public void load_livedie(int live, int die)
		{
			Invoke((MethodInvoker)delegate
			{
				lb_Live.Text = live.ToString();
				lb_die.Text = die.ToString();
			});
		}

		private void ctx_Chon_All_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec();
			sQLite.Update_Data(0.ToString(), "");
			if (list.Count != 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					list[i].checkselec = 1;
					list[i].Row_Select = i;
				}
				sQLite.Update_Data(list);
				Load_dgvacc();
			}
		}

		private void ctx_BoChon_BoiDen_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = new List<ThongTin>();
			foreach (DataGridViewCell selectedCell in dgv_acc.SelectedCells)
			{
				dgv_acc.Rows[selectedCell.RowIndex].Cells[18].Value = false;
				DataTable dataTable = sQLite.LoadData();
				DataRow dataRow = dataTable.Rows[selectedCell.RowIndex];
				object obj = dataRow["Khoa_ID"];
				list.Add(new ThongTin
				{
					Khoa_ID = int.Parse(obj.ToString()),
					checkselec = 0,
					Row_Select = -1
				});
			}
			sQLite.Update_Data(list);
		}

		private void ctx_BoChon_All_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec();
			sQLite.Update_Data(0.ToString(), "");
			if (list.Count == 0)
			{
				return;
			}
			foreach (ThongTin item in list)
			{
				item.checkselec = 0;
				item.Row_Select = -1;
			}
			sQLite.Update_Data(list);
			Load_dgvacc();
		}

		private void ctx_SudungCheckLive_Click(object sender, EventArgs e)
		{
			Load_CauHinhDoiIP();
			Load_CauHinhTuongTac();
			Task task = new Task(delegate
			{
				BeginInvoke((MethodInvoker)delegate
				{
					lb_Loading.Enabled = true;
				});
				SQLite sQLite = new SQLite();
				List<ThongTin> L_thongtin = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
				if (L_thongtin.Count == 0)
				{
					MessageBox.Show("Please select the account to add proxy !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (string.IsNullOrEmpty(ThongSo_CauHinhTuongTac.txt_cookiecheck))
				{
					MessageBox.Show("Please enter cookies to check !", "Notice !");
				}
				else
				{
					Task task2 = new Task(delegate
					{
						Selenium selenium = new Selenium(L_thongtin);
						selenium.checkTTLN(0);
					});
					task2.Start();
					task2.Wait();
				}
				BeginInvoke((MethodInvoker)delegate
				{
					lb_Loading.Enabled = false;
				});
				MessageBox.Show("Check Done !");
			});
			task.Start();
		}

		private void dgv_acc_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			SQLite sQLite = new SQLite();
			if (e.ColumnIndex != dgv_acc.Columns["checkselec"].Index || e.RowIndex != -1 || dgv_acc.RowCount <= 0)
			{
				return;
			}
			if ((bool)dgv_acc.Rows[0].Cells["checkselec"].Value)
			{
				for (int i = 0; i < dgv_acc.RowCount; i++)
				{
					dgv_acc.Rows[i].Cells["checkselec"].Value = false;
				}
				sQLite.Update_Data(0.ToString(), "");
			}
			else
			{
				for (int j = 0; j < dgv_acc.RowCount; j++)
				{
					dgv_acc.Rows[j].Cells["checkselec"].Value = true;
				}
				sQLite.Update_Data(1.ToString(), e.RowIndex.ToString());
			}
		}

		private void ctx_Save_Cookie_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
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
			List<ThongTin> list = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
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
			List<ThongTin> list = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
			using StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
			foreach (ThongTin item in list)
			{
				streamWriter.WriteLine(item.User + "|" + item.Pass + "|" + item.cookie);
			}
		}

		private void ctx_Save_ID_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
			using StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
			foreach (ThongTin item in list)
			{
				if (!string.IsNullOrEmpty(item.ID))
				{
					streamWriter.WriteLine(item.ID);
				}
			}
		}

		private void Deley(int timemin, int timemax)
		{
			Random random = new Random();
			Thread.Sleep(TimeSpan.FromSeconds(random.Next(timemin, timemax)));
		}

		private new_IP changeIP(API_Tinsoft tins, ThongTin thongTin)
		{
			check_ip check_ip2 = tins.checkip();
			if (req._req == 0)
			{
				return null;
			}
			if (!string.IsNullOrEmpty(check_ip2.next_change) && int.Parse(check_ip2.next_change) > 0)
			{
				int num = int.Parse(check_ip2.next_change) + 5;
				while (num > 0 && !Stop.stop)
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

		private Minproxy changeIP_Min(API_Minproxy API_Minproxy, ThongTin thongTin)
		{
			Minproxy minproxy = ((ThongSo_CauHinhDoiIP.cbb_SelecTypeIP == 1) ? API_Minproxy.CheckIP_V6() : API_Minproxy.CheckIP_dancu());
			if (req._req == 0)
			{
				return null;
			}
			if (minproxy != null && minproxy.data.next_request > 0)
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

		private bool ChangeIP_Xproxy(string proxy)
		{
			API_Xproxy aPI_Xproxy = new API_Xproxy(ThongSo_CauHinhDoiIP.txt_Service_Url, proxy);
			return aPI_Xproxy.changeip_xproxy();
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
				while (num > 0 && !Stop.stop)
				{
					num--;
					Thread.Sleep(1000);
					if (!check)
					{
						thongtin.TrangThai = "Reset IP => " + num + " s";
						Change_Row(thongtin);
					}
				}
				return shoplike.NewIP()?.data?.proxy;
			}
			if (new_IP_Shoplike2.status == "success")
			{
				return new_IP_Shoplike2.data?.proxy;
			}
			return null;
		}

		private void OpenFormViewChrome()
		{
			bool flag = false;
			FormCollection openForms = Application.OpenForms;
			foreach (object item in openForms)
			{
				Form form = (Form)item;
				if (form.Name == "Form_Chrome")
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				new Form_Chrome().Show();
			}
		}

		private void btn_start_Click(object sender, EventArgs e)
		{
			Poin.dem = 0;
			Stop.stop = false;
			Load_CauHinhTuongTac();
			Load_CauHinhDoiIP();
			SQLite sQLite = new SQLite();
			Random r = new Random();
			ChangeIP changip = new ChangeIP();
			int dem_thread = 0;
			List<ThongTin> thongtin = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
			if (thongtin.Count != 0)
			{
				btn_start.Enabled = false;
				lb_Loading.Enabled = true;
				btn_stop.Enabled = true;
				if (ThongSo_CauHinhTuongTac.cb_addform)
				{
					OpenFormViewChrome();
				}
				int num = 0;
				List<int> lstPossition = new List<int>();
				num = (ThongSo_CauHinhDoiIP.rad_ChangIP_Minproxy ? (ThongSo_CauHinhDoiIP.rtb_KeyMinproxy.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP) : (ThongSo_CauHinhDoiIP.rad_ChangIP_ShopLike ? (ThongSo_CauHinhDoiIP.rtb_KeyShoplike.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP) : (ThongSo_CauHinhDoiIP.rad_ChangIP_Tinsoft ? (ThongSo_CauHinhDoiIP.rtb_KeyTinsoft.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP) : ((!ThongSo_CauHinhDoiIP.rad_ChangIP_Xproxy) ? ThongSo_CauHinhDoiIP.num_Thread_ChangeIP : (ThongSo_CauHinhDoiIP.rtb_Xproxy_Proxy.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP)))));
				for (int i = 0; i < num; i++)
				{
					lstPossition.Add(0);
				}
				Task task = new Task(delegate
				{
					if (ThongSo_CauHinhDoiIP.rad_ChangIP_Proxy)
					{
						int dem_acc6 = 0;
						List<Task> list = new List<Task>();
						foreach (ThongTin item7 in thongtin)
						{
							ThongTin item6 = item7;
							if (Stop.stop)
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
								int num2 = dem_acc6;
								dem_acc6 = num2 + 1;
								int indexOfPossitionApp = Poin.GetIndexOfPossitionApp(ref lstPossition);
								Task task2 = new Task(delegate
								{
									Selenium selenium6 = new Selenium(item6, indexOfPossitionApp, dem_acc6, Use_Proxy: true);
									selenium6.Run();
								});
								task2.Start();
								list.Add(task2);
								Deley(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
								if (!Stop.stop && dem_thread == ThongSo_CauHinhDoiIP.num_Thread_ChangeIP)
								{
									Task.WaitAll(list.ToArray());
									for (int j = 0; j < lstPossition.Count; j++)
									{
										Poin.FillIndexPossition(ref lstPossition, j);
									}
									list.Clear();
									dem_thread = 0;
								}
							}
						}
						Thread.Sleep(5000);
						Task.WaitAll(list.ToArray());
					}
					else if (ThongSo_CauHinhDoiIP.rad_ChangIP_Tinsoft)
					{
						int dem_key = -1;
						int dem_acc5 = -1;
						int time4 = r.Next(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
						List<Task> L_Task4 = new List<Task>();
						foreach (string item8 in ThongSo_CauHinhDoiIP.rtb_KeyTinsoft)
						{
							List<int> sx4 = new List<int>();
							int num2 = dem_key;
							dem_key = num2 + 1;
							if (Stop.stop || dem_key == thongtin.Count)
							{
								break;
							}
							string item5 = item8;
							Task task3 = new Task(delegate
							{
								string proxy3 = "";
								API_Tinsoft aPI_Tinsoft = new API_Tinsoft(item5);
								check_ip check_ip2 = aPI_Tinsoft.checkip();
								if (check_ip2 == null)
								{
									MessageBox.Show("check key tinsoft ( kiểm tra lại key tinsoft ) ! \nKey : " + item5);
									Stop.stop = true;
								}
								if (check_ip2.success && check_ip2.next_change == "0")
								{
									proxy3 = aPI_Tinsoft.NewIP().proxy;
								}
								else if (check_ip2.success)
								{
									int num17 = int.Parse(check_ip2.next_change) + 5;
									while (num17 > 0 && !Stop.stop)
									{
										num17--;
										Thread.Sleep(1000);
										try
										{
											thongtin[dem_key].TrangThai = "Waiting Get IP => " + num17 + " s";
											Change_Row(thongtin[dem_key]);
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
									MessageBox.Show("Lấy proxy thất bại (Proxy fetch failed) ! \nKey : " + item5);
									Stop.stop = true;
								}
								while (dem_thread < thongtin.Count && !Stop.stop)
								{
									List<Task> list6 = new List<Task>();
									for (int num18 = 0; num18 < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; num18++)
									{
										if (Stop.stop)
										{
											break;
										}
										int indexOfPossitionApp6 = Poin.GetIndexOfPossitionApp(ref lstPossition);
										sx4.Add(indexOfPossitionApp6);
										if (dem_thread >= thongtin.Count)
										{
											break;
										}
										int num19 = dem_thread;
										dem_thread = num19 + 1;
										Task task11 = new Task(delegate
										{
											int num21 = dem_acc5;
											dem_acc5 = num21 + 1;
											thongtin[dem_acc5].proxy = proxy3;
											Selenium selenium5 = new Selenium(thongtin[dem_acc5], indexOfPossitionApp6, dem_acc5 + 1, Use_Proxy: true);
											selenium5.Run();
										});
										task11.Start();
										list6.Add(task11);
										L_Task4.Add(task11);
										int num20 = time4;
										while (num20 > 0 && !Stop.stop && dem_acc5 + 1 != thongtin.Count && !Stop.stop)
										{
											num20--;
											Thread.Sleep(1000);
											try
											{
												thongtin[dem_acc5 + 1].TrangThai = "Waiting Run => " + num20 + " s";
												Change_Row(thongtin[dem_acc5 + 1]);
											}
											catch
											{
												break;
											}
										}
									}
									Task.WaitAll(list6.ToArray());
									foreach (int item9 in sx4)
									{
										Poin.FillIndexPossition(ref lstPossition, item9);
									}
									sx4.Clear();
									if (!Stop.stop && dem_acc5 + 1 != thongtin.Count)
									{
										proxy3 = changeIP(aPI_Tinsoft, thongtin[dem_acc5])?.proxy;
										if (string.IsNullOrEmpty(proxy3))
										{
											thongtin[dem_acc5].TrangThai = "Error getting proxy key => " + item5;
											Change_Row(thongtin[dem_acc5]);
											break;
										}
									}
								}
							});
							task3.Start();
							Thread.Sleep(TimeSpan.FromSeconds(time4 * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP));
							int num3 = time4;
							while (!Stop.stop && num3 > 0 && !Stop.stop)
							{
								num3--;
								Thread.Sleep(1000);
								try
								{
									thongtin[dem_acc5 + 1].TrangThai = "Waiting Run => " + num3 + " s";
									Change_Row(thongtin[dem_acc5 + 1]);
								}
								catch
								{
									goto IL_0396;
								}
							}
							IL_0396:;
						}
						Thread.Sleep(5000);
						Task.WaitAll(L_Task4.ToArray());
					}
					else if (ThongSo_CauHinhDoiIP.rad_ChangIP_ShopLike)
					{
						int num4 = 0;
						int dem_acc4 = -1;
						int time3 = r.Next(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
						List<Task> L_Task3 = new List<Task>();
						foreach (string item10 in ThongSo_CauHinhDoiIP.rtb_KeyShoplike)
						{
							if (!string.IsNullOrEmpty(item10.Trim()))
							{
								if (Stop.stop || num4 == thongtin.Count)
								{
									break;
								}
								num4++;
								string item4 = item10;
								List<int> sx3 = new List<int>();
								Task task4 = new Task(delegate
								{
									ShopLike shoplike = new ShopLike(item4);
									string proxy2 = changeIP_shoplike(shoplike, check: true);
									if (string.IsNullOrEmpty(proxy2))
									{
										MessageBox.Show("Lấy proxy thất bại (Proxy fetch failed) ! \nKey : " + item4);
										Stop.stop = true;
									}
									while (dem_thread < thongtin.Count && !Stop.stop)
									{
										List<Task> list5 = new List<Task>();
										for (int n = 0; n < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; n++)
										{
											if (Stop.stop)
											{
												break;
											}
											if (dem_thread >= thongtin.Count)
											{
												break;
											}
											int num14 = dem_thread;
											dem_thread = num14 + 1;
											Task task10 = new Task(delegate
											{
												int num16 = dem_acc4;
												dem_acc4 = num16 + 1;
												thongtin[dem_acc4].proxy = proxy2;
												int indexOfPossitionApp5 = Poin.GetIndexOfPossitionApp(ref lstPossition);
												sx3.Add(indexOfPossitionApp5);
												Selenium selenium4 = new Selenium(thongtin[dem_acc4], indexOfPossitionApp5, dem_acc4 + 1, Use_Proxy: true);
												selenium4.Run();
											});
											task10.Start();
											list5.Add(task10);
											L_Task3.Add(task10);
											int num15 = time3;
											while (num15 > 0 && !Stop.stop && dem_acc4 + 1 != thongtin.Count && !Stop.stop)
											{
												num15--;
												Thread.Sleep(1000);
												try
												{
													thongtin[dem_acc4 + 1].TrangThai = "Waiting Run => " + num15 + " s";
													Change_Row(thongtin[dem_acc4 + 1]);
												}
												catch
												{
													break;
												}
											}
										}
										Task.WaitAll(list5.ToArray());
										foreach (int item11 in sx3)
										{
											Poin.FillIndexPossition(ref lstPossition, item11);
										}
										sx3.Clear();
										if (!Stop.stop && dem_acc4 + 1 != thongtin.Count)
										{
											proxy2 = changeIP_shoplike(shoplike, check: false, thongtin[dem_acc4]);
											if (string.IsNullOrEmpty(proxy2))
											{
												thongtin[dem_acc4].TrangThai = "Error getting proxy key => " + item4;
												Change_Row(thongtin[dem_acc4]);
												break;
											}
										}
									}
								});
								task4.Start();
								Thread.Sleep(TimeSpan.FromSeconds(time3 * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP + time3));
							}
						}
						Thread.Sleep(5000);
						Task.WaitAll(L_Task3.ToArray());
					}
					else if (ThongSo_CauHinhDoiIP.rad_ChangIP_Xproxy)
					{
						int num5 = -1;
						int dem_acc3 = -1;
						int time2 = r.Next(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
						List<Task> L_Task2 = new List<Task>();
						foreach (string item12 in ThongSo_CauHinhDoiIP.rtb_Xproxy_Proxy)
						{
							num5++;
							if (Stop.stop || num5 == thongtin.Count)
							{
								break;
							}
							string item3 = (ThongSo_CauHinhDoiIP.rad_Xproxy_Sock5 ? ("1|" + item12) : item12);
							List<int> sx2 = new List<int>();
							Task task5 = new Task(delegate
							{
								while (dem_thread < thongtin.Count && !Stop.stop)
								{
									List<Task> list4 = new List<Task>();
									for (int m = 0; m < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; m++)
									{
										if (Stop.stop)
										{
											break;
										}
										if (dem_thread >= thongtin.Count)
										{
											break;
										}
										int num11 = dem_thread;
										dem_thread = num11 + 1;
										Task task9 = new Task(delegate
										{
											int num13 = dem_acc3;
											dem_acc3 = num13 + 1;
											thongtin[dem_acc3].proxy = item3;
											int indexOfPossitionApp4 = Poin.GetIndexOfPossitionApp(ref lstPossition);
											sx2.Add(indexOfPossitionApp4);
											Selenium selenium3 = new Selenium(thongtin[dem_acc3], indexOfPossitionApp4, dem_acc3 + 1, Use_Proxy: true);
											selenium3.Run();
										});
										task9.Start();
										list4.Add(task9);
										L_Task2.Add(task9);
										int num12 = time2;
										while (num12 > 0 && !Stop.stop && dem_acc3 + 1 != thongtin.Count && !Stop.stop)
										{
											num12--;
											Thread.Sleep(1000);
											try
											{
												thongtin[dem_acc3 + 1].TrangThai = "Waiting Run => " + num12 + " s";
												Change_Row(thongtin[dem_acc3 + 1]);
											}
											catch
											{
												break;
											}
										}
									}
									Task.WaitAll(list4.ToArray());
									foreach (int item13 in sx2)
									{
										Poin.FillIndexPossition(ref lstPossition, item13);
									}
									sx2.Clear();
									if (!Stop.stop && dem_acc3 + 1 != thongtin.Count && !ChangeIP_Xproxy(item3))
									{
										thongtin[dem_acc3].TrangThai = "Error Reset proxy => " + item3;
										Change_Row(thongtin[dem_acc3]);
										break;
									}
								}
							});
							task5.Start();
							Thread.Sleep(TimeSpan.FromSeconds(time2 * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP));
							int num6 = time2;
							while (num6 > 0 && !Stop.stop && dem_acc3 + 1 != thongtin.Count && !Stop.stop)
							{
								num6--;
								Thread.Sleep(1000);
								try
								{
									thongtin[dem_acc3 + 1].TrangThai = "Waiting Run => " + num6 + " s";
									Change_Row(thongtin[dem_acc3 + 1]);
								}
								catch
								{
									goto IL_0708;
								}
							}
							IL_0708:;
						}
						Thread.Sleep(5000);
						Task.WaitAll(L_Task2.ToArray());
					}
					else if (ThongSo_CauHinhDoiIP.rad_ChangIP_Minproxy)
					{
						int num7 = 0;
						int dem_acc2 = -1;
						int time = r.Next(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
						List<Task> L_Task = new List<Task>();
						foreach (string item14 in ThongSo_CauHinhDoiIP.rtb_KeyMinproxy)
						{
							if (!string.IsNullOrEmpty(item14.Trim()))
							{
								if (Stop.stop || num7 == thongtin.Count)
								{
									break;
								}
								num7++;
								string item2 = item14;
								List<int> sx = new List<int>();
								API_Minproxy API_Minproxy = new API_Minproxy(item2);
								string proxy = ((ThongSo_CauHinhDoiIP.cbb_SelecTypeIP != 1) ? API_Minproxy.NewIP_dancu()?.data.http_proxy_ipv4 : API_Minproxy.NewIP_V6()?.data.http_proxy);
								if (string.IsNullOrEmpty(proxy))
								{
									MessageBox.Show("Lấy proxy thất bại (Proxy fetch failed) ! \nKey : " + item2);
									Stop.stop = true;
								}
								Task task6 = new Task(delegate
								{
									while (dem_thread < thongtin.Count && !Stop.stop)
									{
										List<Task> list3 = new List<Task>();
										for (int l = 0; l < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; l++)
										{
											if (Stop.stop)
											{
												break;
											}
											if (dem_thread >= thongtin.Count)
											{
												break;
											}
											int num8 = dem_thread;
											dem_thread = num8 + 1;
											Task task8 = new Task(delegate
											{
												int num10 = dem_acc2;
												dem_acc2 = num10 + 1;
												thongtin[dem_acc2].proxy = proxy;
												int indexOfPossitionApp3 = Poin.GetIndexOfPossitionApp(ref lstPossition);
												sx.Add(indexOfPossitionApp3);
												Selenium selenium2 = new Selenium(thongtin[dem_acc2], indexOfPossitionApp3, dem_acc2 + 1, Use_Proxy: true);
												selenium2.Run();
											});
											task8.Start();
											list3.Add(task8);
											L_Task.Add(task8);
											int num9 = time;
											while (num9 > 0 && !Stop.stop && dem_acc2 + 1 != thongtin.Count && !Stop.stop)
											{
												num9--;
												Thread.Sleep(1000);
												try
												{
													thongtin[dem_acc2 + 1].TrangThai = "Waiting Run => " + num9 + " s";
													Change_Row(thongtin[dem_acc2 + 1]);
												}
												catch
												{
													break;
												}
											}
										}
										Task.WaitAll(list3.ToArray());
										foreach (int item15 in sx)
										{
											Poin.FillIndexPossition(ref lstPossition, item15);
										}
										sx.Clear();
										if (!Stop.stop && dem_acc2 + 1 != thongtin.Count)
										{
											proxy = changeIP_Min(API_Minproxy, thongtin[dem_acc2])?.data.http_proxy;
											if (string.IsNullOrEmpty(proxy))
											{
												thongtin[dem_acc2].TrangThai = "Error getting proxy key => " + item2;
												Change_Row(thongtin[dem_acc2]);
												break;
											}
										}
									}
								});
								task6.Start();
								Thread.Sleep(TimeSpan.FromSeconds(time * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP + time));
							}
						}
						Thread.Sleep(5000);
						Task.WaitAll(L_Task.ToArray());
					}
					else
					{
						int dem_acc = 0;
						List<Task> list2 = new List<Task>();
						foreach (ThongTin item16 in thongtin)
						{
							if (Stop.stop)
							{
								break;
							}
							int num2 = dem_acc;
							dem_acc = num2 + 1;
							dem_thread++;
							ThongTin item = item16;
							Task task7 = new Task(delegate
							{
								int indexOfPossitionApp2 = Poin.GetIndexOfPossitionApp(ref lstPossition);
								Selenium selenium = new Selenium(item, indexOfPossitionApp2, dem_acc);
								selenium.Run();
							});
							task7.Start();
							list2.Add(task7);
							Deley(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
							if (!Stop.stop && dem_thread == ThongSo_CauHinhDoiIP.num_Thread_ChangeIP)
							{
								Task.WaitAll(list2.ToArray());
								changip.change();
								list2.Clear();
								dem_thread = 0;
							}
						}
						Thread.Sleep(5000);
						Task.WaitAll(list2.ToArray());
						for (int k = 0; k < lstPossition.Count; k++)
						{
							Poin.FillIndexPossition(ref lstPossition, k);
						}
					}
					BeginInvoke((MethodInvoker)delegate
					{
						btn_start.Enabled = true;
						lb_Loading.Enabled = false;
						btn_stop.Enabled = false;
					});
				});
				task.Start();
			}
			else
			{
				MessageBox.Show("Please select the account to run !");
			}
			Thread.Sleep(1000);
		}

		private void ctx_DeleteProfile_Click(object sender, EventArgs e)
		{
			try
			{
				string text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp";
				SQLite sQLite = new SQLite();
				List<ThongTin> list = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
				if (list.Count == 0)
				{
					MessageBox.Show("Please select the account to delete !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				foreach (ThongTin item in list)
				{
					try
					{
						new DirectoryInfo(text + "\\" + item.User).Delete(recursive: true);
					}
					catch
					{
					}
				}
				MessageBox.Show("Delete proflie - Success !");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void groupBox3_Enter(object sender, EventArgs e)
		{
		}

		private void button2_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void btnMinimize_Click(object sender, EventArgs e)
		{
			KillProcess("chromedriver");
			Environment.Exit(0);
		}

		public void KillProcess(string nameProcess)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName(nameProcess);
				foreach (Process process in processesByName)
				{
					process.Kill();
				}
			}
			catch
			{
			}
		}

		private void toolStripMenuItem_29_Click(object sender, EventArgs e)
		{
			CauHinhHienThi cauHinhHienThi = new CauHinhHienThi();
			cauHinhHienThi.ShowDialog();
			Load_Data_dgv();
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			CauHinhTuongTac cauHinhTuongTac = new CauHinhTuongTac();
			cauHinhTuongTac.ShowDialog();
		}

		private void mnuCauHinhChung_Click(object sender, EventArgs e)
		{
			CauHinhDoiIP cauHinhDoiIP = new CauHinhDoiIP();
			cauHinhDoiIP.ShowDialog();
		}

		private void writeProxyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
			if (list.Count == 0)
			{
				MessageBox.Show("Please select the account to add proxy !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			NhapProxy nhapProxy = new NhapProxy(0, list);
			nhapProxy.ShowDialog();
		}

		private void toolStripMenuItem_49_Click(object sender, EventArgs e)
		{
			if (contect.LH == 0)
			{
				Process.Start("https://zalo.me/g/vmrbwf745");
			}
			else if (contect.LH == 1)
			{
				Process.Start("https://zalo.me/g/vmrbwf745");
			}
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
			using StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
			foreach (ThongTin item in list)
			{
				streamWriter.WriteLine(item.User + "|" + item.Pass + "|" + item.cookie + "|" + item.Mail + "|" + item.Pass_Mail);
			}
		}

		private void ctx_OpenProfile_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> thongtin = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
			int dem_acc = 0;
			if (thongtin.Count != 0)
			{
				lb_Loading.Enabled = true;
			}
			int num = 0;
			List<int> lstPossition = new List<int>();
			num = (ThongSo_CauHinhDoiIP.rad_ChangIP_Minproxy ? (ThongSo_CauHinhDoiIP.rtb_KeyMinproxy.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP) : (ThongSo_CauHinhDoiIP.rad_ChangIP_ShopLike ? (ThongSo_CauHinhDoiIP.rtb_KeyShoplike.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP) : (ThongSo_CauHinhDoiIP.rad_ChangIP_Tinsoft ? (ThongSo_CauHinhDoiIP.rtb_KeyTinsoft.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP) : ((!ThongSo_CauHinhDoiIP.rad_ChangIP_Xproxy) ? ThongSo_CauHinhDoiIP.num_Thread_ChangeIP : (ThongSo_CauHinhDoiIP.rtb_Xproxy_Proxy.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP)))));
			for (int i = 0; i < num; i++)
			{
				lstPossition.Add(0);
			}
			Task task = new Task(delegate
			{
				List<Task> list = new List<Task>();
				foreach (ThongTin item in thongtin)
				{
					dem_acc++;
					Task task2 = new Task(delegate
					{
						int indexOfPossitionApp = Poin.GetIndexOfPossitionApp(ref lstPossition);
						Selenium selenium = new Selenium(item, indexOfPossitionApp, dem_acc);
						selenium.Run_Chrome();
					});
					task2.Start();
					list.Add(task2);
				}
				Task.WaitAll(list.ToArray());
				for (int j = 0; j < lstPossition.Count; j++)
				{
					Poin.FillIndexPossition(ref lstPossition, j);
				}
				BeginInvoke((MethodInvoker)delegate
				{
					lb_Loading.Enabled = false;
				});
			});
			task.Start();
		}

		private void CreateShortcut()
		{
			string text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\maikhanh6635";
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			WshShell wshShell = (WshShell)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")));
			string pathLink = Path.Combine(folderPath, "maikhanh6635.lnk");
			IWshShortcut wshShortcut = (IWshShortcut)(dynamic)wshShell.CreateShortcut(pathLink);
			wshShortcut.Description = "Shortcut Chrome";
			wshShortcut.WorkingDirectory = "C:\\Program Files (x86)\\Google\\Chrome\\Application";
			wshShortcut.IconLocation = "instagram-_2_.ico";
			wshShortcut.TargetPath = "\"C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe\"";
			wshShortcut.Arguments = "user-data-dir=" + text;
			wshShortcut.Save();
		}

		private void ctx_CreadtSC_Click(object sender, EventArgs e)
		{
			CreateShortcut();
		}

		private void btnPost_Click(object sender, EventArgs e)
		{
			Inswfb inswfb = new Inswfb();
			inswfb.Show();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName("chromedriver");
				foreach (Process process in processesByName)
				{
					process.Kill();
				}
			}
			catch
			{
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
			if (list.Count == 0)
			{
				MessageBox.Show("Please select the account to add proxy !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			NhapProxy nhapProxy = new NhapProxy(0, list);
			nhapProxy.ShowDialog();
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Load_dgvacc();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			nhaptaikhoan nhaptaikhoan2 = new nhaptaikhoan(0);
			nhaptaikhoan2.Show();
		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{
		}

		private void ctx_settingCP_Click(object sender, EventArgs e)
		{
			Setting_CP setting_CP = new Setting_CP();
			setting_CP.ShowDialog();
		}

		private void ctx_checkpoinHotmail_Click(object sender, EventArgs e)
		{
			Poin.dem = 0;
			Stop.stop = false;
			Load_SettingCP();
			Load_CauHinhTuongTac();
			Load_CauHinhDoiIP();
			SQLite sQLite = new SQLite();
			Random r = new Random();
			ChangeIP changip = new ChangeIP();
			int dem_thread = 0;
			List<ThongTin> thongtin = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
			if (thongtin.Count != 0)
			{
				btn_start.Enabled = false;
				lb_Loading.Enabled = true;
				btn_stop.Enabled = true;
				int num = 0;
				List<int> lstPossition = new List<int>();
				num = (ThongSo_CauHinhDoiIP.rad_ChangIP_Minproxy ? (ThongSo_CauHinhDoiIP.rtb_KeyMinproxy.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP) : (ThongSo_CauHinhDoiIP.rad_ChangIP_ShopLike ? (ThongSo_CauHinhDoiIP.rtb_KeyShoplike.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP) : (ThongSo_CauHinhDoiIP.rad_ChangIP_Tinsoft ? (ThongSo_CauHinhDoiIP.rtb_KeyTinsoft.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP) : ((!ThongSo_CauHinhDoiIP.rad_ChangIP_Xproxy) ? ThongSo_CauHinhDoiIP.num_Thread_ChangeIP : (ThongSo_CauHinhDoiIP.rtb_Xproxy_Proxy.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP)))));
				for (int i = 0; i < num; i++)
				{
					lstPossition.Add(0);
				}
				Task task = new Task(delegate
				{
					if (ThongSo_CauHinhDoiIP.rad_ChangIP_Proxy)
					{
						int dem_acc6 = 0;
						List<Task> list = new List<Task>();
						foreach (ThongTin _item2 in thongtin)
						{
							ThongTin item6 = _item2;
							if (Stop.stop)
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
								int num2 = dem_acc6;
								dem_acc6 = num2 + 1;
								Task task2 = new Task(delegate
								{
									int indexOfPossitionApp6 = Poin.GetIndexOfPossitionApp(ref lstPossition);
									Selenium selenium6 = new Selenium(item6, indexOfPossitionApp6, dem_acc6, Use_Proxy: true);
									selenium6.Open_CP(_item2.Mail, _item2.Pass_Mail);
								});
								task2.Start();
								list.Add(task2);
								Deley(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
								if (!Stop.stop && dem_thread == ThongSo_CauHinhDoiIP.num_Thread_ChangeIP)
								{
									Task.WaitAll(list.ToArray());
									for (int j = 0; j < lstPossition.Count; j++)
									{
										Poin.FillIndexPossition(ref lstPossition, j);
									}
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
						int dem_acc5 = -1;
						int time4 = r.Next(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
						List<Task> L_Task4 = new List<Task>();
						foreach (string item7 in ThongSo_CauHinhDoiIP.rtb_KeyTinsoft)
						{
							List<int> sx4 = new List<int>();
							int num2 = dem_key;
							dem_key = num2 + 1;
							if (Stop.stop || dem_key == thongtin.Count)
							{
								break;
							}
							string item5 = item7;
							Task task3 = new Task(delegate
							{
								string proxy3 = "";
								API_Tinsoft aPI_Tinsoft = new API_Tinsoft(item5);
								check_ip check_ip2 = aPI_Tinsoft.checkip();
								if (check_ip2 == null)
								{
									MessageBox.Show("check key tinsoft ( kiểm tra lại key tinsoft ) ! \nKey : " + item5);
									Stop.stop = true;
								}
								if (check_ip2.success && check_ip2.next_change == "0")
								{
									proxy3 = aPI_Tinsoft.NewIP().proxy;
								}
								else if (check_ip2.success)
								{
									int num17 = int.Parse(check_ip2.next_change) + 5;
									while (!Stop.stop && num17 > 0 && !Stop.stop)
									{
										num17--;
										Thread.Sleep(1000);
										try
										{
											thongtin[dem_key].TrangThai = "Waiting Get IP => " + num17 + " s";
											Change_Row(thongtin[dem_key]);
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
									MessageBox.Show("Lấy proxy thất bại (Proxy fetch failed) ! \nKey : " + item5);
									Stop.stop = true;
								}
								while (dem_thread < thongtin.Count && !Stop.stop)
								{
									List<Task> list6 = new List<Task>();
									for (int num18 = 0; num18 < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; num18++)
									{
										if (Stop.stop || dem_thread >= thongtin.Count)
										{
											break;
										}
										int num19 = dem_thread;
										dem_thread = num19 + 1;
										int indexOfPossitionApp5 = Poin.GetIndexOfPossitionApp(ref lstPossition);
										sx4.Add(indexOfPossitionApp5);
										Task task11 = new Task(delegate
										{
											int num21 = dem_acc5;
											dem_acc5 = num21 + 1;
											thongtin[dem_acc5].proxy = proxy3;
											Selenium selenium5 = new Selenium(thongtin[dem_acc5], indexOfPossitionApp5, dem_acc5 + 1, Use_Proxy: true);
											selenium5.Open_CP(thongtin[dem_acc5].Mail, thongtin[dem_acc5].Pass_Mail);
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
												thongtin[dem_acc5 + 1].TrangThai = "Waiting Run => " + num20 + " s";
												Change_Row(thongtin[dem_acc5 + 1]);
											}
											catch
											{
												break;
											}
										}
									}
									Task.WaitAll(list6.ToArray());
									foreach (int item8 in sx4)
									{
										Poin.FillIndexPossition(ref lstPossition, item8);
									}
									sx4.Clear();
									if (!Stop.stop && dem_acc5 + 1 != thongtin.Count)
									{
										proxy3 = changeIP(aPI_Tinsoft, thongtin[dem_acc5])?.proxy;
										if (string.IsNullOrEmpty(proxy3))
										{
											thongtin[dem_acc5].TrangThai = "Error getting proxy key => " + item5;
											Change_Row(thongtin[dem_acc5]);
											break;
										}
									}
								}
							});
							task3.Start();
							Thread.Sleep(TimeSpan.FromSeconds(time4 * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP));
							int num3 = time4;
							while (num3 > 0 && !Stop.stop && dem_acc5 + 1 != thongtin.Count)
							{
								num3--;
								Thread.Sleep(1000);
								try
								{
									thongtin[dem_acc5 + 1].TrangThai = "Waiting Run => " + num3 + " s";
									Change_Row(thongtin[dem_acc5 + 1]);
								}
								catch
								{
									goto IL_03b4;
								}
							}
							IL_03b4:;
						}
						Task.WaitAll(L_Task4.ToArray());
					}
					else if (ThongSo_CauHinhDoiIP.rad_ChangIP_ShopLike)
					{
						int num4 = 0;
						int dem_acc4 = -1;
						int time3 = r.Next(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
						List<Task> L_Task3 = new List<Task>();
						foreach (string item9 in ThongSo_CauHinhDoiIP.rtb_KeyShoplike)
						{
							if (Stop.stop || num4 == thongtin.Count)
							{
								break;
							}
							num4++;
							string item4 = item9;
							List<int> sx3 = new List<int>();
							Task task4 = new Task(delegate
							{
								ShopLike shoplike = new ShopLike(item4);
								string proxy2 = changeIP_shoplike(shoplike, check: true);
								if (string.IsNullOrEmpty(proxy2))
								{
									MessageBox.Show("Lấy proxy thất bại (Proxy fetch failed) ! \nKey : " + item4);
									Stop.stop = true;
								}
								while (dem_thread < thongtin.Count && !Stop.stop)
								{
									List<Task> list5 = new List<Task>();
									for (int n = 0; n < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; n++)
									{
										if (Stop.stop)
										{
											break;
										}
										if (dem_thread >= thongtin.Count)
										{
											break;
										}
										int num14 = dem_thread;
										dem_thread = num14 + 1;
										Task task10 = new Task(delegate
										{
											int num16 = dem_acc4;
											dem_acc4 = num16 + 1;
											thongtin[dem_acc4].proxy = proxy2;
											int indexOfPossitionApp4 = Poin.GetIndexOfPossitionApp(ref lstPossition);
											sx3.Add(indexOfPossitionApp4);
											Selenium selenium4 = new Selenium(thongtin[dem_acc4], indexOfPossitionApp4, dem_acc4 + 1, Use_Proxy: true);
											selenium4.Open_CP(thongtin[dem_acc4].Mail, thongtin[dem_acc4].Pass_Mail);
										});
										task10.Start();
										list5.Add(task10);
										L_Task3.Add(task10);
										int num15 = time3;
										while (num15 > 0 && dem_acc4 + 1 != thongtin.Count)
										{
											num15--;
											Thread.Sleep(1000);
											try
											{
												thongtin[dem_acc4 + 1].TrangThai = "Waiting Run => " + num15 + " s";
												Change_Row(thongtin[dem_acc4 + 1]);
											}
											catch
											{
												break;
											}
										}
									}
									Task.WaitAll(list5.ToArray());
									foreach (int item10 in sx3)
									{
										Poin.FillIndexPossition(ref lstPossition, item10);
									}
									sx3.Clear();
									if (!Stop.stop && dem_acc4 + 1 != thongtin.Count)
									{
										proxy2 = changeIP_shoplike(shoplike, check: false, thongtin[dem_acc4]);
									}
								}
							});
							task4.Start();
							Thread.Sleep(TimeSpan.FromSeconds(time3 * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP + time3));
						}
						Task.WaitAll(L_Task3.ToArray());
					}
					else if (ThongSo_CauHinhDoiIP.rad_ChangIP_Xproxy)
					{
						int num5 = -1;
						int dem_acc3 = -1;
						int time2 = r.Next(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
						List<Task> L_Task2 = new List<Task>();
						foreach (string item11 in ThongSo_CauHinhDoiIP.rtb_Xproxy_Proxy)
						{
							List<int> sx2 = new List<int>();
							num5++;
							if (Stop.stop || num5 == thongtin.Count)
							{
								break;
							}
							string item3 = (ThongSo_CauHinhDoiIP.rad_Xproxy_Sock5 ? ("1|" + item11) : item11);
							Task task5 = new Task(delegate
							{
								while (dem_thread < thongtin.Count && !Stop.stop)
								{
									List<Task> list4 = new List<Task>();
									for (int m = 0; m < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; m++)
									{
										if (Stop.stop)
										{
											break;
										}
										if (dem_thread >= thongtin.Count)
										{
											break;
										}
										int num11 = dem_thread;
										dem_thread = num11 + 1;
										Task task9 = new Task(delegate
										{
											int num13 = dem_acc3;
											dem_acc3 = num13 + 1;
											thongtin[dem_acc3].proxy = item3;
											int indexOfPossitionApp3 = Poin.GetIndexOfPossitionApp(ref lstPossition);
											sx2.Add(indexOfPossitionApp3);
											Selenium selenium3 = new Selenium(thongtin[dem_acc3], indexOfPossitionApp3, dem_acc3 + 1, Use_Proxy: true);
											selenium3.Open_CP(thongtin[dem_acc3].Mail, thongtin[dem_acc3].Pass_Mail);
										});
										task9.Start();
										list4.Add(task9);
										L_Task2.Add(task9);
										int num12 = time2;
										while (!Stop.stop && num12 > 0 && dem_acc3 + 1 != thongtin.Count)
										{
											num12--;
											Thread.Sleep(1000);
											try
											{
												thongtin[dem_acc3 + 1].TrangThai = "Waiting Run => " + num12 + " s";
												Change_Row(thongtin[dem_acc3 + 1]);
											}
											catch
											{
												break;
											}
										}
									}
									Task.WaitAll(list4.ToArray());
									foreach (int item12 in sx2)
									{
										Poin.FillIndexPossition(ref lstPossition, item12);
									}
									sx2.Clear();
									if (!Stop.stop && dem_acc3 + 1 != thongtin.Count && !ChangeIP_Xproxy(item3))
									{
										thongtin[dem_acc3].TrangThai = "Error Reset proxy => " + item3;
										Change_Row(thongtin[dem_acc3]);
										break;
									}
								}
							});
							task5.Start();
							Thread.Sleep(TimeSpan.FromSeconds(time2 * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP));
							int num6 = time2;
							while (num6 > 0 && !Stop.stop && dem_acc3 + 1 != thongtin.Count)
							{
								num6--;
								Thread.Sleep(1000);
								try
								{
									thongtin[dem_acc3 + 1].TrangThai = "Waiting Run => " + num6 + " s";
									Change_Row(thongtin[dem_acc3 + 1]);
								}
								catch
								{
									goto IL_06e6;
								}
							}
							IL_06e6:;
						}
						Task.WaitAll(L_Task2.ToArray());
					}
					else if (ThongSo_CauHinhDoiIP.rad_ChangIP_Minproxy)
					{
						int num7 = 0;
						int dem_acc2 = -1;
						int time = r.Next(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
						List<Task> L_Task = new List<Task>();
						foreach (string item13 in ThongSo_CauHinhDoiIP.rtb_KeyMinproxy)
						{
							if (Stop.stop || num7 == thongtin.Count)
							{
								break;
							}
							num7++;
							string item2 = item13;
							List<int> sx = new List<int>();
							Task task6 = new Task(delegate
							{
								API_Minproxy aPI_Minproxy = new API_Minproxy(item2);
								string proxy = ((ThongSo_CauHinhDoiIP.cbb_SelecTypeIP != 1) ? aPI_Minproxy.NewIP_dancu()?.data.http_proxy_ipv4 : aPI_Minproxy.NewIP_V6()?.data.http_proxy);
								if (string.IsNullOrEmpty(proxy))
								{
									MessageBox.Show("Lấy proxy thất bại (Proxy fetch failed) ! \nKey : " + item2);
									Stop.stop = true;
								}
								while (dem_thread < thongtin.Count && !Stop.stop)
								{
									List<Task> list3 = new List<Task>();
									for (int l = 0; l < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; l++)
									{
										if (Stop.stop)
										{
											break;
										}
										if (dem_thread >= thongtin.Count)
										{
											break;
										}
										int num8 = dem_thread;
										dem_thread = num8 + 1;
										Task task8 = new Task(delegate
										{
											int num10 = dem_acc2;
											dem_acc2 = num10 + 1;
											thongtin[dem_acc2].proxy = proxy;
											int indexOfPossitionApp2 = Poin.GetIndexOfPossitionApp(ref lstPossition);
											sx.Add(indexOfPossitionApp2);
											Selenium selenium2 = new Selenium(thongtin[dem_acc2], indexOfPossitionApp2, dem_acc2 + 1, Use_Proxy: true);
											selenium2.Open_CP(thongtin[dem_acc2].Mail, thongtin[dem_acc2].Pass_Mail);
										});
										task8.Start();
										list3.Add(task8);
										L_Task.Add(task8);
										int num9 = time;
										while (!Stop.stop && num9 > 0 && dem_acc2 + 1 != thongtin.Count)
										{
											num9--;
											Thread.Sleep(1000);
											try
											{
												thongtin[dem_acc2 + 1].TrangThai = "Waiting Run => " + num9 + " s";
												Change_Row(thongtin[dem_acc2 + 1]);
											}
											catch
											{
												break;
											}
										}
									}
									Task.WaitAll(list3.ToArray());
									if (!Stop.stop && dem_acc2 + 1 != thongtin.Count)
									{
										proxy = changeIP_Min(aPI_Minproxy, thongtin[dem_acc2])?.data.http_proxy;
										if (string.IsNullOrEmpty(proxy))
										{
											thongtin[dem_acc2].TrangThai = "Error getting proxy key => " + item2;
											Change_Row(thongtin[dem_acc2]);
											break;
										}
									}
								}
							});
							task6.Start();
							Thread.Sleep(TimeSpan.FromSeconds(time * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP + time));
						}
						Task.WaitAll(L_Task.ToArray());
					}
					else
					{
						int dem_acc = 0;
						List<Task> list2 = new List<Task>();
						foreach (ThongTin _item in thongtin)
						{
							if (Stop.stop)
							{
								break;
							}
							dem_thread++;
							int num2 = dem_acc;
							dem_acc = num2 + 1;
							ThongTin item = _item;
							Task task7 = new Task(delegate
							{
								int indexOfPossitionApp = Poin.GetIndexOfPossitionApp(ref lstPossition);
								Selenium selenium = new Selenium(item, indexOfPossitionApp, dem_acc);
								selenium.Open_CP(_item.Mail, _item.Pass_Mail);
							});
							task7.Start();
							list2.Add(task7);
							Deley(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
							if (!Stop.stop && dem_thread == ThongSo_CauHinhDoiIP.num_Thread_ChangeIP)
							{
								Task.WaitAll(list2.ToArray());
								for (int k = 0; k < lstPossition.Count; k++)
								{
									Poin.FillIndexPossition(ref lstPossition, k);
								}
								changip.change();
								list2.Clear();
								dem_thread = 0;
							}
						}
						Task.WaitAll(list2.ToArray());
					}
					BeginInvoke((MethodInvoker)delegate
					{
						btn_start.Enabled = true;
						lb_Loading.Enabled = false;
						btn_stop.Enabled = false;
					});
				});
				task.Start();
			}
			else
			{
				MessageBox.Show("Please select the account to run !");
			}
			Thread.Sleep(1000);
		}

		private void ctx_checkpoinMailDomain_Click(object sender, EventArgs e)
		{
			Poin.dem = 0;
			Stop.stop = false;
			Load_SettingCP();
			Load_CauHinhTuongTac();
			Load_CauHinhDoiIP();
			SQLite sQLite = new SQLite();
			Random r = new Random();
			ChangeIP changip = new ChangeIP();
			int dem_thread = 0;
			List<ThongTin> thongtin = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
			if (thongtin.Count != 0)
			{
				btn_start.Enabled = false;
				lb_Loading.Enabled = true;
				btn_stop.Enabled = true;
				int num = 0;
				List<int> lstPossition = new List<int>();
				num = (ThongSo_CauHinhDoiIP.rad_ChangIP_Minproxy ? (ThongSo_CauHinhDoiIP.rtb_KeyMinproxy.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP) : (ThongSo_CauHinhDoiIP.rad_ChangIP_ShopLike ? (ThongSo_CauHinhDoiIP.rtb_KeyShoplike.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP) : (ThongSo_CauHinhDoiIP.rad_ChangIP_Tinsoft ? (ThongSo_CauHinhDoiIP.rtb_KeyTinsoft.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP) : ((!ThongSo_CauHinhDoiIP.rad_ChangIP_Xproxy) ? ThongSo_CauHinhDoiIP.num_Thread_ChangeIP : (ThongSo_CauHinhDoiIP.rtb_Xproxy_Proxy.Count * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP)))));
				for (int i = 0; i < num; i++)
				{
					lstPossition.Add(0);
				}
				Task task = new Task(delegate
				{
					if (ThongSo_CauHinhDoiIP.rad_ChangIP_Proxy)
					{
						int dem_acc6 = 0;
						List<Task> list = new List<Task>();
						foreach (ThongTin item7 in thongtin)
						{
							ThongTin item6 = item7;
							if (Stop.stop)
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
								int num2 = dem_acc6;
								dem_acc6 = num2 + 1;
								Task task2 = new Task(delegate
								{
									int indexOfPossitionApp6 = Poin.GetIndexOfPossitionApp(ref lstPossition);
									Selenium selenium6 = new Selenium(item6, indexOfPossitionApp6, dem_acc6, Use_Proxy: true);
									selenium6.Open_CP(ThongSo_SettingCP.txt_hotmail, ThongSo_SettingCP.txt_PassHotmail);
								});
								task2.Start();
								list.Add(task2);
								Deley(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
								if (!Stop.stop && dem_thread == ThongSo_CauHinhDoiIP.num_Thread_ChangeIP)
								{
									Task.WaitAll(list.ToArray());
									for (int j = 0; j < lstPossition.Count; j++)
									{
										Poin.FillIndexPossition(ref lstPossition, j);
									}
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
						int dem_acc5 = -1;
						int time4 = r.Next(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
						List<Task> L_Task4 = new List<Task>();
						foreach (string item8 in ThongSo_CauHinhDoiIP.rtb_KeyTinsoft)
						{
							List<int> sx4 = new List<int>();
							int num2 = dem_key;
							dem_key = num2 + 1;
							if (Stop.stop || dem_key == thongtin.Count)
							{
								break;
							}
							string item5 = item8;
							Task task3 = new Task(delegate
							{
								string proxy3 = "";
								API_Tinsoft aPI_Tinsoft = new API_Tinsoft(item5);
								check_ip check_ip2 = aPI_Tinsoft.checkip();
								if (check_ip2 == null)
								{
									MessageBox.Show("check key tinsoft ( kiểm tra lại key tinsoft ) ! \nKey : " + item5);
									Stop.stop = true;
								}
								if (check_ip2.success && check_ip2.next_change == "0")
								{
									proxy3 = aPI_Tinsoft.NewIP().proxy;
								}
								else if (check_ip2.success)
								{
									int num17 = int.Parse(check_ip2.next_change) + 5;
									while (num17 > 0 && !Stop.stop)
									{
										num17--;
										Thread.Sleep(1000);
										try
										{
											thongtin[dem_key].TrangThai = "Waiting Get IP => " + num17 + " s";
											Change_Row(thongtin[dem_key]);
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
									MessageBox.Show("Lấy proxy thất bại (Proxy fetch failed) ! \nKey : " + item5);
									Stop.stop = true;
								}
								while (dem_thread < thongtin.Count && !Stop.stop)
								{
									List<Task> list6 = new List<Task>();
									for (int num18 = 0; num18 < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; num18++)
									{
										if (Stop.stop || dem_thread >= thongtin.Count)
										{
											break;
										}
										int num19 = dem_thread;
										dem_thread = num19 + 1;
										int indexOfPossitionApp5 = Poin.GetIndexOfPossitionApp(ref lstPossition);
										sx4.Add(indexOfPossitionApp5);
										Task task11 = new Task(delegate
										{
											int num21 = dem_acc5;
											dem_acc5 = num21 + 1;
											thongtin[dem_acc5].proxy = proxy3;
											Selenium selenium5 = new Selenium(thongtin[dem_acc5], indexOfPossitionApp5, dem_acc5 + 1, Use_Proxy: true);
											selenium5.Open_CP(ThongSo_SettingCP.txt_hotmail, ThongSo_SettingCP.txt_PassHotmail);
										});
										task11.Start();
										list6.Add(task11);
										L_Task4.Add(task11);
										int num20 = time4;
										while (num20 > 0 && dem_acc5 + 1 != thongtin.Count)
										{
											num20--;
											Thread.Sleep(1000);
											try
											{
												thongtin[dem_acc5 + 1].TrangThai = "Waiting Run => " + num20 + " s";
												Change_Row(thongtin[dem_acc5 + 1]);
											}
											catch
											{
												break;
											}
										}
									}
									Task.WaitAll(list6.ToArray());
									foreach (int item9 in sx4)
									{
										Poin.FillIndexPossition(ref lstPossition, item9);
									}
									sx4.Clear();
									if (!Stop.stop && dem_acc5 + 1 != thongtin.Count)
									{
										proxy3 = changeIP(aPI_Tinsoft, thongtin[dem_acc5])?.proxy;
										if (string.IsNullOrEmpty(proxy3))
										{
											thongtin[dem_acc5].TrangThai = "Error getting proxy key => " + item5;
											Change_Row(thongtin[dem_acc5]);
											break;
										}
									}
								}
							});
							task3.Start();
							Thread.Sleep(TimeSpan.FromSeconds(time4 * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP));
							int num3 = time4;
							while (num3 > 0 && !Stop.stop && dem_acc5 + 1 != thongtin.Count)
							{
								num3--;
								Thread.Sleep(1000);
								try
								{
									thongtin[dem_acc5 + 1].TrangThai = "Waiting Run => " + num3 + " s";
									Change_Row(thongtin[dem_acc5 + 1]);
								}
								catch
								{
									goto IL_038b;
								}
							}
							IL_038b:;
						}
						Task.WaitAll(L_Task4.ToArray());
					}
					else if (ThongSo_CauHinhDoiIP.rad_ChangIP_ShopLike)
					{
						int num4 = 0;
						int dem_acc4 = -1;
						int time3 = r.Next(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
						List<Task> L_Task3 = new List<Task>();
						foreach (string item10 in ThongSo_CauHinhDoiIP.rtb_KeyShoplike)
						{
							if (Stop.stop || num4 == thongtin.Count)
							{
								break;
							}
							num4++;
							string item4 = item10;
							List<int> sx3 = new List<int>();
							Task task4 = new Task(delegate
							{
								ShopLike shoplike = new ShopLike(item4);
								string proxy2 = changeIP_shoplike(shoplike, check: true);
								if (string.IsNullOrEmpty(proxy2))
								{
									MessageBox.Show("Lấy proxy thất bại (Proxy fetch failed) ! \nKey : " + item4);
									Stop.stop = true;
								}
								while (dem_thread < thongtin.Count && !Stop.stop)
								{
									List<Task> list5 = new List<Task>();
									for (int n = 0; n < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; n++)
									{
										if (Stop.stop)
										{
											break;
										}
										if (dem_thread >= thongtin.Count)
										{
											break;
										}
										int num14 = dem_thread;
										dem_thread = num14 + 1;
										Task task10 = new Task(delegate
										{
											int num16 = dem_acc4;
											dem_acc4 = num16 + 1;
											thongtin[dem_acc4].proxy = proxy2;
											int indexOfPossitionApp4 = Poin.GetIndexOfPossitionApp(ref lstPossition);
											sx3.Add(indexOfPossitionApp4);
											Selenium selenium4 = new Selenium(thongtin[dem_acc4], indexOfPossitionApp4, dem_acc4 + 1, Use_Proxy: true);
											selenium4.Open_CP(ThongSo_SettingCP.txt_hotmail, ThongSo_SettingCP.txt_PassHotmail);
										});
										task10.Start();
										list5.Add(task10);
										L_Task3.Add(task10);
										int num15 = time3;
										while (num15 > 0 && !Stop.stop && dem_acc4 + 1 != thongtin.Count)
										{
											num15--;
											Thread.Sleep(1000);
											try
											{
												thongtin[dem_acc4 + 1].TrangThai = "Waiting Run => " + num15 + " s";
												Change_Row(thongtin[dem_acc4 + 1]);
											}
											catch
											{
												break;
											}
										}
									}
									Task.WaitAll(list5.ToArray());
									foreach (int item11 in sx3)
									{
										Poin.FillIndexPossition(ref lstPossition, item11);
									}
									sx3.Clear();
									if (!Stop.stop && dem_acc4 + 1 != thongtin.Count)
									{
										proxy2 = changeIP_shoplike(shoplike, check: false, thongtin[dem_acc4]);
									}
								}
							});
							task4.Start();
							Thread.Sleep(TimeSpan.FromSeconds(time3 * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP + time3));
						}
						Task.WaitAll(L_Task3.ToArray());
					}
					else if (ThongSo_CauHinhDoiIP.rad_ChangIP_Xproxy)
					{
						int num5 = -1;
						int dem_acc3 = -1;
						int time2 = r.Next(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
						List<Task> L_Task2 = new List<Task>();
						foreach (string item12 in ThongSo_CauHinhDoiIP.rtb_Xproxy_Proxy)
						{
							num5++;
							if (Stop.stop || num5 == thongtin.Count)
							{
								break;
							}
							string item3 = (ThongSo_CauHinhDoiIP.rad_Xproxy_Sock5 ? ("1|" + item12) : item12);
							List<int> sx2 = new List<int>();
							Task task5 = new Task(delegate
							{
								while (dem_thread < thongtin.Count && !Stop.stop)
								{
									List<Task> list4 = new List<Task>();
									for (int m = 0; m < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; m++)
									{
										if (Stop.stop)
										{
											break;
										}
										if (dem_thread >= thongtin.Count)
										{
											break;
										}
										int num11 = dem_thread;
										dem_thread = num11 + 1;
										Task task9 = new Task(delegate
										{
											int num13 = dem_acc3;
											dem_acc3 = num13 + 1;
											thongtin[dem_acc3].proxy = item3;
											int indexOfPossitionApp3 = Poin.GetIndexOfPossitionApp(ref lstPossition);
											sx2.Add(indexOfPossitionApp3);
											Selenium selenium3 = new Selenium(thongtin[dem_acc3], indexOfPossitionApp3, dem_acc3 + 1, Use_Proxy: true);
											selenium3.Open_CP(ThongSo_SettingCP.txt_hotmail, ThongSo_SettingCP.txt_PassHotmail);
										});
										task9.Start();
										list4.Add(task9);
										L_Task2.Add(task9);
										int num12 = time2;
										while (num12 > 0 && !Stop.stop && dem_acc3 + 1 != thongtin.Count)
										{
											num12--;
											Thread.Sleep(1000);
											try
											{
												thongtin[dem_acc3 + 1].TrangThai = "Waiting Run => " + num12 + " s";
												Change_Row(thongtin[dem_acc3 + 1]);
											}
											catch
											{
												break;
											}
										}
									}
									Task.WaitAll(list4.ToArray());
									foreach (int item13 in sx2)
									{
										Poin.FillIndexPossition(ref lstPossition, item13);
									}
									sx2.Clear();
									if (!Stop.stop && dem_acc3 + 1 != thongtin.Count && !ChangeIP_Xproxy(item3))
									{
										thongtin[dem_acc3].TrangThai = "Error Reset proxy => " + item3;
										Change_Row(thongtin[dem_acc3]);
										break;
									}
								}
							});
							task5.Start();
							Thread.Sleep(TimeSpan.FromSeconds(time2 * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP));
							int num6 = time2;
							while (num6 > 0 && !Stop.stop && dem_acc3 + 1 != thongtin.Count)
							{
								num6--;
								Thread.Sleep(1000);
								try
								{
									thongtin[dem_acc3 + 1].TrangThai = "Waiting Run => " + num6 + " s";
									Change_Row(thongtin[dem_acc3 + 1]);
								}
								catch
								{
									goto IL_06bd;
								}
							}
							IL_06bd:;
						}
						Task.WaitAll(L_Task2.ToArray());
					}
					else if (ThongSo_CauHinhDoiIP.rad_ChangIP_Minproxy)
					{
						int num7 = 0;
						int dem_acc2 = -1;
						int time = r.Next(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
						List<Task> L_Task = new List<Task>();
						foreach (string item14 in ThongSo_CauHinhDoiIP.rtb_KeyMinproxy)
						{
							if (Stop.stop || num7 == thongtin.Count)
							{
								break;
							}
							num7++;
							string item2 = item14;
							List<int> sx = new List<int>();
							Task task6 = new Task(delegate
							{
								API_Minproxy aPI_Minproxy = new API_Minproxy(item2);
								string proxy = ((ThongSo_CauHinhDoiIP.cbb_SelecTypeIP != 1) ? aPI_Minproxy.NewIP_dancu()?.data.http_proxy_ipv4 : aPI_Minproxy.NewIP_V6()?.data.http_proxy);
								if (string.IsNullOrEmpty(proxy))
								{
									MessageBox.Show("Lấy proxy thất bại (Proxy fetch failed) ! \nKey : " + item2);
									Stop.stop = true;
								}
								while (dem_thread < thongtin.Count && !Stop.stop)
								{
									List<Task> list3 = new List<Task>();
									for (int l = 0; l < ThongSo_CauHinhDoiIP.num_Thread_ChangeIP; l++)
									{
										if (Stop.stop)
										{
											break;
										}
										if (dem_thread >= thongtin.Count)
										{
											break;
										}
										int num8 = dem_thread;
										dem_thread = num8 + 1;
										Task task8 = new Task(delegate
										{
											int num10 = dem_acc2;
											dem_acc2 = num10 + 1;
											thongtin[dem_acc2].proxy = proxy;
											int indexOfPossitionApp2 = Poin.GetIndexOfPossitionApp(ref lstPossition);
											sx.Add(indexOfPossitionApp2);
											Selenium selenium2 = new Selenium(thongtin[dem_acc2], indexOfPossitionApp2, dem_acc2 + 1, Use_Proxy: true);
											selenium2.Open_CP(ThongSo_SettingCP.txt_hotmail, ThongSo_SettingCP.txt_PassHotmail);
										});
										task8.Start();
										list3.Add(task8);
										L_Task.Add(task8);
										int num9 = time;
										while (num9 > 0 && !Stop.stop && dem_acc2 + 1 != thongtin.Count)
										{
											num9--;
											Thread.Sleep(1000);
											try
											{
												thongtin[dem_acc2 + 1].TrangThai = "Waiting Run => " + num9 + " s";
												Change_Row(thongtin[dem_acc2 + 1]);
											}
											catch
											{
												break;
											}
										}
									}
									Task.WaitAll(list3.ToArray());
									foreach (int item15 in sx)
									{
										Poin.FillIndexPossition(ref lstPossition, item15);
									}
									sx.Clear();
									if (!Stop.stop && dem_acc2 + 1 != thongtin.Count)
									{
										proxy = changeIP_Min(aPI_Minproxy, thongtin[dem_acc2])?.data.http_proxy;
										if (string.IsNullOrEmpty(proxy))
										{
											thongtin[dem_acc2].TrangThai = "Error getting proxy key => " + item2;
											Change_Row(thongtin[dem_acc2]);
											break;
										}
									}
								}
							});
							task6.Start();
							Thread.Sleep(TimeSpan.FromSeconds(time * ThongSo_CauHinhDoiIP.num_Thread_ChangeIP + time));
						}
						Task.WaitAll(L_Task.ToArray());
					}
					else
					{
						int dem_acc = 0;
						List<Task> list2 = new List<Task>();
						foreach (ThongTin item16 in thongtin)
						{
							if (Stop.stop)
							{
								break;
							}
							dem_thread++;
							int num2 = dem_acc;
							dem_acc = num2 + 1;
							ThongTin item = item16;
							Task task7 = new Task(delegate
							{
								int indexOfPossitionApp = Poin.GetIndexOfPossitionApp(ref lstPossition);
								Selenium selenium = new Selenium(item, indexOfPossitionApp, dem_acc);
								selenium.Open_CP(ThongSo_SettingCP.txt_hotmail, ThongSo_SettingCP.txt_PassHotmail);
							});
							task7.Start();
							list2.Add(task7);
							Deley(ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMin, ThongSo_CauHinhTuongTac.num_ThreadTimeout_TimeMax);
							if (!Stop.stop && dem_thread == ThongSo_CauHinhDoiIP.num_Thread_ChangeIP)
							{
								Task.WaitAll(list2.ToArray());
								for (int k = 0; k < lstPossition.Count; k++)
								{
									Poin.FillIndexPossition(ref lstPossition, k);
								}
								changip.change();
								list2.Clear();
								dem_thread = 0;
							}
						}
						Task.WaitAll(list2.ToArray());
					}
					BeginInvoke((MethodInvoker)delegate
					{
						btn_start.Enabled = true;
						lb_Loading.Enabled = false;
						btn_stop.Enabled = false;
					});
				});
				task.Start();
			}
			else
			{
				MessageBox.Show("Please select the account to run !");
			}
			Thread.Sleep(1000);
		}

		private void checkpoinPhoneToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Chon("CheckPoin", enum_Checkpoin.Phone.ToString().ToString());
		}

		private void checkpoinMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Chon("CheckPoin", enum_Checkpoin.Mail.ToString().ToString());
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.Form1));
			dgv_acc = new System.Windows.Forms.DataGridView();
			STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
			User = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Cookie = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			_2FA = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Pass_Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
			proxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Avatar = new System.Windows.Forms.DataGridViewTextBoxColumn();
			BaiViet = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Followers = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Following = new System.Windows.Forms.DataGridViewTextBoxColumn();
			TinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
			CheckPoin = new System.Windows.Forms.DataGridViewTextBoxColumn();
			TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
			checkselec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			tstrstatusbar = new System.Windows.Forms.ToolStrip();
			toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			lb_IP = new System.Windows.Forms.ToolStripLabel();
			lb_loadIP = new System.Windows.Forms.ToolStripLabel();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			lb_Live = new System.Windows.Forms.ToolStripLabel();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
			lb_die = new System.Windows.Forms.ToolStripLabel();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
			lb_TongAcc = new System.Windows.Forms.ToolStripLabel();
			toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			label = new System.Windows.Forms.ToolStripLabel();
			lb_kichhoat = new System.Windows.Forms.ToolStripLabel();
			toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			lb_HSD = new System.Windows.Forms.ToolStripLabel();
			lb_Loading = new System.Windows.Forms.ToolStripButton();
			ctxmain = new System.Windows.Forms.ContextMenuStrip(components);
			ctx_chon = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Chon_BoiDen = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Chon_Live = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Chon__NotLive = new System.Windows.Forms.ToolStripMenuItem();
			ctx_ChuaCheckLive = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Chon_TLC = new System.Windows.Forms.ToolStripMenuItem();
			checkpoinPhoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkpoinMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Chon_All = new System.Windows.Forms.ToolStripMenuItem();
			ctx_BoChon = new System.Windows.Forms.ToolStripMenuItem();
			ctx_BoChon_BoiDen = new System.Windows.Forms.ToolStripMenuItem();
			ctx_BoChon_All = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Delete = new System.Windows.Forms.ToolStripMenuItem();
			ctx_DeleteAll = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Save_Cookie = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Save_UserPass = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Save_UserPassCookie = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Profile = new System.Windows.Forms.ToolStripMenuItem();
			ctx_OpenProfile = new System.Windows.Forms.ToolStripMenuItem();
			ctx_DeleteProfile = new System.Windows.Forms.ToolStripMenuItem();
			ctx_CreadtSC = new System.Windows.Forms.ToolStripMenuItem();
			ctx_OpenCP = new System.Windows.Forms.ToolStripMenuItem();
			ctx_checkpoinHotmail = new System.Windows.Forms.ToolStripMenuItem();
			ctx_checkpoinMailDomain = new System.Windows.Forms.ToolStripMenuItem();
			ctx_checkpoinPhone = new System.Windows.Forms.ToolStripMenuItem();
			ctx_settingCP = new System.Windows.Forms.ToolStripMenuItem();
			ctx_SudungCheckLive = new System.Windows.Forms.ToolStripMenuItem();
			loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			groupBox2 = new System.Windows.Forms.GroupBox();
			lb_setting_CauHinhTuongTac = new System.Windows.Forms.Label();
			btn_stop = new System.Windows.Forms.Button();
			btn_start = new System.Windows.Forms.Button();
			pnlHeader = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			btnMinimize = new System.Windows.Forms.Button();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			mnuCauHinhChung = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_29 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_49 = new System.Windows.Forms.ToolStripMenuItem();
			btnPost = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)dgv_acc).BeginInit();
			tstrstatusbar.SuspendLayout();
			ctxmain.SuspendLayout();
			groupBox2.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			dgv_acc.AllowUserToAddRows = false;
			dgv_acc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			dgv_acc.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			dgv_acc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25f);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgv_acc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dgv_acc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv_acc.Columns.AddRange(STT, User, Pass, Cookie, Total, FullName, ID, _2FA, Mail, Pass_Mail, proxy, Avatar, BaiViet, Followers, Following, TinhTrang, CheckPoin, TrangThai, checkselec);
			dgv_acc.EnableHeadersVisualStyles = false;
			dgv_acc.Location = new System.Drawing.Point(12, 114);
			dgv_acc.Name = "dgv_acc";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25f);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgv_acc.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgv_acc.RowHeadersVisible = false;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dgv_acc.RowsDefaultCellStyle = dataGridViewCellStyle3;
			dgv_acc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			dgv_acc.Size = new System.Drawing.Size(1175, 529);
			dgv_acc.TabIndex = 57;
			dgv_acc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgv_acc_CellClick);
			dgv_acc.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dgv_acc_CellMouseUp);
			dgv_acc.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(dgv_acc_CellValueChanged);
			dgv_acc.MouseDown += new System.Windows.Forms.MouseEventHandler(dgv_acc_MouseDown);
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
			Pass.DataPropertyName = "Pass";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			Pass.DefaultCellStyle = dataGridViewCellStyle6;
			Pass.HeaderText = "Pass";
			Pass.Name = "Pass";
			Pass.Width = 40;
			Cookie.DataPropertyName = "Cookie";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			Cookie.DefaultCellStyle = dataGridViewCellStyle7;
			Cookie.HeaderText = "Cookie";
			Cookie.Name = "Cookie";
			Cookie.Width = 80;
			Total.DataPropertyName = "Total";
			Total.HeaderText = "Total (s)";
			Total.Name = "Total";
			Total.Width = 50;
			FullName.DataPropertyName = "FullName";
			FullName.HeaderText = "Full Name";
			FullName.Name = "FullName";
			FullName.Width = 120;
			ID.DataPropertyName = "ID";
			ID.HeaderText = "ID";
			ID.Name = "ID";
			ID.Width = 80;
			_2FA.DataPropertyName = "_2FA";
			_2FA.HeaderText = "2FA";
			_2FA.Name = "_2FA";
			_2FA.Width = 80;
			Mail.DataPropertyName = "Mail";
			Mail.HeaderText = "Mail";
			Mail.Name = "Mail";
			Pass_Mail.DataPropertyName = "Pass_Mail";
			Pass_Mail.HeaderText = "Pass Mail";
			Pass_Mail.Name = "Pass_Mail";
			Pass_Mail.Width = 40;
			proxy.DataPropertyName = "proxy";
			proxy.HeaderText = "proxy";
			proxy.Name = "proxy";
			proxy.Width = 70;
			Avatar.DataPropertyName = "Avatar";
			Avatar.HeaderText = "Avatar";
			Avatar.Name = "Avatar";
			Avatar.Width = 40;
			BaiViet.DataPropertyName = "BaiViet";
			BaiViet.HeaderText = "Posts";
			BaiViet.Name = "BaiViet";
			BaiViet.Width = 40;
			Followers.DataPropertyName = "Followers";
			Followers.HeaderText = "Followers";
			Followers.Name = "Followers";
			Followers.Width = 60;
			Following.DataPropertyName = "Following";
			Following.HeaderText = "Following";
			Following.Name = "Following";
			Following.Width = 60;
			TinhTrang.DataPropertyName = "TinhTrang";
			TinhTrang.HeaderText = "Live/Die";
			TinhTrang.Name = "TinhTrang";
			TinhTrang.Width = 70;
			CheckPoin.HeaderText = "CheckPoin";
			CheckPoin.Name = "CheckPoin";
			CheckPoin.Width = 70;
			TrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			TrangThai.DataPropertyName = "TrangThai";
			TrangThai.HeaderText = "Status";
			TrangThai.Name = "TrangThai";
			checkselec.DataPropertyName = "checkselec";
			checkselec.HeaderText = "Select";
			checkselec.Name = "checkselec";
			checkselec.Width = 50;
			tstrstatusbar.Dock = System.Windows.Forms.DockStyle.Bottom;
			tstrstatusbar.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			tstrstatusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[18]
			{
				toolStripLabel1, lb_IP, lb_loadIP, toolStripSeparator3, toolStripLabel3, lb_Live, toolStripSeparator1, toolStripLabel7, lb_die, toolStripSeparator2,
				toolStripLabel4, lb_TongAcc, toolStripSeparator4, label, lb_kichhoat, toolStripSeparator5, lb_HSD, lb_Loading
			});
			tstrstatusbar.Location = new System.Drawing.Point(0, 646);
			tstrstatusbar.Name = "tstrstatusbar";
			tstrstatusbar.Size = new System.Drawing.Size(1199, 25);
			tstrstatusbar.TabIndex = 70;
			tstrstatusbar.Text = "Status Bar";
			toolStripLabel1.ForeColor = System.Drawing.Color.Teal;
			toolStripLabel1.Name = "toolStripLabel1";
			toolStripLabel1.Size = new System.Drawing.Size(24, 22);
			toolStripLabel1.Text = "IP: ";
			lb_IP.ForeColor = System.Drawing.Color.DarkRed;
			lb_IP.Name = "lb_IP";
			lb_IP.Size = new System.Drawing.Size(53, 22);
			lb_IP.Text = "0.0.0.0   ";
			lb_loadIP.ForeColor = System.Drawing.Color.Green;
			lb_loadIP.Image = (System.Drawing.Image)resources.GetObject("lb_loadIP.Image");
			lb_loadIP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			lb_loadIP.Name = "lb_loadIP";
			lb_loadIP.Size = new System.Drawing.Size(16, 22);
			lb_loadIP.Click += new System.EventHandler(lb_loadIP_Click);
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			toolStripLabel3.ForeColor = System.Drawing.Color.Green;
			toolStripLabel3.Name = "toolStripLabel3";
			toolStripLabel3.Size = new System.Drawing.Size(46, 22);
			toolStripLabel3.Text = "    Live: ";
			lb_Live.ForeColor = System.Drawing.Color.Green;
			lb_Live.Name = "lb_Live";
			lb_Live.Size = new System.Drawing.Size(14, 22);
			lb_Live.Text = "0";
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			toolStripLabel7.ForeColor = System.Drawing.Color.DarkRed;
			toolStripLabel7.Name = "toolStripLabel7";
			toolStripLabel7.Size = new System.Drawing.Size(34, 22);
			toolStripLabel7.Text = "   Die";
			lb_die.ForeColor = System.Drawing.Color.DarkRed;
			lb_die.Name = "lb_die";
			lb_die.Size = new System.Drawing.Size(14, 22);
			lb_die.Text = "0";
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			toolStripLabel4.ForeColor = System.Drawing.Color.Teal;
			toolStripLabel4.Name = "toolStripLabel4";
			toolStripLabel4.Size = new System.Drawing.Size(59, 22);
			toolStripLabel4.Text = "Total Acc:";
			lb_TongAcc.ForeColor = System.Drawing.Color.DarkCyan;
			lb_TongAcc.Name = "lb_TongAcc";
			lb_TongAcc.Size = new System.Drawing.Size(14, 22);
			lb_TongAcc.Text = "0";
			toolStripSeparator4.Name = "toolStripSeparator4";
			toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			label.Name = "label";
			label.Size = new System.Drawing.Size(35, 22);
			label.Text = "Key : ";
			lb_kichhoat.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lb_kichhoat.ForeColor = System.Drawing.Color.Black;
			lb_kichhoat.Name = "lb_kichhoat";
			lb_kichhoat.Size = new System.Drawing.Size(100, 22);
			lb_kichhoat.Text = "Registration Code";
			toolStripSeparator5.Name = "toolStripSeparator5";
			toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			lb_HSD.ForeColor = System.Drawing.Color.DarkRed;
			lb_HSD.Name = "lb_HSD";
			lb_HSD.Size = new System.Drawing.Size(80, 22);
			lb_HSD.Text = "Expiry :  0 day";
			lb_Loading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			lb_Loading.Enabled = false;
			lb_Loading.Image = (System.Drawing.Image)resources.GetObject("lb_Loading.Image");
			lb_Loading.ImageTransparentColor = System.Drawing.Color.Magenta;
			lb_Loading.Name = "lb_Loading";
			lb_Loading.Size = new System.Drawing.Size(23, 22);
			ctxmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[9] { ctx_chon, ctx_BoChon, ctx_Delete, ctx_DeleteAll, toolStripMenuItem4, ctx_Profile, ctx_OpenCP, ctx_SudungCheckLive, loadToolStripMenuItem });
			ctxmain.Name = "ctxmain";
			ctxmain.Size = new System.Drawing.Size(163, 202);
			ctx_chon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { ctx_Chon_BoiDen, ctx_Chon_Live, ctx_Chon__NotLive, ctx_ChuaCheckLive, ctx_Chon_TLC, checkpoinPhoneToolStripMenuItem, checkpoinMailToolStripMenuItem, ctx_Chon_All });
			ctx_chon.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_chon.Image = (System.Drawing.Image)resources.GetObject("ctx_chon.Image");
			ctx_chon.Name = "ctx_chon";
			ctx_chon.Size = new System.Drawing.Size(162, 22);
			ctx_chon.Text = "Select";
			ctx_Chon_BoiDen.Image = Interactive_ins.Properties.Resources.check;
			ctx_Chon_BoiDen.Name = "ctx_Chon_BoiDen";
			ctx_Chon_BoiDen.Size = new System.Drawing.Size(172, 22);
			ctx_Chon_BoiDen.Text = "blacked out";
			ctx_Chon_BoiDen.Click += new System.EventHandler(ctx_Chon_BoiDen_Click);
			ctx_Chon_Live.Image = (System.Drawing.Image)resources.GetObject("ctx_Chon_Live.Image");
			ctx_Chon_Live.Name = "ctx_Chon_Live";
			ctx_Chon_Live.Size = new System.Drawing.Size(172, 22);
			ctx_Chon_Live.Text = "Live !";
			ctx_Chon_Live.Click += new System.EventHandler(ctx_Chon_Live_Click);
			ctx_Chon__NotLive.Image = (System.Drawing.Image)resources.GetObject("ctx_Chon__NotLive.Image");
			ctx_Chon__NotLive.Name = "ctx_Chon__NotLive";
			ctx_Chon__NotLive.Size = new System.Drawing.Size(172, 22);
			ctx_Chon__NotLive.Text = "Not Live!";
			ctx_Chon__NotLive.Click += new System.EventHandler(ctx_Chon__NotLive_Click);
			ctx_ChuaCheckLive.Image = (System.Drawing.Image)resources.GetObject("ctx_ChuaCheckLive.Image");
			ctx_ChuaCheckLive.Name = "ctx_ChuaCheckLive";
			ctx_ChuaCheckLive.Size = new System.Drawing.Size(172, 22);
			ctx_ChuaCheckLive.Text = "Unknown Live/Die";
			ctx_ChuaCheckLive.Click += new System.EventHandler(ctx_ChuaCheckLive_Click);
			ctx_Chon_TLC.Image = (System.Drawing.Image)resources.GetObject("ctx_Chon_TLC.Image");
			ctx_Chon_TLC.Name = "ctx_Chon_TLC";
			ctx_Chon_TLC.Size = new System.Drawing.Size(172, 22);
			ctx_Chon_TLC.Text = "Chưa đủ ĐK TLC";
			ctx_Chon_TLC.Click += new System.EventHandler(ctx_Chon_TLC_Click);
			checkpoinPhoneToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("checkpoinPhoneToolStripMenuItem.Image");
			checkpoinPhoneToolStripMenuItem.Name = "checkpoinPhoneToolStripMenuItem";
			checkpoinPhoneToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			checkpoinPhoneToolStripMenuItem.Text = "Checkpoin Phone";
			checkpoinPhoneToolStripMenuItem.Click += new System.EventHandler(checkpoinPhoneToolStripMenuItem_Click);
			checkpoinMailToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("checkpoinMailToolStripMenuItem.Image");
			checkpoinMailToolStripMenuItem.Name = "checkpoinMailToolStripMenuItem";
			checkpoinMailToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			checkpoinMailToolStripMenuItem.Text = "Checkpoin Mail";
			checkpoinMailToolStripMenuItem.Click += new System.EventHandler(checkpoinMailToolStripMenuItem_Click);
			ctx_Chon_All.Image = (System.Drawing.Image)resources.GetObject("ctx_Chon_All.Image");
			ctx_Chon_All.Name = "ctx_Chon_All";
			ctx_Chon_All.Size = new System.Drawing.Size(172, 22);
			ctx_Chon_All.Text = "All";
			ctx_Chon_All.Click += new System.EventHandler(ctx_Chon_All_Click);
			ctx_BoChon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { ctx_BoChon_BoiDen, ctx_BoChon_All });
			ctx_BoChon.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_BoChon.Image = (System.Drawing.Image)resources.GetObject("ctx_BoChon.Image");
			ctx_BoChon.Name = "ctx_BoChon";
			ctx_BoChon.Size = new System.Drawing.Size(162, 22);
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
			ctx_Delete.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_Delete.Image = (System.Drawing.Image)resources.GetObject("ctx_Delete.Image");
			ctx_Delete.Name = "ctx_Delete";
			ctx_Delete.Size = new System.Drawing.Size(162, 22);
			ctx_Delete.Text = "Delete";
			ctx_Delete.Click += new System.EventHandler(ctx_Delete_Click);
			ctx_DeleteAll.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_DeleteAll.Image = (System.Drawing.Image)resources.GetObject("ctx_DeleteAll.Image");
			ctx_DeleteAll.Name = "ctx_DeleteAll";
			ctx_DeleteAll.Size = new System.Drawing.Size(162, 22);
			ctx_DeleteAll.Text = "Delete All";
			ctx_DeleteAll.Click += new System.EventHandler(ctx_DeleteAll_Click);
			toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { ctx_Save_Cookie, ctx_Save_UserPass, ctx_Save_UserPassCookie, toolStripMenuItem1 });
			toolStripMenuItem4.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			toolStripMenuItem4.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem4.Image");
			toolStripMenuItem4.Name = "toolStripMenuItem4";
			toolStripMenuItem4.Size = new System.Drawing.Size(162, 22);
			toolStripMenuItem4.Text = "Save";
			ctx_Save_Cookie.Image = Interactive_ins.Properties.Resources.floppy_disk__1_;
			ctx_Save_Cookie.Name = "ctx_Save_Cookie";
			ctx_Save_Cookie.Size = new System.Drawing.Size(237, 22);
			ctx_Save_Cookie.Text = "Cookie";
			ctx_Save_Cookie.Click += new System.EventHandler(ctx_Save_Cookie_Click);
			ctx_Save_UserPass.Image = (System.Drawing.Image)resources.GetObject("ctx_Save_UserPass.Image");
			ctx_Save_UserPass.Name = "ctx_Save_UserPass";
			ctx_Save_UserPass.Size = new System.Drawing.Size(237, 22);
			ctx_Save_UserPass.Text = "User|Pass";
			ctx_Save_UserPass.Click += new System.EventHandler(ctx_Save_UserPass_Click);
			ctx_Save_UserPassCookie.Image = (System.Drawing.Image)resources.GetObject("ctx_Save_UserPassCookie.Image");
			ctx_Save_UserPassCookie.Name = "ctx_Save_UserPassCookie";
			ctx_Save_UserPassCookie.Size = new System.Drawing.Size(237, 22);
			ctx_Save_UserPassCookie.Text = "User|Pass|Cookie";
			ctx_Save_UserPassCookie.Click += new System.EventHandler(ctx_Save_UserPassCookie_Click);
			toolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem1.Image");
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new System.Drawing.Size(237, 22);
			toolStripMenuItem1.Text = "User|Pass|Cookie|Mail|PassMail";
			toolStripMenuItem1.Click += new System.EventHandler(toolStripMenuItem1_Click);
			ctx_Profile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { ctx_OpenProfile, ctx_DeleteProfile, ctx_CreadtSC });
			ctx_Profile.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_Profile.Image = Interactive_ins.Properties.Resources.data_backup_25px;
			ctx_Profile.Name = "ctx_Profile";
			ctx_Profile.Size = new System.Drawing.Size(162, 22);
			ctx_Profile.Text = "Chrome Profile";
			ctx_OpenProfile.Image = (System.Drawing.Image)resources.GetObject("ctx_OpenProfile.Image");
			ctx_OpenProfile.Name = "ctx_OpenProfile";
			ctx_OpenProfile.Size = new System.Drawing.Size(200, 22);
			ctx_OpenProfile.Text = "Open Profile";
			ctx_OpenProfile.Click += new System.EventHandler(ctx_OpenProfile_Click);
			ctx_DeleteProfile.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_DeleteProfile.Image = (System.Drawing.Image)resources.GetObject("ctx_DeleteProfile.Image");
			ctx_DeleteProfile.Name = "ctx_DeleteProfile";
			ctx_DeleteProfile.Size = new System.Drawing.Size(200, 22);
			ctx_DeleteProfile.Text = "Delete Profile";
			ctx_DeleteProfile.Click += new System.EventHandler(ctx_DeleteProfile_Click);
			ctx_CreadtSC.Image = (System.Drawing.Image)resources.GetObject("ctx_CreadtSC.Image");
			ctx_CreadtSC.Name = "ctx_CreadtSC";
			ctx_CreadtSC.Size = new System.Drawing.Size(200, 22);
			ctx_CreadtSC.Text = "Create Shortcut chrome";
			ctx_CreadtSC.Click += new System.EventHandler(ctx_CreadtSC_Click);
			ctx_OpenCP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { ctx_checkpoinHotmail, ctx_checkpoinMailDomain, ctx_checkpoinPhone, ctx_settingCP });
			ctx_OpenCP.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_OpenCP.Image = (System.Drawing.Image)resources.GetObject("ctx_OpenCP.Image");
			ctx_OpenCP.Name = "ctx_OpenCP";
			ctx_OpenCP.Size = new System.Drawing.Size(162, 22);
			ctx_OpenCP.Text = "Open CheckPoin";
			ctx_checkpoinHotmail.Image = (System.Drawing.Image)resources.GetObject("ctx_checkpoinHotmail.Image");
			ctx_checkpoinHotmail.Name = "ctx_checkpoinHotmail";
			ctx_checkpoinHotmail.Size = new System.Drawing.Size(202, 22);
			ctx_checkpoinHotmail.Text = "Checkpoin Hotmail";
			ctx_checkpoinHotmail.Click += new System.EventHandler(ctx_checkpoinHotmail_Click);
			ctx_checkpoinMailDomain.Image = (System.Drawing.Image)resources.GetObject("ctx_checkpoinMailDomain.Image");
			ctx_checkpoinMailDomain.Name = "ctx_checkpoinMailDomain";
			ctx_checkpoinMailDomain.Size = new System.Drawing.Size(202, 22);
			ctx_checkpoinMailDomain.Text = "Checkpoin Mail Domain";
			ctx_checkpoinMailDomain.Click += new System.EventHandler(ctx_checkpoinMailDomain_Click);
			ctx_checkpoinPhone.Enabled = false;
			ctx_checkpoinPhone.Image = (System.Drawing.Image)resources.GetObject("ctx_checkpoinPhone.Image");
			ctx_checkpoinPhone.Name = "ctx_checkpoinPhone";
			ctx_checkpoinPhone.Size = new System.Drawing.Size(202, 22);
			ctx_checkpoinPhone.Text = "Checkpoin Phone ";
			ctx_settingCP.Image = (System.Drawing.Image)resources.GetObject("ctx_settingCP.Image");
			ctx_settingCP.Name = "ctx_settingCP";
			ctx_settingCP.Size = new System.Drawing.Size(202, 22);
			ctx_settingCP.Text = "Setting ...";
			ctx_settingCP.Click += new System.EventHandler(ctx_settingCP_Click);
			ctx_SudungCheckLive.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_SudungCheckLive.Image = (System.Drawing.Image)resources.GetObject("ctx_SudungCheckLive.Image");
			ctx_SudungCheckLive.Name = "ctx_SudungCheckLive";
			ctx_SudungCheckLive.Size = new System.Drawing.Size(162, 22);
			ctx_SudungCheckLive.Text = "Check Live";
			ctx_SudungCheckLive.Click += new System.EventHandler(ctx_SudungCheckLive_Click);
			loadToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			loadToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("loadToolStripMenuItem.Image");
			loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			loadToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			loadToolStripMenuItem.Text = "Reload Data";
			loadToolStripMenuItem.Click += new System.EventHandler(loadToolStripMenuItem_Click);
			openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			openFileDialog1.InitialDirectory = "C:\\Users\\Admin\\Desktop\\";
			openFileDialog1.RestoreDirectory = true;
			saveFileDialog1.Filter = "txt files |* .txt| All files (*. *) | *. *";
			saveFileDialog1.Title = "Save";
			groupBox2.Controls.Add(lb_setting_CauHinhTuongTac);
			groupBox2.Controls.Add(btn_stop);
			groupBox2.Controls.Add(btn_start);
			groupBox2.Location = new System.Drawing.Point(12, 56);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(345, 52);
			groupBox2.TabIndex = 90;
			groupBox2.TabStop = false;
			groupBox2.Enter += new System.EventHandler(groupBox2_Enter);
			lb_setting_CauHinhTuongTac.AutoSize = true;
			lb_setting_CauHinhTuongTac.Cursor = System.Windows.Forms.Cursors.Hand;
			lb_setting_CauHinhTuongTac.Font = new System.Drawing.Font("Segoe UI Semibold", 13f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lb_setting_CauHinhTuongTac.Image = (System.Drawing.Image)resources.GetObject("lb_setting_CauHinhTuongTac.Image");
			lb_setting_CauHinhTuongTac.Location = new System.Drawing.Point(306, 17);
			lb_setting_CauHinhTuongTac.Name = "lb_setting_CauHinhTuongTac";
			lb_setting_CauHinhTuongTac.Size = new System.Drawing.Size(27, 25);
			lb_setting_CauHinhTuongTac.TabIndex = 69;
			lb_setting_CauHinhTuongTac.Text = "   ";
			lb_setting_CauHinhTuongTac.Click += new System.EventHandler(lb_setting_CauHinhTuongTac_Click);
			btn_stop.Enabled = false;
			btn_stop.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			btn_stop.FlatAppearance.BorderSize = 3;
			btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btn_stop.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btn_stop.ForeColor = System.Drawing.Color.DarkRed;
			btn_stop.Image = (System.Drawing.Image)resources.GetObject("btn_stop.Image");
			btn_stop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btn_stop.Location = new System.Drawing.Point(165, 14);
			btn_stop.Name = "btn_stop";
			btn_stop.Size = new System.Drawing.Size(127, 31);
			btn_stop.TabIndex = 68;
			btn_stop.Text = "   Stop Progress";
			btn_stop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btn_stop.UseVisualStyleBackColor = true;
			btn_stop.Click += new System.EventHandler(btn_stop_Click);
			btn_start.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			btn_start.FlatAppearance.BorderSize = 3;
			btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btn_start.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btn_start.ForeColor = System.Drawing.Color.DarkBlue;
			btn_start.Image = (System.Drawing.Image)resources.GetObject("btn_start.Image");
			btn_start.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btn_start.Location = new System.Drawing.Point(17, 14);
			btn_start.Name = "btn_start";
			btn_start.Size = new System.Drawing.Size(127, 31);
			btn_start.TabIndex = 67;
			btn_start.Text = " Interactive Run";
			btn_start.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btn_start.UseVisualStyleBackColor = true;
			btn_start.Click += new System.EventHandler(btn_start_Click);
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(label1);
			pnlHeader.Controls.Add(label3);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(button2);
			pnlHeader.Controls.Add(button1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(1, 2);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1198, 29);
			pnlHeader.TabIndex = 91;
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold);
			label1.ForeColor = System.Drawing.Color.Black;
			label1.Location = new System.Drawing.Point(395, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 16);
			label1.TabIndex = 14;
			label1.Text = "ThichCare - V1.8.1";
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold);
			label3.ForeColor = System.Drawing.Color.Black;
			label3.Location = new System.Drawing.Point(48, 7);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(353, 16);
			label3.TabIndex = 13;
			label3.Text = "Instagram Account Management And ThichCare ";
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(6, 1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.Dock = System.Windows.Forms.DockStyle.Right;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Image = Interactive_ins.Properties.Resources.minimize_window_25px;
			button2.Location = new System.Drawing.Point(1102, 0);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(32, 29);
			button2.TabIndex = 0;
			button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.Dock = System.Windows.Forms.DockStyle.Right;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = Interactive_ins.Properties.Resources.maximize_window_25px;
			button1.Location = new System.Drawing.Point(1134, 0);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(32, 29);
			button1.TabIndex = 1;
			button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button1.UseVisualStyleBackColor = true;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = Interactive_ins.Properties.Resources.icons8_close_window_25px;
			btnMinimize.Location = new System.Drawing.Point(1166, 0);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 29);
			btnMinimize.TabIndex = 2;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
			menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			menuStrip1.AutoSize = false;
			menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { mnuCauHinhChung, toolStripMenuItem_1, toolStripMenuItem_29, toolStripMenuItem_49 });
			menuStrip1.Location = new System.Drawing.Point(0, 32);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			menuStrip1.Size = new System.Drawing.Size(1199, 25);
			menuStrip1.Stretch = false;
			menuStrip1.TabIndex = 92;
			menuStrip1.Text = "menuStrip1";
			mnuCauHinhChung.Image = Interactive_ins.Properties.Resources.literature_25px;
			mnuCauHinhChung.Name = "mnuCauHinhChung";
			mnuCauHinhChung.Size = new System.Drawing.Size(171, 21);
			mnuCauHinhChung.Text = "Change ip configuration";
			mnuCauHinhChung.Click += new System.EventHandler(mnuCauHinhChung_Click);
			toolStripMenuItem_1.Image = Interactive_ins.Properties.Resources.interactivity;
			toolStripMenuItem_1.Name = "toolStripMenuItem_1";
			toolStripMenuItem_1.Size = new System.Drawing.Size(176, 21);
			toolStripMenuItem_1.Text = "Interactive Configuration";
			toolStripMenuItem_1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			toolStripMenuItem_1.Click += new System.EventHandler(toolStripMenuItem_1_Click);
			toolStripMenuItem_29.Image = Interactive_ins.Properties.Resources.data_backup_25px;
			toolStripMenuItem_29.Name = "toolStripMenuItem_29";
			toolStripMenuItem_29.Size = new System.Drawing.Size(156, 21);
			toolStripMenuItem_29.Text = "Display Configuration";
			toolStripMenuItem_29.Click += new System.EventHandler(toolStripMenuItem_29_Click);
			toolStripMenuItem_49.Image = Interactive_ins.Properties.Resources.telephone;
			toolStripMenuItem_49.Name = "toolStripMenuItem_49";
			toolStripMenuItem_49.Size = new System.Drawing.Size(79, 21);
			toolStripMenuItem_49.Text = "Contact";
			toolStripMenuItem_49.Click += new System.EventHandler(toolStripMenuItem_49_Click);
			btnPost.Cursor = System.Windows.Forms.Cursors.Hand;
			btnPost.Font = new System.Drawing.Font("Segoe UI Semibold", 8f);
			btnPost.ForeColor = System.Drawing.Color.DarkBlue;
			btnPost.Image = Interactive_ins.Properties.Resources.instagram;
			btnPost.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnPost.Location = new System.Drawing.Point(380, 71);
			btnPost.Name = "btnPost";
			btnPost.Size = new System.Drawing.Size(127, 29);
			btnPost.TabIndex = 93;
			btnPost.Text = "Register ins with fb";
			btnPost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnPost.UseVisualStyleBackColor = false;
			btnPost.Click += new System.EventHandler(btnPost_Click);
			button9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button9.BackColor = System.Drawing.Color.White;
			button9.Cursor = System.Windows.Forms.Cursors.Hand;
			button9.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button9.Location = new System.Drawing.Point(1055, 73);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(132, 27);
			button9.TabIndex = 94;
			button9.Text = "Close Chromedriver";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button7.Cursor = System.Windows.Forms.Cursors.Hand;
			button7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			button7.ForeColor = System.Drawing.Color.DarkBlue;
			button7.Image = (System.Drawing.Image)resources.GetObject("button7.Image");
			button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button7.Location = new System.Drawing.Point(523, 71);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(127, 29);
			button7.TabIndex = 95;
			button7.Text = "       Import Proxy";
			button7.UseVisualStyleBackColor = false;
			button7.Click += new System.EventHandler(button7_Click);
			button3.Cursor = System.Windows.Forms.Cursors.Hand;
			button3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			button3.ForeColor = System.Drawing.Color.DarkBlue;
			button3.Image = (System.Drawing.Image)resources.GetObject("button3.Image");
			button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button3.Location = new System.Drawing.Point(665, 71);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(127, 29);
			button3.TabIndex = 96;
			button3.Text = "       Import ACC";
			button3.UseVisualStyleBackColor = false;
			button3.Click += new System.EventHandler(button3_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			BackColor = System.Drawing.Color.White;
			base.CausesValidation = false;
			base.ClientSize = new System.Drawing.Size(1199, 671);
			base.Controls.Add(button3);
			base.Controls.Add(button7);
			base.Controls.Add(button9);
			base.Controls.Add(btnPost);
			base.Controls.Add(menuStrip1);
			base.Controls.Add(pnlHeader);
			base.Controls.Add(groupBox2);
			base.Controls.Add(tstrstatusbar);
			base.Controls.Add(dgv_acc);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.25f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Form1";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Phần mềm chăm sóc, quản lý Instagram - ThichCare (Zalo: https://zalo.me/g/vmrbwf745)";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
			base.Load += new System.EventHandler(Form1_Load);
			((System.ComponentModel.ISupportInitialize)dgv_acc).EndInit();
			tstrstatusbar.ResumeLayout(false);
			tstrstatusbar.PerformLayout();
			ctxmain.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
