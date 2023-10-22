using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class FollowFollowerUser : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Label label10;

		private Label label8;

		private NumericUpDown num_FollowFollowerUser_SLMax;

		private Label label9;

		private NumericUpDown num_FollowFollowerUser_SLMin;

		private GroupBox groupBox3;

		private RichTextBox rtb_FollowFollowerUser_ID;

		private Label label3;

		private NumericUpDown num_FollowFollowerUser_TimeMax;

		private Label label2;

		private NumericUpDown num_FollowFollowerUser_TimeMin;

		private Label label1;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button btn_Cancel;

		private Button btn_OK;

		public FollowFollowerUser(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public FollowFollowerUser(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_FollowFollowerUser_SLMin", num_FollowFollowerUser_SLMin.Value.ToString());
			jSON_Settings.Add("num_FollowFollowerUser_SLMax", num_FollowFollowerUser_SLMax.Value.ToString());
			jSON_Settings.Add("num_FollowFollowerUser_TimeMin", num_FollowFollowerUser_TimeMin.Value.ToString());
			jSON_Settings.Add("num_FollowFollowerUser_TimeMax", num_FollowFollowerUser_TimeMax.Value.ToString());
			jSON_Settings.Add("rtb_FollowFollowerUser_ID", rtb_FollowFollowerUser_ID.Text);
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 15;
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

		private void FollowFollowerUser_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_FollowFollowerUser_SLMin.Value = jSON_Settings.GetValueInt("num_FollowFollowerUser_SLMin");
				num_FollowFollowerUser_SLMax.Value = jSON_Settings.GetValueInt("num_FollowFollowerUser_SLMax");
				num_FollowFollowerUser_TimeMin.Value = jSON_Settings.GetValueInt("num_FollowFollowerUser_TimeMin");
				num_FollowFollowerUser_TimeMax.Value = jSON_Settings.GetValueInt("num_FollowFollowerUser_TimeMax");
				rtb_FollowFollowerUser_ID.Text = jSON_Settings.GetValue("rtb_FollowFollowerUser_ID");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				groupBox3.Text = "Danh sách User";
				btn_OK.Text = "Lưu";
				btn_Cancel.Text = "Thoát";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.FollowFollowerUser));
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_FollowFollowerUser_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_FollowFollowerUser_SLMin = new System.Windows.Forms.NumericUpDown();
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_FollowFollowerUser_ID = new System.Windows.Forms.RichTextBox();
			label3 = new System.Windows.Forms.Label();
			num_FollowFollowerUser_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			num_FollowFollowerUser_TimeMin = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			btn_Cancel = new System.Windows.Forms.Button();
			btn_OK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_FollowFollowerUser_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowFollowerUser_SLMin).BeginInit();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_FollowFollowerUser_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowFollowerUser_TimeMin).BeginInit();
			SuspendLayout();
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(19, 46);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(76, 15);
			label10.TabIndex = 192;
			label10.Text = "Follow/User :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(289, 46);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(42, 15);
			label8.TabIndex = 196;
			label8.Text = "Follow";
			num_FollowFollowerUser_SLMax.Location = new System.Drawing.Point(240, 44);
			num_FollowFollowerUser_SLMax.Name = "num_FollowFollowerUser_SLMax";
			num_FollowFollowerUser_SLMax.Size = new System.Drawing.Size(43, 23);
			num_FollowFollowerUser_SLMax.TabIndex = 195;
			num_FollowFollowerUser_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(209, 46);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 194;
			label9.Text = "-->";
			num_FollowFollowerUser_SLMin.Location = new System.Drawing.Point(160, 44);
			num_FollowFollowerUser_SLMin.Name = "num_FollowFollowerUser_SLMin";
			num_FollowFollowerUser_SLMin.Size = new System.Drawing.Size(43, 23);
			num_FollowFollowerUser_SLMin.TabIndex = 193;
			num_FollowFollowerUser_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			groupBox3.Controls.Add(rtb_FollowFollowerUser_ID);
			groupBox3.Location = new System.Drawing.Point(22, 104);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(326, 169);
			groupBox3.TabIndex = 189;
			groupBox3.TabStop = false;
			groupBox3.Text = "List of Users :";
			rtb_FollowFollowerUser_ID.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_FollowFollowerUser_ID.Location = new System.Drawing.Point(3, 19);
			rtb_FollowFollowerUser_ID.Name = "rtb_FollowFollowerUser_ID";
			rtb_FollowFollowerUser_ID.Size = new System.Drawing.Size(320, 147);
			rtb_FollowFollowerUser_ID.TabIndex = 0;
			rtb_FollowFollowerUser_ID.Text = "";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(289, 78);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 201;
			label3.Text = "( s )";
			num_FollowFollowerUser_TimeMax.Location = new System.Drawing.Point(240, 76);
			num_FollowFollowerUser_TimeMax.Name = "num_FollowFollowerUser_TimeMax";
			num_FollowFollowerUser_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_FollowFollowerUser_TimeMax.TabIndex = 200;
			num_FollowFollowerUser_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(209, 78);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 199;
			label2.Text = "-->";
			num_FollowFollowerUser_TimeMin.Location = new System.Drawing.Point(160, 76);
			num_FollowFollowerUser_TimeMin.Name = "num_FollowFollowerUser_TimeMin";
			num_FollowFollowerUser_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_FollowFollowerUser_TimeMin.TabIndex = 198;
			num_FollowFollowerUser_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(19, 78);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 15);
			label1.TabIndex = 197;
			label1.Text = "Waiting time :";
			txt_TenHanhDong.Location = new System.Drawing.Point(160, 12);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(171, 23);
			txt_TenHanhDong.TabIndex = 246;
			txt_TenHanhDong.Text = "FollowFollowerUser";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(18, 15);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 245;
			label11.Text = "Action name :";
			btn_Cancel.BackColor = System.Drawing.Color.Maroon;
			btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btn_Cancel.FlatAppearance.BorderSize = 0;
			btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btn_Cancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btn_Cancel.ForeColor = System.Drawing.Color.White;
			btn_Cancel.Location = new System.Drawing.Point(198, 290);
			btn_Cancel.Name = "btn_Cancel";
			btn_Cancel.Size = new System.Drawing.Size(92, 29);
			btn_Cancel.TabIndex = 248;
			btn_Cancel.Text = "Cancel";
			btn_Cancel.UseVisualStyleBackColor = false;
			btn_Cancel.Click += new System.EventHandler(btn_Cancel_Click);
			btn_OK.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btn_OK.Cursor = System.Windows.Forms.Cursors.Hand;
			btn_OK.FlatAppearance.BorderSize = 0;
			btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btn_OK.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btn_OK.ForeColor = System.Drawing.Color.White;
			btn_OK.Location = new System.Drawing.Point(94, 290);
			btn_OK.Name = "btn_OK";
			btn_OK.Size = new System.Drawing.Size(92, 29);
			btn_OK.TabIndex = 247;
			btn_OK.Text = "Save";
			btn_OK.UseVisualStyleBackColor = false;
			btn_OK.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(367, 331);
			base.Controls.Add(btn_Cancel);
			base.Controls.Add(btn_OK);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_FollowFollowerUser_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_FollowFollowerUser_SLMin);
			base.Controls.Add(groupBox3);
			base.Controls.Add(label3);
			base.Controls.Add(num_FollowFollowerUser_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(num_FollowFollowerUser_TimeMin);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FollowFollowerUser";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Follow user's followers";
			base.Load += new System.EventHandler(FollowFollowerUser_Load);
			((System.ComponentModel.ISupportInitialize)num_FollowFollowerUser_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowFollowerUser_SLMin).EndInit();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)num_FollowFollowerUser_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowFollowerUser_TimeMin).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
