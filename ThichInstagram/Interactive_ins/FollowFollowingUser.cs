using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class FollowFollowingUser : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Label label10;

		private Label label8;

		private NumericUpDown num_FollowFollowingUser_SLMax;

		private Label label9;

		private NumericUpDown num_FollowFollowingUser_SLMin;

		private GroupBox groupBox3;

		private RichTextBox rtb_FollowFollowingUser_ID;

		private Label label3;

		private NumericUpDown num_FollowFollowingUser_TimeMax;

		private Label label2;

		private NumericUpDown num_FollowFollowingUser_TimeMin;

		private Label label1;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button button1;

		private Button button2;

		public FollowFollowingUser(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public FollowFollowingUser(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_FollowFollowingUser_SLMin", num_FollowFollowingUser_SLMin.Value.ToString());
			jSON_Settings.Add("num_FollowFollowingUser_SLMax", num_FollowFollowingUser_SLMax.Value.ToString());
			jSON_Settings.Add("num_FollowFollowingUser_TimeMin", num_FollowFollowingUser_TimeMin.Value.ToString());
			jSON_Settings.Add("num_FollowFollowingUser_TimeMax", num_FollowFollowingUser_TimeMax.Value.ToString());
			jSON_Settings.Add("rtb_FollowFollowingUser_ID", rtb_FollowFollowingUser_ID.Text);
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 16;
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

		private void FollowFollowingUser_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_FollowFollowingUser_SLMin.Value = jSON_Settings.GetValueInt("num_FollowFollowingUser_SLMin");
				num_FollowFollowingUser_SLMax.Value = jSON_Settings.GetValueInt("num_FollowFollowingUser_SLMax");
				num_FollowFollowingUser_TimeMin.Value = jSON_Settings.GetValueInt("num_FollowFollowingUser_TimeMin");
				num_FollowFollowingUser_TimeMax.Value = jSON_Settings.GetValueInt("num_FollowFollowingUser_TimeMax");
				rtb_FollowFollowingUser_ID.Text = jSON_Settings.GetValue("rtb_FollowFollowingUser_ID");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				groupBox3.Text = "Danh sách User";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.FollowFollowingUser));
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_FollowFollowingUser_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_FollowFollowingUser_SLMin = new System.Windows.Forms.NumericUpDown();
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_FollowFollowingUser_ID = new System.Windows.Forms.RichTextBox();
			label3 = new System.Windows.Forms.Label();
			num_FollowFollowingUser_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			num_FollowFollowingUser_TimeMin = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_FollowFollowingUser_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowFollowingUser_SLMin).BeginInit();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_FollowFollowingUser_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowFollowingUser_TimeMin).BeginInit();
			SuspendLayout();
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(19, 47);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(76, 15);
			label10.TabIndex = 205;
			label10.Text = "Follow/User :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(289, 47);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(42, 15);
			label8.TabIndex = 209;
			label8.Text = "Follow";
			num_FollowFollowingUser_SLMax.Location = new System.Drawing.Point(240, 45);
			num_FollowFollowingUser_SLMax.Name = "num_FollowFollowingUser_SLMax";
			num_FollowFollowingUser_SLMax.Size = new System.Drawing.Size(43, 23);
			num_FollowFollowingUser_SLMax.TabIndex = 208;
			num_FollowFollowingUser_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(209, 47);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 207;
			label9.Text = "-->";
			num_FollowFollowingUser_SLMin.Location = new System.Drawing.Point(160, 45);
			num_FollowFollowingUser_SLMin.Name = "num_FollowFollowingUser_SLMin";
			num_FollowFollowingUser_SLMin.Size = new System.Drawing.Size(43, 23);
			num_FollowFollowingUser_SLMin.TabIndex = 206;
			num_FollowFollowingUser_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			groupBox3.Controls.Add(rtb_FollowFollowingUser_ID);
			groupBox3.Location = new System.Drawing.Point(22, 105);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(326, 169);
			groupBox3.TabIndex = 202;
			groupBox3.TabStop = false;
			groupBox3.Text = "List of Users :";
			rtb_FollowFollowingUser_ID.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_FollowFollowingUser_ID.Location = new System.Drawing.Point(3, 19);
			rtb_FollowFollowingUser_ID.Name = "rtb_FollowFollowingUser_ID";
			rtb_FollowFollowingUser_ID.Size = new System.Drawing.Size(320, 147);
			rtb_FollowFollowingUser_ID.TabIndex = 0;
			rtb_FollowFollowingUser_ID.Text = "";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(289, 79);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 214;
			label3.Text = "( s )";
			num_FollowFollowingUser_TimeMax.Location = new System.Drawing.Point(240, 77);
			num_FollowFollowingUser_TimeMax.Name = "num_FollowFollowingUser_TimeMax";
			num_FollowFollowingUser_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_FollowFollowingUser_TimeMax.TabIndex = 213;
			num_FollowFollowingUser_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(209, 79);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 212;
			label2.Text = "-->";
			num_FollowFollowingUser_TimeMin.Location = new System.Drawing.Point(160, 77);
			num_FollowFollowingUser_TimeMin.Name = "num_FollowFollowingUser_TimeMin";
			num_FollowFollowingUser_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_FollowFollowingUser_TimeMin.TabIndex = 211;
			num_FollowFollowingUser_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(19, 79);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 15);
			label1.TabIndex = 210;
			label1.Text = "Waiting time :";
			txt_TenHanhDong.Location = new System.Drawing.Point(160, 12);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(171, 23);
			txt_TenHanhDong.TabIndex = 248;
			txt_TenHanhDong.Text = "Follow user's following";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(18, 15);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 247;
			label11.Text = "Action name :";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(191, 286);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 250;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(87, 286);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 249;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(367, 327);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_FollowFollowingUser_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_FollowFollowingUser_SLMin);
			base.Controls.Add(groupBox3);
			base.Controls.Add(label3);
			base.Controls.Add(num_FollowFollowingUser_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(num_FollowFollowingUser_TimeMin);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "FollowFollowingUser";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Follow user's following";
			base.Load += new System.EventHandler(FollowFollowingUser_Load);
			((System.ComponentModel.ISupportInitialize)num_FollowFollowingUser_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowFollowingUser_SLMin).EndInit();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)num_FollowFollowingUser_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowFollowingUser_TimeMin).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
