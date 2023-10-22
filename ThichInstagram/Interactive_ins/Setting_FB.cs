using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Interactive_ins.Properties;

namespace Interactive_ins
{
	public class Setting_FB : Form
	{
		private IContainer components = null;

		private GroupBox gr_ChangePass;

		private GroupBox groupBox4;

		private RichTextBox rtb_Pass;

		private Label label1;

		private NumericUpDown num_ACC;

		private Label label2;

		private GroupBox gr_changeAvt;

		private TextBox txt_PathImg;

		private Label label5;

		private CheckBox cb_UpAvt;

		private CheckBox cb_LockAcc;

		private Label label3;

		private Label lb_ChangeIP;

		private Button btnCancel;

		private Button btnAdd;

		private Label Lb_WriteProxy;

		private Label label6;

		private CheckBox rad_ChangePass_Random;

		private CheckBox cb_DoiTen;

		private Label lb_Ten;

		private CheckBox cb_follow;

		private CheckBox cb_post;

		private Label label8;

		private NumericUpDown num_Follow_SLMax;

		private Label label9;

		private NumericUpDown num_Follow_SLMin;

		private Label label4;

		private NumericUpDown num_Post_SLMax;

		private Label label7;

		private NumericUpDown num_Post_SLMin;

		private GroupBox groupBox5;

		private GroupBox groupBox6;

		private Label label10;

		private TextBox txt_PassHotmail;

		private Label label11;

		private TextBox txt_hotmail;

		private Label label12;

		private TextBox txt_domain;

		private RadioButton rad_hotmail;

		private RadioButton rad_domain;

		private RadioButton rad_FakeEmail;

		private GroupBox groupBox2;

		private RichTextBox rtb_hotmail;

		public Setting_FB()
		{
			InitializeComponent();
		}

		private void save()
		{
			JSON_Settings jSON_Settings = new JSON_Settings(Load_file.path_Setting_FB);
			jSON_Settings.Add("num_ACC", num_ACC.Value.ToString());
			jSON_Settings.Add("num_Follow_SLMin", num_Follow_SLMin.Value.ToString());
			jSON_Settings.Add("num_Follow_SLMax", num_Follow_SLMax.Value.ToString());
			jSON_Settings.Add("num_Post_SLMin", num_Post_SLMin.Value.ToString());
			jSON_Settings.Add("num_Post_SLMax", num_Post_SLMax.Value.ToString());
			jSON_Settings.Add("cb_DoiTen", cb_DoiTen.Checked.ToString());
			jSON_Settings.Add("cb_LockAcc", cb_LockAcc.Checked.ToString());
			jSON_Settings.Add("cb_UpAvt", cb_UpAvt.Checked.ToString());
			jSON_Settings.Add("cb_follow", cb_follow.Checked.ToString());
			jSON_Settings.Add("cb_post", cb_post.Checked.ToString());
			jSON_Settings.Add("rad_ChangePass_Random", rad_ChangePass_Random.Checked.ToString());
			jSON_Settings.Add("rad_FakeEmail", rad_FakeEmail.Checked.ToString());
			jSON_Settings.Add("rad_hotmail", rad_hotmail.Checked.ToString());
			jSON_Settings.Add("rad_domain", rad_domain.Checked.ToString());
			jSON_Settings.Add("rtb_Pass", rtb_Pass.Text);
			jSON_Settings.Add("rtb_hotmail", rtb_hotmail.Text);
			jSON_Settings.Add("txt_PathImg", txt_PathImg.Text);
			jSON_Settings.Add("txt_domain", txt_domain.Text);
			jSON_Settings.Add("txt_hotmail", txt_hotmail.Text);
			jSON_Settings.Add("txt_PassHotmail", txt_PassHotmail.Text);
		}

