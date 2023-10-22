using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class NhanTinTheoUser : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private NumericUpDown num_MessUser_SLMin;

		private Label label10;

		private Label label8;

		private NumericUpDown num_MessUser_SLMax;

		private Label label9;

		private GroupBox groupBox2;

		private TextBox txt_MessUser_PathImg;

		private Label label5;

		private Label label4;

		private Label label6;

		private NumericUpDown num_MessUser_SLImgMax;

		private Label label7;

		private NumericUpDown num_MessUser_SLImgMin;

		private CheckBox cb_MessUser_SendIMG;

		private Label label3;

		private NumericUpDown num_MessUser_TimeMax;

		private Label label2;

		private NumericUpDown num_MessUser_TimeMin;

		private Label label1;

		private RichTextBox rtb_MessUser_LUser;

		private GroupBox groupBox1;

		private GroupBox groupBox3;

		private RichTextBox rtb_MessUser_NDmess;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button button1;

		private Button button2;

		public NhanTinTheoUser(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public NhanTinTheoUser(Thongso_HanhDong Thongso_HanhDong)
		{
			InitializeComponent();
			this.Thongso_HanhDong = Thongso_HanhDong;
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			File.Delete("settings\\Cache.json");
			interact_sql interact_sql2 = new interact_sql();
			JSON_Settings jSON_Settings = new JSON_Settings("Cache");
			jSON_Settings.Add("txt_TenHanhDong", txt_TenHanhDong.Text);
			jSON_Settings.Add("num_MessUser_SLMin", num_MessUser_SLMin.Value.ToString());
			jSON_Settings.Add("num_MessUser_SLMax", num_MessUser_SLMax.Value.ToString());
			jSON_Settings.Add("num_MessUser_TimeMin", num_MessUser_TimeMin.Value.ToString());
			jSON_Settings.Add("num_MessUser_TimeMax", num_MessUser_TimeMax.Value.ToString());
			jSON_Settings.Add("rtb_MessUser_LUser", rtb_MessUser_LUser.Text);
			jSON_Settings.Add("rtb_MessUser_NDmess", rtb_MessUser_NDmess.Text);
			jSON_Settings.Add("cb_MessUser_SendIMG", cb_MessUser_SendIMG.Checked.ToString());
			jSON_Settings.Add("txt_MessUser_PathImg", txt_MessUser_PathImg.Text);
			jSON_Settings.Add("num_MessUser_SLImgMin", num_MessUser_SLImgMin.Value.ToString());
			jSON_Settings.Add("num_MessUser_SLImgMax", num_MessUser_SLImgMax.Value.ToString());
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 3;
			if (!string.IsNullOrEmpty(Thongso_HanhDong.ID_HanhDong))
			{
				interact_sql2.Update_Data_HanhDong(Thongso_HanhDong);
			}
			else
			{
				interact_sql2.Add_data_HanhDong(Thongso_HanhDong);
			}
			Close();
		}

		private void NhanTinTheoUser_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_MessUser_SLMin.Value = jSON_Settings.GetValueInt("num_MessUser_SLMin");
				num_MessUser_SLMax.Value = jSON_Settings.GetValueInt("num_MessUser_SLMax");
				num_MessUser_TimeMin.Value = jSON_Settings.GetValueInt("num_MessUser_TimeMin");
				num_MessUser_TimeMax.Value = jSON_Settings.GetValueInt("num_MessUser_TimeMax");
				num_MessUser_SLImgMin.Value = jSON_Settings.GetValueInt("num_MessUser_SLImgMin");
				num_MessUser_SLImgMax.Value = jSON_Settings.GetValueInt("num_MessUser_SLImgMax");
				cb_MessUser_SendIMG.Checked = jSON_Settings.GetValueBool("cb_MessUser_SendIMG");
				rtb_MessUser_LUser.Text = jSON_Settings.GetValue("rtb_MessUser_LUser");
				rtb_MessUser_NDmess.Text = jSON_Settings.GetValue("rtb_MessUser_NDmess");
				txt_MessUser_PathImg.Text = jSON_Settings.GetValue("txt_MessUser_PathImg");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				label10.Text = "Số lượng : ";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
				groupBox3.Text = "Nội dung tin nhắn";
				groupBox1.Text = "Danh sách User cần nhắn tin :";
				cb_MessUser_SendIMG.Text = "Gửi ảnh ";
				label4.Text = "Số ảnh : ";
			}
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.NhanTinTheoUser));
			num_MessUser_SLMin = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_MessUser_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			txt_MessUser_PathImg = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			num_MessUser_SLImgMax = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			num_MessUser_SLImgMin = new System.Windows.Forms.NumericUpDown();
			cb_MessUser_SendIMG = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			num_MessUser_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			num_MessUser_TimeMin = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			rtb_MessUser_LUser = new System.Windows.Forms.RichTextBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_MessUser_NDmess = new System.Windows.Forms.RichTextBox();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_MessUser_SLMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_MessUser_SLMax).BeginInit();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_MessUser_SLImgMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_MessUser_SLImgMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_MessUser_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_MessUser_TimeMin).BeginInit();
			groupBox1.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			num_MessUser_SLMin.Location = new System.Drawing.Point(118, 59);
			num_MessUser_SLMin.Name = "num_MessUser_SLMin";
			num_MessUser_SLMin.Size = new System.Drawing.Size(43, 23);
			num_MessUser_SLMin.TabIndex = 132;
			num_MessUser_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(16, 61);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(59, 15);
			label10.TabIndex = 131;
			label10.Text = "Quantity :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(247, 61);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(30, 15);
			label8.TabIndex = 135;
			label8.Text = "User";
			num_MessUser_SLMax.Location = new System.Drawing.Point(198, 59);
			num_MessUser_SLMax.Name = "num_MessUser_SLMax";
			num_MessUser_SLMax.Size = new System.Drawing.Size(43, 23);
			num_MessUser_SLMax.TabIndex = 134;
			num_MessUser_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(167, 61);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 133;
			label9.Text = "-->";
			groupBox2.Controls.Add(txt_MessUser_PathImg);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(num_MessUser_SLImgMax);
			groupBox2.Controls.Add(label7);
			groupBox2.Controls.Add(num_MessUser_SLImgMin);
			groupBox2.Location = new System.Drawing.Point(304, 238);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(283, 82);
			groupBox2.TabIndex = 137;
			groupBox2.TabStop = false;
			txt_MessUser_PathImg.Location = new System.Drawing.Point(124, 16);
			txt_MessUser_PathImg.Name = "txt_MessUser_PathImg";
			txt_MessUser_PathImg.Size = new System.Drawing.Size(141, 23);
			txt_MessUser_PathImg.TabIndex = 21;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(13, 19);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(74, 15);
			label5.TabIndex = 20;
			label5.Text = "Image path :";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(13, 55);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(111, 15);
			label4.TabIndex = 19;
			label4.Text = "Number of photos :";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(253, 55);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(29, 15);
			label6.TabIndex = 18;
			label6.Text = "Img";
			num_MessUser_SLImgMax.Location = new System.Drawing.Point(204, 53);
			num_MessUser_SLImgMax.Name = "num_MessUser_SLImgMax";
			num_MessUser_SLImgMax.Size = new System.Drawing.Size(43, 23);
			num_MessUser_SLImgMax.TabIndex = 17;
			num_MessUser_SLImgMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(173, 55);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(25, 15);
			label7.TabIndex = 16;
			label7.Text = "-->";
			num_MessUser_SLImgMin.Location = new System.Drawing.Point(124, 53);
			num_MessUser_SLImgMin.Name = "num_MessUser_SLImgMin";
			num_MessUser_SLImgMin.Size = new System.Drawing.Size(43, 23);
			num_MessUser_SLImgMin.TabIndex = 15;
			num_MessUser_SLImgMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			cb_MessUser_SendIMG.AutoSize = true;
			cb_MessUser_SendIMG.Location = new System.Drawing.Point(304, 223);
			cb_MessUser_SendIMG.Name = "cb_MessUser_SendIMG";
			cb_MessUser_SendIMG.Size = new System.Drawing.Size(93, 19);
			cb_MessUser_SendIMG.TabIndex = 136;
			cb_MessUser_SendIMG.Text = "Send photos";
			cb_MessUser_SendIMG.UseVisualStyleBackColor = true;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(247, 93);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 142;
			label3.Text = "( s )";
			num_MessUser_TimeMax.Location = new System.Drawing.Point(198, 91);
			num_MessUser_TimeMax.Name = "num_MessUser_TimeMax";
			num_MessUser_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_MessUser_TimeMax.TabIndex = 141;
			num_MessUser_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(167, 93);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 140;
			label2.Text = "-->";
			num_MessUser_TimeMin.Location = new System.Drawing.Point(118, 91);
			num_MessUser_TimeMin.Name = "num_MessUser_TimeMin";
			num_MessUser_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_MessUser_TimeMin.TabIndex = 139;
			num_MessUser_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 93);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 15);
			label1.TabIndex = 138;
			label1.Text = "Waiting time :";
			rtb_MessUser_LUser.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_MessUser_LUser.Location = new System.Drawing.Point(3, 19);
			rtb_MessUser_LUser.Name = "rtb_MessUser_LUser";
			rtb_MessUser_LUser.Size = new System.Drawing.Size(265, 178);
			rtb_MessUser_LUser.TabIndex = 0;
			rtb_MessUser_LUser.Text = "";
			groupBox1.Controls.Add(rtb_MessUser_LUser);
			groupBox1.Location = new System.Drawing.Point(17, 120);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(271, 200);
			groupBox1.TabIndex = 128;
			groupBox1.TabStop = false;
			groupBox1.Text = "List of users to message:";
			groupBox3.Controls.Add(rtb_MessUser_NDmess);
			groupBox3.Location = new System.Drawing.Point(301, 16);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(286, 195);
			groupBox3.TabIndex = 129;
			groupBox3.TabStop = false;
			groupBox3.Text = "Message content :";
			rtb_MessUser_NDmess.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_MessUser_NDmess.Location = new System.Drawing.Point(3, 19);
			rtb_MessUser_NDmess.Name = "rtb_MessUser_NDmess";
			rtb_MessUser_NDmess.Size = new System.Drawing.Size(280, 173);
			rtb_MessUser_NDmess.TabIndex = 0;
			rtb_MessUser_NDmess.Text = "";
			txt_TenHanhDong.Location = new System.Drawing.Point(118, 23);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(158, 23);
			txt_TenHanhDong.TabIndex = 168;
			txt_TenHanhDong.Text = "Message Users";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(16, 26);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 167;
			label11.Text = "Action name :";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(300, 344);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 262;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(196, 344);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 261;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(602, 388);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(groupBox3);
			base.Controls.Add(label3);
			base.Controls.Add(num_MessUser_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(num_MessUser_TimeMin);
			base.Controls.Add(label1);
			base.Controls.Add(groupBox2);
			base.Controls.Add(cb_MessUser_SendIMG);
			base.Controls.Add(num_MessUser_SLMin);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_MessUser_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(groupBox1);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "NhanTinTheoUser";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Message Users";
			base.Load += new System.EventHandler(NhanTinTheoUser_Load);
			((System.ComponentModel.ISupportInitialize)num_MessUser_SLMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_MessUser_SLMax).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)num_MessUser_SLImgMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_MessUser_SLImgMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_MessUser_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_MessUser_TimeMin).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
