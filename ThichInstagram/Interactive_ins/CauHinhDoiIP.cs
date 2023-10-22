using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class CauHinhDoiIP : Form
	{
		private IContainer components = null;

		private RadioButton rad_ChangIP_Dcom;

		private RadioButton rad_ChangIP_No;

		private Label label4;

		private NumericUpDown num_Thread_ChangeIP;

		private Label label2;

		private Button btn_LaytenDcom;

		private TextBox txt_URL;

		private Label label1;

		private RadioButton rad_Dcom_Hilink;

		private RadioButton rad_Dcom_Thuong;

		private Button btn_CheckChangeIP;

		private TextBox txt_Name_Dcom;

		private RadioButton rad_ChangIP_Proxy;

		private GroupBox gr_changeDcom;

		private RadioButton rad_ChangIP_HMA;

		private GroupBox groupBox1;

		private Button btnCancel;

		private Button btnAdd;

		private GroupBox groupBox5;

		private RadioButton rad_Xproxy_Sock5;

		private RadioButton rad_Xproxy_Http;

		private Label label7;

		private TextBox txt_Service_Url;

		private Label label6;

		private RichTextBox rtb_Xproxy_Proxy;

		private RadioButton rad_ChangIP_Xproxy;

		private Label label8;

		private GroupBox groupBox2;

		private RichTextBox rtb_KeyShoplike;

		private GroupBox groupBox3;

		private RichTextBox rtb_KeyTinsoft;

		private RadioButton rad_ChangIP_ShopLike;

		private RadioButton rad_ChangIP_Tinsoft;

		private GroupBox groupBox6;

		private RichTextBox rtb_KeyMinproxy;

		private RadioButton rad_ChangIP_Minproxy;

		private Label label3;

		private ComboBox cbb_SelecTypeIP;

		private Label label12;

		public CauHinhDoiIP()
		{
			InitializeComponent();
		}

		private void save()
		{
			JSON_Settings jSON_Settings = new JSON_Settings(Load_file.path_CauHinhDoiIP);
			jSON_Settings.Add("num_Thread_ChangeIP", num_Thread_ChangeIP.Value.ToString());
			jSON_Settings.Add("rad_ChangIP_No", rad_ChangIP_No.Checked.ToString());
			jSON_Settings.Add("rad_ChangIP_HMA", rad_ChangIP_HMA.Checked.ToString());
			jSON_Settings.Add("rad_ChangIP_Dcom", rad_ChangIP_Dcom.Checked.ToString());
			jSON_Settings.Add("rad_ChangIP_Proxy", rad_ChangIP_Proxy.Checked.ToString());
			jSON_Settings.Add("rad_ChangIP_Tinsoft", rad_ChangIP_Tinsoft.Checked.ToString());
			jSON_Settings.Add("rad_ChangIP_ShopLike", rad_ChangIP_ShopLike.Checked.ToString());
			jSON_Settings.Add("rad_Dcom_Thuong", rad_Dcom_Thuong.Checked.ToString());
			jSON_Settings.Add("rad_Dcom_Hilink", rad_Dcom_Hilink.Checked.ToString());
			jSON_Settings.Add("txt_Name_Dcom", txt_Name_Dcom.Text);
			jSON_Settings.Add("txt_URL", txt_URL.Text);
			jSON_Settings.Add("rtb_KeyShoplike", rtb_KeyShoplike.Text);
			jSON_Settings.Add("rtb_KeyTinsoft", rtb_KeyTinsoft.Text);
			jSON_Settings.Add("rad_ChangIP_Xproxy", rad_ChangIP_Xproxy.Checked.ToString());
			jSON_Settings.Add("rad_Xproxy_Http", rad_Xproxy_Http.Checked.ToString());
			jSON_Settings.Add("rad_Xproxy_Sock5", rad_Xproxy_Sock5.Checked.ToString());
			jSON_Settings.Add("txt_Service_Url", txt_Service_Url.Text);
			jSON_Settings.Add("rtb_Xproxy_Proxy", rtb_Xproxy_Proxy.Text);
			jSON_Settings.Add("rad_ChangIP_Minproxy", rad_ChangIP_Minproxy.Checked.ToString());
			jSON_Settings.Add("rtb_KeyMinproxy", rtb_KeyMinproxy.Text);
			jSON_Settings.Add("cbb_SelecTypeIP", cbb_SelecTypeIP.SelectedIndex.ToString());
		}

		private void load()
		{
			JSON_Settings jSON_Settings = new JSON_Settings(Load_file.path_CauHinhDoiIP);
			try
			{
				num_Thread_ChangeIP.Value = jSON_Settings.GetValueInt("num_Thread_ChangeIP");
				rad_ChangIP_No.Checked = jSON_Settings.GetValueBool("rad_ChangIP_No");
				rad_ChangIP_HMA.Checked = jSON_Settings.GetValueBool("rad_ChangIP_HMA");
				rad_ChangIP_Dcom.Checked = jSON_Settings.GetValueBool("rad_ChangIP_Dcom");
				rad_ChangIP_Proxy.Checked = jSON_Settings.GetValueBool("rad_ChangIP_Proxy");
				rad_ChangIP_Tinsoft.Checked = jSON_Settings.GetValueBool("rad_ChangIP_Tinsoft");
				rad_ChangIP_ShopLike.Checked = jSON_Settings.GetValueBool("rad_ChangIP_ShopLike");
				rad_Dcom_Thuong.Checked = jSON_Settings.GetValueBool("rad_Dcom_Thuong");
				rad_Dcom_Hilink.Checked = jSON_Settings.GetValueBool("rad_Dcom_Hilink");
				txt_Name_Dcom.Text = jSON_Settings.GetValue("txt_Name_Dcom");
				txt_URL.Text = jSON_Settings.GetValue("txt_URL");
				rtb_KeyShoplike.Text = jSON_Settings.GetValue("rtb_KeyShoplike");
				rtb_KeyTinsoft.Text = jSON_Settings.GetValue("rtb_KeyTinsoft");
				rad_ChangIP_Xproxy.Checked = jSON_Settings.GetValueBool("rad_ChangIP_Xproxy");
				rad_Xproxy_Http.Checked = jSON_Settings.GetValueBool("rad_Xproxy_Http");
				rad_Xproxy_Sock5.Checked = jSON_Settings.GetValueBool("rad_Xproxy_Sock5");
				txt_Service_Url.Text = jSON_Settings.GetValue("txt_Service_Url");
				rtb_Xproxy_Proxy.Text = jSON_Settings.GetValue("rtb_Xproxy_Proxy");
				rad_ChangIP_Minproxy.Checked = jSON_Settings.GetValueBool("rad_ChangIP_Minproxy");
				rtb_KeyMinproxy.Text = jSON_Settings.GetValue("rtb_KeyMinproxy");
				cbb_SelecTypeIP.SelectedIndex = jSON_Settings.GetValueInt("cbb_SelecTypeIP");
			}
			catch
			{
			}
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void rad_ChangIP_Dcom_CheckedChanged(object sender, EventArgs e)
		{
			if (rad_ChangIP_Dcom.Checked)
			{
				gr_changeDcom.Enabled = true;
				btn_CheckChangeIP.Enabled = true;
			}
			else
			{
				gr_changeDcom.Enabled = false;
				btn_CheckChangeIP.Enabled = false;
			}
		}

		private void rad_ChangIP_HMA_CheckedChanged(object sender, EventArgs e)
		{
			if (rad_ChangIP_HMA.Checked)
			{
				btn_CheckChangeIP.Enabled = true;
			}
			else
			{
				btn_CheckChangeIP.Enabled = false;
			}
		}

		private void btn_LaytenDcom_Click(object sender, EventArgs e)
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo("rasdial.exe")
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				};
				Process process = Process.Start(startInfo);
				string text = process.StandardOutput.ReadToEnd();
				if (text.Split('\n').Length <= 3)
				{
					MessageBox.Show("Please connect Dcom first !");
					return;
				}
				txt_Name_Dcom.Text = text.Split('\n').ToList()[1];
				MessageBox.Show("Retrieving Dcom configuration name successful !");
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred : " + ex.Message);
			}
		}

		private void btn_OK_Click(object sender, EventArgs e)
		{
			save();
			Close();
		}

		private void CauHinhDoiIP_Load(object sender, EventArgs e)
		{
			load();
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label2.Text = "Đổi IP sau : ";
				label4.Text = "( Lượt )";
				rad_ChangIP_No.Text = "Không đổi IP";
				rad_ChangIP_HMA.Text = "Đổi IP bằng HMA";
				rad_ChangIP_Dcom.Text = "Đổi IP bằng Dcom";
				rad_ChangIP_Proxy.Text = "Dùng Proxy";
				btn_LaytenDcom.Text = "Lấy tên";
				label7.Text = "Loại Proxy : ";
				label8.Text = "Nhập Proxy : ";
				btnAdd.Text = "Lưu";
				btnCancel.Text = "Thoát";
				groupBox1.Text = "Cấu hình đổi IP";
				label12.Text = "Loại IP :";
			}
		}

		private void btn_CheckChangeIP_Click(object sender, EventArgs e)
		{
			ChangeIP changeIP = new ChangeIP();
			if (rad_Dcom_Thuong.Checked)
			{
				changeIP.ChangeIP_Dcom(txt_Name_Dcom.Text);
			}
			else if (rad_ChangIP_HMA.Checked)
			{
				if (changeIP.ChangeIP_HMA())
				{
					MessageBox.Show("Change ip successfully !", "Notify !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("Change ip failed !", "Notify !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			else if (rad_ChangIP_Xproxy.Checked)
			{
				List<string> list = rtb_Xproxy_Proxy.Text.Split('\n').ToList();
				list?.RemoveAll((string x) => x == "");
				changeIP.ChangeIP_Xproxy(txt_Service_Url.Text, list);
			}
			else if (rad_Dcom_Hilink.Checked)
			{
				bool flag = false;
				int num = changeIP.ResetHilink(txt_URL.Text);
				if (num == 0)
				{
					Thread.Sleep(2000);
					num = changeIP.ResetHilink(txt_URL.Text);
				}
				if (num == 1)
				{
					MessageBox.Show("Change ip successfully !", "Notify !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("Change ip failed !", "Notify !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
		}

		private void groupBox5_Enter(object sender, EventArgs e)
		{
		}

		private void rad_ChangIP_Xproxy_CheckedChanged(object sender, EventArgs e)
		{
			if (rad_ChangIP_Xproxy.Checked)
			{
				btn_CheckChangeIP.Enabled = true;
			}
			else
			{
				rad_ChangIP_Xproxy.Enabled = false;
			}
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{
		}

		private void rad_ChangIP_Minproxy_CheckedChanged(object sender, EventArgs e)
		{
			if (rad_ChangIP_Minproxy.Checked)
			{
				groupBox6.Enabled = true;
			}
			else
			{
				groupBox6.Enabled = false;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.CauHinhDoiIP));
			rad_ChangIP_Dcom = new System.Windows.Forms.RadioButton();
			rad_ChangIP_No = new System.Windows.Forms.RadioButton();
			label4 = new System.Windows.Forms.Label();
			num_Thread_ChangeIP = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			btn_LaytenDcom = new System.Windows.Forms.Button();
			txt_URL = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			rad_Dcom_Hilink = new System.Windows.Forms.RadioButton();
			rad_Dcom_Thuong = new System.Windows.Forms.RadioButton();
			btn_CheckChangeIP = new System.Windows.Forms.Button();
			txt_Name_Dcom = new System.Windows.Forms.TextBox();
			rad_ChangIP_Proxy = new System.Windows.Forms.RadioButton();
			gr_changeDcom = new System.Windows.Forms.GroupBox();
			rad_ChangIP_HMA = new System.Windows.Forms.RadioButton();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox6 = new System.Windows.Forms.GroupBox();
			cbb_SelecTypeIP = new System.Windows.Forms.ComboBox();
			label12 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			rtb_KeyMinproxy = new System.Windows.Forms.RichTextBox();
			rad_ChangIP_Minproxy = new System.Windows.Forms.RadioButton();
			groupBox5 = new System.Windows.Forms.GroupBox();
			label8 = new System.Windows.Forms.Label();
			rad_Xproxy_Sock5 = new System.Windows.Forms.RadioButton();
			rad_Xproxy_Http = new System.Windows.Forms.RadioButton();
			label7 = new System.Windows.Forms.Label();
			txt_Service_Url = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			rtb_Xproxy_Proxy = new System.Windows.Forms.RichTextBox();
			rad_ChangIP_Xproxy = new System.Windows.Forms.RadioButton();
			groupBox2 = new System.Windows.Forms.GroupBox();
			rtb_KeyShoplike = new System.Windows.Forms.RichTextBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_KeyTinsoft = new System.Windows.Forms.RichTextBox();
			rad_ChangIP_ShopLike = new System.Windows.Forms.RadioButton();
			rad_ChangIP_Tinsoft = new System.Windows.Forms.RadioButton();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_Thread_ChangeIP).BeginInit();
			gr_changeDcom.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox6.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			rad_ChangIP_Dcom.AutoSize = true;
			rad_ChangIP_Dcom.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			rad_ChangIP_Dcom.ForeColor = System.Drawing.Color.DarkBlue;
			rad_ChangIP_Dcom.Location = new System.Drawing.Point(24, 132);
			rad_ChangIP_Dcom.Name = "rad_ChangIP_Dcom";
			rad_ChangIP_Dcom.Size = new System.Drawing.Size(115, 19);
			rad_ChangIP_Dcom.TabIndex = 44;
			rad_ChangIP_Dcom.Text = "Change IP Dcom";
			rad_ChangIP_Dcom.UseVisualStyleBackColor = true;
			rad_ChangIP_Dcom.CheckedChanged += new System.EventHandler(rad_ChangIP_Dcom_CheckedChanged);
			rad_ChangIP_No.AutoSize = true;
			rad_ChangIP_No.Checked = true;
			rad_ChangIP_No.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			rad_ChangIP_No.ForeColor = System.Drawing.Color.DarkRed;
			rad_ChangIP_No.Location = new System.Drawing.Point(24, 77);
			rad_ChangIP_No.Name = "rad_ChangIP_No";
			rad_ChangIP_No.Size = new System.Drawing.Size(118, 19);
			rad_ChangIP_No.TabIndex = 43;
			rad_ChangIP_No.TabStop = true;
			rad_ChangIP_No.Text = "Do not change IP";
			rad_ChangIP_No.UseVisualStyleBackColor = true;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Italic);
			label4.Location = new System.Drawing.Point(177, 30);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(47, 15);
			label4.TabIndex = 42;
			label4.Text = "( Turn )";
			num_Thread_ChangeIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			num_Thread_ChangeIP.Location = new System.Drawing.Point(124, 27);
			num_Thread_ChangeIP.Name = "num_Thread_ChangeIP";
			num_Thread_ChangeIP.Size = new System.Drawing.Size(55, 21);
			num_Thread_ChangeIP.TabIndex = 41;
			num_Thread_ChangeIP.Value = new decimal(new int[4] { 6, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			label2.Location = new System.Drawing.Point(21, 30);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(93, 15);
			label2.TabIndex = 40;
			label2.Text = "Change IP later :";
			btn_LaytenDcom.ForeColor = System.Drawing.Color.Maroon;
			btn_LaytenDcom.Location = new System.Drawing.Point(73, 18);
			btn_LaytenDcom.Name = "btn_LaytenDcom";
			btn_LaytenDcom.Size = new System.Drawing.Size(72, 27);
			btn_LaytenDcom.TabIndex = 5;
			btn_LaytenDcom.Text = "Get Name";
			btn_LaytenDcom.UseVisualStyleBackColor = true;
			btn_LaytenDcom.Click += new System.EventHandler(btn_LaytenDcom_Click);
			txt_URL.Location = new System.Drawing.Point(156, 57);
			txt_URL.Name = "txt_URL";
			txt_URL.Size = new System.Drawing.Size(92, 23);
			txt_URL.TabIndex = 4;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(73, 61);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(84, 15);
			label1.TabIndex = 3;
			label1.Text = "Name Dcom : ";
			rad_Dcom_Hilink.AutoSize = true;
			rad_Dcom_Hilink.Location = new System.Drawing.Point(12, 58);
			rad_Dcom_Hilink.Name = "rad_Dcom_Hilink";
			rad_Dcom_Hilink.Size = new System.Drawing.Size(56, 19);
			rad_Dcom_Hilink.TabIndex = 2;
			rad_Dcom_Hilink.TabStop = true;
			rad_Dcom_Hilink.Text = "Hilink";
			rad_Dcom_Hilink.UseVisualStyleBackColor = true;
			rad_Dcom_Thuong.AutoSize = true;
			rad_Dcom_Thuong.Location = new System.Drawing.Point(12, 22);
			rad_Dcom_Thuong.Name = "rad_Dcom_Thuong";
			rad_Dcom_Thuong.Size = new System.Drawing.Size(47, 19);
			rad_Dcom_Thuong.TabIndex = 1;
			rad_Dcom_Thuong.TabStop = true;
			rad_Dcom_Thuong.Text = "APP";
			rad_Dcom_Thuong.UseVisualStyleBackColor = true;
			btn_CheckChangeIP.Enabled = false;
			btn_CheckChangeIP.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			btn_CheckChangeIP.ForeColor = System.Drawing.Color.Maroon;
			btn_CheckChangeIP.Location = new System.Drawing.Point(229, 23);
			btn_CheckChangeIP.Name = "btn_CheckChangeIP";
			btn_CheckChangeIP.Size = new System.Drawing.Size(55, 29);
			btn_CheckChangeIP.TabIndex = 45;
			btn_CheckChangeIP.Text = "Test";
			btn_CheckChangeIP.UseVisualStyleBackColor = true;
			btn_CheckChangeIP.Click += new System.EventHandler(btn_CheckChangeIP_Click);
			txt_Name_Dcom.Location = new System.Drawing.Point(155, 21);
			txt_Name_Dcom.Name = "txt_Name_Dcom";
			txt_Name_Dcom.Size = new System.Drawing.Size(93, 23);
			txt_Name_Dcom.TabIndex = 1;
			rad_ChangIP_Proxy.AutoSize = true;
			rad_ChangIP_Proxy.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			rad_ChangIP_Proxy.ForeColor = System.Drawing.Color.DarkBlue;
			rad_ChangIP_Proxy.Location = new System.Drawing.Point(180, 132);
			rad_ChangIP_Proxy.Name = "rad_ChangIP_Proxy";
			rad_ChangIP_Proxy.Size = new System.Drawing.Size(77, 19);
			rad_ChangIP_Proxy.TabIndex = 50;
			rad_ChangIP_Proxy.Text = "Use Proxy";
			rad_ChangIP_Proxy.UseVisualStyleBackColor = true;
			gr_changeDcom.Controls.Add(btn_LaytenDcom);
			gr_changeDcom.Controls.Add(txt_URL);
			gr_changeDcom.Controls.Add(label1);
			gr_changeDcom.Controls.Add(rad_Dcom_Hilink);
			gr_changeDcom.Controls.Add(rad_Dcom_Thuong);
			gr_changeDcom.Controls.Add(txt_Name_Dcom);
			gr_changeDcom.Enabled = false;
			gr_changeDcom.Location = new System.Drawing.Point(24, 149);
			gr_changeDcom.Name = "gr_changeDcom";
			gr_changeDcom.Size = new System.Drawing.Size(260, 94);
			gr_changeDcom.TabIndex = 3;
			gr_changeDcom.TabStop = false;
			rad_ChangIP_HMA.AutoSize = true;
			rad_ChangIP_HMA.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			rad_ChangIP_HMA.ForeColor = System.Drawing.Color.DarkBlue;
			rad_ChangIP_HMA.Location = new System.Drawing.Point(24, 105);
			rad_ChangIP_HMA.Name = "rad_ChangIP_HMA";
			rad_ChangIP_HMA.Size = new System.Drawing.Size(110, 19);
			rad_ChangIP_HMA.TabIndex = 49;
			rad_ChangIP_HMA.Text = "Change IP HMA";
			rad_ChangIP_HMA.UseVisualStyleBackColor = true;
			groupBox1.Controls.Add(groupBox6);
			groupBox1.Controls.Add(rad_ChangIP_Minproxy);
			groupBox1.Controls.Add(groupBox5);
			groupBox1.Controls.Add(rad_ChangIP_Xproxy);
			groupBox1.Controls.Add(groupBox2);
			groupBox1.Controls.Add(groupBox3);
			groupBox1.Controls.Add(rad_ChangIP_ShopLike);
			groupBox1.Controls.Add(gr_changeDcom);
			groupBox1.Controls.Add(rad_ChangIP_Proxy);
			groupBox1.Controls.Add(rad_ChangIP_HMA);
			groupBox1.Controls.Add(rad_ChangIP_Tinsoft);
			groupBox1.Controls.Add(btn_CheckChangeIP);
			groupBox1.Controls.Add(rad_ChangIP_Dcom);
			groupBox1.Controls.Add(rad_ChangIP_No);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(num_Thread_ChangeIP);
			groupBox1.Controls.Add(label2);
			groupBox1.Location = new System.Drawing.Point(14, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(880, 427);
			groupBox1.TabIndex = 62;
			groupBox1.TabStop = false;
			groupBox1.Text = "Change IP";
			groupBox1.Enter += new System.EventHandler(groupBox1_Enter);
			groupBox6.Controls.Add(cbb_SelecTypeIP);
			groupBox6.Controls.Add(label12);
			groupBox6.Controls.Add(label3);
			groupBox6.Controls.Add(rtb_KeyMinproxy);
			groupBox6.Enabled = false;
			groupBox6.Location = new System.Drawing.Point(605, 42);
			groupBox6.Name = "groupBox6";
			groupBox6.Size = new System.Drawing.Size(260, 146);
			groupBox6.TabIndex = 206;
			groupBox6.TabStop = false;
			cbb_SelecTypeIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbb_SelecTypeIP.FormattingEnabled = true;
			cbb_SelecTypeIP.Items.AddRange(new object[2] { "Dân cư", "IPv6" });
			cbb_SelecTypeIP.Location = new System.Drawing.Point(95, 15);
			cbb_SelecTypeIP.Name = "cbb_SelecTypeIP";
			cbb_SelecTypeIP.Size = new System.Drawing.Size(150, 23);
			cbb_SelecTypeIP.TabIndex = 14;
			label12.AutoSize = true;
			label12.ForeColor = System.Drawing.Color.DarkRed;
			label12.Location = new System.Drawing.Point(17, 18);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(52, 15);
			label12.TabIndex = 13;
			label12.Text = "Type IP :";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(17, 46);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(89, 15);
			label3.TabIndex = 12;
			label3.Text = "Key Minproxy : ";
			rtb_KeyMinproxy.Location = new System.Drawing.Point(13, 64);
			rtb_KeyMinproxy.Name = "rtb_KeyMinproxy";
			rtb_KeyMinproxy.Size = new System.Drawing.Size(234, 74);
			rtb_KeyMinproxy.TabIndex = 0;
			rtb_KeyMinproxy.Text = "";
			rtb_KeyMinproxy.WordWrap = false;
			rad_ChangIP_Minproxy.AutoSize = true;
			rad_ChangIP_Minproxy.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			rad_ChangIP_Minproxy.ForeColor = System.Drawing.Color.DarkBlue;
			rad_ChangIP_Minproxy.Location = new System.Drawing.Point(605, 26);
			rad_ChangIP_Minproxy.Name = "rad_ChangIP_Minproxy";
			rad_ChangIP_Minproxy.Size = new System.Drawing.Size(91, 19);
			rad_ChangIP_Minproxy.TabIndex = 207;
			rad_ChangIP_Minproxy.Text = "Minproxy.vn";
			rad_ChangIP_Minproxy.UseVisualStyleBackColor = true;
			rad_ChangIP_Minproxy.CheckedChanged += new System.EventHandler(rad_ChangIP_Minproxy_CheckedChanged);
			groupBox5.Controls.Add(label8);
			groupBox5.Controls.Add(rad_Xproxy_Sock5);
			groupBox5.Controls.Add(rad_Xproxy_Http);
			groupBox5.Controls.Add(label7);
			groupBox5.Controls.Add(txt_Service_Url);
			groupBox5.Controls.Add(label6);
			groupBox5.Controls.Add(rtb_Xproxy_Proxy);
			groupBox5.Location = new System.Drawing.Point(316, 42);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(260, 201);
			groupBox5.TabIndex = 206;
			groupBox5.TabStop = false;
			groupBox5.Enter += new System.EventHandler(groupBox5_Enter);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(6, 74);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(75, 15);
			label8.TabIndex = 11;
			label8.Text = "Write proxy :";
			rad_Xproxy_Sock5.AutoSize = true;
			rad_Xproxy_Sock5.Location = new System.Drawing.Point(174, 45);
			rad_Xproxy_Sock5.Name = "rad_Xproxy_Sock5";
			rad_Xproxy_Sock5.Size = new System.Drawing.Size(58, 19);
			rad_Xproxy_Sock5.TabIndex = 10;
			rad_Xproxy_Sock5.TabStop = true;
			rad_Xproxy_Sock5.Text = "Sock5";
			rad_Xproxy_Sock5.UseVisualStyleBackColor = true;
			rad_Xproxy_Http.AutoSize = true;
			rad_Xproxy_Http.Location = new System.Drawing.Point(103, 45);
			rad_Xproxy_Http.Name = "rad_Xproxy_Http";
			rad_Xproxy_Http.Size = new System.Drawing.Size(49, 19);
			rad_Xproxy_Http.TabIndex = 9;
			rad_Xproxy_Http.TabStop = true;
			rad_Xproxy_Http.Text = "Http";
			rad_Xproxy_Http.UseVisualStyleBackColor = true;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(6, 47);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(69, 15);
			label7.TabIndex = 8;
			label7.Text = "Proxy type :";
			txt_Service_Url.Location = new System.Drawing.Point(87, 16);
			txt_Service_Url.Name = "txt_Service_Url";
			txt_Service_Url.Size = new System.Drawing.Size(167, 23);
			txt_Service_Url.TabIndex = 7;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(6, 19);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(75, 15);
			label6.TabIndex = 6;
			label6.Text = "Service URL :";
			rtb_Xproxy_Proxy.Location = new System.Drawing.Point(9, 97);
			rtb_Xproxy_Proxy.Name = "rtb_Xproxy_Proxy";
			rtb_Xproxy_Proxy.Size = new System.Drawing.Size(245, 98);
			rtb_Xproxy_Proxy.TabIndex = 0;
			rtb_Xproxy_Proxy.Text = "";
			rtb_Xproxy_Proxy.WordWrap = false;
			rad_ChangIP_Xproxy.AutoSize = true;
			rad_ChangIP_Xproxy.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			rad_ChangIP_Xproxy.ForeColor = System.Drawing.Color.DarkBlue;
			rad_ChangIP_Xproxy.Location = new System.Drawing.Point(316, 26);
			rad_ChangIP_Xproxy.Name = "rad_ChangIP_Xproxy";
			rad_ChangIP_Xproxy.Size = new System.Drawing.Size(207, 19);
			rad_ChangIP_Xproxy.TabIndex = 205;
			rad_ChangIP_Xproxy.Text = "Xproxy, Mobi, OBC, Eager, S proxy ";
			rad_ChangIP_Xproxy.UseVisualStyleBackColor = true;
			rad_ChangIP_Xproxy.CheckedChanged += new System.EventHandler(rad_ChangIP_Xproxy_CheckedChanged);
			groupBox2.Controls.Add(rtb_KeyShoplike);
			groupBox2.Location = new System.Drawing.Point(316, 274);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(260, 144);
			groupBox2.TabIndex = 204;
			groupBox2.TabStop = false;
			groupBox2.Text = "Key Shoplike : ";
			rtb_KeyShoplike.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_KeyShoplike.Location = new System.Drawing.Point(3, 19);
			rtb_KeyShoplike.Name = "rtb_KeyShoplike";
			rtb_KeyShoplike.Size = new System.Drawing.Size(254, 122);
			rtb_KeyShoplike.TabIndex = 0;
			rtb_KeyShoplike.Text = "";
			rtb_KeyShoplike.WordWrap = false;
			groupBox3.Controls.Add(rtb_KeyTinsoft);
			groupBox3.Location = new System.Drawing.Point(24, 274);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(260, 144);
			groupBox3.TabIndex = 203;
			groupBox3.TabStop = false;
			groupBox3.Text = "Key Tinsoft : ";
			rtb_KeyTinsoft.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_KeyTinsoft.Location = new System.Drawing.Point(3, 19);
			rtb_KeyTinsoft.Name = "rtb_KeyTinsoft";
			rtb_KeyTinsoft.Size = new System.Drawing.Size(254, 122);
			rtb_KeyTinsoft.TabIndex = 0;
			rtb_KeyTinsoft.Text = "";
			rtb_KeyTinsoft.WordWrap = false;
			rad_ChangIP_ShopLike.AutoSize = true;
			rad_ChangIP_ShopLike.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			rad_ChangIP_ShopLike.ForeColor = System.Drawing.Color.DarkBlue;
			rad_ChangIP_ShopLike.Location = new System.Drawing.Point(316, 251);
			rad_ChangIP_ShopLike.Name = "rad_ChangIP_ShopLike";
			rad_ChangIP_ShopLike.Size = new System.Drawing.Size(117, 19);
			rad_ChangIP_ShopLike.TabIndex = 58;
			rad_ChangIP_ShopLike.Text = "proxy.shoplike.vn";
			rad_ChangIP_ShopLike.UseVisualStyleBackColor = true;
			rad_ChangIP_Tinsoft.AutoSize = true;
			rad_ChangIP_Tinsoft.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			rad_ChangIP_Tinsoft.ForeColor = System.Drawing.Color.DarkBlue;
			rad_ChangIP_Tinsoft.Location = new System.Drawing.Point(24, 251);
			rad_ChangIP_Tinsoft.Name = "rad_ChangIP_Tinsoft";
			rad_ChangIP_Tinsoft.Size = new System.Drawing.Size(115, 19);
			rad_ChangIP_Tinsoft.TabIndex = 47;
			rad_ChangIP_Tinsoft.Text = "tinsoftproxy.com";
			rad_ChangIP_Tinsoft.UseVisualStyleBackColor = true;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(484, 453);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 127;
			btnCancel.Text = "Close";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btn_Cancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(375, 453);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 126;
			btnAdd.Text = "Save";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btn_OK_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(906, 493);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(groupBox1);
			Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "CauHinhDoiIP";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "General Configuration";
			base.Load += new System.EventHandler(CauHinhDoiIP_Load);
			((System.ComponentModel.ISupportInitialize)num_Thread_ChangeIP).EndInit();
			gr_changeDcom.ResumeLayout(false);
			gr_changeDcom.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox6.ResumeLayout(false);
			groupBox6.PerformLayout();
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