		private void load()
		{
			JSON_Settings jSON_Settings = new JSON_Settings(Load_file.path_Setting_FB);
			try
			{
				num_ACC.Value = jSON_Settings.GetValueInt("num_ACC");
				num_Follow_SLMin.Value = jSON_Settings.GetValueInt("num_Follow_SLMin");
				num_Follow_SLMax.Value = jSON_Settings.GetValueInt("num_Follow_SLMax");
				num_Post_SLMin.Value = jSON_Settings.GetValueInt("num_Post_SLMin");
				num_Post_SLMax.Value = jSON_Settings.GetValueInt("num_Post_SLMax");
				cb_DoiTen.Checked = jSON_Settings.GetValueBool("cb_DoiTen");
				cb_LockAcc.Checked = jSON_Settings.GetValueBool("cb_LockAcc");
				cb_UpAvt.Checked = jSON_Settings.GetValueBool("cb_UpAvt");
				cb_follow.Checked = jSON_Settings.GetValueBool("cb_follow");
				cb_post.Checked = jSON_Settings.GetValueBool("cb_post");
				rad_ChangePass_Random.Checked = jSON_Settings.GetValueBool("rad_ChangePass_Random");
				rad_FakeEmail.Checked = jSON_Settings.GetValueBool("rad_FakeEmail");
				rad_hotmail.Checked = jSON_Settings.GetValueBool("rad_hotmail");
				rad_domain.Checked = jSON_Settings.GetValueBool("rad_domain");
				rtb_Pass.Text = jSON_Settings.GetValue("rtb_Pass");
				rtb_hotmail.Text = jSON_Settings.GetValue("rtb_hotmail");
				txt_PathImg.Text = jSON_Settings.GetValue("txt_PathImg");
				txt_domain.Text = jSON_Settings.GetValue("txt_domain");
				txt_hotmail.Text = jSON_Settings.GetValue("txt_hotmail");
				txt_PassHotmail.Text = jSON_Settings.GetValue("txt_PassHotmail");
			}
			catch
			{
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lb_ChangeIP_Click(object sender, EventArgs e)
		{
			CauHinhDoiIP cauHinhDoiIP = new CauHinhDoiIP();
			cauHinhDoiIP.ShowDialog();
		}

		private void Lb_WriteProxy_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec_FB(enum_thongtin.checkselec.ToString(), 1.ToString());
			if (list.Count == 0)
			{
				MessageBox.Show("Please select the account to add proxy !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			NhapProxy nhapProxy = new NhapProxy(1, list);
			nhapProxy.ShowDialog();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			save();
			Close();
		}

		private void Setting_FB_Load(object sender, EventArgs e)
		{
			load();
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label1.Text = "Tạo Ins/Fb : ";
				label3.Text = "Đổi IP : ";
				label6.Text = "Nhập Proxy : ";
				cb_DoiTen.Text = "      Đổi tên";
				cb_LockAcc.Text = "      Khóa Acc";
				cb_post.Text = "      Đăng bài";
				groupBox4.Text = "Danh sách Pass";
				btnAdd.Text = "Lưu";
				btnCancel.Text = "Thoát";
			}
		}

		private void lb_Ten_Click(object sender, EventArgs e)
		{
			string text = "ten.txt";
			if (File.Exists(text))
			{
				Process process = new Process();
				process.StartInfo.FileName = text;
				process.Start();
			}
		}

		private void rad_domain_CheckedChanged(object sender, EventArgs e)
		{
			if (rad_domain.Checked)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.Setting_FB));
			gr_ChangePass = new System.Windows.Forms.GroupBox();
			rad_ChangePass_Random = new System.Windows.Forms.CheckBox();
			groupBox4 = new System.Windows.Forms.GroupBox();
			rtb_Pass = new System.Windows.Forms.RichTextBox();
			label1 = new System.Windows.Forms.Label();
			num_ACC = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			gr_changeAvt = new System.Windows.Forms.GroupBox();
			txt_PathImg = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			label6 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_Follow_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_Follow_SLMin = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			num_Post_SLMax = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			num_Post_SLMin = new System.Windows.Forms.NumericUpDown();
			cb_post = new System.Windows.Forms.CheckBox();
			cb_follow = new System.Windows.Forms.CheckBox();
			cb_DoiTen = new System.Windows.Forms.CheckBox();
			lb_Ten = new System.Windows.Forms.Label();
			Lb_WriteProxy = new System.Windows.Forms.Label();
			lb_ChangeIP = new System.Windows.Forms.Label();
			cb_UpAvt = new System.Windows.Forms.CheckBox();
			cb_LockAcc = new System.Windows.Forms.CheckBox();
			groupBox5 = new System.Windows.Forms.GroupBox();
			groupBox6 = new System.Windows.Forms.GroupBox();
			label10 = new System.Windows.Forms.Label();
			txt_PassHotmail = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			txt_hotmail = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			txt_domain = new System.Windows.Forms.TextBox();
			rad_hotmail = new System.Windows.Forms.RadioButton();
			rad_domain = new System.Windows.Forms.RadioButton();
			rad_FakeEmail = new System.Windows.Forms.RadioButton();
			groupBox2 = new System.Windows.Forms.GroupBox();
			rtb_hotmail = new System.Windows.Forms.RichTextBox();
			gr_ChangePass.SuspendLayout();
			groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_ACC).BeginInit();
			gr_changeAvt.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_Follow_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Follow_SLMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Post_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Post_SLMin).BeginInit();
			groupBox5.SuspendLayout();
			groupBox6.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			gr_ChangePass.Controls.Add(rad_ChangePass_Random);
			gr_ChangePass.Controls.Add(groupBox4);
			gr_ChangePass.Location = new System.Drawing.Point(291, 372);
			gr_ChangePass.Name = "gr_ChangePass";
			gr_ChangePass.Size = new System.Drawing.Size(248, 177);
			gr_ChangePass.TabIndex = 171;
			gr_ChangePass.TabStop = false;
			rad_ChangePass_Random.AutoSize = true;
			rad_ChangePass_Random.Checked = true;
			rad_ChangePass_Random.CheckState = System.Windows.Forms.CheckState.Checked;
			rad_ChangePass_Random.Location = new System.Drawing.Point(26, 145);
			rad_ChangePass_Random.Name = "rad_ChangePass_Random";
			rad_ChangePass_Random.Size = new System.Drawing.Size(104, 20);
			rad_ChangePass_Random.TabIndex = 135;
			rad_ChangePass_Random.Text = "Random Pass";
			rad_ChangePass_Random.UseVisualStyleBackColor = true;
			groupBox4.Controls.Add(rtb_Pass);
			groupBox4.Location = new System.Drawing.Point(6, 10);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(234, 129);
			groupBox4.TabIndex = 134;
			groupBox4.TabStop = false;
			groupBox4.Text = "Content Pass:";
			rtb_Pass.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_Pass.Location = new System.Drawing.Point(3, 19);
			rtb_Pass.Name = "rtb_Pass";
			rtb_Pass.Size = new System.Drawing.Size(228, 107);
			rtb_Pass.TabIndex = 0;
			rtb_Pass.Text = "";
			rtb_Pass.WordWrap = false;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(288, 19);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(103, 16);
			label1.TabIndex = 172;
			label1.Text = "Create Ins /Fb : ";
			num_ACC.Location = new System.Drawing.Point(397, 17);
			num_ACC.Maximum = new decimal(new int[4] { 5, 0, 0, 0 });
			num_ACC.Name = "num_ACC";
			num_ACC.Size = new System.Drawing.Size(88, 23);
			num_ACC.TabIndex = 173;
			num_ACC.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(491, 19);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(28, 16);
			label2.TabIndex = 174;
			label2.Text = "Acc";
			gr_changeAvt.Controls.Add(txt_PathImg);
			gr_changeAvt.Controls.Add(label5);
			gr_changeAvt.Location = new System.Drawing.Point(291, 314);
			gr_changeAvt.Name = "gr_changeAvt";
			gr_changeAvt.Size = new System.Drawing.Size(248, 52);
			gr_changeAvt.TabIndex = 181;
			gr_changeAvt.TabStop = false;
			txt_PathImg.Location = new System.Drawing.Point(82, 18);
			txt_PathImg.Name = "txt_PathImg";
			txt_PathImg.Size = new System.Drawing.Size(155, 23);
			txt_PathImg.TabIndex = 23;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(9, 21);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(72, 16);
			label5.TabIndex = 22;
			label5.Text = "Path Img : ";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(288, 62);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(79, 16);
			label3.TabIndex = 182;
			label3.Text = "Change IP : ";
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(148, 446);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 185;
			btnCancel.Text = "Close";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(39, 446);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 184;
			btnAdd.Text = "Save";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(288, 102);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(87, 16);
			label6.TabIndex = 186;
			label6.Text = "Write Proxy : ";
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Tahoma", 8.5f, System.Drawing.FontStyle.Italic);
			label8.Location = new System.Drawing.Point(502, 215);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(51, 14);
			label8.TabIndex = 194;
			label8.Text = "(Follow)";
			num_Follow_SLMax.Location = new System.Drawing.Point(458, 213);
			num_Follow_SLMax.Name = "num_Follow_SLMax";
			num_Follow_SLMax.Size = new System.Drawing.Size(43, 23);
			num_Follow_SLMax.TabIndex = 193;
			num_Follow_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(431, 215);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(27, 16);
			label9.TabIndex = 192;
			label9.Text = "-->";
			num_Follow_SLMin.Location = new System.Drawing.Point(386, 213);
			num_Follow_SLMin.Name = "num_Follow_SLMin";
			num_Follow_SLMin.Size = new System.Drawing.Size(43, 23);
			num_Follow_SLMin.TabIndex = 191;
			num_Follow_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Tahoma", 8.5f, System.Drawing.FontStyle.Italic);
			label4.Location = new System.Drawing.Point(502, 289);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(41, 14);
			label4.TabIndex = 198;
			label4.Text = "(Post)";
			num_Post_SLMax.Location = new System.Drawing.Point(458, 287);
			num_Post_SLMax.Name = "num_Post_SLMax";
			num_Post_SLMax.Size = new System.Drawing.Size(43, 23);
			num_Post_SLMax.TabIndex = 197;
			num_Post_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(431, 289);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(27, 16);
			label7.TabIndex = 196;
			label7.Text = "-->";
			num_Post_SLMin.Location = new System.Drawing.Point(386, 287);
			num_Post_SLMin.Name = "num_Post_SLMin";
			num_Post_SLMin.Size = new System.Drawing.Size(43, 23);
			num_Post_SLMin.TabIndex = 195;
			num_Post_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			cb_post.AutoSize = true;
			cb_post.Image = (System.Drawing.Image)resources.GetObject("cb_post.Image");
			cb_post.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_post.Location = new System.Drawing.Point(291, 287);
			cb_post.Name = "cb_post";
			cb_post.Size = new System.Drawing.Size(75, 20);
			cb_post.TabIndex = 182;
			cb_post.Text = "      Post";
			cb_post.UseVisualStyleBackColor = true;
			cb_follow.AutoSize = true;
			cb_follow.Image = (System.Drawing.Image)resources.GetObject("cb_follow.Image");
			cb_follow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_follow.Location = new System.Drawing.Point(291, 214);
			cb_follow.Name = "cb_follow";
			cb_follow.Size = new System.Drawing.Size(88, 20);
			cb_follow.TabIndex = 190;
			cb_follow.Text = "      Follow";
			cb_follow.UseVisualStyleBackColor = true;
			cb_DoiTen.AutoSize = true;
			cb_DoiTen.Image = Interactive_ins.Properties.Resources.name;
			cb_DoiTen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_DoiTen.Location = new System.Drawing.Point(291, 144);
			cb_DoiTen.Name = "cb_DoiTen";
			cb_DoiTen.Size = new System.Drawing.Size(131, 20);
			cb_DoiTen.TabIndex = 189;
			cb_DoiTen.Text = "      Change Name";
			cb_DoiTen.UseVisualStyleBackColor = true;
			lb_Ten.AutoSize = true;
			lb_Ten.Cursor = System.Windows.Forms.Cursors.Hand;
			lb_Ten.Font = new System.Drawing.Font("Microsoft Sans Serif", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lb_Ten.Image = (System.Drawing.Image)resources.GetObject("lb_Ten.Image");
			lb_Ten.Location = new System.Drawing.Point(427, 137);
			lb_Ten.Name = "lb_Ten";
			lb_Ten.Size = new System.Drawing.Size(33, 26);
			lb_Ten.TabIndex = 188;
			lb_Ten.Text = "   ";
			lb_Ten.Click += new System.EventHandler(lb_Ten_Click);
			Lb_WriteProxy.AutoSize = true;
			Lb_WriteProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			Lb_WriteProxy.Font = new System.Drawing.Font("Segoe UI Semibold", 13f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			Lb_WriteProxy.Image = (System.Drawing.Image)resources.GetObject("Lb_WriteProxy.Image");
			Lb_WriteProxy.Location = new System.Drawing.Point(396, 97);
			Lb_WriteProxy.Name = "Lb_WriteProxy";
			Lb_WriteProxy.Size = new System.Drawing.Size(27, 25);
			Lb_WriteProxy.TabIndex = 187;
			Lb_WriteProxy.Text = "   ";
			Lb_WriteProxy.Click += new System.EventHandler(Lb_WriteProxy_Click);
			lb_ChangeIP.AutoSize = true;
			lb_ChangeIP.Cursor = System.Windows.Forms.Cursors.Hand;
			lb_ChangeIP.Font = new System.Drawing.Font("Segoe UI Semibold", 13f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lb_ChangeIP.Image = (System.Drawing.Image)resources.GetObject("lb_ChangeIP.Image");
			lb_ChangeIP.Location = new System.Drawing.Point(396, 57);
			lb_ChangeIP.Name = "lb_ChangeIP";
			lb_ChangeIP.Size = new System.Drawing.Size(27, 25);
			lb_ChangeIP.TabIndex = 183;
			lb_ChangeIP.Text = "   ";
			lb_ChangeIP.Click += new System.EventHandler(lb_ChangeIP_Click);
			cb_UpAvt.AutoSize = true;
			cb_UpAvt.Image = Interactive_ins.Properties.Resources.user__1_;
			cb_UpAvt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_UpAvt.Location = new System.Drawing.Point(291, 251);
			cb_UpAvt.Name = "cb_UpAvt";
			cb_UpAvt.Size = new System.Drawing.Size(107, 20);
			cb_UpAvt.TabIndex = 177;
			cb_UpAvt.Text = "      Up Avatar";
			cb_UpAvt.UseVisualStyleBackColor = true;
			cb_LockAcc.AutoSize = true;
			cb_LockAcc.Image = Interactive_ins.Properties.Resources._lock;
			cb_LockAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_LockAcc.Location = new System.Drawing.Point(291, 179);
			cb_LockAcc.Name = "cb_LockAcc";
			cb_LockAcc.Size = new System.Drawing.Size(100, 20);
			cb_LockAcc.TabIndex = 176;
			cb_LockAcc.Text = "      Lock Acc";
			cb_LockAcc.UseVisualStyleBackColor = true;
			groupBox5.Controls.Add(groupBox6);
			groupBox5.Controls.Add(rad_hotmail);
			groupBox5.Controls.Add(rad_domain);
			groupBox5.Controls.Add(rad_FakeEmail);
			groupBox5.Controls.Add(groupBox2);
			groupBox5.Location = new System.Drawing.Point(14, 12);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(250, 399);
			groupBox5.TabIndex = 199;
			groupBox5.TabStop = false;
			groupBox6.Controls.Add(label10);
			groupBox6.Controls.Add(txt_PassHotmail);
			groupBox6.Controls.Add(label11);
			groupBox6.Controls.Add(txt_hotmail);
			groupBox6.Controls.Add(label12);
			groupBox6.Controls.Add(txt_domain);
			groupBox6.Enabled = false;
			groupBox6.Location = new System.Drawing.Point(6, 33);
			groupBox6.Name = "groupBox6";
			groupBox6.Size = new System.Drawing.Size(238, 137);
			groupBox6.TabIndex = 139;
			groupBox6.TabStop = false;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(10, 102);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(47, 16);
			label10.TabIndex = 143;
			label10.Text = "Pass : ";
			txt_PassHotmail.Location = new System.Drawing.Point(75, 99);
			txt_PassHotmail.Name = "txt_PassHotmail";
			txt_PassHotmail.Size = new System.Drawing.Size(155, 23);
			txt_PassHotmail.TabIndex = 142;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(10, 63);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(64, 16);
			label11.TabIndex = 141;
			label11.Text = "Hotmail : ";
			txt_hotmail.Location = new System.Drawing.Point(75, 60);
			txt_hotmail.Name = "txt_hotmail";
			txt_hotmail.Size = new System.Drawing.Size(155, 23);
			txt_hotmail.TabIndex = 140;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(10, 25);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(64, 16);
			label12.TabIndex = 139;
			label12.Text = "Domain : ";
			txt_domain.Location = new System.Drawing.Point(75, 22);
			txt_domain.Name = "txt_domain";
			txt_domain.Size = new System.Drawing.Size(155, 23);
			txt_domain.TabIndex = 138;
			rad_hotmail.AutoSize = true;
			rad_hotmail.Location = new System.Drawing.Point(11, 180);
			rad_hotmail.Name = "rad_hotmail";
			rad_hotmail.Size = new System.Drawing.Size(69, 20);
			rad_hotmail.TabIndex = 138;
			rad_hotmail.Text = "Hotmail";
			rad_hotmail.UseVisualStyleBackColor = true;
			rad_domain.AutoSize = true;
			rad_domain.Location = new System.Drawing.Point(11, 16);
			rad_domain.Name = "rad_domain";
			rad_domain.Size = new System.Drawing.Size(176, 20);
			rad_domain.TabIndex = 136;
			rad_domain.Text = "Mail Domain ( @domain ) ";
			rad_domain.UseVisualStyleBackColor = true;
			rad_domain.CheckedChanged += new System.EventHandler(rad_domain_CheckedChanged);
			rad_FakeEmail.AutoSize = true;
			rad_FakeEmail.Checked = true;
			rad_FakeEmail.Location = new System.Drawing.Point(11, 360);
			rad_FakeEmail.Name = "rad_FakeEmail";
			rad_FakeEmail.Size = new System.Drawing.Size(175, 20);
			rad_FakeEmail.TabIndex = 135;
			rad_FakeEmail.TabStop = true;
			rad_FakeEmail.Text = "Fake Email ( Not verified )";
			rad_FakeEmail.UseVisualStyleBackColor = true;
			groupBox2.Controls.Add(rtb_hotmail);
			groupBox2.Location = new System.Drawing.Point(6, 202);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(234, 152);
			groupBox2.TabIndex = 134;
			groupBox2.TabStop = false;
			groupBox2.Text = "Hotmail ( User|Pass ) :";
			rtb_hotmail.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_hotmail.Location = new System.Drawing.Point(3, 19);
			rtb_hotmail.Name = "rtb_hotmail";
			rtb_hotmail.Size = new System.Drawing.Size(228, 130);
			rtb_hotmail.TabIndex = 0;
			rtb_hotmail.Text = "";
			rtb_hotmail.WordWrap = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(567, 556);
			base.Controls.Add(groupBox5);
			base.Controls.Add(label4);
			base.Controls.Add(num_Post_SLMax);
			base.Controls.Add(label7);
			base.Controls.Add(num_Post_SLMin);
			base.Controls.Add(label8);
			base.Controls.Add(num_Follow_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_Follow_SLMin);
			base.Controls.Add(cb_post);
			base.Controls.Add(cb_follow);
			base.Controls.Add(cb_DoiTen);
			base.Controls.Add(lb_Ten);
			base.Controls.Add(Lb_WriteProxy);
			base.Controls.Add(label6);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(lb_ChangeIP);
			base.Controls.Add(label3);
			base.Controls.Add(gr_changeAvt);
			base.Controls.Add(cb_UpAvt);
			base.Controls.Add(cb_LockAcc);
			base.Controls.Add(label2);
			base.Controls.Add(num_ACC);
			base.Controls.Add(label1);
			base.Controls.Add(gr_ChangePass);
			Font = new System.Drawing.Font("Tahoma", 9.75f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "Setting_FB";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Setting Instagram With Facebook";
			base.Load += new System.EventHandler(Setting_FB_Load);
			gr_ChangePass.ResumeLayout(false);
			gr_ChangePass.PerformLayout();
			groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)num_ACC).EndInit();
			gr_changeAvt.ResumeLayout(false);
			gr_changeAvt.PerformLayout();
			((System.ComponentModel.ISupportInitialize)num_Follow_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Follow_SLMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Post_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Post_SLMin).EndInit();
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			groupBox6.ResumeLayout(false);
			groupBox6.PerformLayout();
			groupBox2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
