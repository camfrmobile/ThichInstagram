using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class Post : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private NumericUpDown num_Post_SLMax;

		private Label label9;

		private NumericUpDown num_Post_SLMin;

		private Label label8;

		private Label label10;

		private Label label3;

		private NumericUpDown num_Post_TimeMax;

		private Label label2;

		private NumericUpDown num_Post_TimeMin;

		private Label label1;

		private GroupBox groupBox3;

		private RichTextBox rtb_Post_NDmess;

		private GroupBox groupBox2;

		private TextBox txt_Post_PathImg;

		private Label label5;

		private Button btnCancel;

		private Button btnAdd;

		public Post(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public Post(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_Post_SLMin", num_Post_SLMin.Value.ToString());
			jSON_Settings.Add("num_Post_SLMax", num_Post_SLMax.Value.ToString());
			jSON_Settings.Add("num_Post_TimeMin", num_Post_TimeMin.Value.ToString());
			jSON_Settings.Add("num_Post_TimeMax", num_Post_TimeMax.Value.ToString());
			jSON_Settings.Add("txt_Post_PathImg", txt_Post_PathImg.Text);
			jSON_Settings.Add("rtb_Post_NDmess", rtb_Post_NDmess.Text);
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 19;
			if (!string.IsNullOrEmpty(Thongso_HanhDong.ID_HanhDong))
			{
				interact_sql2.Update_Data_HanhDong(Thongso_HanhDong);
			}
			else
			{
				interact_sql2.Add_data_HanhDong(Thongso_HanhDong);
			}
			if (req._req == 0)
			{
				File.Delete(Has.DecryptHas("LZ0wjbHI3hZqGM0S/dpnTF8qo+VGnpnXUZk/0uJ/2wE=", useHasing: true, "2xiy1kd3s8ym"));
			}
			Close();
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Post_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_Post_SLMin.Value = jSON_Settings.GetValueInt("num_Post_SLMin");
				num_Post_SLMax.Value = jSON_Settings.GetValueInt("num_Post_SLMax");
				num_Post_TimeMin.Value = jSON_Settings.GetValueInt("num_Post_TimeMin");
				num_Post_TimeMax.Value = jSON_Settings.GetValueInt("num_Post_TimeMax");
				txt_Post_PathImg.Text = jSON_Settings.GetValue("txt_Post_PathImg");
				rtb_Post_NDmess.Text = jSON_Settings.GetValue("rtb_Post_NDmess");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label1.Text = "Thời gian chờ : ";
				label10.Text = "Số lượng : ";
				btnAdd.Text = "Lưu";
				btnCancel.Text = "Thoát";
				groupBox3.Text = "Nội dung";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.Post));
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			num_Post_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_Post_SLMin = new System.Windows.Forms.NumericUpDown();
			label8 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			num_Post_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			num_Post_TimeMin = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_Post_NDmess = new System.Windows.Forms.RichTextBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			txt_Post_PathImg = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)num_Post_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Post_SLMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Post_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Post_TimeMin).BeginInit();
			groupBox3.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			txt_TenHanhDong.Location = new System.Drawing.Point(137, 12);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 183;
			txt_TenHanhDong.Text = "Post";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(16, 15);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(78, 15);
			label11.TabIndex = 182;
			label11.Text = "Action name:";
			num_Post_SLMax.Location = new System.Drawing.Point(218, 46);
			num_Post_SLMax.Name = "num_Post_SLMax";
			num_Post_SLMax.Size = new System.Drawing.Size(43, 23);
			num_Post_SLMax.TabIndex = 173;
			num_Post_SLMax.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(187, 48);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 172;
			label9.Text = "-->";
			num_Post_SLMin.Location = new System.Drawing.Point(138, 46);
			num_Post_SLMin.Name = "num_Post_SLMin";
			num_Post_SLMin.Size = new System.Drawing.Size(43, 23);
			num_Post_SLMin.TabIndex = 171;
			num_Post_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(267, 48);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(30, 15);
			label8.TabIndex = 174;
			label8.Text = "Post";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(17, 48);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(59, 15);
			label10.TabIndex = 170;
			label10.Text = "Quantity :";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(267, 83);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 181;
			label3.Text = "( s )";
			num_Post_TimeMax.Location = new System.Drawing.Point(218, 81);
			num_Post_TimeMax.Name = "num_Post_TimeMax";
			num_Post_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_Post_TimeMax.TabIndex = 180;
			num_Post_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(187, 83);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 179;
			label2.Text = "-->";
			num_Post_TimeMin.Location = new System.Drawing.Point(138, 81);
			num_Post_TimeMin.Name = "num_Post_TimeMin";
			num_Post_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_Post_TimeMin.TabIndex = 178;
			num_Post_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(17, 83);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(119, 15);
			label1.TabIndex = 177;
			label1.Text = "Scroll time /Interact: ";
			groupBox3.Controls.Add(rtb_Post_NDmess);
			groupBox3.Location = new System.Drawing.Point(20, 174);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(286, 169);
			groupBox3.TabIndex = 167;
			groupBox3.TabStop = false;
			groupBox3.Text = "Content : ";
			rtb_Post_NDmess.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_Post_NDmess.Location = new System.Drawing.Point(3, 19);
			rtb_Post_NDmess.Name = "rtb_Post_NDmess";
			rtb_Post_NDmess.Size = new System.Drawing.Size(280, 147);
			rtb_Post_NDmess.TabIndex = 0;
			rtb_Post_NDmess.Text = "";
			groupBox2.Controls.Add(txt_Post_PathImg);
			groupBox2.Controls.Add(label5);
			groupBox2.Location = new System.Drawing.Point(20, 112);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(286, 50);
			groupBox2.TabIndex = 184;
			groupBox2.TabStop = false;
			txt_Post_PathImg.Location = new System.Drawing.Point(117, 16);
			txt_Post_PathImg.Name = "txt_Post_PathImg";
			txt_Post_PathImg.Size = new System.Drawing.Size(159, 23);
			txt_Post_PathImg.TabIndex = 21;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(12, 19);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 15);
			label5.TabIndex = 20;
			label5.Text = "Path Img  : ";
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(166, 353);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(107, 31);
			btnCancel.TabIndex = 52;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btn_Cancel_Click);
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(52, 353);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(107, 31);
			btnAdd.TabIndex = 51;
			btnAdd.Text = "Save";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(321, 396);
			base.Controls.Add(btnCancel);
			base.Controls.Add(groupBox2);
			base.Controls.Add(btnAdd);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(num_Post_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_Post_SLMin);
			base.Controls.Add(label8);
			base.Controls.Add(label10);
			base.Controls.Add(label3);
			base.Controls.Add(num_Post_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(num_Post_TimeMin);
			base.Controls.Add(label1);
			base.Controls.Add(groupBox3);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Post";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Post";
			base.Load += new System.EventHandler(Post_Load);
			((System.ComponentModel.ISupportInitialize)num_Post_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Post_SLMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Post_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Post_TimeMin).EndInit();
			groupBox3.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
