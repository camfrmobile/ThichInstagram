using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class nhaptaikhoan : Form
	{
		private int dang;

		public static nhaptaikhoan remote;

		private List<string> dd_0 = new List<string> { "User", "Pass", "Cookie", "2FA", "Mail", "Pass Mail", "Proxy" };

		private List<string> dd_1 = new List<string> { "User", "Pass", "Cookie", "2FA", "Proxy" };

		private IContainer components = null;

		private ComboBox cbb_DinhDangNhap;

		private Button btnCancel;

		private Button btnAdd;

		private Label label8;

		private Panel plDinhDangNhap;

		private ComboBox cbb_DinhDang1;

		private ComboBox cbb_DinhDang2;

		private ComboBox cbb_DinhDang3;

		private ComboBox cbb_DinhDang4;

		private ComboBox cbb_DinhDang5;

		private Label label13;

		private ComboBox cbb_DinhDang6;

		private Label label12;

		private Label label11;

		private Label label9;

		private Label label10;

		private CheckBox cb_CheckThongTin;

		private Label label15;

		private ToolStrip tstrstatusbar;

		private ToolStripLabel toolStripLabel1;

		private ToolStripLabel lb_IP;

		private ToolStripLabel lb_loadIP;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripLabel toolStripLabel3;

		private ToolStripLabel lb_Live;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripLabel toolStripLabel7;

		private ToolStripLabel lb_die;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripLabel toolStripLabel4;

		private ToolStripLabel lb_TongAcc;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripButton lb_Loading;

		private GroupBox groupBox1;

		private RichTextBox txt_Account;

		private Label label1;

		public nhaptaikhoan(int dang)
		{
			InitializeComponent();
			this.dang = dang;
			remote = this;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			lb_Loading.Enabled = true;
			int dem = 0;
			List<ThongTin> thongtin = new List<ThongTin>();
			List<string> L_tt = txt_Account.Text.Split('\n').ToList();
			L_tt?.RemoveAll((string x) => x.Trim() == "");
			switch (dang)
			{
			case 0:
			{
				Task task2 = new Task(delegate
				{
					SQLite sQLite = new SQLite();
					foreach (string item in L_tt)
					{
						string[] acc = item.Split('|');
						if (!sQLite.Select_Data_User(acc[0]))
						{
							int a = 0;
							Invoke((MethodInvoker)delegate
							{
								a = cbb_DinhDangNhap.SelectedIndex;
							});
							switch (a)
							{
							case 0:
								if (acc.Count() >= 2)
								{
									thongtin.Add(new ThongTin
									{
										User = acc[0],
										Pass = acc[1],
										Color = 2
									});
								}
								break;
							case 1:
								if (acc.Count() >= 3)
								{
									thongtin.Add(new ThongTin
									{
										User = acc[0],
										Pass = acc[1],
										_2FA = acc[2],
										Color = 2
									});
								}
								break;
							case 2:
								if (acc.Count() >= 3)
								{
									thongtin.Add(new ThongTin
									{
										User = acc[0],
										Pass = acc[1],
										cookie = acc[2],
										Color = 2
									});
								}
								break;
							case 3:
								if (acc.Count() >= 5)
								{
									thongtin.Add(new ThongTin
									{
										User = acc[0],
										Pass = acc[1],
										cookie = acc[2],
										Mail = acc[3],
										Pass_Mail = acc[4],
										Color = 2
									});
								}
								break;
							case 4:
								if (acc.Count() >= 6)
								{
									thongtin.Add(new ThongTin
									{
										User = acc[0],
										Pass = acc[1],
										cookie = acc[2],
										Mail = acc[3],
										Pass_Mail = acc[4],
										proxy = acc[5],
										Color = 2
									});
								}
								break;
							case 5:
							{
								ThongTin tt2 = new ThongTin();
								Invoke((MethodInvoker)delegate
								{
									int selectedIndex = cbb_DinhDang1.SelectedIndex;
									int selectedIndex2 = cbb_DinhDang2.SelectedIndex;
									int selectedIndex3 = cbb_DinhDang3.SelectedIndex;
									int selectedIndex4 = cbb_DinhDang4.SelectedIndex;
									int selectedIndex5 = cbb_DinhDang5.SelectedIndex;
									int selectedIndex6 = cbb_DinhDang6.SelectedIndex;
									nhaptaikhoan obj = this;
									ThongTin thongTin = tt2;
									object acc2;
									if (acc.Count() < 1)
									{
										acc2 = "";
									}
									else
									{
										string[] array = acc;
										acc2 = ((array != null) ? array[0] : null);
									}
									obj.check(selectedIndex, thongTin, (string)acc2);
									nhaptaikhoan obj2 = this;
									ThongTin thongTin2 = tt2;
									object acc3;
									if (acc.Count() < 2)
									{
										acc3 = "";
									}
									else
									{
										string[] array2 = acc;
										acc3 = ((array2 != null) ? array2[1] : null);
									}
									obj2.check(selectedIndex2, thongTin2, (string)acc3);
									nhaptaikhoan obj3 = this;
									ThongTin thongTin3 = tt2;
									object acc4;
									if (acc.Count() < 3)
									{
										acc4 = "";
									}
									else
									{
										string[] array3 = acc;
										acc4 = ((array3 != null) ? array3[2] : null);
									}
									obj3.check(selectedIndex3, thongTin3, (string)acc4);
									nhaptaikhoan obj4 = this;
									ThongTin thongTin4 = tt2;
									object acc5;
									if (acc.Count() < 4)
									{
										acc5 = "";
									}
									else
									{
										string[] array4 = acc;
										acc5 = ((array4 != null) ? array4[3] : null);
									}
									obj4.check(selectedIndex4, thongTin4, (string)acc5);
									nhaptaikhoan obj5 = this;
									ThongTin thongTin5 = tt2;
									object acc6;
									if (acc.Count() < 5)
									{
										acc6 = "";
									}
									else
									{
										string[] array5 = acc;
										acc6 = ((array5 != null) ? array5[4] : null);
									}
									obj5.check(selectedIndex5, thongTin5, (string)acc6);
									nhaptaikhoan obj6 = this;
									ThongTin thongTin6 = tt2;
									object acc7;
									if (acc.Count() < 6)
									{
										acc7 = "";
									}
									else
									{
										string[] array6 = acc;
										acc7 = ((array6 != null) ? array6[5] : null);
									}
									obj6.check(selectedIndex6, thongTin6, (string)acc7);
									tt2.Color = 2;
									thongtin.Add(tt2);
								});
								break;
							}
							}
							dem++;
						}
					}
					sQLite.Save_Data(thongtin);
					if (cb_CheckThongTin.Checked && !string.IsNullOrEmpty(ThongSo_CauHinhTuongTac.txt_cookiecheck))
					{
						Selenium selenium = new Selenium(thongtin);
						string text = selenium.checkTTLN();
					}
					Invoke((MethodInvoker)delegate
					{
						lb_Loading.Enabled = false;
						lb_TongAcc.Text = dem.ToString();
					});
					Form1.remote.Load_dgvacc();
				});
				task2.Start();
				break;
			}
			case 1:
			{
				Task task = new Task(delegate
				{
					SQLite sQLite2 = new SQLite();
					foreach (string item2 in L_tt)
					{
						string[] acc8 = item2.Split('|');
						if (!sQLite2.Select_Data_User_FB(acc8[0]))
						{
							int a2 = 0;
							Invoke((MethodInvoker)delegate
							{
								a2 = cbb_DinhDangNhap.SelectedIndex;
							});
							switch (a2)
							{
							case 0:
								if (acc8.Count() >= 2)
								{
									thongtin.Add(new ThongTin
									{
										User = acc8[0],
										Pass = acc8[1],
										Color = 2
									});
								}
								break;
							case 1:
								if (acc8.Count() >= 3)
								{
									thongtin.Add(new ThongTin
									{
										User = acc8[0],
										Pass = acc8[1],
										cookie = acc8[2],
										Color = 2
									});
								}
								break;
							case 2:
								if (acc8.Count() >= 4)
								{
									thongtin.Add(new ThongTin
									{
										User = acc8[0],
										Pass = acc8[1],
										cookie = acc8[2],
										_2FA = acc8[3],
										Color = 2
									});
								}
								break;
							case 3:
								if (acc8.Count() >= 5)
								{
									thongtin.Add(new ThongTin
									{
										User = acc8[0],
										Pass = acc8[1],
										cookie = acc8[2],
										_2FA = acc8[3],
										proxy = acc8[4],
										Color = 2
									});
								}
								break;
							case 4:
							{
								ThongTin tt3 = new ThongTin();
								Invoke((MethodInvoker)delegate
								{
									int selectedIndex7 = cbb_DinhDang1.SelectedIndex;
									int selectedIndex8 = cbb_DinhDang2.SelectedIndex;
									int selectedIndex9 = cbb_DinhDang3.SelectedIndex;
									int selectedIndex10 = cbb_DinhDang4.SelectedIndex;
									int selectedIndex11 = cbb_DinhDang5.SelectedIndex;
									nhaptaikhoan obj7 = this;
									ThongTin thongTin7 = tt3;
									object acc9;
									if (acc8.Count() < 1)
									{
										acc9 = "";
									}
									else
									{
										string[] array7 = acc8;
										acc9 = ((array7 != null) ? array7[0] : null);
									}
									obj7.check(selectedIndex7, thongTin7, (string)acc9);
									nhaptaikhoan obj8 = this;
									ThongTin thongTin8 = tt3;
									object acc10;
									if (acc8.Count() < 2)
									{
										acc10 = "";
									}
									else
									{
										string[] array8 = acc8;
										acc10 = ((array8 != null) ? array8[1] : null);
									}
									obj8.check(selectedIndex8, thongTin8, (string)acc10);
									nhaptaikhoan obj9 = this;
									ThongTin thongTin9 = tt3;
									object acc11;
									if (acc8.Count() < 3)
									{
										acc11 = "";
									}
									else
									{
										string[] array9 = acc8;
										acc11 = ((array9 != null) ? array9[2] : null);
									}
									obj9.check(selectedIndex9, thongTin9, (string)acc11);
									nhaptaikhoan obj10 = this;
									ThongTin thongTin10 = tt3;
									object acc12;
									if (acc8.Count() < 4)
									{
										acc12 = "";
									}
									else
									{
										string[] array10 = acc8;
										acc12 = ((array10 != null) ? array10[3] : null);
									}
									obj10.check(selectedIndex10, thongTin10, (string)acc12);
									nhaptaikhoan obj11 = this;
									ThongTin thongTin11 = tt3;
									object acc13;
									if (acc8.Count() < 5)
									{
										acc13 = "";
									}
									else
									{
										string[] array11 = acc8;
										acc13 = ((array11 != null) ? array11[4] : null);
									}
									obj11.check(selectedIndex11, thongTin11, (string)acc13);
									tt3.Color = 2;
									thongtin.Add(tt3);
								});
								break;
							}
							}
							dem++;
						}
					}
					if (cb_CheckThongTin.Checked)
					{
						int live = 0;
						int die = 0;
						foreach (ThongTin item3 in thongtin)
						{
							string text2 = Inswfb.remote.CheckInfoUsingUid(item3.User);
							if (text2.StartsWith("0|"))
							{
								if (Inswfb.remote.CheckLiveWall(item3.User).StartsWith("0|"))
								{
									item3.Color = 0;
									die++;
								}
								else
								{
									item3.Color = 2;
								}
							}
							else if (text2.StartsWith("1|"))
							{
								live++;
								item3.Color = 1;
							}
							else
							{
								item3.Color = 2;
							}
							Invoke((MethodInvoker)delegate
							{
								lb_Live.Text = live.ToString();
								lb_die.Text = die.ToString();
							});
						}
					}
					sQLite2.Save_Data_FB(thongtin);
					Invoke((MethodInvoker)delegate
					{
						lb_Loading.Enabled = false;
						lb_TongAcc.Text = dem.ToString();
					});
					Inswfb.remote.Load_dgvacc();
				});
				task.Start();
				break;
			}
			}
		}

		public void lb1(int i)
		{
			Invoke((MethodInvoker)delegate
			{
				if (i == 0)
				{
					label1.ForeColor = Color.Green;
				}
				else if (i == 1)
				{
					label1.Text = "! Cookie Check Die.";
					label1.ForeColor = Color.Red;
				}
			});
		}

		public void load_livedie(int live, int die)
		{
			try
			{
				Invoke((MethodInvoker)delegate
				{
					lb_Live.Text = live.ToString();
					lb_die.Text = die.ToString();
				});
			}
			catch
			{
			}
		}

		private void check(int cbb_dd1, ThongTin tt, string acc)
		{
			if (dang == 0)
			{
				switch (cbb_dd1)
				{
				case 0:
					if (acc.Count() >= cbb_dd1)
					{
						tt.User = acc;
					}
					break;
				case 1:
					if (acc.Count() >= cbb_dd1)
					{
						tt.Pass = acc;
					}
					break;
				case 2:
					if (acc.Count() >= cbb_dd1)
					{
						tt.cookie = acc;
					}
					break;
				case 3:
					if (acc.Count() >= cbb_dd1)
					{
						tt._2FA = acc;
					}
					break;
				case 4:
					if (acc.Count() >= cbb_dd1)
					{
						tt.Mail = acc;
					}
					break;
				case 5:
					if (acc.Count() >= cbb_dd1)
					{
						tt.Pass_Mail = acc;
					}
					break;
				case 6:
					if (acc.Count() >= cbb_dd1)
					{
						tt.proxy = acc;
					}
					break;
				}
			}
			else
			{
				if (dang != 1)
				{
					return;
				}
				switch (cbb_dd1)
				{
				case 0:
					if (acc.Count() >= cbb_dd1)
					{
						tt.User = acc;
					}
					break;
				case 1:
					if (acc.Count() >= cbb_dd1)
					{
						tt.Pass = acc;
					}
					break;
				case 2:
					if (acc.Count() >= cbb_dd1)
					{
						tt.cookie = acc;
					}
					break;
				case 3:
					if (acc.Count() >= cbb_dd1)
					{
						tt._2FA = acc;
					}
					break;
				case 4:
					if (acc.Count() >= cbb_dd1)
					{
						tt.proxy = acc;
					}
					break;
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void nhaptaikhoan_Load(object sender, EventArgs e)
		{
			Form1.remote.Load_CauHinhDoiIP();
			switch (dang)
			{
			case 0:
				cbb_DinhDangNhap.Items.Add("User|Pass");
				cbb_DinhDangNhap.Items.Add("User|Pass|2FA");
				cbb_DinhDangNhap.Items.Add("User|Pass|Cookie");
				cbb_DinhDangNhap.Items.Add("User|Pass|Cookie|Mail|Pass Mail");
				cbb_DinhDangNhap.Items.Add("User|Pass|Cookie|Mail|Pass Mail|Proxy");
				cbb_DinhDangNhap.Items.Add("Other ...");
				foreach (string item in dd_0)
				{
					cbb_DinhDang1.Items.Add(item);
					cbb_DinhDang2.Items.Add(item);
					cbb_DinhDang3.Items.Add(item);
					cbb_DinhDang4.Items.Add(item);
					cbb_DinhDang5.Items.Add(item);
					cbb_DinhDang6.Items.Add(item);
				}
				break;
			case 1:
				cbb_DinhDangNhap.Items.Add("User|Pass");
				cbb_DinhDangNhap.Items.Add("User|Pass|Cookie");
				cbb_DinhDangNhap.Items.Add("User|Pass|Cookie|2FA");
				cbb_DinhDangNhap.Items.Add("User|Pass|Cookie|2FA|Proxy");
				cbb_DinhDangNhap.Items.Add("Other ...");
				foreach (string item2 in dd_1)
				{
					cbb_DinhDang1.Items.Add(item2);
					cbb_DinhDang2.Items.Add(item2);
					cbb_DinhDang3.Items.Add(item2);
					cbb_DinhDang4.Items.Add(item2);
					cbb_DinhDang5.Items.Add(item2);
					cbb_DinhDang6.Items.Add(item2);
				}
				break;
			}
			cbb_DinhDangNhap.SelectedIndex = 0;
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				groupBox1.Text = "Nhập Acc";
				label8.Text = "Định dạng :";
				label15.Text = "Cài đặt : ";
				btnAdd.Text = "Lưu";
				btnCancel.Text = "Thoát";
				cb_CheckThongTin.Text = "Kiểm tra thông tin Acc ( Check Follow, post, name, id, ...)";
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.nhaptaikhoan));
			cbb_DinhDangNhap = new System.Windows.Forms.ComboBox();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			label8 = new System.Windows.Forms.Label();
			plDinhDangNhap = new System.Windows.Forms.Panel();
			cbb_DinhDang1 = new System.Windows.Forms.ComboBox();
			cbb_DinhDang2 = new System.Windows.Forms.ComboBox();
			cbb_DinhDang3 = new System.Windows.Forms.ComboBox();
			cbb_DinhDang4 = new System.Windows.Forms.ComboBox();
			cbb_DinhDang5 = new System.Windows.Forms.ComboBox();
			label13 = new System.Windows.Forms.Label();
			cbb_DinhDang6 = new System.Windows.Forms.ComboBox();
			label12 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			cb_CheckThongTin = new System.Windows.Forms.CheckBox();
			label15 = new System.Windows.Forms.Label();
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
			lb_Loading = new System.Windows.Forms.ToolStripButton();
			groupBox1 = new System.Windows.Forms.GroupBox();
			txt_Account = new System.Windows.Forms.RichTextBox();
			label1 = new System.Windows.Forms.Label();
			plDinhDangNhap.SuspendLayout();
			tstrstatusbar.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			cbb_DinhDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
			cbb_DinhDangNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbb_DinhDangNhap.FormattingEnabled = true;
			cbb_DinhDangNhap.Location = new System.Drawing.Point(117, 265);
			cbb_DinhDangNhap.Name = "cbb_DinhDangNhap";
			cbb_DinhDangNhap.Size = new System.Drawing.Size(341, 21);
			cbb_DinhDangNhap.TabIndex = 52;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(370, 364);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(107, 31);
			btnCancel.TabIndex = 50;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(256, 364);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(107, 31);
			btnAdd.TabIndex = 49;
			btnAdd.Text = "Save";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(28, 268);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(83, 15);
			label8.TabIndex = 56;
			label8.Text = "Input Format :";
			plDinhDangNhap.Controls.Add(cbb_DinhDang1);
			plDinhDangNhap.Controls.Add(cbb_DinhDang2);
			plDinhDangNhap.Controls.Add(cbb_DinhDang3);
			plDinhDangNhap.Controls.Add(cbb_DinhDang4);
			plDinhDangNhap.Controls.Add(cbb_DinhDang5);
			plDinhDangNhap.Controls.Add(label13);
			plDinhDangNhap.Controls.Add(cbb_DinhDang6);
			plDinhDangNhap.Controls.Add(label12);
			plDinhDangNhap.Controls.Add(label11);
			plDinhDangNhap.Controls.Add(label9);
			plDinhDangNhap.Controls.Add(label10);
			plDinhDangNhap.Location = new System.Drawing.Point(117, 300);
			plDinhDangNhap.Name = "plDinhDangNhap";
			plDinhDangNhap.Size = new System.Drawing.Size(557, 28);
			plDinhDangNhap.TabIndex = 57;
			cbb_DinhDang1.Cursor = System.Windows.Forms.Cursors.Hand;
			cbb_DinhDang1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbb_DinhDang1.FormattingEnabled = true;
			cbb_DinhDang1.Location = new System.Drawing.Point(3, 3);
			cbb_DinhDang1.Name = "cbb_DinhDang1";
			cbb_DinhDang1.Size = new System.Drawing.Size(78, 21);
			cbb_DinhDang1.TabIndex = 40;
			cbb_DinhDang2.Cursor = System.Windows.Forms.Cursors.Hand;
			cbb_DinhDang2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbb_DinhDang2.FormattingEnabled = true;
			cbb_DinhDang2.Location = new System.Drawing.Point(96, 3);
			cbb_DinhDang2.Name = "cbb_DinhDang2";
			cbb_DinhDang2.Size = new System.Drawing.Size(78, 21);
			cbb_DinhDang2.TabIndex = 40;
			cbb_DinhDang3.Cursor = System.Windows.Forms.Cursors.Hand;
			cbb_DinhDang3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbb_DinhDang3.FormattingEnabled = true;
			cbb_DinhDang3.Location = new System.Drawing.Point(189, 3);
			cbb_DinhDang3.Name = "cbb_DinhDang3";
			cbb_DinhDang3.Size = new System.Drawing.Size(78, 21);
			cbb_DinhDang3.TabIndex = 40;
			cbb_DinhDang4.Cursor = System.Windows.Forms.Cursors.Hand;
			cbb_DinhDang4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbb_DinhDang4.FormattingEnabled = true;
			cbb_DinhDang4.Location = new System.Drawing.Point(282, 3);
			cbb_DinhDang4.Name = "cbb_DinhDang4";
			cbb_DinhDang4.Size = new System.Drawing.Size(78, 21);
			cbb_DinhDang4.TabIndex = 40;
			cbb_DinhDang5.Cursor = System.Windows.Forms.Cursors.Hand;
			cbb_DinhDang5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbb_DinhDang5.FormattingEnabled = true;
			cbb_DinhDang5.Location = new System.Drawing.Point(375, 3);
			cbb_DinhDang5.Name = "cbb_DinhDang5";
			cbb_DinhDang5.Size = new System.Drawing.Size(78, 21);
			cbb_DinhDang5.TabIndex = 40;
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Tahoma", 12f);
			label13.Location = new System.Drawing.Point(453, 3);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(15, 19);
			label13.TabIndex = 41;
			label13.Text = "|";
			cbb_DinhDang6.Cursor = System.Windows.Forms.Cursors.Hand;
			cbb_DinhDang6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbb_DinhDang6.FormattingEnabled = true;
			cbb_DinhDang6.Location = new System.Drawing.Point(468, 3);
			cbb_DinhDang6.Name = "cbb_DinhDang6";
			cbb_DinhDang6.Size = new System.Drawing.Size(78, 21);
			cbb_DinhDang6.TabIndex = 40;
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Tahoma", 12f);
			label12.Location = new System.Drawing.Point(360, 3);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(15, 19);
			label12.TabIndex = 41;
			label12.Text = "|";
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Tahoma", 12f);
			label11.Location = new System.Drawing.Point(267, 3);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(15, 19);
			label11.TabIndex = 41;
			label11.Text = "|";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Tahoma", 12f);
			label9.Location = new System.Drawing.Point(81, 3);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(15, 19);
			label9.TabIndex = 41;
			label9.Text = "|";
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Tahoma", 12f);
			label10.Location = new System.Drawing.Point(174, 3);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(15, 19);
			label10.TabIndex = 41;
			label10.Text = "|";
			cb_CheckThongTin.AutoSize = true;
			cb_CheckThongTin.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_CheckThongTin.Location = new System.Drawing.Point(120, 338);
			cb_CheckThongTin.Name = "cb_CheckThongTin";
			cb_CheckThongTin.Size = new System.Drawing.Size(302, 19);
			cb_CheckThongTin.TabIndex = 59;
			cb_CheckThongTin.Text = "check information ( Check Follow, post, name, id, ...)";
			cb_CheckThongTin.UseVisualStyleBackColor = true;
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(28, 340);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(55, 15);
			label15.TabIndex = 58;
			label15.Text = "Options :";
			tstrstatusbar.Dock = System.Windows.Forms.DockStyle.Bottom;
			tstrstatusbar.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			tstrstatusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				toolStripLabel1, lb_IP, lb_loadIP, toolStripSeparator3, toolStripLabel3, lb_Live, toolStripSeparator1, toolStripLabel7, lb_die, toolStripSeparator2,
				toolStripLabel4, lb_TongAcc, toolStripSeparator4, lb_Loading
			});
			tstrstatusbar.Location = new System.Drawing.Point(0, 407);
			tstrstatusbar.Name = "tstrstatusbar";
			tstrstatusbar.Size = new System.Drawing.Size(713, 25);
			tstrstatusbar.TabIndex = 71;
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
			lb_Loading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			lb_Loading.Enabled = false;
			lb_Loading.Image = (System.Drawing.Image)resources.GetObject("lb_Loading.Image");
			lb_Loading.ImageTransparentColor = System.Drawing.Color.Magenta;
			lb_Loading.Name = "lb_Loading";
			lb_Loading.Size = new System.Drawing.Size(23, 22);
			groupBox1.Controls.Add(txt_Account);
			groupBox1.Location = new System.Drawing.Point(12, 11);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(689, 238);
			groupBox1.TabIndex = 72;
			groupBox1.TabStop = false;
			groupBox1.Text = "Write Acc";
			txt_Account.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Account.Dock = System.Windows.Forms.DockStyle.Fill;
			txt_Account.Location = new System.Drawing.Point(3, 19);
			txt_Account.Name = "txt_Account";
			txt_Account.Size = new System.Drawing.Size(683, 216);
			txt_Account.TabIndex = 74;
			txt_Account.Text = "";
			txt_Account.WordWrap = false;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(489, 268);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(85, 15);
			label1.TabIndex = 73;
			label1.Text = "                          ";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(713, 432);
			base.Controls.Add(label1);
			base.Controls.Add(groupBox1);
			base.Controls.Add(tstrstatusbar);
			base.Controls.Add(cb_CheckThongTin);
			base.Controls.Add(label15);
			base.Controls.Add(plDinhDangNhap);
			base.Controls.Add(label8);
			base.Controls.Add(cbb_DinhDangNhap);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "nhaptaikhoan";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Import Account";
			base.Load += new System.EventHandler(nhaptaikhoan_Load);
			plDinhDangNhap.ResumeLayout(false);
			plDinhDangNhap.PerformLayout();
			tstrstatusbar.ResumeLayout(false);
			tstrstatusbar.PerformLayout();
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
