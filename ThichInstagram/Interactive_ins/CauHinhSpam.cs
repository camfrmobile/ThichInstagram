using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class CauHinhSpam : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private RichTextBox rtb_Spam_NDcmt;

		private GroupBox groupBox3;

		private GroupBox groupBox1;

		private RichTextBox rtb_Spam_LUser;

		private Label label1;

		private NumericUpDown num_Spam_TimeMax;

		private Label label2;

		private NumericUpDown num_Spam_TimeMin;

		private Label label3;

		private NumericUpDown num_Spam_SLMin;

		private Label label10;

		private Label label8;

		private NumericUpDown num_Spam_SLMax;

		private Label label9;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button btnCancel;

		private Button btnAdd;

		public CauHinhSpam(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public CauHinhSpam(Thongso_HanhDong Thongso_HanhDong)
		{
			InitializeComponent();
			this.Thongso_HanhDong = Thongso_HanhDong;
		}

		private void CauHinhSpam_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_Spam_SLMin.Value = jSON_Settings.GetValueInt("num_Spam_SLMin");
				num_Spam_SLMax.Value = jSON_Settings.GetValueInt("num_Spam_SLMax");
				num_Spam_TimeMin.Value = jSON_Settings.GetValueInt("num_Spam_TimeMin");
				num_Spam_TimeMax.Value = jSON_Settings.GetValueInt("num_Spam_TimeMax");
				rtb_Spam_LUser.Text = jSON_Settings.GetValue("rtb_Spam_LUser");
				rtb_Spam_NDcmt.Text = jSON_Settings.GetValue("rtb_Spam_NDcmt");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				groupBox1.Text = "Danh sách User : ";
				groupBox3.Text = "Nội dung bình luận:";
				btnAdd.Text = "Lưu";
				btnCancel.Text = "Thoát";
			}
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			File.Delete("settings\\Cache.json");
			interact_sql interact_sql2 = new interact_sql();
			JSON_Settings jSON_Settings = new JSON_Settings("Cache");
			jSON_Settings.Add("txt_TenHanhDong", txt_TenHanhDong.Text);
			jSON_Settings.Add("num_Spam_SLMin", num_Spam_SLMin.Value.ToString());
			jSON_Settings.Add("num_Spam_SLMax", num_Spam_SLMax.Value.ToString());
			jSON_Settings.Add("num_Spam_TimeMin", num_Spam_TimeMin.Value.ToString());
			jSON_Settings.Add("num_Spam_TimeMax", num_Spam_TimeMax.Value.ToString());
			jSON_Settings.Add("rtb_Spam_LUser", rtb_Spam_LUser.Text);
			jSON_Settings.Add("rtb_Spam_NDcmt", rtb_Spam_NDcmt.Text);
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 8;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.CauHinhSpam));
			rtb_Spam_NDcmt = new System.Windows.Forms.RichTextBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			rtb_Spam_LUser = new System.Windows.Forms.RichTextBox();
			label1 = new System.Windows.Forms.Label();
			num_Spam_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			num_Spam_TimeMin = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			num_Spam_SLMin = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_Spam_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			groupBox3.SuspendLayout();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_Spam_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Spam_TimeMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Spam_SLMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Spam_SLMax).BeginInit();
			SuspendLayout();
			rtb_Spam_NDcmt.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_Spam_NDcmt.Location = new System.Drawing.Point(3, 19);
			rtb_Spam_NDcmt.Name = "rtb_Spam_NDcmt";
			rtb_Spam_NDcmt.Size = new System.Drawing.Size(280, 268);
			rtb_Spam_NDcmt.TabIndex = 0;
			rtb_Spam_NDcmt.Text = "";
			groupBox3.Controls.Add(rtb_Spam_NDcmt);
			groupBox3.Location = new System.Drawing.Point(304, 19);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(286, 290);
			groupBox3.TabIndex = 144;
			groupBox3.TabStop = false;
			groupBox3.Text = "Comment content :";
			groupBox1.Controls.Add(rtb_Spam_LUser);
			groupBox1.Location = new System.Drawing.Point(10, 112);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(281, 200);
			groupBox1.TabIndex = 143;
			groupBox1.TabStop = false;
			groupBox1.Text = "List of Users :";
			rtb_Spam_LUser.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_Spam_LUser.Location = new System.Drawing.Point(3, 19);
			rtb_Spam_LUser.Name = "rtb_Spam_LUser";
			rtb_Spam_LUser.Size = new System.Drawing.Size(275, 178);
			rtb_Spam_LUser.TabIndex = 0;
			rtb_Spam_LUser.Text = "";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(17, 87);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 15);
			label1.TabIndex = 154;
			label1.Text = "Waiting time :";
			num_Spam_TimeMax.Location = new System.Drawing.Point(199, 85);
			num_Spam_TimeMax.Name = "num_Spam_TimeMax";
			num_Spam_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_Spam_TimeMax.TabIndex = 157;
			num_Spam_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(168, 87);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 156;
			label2.Text = "-->";
			num_Spam_TimeMin.Location = new System.Drawing.Point(119, 85);
			num_Spam_TimeMin.Name = "num_Spam_TimeMin";
			num_Spam_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_Spam_TimeMin.TabIndex = 155;
			num_Spam_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(248, 87);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 158;
			label3.Text = "( s )";
			num_Spam_SLMin.Location = new System.Drawing.Point(119, 53);
			num_Spam_SLMin.Name = "num_Spam_SLMin";
			num_Spam_SLMin.Size = new System.Drawing.Size(43, 23);
			num_Spam_SLMin.TabIndex = 148;
			num_Spam_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(17, 55);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(67, 15);
			label10.TabIndex = 147;
			label10.Text = "Post /User :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(248, 55);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(30, 15);
			label8.TabIndex = 151;
			label8.Text = "Post";
			num_Spam_SLMax.Location = new System.Drawing.Point(199, 53);
			num_Spam_SLMax.Name = "num_Spam_SLMax";
			num_Spam_SLMax.Size = new System.Drawing.Size(43, 23);
			num_Spam_SLMax.TabIndex = 150;
			num_Spam_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(168, 55);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 149;
			label9.Text = "-->";
			txt_TenHanhDong.Location = new System.Drawing.Point(120, 19);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 204;
			txt_TenHanhDong.Text = "Spam";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(18, 22);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 203;
			label11.Text = "Action name :";
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(308, 326);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 206;
			btnCancel.Text = "Close";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btn_Cancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(199, 326);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 205;
			btnAdd.Text = "Save";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(602, 367);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(groupBox3);
			base.Controls.Add(groupBox1);
			base.Controls.Add(label1);
			base.Controls.Add(num_Spam_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(num_Spam_TimeMin);
			base.Controls.Add(label3);
			base.Controls.Add(num_Spam_SLMin);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_Spam_SLMax);
			base.Controls.Add(label9);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "CauHinhSpam";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Spam Posts";
			base.Load += new System.EventHandler(CauHinhSpam_Load);
			groupBox3.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)num_Spam_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Spam_TimeMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Spam_SLMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Spam_SLMax).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
