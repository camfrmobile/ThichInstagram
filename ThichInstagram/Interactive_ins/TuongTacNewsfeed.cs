using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class TuongTacNewsfeed : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private GroupBox groupBox1;

		private Label label1;

		private NumericUpDown num_TTNewsfeed_TimeMin;

		private Label label3;

		private NumericUpDown num_TTNewsfeed_TimeMax;

		private Label label2;

		private Label label6;

		private NumericUpDown num_TTNewsfeed_CmtMax;

		private Label label7;

		private NumericUpDown num_TTNewsfeed_CmtMin;

		private CheckBox cb_TTNewsfeed_Cmt;

		private Label label4;

		private NumericUpDown num_TTNewsfeed_LikeMax;

		private Label label5;

		private NumericUpDown num_TTNewsfeed_LikeMin;

		private CheckBox cb_TTNewsfeed_Like;

		private GroupBox groupBox3;

		private RichTextBox rtb_TTNewsfeed_Cmt;

		private TextBox txt_TenHanhDong;

		private Label label8;

		private Button button1;

		private Button button2;

		public TuongTacNewsfeed(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public TuongTacNewsfeed(Thongso_HanhDong Thongso_HanhDong)
		{
			InitializeComponent();
			this.Thongso_HanhDong = Thongso_HanhDong;
		}

		private void btn_okTT_Click(object sender, EventArgs e)
		{
			File.Delete("settings\\Cache.json");
			interact_sql interact_sql2 = new interact_sql();
			JSON_Settings jSON_Settings = new JSON_Settings("Cache");
			jSON_Settings.Add("txt_TenHanhDong", txt_TenHanhDong.Text);
			jSON_Settings.Add("num_TTNewsfeed_TimeMin", num_TTNewsfeed_TimeMin.Value.ToString());
			jSON_Settings.Add("num_TTNewsfeed_TimeMax", num_TTNewsfeed_TimeMax.Value.ToString());
			jSON_Settings.Add("num_TTNewsfeed_LikeMin", num_TTNewsfeed_LikeMin.Value.ToString());
			jSON_Settings.Add("num_TTNewsfeed_LikeMax", num_TTNewsfeed_LikeMax.Value.ToString());
			jSON_Settings.Add("num_TTNewsfeed_CmtMin", num_TTNewsfeed_CmtMin.Value.ToString());
			jSON_Settings.Add("num_TTNewsfeed_CmtMax", num_TTNewsfeed_CmtMax.Value.ToString());
			jSON_Settings.Add("cb_TTNewsfeed_Like", cb_TTNewsfeed_Like.Checked.ToString());
			jSON_Settings.Add("cb_TTNewsfeed_Cmt", cb_TTNewsfeed_Cmt.Checked.ToString());
			jSON_Settings.Add("rtb_TTNewsfeed_Cmt", rtb_TTNewsfeed_Cmt.Text);
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 0;
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

		private void TuongTacNewsfeed_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_TTNewsfeed_TimeMin.Value = jSON_Settings.GetValueInt("num_TTNewsfeed_TimeMin");
				num_TTNewsfeed_TimeMax.Value = jSON_Settings.GetValueInt("num_TTNewsfeed_TimeMax");
				num_TTNewsfeed_LikeMin.Value = jSON_Settings.GetValueInt("num_TTNewsfeed_LikeMin");
				num_TTNewsfeed_LikeMax.Value = jSON_Settings.GetValueInt("num_TTNewsfeed_LikeMax");
				num_TTNewsfeed_CmtMin.Value = jSON_Settings.GetValueInt("num_TTNewsfeed_CmtMin");
				num_TTNewsfeed_CmtMax.Value = jSON_Settings.GetValueInt("num_TTNewsfeed_CmtMax");
				cb_TTNewsfeed_Like.Checked = jSON_Settings.GetValueBool("cb_TTNewsfeed_Like");
				cb_TTNewsfeed_Cmt.Checked = jSON_Settings.GetValueBool("cb_TTNewsfeed_Cmt");
				rtb_TTNewsfeed_Cmt.Text = jSON_Settings.GetValue("rtb_TTNewsfeed_Cmt");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label8.Text = "Tên hành động : ";
				label1.Text = "Thời gian lướt  : ";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
				groupBox3.Text = "Nội dung bình luận";
			}
		}

		private void btn_CancelTT_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.TuongTacNewsfeed));
			groupBox1 = new System.Windows.Forms.GroupBox();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_TTNewsfeed_Cmt = new System.Windows.Forms.RichTextBox();
			label6 = new System.Windows.Forms.Label();
			num_TTNewsfeed_CmtMax = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			num_TTNewsfeed_CmtMin = new System.Windows.Forms.NumericUpDown();
			cb_TTNewsfeed_Cmt = new System.Windows.Forms.CheckBox();
			label4 = new System.Windows.Forms.Label();
			num_TTNewsfeed_LikeMax = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			num_TTNewsfeed_LikeMin = new System.Windows.Forms.NumericUpDown();
			cb_TTNewsfeed_Like = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			num_TTNewsfeed_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			num_TTNewsfeed_TimeMin = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			groupBox1.SuspendLayout();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_TTNewsfeed_CmtMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTNewsfeed_CmtMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTNewsfeed_LikeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTNewsfeed_LikeMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTNewsfeed_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_TTNewsfeed_TimeMin).BeginInit();
			SuspendLayout();
			groupBox1.Controls.Add(txt_TenHanhDong);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(groupBox3);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(num_TTNewsfeed_CmtMax);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(num_TTNewsfeed_CmtMin);
			groupBox1.Controls.Add(cb_TTNewsfeed_Cmt);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(num_TTNewsfeed_LikeMax);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(num_TTNewsfeed_LikeMin);
			groupBox1.Controls.Add(cb_TTNewsfeed_Like);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(num_TTNewsfeed_TimeMax);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(num_TTNewsfeed_TimeMin);
			groupBox1.Controls.Add(label1);
			groupBox1.Location = new System.Drawing.Point(12, 7);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(329, 336);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			txt_TenHanhDong.Location = new System.Drawing.Point(147, 16);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(155, 23);
			txt_TenHanhDong.TabIndex = 162;
			txt_TenHanhDong.Text = "Interactive Newsfeed";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(16, 19);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(81, 15);
			label8.TabIndex = 161;
			label8.Text = "Action name :";
			groupBox3.Controls.Add(rtb_TTNewsfeed_Cmt);
			groupBox3.Location = new System.Drawing.Point(19, 150);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(286, 169);
			groupBox3.TabIndex = 160;
			groupBox3.TabStop = false;
			groupBox3.Text = "Nội dung comment : ";
			rtb_TTNewsfeed_Cmt.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_TTNewsfeed_Cmt.Location = new System.Drawing.Point(3, 19);
			rtb_TTNewsfeed_Cmt.Name = "rtb_TTNewsfeed_Cmt";
			rtb_TTNewsfeed_Cmt.Size = new System.Drawing.Size(280, 147);
			rtb_TTNewsfeed_Cmt.TabIndex = 0;
			rtb_TTNewsfeed_Cmt.Text = "";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(276, 123);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(29, 15);
			label6.TabIndex = 14;
			label6.Text = "Cmt";
			num_TTNewsfeed_CmtMax.Location = new System.Drawing.Point(227, 121);
			num_TTNewsfeed_CmtMax.Name = "num_TTNewsfeed_CmtMax";
			num_TTNewsfeed_CmtMax.Size = new System.Drawing.Size(43, 23);
			num_TTNewsfeed_CmtMax.TabIndex = 13;
			num_TTNewsfeed_CmtMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(196, 123);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(25, 15);
			label7.TabIndex = 12;
			label7.Text = "-->";
			num_TTNewsfeed_CmtMin.Location = new System.Drawing.Point(147, 121);
			num_TTNewsfeed_CmtMin.Name = "num_TTNewsfeed_CmtMin";
			num_TTNewsfeed_CmtMin.Size = new System.Drawing.Size(43, 23);
			num_TTNewsfeed_CmtMin.TabIndex = 11;
			num_TTNewsfeed_CmtMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			cb_TTNewsfeed_Cmt.AutoSize = true;
			cb_TTNewsfeed_Cmt.Location = new System.Drawing.Point(19, 121);
			cb_TTNewsfeed_Cmt.Name = "cb_TTNewsfeed_Cmt";
			cb_TTNewsfeed_Cmt.Size = new System.Drawing.Size(79, 19);
			cb_TTNewsfeed_Cmt.TabIndex = 10;
			cb_TTNewsfeed_Cmt.Text = "Comment";
			cb_TTNewsfeed_Cmt.UseVisualStyleBackColor = true;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(276, 86);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(28, 15);
			label4.TabIndex = 9;
			label4.Text = "Like";
			num_TTNewsfeed_LikeMax.Location = new System.Drawing.Point(227, 84);
			num_TTNewsfeed_LikeMax.Name = "num_TTNewsfeed_LikeMax";
			num_TTNewsfeed_LikeMax.Size = new System.Drawing.Size(43, 23);
			num_TTNewsfeed_LikeMax.TabIndex = 8;
			num_TTNewsfeed_LikeMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(196, 86);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(25, 15);
			label5.TabIndex = 7;
			label5.Text = "-->";
			num_TTNewsfeed_LikeMin.Location = new System.Drawing.Point(147, 84);
			num_TTNewsfeed_LikeMin.Name = "num_TTNewsfeed_LikeMin";
			num_TTNewsfeed_LikeMin.Size = new System.Drawing.Size(43, 23);
			num_TTNewsfeed_LikeMin.TabIndex = 6;
			num_TTNewsfeed_LikeMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			cb_TTNewsfeed_Like.AutoSize = true;
			cb_TTNewsfeed_Like.Location = new System.Drawing.Point(19, 84);
			cb_TTNewsfeed_Like.Name = "cb_TTNewsfeed_Like";
			cb_TTNewsfeed_Like.Size = new System.Drawing.Size(47, 19);
			cb_TTNewsfeed_Like.TabIndex = 5;
			cb_TTNewsfeed_Like.Text = "Like";
			cb_TTNewsfeed_Like.UseVisualStyleBackColor = true;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(276, 51);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 4;
			label3.Text = "( s )";
			num_TTNewsfeed_TimeMax.Location = new System.Drawing.Point(227, 49);
			num_TTNewsfeed_TimeMax.Name = "num_TTNewsfeed_TimeMax";
			num_TTNewsfeed_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_TTNewsfeed_TimeMax.TabIndex = 3;
			num_TTNewsfeed_TimeMax.Value = new decimal(new int[4] { 20, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(196, 51);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 2;
			label2.Text = "-->";
			num_TTNewsfeed_TimeMin.Location = new System.Drawing.Point(147, 49);
			num_TTNewsfeed_TimeMin.Name = "num_TTNewsfeed_TimeMin";
			num_TTNewsfeed_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_TTNewsfeed_TimeMin.TabIndex = 1;
			num_TTNewsfeed_TimeMin.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 51);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(119, 15);
			label1.TabIndex = 0;
			label1.Text = "Scroll time /Interact: ";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(186, 353);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 278;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_CancelTT_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(82, 353);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 277;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_okTT_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(353, 393);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(groupBox1);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "TuongTacNewsfeed";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Interactive Newsfeed";
			base.Load += new System.EventHandler(TuongTacNewsfeed_Load);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)num_TTNewsfeed_CmtMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTNewsfeed_CmtMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTNewsfeed_LikeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTNewsfeed_LikeMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTNewsfeed_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_TTNewsfeed_TimeMin).EndInit();
			ResumeLayout(false);
		}
	}
}
