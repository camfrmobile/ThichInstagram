using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class TuongTacFollowing : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Label label8;

		private NumericUpDown num_TTFollowing_SLMax;

		private Label label9;

		private Label label10;

		private GroupBox groupBox1;

		private Label label6;

		private NumericUpDown num_TTFollowing_CmtMax;

		private Label label7;

		private NumericUpDown num_TTFollowing_CmtMin;

		private CheckBox cb_TTFollowing_Cmt;

		private Label label4;

		private NumericUpDown num_TTFollowing_LikeMax;

		private Label label5;

		private NumericUpDown num_TTFollowing_LikeMin;

		private CheckBox cb_TTFollowing_Like;

		private Label label3;

		private NumericUpDown num_TTFollowing_TimeMax;

		private Label label2;

		private NumericUpDown num_TTFollowing_TimeMin;

		private Label label1;

		private NumericUpDown num_TTFollowing_SLMin;

		private GroupBox groupBox3;

		private RichTextBox rtb_TTFollowing_Cmt;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button button1;

		private Button button2;

		public TuongTacFollowing(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public TuongTacFollowing(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_TTFollowing_SLMin", num_TTFollowing_SLMin.Value.ToString());
			jSON_Settings.Add("num_TTFollowing_SLMax", num_TTFollowing_SLMax.Value.ToString());
			jSON_Settings.Add("num_TTFollowing_TimeMin", num_TTFollowing_TimeMin.Value.ToString());
			jSON_Settings.Add("num_TTFollowing_TimeMax", num_TTFollowing_TimeMax.Value.ToString());
			jSON_Settings.Add("num_TTFollowing_LikeMin", num_TTFollowing_LikeMin.Value.ToString());
			jSON_Settings.Add("num_TTFollowing_LikeMax", num_TTFollowing_LikeMax.Value.ToString());
			jSON_Settings.Add("num_TTFollowing_CmtMin", num_TTFollowing_CmtMin.Value.ToString());
			jSON_Settings.Add("num_TTFollowing_CmtMax", num_TTFollowing_CmtMax.Value.ToString());
			jSON_Settings.Add("cb_TTFollowing_Like", cb_TTFollowing_Like.Checked.ToString());
			jSON_Settings.Add("cb_TTFollowing_Cmt", cb_TTFollowing_Cmt.Checked.ToString());
			jSON_Settings.Add("rtb_TTFollowing_Cmt", rtb_TTFollowing_Cmt.Text);
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 2;
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

		private void TuongTacFollowing_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_TTFollowing_SLMin.Value = jSON_Settings.GetValueInt("num_TTFollowing_SLMin");
				num_TTFollowing_SLMax.Value = jSON_Settings.GetValueInt("num_TTFollowing_SLMax");
				num_TTFollowing_TimeMin.Value = jSON_Settings.GetValueInt("num_TTFollowing_TimeMin");
				num_TTFollowing_TimeMax.Value = jSON_Settings.GetValueInt("num_TTFollowing_TimeMax");
				num_TTFollowing_LikeMin.Value = jSON_Settings.GetValueInt("num_TTFollowing_LikeMin");
				num_TTFollowing_LikeMax.Value = jSON_Settings.GetValueInt("num_TTFollowing_LikeMax");
				num_TTFollowing_CmtMin.Value = jSON_Settings.GetValueInt("num_TTFollowing_CmtMin");
				num_TTFollowing_CmtMax.Value = jSON_Settings.GetValueInt("num_TTFollowing_CmtMax");
				cb_TTFollowing_Like.Checked = jSON_Settings.GetValueBool("cb_TTFollowing_Like");
				cb_TTFollowing_Cmt.Checked = jSON_Settings.GetValueBool("cb_TTFollowing_Cmt");
				rtb_TTFollowing_Cmt.Text = jSON_Settings.GetValue("rtb_TTFollowing_Cmt");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				label10.Text = "Số lượng : ";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
				groupBox3.Text = "Nội dung bình luận";
				cb_TTFollowing_Cmt.Text = "Bình luận";
			}
		}

		private void button1_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.TuongTacFollowing));
			label8 = new System.Windows.Forms.Label();
			num_TTFollowing_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_TTFollowing_Cmt = new System.Windows.Forms.RichTextBox();
			label6 = new System.Windows.Forms.Label();
			num_TTFollowing_CmtMax = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			num_TTFollowing_CmtMin = new System.Windows.Forms.NumericUpDown();
			cb_TTFollowing_Cmt = new System.Windows.Forms.CheckBox();
			label4 = new System.Windows.Forms.Label();
			num_TTFollowing_LikeMax = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			num_TTFollowing_LikeMin = new System.Windows.Forms.NumericUpDown();
			cb_TTFollowing_Like = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			num_TTFollowing_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			num_TTFollowing_TimeMin = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			num_TTFollowing_SLMin = new System.Windows.Forms.NumericUpDown();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_SLMax).BeginInit();
			groupBox1.SuspendLayout();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_CmtMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_CmtMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_LikeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_LikeMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_TimeMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_SLMin).BeginInit();
			SuspendLayout();
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(288, 48);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(30, 15);
			label8.TabIndex = 127;
			label8.Text = "User";
			num_TTFollowing_SLMax.Location = new System.Drawing.Point(239, 46);
			num_TTFollowing_SLMax.Name = "num_TTFollowing_SLMax";
			num_TTFollowing_SLMax.Size = new System.Drawing.Size(43, 23);
			num_TTFollowing_SLMax.TabIndex = 126;
			num_TTFollowing_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(208, 48);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 125;
			label9.Text = "-->";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(28, 48);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(59, 15);
			label10.TabIndex = 123;
			label10.Text = "Quantity :";
			groupBox1.Controls.Add(groupBox3);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(num_TTFollowing_CmtMax);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(num_TTFollowing_CmtMin);
			groupBox1.Controls.Add(cb_TTFollowing_Cmt);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(num_TTFollowing_LikeMax);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(num_TTFollowing_LikeMin);
			groupBox1.Controls.Add(cb_TTFollowing_Like);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(num_TTFollowing_TimeMax);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(num_TTFollowing_TimeMin);
			groupBox1.Controls.Add(label1);
			groupBox1.Location = new System.Drawing.Point(12, 78);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(329, 309);
			groupBox1.TabIndex = 120;
			groupBox1.TabStop = false;
			groupBox1.Text = "Interactive configuration /User";
			groupBox3.Controls.Add(rtb_TTFollowing_Cmt);
			groupBox3.Location = new System.Drawing.Point(19, 121);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(286, 169);
			groupBox3.TabIndex = 162;
			groupBox3.TabStop = false;
			groupBox3.Text = "Comment content:";
			rtb_TTFollowing_Cmt.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_TTFollowing_Cmt.Location = new System.Drawing.Point(3, 19);
			rtb_TTFollowing_Cmt.Name = "rtb_TTFollowing_Cmt";
			rtb_TTFollowing_Cmt.Size = new System.Drawing.Size(280, 147);
			rtb_TTFollowing_Cmt.TabIndex = 0;
			rtb_TTFollowing_Cmt.Text = "";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(276, 92);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(29, 15);
			label6.TabIndex = 14;
			label6.Text = "Cmt";
			num_TTFollowing_CmtMax.Location = new System.Drawing.Point(227, 90);
			num_TTFollowing_CmtMax.Name = "num_TTFollowing_CmtMax";
			num_TTFollowing_CmtMax.Size = new System.Drawing.Size(43, 23);
			num_TTFollowing_CmtMax.TabIndex = 13;
			num_TTFollowing_CmtMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(196, 92);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(25, 15);
			label7.TabIndex = 12;
			label7.Text = "-->";
			num_TTFollowing_CmtMin.Location = new System.Drawing.Point(147, 90);
			num_TTFollowing_CmtMin.Name = "num_TTFollowing_CmtMin";
			num_TTFollowing_CmtMin.Size = new System.Drawing.Size(43, 23);
			num_TTFollowing_CmtMin.TabIndex = 11;
			num_TTFollowing_CmtMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			cb_TTFollowing_Cmt.AutoSize = true;
			cb_TTFollowing_Cmt.Location = new System.Drawing.Point(19, 90);
			cb_TTFollowing_Cmt.Name = "cb_TTFollowing_Cmt";
			cb_TTFollowing_Cmt.Size = new System.Drawing.Size(79, 19);
			cb_TTFollowing_Cmt.TabIndex = 10;
			cb_TTFollowing_Cmt.Text = "Comment";
			cb_TTFollowing_Cmt.UseVisualStyleBackColor = true;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(276, 55);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(28, 15);
			label4.TabIndex = 9;
			label4.Text = "Like";
			num_TTFollowing_LikeMax.Location = new System.Drawing.Point(227, 53);
			num_TTFollowing_LikeMax.Name = "num_TTFollowing_LikeMax";
			num_TTFollowing_LikeMax.Size = new System.Drawing.Size(43, 23);
			num_TTFollowing_LikeMax.TabIndex = 8;
			num_TTFollowing_LikeMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(196, 55);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(25, 15);
			label5.TabIndex = 7;
			label5.Text = "-->";
			num_TTFollowing_LikeMin.Location = new System.Drawing.Point(147, 53);
			num_TTFollowing_LikeMin.Name = "num_TTFollowing_LikeMin";
			num_TTFollowing_LikeMin.Size = new System.Drawing.Size(43, 23);
			num_TTFollowing_LikeMin.TabIndex = 6;
			num_TTFollowing_LikeMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			cb_TTFollowing_Like.AutoSize = true;
			cb_TTFollowing_Like.Location = new System.Drawing.Point(19, 53);
			cb_TTFollowing_Like.Name = "cb_TTFollowing_Like";
			cb_TTFollowing_Like.Size = new System.Drawing.Size(47, 19);
			cb_TTFollowing_Like.TabIndex = 5;
			cb_TTFollowing_Like.Text = "Like";
			cb_TTFollowing_Like.UseVisualStyleBackColor = true;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(276, 20);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 4;
			label3.Text = "( s )";
			num_TTFollowing_TimeMax.Location = new System.Drawing.Point(227, 18);
			num_TTFollowing_TimeMax.Name = "num_TTFollowing_TimeMax";
			num_TTFollowing_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_TTFollowing_TimeMax.TabIndex = 3;
			num_TTFollowing_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(196, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 2;
			label2.Text = "-->";
			num_TTFollowing_TimeMin.Location = new System.Drawing.Point(147, 18);
			num_TTFollowing_TimeMin.Name = "num_TTFollowing_TimeMin";
			num_TTFollowing_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_TTFollowing_TimeMin.TabIndex = 1;
			num_TTFollowing_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 20);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(82, 15);
			label1.TabIndex = 0;
			label1.Text = "Waiting time :";
			num_TTFollowing_SLMin.Location = new System.Drawing.Point(159, 46);
			num_TTFollowing_SLMin.Name = "num_TTFollowing_SLMin";
			num_TTFollowing_SLMin.Size = new System.Drawing.Size(43, 23);
			num_TTFollowing_SLMin.TabIndex = 124;
			num_TTFollowing_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			txt_TenHanhDong.Location = new System.Drawing.Point(159, 11);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(155, 23);
			txt_TenHanhDong.TabIndex = 166;
			txt_TenHanhDong.Text = "Interactive Following";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(28, 14);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 165;
			label11.Text = "Action name :";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(188, 400);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 276;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(button1_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(84, 400);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 275;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(353, 441);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(label8);
			base.Controls.Add(num_TTFollowing_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(label10);
			base.Controls.Add(groupBox1);
			base.Controls.Add(num_TTFollowing_SLMin);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "TuongTacFollowing";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Interactive Following";
			base.Load += new System.EventHandler(TuongTacFollowing_Load);
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_SLMax).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_CmtMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_CmtMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_LikeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_LikeMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_TimeMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowing_SLMin).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
