using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class FollowGoiY : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Label label3;

		private NumericUpDown num_FollowGoiY_TimeMax;

		private Label label2;

		private Label label1;

		private NumericUpDown num_FollowGoiY_TimeMin;

		private Label label10;

		private Label label8;

		private NumericUpDown num_FollowGoiY_SLMax;

		private Label label9;

		private NumericUpDown num_FollowGoiY_SLMin;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button btn_Cancel;

		private Button btn_ok;

		public FollowGoiY(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public FollowGoiY(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_FollowGoiY_SLMin", num_FollowGoiY_SLMin.Value.ToString());
			jSON_Settings.Add("num_FollowGoiY_SLMax", num_FollowGoiY_SLMax.Value.ToString());
			jSON_Settings.Add("num_FollowGoiY_TimeMin", num_FollowGoiY_TimeMin.Value.ToString());
			jSON_Settings.Add("num_FollowGoiY_TimeMax", num_FollowGoiY_TimeMax.Value.ToString());
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 10;
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

		private void FollowGoiY_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_FollowGoiY_SLMin.Value = jSON_Settings.GetValueInt("num_FollowGoiY_SLMin");
				num_FollowGoiY_SLMax.Value = jSON_Settings.GetValueInt("num_FollowGoiY_SLMax");
				num_FollowGoiY_TimeMin.Value = jSON_Settings.GetValueInt("num_FollowGoiY_TimeMin");
				num_FollowGoiY_TimeMax.Value = jSON_Settings.GetValueInt("num_FollowGoiY_TimeMax");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label10.Text = "Sô Follow : ";
				label1.Text = "Thời gian chờ : ";
				btn_ok.Text = "Lưu";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.FollowGoiY));
			label3 = new System.Windows.Forms.Label();
			num_FollowGoiY_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			num_FollowGoiY_TimeMin = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_FollowGoiY_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_FollowGoiY_SLMin = new System.Windows.Forms.NumericUpDown();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			btn_Cancel = new System.Windows.Forms.Button();
			btn_ok = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_FollowGoiY_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowGoiY_TimeMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowGoiY_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_FollowGoiY_SLMin).BeginInit();
			SuspendLayout();
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(250, 79);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 212;
			label3.Text = "( s )";
			num_FollowGoiY_TimeMax.Location = new System.Drawing.Point(201, 77);
			num_FollowGoiY_TimeMax.Name = "num_FollowGoiY_TimeMax";
			num_FollowGoiY_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_FollowGoiY_TimeMax.TabIndex = 211;
			num_FollowGoiY_TimeMax.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(170, 79);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 210;
			label2.Text = "-->";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(19, 79);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 15);
			label1.TabIndex = 208;
			label1.Text = "Waiting time :";
			num_FollowGoiY_TimeMin.Location = new System.Drawing.Point(121, 77);
			num_FollowGoiY_TimeMin.Name = "num_FollowGoiY_TimeMin";
			num_FollowGoiY_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_FollowGoiY_TimeMin.TabIndex = 209;
			num_FollowGoiY_TimeMin.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(19, 47);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(78, 15);
			label10.TabIndex = 203;
			label10.Text = "Num Follow :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(250, 47);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(42, 15);
			label8.TabIndex = 207;
			label8.Text = "Follow";
			num_FollowGoiY_SLMax.Location = new System.Drawing.Point(201, 45);
			num_FollowGoiY_SLMax.Name = "num_FollowGoiY_SLMax";
			num_FollowGoiY_SLMax.Size = new System.Drawing.Size(43, 23);
			num_FollowGoiY_SLMax.TabIndex = 206;
			num_FollowGoiY_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(170, 47);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 205;
			label9.Text = "-->";
			num_FollowGoiY_SLMin.Location = new System.Drawing.Point(121, 45);
			num_FollowGoiY_SLMin.Name = "num_FollowGoiY_SLMin";
			num_FollowGoiY_SLMin.Size = new System.Drawing.Size(43, 23);
			num_FollowGoiY_SLMin.TabIndex = 204;
			num_FollowGoiY_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			txt_TenHanhDong.Location = new System.Drawing.Point(122, 12);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 214;
			txt_TenHanhDong.Text = "Follow suggestions ";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(20, 15);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 213;
			label11.Text = "Action name :";
			btn_Cancel.BackColor = System.Drawing.Color.Maroon;
			btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btn_Cancel.FlatAppearance.BorderSize = 0;
			btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btn_Cancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btn_Cancel.ForeColor = System.Drawing.Color.White;
			btn_Cancel.Location = new System.Drawing.Point(159, 119);
			btn_Cancel.Name = "btn_Cancel";
			btn_Cancel.Size = new System.Drawing.Size(92, 29);
			btn_Cancel.TabIndex = 252;
			btn_Cancel.Text = "Cancel";
			btn_Cancel.UseVisualStyleBackColor = false;
			btn_Cancel.Click += new System.EventHandler(btn_Cancel_Click);
			btn_ok.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btn_ok.Cursor = System.Windows.Forms.Cursors.Hand;
			btn_ok.FlatAppearance.BorderSize = 0;
			btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btn_ok.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btn_ok.ForeColor = System.Drawing.Color.White;
			btn_ok.Location = new System.Drawing.Point(55, 119);
			btn_ok.Name = "btn_ok";
			btn_ok.Size = new System.Drawing.Size(92, 29);
			btn_ok.TabIndex = 251;
			btn_ok.Text = "Save";
			btn_ok.UseVisualStyleBackColor = false;
			btn_ok.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(300, 164);
			base.Controls.Add(btn_Cancel);
			base.Controls.Add(btn_ok);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(label3);
			base.Controls.Add(num_FollowGoiY_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(num_FollowGoiY_TimeMin);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_FollowGoiY_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_FollowGoiY_SLMin);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "FollowGoiY";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Follow suggestions ";
			base.Load += new System.EventHandler(FollowGoiY_Load);
			((System.ComponentModel.ISupportInitialize)num_FollowGoiY_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowGoiY_TimeMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowGoiY_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_FollowGoiY_SLMin).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
