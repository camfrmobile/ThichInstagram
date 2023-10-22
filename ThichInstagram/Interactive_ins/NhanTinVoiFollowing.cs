using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class NhanTinVoiFollowing : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Label label10;

		private Label label8;

		private NumericUpDown num_MessFollowing_SLMax;

		private Label label9;

		private NumericUpDown num_MessFollowing_SLMin;

		private TextBox txt_MessFollowing_PathImg;

		private Label label5;

		private Label label4;

		private Label label6;

		private GroupBox groupBox3;

		private RichTextBox rtb_MessFollowing_NDmess;

		private GroupBox groupBox2;

		private NumericUpDown num_MessFollowing_SLImgMax;

		private Label label7;

		private NumericUpDown num_MessFollowing_SLImgMin;

		private CheckBox cb_MessFollowing_SendIMG;

		private Label label3;

		private NumericUpDown num_MessFollowing_TimeMax;

		private Label label2;

		private NumericUpDown num_MessFollowing_TimeMin;

		private Label label1;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button button1;

		private Button button2;

		public NhanTinVoiFollowing(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public NhanTinVoiFollowing(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_MessFollowing_SLMin", num_MessFollowing_SLMin.Value.ToString());
			jSON_Settings.Add("num_MessFollowing_SLMax", num_MessFollowing_SLMax.Value.ToString());
			jSON_Settings.Add("num_MessFollowing_TimeMin", num_MessFollowing_TimeMin.Value.ToString());
			jSON_Settings.Add("num_MessFollowing_TimeMax", num_MessFollowing_TimeMax.Value.ToString());
			jSON_Settings.Add("rtb_MessFollowing_NDmess", rtb_MessFollowing_NDmess.Text);
			jSON_Settings.Add("cb_MessFollowing_SendIMG", cb_MessFollowing_SendIMG.Checked.ToString());
			jSON_Settings.Add("txt_MessFollowing_PathImg", txt_MessFollowing_PathImg.Text);
			jSON_Settings.Add("num_MessFollowing_SLImgMin", num_MessFollowing_SLImgMin.Value.ToString());
			jSON_Settings.Add("num_MessFollowing_SLImgMax", num_MessFollowing_SLImgMax.Value.ToString());
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 5;
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

		private void NhanTinVoiFollowing_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_MessFollowing_SLMin.Value = jSON_Settings.GetValueInt("num_MessFollowing_SLMin");
				num_MessFollowing_SLMax.Value = jSON_Settings.GetValueInt("num_MessFollowing_SLMax");
				num_MessFollowing_TimeMin.Value = jSON_Settings.GetValueInt("num_MessFollowing_TimeMin");
				num_MessFollowing_TimeMax.Value = jSON_Settings.GetValueInt("num_MessFollowing_TimeMax");
				num_MessFollowing_SLImgMin.Value = jSON_Settings.GetValueInt("num_MessFollowing_SLImgMin");
				num_MessFollowing_SLImgMax.Value = jSON_Settings.GetValueInt("num_MessFollowing_SLImgMax");
				cb_MessFollowing_SendIMG.Checked = jSON_Settings.GetValueBool("cb_MessFollowing_SendIMG");
				rtb_MessFollowing_NDmess.Text = jSON_Settings.GetValue("rtb_MessFollowing_NDmess");
				txt_MessFollowing_PathImg.Text = jSON_Settings.GetValue("txt_MessFollowing_PathImg");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				label10.Text = "Số lượng : ";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
				groupBox3.Text = "Nội dung tin nhắn";
				cb_MessFollowing_SendIMG.Text = "Gửi ảnh ";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.NhanTinVoiFollowing));
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_MessFollowing_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_MessFollowing_SLMin = new System.Windows.Forms.NumericUpDown();
			txt_MessFollowing_PathImg = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_MessFollowing_NDmess = new System.Windows.Forms.RichTextBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			num_MessFollowing_SLImgMax = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			num_MessFollowing_SLImgMin = new System.Windows.Forms.NumericUpDown();
			cb_MessFollowing_SendIMG = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			num_MessFollowing_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			num_MessFollowing_TimeMin = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_MessFollowing_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowing_SLMin).BeginInit();
			groupBox3.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_MessFollowing_SLImgMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowing_SLImgMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowing_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowing_TimeMin).BeginInit();
			SuspendLayout();
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(17, 52);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(59, 15);
			label10.TabIndex = 162;
			label10.Text = "Quantity :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(248, 52);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(30, 15);
			label8.TabIndex = 166;
			label8.Text = "User";
			num_MessFollowing_SLMax.Location = new System.Drawing.Point(199, 50);
			num_MessFollowing_SLMax.Name = "num_MessFollowing_SLMax";
			num_MessFollowing_SLMax.Size = new System.Drawing.Size(43, 23);
			num_MessFollowing_SLMax.TabIndex = 165;
			num_MessFollowing_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(168, 52);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 164;
			label9.Text = "-->";
			num_MessFollowing_SLMin.Location = new System.Drawing.Point(119, 50);
			num_MessFollowing_SLMin.Name = "num_MessFollowing_SLMin";
			num_MessFollowing_SLMin.Size = new System.Drawing.Size(43, 23);
			num_MessFollowing_SLMin.TabIndex = 163;
			num_MessFollowing_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			txt_MessFollowing_PathImg.Location = new System.Drawing.Point(121, 16);
			txt_MessFollowing_PathImg.Name = "txt_MessFollowing_PathImg";
			txt_MessFollowing_PathImg.Size = new System.Drawing.Size(144, 23);
			txt_MessFollowing_PathImg.TabIndex = 21;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(8, 19);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(77, 15);
			label5.TabIndex = 20;
			label5.Text = "Image path : ";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(8, 55);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(111, 15);
			label4.TabIndex = 19;
			label4.Text = "Number of photos :";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(250, 55);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(29, 15);
			label6.TabIndex = 18;
			label6.Text = "Img";
			groupBox3.Controls.Add(rtb_MessFollowing_NDmess);
			groupBox3.Location = new System.Drawing.Point(20, 110);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(286, 169);
			groupBox3.TabIndex = 159;
			groupBox3.TabStop = false;
			groupBox3.Text = "Message content :";
			rtb_MessFollowing_NDmess.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_MessFollowing_NDmess.Location = new System.Drawing.Point(3, 19);
			rtb_MessFollowing_NDmess.Name = "rtb_MessFollowing_NDmess";
			rtb_MessFollowing_NDmess.Size = new System.Drawing.Size(280, 147);
			rtb_MessFollowing_NDmess.TabIndex = 0;
			rtb_MessFollowing_NDmess.Text = "";
			groupBox2.Controls.Add(txt_MessFollowing_PathImg);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(num_MessFollowing_SLImgMax);
			groupBox2.Controls.Add(label7);
			groupBox2.Controls.Add(num_MessFollowing_SLImgMin);
			groupBox2.Location = new System.Drawing.Point(20, 300);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(286, 82);
			groupBox2.TabIndex = 168;
			groupBox2.TabStop = false;
			num_MessFollowing_SLImgMax.Location = new System.Drawing.Point(201, 53);
			num_MessFollowing_SLImgMax.Name = "num_MessFollowing_SLImgMax";
			num_MessFollowing_SLImgMax.Size = new System.Drawing.Size(43, 23);
			num_MessFollowing_SLImgMax.TabIndex = 17;
			num_MessFollowing_SLImgMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(170, 55);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(25, 15);
			label7.TabIndex = 16;
			label7.Text = "-->";
			num_MessFollowing_SLImgMin.Location = new System.Drawing.Point(121, 53);
			num_MessFollowing_SLImgMin.Name = "num_MessFollowing_SLImgMin";
			num_MessFollowing_SLImgMin.Size = new System.Drawing.Size(43, 23);
			num_MessFollowing_SLImgMin.TabIndex = 15;
			num_MessFollowing_SLImgMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			cb_MessFollowing_SendIMG.AutoSize = true;
			cb_MessFollowing_SendIMG.Location = new System.Drawing.Point(20, 285);
			cb_MessFollowing_SendIMG.Name = "cb_MessFollowing_SendIMG";
			cb_MessFollowing_SendIMG.Size = new System.Drawing.Size(93, 19);
			cb_MessFollowing_SendIMG.TabIndex = 167;
			cb_MessFollowing_SendIMG.Text = "Send photos";
			cb_MessFollowing_SendIMG.UseVisualStyleBackColor = true;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(248, 84);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 173;
			label3.Text = "( s )";
			num_MessFollowing_TimeMax.Location = new System.Drawing.Point(199, 82);
			num_MessFollowing_TimeMax.Name = "num_MessFollowing_TimeMax";
			num_MessFollowing_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_MessFollowing_TimeMax.TabIndex = 172;
			num_MessFollowing_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(168, 84);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 171;
			label2.Text = "-->";
			num_MessFollowing_TimeMin.Location = new System.Drawing.Point(119, 82);
			num_MessFollowing_TimeMin.Name = "num_MessFollowing_TimeMin";
			num_MessFollowing_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_MessFollowing_TimeMin.TabIndex = 170;
			num_MessFollowing_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(17, 84);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 15);
			label1.TabIndex = 169;
			label1.Text = "Waiting time :";
			txt_TenHanhDong.Location = new System.Drawing.Point(118, 17);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 175;
			txt_TenHanhDong.Text = "Message Following";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(16, 20);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 174;
			label11.Text = "Action name :";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(172, 403);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 266;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(68, 403);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 265;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(327, 445);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_MessFollowing_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_MessFollowing_SLMin);
			base.Controls.Add(groupBox3);
			base.Controls.Add(groupBox2);
			base.Controls.Add(cb_MessFollowing_SendIMG);
			base.Controls.Add(label3);
			base.Controls.Add(num_MessFollowing_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(num_MessFollowing_TimeMin);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "NhanTinVoiFollowing";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Message Following";
			base.Load += new System.EventHandler(NhanTinVoiFollowing_Load);
			((System.ComponentModel.ISupportInitialize)num_MessFollowing_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowing_SLMin).EndInit();
			groupBox3.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)num_MessFollowing_SLImgMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowing_SLImgMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowing_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_MessFollowing_TimeMin).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
