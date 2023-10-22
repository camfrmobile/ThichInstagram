using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class UnFollow : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Label label10;

		private Label label8;

		private NumericUpDown num_UnFollow_SLMax;

		private Label label9;

		private NumericUpDown num_UnFollow_SLMin;

		private Label label3;

		private NumericUpDown num_UnFollow_TimeMax;

		private Label label2;

		private NumericUpDown num_UnFollow_TimeMin;

		private Label label1;

		private Label label4;

		private CheckBox cb_UnFolowFollower;

		private CheckBox cb_UnFolowFollowing;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button button1;

		private Button button2;

		public UnFollow(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public UnFollow(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_UnFollow_SLMin", num_UnFollow_SLMin.Value.ToString());
			jSON_Settings.Add("num_UnFollow_SLMax", num_UnFollow_SLMax.Value.ToString());
			jSON_Settings.Add("num_UnFollow_TimeMin", num_UnFollow_TimeMin.Value.ToString());
			jSON_Settings.Add("num_UnFollow_TimeMax", num_UnFollow_TimeMax.Value.ToString());
			jSON_Settings.Add("cb_UnFolowFollower", cb_UnFolowFollower.Checked.ToString());
			jSON_Settings.Add("cb_UnFolowFollowing", cb_UnFolowFollowing.Checked.ToString());
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 17;
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

		private void UnFollow_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_UnFollow_SLMin.Value = jSON_Settings.GetValueInt("num_UnFollow_SLMin");
				num_UnFollow_SLMax.Value = jSON_Settings.GetValueInt("num_UnFollow_SLMax");
				num_UnFollow_TimeMin.Value = jSON_Settings.GetValueInt("num_UnFollow_TimeMin");
				num_UnFollow_TimeMax.Value = jSON_Settings.GetValueInt("num_UnFollow_TimeMax");
				cb_UnFolowFollower.Checked = jSON_Settings.GetValueBool("cb_UnFolowFollower");
				cb_UnFolowFollowing.Checked = jSON_Settings.GetValueBool("cb_UnFolowFollowing");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				label10.Text = "Số lượng : ";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
				label4.Text = "Cài đặt";
				cb_UnFolowFollower.Text = "Bỏ theo dõi Follower";
				cb_UnFolowFollowing.Text = "Bỏ theo dõi Following";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.UnFollow));
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_UnFollow_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_UnFollow_SLMin = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			num_UnFollow_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			num_UnFollow_TimeMin = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			cb_UnFolowFollower = new System.Windows.Forms.CheckBox();
			cb_UnFolowFollowing = new System.Windows.Forms.CheckBox();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_UnFollow_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_UnFollow_SLMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_UnFollow_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_UnFollow_TimeMin).BeginInit();
			SuspendLayout();
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(19, 45);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(59, 15);
			label10.TabIndex = 218;
			label10.Text = "Quantity :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(243, 45);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(42, 15);
			label8.TabIndex = 222;
			label8.Text = "Follow";
			num_UnFollow_SLMax.Location = new System.Drawing.Point(194, 43);
			num_UnFollow_SLMax.Name = "num_UnFollow_SLMax";
			num_UnFollow_SLMax.Size = new System.Drawing.Size(43, 23);
			num_UnFollow_SLMax.TabIndex = 221;
			num_UnFollow_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(163, 45);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 220;
			label9.Text = "-->";
			num_UnFollow_SLMin.Location = new System.Drawing.Point(114, 43);
			num_UnFollow_SLMin.Name = "num_UnFollow_SLMin";
			num_UnFollow_SLMin.Size = new System.Drawing.Size(43, 23);
			num_UnFollow_SLMin.TabIndex = 219;
			num_UnFollow_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(243, 77);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 15);
			label3.TabIndex = 227;
			label3.Text = "giây";
			num_UnFollow_TimeMax.Location = new System.Drawing.Point(194, 75);
			num_UnFollow_TimeMax.Name = "num_UnFollow_TimeMax";
			num_UnFollow_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_UnFollow_TimeMax.TabIndex = 226;
			num_UnFollow_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(163, 77);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 225;
			label2.Text = "-->";
			num_UnFollow_TimeMin.Location = new System.Drawing.Point(114, 75);
			num_UnFollow_TimeMin.Name = "num_UnFollow_TimeMin";
			num_UnFollow_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_UnFollow_TimeMin.TabIndex = 224;
			num_UnFollow_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(19, 77);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 15);
			label1.TabIndex = 223;
			label1.Text = "Waiting time :";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(22, 110);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(101, 15);
			label4.TabIndex = 228;
			label4.Text = "UnFollow option :";
			cb_UnFolowFollower.AutoSize = true;
			cb_UnFolowFollower.Location = new System.Drawing.Point(45, 133);
			cb_UnFolowFollower.Name = "cb_UnFolowFollower";
			cb_UnFolowFollower.Size = new System.Drawing.Size(182, 19);
			cb_UnFolowFollower.TabIndex = 229;
			cb_UnFolowFollower.Text = "Ranndom UnFollow followers";
			cb_UnFolowFollower.UseVisualStyleBackColor = true;
			cb_UnFolowFollowing.AutoSize = true;
			cb_UnFolowFollowing.Location = new System.Drawing.Point(45, 158);
			cb_UnFolowFollowing.Name = "cb_UnFolowFollowing";
			cb_UnFolowFollowing.Size = new System.Drawing.Size(184, 19);
			cb_UnFolowFollowing.TabIndex = 230;
			cb_UnFolowFollowing.Text = "Ranndom UnFollow following";
			cb_UnFolowFollowing.UseVisualStyleBackColor = true;
			txt_TenHanhDong.Location = new System.Drawing.Point(114, 12);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(123, 23);
			txt_TenHanhDong.TabIndex = 250;
			txt_TenHanhDong.Text = "UnFollow";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(18, 14);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 249;
			label11.Text = "Action name :";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(159, 192);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 282;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(55, 192);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 281;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(299, 240);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(cb_UnFolowFollowing);
			base.Controls.Add(cb_UnFolowFollower);
			base.Controls.Add(label4);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_UnFollow_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_UnFollow_SLMin);
			base.Controls.Add(label3);
			base.Controls.Add(num_UnFollow_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(num_UnFollow_TimeMin);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "UnFollow";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "UnFollow";
			base.Load += new System.EventHandler(UnFollow_Load);
			((System.ComponentModel.ISupportInitialize)num_UnFollow_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_UnFollow_SLMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_UnFollow_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_UnFollow_TimeMin).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
