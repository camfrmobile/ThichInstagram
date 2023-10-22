using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class TuongTacFollowers : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Label label6;

		private NumericUpDown num_TTFollowers_CmtMax;

		private Label label7;

		private NumericUpDown num_TTFollowers_CmtMin;

		private CheckBox cb_TTFollowers_Cmt;

		private Label label4;

		private NumericUpDown num_TTFollowers_LikeMax;

		private Label label5;

		private NumericUpDown num_TTFollowers_LikeMin;

		private CheckBox cb_TTFollowers_Like;

		private Label label3;

		private NumericUpDown num_TTFollowers_TimeMax;

		private Label label2;

		private NumericUpDown num_TTFollowers_TimeMin;

		private Label label1;

		private GroupBox groupBox1;

		private Label label8;

		private NumericUpDown num_TTFollowers_SLMax;

		private Label label9;

		private NumericUpDown num_TTFollowers_SLMin;

		private Label label10;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private GroupBox groupBox3;

		private RichTextBox rtb_TTFollowers_Cmt;

		private Button button1;

		private Button button2;

		public TuongTacFollowers(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public TuongTacFollowers(Thongso_HanhDong Thongso_HanhDong)
		{
			InitializeComponent();
			this.Thongso_HanhDong = Thongso_HanhDong;
		}

		private void TuongTacFollowers_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_TTFollowers_SLMin.Value = jSON_Settings.GetValueInt("num_TTFollowers_SLMin");
				num_TTFollowers_SLMax.Value = jSON_Settings.GetValueInt("num_TTFollowers_SLMax");
				num_TTFollowers_TimeMin.Value = jSON_Settings.GetValueInt("num_TTFollowers_TimeMin");
				num_TTFollowers_TimeMax.Value = jSON_Settings.GetValueInt("num_TTFollowers_TimeMax");
				num_TTFollowers_LikeMin.Value = jSON_Settings.GetValueInt("num_TTFollowers_LikeMin");
				num_TTFollowers_LikeMax.Value = jSON_Settings.GetValueInt("num_TTFollowers_LikeMax");
				num_TTFollowers_CmtMin.Value = jSON_Settings.GetValueInt("num_TTFollowers_CmtMin");
				num_TTFollowers_CmtMax.Value = jSON_Settings.GetValueInt("num_TTFollowers_CmtMax");
				cb_TTFollowers_Like.Checked = jSON_Settings.GetValueBool("cb_TTFollowers_Like");
				cb_TTFollowers_Cmt.Checked = jSON_Settings.GetValueBool("cb_TTFollowers_Cmt");
				rtb_TTFollowers_Cmt.Text = jSON_Settings.GetValue("rtb_TTFollowers_Cmt");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				label10.Text = "Số lượng : ";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
				groupBox3.Text = "Nội dung bình luận";
				cb_TTFollowers_Cmt.Text = "Bình luận";
			}
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			File.Delete("settings\\Cache.json");
			interact_sql interact_sql2 = new interact_sql();
			JSON_Settings jSON_Settings = new JSON_Settings("Cache");
			jSON_Settings.Add("txt_TenHanhDong", txt_TenHanhDong.Text);
			jSON_Settings.Add("num_TTFollowers_SLMin", num_TTFollowers_SLMin.Value.ToString());
			jSON_Settings.Add("num_TTFollowers_SLMax", num_TTFollowers_SLMax.Value.ToString());
			jSON_Settings.Add("num_TTFollowers_TimeMin", num_TTFollowers_TimeMin.Value.ToString());
			jSON_Settings.Add("num_TTFollowers_TimeMax", num_TTFollowers_TimeMax.Value.ToString());
			jSON_Settings.Add("num_TTFollowers_LikeMin", num_TTFollowers_LikeMin.Value.ToString());
			jSON_Settings.Add("num_TTFollowers_LikeMax", num_TTFollowers_LikeMax.Value.ToString());
			jSON_Settings.Add("num_TTFollowers_CmtMin", num_TTFollowers_CmtMin.Value.ToString());
			jSON_Settings.Add("num_TTFollowers_CmtMax", num_TTFollowers_CmtMax.Value.ToString());
			jSON_Settings.Add("cb_TTFollowers_Like", cb_TTFollowers_Like.Checked.ToString());
			jSON_Settings.Add("cb_TTFollowers_Cmt", cb_TTFollowers_Cmt.Checked.ToString());
			jSON_Settings.Add("rtb_TTFollowers_Cmt", rtb_TTFollowers_Cmt.Text);
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 1;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.TuongTacFollowers));
			label6 = new System.Windows.Forms.Label();
			num_TTFollowers_CmtMax = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			num_TTFollowers_CmtMin = new System.Windows.Forms.NumericUpDown();
			cb_TTFollowers_Cmt = new System.Windows.Forms.CheckBox();
			label4 = new System.Windows.Forms.Label();
			num_TTFollowers_LikeMax = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			num_TTFollowers_LikeMin = new System.Windows.Forms.NumericUpDown();
			cb_TTFollowers_Like = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			num_TTFollowers_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			num_TTFollowers_TimeMin = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_TTFollowers_Cmt = new System.Windows.Forms.RichTextBox();
			label8 = new System.Windows.Forms.Label();
			num_TTFollowers_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_TTFollowers_SLMin = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_CmtMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_CmtMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_LikeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_LikeMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_TimeMin).BeginInit();
			groupBox1.SuspendLayout();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_SLMin).BeginInit();
			SuspendLayout();
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(276, 92);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(29, 15);
			label6.TabIndex = 14;
			label6.Text = "Cmt";
			num_TTFollowers_CmtMax.Location = new System.Drawing.Point(227, 90);
			num_TTFollowers_CmtMax.Name = "num_TTFollowers_CmtMax";
			num_TTFollowers_CmtMax.Size = new System.Drawing.Size(43, 23);
			num_TTFollowers_CmtMax.TabIndex = 13;
			num_TTFollowers_CmtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			num_TTFollowers_CmtMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(196, 92);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(25, 15);
			label7.TabIndex = 12;
			label7.Text = "-->";
			num_TTFollowers_CmtMin.Location = new System.Drawing.Point(147, 90);
			num_TTFollowers_CmtMin.Name = "num_TTFollowers_CmtMin";
			num_TTFollowers_CmtMin.Size = new System.Drawing.Size(43, 23);
			num_TTFollowers_CmtMin.TabIndex = 11;
			num_TTFollowers_CmtMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			cb_TTFollowers_Cmt.AutoSize = true;
			cb_TTFollowers_Cmt.Location = new System.Drawing.Point(19, 90);
			cb_TTFollowers_Cmt.Name = "cb_TTFollowers_Cmt";
			cb_TTFollowers_Cmt.Size = new System.Drawing.Size(79, 19);
			cb_TTFollowers_Cmt.TabIndex = 10;
			cb_TTFollowers_Cmt.Text = "Comment";
			cb_TTFollowers_Cmt.UseVisualStyleBackColor = true;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(276, 55);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(28, 15);
			label4.TabIndex = 9;
			label4.Text = "Like";
			num_TTFollowers_LikeMax.Location = new System.Drawing.Point(227, 53);
			num_TTFollowers_LikeMax.Name = "num_TTFollowers_LikeMax";
			num_TTFollowers_LikeMax.Size = new System.Drawing.Size(43, 23);
			num_TTFollowers_LikeMax.TabIndex = 8;
			num_TTFollowers_LikeMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(196, 55);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(25, 15);
			label5.TabIndex = 7;
			label5.Text = "-->";
			num_TTFollowers_LikeMin.Location = new System.Drawing.Point(147, 53);
			num_TTFollowers_LikeMin.Name = "num_TTFollowers_LikeMin";
			num_TTFollowers_LikeMin.Size = new System.Drawing.Size(43, 23);
			num_TTFollowers_LikeMin.TabIndex = 6;
			num_TTFollowers_LikeMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			cb_TTFollowers_Like.AutoSize = true;
			cb_TTFollowers_Like.Location = new System.Drawing.Point(19, 53);
			cb_TTFollowers_Like.Name = "cb_TTFollowers_Like";
			cb_TTFollowers_Like.Size = new System.Drawing.Size(47, 19);
			cb_TTFollowers_Like.TabIndex = 5;
			cb_TTFollowers_Like.Text = "Like";
			cb_TTFollowers_Like.UseVisualStyleBackColor = true;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(276, 20);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 4;
			label3.Text = "( s )";
			num_TTFollowers_TimeMax.Location = new System.Drawing.Point(227, 18);
			num_TTFollowers_TimeMax.Name = "num_TTFollowers_TimeMax";
			num_TTFollowers_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_TTFollowers_TimeMax.TabIndex = 3;
			num_TTFollowers_TimeMax.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(196, 20);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 2;
			label2.Text = "-->";
			num_TTFollowers_TimeMin.Location = new System.Drawing.Point(147, 18);
			num_TTFollowers_TimeMin.Name = "num_TTFollowers_TimeMin";
			num_TTFollowers_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_TTFollowers_TimeMin.TabIndex = 1;
			num_TTFollowers_TimeMin.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 20);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(119, 15);
			label1.TabIndex = 0;
			label1.Text = "Scroll time /Interact: ";
			groupBox1.Controls.Add(groupBox3);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(num_TTFollowers_CmtMax);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(num_TTFollowers_CmtMin);
			groupBox1.Controls.Add(cb_TTFollowers_Cmt);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(num_TTFollowers_LikeMax);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(num_TTFollowers_LikeMin);
			groupBox1.Controls.Add(cb_TTFollowers_Like);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(num_TTFollowers_TimeMax);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(num_TTFollowers_TimeMin);
			groupBox1.Controls.Add(label1);
			groupBox1.Location = new System.Drawing.Point(12, 78);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(329, 305);
			groupBox1.TabIndex = 73;
			groupBox1.TabStop = false;
			groupBox1.Text = "Interactive configuration /User";
			groupBox3.Controls.Add(rtb_TTFollowers_Cmt);
			groupBox3.Location = new System.Drawing.Point(20, 119);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(286, 169);
			groupBox3.TabIndex = 161;
			groupBox3.TabStop = false;
			groupBox3.Text = "Comment content : ";
			rtb_TTFollowers_Cmt.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_TTFollowers_Cmt.Location = new System.Drawing.Point(3, 19);
			rtb_TTFollowers_Cmt.Name = "rtb_TTFollowers_Cmt";
			rtb_TTFollowers_Cmt.Size = new System.Drawing.Size(280, 147);
			rtb_TTFollowers_Cmt.TabIndex = 0;
			rtb_TTFollowers_Cmt.Text = "";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(288, 48);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(30, 15);
			label8.TabIndex = 119;
			label8.Text = "User";
			num_TTFollowers_SLMax.Location = new System.Drawing.Point(239, 46);
			num_TTFollowers_SLMax.Name = "num_TTFollowers_SLMax";
			num_TTFollowers_SLMax.Size = new System.Drawing.Size(43, 23);
			num_TTFollowers_SLMax.TabIndex = 118;
			num_TTFollowers_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(208, 48);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 117;
			label9.Text = "-->";
			num_TTFollowers_SLMin.Location = new System.Drawing.Point(159, 46);
			num_TTFollowers_SLMin.Name = "num_TTFollowers_SLMin";
			num_TTFollowers_SLMin.Size = new System.Drawing.Size(43, 23);
			num_TTFollowers_SLMin.TabIndex = 116;
			num_TTFollowers_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(28, 48);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(59, 15);
			label10.TabIndex = 115;
			label10.Text = "Quantity :";
			txt_TenHanhDong.Location = new System.Drawing.Point(159, 12);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(155, 23);
			txt_TenHanhDong.TabIndex = 164;
			txt_TenHanhDong.Text = "Interactive Followers";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(28, 15);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 163;
			label11.Text = "Action name :";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(186, 396);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 274;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(82, 396);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 273;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(353, 437);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(label8);
			base.Controls.Add(num_TTFollowers_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(groupBox1);
			base.Controls.Add(num_TTFollowers_SLMin);
			base.Controls.Add(label10);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "TuongTacFollowers";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Interactive Followers";
			base.Load += new System.EventHandler(TuongTacFollowers_Load);
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_CmtMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_CmtMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_LikeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_LikeMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_TimeMin).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTFollowers_SLMin).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
