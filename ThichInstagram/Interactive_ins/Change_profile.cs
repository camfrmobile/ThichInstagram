using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Interactive_ins.Properties;

namespace Interactive_ins
{
	public class Change_profile : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private GroupBox gr_ChangeProfile;

		private GroupBox gr_GioiTinh;

		private RadioButton rad_Nu;

		private RadioButton rad_Nam;

		private GroupBox gr_ChangePass;

		private RadioButton rad_ChangePass_Random;

		private CheckBox cb_ChangePass;

		private CheckBox cb_DoiTen;

		private Label lb_Ten;

		private CheckBox cb_GioiTinh;

		private CheckBox cb_LockAcc;

		private CheckBox cb_GoAvt;

		private CheckBox cb_UpAvt;

		private CheckBox cb_DeletePhone_addmail;

		private GroupBox groupBox4;

		private RichTextBox rtb_Pass;

		private GroupBox gr_changeAvt;

		private TextBox txt_PathImg;

		private Label label5;

		private GroupBox groupBox5;

		private RadioButton rad_FakeEmail;

		private GroupBox groupBox2;

		private RichTextBox rtb_hotmail;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button btn_Cancel;

		private Button btn_OK;

		private RadioButton rad_hotmail;

		private RadioButton rad_domain;

		private GroupBox groupBox1;

		private RichTextBox rtb_web;

		private CheckBox cb_Web;

		private GroupBox groupBox3;

		private RichTextBox rtb_TieuSu;

		private CheckBox cb_TieuSu;

		private GroupBox groupBox6;

		private Label label3;

		private TextBox txt_PassHotmail;

		private Label label2;

		private TextBox txt_hotmail;

		private Label label1;

		private TextBox txt_domain;

