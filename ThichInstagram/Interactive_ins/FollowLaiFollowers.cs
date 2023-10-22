using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class FollowLaiFollowers : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Label label3;

		private NumericUpDown num_FollowLaiFollower_TimeMax;

		private Label label2;

		private Label label1;

		private NumericUpDown num_FollowLaiFollower_TimeMin;

		private Label label10;

		private Label label8;

		private NumericUpDown num_FollowLaiFollower_SLMax;

		private Label label9;

		private NumericUpDown num_FollowLaiFollower_SLMin;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button button1;

		private Button button2;

		public FollowLaiFollowers(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public FollowLaiFollowers(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_FollowLaiFollower_SLMin", num_FollowLaiFollower_SLMin.Value.ToString());
			jSON_Settings.Add("num_FollowLaiFollower_SLMax", num_FollowLaiFollower_SLMax.Value.ToString());
			jSON_Settings.Add("num_FollowLaiFollower_TimeMin", num_FollowLaiFollower_TimeMin.Value.ToString());
			jSON_Settings.Add("num_FollowLaiFollower_TimeMax", num_FollowLaiFollower_TimeMax.Value.ToString());
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 13;
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

		private void FollowLaiFollowers_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_FollowLaiFollower_SLMin.Value = jSON_Settings.GetValueInt("num_FollowLaiFollower_SLMin");
				num_FollowLaiFollower_SLMax.Value = jSON_Settings.GetValueInt("num_FollowLaiFollower_SLMax");
				num_FollowLaiFollower_TimeMin.Value = jSON_Settings.GetValueInt("num_FollowLaiFollower_TimeMin");
				num_FollowLaiFollower_TimeMax.Value = jSON_Settings.GetValueInt("num_FollowLaiFollower_TimeMax");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label10.Text = "Sô Follow : ";
				label1.Text = "Thời gian chờ : ";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.FollowLaiFollowers));
			label3 = new System.Windows.Forms.Label();
			num_FollowLaiFollower_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			num_FollowLaiFollower_TimeMin = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_FollowLaiFollower_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_FollowLaiFollower_SLMin = new System.Windows.Forms.NumericUpDown();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_FollowLaiFollower_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowLaiFollower_TimeMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowLaiFollower_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowLaiFollower_SLMin).BeginInit();
			SuspendLayout();
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(251, 81);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 236;
			label3.Text = "( s )";
			num_FollowLaiFollower_TimeMax.Location = new System.Drawing.Point(202, 79);
			num_FollowLaiFollower_TimeMax.Name = "num_FollowLaiFollower_TimeMax";
			num_FollowLaiFollower_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_FollowLaiFollower_TimeMax.TabIndex = 235;
			num_FollowLaiFollower_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(171, 81);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 234;
			label2.Text = "-->";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(20, 81);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 15);
			label1.TabIndex = 232;
			label1.Text = "Waiting time :";
			num_FollowLaiFollower_TimeMin.Location = new System.Drawing.Point(122, 79);
			num_FollowLaiFollower_TimeMin.Name = "num_FollowLaiFollower_TimeMin";
			num_FollowLaiFollower_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_FollowLaiFollower_TimeMin.TabIndex = 233;
			num_FollowLaiFollower_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(20, 49);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(78, 15);
			label10.TabIndex = 227;
			label10.Text = "Num Follow :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(251, 49);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(42, 15);
			label8.TabIndex = 231;
			label8.Text = "Follow";
			num_FollowLaiFollower_SLMax.Location = new System.Drawing.Point(202, 47);
			num_FollowLaiFollower_SLMax.Name = "num_FollowLaiFollower_SLMax";
			num_FollowLaiFollower_SLMax.Size = new System.Drawing.Size(43, 23);
			num_FollowLaiFollower_SLMax.TabIndex = 230;
			num_FollowLaiFollower_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(171, 49);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 229;
			label9.Text = "-->";
			num_FollowLaiFollower_SLMin.Location = new System.Drawing.Point(122, 47);
			num_FollowLaiFollower_SLMin.Name = "num_FollowLaiFollower_SLMin";
			num_FollowLaiFollower_SLMin.Size = new System.Drawing.Size(43, 23);
			num_FollowLaiFollower_SLMin.TabIndex = 228;
			num_FollowLaiFollower_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			txt_TenHanhDong.Location = new System.Drawing.Point(121, 16);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 242;
			txt_TenHanhDong.Text = "Follow back Followers";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(19, 19);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 241;
			label11.Text = "Action name :";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(158, 120);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 254;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(54, 120);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 253;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(301, 164);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(label3);
			base.Controls.Add(num_FollowLaiFollower_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(num_FollowLaiFollower_TimeMin);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_FollowLaiFollower_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_FollowLaiFollower_SLMin);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "FollowLaiFollowers";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Follow back Followers";
			base.Load += new System.EventHandler(FollowLaiFollowers_Load);
			((System.ComponentModel.ISupportInitialize)num_FollowLaiFollower_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowLaiFollower_TimeMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowLaiFollower_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowLaiFollower_SLMin).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
