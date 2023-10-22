using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class ShareBaiViet : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Label label3;

		private NumericUpDown num_Share_TimeMax;

		private Label label2;

		private Label label1;

		private NumericUpDown num_Share_TimeMin;

		private Label label10;

		private Label label8;

		private NumericUpDown num_Share_SLMax;

		private Label label9;

		private NumericUpDown num_Share_SLMin;

		private GroupBox groupBox1;

		private RichTextBox rtb_Share_Link;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button button1;

		private Button button2;

		public ShareBaiViet(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public ShareBaiViet(Thongso_HanhDong Thongso_HanhDong)
		{
			InitializeComponent();
			this.Thongso_HanhDong = Thongso_HanhDong;
		}

		private void ShareBaiViet_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_Share_SLMin.Value = jSON_Settings.GetValueInt("num_Share_SLMin");
				num_Share_SLMax.Value = jSON_Settings.GetValueInt("num_Share_SLMax");
				num_Share_TimeMin.Value = jSON_Settings.GetValueInt("num_Share_TimeMin");
				num_Share_TimeMax.Value = jSON_Settings.GetValueInt("num_Share_TimeMax");
				rtb_Share_Link.Text = jSON_Settings.GetValue("rtb_Share_Link");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				label10.Text = "Số lượng User : ";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
				groupBox1.Text = "Danh sách link bài viết";
			}
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			File.Delete("settings\\Cache.json");
			interact_sql interact_sql2 = new interact_sql();
			JSON_Settings jSON_Settings = new JSON_Settings("Cache");
			jSON_Settings.Add("txt_TenHanhDong", txt_TenHanhDong.Text);
			jSON_Settings.Add("num_Share_SLMin", num_Share_SLMin.Value.ToString());
			jSON_Settings.Add("num_Share_SLMax", num_Share_SLMax.Value.ToString());
			jSON_Settings.Add("num_Share_TimeMin", num_Share_TimeMin.Value.ToString());
			jSON_Settings.Add("num_Share_TimeMax", num_Share_TimeMax.Value.ToString());
			jSON_Settings.Add("rtb_Share_Link", rtb_Share_Link.Text);
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 9;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.ShareBaiViet));
			label3 = new System.Windows.Forms.Label();
			num_Share_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			num_Share_TimeMin = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_Share_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_Share_SLMin = new System.Windows.Forms.NumericUpDown();
			groupBox1 = new System.Windows.Forms.GroupBox();
			rtb_Share_Link = new System.Windows.Forms.RichTextBox();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_Share_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Share_TimeMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Share_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Share_SLMin).BeginInit();
			groupBox1.SuspendLayout();
			SuspendLayout();
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(251, 84);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 212;
			label3.Text = "( s )";
			num_Share_TimeMax.Location = new System.Drawing.Point(202, 82);
			num_Share_TimeMax.Name = "num_Share_TimeMax";
			num_Share_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_Share_TimeMax.TabIndex = 211;
			num_Share_TimeMax.Value = new decimal(new int[4] { 20, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(171, 84);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 210;
			label2.Text = "-->";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(20, 84);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 15);
			label1.TabIndex = 208;
			label1.Text = "Waiting time :";
			num_Share_TimeMin.Location = new System.Drawing.Point(122, 82);
			num_Share_TimeMin.Name = "num_Share_TimeMin";
			num_Share_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_Share_TimeMin.TabIndex = 209;
			num_Share_TimeMin.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(20, 52);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(102, 15);
			label10.TabIndex = 203;
			label10.Text = "Number of Users :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(251, 52);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(30, 15);
			label8.TabIndex = 207;
			label8.Text = "User";
			num_Share_SLMax.Location = new System.Drawing.Point(202, 50);
			num_Share_SLMax.Name = "num_Share_SLMax";
			num_Share_SLMax.Size = new System.Drawing.Size(43, 23);
			num_Share_SLMax.TabIndex = 206;
			num_Share_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(171, 52);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 205;
			label9.Text = "-->";
			num_Share_SLMin.Location = new System.Drawing.Point(122, 50);
			num_Share_SLMin.Name = "num_Share_SLMin";
			num_Share_SLMin.Size = new System.Drawing.Size(43, 23);
			num_Share_SLMin.TabIndex = 204;
			num_Share_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			groupBox1.Controls.Add(rtb_Share_Link);
			groupBox1.Location = new System.Drawing.Point(12, 110);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(281, 141);
			groupBox1.TabIndex = 213;
			groupBox1.TabStop = false;
			groupBox1.Text = "Article link :";
			rtb_Share_Link.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_Share_Link.Location = new System.Drawing.Point(3, 19);
			rtb_Share_Link.Name = "rtb_Share_Link";
			rtb_Share_Link.Size = new System.Drawing.Size(275, 119);
			rtb_Share_Link.TabIndex = 0;
			rtb_Share_Link.Text = "";
			txt_TenHanhDong.Location = new System.Drawing.Point(121, 18);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 215;
			txt_TenHanhDong.Text = "Share Posts";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(19, 21);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 214;
			label11.Text = "Action name :";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(158, 271);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 268;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(54, 271);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 267;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(304, 312);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(groupBox1);
			base.Controls.Add(label3);
			base.Controls.Add(num_Share_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(num_Share_TimeMin);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_Share_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_Share_SLMin);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "ShareBaiViet";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Share Posts";
			base.Load += new System.EventHandler(ShareBaiViet_Load);
			((System.ComponentModel.ISupportInitialize)num_Share_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Share_TimeMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Share_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Share_SLMin).EndInit();
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
