using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class TuongTacTinNhan : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Label label3;

		private NumericUpDown num_Mess_TimeMax;

		private Label label2;

		private Label label1;

		private NumericUpDown num_Mess_TimeMin;

		private Label label10;

		private Label label8;

		private NumericUpDown num_Mess_SLMax;

		private Label label9;

		private NumericUpDown num_Mess_SLMin;

		private NumericUpDown num_Mess_SLImgMin;

		private Label label7;

		private NumericUpDown num_Mess_SLImgMax;

		private Label label6;

		private Label label4;

		private Label label5;

		private TextBox txt_Mess_PathImg;

		private GroupBox groupBox2;

		private CheckBox cb_Mess_SendIMG;

		private RichTextBox rtb_Mess_NDmess;

		private GroupBox groupBox3;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button button1;

		private Button button2;

		public TuongTacTinNhan(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public TuongTacTinNhan(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_Mess_SLMin", num_Mess_SLMin.Value.ToString());
			jSON_Settings.Add("num_Mess_SLMax", num_Mess_SLMax.Value.ToString());
			jSON_Settings.Add("num_Mess_TimeMin", num_Mess_TimeMin.Value.ToString());
			jSON_Settings.Add("num_Mess_TimeMax", num_Mess_TimeMax.Value.ToString());
			jSON_Settings.Add("rtb_Mess_NDmess", rtb_Mess_NDmess.Text);
			jSON_Settings.Add("cb_Mess_SendIMG", cb_Mess_SendIMG.Checked.ToString());
			jSON_Settings.Add("txt_Mess_PathImg", txt_Mess_PathImg.Text);
			jSON_Settings.Add("num_Mess_SLImgMin", num_Mess_SLImgMin.Value.ToString());
			jSON_Settings.Add("num_Mess_SLImgMax", num_Mess_SLImgMax.Value.ToString());
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 6;
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

		private void TuongTacTinNhan_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_Mess_SLMin.Value = jSON_Settings.GetValueInt("num_Mess_SLMin");
				num_Mess_SLMax.Value = jSON_Settings.GetValueInt("num_Mess_SLMax");
				num_Mess_TimeMin.Value = jSON_Settings.GetValueInt("num_Mess_TimeMin");
				num_Mess_TimeMax.Value = jSON_Settings.GetValueInt("num_Mess_TimeMax");
				num_Mess_SLImgMin.Value = jSON_Settings.GetValueInt("num_Mess_SLImgMin");
				num_Mess_SLImgMax.Value = jSON_Settings.GetValueInt("num_Mess_SLImgMax");
				cb_Mess_SendIMG.Checked = jSON_Settings.GetValueBool("cb_Mess_SendIMG");
				rtb_Mess_NDmess.Text = jSON_Settings.GetValue("rtb_Mess_NDmess");
				txt_Mess_PathImg.Text = jSON_Settings.GetValue("txt_Mess_PathImg");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				label10.Text = "Số lượng : ";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
				groupBox3.Text = "Nội dung nhắn tin";
				cb_Mess_SendIMG.Text = "Gửi ảnh";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.TuongTacTinNhan));
			label3 = new System.Windows.Forms.Label();
			num_Mess_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			num_Mess_TimeMin = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_Mess_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_Mess_SLMin = new System.Windows.Forms.NumericUpDown();
			num_Mess_SLImgMin = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			num_Mess_SLImgMax = new System.Windows.Forms.NumericUpDown();
			label6 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			txt_Mess_PathImg = new System.Windows.Forms.TextBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			cb_Mess_SendIMG = new System.Windows.Forms.CheckBox();
			rtb_Mess_NDmess = new System.Windows.Forms.RichTextBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_Mess_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Mess_TimeMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Mess_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Mess_SLMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Mess_SLImgMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Mess_SLImgMax).BeginInit();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(272, 80);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 188;
			label3.Text = "( s )";
			num_Mess_TimeMax.Location = new System.Drawing.Point(223, 78);
			num_Mess_TimeMax.Name = "num_Mess_TimeMax";
			num_Mess_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_Mess_TimeMax.TabIndex = 187;
			num_Mess_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(192, 80);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 186;
			label2.Text = "-->";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 80);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(119, 15);
			label1.TabIndex = 184;
			label1.Text = "Scroll time /Interact: ";
			num_Mess_TimeMin.Location = new System.Drawing.Point(143, 78);
			num_Mess_TimeMin.Name = "num_Mess_TimeMin";
			num_Mess_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_Mess_TimeMin.TabIndex = 185;
			num_Mess_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(16, 48);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(59, 15);
			label10.TabIndex = 177;
			label10.Text = "Quantity :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(272, 48);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(30, 15);
			label8.TabIndex = 181;
			label8.Text = "User";
			num_Mess_SLMax.Location = new System.Drawing.Point(223, 46);
			num_Mess_SLMax.Name = "num_Mess_SLMax";
			num_Mess_SLMax.Size = new System.Drawing.Size(43, 23);
			num_Mess_SLMax.TabIndex = 180;
			num_Mess_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(192, 48);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 179;
			label9.Text = "-->";
			num_Mess_SLMin.Location = new System.Drawing.Point(143, 46);
			num_Mess_SLMin.Name = "num_Mess_SLMin";
			num_Mess_SLMin.Size = new System.Drawing.Size(43, 23);
			num_Mess_SLMin.TabIndex = 178;
			num_Mess_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			num_Mess_SLImgMin.Location = new System.Drawing.Point(120, 53);
			num_Mess_SLImgMin.Name = "num_Mess_SLImgMin";
			num_Mess_SLImgMin.Size = new System.Drawing.Size(43, 23);
			num_Mess_SLImgMin.TabIndex = 15;
			num_Mess_SLImgMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(169, 55);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(25, 15);
			label7.TabIndex = 16;
			label7.Text = "-->";
			num_Mess_SLImgMax.Location = new System.Drawing.Point(200, 53);
			num_Mess_SLImgMax.Name = "num_Mess_SLImgMax";
			num_Mess_SLImgMax.Size = new System.Drawing.Size(43, 23);
			num_Mess_SLImgMax.TabIndex = 17;
			num_Mess_SLImgMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(249, 55);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(29, 15);
			label6.TabIndex = 18;
			label6.Text = "Img";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(7, 55);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(108, 15);
			label4.TabIndex = 19;
			label4.Text = "Number of photos:";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(7, 19);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(74, 15);
			label5.TabIndex = 20;
			label5.Text = "Image path :";
			txt_Mess_PathImg.Location = new System.Drawing.Point(121, 16);
			txt_Mess_PathImg.Name = "txt_Mess_PathImg";
			txt_Mess_PathImg.Size = new System.Drawing.Size(144, 23);
			txt_Mess_PathImg.TabIndex = 21;
			groupBox2.Controls.Add(txt_Mess_PathImg);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(num_Mess_SLImgMax);
			groupBox2.Controls.Add(label7);
			groupBox2.Controls.Add(num_Mess_SLImgMin);
			groupBox2.Location = new System.Drawing.Point(19, 296);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(286, 82);
			groupBox2.TabIndex = 183;
			groupBox2.TabStop = false;
			cb_Mess_SendIMG.AutoSize = true;
			cb_Mess_SendIMG.Location = new System.Drawing.Point(31, 281);
			cb_Mess_SendIMG.Name = "cb_Mess_SendIMG";
			cb_Mess_SendIMG.Size = new System.Drawing.Size(93, 19);
			cb_Mess_SendIMG.TabIndex = 182;
			cb_Mess_SendIMG.Text = "Send photos";
			cb_Mess_SendIMG.UseVisualStyleBackColor = true;
			rtb_Mess_NDmess.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_Mess_NDmess.Location = new System.Drawing.Point(3, 19);
			rtb_Mess_NDmess.Name = "rtb_Mess_NDmess";
			rtb_Mess_NDmess.Size = new System.Drawing.Size(280, 147);
			rtb_Mess_NDmess.TabIndex = 0;
			rtb_Mess_NDmess.Text = "";
			groupBox3.Controls.Add(rtb_Mess_NDmess);
			groupBox3.Location = new System.Drawing.Point(19, 106);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(286, 169);
			groupBox3.TabIndex = 174;
			groupBox3.TabStop = false;
			groupBox3.Text = "Message content :";
			txt_TenHanhDong.Location = new System.Drawing.Point(143, 12);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 190;
			txt_TenHanhDong.Text = "Reply The Message";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(16, 15);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 189;
			label11.Text = "Action name :";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(172, 388);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 280;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(68, 388);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 279;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(324, 427);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(cb_Mess_SendIMG);
			base.Controls.Add(label3);
			base.Controls.Add(num_Mess_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(groupBox2);
			base.Controls.Add(num_Mess_TimeMin);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_Mess_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_Mess_SLMin);
			base.Controls.Add(groupBox3);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "TuongTacTinNhan";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Reply The Message";
			base.Load += new System.EventHandler(TuongTacTinNhan_Load);
			((System.ComponentModel.ISupportInitialize)num_Mess_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Mess_TimeMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Mess_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Mess_SLMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Mess_SLImgMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Mess_SLImgMax).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
