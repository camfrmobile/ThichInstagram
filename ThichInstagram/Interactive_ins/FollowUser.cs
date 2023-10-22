using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class FollowUser : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private GroupBox groupBox3;

		private RichTextBox rtb_FollowUser_User;

		private Label label3;

		private NumericUpDown num_FollowUser_TimeMax;

		private Label label2;

		private Label label1;

		private NumericUpDown num_FollowUser_TimeMin;

		private Label label11;

		private TextBox txt_TenHanhDong;

		private Button button1;

		private Button button2;

		public FollowUser(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public FollowUser(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_FollowUser_TimeMin", num_FollowUser_TimeMin.Value.ToString());
			jSON_Settings.Add("num_FollowUser_TimeMax", num_FollowUser_TimeMax.Value.ToString());
			jSON_Settings.Add("rtb_FollowUser_User", rtb_FollowUser_User.Text);
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 12;
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

		private void FollowUser_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_FollowUser_TimeMin.Value = jSON_Settings.GetValueInt("num_FollowTuKhoa_TimeMin");
				num_FollowUser_TimeMax.Value = jSON_Settings.GetValueInt("num_FollowTuKhoa_TimeMax");
				rtb_FollowUser_User.Text = jSON_Settings.GetValue("rtb_FollowTuKhoa_TuKhoa");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
				groupBox3.Text = "Danh sách Keyword";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.FollowUser));
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_FollowUser_User = new System.Windows.Forms.RichTextBox();
			label3 = new System.Windows.Forms.Label();
			num_FollowUser_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			num_FollowUser_TimeMin = new System.Windows.Forms.NumericUpDown();
			label11 = new System.Windows.Forms.Label();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_FollowUser_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowUser_TimeMin).BeginInit();
			SuspendLayout();
			groupBox3.Controls.Add(rtb_FollowUser_User);
			groupBox3.Location = new System.Drawing.Point(20, 78);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(286, 169);
			groupBox3.TabIndex = 238;
			groupBox3.TabStop = false;
			groupBox3.Text = "List of Users :";
			rtb_FollowUser_User.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_FollowUser_User.Location = new System.Drawing.Point(3, 19);
			rtb_FollowUser_User.Name = "rtb_FollowUser_User";
			rtb_FollowUser_User.Size = new System.Drawing.Size(280, 147);
			rtb_FollowUser_User.TabIndex = 0;
			rtb_FollowUser_User.Text = "";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(263, 48);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 237;
			label3.Text = "( s )";
			num_FollowUser_TimeMax.Location = new System.Drawing.Point(214, 46);
			num_FollowUser_TimeMax.Name = "num_FollowUser_TimeMax";
			num_FollowUser_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_FollowUser_TimeMax.TabIndex = 236;
			num_FollowUser_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(183, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 235;
			label2.Text = "-->";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(32, 48);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 15);
			label1.TabIndex = 233;
			label1.Text = "Waiting time :";
			num_FollowUser_TimeMin.Location = new System.Drawing.Point(134, 46);
			num_FollowUser_TimeMin.Name = "num_FollowUser_TimeMin";
			num_FollowUser_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_FollowUser_TimeMin.TabIndex = 234;
			num_FollowUser_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(31, 15);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 239;
			label11.Text = "Action name :";
			txt_TenHanhDong.Location = new System.Drawing.Point(133, 12);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 240;
			txt_TenHanhDong.Text = "Follow by user";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(170, 262);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 258;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(66, 262);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 257;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(327, 303);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(groupBox3);
			base.Controls.Add(label3);
			base.Controls.Add(num_FollowUser_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(num_FollowUser_TimeMin);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "FollowUser";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Follow by user";
			base.Load += new System.EventHandler(FollowUser_Load);
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)num_FollowUser_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowUser_TimeMin).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
