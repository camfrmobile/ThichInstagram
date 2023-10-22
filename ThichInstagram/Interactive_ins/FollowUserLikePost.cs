using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class FollowUserLikePost : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Label label10;

		private Label label8;

		private NumericUpDown num_FollowUserLikePost_SLMax;

		private Label label9;

		private NumericUpDown num_FollowUserLikePost_SLMin;

		private GroupBox groupBox3;

		private RichTextBox rtb_FollowUserLikePost_Link;

		private Label label3;

		private NumericUpDown num_FollowUserLikePost_TimeMax;

		private Label label2;

		private NumericUpDown num_FollowUserLikePost_TimeMin;

		private Label label1;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button button1;

		private Button button2;

		public FollowUserLikePost(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public FollowUserLikePost(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_FollowUserLikePost_SLMin", num_FollowUserLikePost_SLMin.Value.ToString());
			jSON_Settings.Add("num_FollowUserLikePost_SLMax", num_FollowUserLikePost_SLMax.Value.ToString());
			jSON_Settings.Add("num_FollowUserLikePost_TimeMin", num_FollowUserLikePost_TimeMin.Value.ToString());
			jSON_Settings.Add("num_FollowUserLikePost_TimeMax", num_FollowUserLikePost_TimeMax.Value.ToString());
			jSON_Settings.Add("rtb_FollowUserLikePost_Link", rtb_FollowUserLikePost_Link.Text);
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 14;
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

		private void FollowUserLikePost_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_FollowUserLikePost_SLMin.Value = jSON_Settings.GetValueInt("num_FollowUserLikePost_SLMin");
				num_FollowUserLikePost_SLMax.Value = jSON_Settings.GetValueInt("num_FollowUserLikePost_SLMax");
				num_FollowUserLikePost_TimeMin.Value = jSON_Settings.GetValueInt("num_FollowUserLikePost_TimeMin");
				num_FollowUserLikePost_TimeMax.Value = jSON_Settings.GetValueInt("num_FollowUserLikePost_TimeMax");
				rtb_FollowUserLikePost_Link.Text = jSON_Settings.GetValue("rtb_FollowUserLikePost_Link");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				label10.Text = "Số Follow/Link : ";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
				groupBox3.Text = "Danh sách Link bài viết";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.FollowUserLikePost));
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_FollowUserLikePost_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_FollowUserLikePost_SLMin = new System.Windows.Forms.NumericUpDown();
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_FollowUserLikePost_Link = new System.Windows.Forms.RichTextBox();
			label3 = new System.Windows.Forms.Label();
			num_FollowUserLikePost_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			num_FollowUserLikePost_TimeMin = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_FollowUserLikePost_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowUserLikePost_SLMin).BeginInit();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_FollowUserLikePost_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowUserLikePost_TimeMin).BeginInit();
			SuspendLayout();
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(19, 45);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(102, 15);
			label10.TabIndex = 177;
			label10.Text = "Num Follow/Link:";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(262, 45);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(42, 15);
			label8.TabIndex = 181;
			label8.Text = "Follow";
			num_FollowUserLikePost_SLMax.Location = new System.Drawing.Point(213, 43);
			num_FollowUserLikePost_SLMax.Name = "num_FollowUserLikePost_SLMax";
			num_FollowUserLikePost_SLMax.Size = new System.Drawing.Size(43, 23);
			num_FollowUserLikePost_SLMax.TabIndex = 180;
			num_FollowUserLikePost_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(182, 45);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 179;
			label9.Text = "-->";
			num_FollowUserLikePost_SLMin.Location = new System.Drawing.Point(133, 43);
			num_FollowUserLikePost_SLMin.Name = "num_FollowUserLikePost_SLMin";
			num_FollowUserLikePost_SLMin.Size = new System.Drawing.Size(43, 23);
			num_FollowUserLikePost_SLMin.TabIndex = 178;
			num_FollowUserLikePost_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			groupBox3.Controls.Add(rtb_FollowUserLikePost_Link);
			groupBox3.Location = new System.Drawing.Point(22, 103);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(286, 169);
			groupBox3.TabIndex = 174;
			groupBox3.TabStop = false;
			groupBox3.Text = "Article link :";
			rtb_FollowUserLikePost_Link.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_FollowUserLikePost_Link.Location = new System.Drawing.Point(3, 19);
			rtb_FollowUserLikePost_Link.Name = "rtb_FollowUserLikePost_Link";
			rtb_FollowUserLikePost_Link.Size = new System.Drawing.Size(280, 147);
			rtb_FollowUserLikePost_Link.TabIndex = 0;
			rtb_FollowUserLikePost_Link.Text = "";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(262, 77);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 188;
			label3.Text = "( s )";
			num_FollowUserLikePost_TimeMax.Location = new System.Drawing.Point(213, 75);
			num_FollowUserLikePost_TimeMax.Name = "num_FollowUserLikePost_TimeMax";
			num_FollowUserLikePost_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_FollowUserLikePost_TimeMax.TabIndex = 187;
			num_FollowUserLikePost_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(182, 77);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 186;
			label2.Text = "-->";
			num_FollowUserLikePost_TimeMin.Location = new System.Drawing.Point(133, 75);
			num_FollowUserLikePost_TimeMin.Name = "num_FollowUserLikePost_TimeMin";
			num_FollowUserLikePost_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_FollowUserLikePost_TimeMin.TabIndex = 185;
			num_FollowUserLikePost_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(19, 77);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 15);
			label1.TabIndex = 184;
			label1.Text = "Waiting time :";
			txt_TenHanhDong.Location = new System.Drawing.Point(133, 12);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 244;
			txt_TenHanhDong.Text = "Follow user like post";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(19, 15);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 243;
			label11.Text = "Action name :";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(169, 281);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 260;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(65, 281);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 259;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(327, 322);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_FollowUserLikePost_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_FollowUserLikePost_SLMin);
			base.Controls.Add(groupBox3);
			base.Controls.Add(label3);
			base.Controls.Add(num_FollowUserLikePost_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(num_FollowUserLikePost_TimeMin);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "FollowUserLikePost";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Follow user like post";
			base.Load += new System.EventHandler(FollowUserLikePost_Load);
			((System.ComponentModel.ISupportInitialize)num_FollowUserLikePost_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowUserLikePost_SLMin).EndInit();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)num_FollowUserLikePost_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowUserLikePost_TimeMin).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
