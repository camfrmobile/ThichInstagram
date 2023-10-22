using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class CauHinhLuotStory : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Button btn_ok;

		private Label label3;

		private NumericUpDown num_Story_TimeMax;

		private Label label2;

		private Label label1;

		private NumericUpDown num_Story_TimeMin;

		private Button btn_Cancel;

		private Label label10;

		private Label label8;

		private NumericUpDown num_Story_SLMax;

		private Label label9;

		private NumericUpDown num_Story_SLMin;

		private TextBox txt_TenHanhDong;

		private Label label11;

		public CauHinhLuotStory(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public CauHinhLuotStory(Thongso_HanhDong Thongso_HanhDong)
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
			jSON_Settings.Add("num_Story_SLMin", num_Story_SLMin.Value.ToString());
			jSON_Settings.Add("num_Story_SLMax", num_Story_SLMax.Value.ToString());
			jSON_Settings.Add("num_Story_TimeMin", num_Story_TimeMin.Value.ToString());
			jSON_Settings.Add("num_Story_TimeMax", num_Story_TimeMax.Value.ToString());
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 7;
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

		private void CauHinhLuotStory_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				num_Story_SLMin.Value = jSON_Settings.GetValueInt("num_Story_SLMin");
				num_Story_SLMax.Value = jSON_Settings.GetValueInt("num_Story_SLMax");
				num_Story_TimeMin.Value = jSON_Settings.GetValueInt("num_Story_TimeMin");
				num_Story_TimeMax.Value = jSON_Settings.GetValueInt("num_Story_TimeMax");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label10.Text = "Số lượng : ";
				label1.Text = "Thời gian /Story: ";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.CauHinhLuotStory));
			btn_ok = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			num_Story_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			num_Story_TimeMin = new System.Windows.Forms.NumericUpDown();
			btn_Cancel = new System.Windows.Forms.Button();
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_Story_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_Story_SLMin = new System.Windows.Forms.NumericUpDown();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)num_Story_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Story_TimeMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Story_SLMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Story_SLMin).BeginInit();
			SuspendLayout();
			btn_ok.BackColor = System.Drawing.Color.SlateBlue;
			btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			btn_ok.ForeColor = System.Drawing.SystemColors.ButtonFace;
			btn_ok.Image = (System.Drawing.Image)resources.GetObject("btn_ok.Image");
			btn_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btn_ok.Location = new System.Drawing.Point(71, 121);
			btn_ok.Name = "btn_ok";
			btn_ok.Size = new System.Drawing.Size(75, 36);
			btn_ok.TabIndex = 189;
			btn_ok.Text = "OK";
			btn_ok.UseVisualStyleBackColor = false;
			btn_ok.Click += new System.EventHandler(btn_ok_Click);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(259, 84);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(26, 15);
			label3.TabIndex = 200;
			label3.Text = "( s )";
			num_Story_TimeMax.Location = new System.Drawing.Point(210, 82);
			num_Story_TimeMax.Name = "num_Story_TimeMax";
			num_Story_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_Story_TimeMax.TabIndex = 199;
			num_Story_TimeMax.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(179, 84);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 198;
			label2.Text = "-->";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(22, 84);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(106, 15);
			label1.TabIndex = 196;
			label1.Text = "Scroll time /Story: ";
			num_Story_TimeMin.Location = new System.Drawing.Point(130, 82);
			num_Story_TimeMin.Name = "num_Story_TimeMin";
			num_Story_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_Story_TimeMin.TabIndex = 197;
			num_Story_TimeMin.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			btn_Cancel.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
			btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			btn_Cancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			btn_Cancel.Image = (System.Drawing.Image)resources.GetObject("btn_Cancel.Image");
			btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btn_Cancel.Location = new System.Drawing.Point(179, 121);
			btn_Cancel.Name = "btn_Cancel";
			btn_Cancel.Size = new System.Drawing.Size(75, 36);
			btn_Cancel.TabIndex = 190;
			btn_Cancel.Text = "    Cancel";
			btn_Cancel.UseVisualStyleBackColor = false;
			btn_Cancel.Click += new System.EventHandler(btn_Cancel_Click);
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(22, 52);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(59, 15);
			label10.TabIndex = 191;
			label10.Text = "Quantity :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(259, 52);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(30, 15);
			label8.TabIndex = 195;
			label8.Text = "User";
			num_Story_SLMax.Location = new System.Drawing.Point(210, 50);
			num_Story_SLMax.Name = "num_Story_SLMax";
			num_Story_SLMax.Size = new System.Drawing.Size(43, 23);
			num_Story_SLMax.TabIndex = 194;
			num_Story_SLMax.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(179, 52);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 193;
			label9.Text = "-->";
			num_Story_SLMin.Location = new System.Drawing.Point(130, 50);
			num_Story_SLMin.Name = "num_Story_SLMin";
			num_Story_SLMin.Size = new System.Drawing.Size(43, 23);
			num_Story_SLMin.TabIndex = 192;
			num_Story_SLMin.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			txt_TenHanhDong.Location = new System.Drawing.Point(129, 16);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 202;
			txt_TenHanhDong.Text = "View Story";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(21, 19);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 201;
			label11.Text = "Action name :";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(309, 167);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(btn_ok);
			base.Controls.Add(label3);
			base.Controls.Add(num_Story_TimeMax);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(num_Story_TimeMin);
			base.Controls.Add(btn_Cancel);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(num_Story_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(num_Story_SLMin);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "CauHinhLuotStory";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "View Story";
			base.Load += new System.EventHandler(CauHinhLuotStory_Load);
			((System.ComponentModel.ISupportInitialize)num_Story_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Story_TimeMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Story_SLMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Story_SLMin).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