		public Change_profile(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public Change_profile(Thongso_HanhDong Thongso_HanhDong)
		{
			InitializeComponent();
			this.Thongso_HanhDong = Thongso_HanhDong;
		}

		private void save_INI()
		{
			File.Delete(Has.DeCryptWithKey("GAmhfOtZcSKhrhGPadHu6el7e9ZvpqGO", "2gmizasryc6g"));
			interact_sql interact_sql2 = new interact_sql();
			JSON_Settings jSON_Settings = new JSON_Settings(Has.DeCryptWithKey("pP2KyUX4YcA=", "f5tx7a"));
			jSON_Settings.Add(Has.DeCryptWithKey("VJb6UnpuR0XelZlC/IT0Rg==", "f5tx7a"), cb_DoiTen.Checked.ToString());
			jSON_Settings.Add(Has.DeCryptWithKey("CQqjnISazt+5NV0WrX1Zow==", "f5tx7a"), cb_GoAvt.Checked.ToString());
			jSON_Settings.Add(Has.DeCryptWithKey("RAqslXxigi5CiO4tqVsAHw==", "f5tx7a"), cb_LockAcc.Checked.ToString());
			jSON_Settings.Add(Has.DeCryptWithKey("2tr8xEzhGQfflmj+AqtRpw==", "f5tx7a"), cb_GioiTinh.Checked.ToString());
			jSON_Settings.Add(Has.DeCryptWithKey("O2Hma9EJf00=", "f5tx7a"), rad_Nam.Checked.ToString());
			jSON_Settings.Add(Has.DeCryptWithKey("qDvasiSit24=", "f5tx7a"), rad_Nu.Checked.ToString());
			jSON_Settings.Add(Has.DeCryptWithKey("2Kgm1tp/q9m5NV0WrX1Zow==", "f5tx7a"), cb_UpAvt.Checked.ToString());
			jSON_Settings.Add(Has.DeCryptWithKey("nnfv+Zt+R8xCiENrvIn0iA==", "f5tx7a"), txt_PathImg.Text);
			jSON_Settings.Add(Has.DeCryptWithKey("+8HvaFgwLeEDDsqbD+RFzQ==", "f5tx7a"), cb_ChangePass.Checked.ToString());
			jSON_Settings.Add(Has.DeCryptWithKey("t7MRMbkbSwu5NV0WrX1Zow==", "f5tx7a"), rtb_Pass.Text);
			jSON_Settings.Add(Has.DeCryptWithKey("bossTer51XlSDxZM0Iuu0WEaIF94iICM", "f5tx7a"), rad_ChangePass_Random.Checked.ToString());
			jSON_Settings.Add(Has.DeCryptWithKey("ZCWdlC2mKpNNw2CjEc55sA==", "f5tx7a"), cb_TieuSu.Checked.ToString());
			jSON_Settings.Add(Has.DeCryptWithKey("fZwqULg3YywhsB3Vzuc65A==", "f5tx7a"), rtb_TieuSu.Text);
			jSON_Settings.Add(Has.DeCryptWithKey("BSrE4c/tUDM=", "f5tx7a"), cb_Web.Checked.ToString());
			jSON_Settings.Add(Has.DeCryptWithKey("mqTzR0BjaV0=", "f5tx7a"), rtb_web.Text);
			jSON_Settings.Add(Has.DeCryptWithKey("hm3+kU/2DulPnsEf9koR25DH/IBsD0ph", "f5tx7a"), cb_DeletePhone_addmail.Checked.ToString());
			jSON_Settings.Add(Has.DeCryptWithKey("GMYCJeMBx9xvKkUy9qxzcg==", "f5tx7a"), rtb_hotmail.Text);
			jSON_Settings.Add(Has.DeCryptWithKey("u17Q/wM7Mn0tiaWu0dyVZA==", "f5tx7a"), rad_FakeEmail.Checked.ToString());
			jSON_Settings.Add("txt_domain", txt_domain.Text);
			jSON_Settings.Add("rad_domain", rad_domain.Checked.ToString());
			jSON_Settings.Add("rad_hotmail", rad_hotmail.Checked.ToString());
			jSON_Settings.Add("txt_hotmail", txt_hotmail.Text);
			jSON_Settings.Add("txt_PassHotmail", txt_PassHotmail.Text);
			Json_CauHinh = File.ReadAllText(Has.DeCryptWithKey("JvPYF50dLTRe7QaZB10ZQeSjzJrAlBVI", "f5tx7a"));
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 18;
			if (!string.IsNullOrEmpty(Thongso_HanhDong.ID_HanhDong))
			{
				interact_sql2.Update_Data_HanhDong(Thongso_HanhDong);
			}
			else
			{
				interact_sql2.Add_data_HanhDong(Thongso_HanhDong);
			}
			if (req._req == 0)
			{
				File.Delete(Has.DeCryptWithKey("k6NBiGF32ggIlQX1g5XNOiSaAxSIIdTy0pz9aK7Qo5c=", "m9hk7duc"));
			}
			Close();
		}

		private void load_data_Change_profile()
		{
		}

		private void Change_profile_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				cb_DoiTen.Checked = jSON_Settings.GetValueBool(Has.DecryptHas("0Izig6T+A6r57nCRgRflWg==", useHasing: true, "5uzs2cz9r5l3z"));
				cb_GoAvt.Checked = jSON_Settings.GetValueBool(Has.DecryptHas("9Hf1Fy+yVftxtEjAo7rMHw==", useHasing: true, "5uzs2cz9r5l3z"));
				cb_LockAcc.Checked = jSON_Settings.GetValueBool(Has.DecryptHas("b6rjp6+y/ZwEaI0EGZzhow==", useHasing: true, "5uzs2cz9r5l3z"));
				cb_GioiTinh.Checked = jSON_Settings.GetValueBool(Has.DecryptHas("I3CkII5QRxy+/LVA61X05Q==", useHasing: true, "5uzs2cz9r5l3z"));
				rad_Nam.Checked = jSON_Settings.GetValueBool(Has.DecryptHas("cf4cxBAcYoc=", useHasing: true, "5uzs2cz9r5l3z"));
				rad_Nu.Checked = jSON_Settings.GetValueBool(Has.DecryptHas("lV0EIFLAXAY=", useHasing: true, "5uzs2cz9r5l3z"));
				cb_UpAvt.Checked = jSON_Settings.GetValueBool(Has.DecryptHas("z9IXNONippVxtEjAo7rMHw==", useHasing: true, "5uzs2cz9r5l3z"));
				txt_PathImg.Text = jSON_Settings.GetValue(Has.DecryptHas("MvEFTDqmOViAMO1njSmCnw==", useHasing: true, "5uzs2cz9r5l3z"));
				cb_ChangePass.Checked = jSON_Settings.GetValueBool(Has.DecryptHas("PH5KUyeEjg4lDzSxL/gM2w==", useHasing: true, "5uzs2cz9r5l3z"));
				rtb_Pass.Text = jSON_Settings.GetValue(Has.DecryptHas("VQFzvJuXcGZxtEjAo7rMHw==", useHasing: true, "5uzs2cz9r5l3z"));
				rad_ChangePass_Random.Checked = jSON_Settings.GetValueBool(Has.DecryptHas("DVDvW9DTJDNqvFHXjz9VTLmVdQWFdzUt", useHasing: true, "5uzs2cz9r5l3z"));
				cb_TieuSu.Checked = jSON_Settings.GetValueBool(Has.DecryptHas("wawHwXZqy0NxrSaom3DyCQ==", useHasing: true, "5uzs2cz9r5l3z"));
				rtb_TieuSu.Text = jSON_Settings.GetValue(Has.DecryptHas("Fn4Y+fOPteTcoAZao/q5KA==", useHasing: true, "5uzs2cz9r5l3z"));
				cb_Web.Checked = jSON_Settings.GetValueBool(Has.DecryptHas("2oW+62RhcHo=", useHasing: true, "5uzs2cz9r5l3z"));
				rtb_web.Text = jSON_Settings.GetValue(Has.DecryptHas("QV/PYtMC1RA=", useHasing: true, "5uzs2cz9r5l3z"));
				cb_DeletePhone_addmail.Checked = jSON_Settings.GetValueBool(Has.DecryptHas("8+ctl6JJwCHu4CTRbcQO5sL1s2FmJ8og", useHasing: true, "z9hzufpsmomt"));
				rtb_hotmail.Text = jSON_Settings.GetValue(Has.DecryptHas("sdRlv5Rw6cLvuW9y4MEUfQ==", useHasing: true, "z9hzufpsmomt"));
				rad_FakeEmail.Checked = jSON_Settings.GetValueBool(Has.DecryptHas("QQfs1A7dpmdDSLLNdRavYQ==", useHasing: true, "z9hzufpsmomt"));
				txt_domain.Text = jSON_Settings.GetValue("txt_domain");
				rad_domain.Checked = jSON_Settings.GetValueBool("rad_domain");
				rad_hotmail.Checked = jSON_Settings.GetValueBool("rad_hotmail");
				txt_hotmail.Text = jSON_Settings.GetValue("txt_hotmail");
				txt_PassHotmail.Text = jSON_Settings.GetValue("txt_PassHotmail");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				cb_DoiTen.Text = "      Đổi tên";
				cb_GoAvt.Text = "      Gỡ avatar";
				cb_LockAcc.Text = "      Khóa Acc";
				cb_GioiTinh.Text = "      Đổi giới tính";
				rad_Nam.Text = "Nam";
				rad_Nu.Text = "Nữ";
				cb_ChangePass.Text = "      Đổi pass";
				groupBox4.Text = "Danh sách Pass : ";
				rad_FakeEmail.Text = "Fake Email ( Không xác thực )";
				cb_TieuSu.Text = "      Dổi tiểu sử";
				groupBox3.Text = "Danh sách tiểu sử";
				cb_Web.Text = "      Đổi Web";
				groupBox1.Text = "Danh sách Web";
				btn_OK.Text = "Lưu";
				btn_Cancel.Text = "Thoát";
			}
		}

		private void btn_OK_Click(object sender, EventArgs e)
		{
			save_INI();
			Close();
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			Close();
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

		private void cb_TieuSu_CheckedChanged(object sender, EventArgs e)
		{
			if (cb_TieuSu.Checked)
			{
				rtb_TieuSu.Enabled = true;
			}
			else
			{
				rtb_TieuSu.Enabled = false;
			}
		}

		private void cb_ChangePass_CheckedChanged(object sender, EventArgs e)
		{
			if (cb_ChangePass.Checked)
			{
				gr_ChangePass.Enabled = true;
			}
			else
			{
				gr_ChangePass.Enabled = false;
			}
		}

		private void cb_GioiTinh_CheckedChanged(object sender, EventArgs e)
		{
			if (cb_GioiTinh.Checked)
			{
				gr_GioiTinh.Enabled = true;
			}
			else
			{
				gr_GioiTinh.Enabled = false;
			}
		}

		private void cb_LockAcc_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void gr_ChangeProfile_Enter(object sender, EventArgs e)
		{
		}

		private void cb_DeletePhone_addmail_CheckedChanged(object sender, EventArgs e)
		{
			if (cb_DeletePhone_addmail.Checked)
			{
				groupBox5.Enabled = true;
			}
			else
			{
				groupBox5.Enabled = false;
			}
		}

		private void cb_Web_CheckedChanged(object sender, EventArgs e)
		{
			if (cb_Web.Checked)
			{
				groupBox1.Enabled = true;
			}
			else
			{
				groupBox1.Enabled = false;
			}
		}

		private void cb_UpAvt_CheckedChanged(object sender, EventArgs e)
		{
			if (cb_UpAvt.Checked)
			{
				gr_changeAvt.Enabled = true;
			}
			else
			{
				gr_changeAvt.Enabled = false;
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.Change_profile));
			gr_ChangeProfile = new System.Windows.Forms.GroupBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			rtb_web = new System.Windows.Forms.RichTextBox();
			cb_Web = new System.Windows.Forms.CheckBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_TieuSu = new System.Windows.Forms.RichTextBox();
			cb_TieuSu = new System.Windows.Forms.CheckBox();
			groupBox5 = new System.Windows.Forms.GroupBox();
			groupBox6 = new System.Windows.Forms.GroupBox();
			label3 = new System.Windows.Forms.Label();
			txt_PassHotmail = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txt_hotmail = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			txt_domain = new System.Windows.Forms.TextBox();
			rad_hotmail = new System.Windows.Forms.RadioButton();
			rad_domain = new System.Windows.Forms.RadioButton();
			rad_FakeEmail = new System.Windows.Forms.RadioButton();
			groupBox2 = new System.Windows.Forms.GroupBox();
			rtb_hotmail = new System.Windows.Forms.RichTextBox();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			gr_changeAvt = new System.Windows.Forms.GroupBox();
			txt_PathImg = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			cb_DeletePhone_addmail = new System.Windows.Forms.CheckBox();
			cb_UpAvt = new System.Windows.Forms.CheckBox();
			cb_GioiTinh = new System.Windows.Forms.CheckBox();
			cb_LockAcc = new System.Windows.Forms.CheckBox();
			cb_GoAvt = new System.Windows.Forms.CheckBox();
			gr_ChangePass = new System.Windows.Forms.GroupBox();
			groupBox4 = new System.Windows.Forms.GroupBox();
			rtb_Pass = new System.Windows.Forms.RichTextBox();
			rad_ChangePass_Random = new System.Windows.Forms.RadioButton();
			cb_ChangePass = new System.Windows.Forms.CheckBox();
			cb_DoiTen = new System.Windows.Forms.CheckBox();
			lb_Ten = new System.Windows.Forms.Label();
			gr_GioiTinh = new System.Windows.Forms.GroupBox();
			rad_Nu = new System.Windows.Forms.RadioButton();
			rad_Nam = new System.Windows.Forms.RadioButton();
			btn_Cancel = new System.Windows.Forms.Button();
			btn_OK = new System.Windows.Forms.Button();
			gr_ChangeProfile.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox6.SuspendLayout();
			groupBox2.SuspendLayout();
			gr_changeAvt.SuspendLayout();
			gr_ChangePass.SuspendLayout();
			groupBox4.SuspendLayout();
			gr_GioiTinh.SuspendLayout();
			SuspendLayout();
			gr_ChangeProfile.Controls.Add(groupBox1);
			gr_ChangeProfile.Controls.Add(cb_Web);
			gr_ChangeProfile.Controls.Add(groupBox3);
			gr_ChangeProfile.Controls.Add(cb_TieuSu);
			gr_ChangeProfile.Controls.Add(groupBox5);
			gr_ChangeProfile.Controls.Add(txt_TenHanhDong);
			gr_ChangeProfile.Controls.Add(label11);
			gr_ChangeProfile.Controls.Add(gr_changeAvt);
			gr_ChangeProfile.Controls.Add(cb_DeletePhone_addmail);
			gr_ChangeProfile.Controls.Add(cb_UpAvt);
			gr_ChangeProfile.Controls.Add(cb_GioiTinh);
			gr_ChangeProfile.Controls.Add(cb_LockAcc);
			gr_ChangeProfile.Controls.Add(cb_GoAvt);
			gr_ChangeProfile.Controls.Add(gr_ChangePass);
			gr_ChangeProfile.Controls.Add(cb_ChangePass);
			gr_ChangeProfile.Controls.Add(cb_DoiTen);
			gr_ChangeProfile.Controls.Add(lb_Ten);
			gr_ChangeProfile.Controls.Add(gr_GioiTinh);
			gr_ChangeProfile.Location = new System.Drawing.Point(14, 7);
			gr_ChangeProfile.Name = "gr_ChangeProfile";
			gr_ChangeProfile.Size = new System.Drawing.Size(817, 526);
			gr_ChangeProfile.TabIndex = 73;
			gr_ChangeProfile.TabStop = false;
			gr_ChangeProfile.Enter += new System.EventHandler(gr_ChangeProfile_Enter);
			groupBox1.Controls.Add(rtb_web);
			groupBox1.Enabled = false;
			groupBox1.Location = new System.Drawing.Point(553, 242);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(248, 164);
			groupBox1.TabIndex = 173;
			groupBox1.TabStop = false;
			groupBox1.Text = "Content Web : ";
			rtb_web.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_web.Location = new System.Drawing.Point(3, 19);
			rtb_web.Name = "rtb_web";
			rtb_web.Size = new System.Drawing.Size(242, 142);
			rtb_web.TabIndex = 0;
			rtb_web.Text = "";
			rtb_web.WordWrap = false;
			cb_Web.AutoSize = true;
			cb_Web.Image = Interactive_ins.Properties.Resources.world_wide_web;
			cb_Web.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_Web.Location = new System.Drawing.Point(556, 222);
			cb_Web.Name = "cb_Web";
			cb_Web.Size = new System.Drawing.Size(87, 19);
			cb_Web.TabIndex = 172;
			cb_Web.Text = "      Website";
			cb_Web.UseVisualStyleBackColor = true;
			groupBox3.Controls.Add(rtb_TieuSu);
			groupBox3.Enabled = false;
			groupBox3.Location = new System.Drawing.Point(556, 47);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(248, 164);
			groupBox3.TabIndex = 171;
			groupBox3.TabStop = false;
			groupBox3.Text = "Content Bio : ";
			rtb_TieuSu.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_TieuSu.Location = new System.Drawing.Point(3, 19);
			rtb_TieuSu.Name = "rtb_TieuSu";
			rtb_TieuSu.Size = new System.Drawing.Size(242, 142);
			rtb_TieuSu.TabIndex = 0;
			rtb_TieuSu.Text = "";
			rtb_TieuSu.WordWrap = false;
			cb_TieuSu.AutoSize = true;
			cb_TieuSu.Image = Interactive_ins.Properties.Resources.bio;
			cb_TieuSu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_TieuSu.Location = new System.Drawing.Point(559, 27);
			cb_TieuSu.Name = "cb_TieuSu";
			cb_TieuSu.Size = new System.Drawing.Size(104, 19);
			cb_TieuSu.TabIndex = 170;
			cb_TieuSu.Text = "      Change Bio";
			cb_TieuSu.UseVisualStyleBackColor = true;
			groupBox5.Controls.Add(groupBox6);
			groupBox5.Controls.Add(rad_hotmail);
			groupBox5.Controls.Add(rad_domain);
			groupBox5.Controls.Add(rad_FakeEmail);
			groupBox5.Controls.Add(groupBox2);
			groupBox5.Enabled = false;
			groupBox5.Location = new System.Drawing.Point(288, 41);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(250, 365);
			groupBox5.TabIndex = 169;
			groupBox5.TabStop = false;
			groupBox6.Controls.Add(label3);
			groupBox6.Controls.Add(txt_PassHotmail);
			groupBox6.Controls.Add(label2);
			groupBox6.Controls.Add(txt_hotmail);
			groupBox6.Controls.Add(label1);
			groupBox6.Controls.Add(txt_domain);
			groupBox6.Enabled = false;
			groupBox6.Location = new System.Drawing.Point(6, 33);
			groupBox6.Name = "groupBox6";
			groupBox6.Size = new System.Drawing.Size(238, 137);
			groupBox6.TabIndex = 139;
			groupBox6.TabStop = false;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(10, 102);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(39, 15);
			label3.TabIndex = 143;
			label3.Text = "Pass : ";
			txt_PassHotmail.Location = new System.Drawing.Point(72, 99);
			txt_PassHotmail.Name = "txt_PassHotmail";
			txt_PassHotmail.Size = new System.Drawing.Size(155, 23);
			txt_PassHotmail.TabIndex = 142;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(10, 63);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(59, 15);
			label2.TabIndex = 141;
			label2.Text = "Hotmail : ";
			txt_hotmail.Location = new System.Drawing.Point(72, 60);
			txt_hotmail.Name = "txt_hotmail";
			txt_hotmail.Size = new System.Drawing.Size(155, 23);
			txt_hotmail.TabIndex = 140;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(10, 25);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 15);
			label1.TabIndex = 139;
			label1.Text = "Domain : ";
			txt_domain.Location = new System.Drawing.Point(72, 22);
			txt_domain.Name = "txt_domain";
			txt_domain.Size = new System.Drawing.Size(155, 23);
			txt_domain.TabIndex = 138;
			rad_hotmail.AutoSize = true;
			rad_hotmail.Location = new System.Drawing.Point(11, 180);
			rad_hotmail.Name = "rad_hotmail";
			rad_hotmail.Size = new System.Drawing.Size(68, 19);
			rad_hotmail.TabIndex = 138;
			rad_hotmail.Text = "Hotmail";
			rad_hotmail.UseVisualStyleBackColor = true;
			rad_domain.AutoSize = true;
			rad_domain.Location = new System.Drawing.Point(11, 16);
			rad_domain.Name = "rad_domain";
			rad_domain.Size = new System.Drawing.Size(166, 19);
			rad_domain.TabIndex = 136;
			rad_domain.Text = "Mail Domain ( @domain ) ";
			rad_domain.UseVisualStyleBackColor = true;
			rad_domain.CheckedChanged += new System.EventHandler(rad_domain_CheckedChanged);
			rad_FakeEmail.AutoSize = true;
			rad_FakeEmail.Checked = true;
			rad_FakeEmail.Location = new System.Drawing.Point(11, 327);
			rad_FakeEmail.Name = "rad_FakeEmail";
			rad_FakeEmail.Size = new System.Drawing.Size(160, 19);
			rad_FakeEmail.TabIndex = 135;
			rad_FakeEmail.TabStop = true;
			rad_FakeEmail.Text = "Fake Email ( Not verified )";
			rad_FakeEmail.UseVisualStyleBackColor = true;
			rad_FakeEmail.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
			groupBox2.Controls.Add(rtb_hotmail);
			groupBox2.Location = new System.Drawing.Point(6, 202);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(238, 114);
			groupBox2.TabIndex = 134;
			groupBox2.TabStop = false;
			groupBox2.Text = "Hotmail ( User|Pass ) :";
			rtb_hotmail.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_hotmail.Location = new System.Drawing.Point(3, 19);
			rtb_hotmail.Name = "rtb_hotmail";
			rtb_hotmail.Size = new System.Drawing.Size(232, 92);
			rtb_hotmail.TabIndex = 0;
			rtb_hotmail.Text = "";
			rtb_hotmail.WordWrap = false;
			txt_TenHanhDong.Location = new System.Drawing.Point(119, 22);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(150, 23);
			txt_TenHanhDong.TabIndex = 168;
			txt_TenHanhDong.Text = "ChangeProfile";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(17, 25);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 167;
			label11.Text = "Action name :";
			gr_changeAvt.Controls.Add(txt_PathImg);
			gr_changeAvt.Controls.Add(label5);
			gr_changeAvt.Location = new System.Drawing.Point(21, 266);
			gr_changeAvt.Name = "gr_changeAvt";
			gr_changeAvt.Size = new System.Drawing.Size(248, 52);
			gr_changeAvt.TabIndex = 134;
			gr_changeAvt.TabStop = false;
			txt_PathImg.Location = new System.Drawing.Point(82, 18);
			txt_PathImg.Name = "txt_PathImg";
			txt_PathImg.Size = new System.Drawing.Size(155, 23);
			txt_PathImg.TabIndex = 23;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(9, 21);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(65, 15);
			label5.TabIndex = 22;
			label5.Text = "Path Img : ";
			cb_DeletePhone_addmail.AutoSize = true;
			cb_DeletePhone_addmail.Image = Interactive_ins.Properties.Resources.remove;
			cb_DeletePhone_addmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_DeletePhone_addmail.Location = new System.Drawing.Point(288, 26);
			cb_DeletePhone_addmail.Name = "cb_DeletePhone_addmail";
			cb_DeletePhone_addmail.Size = new System.Drawing.Size(194, 19);
			cb_DeletePhone_addmail.TabIndex = 133;
			cb_DeletePhone_addmail.Text = "      Delete Phone - Add Hotmail";
			cb_DeletePhone_addmail.UseVisualStyleBackColor = true;
			cb_DeletePhone_addmail.CheckedChanged += new System.EventHandler(cb_DeletePhone_addmail_CheckedChanged);
			cb_UpAvt.AutoSize = true;
			cb_UpAvt.Image = Interactive_ins.Properties.Resources.user__1_;
			cb_UpAvt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_UpAvt.Location = new System.Drawing.Point(21, 250);
			cb_UpAvt.Name = "cb_UpAvt";
			cb_UpAvt.Size = new System.Drawing.Size(96, 19);
			cb_UpAvt.TabIndex = 90;
			cb_UpAvt.Text = "      Up Avatar";
			cb_UpAvt.UseVisualStyleBackColor = true;
			cb_UpAvt.CheckedChanged += new System.EventHandler(cb_UpAvt_CheckedChanged);
			cb_GioiTinh.AutoSize = true;
			cb_GioiTinh.Image = Interactive_ins.Properties.Resources.sex;
			cb_GioiTinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_GioiTinh.Location = new System.Drawing.Point(21, 177);
			cb_GioiTinh.Name = "cb_GioiTinh";
			cb_GioiTinh.Size = new System.Drawing.Size(106, 19);
			cb_GioiTinh.TabIndex = 89;
			cb_GioiTinh.Text = "      Change Sex";
			cb_GioiTinh.UseVisualStyleBackColor = true;
			cb_GioiTinh.CheckedChanged += new System.EventHandler(cb_GioiTinh_CheckedChanged);
			cb_LockAcc.AutoSize = true;
			cb_LockAcc.Image = Interactive_ins.Properties.Resources._lock;
			cb_LockAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_LockAcc.Location = new System.Drawing.Point(21, 137);
			cb_LockAcc.Name = "cb_LockAcc";
			cb_LockAcc.Size = new System.Drawing.Size(92, 19);
			cb_LockAcc.TabIndex = 88;
			cb_LockAcc.Text = "      Lock Acc";
			cb_LockAcc.UseVisualStyleBackColor = true;
			cb_LockAcc.CheckedChanged += new System.EventHandler(cb_LockAcc_CheckedChanged);
			cb_GoAvt.AutoSize = true;
			cb_GoAvt.Image = Interactive_ins.Properties.Resources.remove_user;
			cb_GoAvt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_GoAvt.Location = new System.Drawing.Point(21, 99);
			cb_GoAvt.Name = "cb_GoAvt";
			cb_GoAvt.Size = new System.Drawing.Size(122, 19);
			cb_GoAvt.TabIndex = 87;
			cb_GoAvt.Text = "      Remove avatar";
			cb_GoAvt.UseVisualStyleBackColor = true;
			gr_ChangePass.Controls.Add(groupBox4);
			gr_ChangePass.Controls.Add(rad_ChangePass_Random);
			gr_ChangePass.Enabled = false;
			gr_ChangePass.Location = new System.Drawing.Point(21, 349);
			gr_ChangePass.Name = "gr_ChangePass";
			gr_ChangePass.Size = new System.Drawing.Size(246, 163);
			gr_ChangePass.TabIndex = 80;
			gr_ChangePass.TabStop = false;
			groupBox4.Controls.Add(rtb_Pass);
			groupBox4.Location = new System.Drawing.Point(6, 11);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(234, 114);
			groupBox4.TabIndex = 134;
			groupBox4.TabStop = false;
			groupBox4.Text = "Content Pass:";
			rtb_Pass.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_Pass.Location = new System.Drawing.Point(3, 19);
			rtb_Pass.Name = "rtb_Pass";
			rtb_Pass.Size = new System.Drawing.Size(228, 92);
			rtb_Pass.TabIndex = 0;
			rtb_Pass.Text = "";
			rtb_Pass.WordWrap = false;
			rad_ChangePass_Random.AutoSize = true;
			rad_ChangePass_Random.Checked = true;
			rad_ChangePass_Random.Location = new System.Drawing.Point(23, 135);
			rad_ChangePass_Random.Name = "rad_ChangePass_Random";
			rad_ChangePass_Random.Size = new System.Drawing.Size(96, 19);
			rad_ChangePass_Random.TabIndex = 78;
			rad_ChangePass_Random.TabStop = true;
			rad_ChangePass_Random.Text = "Random Pass";
			rad_ChangePass_Random.UseVisualStyleBackColor = true;
			cb_ChangePass.AutoSize = true;
			cb_ChangePass.Image = Interactive_ins.Properties.Resources.id_card;
			cb_ChangePass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_ChangePass.Location = new System.Drawing.Point(21, 333);
			cb_ChangePass.Name = "cb_ChangePass";
			cb_ChangePass.Size = new System.Drawing.Size(110, 19);
			cb_ChangePass.TabIndex = 86;
			cb_ChangePass.Text = "      Change Pass";
			cb_ChangePass.UseVisualStyleBackColor = true;
			cb_ChangePass.CheckedChanged += new System.EventHandler(cb_ChangePass_CheckedChanged);
			cb_DoiTen.AutoSize = true;
			cb_DoiTen.Image = Interactive_ins.Properties.Resources.name;
			cb_DoiTen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_DoiTen.Location = new System.Drawing.Point(21, 62);
			cb_DoiTen.Name = "cb_DoiTen";
			cb_DoiTen.Size = new System.Drawing.Size(119, 19);
			cb_DoiTen.TabIndex = 84;
			cb_DoiTen.Text = "      Change Name";
			cb_DoiTen.UseVisualStyleBackColor = true;
			lb_Ten.AutoSize = true;
			lb_Ten.Cursor = System.Windows.Forms.Cursors.Hand;
			lb_Ten.Font = new System.Drawing.Font("Microsoft Sans Serif", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lb_Ten.Image = (System.Drawing.Image)resources.GetObject("lb_Ten.Image");
			lb_Ten.Location = new System.Drawing.Point(145, 55);
			lb_Ten.Name = "lb_Ten";
			lb_Ten.Size = new System.Drawing.Size(33, 26);
			lb_Ten.TabIndex = 83;
			lb_Ten.Text = "   ";
			lb_Ten.Click += new System.EventHandler(lb_Ten_Click);
			gr_GioiTinh.Controls.Add(rad_Nu);
			gr_GioiTinh.Controls.Add(rad_Nam);
			gr_GioiTinh.Enabled = false;
			gr_GioiTinh.Location = new System.Drawing.Point(24, 196);
			gr_GioiTinh.Name = "gr_GioiTinh";
			gr_GioiTinh.Size = new System.Drawing.Size(245, 39);
			gr_GioiTinh.TabIndex = 79;
			gr_GioiTinh.TabStop = false;
			rad_Nu.AutoSize = true;
			rad_Nu.Location = new System.Drawing.Point(150, 13);
			rad_Nu.Name = "rad_Nu";
			rad_Nu.Size = new System.Drawing.Size(63, 19);
			rad_Nu.TabIndex = 77;
			rad_Nu.Text = "Female";
			rad_Nu.UseVisualStyleBackColor = true;
			rad_Nam.AutoSize = true;
			rad_Nam.Checked = true;
			rad_Nam.Location = new System.Drawing.Point(38, 13);
			rad_Nam.Name = "rad_Nam";
			rad_Nam.Size = new System.Drawing.Size(51, 19);
			rad_Nam.TabIndex = 76;
			rad_Nam.TabStop = true;
			rad_Nam.Text = "Male";
			rad_Nam.UseVisualStyleBackColor = true;
			btn_Cancel.BackColor = System.Drawing.Color.Maroon;
			btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btn_Cancel.FlatAppearance.BorderSize = 0;
			btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btn_Cancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btn_Cancel.ForeColor = System.Drawing.Color.White;
			btn_Cancel.Location = new System.Drawing.Point(420, 549);
			btn_Cancel.Name = "btn_Cancel";
			btn_Cancel.Size = new System.Drawing.Size(92, 29);
			btn_Cancel.TabIndex = 77;
			btn_Cancel.Text = "Cancel";
			btn_Cancel.UseVisualStyleBackColor = false;
			btn_Cancel.Click += new System.EventHandler(btn_Cancel_Click);
			btn_OK.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btn_OK.Cursor = System.Windows.Forms.Cursors.Hand;
			btn_OK.FlatAppearance.BorderSize = 0;
			btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btn_OK.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btn_OK.ForeColor = System.Drawing.Color.White;
			btn_OK.Location = new System.Drawing.Point(316, 549);
			btn_OK.Name = "btn_OK";
			btn_OK.Size = new System.Drawing.Size(92, 29);
			btn_OK.TabIndex = 76;
			btn_OK.Text = "Save";
			btn_OK.UseVisualStyleBackColor = false;
			btn_OK.Click += new System.EventHandler(btn_OK_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(843, 590);
			base.Controls.Add(btn_Cancel);
			base.Controls.Add(btn_OK);
			base.Controls.Add(gr_ChangeProfile);
			Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Change_profile";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Change Profile";
			base.Load += new System.EventHandler(Change_profile_Load);
			gr_ChangeProfile.ResumeLayout(false);
			gr_ChangeProfile.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			groupBox6.ResumeLayout(false);
			groupBox6.PerformLayout();
			groupBox2.ResumeLayout(false);
			gr_changeAvt.ResumeLayout(false);
			gr_changeAvt.PerformLayout();
			gr_ChangePass.ResumeLayout(false);
			gr_ChangePass.PerformLayout();
			groupBox4.ResumeLayout(false);
			gr_GioiTinh.ResumeLayout(false);
			gr_GioiTinh.PerformLayout();
			ResumeLayout(false);
		}
	}
}
