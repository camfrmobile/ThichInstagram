using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class FollowTuKhoa : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Label label3;

		private NumericUpDown num_FollowTuKhoa_TimeMax;

		private Label label2;

		private Label label1;

		private NumericUpDown num_FollowTuKhoa_TimeMin;

		private Label label10;

		private Label label8;

		private NumericUpDown num_FollowTuKhoa_SLMax;

		private Label label9;

		private NumericUpDown num_FollowTuKhoa_SLMin;

		private GroupBox groupBox3;

		private RichTextBox rtb_FollowTuKhoa_TuKhoa;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button button1;

		private Button button2;

		public FollowTuKhoa(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public FollowTuKhoa(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_FollowTuKhoa_SLMin", num_FollowTuKhoa_SLMin.Value.ToString());
			jSON_Settings.Add("num_FollowTuKhoa_SLMax", num_FollowTuKhoa_SLMax.Value.ToString());
			jSON_Settings.Add("num_FollowTuKhoa_TimeMin", num_FollowTuKhoa_TimeMin.Value.ToString());
			jSON_Settings.Add("num_FollowTuKhoa_TimeMax", num_FollowTuKhoa_TimeMax.Value.ToString());
			jSON_Settings.Add("rtb_FollowTuKhoa_TuKhoa", rtb_FollowTuKhoa_TuKhoa.Text);
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 11;
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

		private void FollowTuKhoa_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_FollowTuKhoa_SLMin.Value = jSON_Settings.GetValueInt("num_FollowTuKhoa_SLMin");
				num_FollowTuKhoa_SLMax.Value = jSON_Settings.GetValueInt("num_FollowTuKhoa_SLMax");
				num_FollowTuKhoa_TimeMin.Value = jSON_Settings.GetValueInt("num_FollowTuKhoa_TimeMin");
				num_FollowTuKhoa_TimeMax.Value = jSON_Settings.GetValueInt("num_FollowTuKhoa_TimeMax");
				rtb_FollowTuKhoa_TuKhoa.Text = jSON_Settings.GetValue("rtb_FollowTuKhoa_TuKhoa");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label10.Text = "Sô Follow : ";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.FollowTuKhoa));
			label3 = new System.Windows.Forms.Label();
			num_FollowTuKhoa_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			num_FollowTuKhoa_TimeMin = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_FollowTuKhoa_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_FollowTuKhoa_SLMin = new System.Windows.Forms.NumericUpDown();
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_FollowTuKhoa_TuKhoa = new System.Windows.Forms.RichTextBox();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_FollowTuKhoa_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowTuKhoa_TimeMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowTuKhoa_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowTuKhoa_SLMin).BeginInit();
			groupBox3.SuspendLayout();
			SuspendLayout();
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(250, 83);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 224;
			label3.Text = "( s )";
			num_FollowTuKhoa_TimeMax.Location = new System.Drawing.Point(201, 81);
			num_FollowTuKhoa_TimeMax.Name = "num_FollowTuKhoa_TimeMax";
			num_FollowTuKhoa_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_FollowTuKhoa_TimeMax.TabIndex = 223;
			num_FollowTuKhoa_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(170, 83);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 222;
			label2.Text = "-->";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(19, 83);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 15);
			label1.TabIndex = 220;
			label1.Text = "Waiting time :";
			num_FollowTuKhoa_TimeMin.Location = new System.Drawing.Point(121, 81);
			num_FollowTuKhoa_TimeMin.Name = "num_FollowTuKhoa_TimeMin";
			num_FollowTuKhoa_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_FollowTuKhoa_TimeMin.TabIndex = 221;
			num_FollowTuKhoa_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(19, 51);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(78, 15);
			label10.TabIndex = 215;
			label10.Text = "Num Follow :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(250, 51);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(45, 15);
			label8.TabIndex = 219;
			label8.Text = "Follow ";
			num_FollowTuKhoa_SLMax.Location = new System.Drawing.Point(201, 49);
			num_FollowTuKhoa_SLMax.Name = "num_FollowTuKhoa_SLMax";
			num_FollowTuKhoa_SLMax.Size = new System.Drawing.Size(43, 23);
			num_FollowTuKhoa_SLMax.TabIndex = 218;
			num_FollowTuKhoa_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(170, 51);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 217;
			label9.Text = "-->";
			num_FollowTuKhoa_SLMin.Location = new System.Drawing.Point(121, 49);
			num_FollowTuKhoa_SLMin.Name = "num_FollowTuKhoa_SLMin";
			num_FollowTuKhoa_SLMin.Size = new System.Drawing.Size(43, 23);
			num_FollowTuKhoa_SLMin.TabIndex = 216;
			num_FollowTuKhoa_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			groupBox3.Controls.Add(rtb_FollowTuKhoa_TuKhoa);
			groupBox3.Location = new System.Drawing.Point(7, 110);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(286, 169);
			groupBox3.TabIndex = 225;
			groupBox3.TabStop = false;
			groupBox3.Text = "Keyword list:";
			rtb_FollowTuKhoa_TuKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_FollowTuKhoa_TuKhoa.Location = new System.Drawing.Point(3, 19);
			rtb_FollowTuKhoa_TuKhoa.Name = "rtb_FollowTuKhoa_TuKhoa";
			rtb_FollowTuKhoa_TuKhoa.Size = new System.Drawing.Size(280, 147);
			rtb_FollowTuKhoa_TuKhoa.TabIndex = 0;
			rtb_FollowTuKhoa_TuKhoa.Text = "";
			txt_TenHanhDong.Location = new System.Drawing.Point(120, 15);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 227;
			txt_TenHanhDong.Text = "Follow by keyword";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(18, 18);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 226;
			label11.Text = "Action name :";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(159, 296);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 256;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(55, 296);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 255;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(300, 337);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(groupBox3);
			base.Controls.Add(label3);
			base.Controls.Add(num_FollowTuKhoa_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(num_FollowTuKhoa_TimeMin);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_FollowTuKhoa_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_FollowTuKhoa_SLMin);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "FollowTuKhoa";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Follow by keyword";
			base.Load += new System.EventHandler(FollowTuKhoa_Load);
			((System.ComponentModel.ISupportInitialize)num_FollowTuKhoa_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowTuKhoa_TimeMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowTuKhoa_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowTuKhoa_SLMin).EndInit();
			groupBox3.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
