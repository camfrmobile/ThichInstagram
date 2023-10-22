using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class NhanTinVoiFollowers : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private RichTextBox rtb_MessFollowers_NDmess;

		private Label label3;

		private NumericUpDown num_MessFollowers_TimeMax;

		private Label label2;

		private NumericUpDown num_MessFollowers_TimeMin;

		private Label label1;

		private TextBox txt_MessFollowers_PathImg;

		private Label label5;

		private Label label4;

		private Label label6;

		private CheckBox cb_MessFollowers_SendIMG;

		private NumericUpDown num_MessFollowers_SLImgMax;

		private NumericUpDown num_MessFollowers_SLImgMin;

		private GroupBox groupBox3;

		private GroupBox groupBox2;

		private Label label7;

		private Label label10;

		private Label label8;

		private NumericUpDown num_MessFollowers_SLMax;

		private Label label9;

		private NumericUpDown num_MessFollowers_SLMin;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button button1;

		private Button button2;

		public NhanTinVoiFollowers(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public NhanTinVoiFollowers(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_Spam_SLMin", num_MessFollowers_SLMin.Value.ToString());
			jSON_Settings.Add("num_MessFollowers_SLMax", num_MessFollowers_SLMax.Value.ToString());
			jSON_Settings.Add("num_MessFollowers_TimeMin", num_MessFollowers_TimeMin.Value.ToString());
			jSON_Settings.Add("num_MessFollowers_TimeMax", num_MessFollowers_TimeMax.Value.ToString());
			jSON_Settings.Add("rtb_MessFollowers_NDmess", rtb_MessFollowers_NDmess.Text);
			jSON_Settings.Add("cb_MessFollowers_SendIMG", cb_MessFollowers_SendIMG.Checked.ToString());
			jSON_Settings.Add("txt_MessFollowers_PathImg", txt_MessFollowers_PathImg.Text);
			jSON_Settings.Add("num_MessFollowers_SLImgMin", num_MessFollowers_SLImgMin.Value.ToString());
			jSON_Settings.Add("num_MessFollowers_SLImgMax", num_MessFollowers_SLImgMax.Value.ToString());
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 4;
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

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void NhanTinVoiFollowers_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_MessFollowers_SLMin.Value = jSON_Settings.GetValueInt("num_MessFollowers_SLMin");
				num_MessFollowers_SLMax.Value = jSON_Settings.GetValueInt("num_MessFollowers_SLMax");
				num_MessFollowers_TimeMin.Value = jSON_Settings.GetValueInt("num_MessFollowers_TimeMin");
				num_MessFollowers_TimeMax.Value = jSON_Settings.GetValueInt("num_MessFollowers_TimeMax");
				num_MessFollowers_SLImgMin.Value = jSON_Settings.GetValueInt("num_MessFollowers_SLImgMin");
				num_MessFollowers_SLImgMax.Value = jSON_Settings.GetValueInt("num_MessFollowers_SLImgMax");
				cb_MessFollowers_SendIMG.Checked = jSON_Settings.GetValueBool("cb_MessFollowers_SendIMG");
				rtb_MessFollowers_NDmess.Text = jSON_Settings.GetValue("rtb_MessFollowers_NDmess");
				txt_MessFollowers_PathImg.Text = jSON_Settings.GetValue("txt_MessFollowers_PathImg");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				label10.Text = "Số lượng : ";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
				groupBox3.Text = "Nội dung tin nhắn";
				cb_MessFollowers_SendIMG.Text = "Gửi ảnh ";
				label4.Text = "Số ảnh : ";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.NhanTinVoiFollowers));
			rtb_MessFollowers_NDmess = new System.Windows.Forms.RichTextBox();
			label3 = new System.Windows.Forms.Label();
			num_MessFollowers_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			num_MessFollowers_TimeMin = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			txt_MessFollowers_PathImg = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			cb_MessFollowers_SendIMG = new System.Windows.Forms.CheckBox();
			num_MessFollowers_SLImgMax = new System.Windows.Forms.NumericUpDown();
			num_MessFollowers_SLImgMin = new System.Windows.Forms.NumericUpDown();
			groupBox3 = new System.Windows.Forms.GroupBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			label7 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_MessFollowers_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_MessFollowers_SLMin = new System.Windows.Forms.NumericUpDown();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_MessFollowers_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowers_TimeMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowers_SLImgMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowers_SLImgMin).BeginInit();
			groupBox3.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_MessFollowers_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowers_SLMin).BeginInit();
			SuspendLayout();
			rtb_MessFollowers_NDmess.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_MessFollowers_NDmess.Location = new System.Drawing.Point(3, 19);
			rtb_MessFollowers_NDmess.Name = "rtb_MessFollowers_NDmess";
			rtb_MessFollowers_NDmess.Size = new System.Drawing.Size(280, 147);
			rtb_MessFollowers_NDmess.TabIndex = 0;
			rtb_MessFollowers_NDmess.Text = "";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(267, 86);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 158;
			label3.Text = "( s )";
			num_MessFollowers_TimeMax.Location = new System.Drawing.Point(218, 84);
			num_MessFollowers_TimeMax.Name = "num_MessFollowers_TimeMax";
			num_MessFollowers_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_MessFollowers_TimeMax.TabIndex = 157;
			num_MessFollowers_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(187, 86);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 156;
			label2.Text = "-->";
			num_MessFollowers_TimeMin.Location = new System.Drawing.Point(138, 84);
			num_MessFollowers_TimeMin.Name = "num_MessFollowers_TimeMin";
			num_MessFollowers_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_MessFollowers_TimeMin.TabIndex = 155;
			num_MessFollowers_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(17, 86);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(119, 15);
			label1.TabIndex = 154;
			label1.Text = "Scroll time /Interact: ";
			txt_MessFollowers_PathImg.Location = new System.Drawing.Point(121, 16);
			txt_MessFollowers_PathImg.Name = "txt_MessFollowers_PathImg";
			txt_MessFollowers_PathImg.Size = new System.Drawing.Size(144, 23);
			txt_MessFollowers_PathImg.TabIndex = 21;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(13, 19);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(74, 15);
			label5.TabIndex = 20;
			label5.Text = "Image path :";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(13, 55);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(108, 15);
			label4.TabIndex = 19;
			label4.Text = "Number of photos:";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(250, 55);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(29, 15);
			label6.TabIndex = 18;
			label6.Text = "Img";
			cb_MessFollowers_SendIMG.AutoSize = true;
			cb_MessFollowers_SendIMG.Location = new System.Drawing.Point(34, 287);
			cb_MessFollowers_SendIMG.Name = "cb_MessFollowers_SendIMG";
			cb_MessFollowers_SendIMG.Size = new System.Drawing.Size(93, 19);
			cb_MessFollowers_SendIMG.TabIndex = 152;
			cb_MessFollowers_SendIMG.Text = "Send photos";
			cb_MessFollowers_SendIMG.UseVisualStyleBackColor = true;
			num_MessFollowers_SLImgMax.Location = new System.Drawing.Point(201, 53);
			num_MessFollowers_SLImgMax.Name = "num_MessFollowers_SLImgMax";
			num_MessFollowers_SLImgMax.Size = new System.Drawing.Size(43, 23);
			num_MessFollowers_SLImgMax.TabIndex = 17;
			num_MessFollowers_SLImgMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			num_MessFollowers_SLImgMin.Location = new System.Drawing.Point(121, 53);
			num_MessFollowers_SLImgMin.Name = "num_MessFollowers_SLImgMin";
			num_MessFollowers_SLImgMin.Size = new System.Drawing.Size(43, 23);
			num_MessFollowers_SLImgMin.TabIndex = 15;
			num_MessFollowers_SLImgMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			groupBox3.Controls.Add(rtb_MessFollowers_NDmess);
			groupBox3.Location = new System.Drawing.Point(19, 112);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(286, 169);
			groupBox3.TabIndex = 144;
			groupBox3.TabStop = false;
			groupBox3.Text = "Message content :";
			groupBox2.Controls.Add(txt_MessFollowers_PathImg);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(num_MessFollowers_SLImgMax);
			groupBox2.Controls.Add(label7);
			groupBox2.Controls.Add(num_MessFollowers_SLImgMin);
			groupBox2.Location = new System.Drawing.Point(19, 302);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(286, 82);
			groupBox2.TabIndex = 153;
			groupBox2.TabStop = false;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(170, 55);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(25, 15);
			label7.TabIndex = 16;
			label7.Text = "-->";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(17, 53);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(59, 15);
			label10.TabIndex = 147;
			label10.Text = "Quantity :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(267, 53);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(30, 15);
			label8.TabIndex = 151;
			label8.Text = "User";
			num_MessFollowers_SLMax.Location = new System.Drawing.Point(218, 51);
			num_MessFollowers_SLMax.Name = "num_MessFollowers_SLMax";
			num_MessFollowers_SLMax.Size = new System.Drawing.Size(43, 23);
			num_MessFollowers_SLMax.TabIndex = 150;
			num_MessFollowers_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(187, 53);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 149;
			label9.Text = "-->";
			num_MessFollowers_SLMin.Location = new System.Drawing.Point(138, 51);
			num_MessFollowers_SLMin.Name = "num_MessFollowers_SLMin";
			num_MessFollowers_SLMin.Size = new System.Drawing.Size(43, 23);
			num_MessFollowers_SLMin.TabIndex = 148;
			num_MessFollowers_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			txt_TenHanhDong.Location = new System.Drawing.Point(137, 18);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 166;
			txt_TenHanhDong.Text = "Message Followers";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(16, 21);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 165;
			label11.Text = "Action name :";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(170, 399);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 264;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(66, 399);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 263;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(321, 440);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(label3);
			base.Controls.Add(num_MessFollowers_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(num_MessFollowers_TimeMin);
			base.Controls.Add(label1);
			base.Controls.Add(cb_MessFollowers_SendIMG);
			base.Controls.Add(groupBox3);
			base.Controls.Add(groupBox2);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_MessFollowers_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_MessFollowers_SLMin);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "NhanTinVoiFollowers";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Message Followers";
			base.Load += new System.EventHandler(NhanTinVoiFollowers_Load);
			((System.ComponentModel.ISupportInitialize)num_MessFollowers_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowers_TimeMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowers_SLImgMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowers_SLImgMin).EndInit();
			groupBox3.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)num_MessFollowers_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowers_SLMin).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
