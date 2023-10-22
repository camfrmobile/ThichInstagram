using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class DichVuIns : Form
	{
		public delegate void send(bool cb_follow, bool cb_postMedia, bool cb_avt, int num_follow, int num_Post, int num_Min_DeleyNext, int num_Max_DeleyNext, int num_Thread, bool rad_SDChrome, bool rad_SDRequest);

		public static string path_data_DichVuIns = "data/Data_DichVuIns.ini";

		public send send_data;

		private IContainer components = null;

		private Label lb_link;

		private Label lb_pathPost;

		private Label lb_IDInss;

		private NumericUpDown num_Post;

		private Label label1;

		private CheckBox cb_postMedia;

		private NumericUpDown num_follow;

		private Label label4;

		private CheckBox cb_follow;

		private Button btn_Cancel;

		private Button btn_ok;

		private GroupBox gr_DichVu;

		private NumericUpDown num_Min_DeleyNext;

		private Label label3;

		private NumericUpDown num_Max_DeleyNext;

		private Label label5;

		private Label label8;

		private Label label7;

		private Label lb_path_avt;

		private CheckBox cb_avt;

		private NumericUpDown num_Thread;

		private Label label9;

		private GroupBox groupBox1;

		private RadioButton rad_SDRequest;

		private RadioButton rad_SDChrome;

		public DichVuIns()
		{
			InitializeComponent();
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void DichVuIns_Load(object sender, EventArgs e)
		{
		}

		private void lb_IDInss_Click(object sender, EventArgs e)
		{
			string path_Follow = API_instagram.path_Follow;
			if (File.Exists(path_Follow))
			{
				Process process = new Process();
				process.StartInfo.FileName = path_Follow;
				process.Start();
			}
		}

		private void lb_pathPost_Click(object sender, EventArgs e)
		{
			string path_img = API_instagram.path_img;
			if (Directory.Exists(path_img))
			{
				Process process = new Process();
				process.StartInfo.FileName = path_img;
				process.Start();
			}
		}

		private void lb_path_avt_Click(object sender, EventArgs e)
		{
			string path_imgAvt = API_instagram.path_imgAvt;
			if (Directory.Exists(path_imgAvt))
			{
				Process process = new Process();
				process.StartInfo.FileName = path_imgAvt;
				process.Start();
			}
		}

		private void lb_link_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.thegioididong.com/game-app/kich-thuoc-anh-tren-instagram-chuan-2021-anh-doc-anh-ngang-1324211#:~:text=Instagram%20th%C6%B0%E1%BB%9Dng%20c%C3%B3%20hai%20t%E1%BB%B7,(%C4%91%E1%BB%91i%20v%E1%BB%9Bi%20%E1%BA%A3nh%20ngang).");
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.DichVuIns));
			lb_link = new System.Windows.Forms.Label();
			lb_pathPost = new System.Windows.Forms.Label();
			lb_IDInss = new System.Windows.Forms.Label();
			num_Post = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			cb_postMedia = new System.Windows.Forms.CheckBox();
			num_follow = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			cb_follow = new System.Windows.Forms.CheckBox();
			btn_Cancel = new System.Windows.Forms.Button();
			btn_ok = new System.Windows.Forms.Button();
			gr_DichVu = new System.Windows.Forms.GroupBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			rad_SDRequest = new System.Windows.Forms.RadioButton();
			rad_SDChrome = new System.Windows.Forms.RadioButton();
			num_Thread = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			num_Max_DeleyNext = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			num_Min_DeleyNext = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			lb_path_avt = new System.Windows.Forms.Label();
			cb_avt = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)num_Post).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_follow).BeginInit();
			gr_DichVu.SuspendLayout();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_Thread).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Max_DeleyNext).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Min_DeleyNext).BeginInit();
			SuspendLayout();
			lb_link.AutoSize = true;
			lb_link.Cursor = System.Windows.Forms.Cursors.Hand;
			lb_link.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
			lb_link.ForeColor = System.Drawing.Color.Blue;
			lb_link.Location = new System.Drawing.Point(340, 115);
			lb_link.Name = "lb_link";
			lb_link.Size = new System.Drawing.Size(29, 15);
			lb_link.TabIndex = 60;
			lb_link.Text = "Link";
			lb_link.Click += new System.EventHandler(lb_link_Click);
			lb_pathPost.AutoSize = true;
			lb_pathPost.Cursor = System.Windows.Forms.Cursors.Hand;
			lb_pathPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lb_pathPost.Image = (System.Drawing.Image)resources.GetObject("lb_pathPost.Image");
			lb_pathPost.Location = new System.Drawing.Point(137, 64);
			lb_pathPost.Name = "lb_pathPost";
			lb_pathPost.Size = new System.Drawing.Size(33, 26);
			lb_pathPost.TabIndex = 56;
			lb_pathPost.Text = "   ";
			lb_pathPost.Click += new System.EventHandler(lb_pathPost_Click);
			lb_IDInss.AutoSize = true;
			lb_IDInss.Cursor = System.Windows.Forms.Cursors.Hand;
			lb_IDInss.Font = new System.Drawing.Font("Microsoft Sans Serif", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lb_IDInss.Image = (System.Drawing.Image)resources.GetObject("lb_IDInss.Image");
			lb_IDInss.Location = new System.Drawing.Point(137, 20);
			lb_IDInss.Name = "lb_IDInss";
			lb_IDInss.Size = new System.Drawing.Size(33, 26);
			lb_IDInss.TabIndex = 55;
			lb_IDInss.Text = "   ";
			lb_IDInss.Click += new System.EventHandler(lb_IDInss_Click);
			num_Post.Location = new System.Drawing.Point(273, 68);
			num_Post.Name = "num_Post";
			num_Post.Size = new System.Drawing.Size(96, 23);
			num_Post.TabIndex = 50;
			num_Post.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.Teal;
			label1.Location = new System.Drawing.Point(171, 71);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(81, 15);
			label1.TabIndex = 49;
			label1.Text = "Số lượng Post";
			cb_postMedia.AutoSize = true;
			cb_postMedia.Checked = true;
			cb_postMedia.CheckState = System.Windows.Forms.CheckState.Checked;
			cb_postMedia.Image = (System.Drawing.Image)resources.GetObject("cb_postMedia.Image");
			cb_postMedia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_postMedia.Location = new System.Drawing.Point(20, 69);
			cb_postMedia.Name = "cb_postMedia";
			cb_postMedia.Size = new System.Drawing.Size(100, 19);
			cb_postMedia.TabIndex = 48;
			cb_postMedia.Text = "     Post Media";
			cb_postMedia.UseVisualStyleBackColor = true;
			num_follow.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			num_follow.Location = new System.Drawing.Point(273, 23);
			num_follow.Name = "num_follow";
			num_follow.Size = new System.Drawing.Size(96, 23);
			num_follow.TabIndex = 45;
			num_follow.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label4.ForeColor = System.Drawing.Color.Teal;
			label4.Location = new System.Drawing.Point(171, 26);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(93, 15);
			label4.TabIndex = 44;
			label4.Text = "Số lượng Follow";
			cb_follow.AutoSize = true;
			cb_follow.Checked = true;
			cb_follow.CheckState = System.Windows.Forms.CheckState.Checked;
			cb_follow.Image = (System.Drawing.Image)resources.GetObject("cb_follow.Image");
			cb_follow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_follow.Location = new System.Drawing.Point(20, 23);
			cb_follow.Name = "cb_follow";
			cb_follow.Size = new System.Drawing.Size(79, 19);
			cb_follow.TabIndex = 0;
			cb_follow.Text = "     Follow ";
			cb_follow.UseVisualStyleBackColor = true;
			btn_Cancel.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
			btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			btn_Cancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			btn_Cancel.Image = (System.Drawing.Image)resources.GetObject("btn_Cancel.Image");
			btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btn_Cancel.Location = new System.Drawing.Point(226, 273);
			btn_Cancel.Name = "btn_Cancel";
			btn_Cancel.Size = new System.Drawing.Size(75, 36);
			btn_Cancel.TabIndex = 58;
			btn_Cancel.Text = "    Cancel";
			btn_Cancel.UseVisualStyleBackColor = false;
			btn_Cancel.Click += new System.EventHandler(btn_Cancel_Click);
			btn_ok.BackColor = System.Drawing.Color.SlateBlue;
			btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			btn_ok.ForeColor = System.Drawing.SystemColors.ButtonFace;
			btn_ok.Image = (System.Drawing.Image)resources.GetObject("btn_ok.Image");
			btn_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btn_ok.Location = new System.Drawing.Point(118, 273);
			btn_ok.Name = "btn_ok";
			btn_ok.Size = new System.Drawing.Size(75, 36);
			btn_ok.TabIndex = 57;
			btn_ok.Text = "OK";
			btn_ok.UseVisualStyleBackColor = false;
			btn_ok.Click += new System.EventHandler(btn_ok_Click);
			gr_DichVu.BackColor = System.Drawing.SystemColors.Control;
			gr_DichVu.Controls.Add(groupBox1);
			gr_DichVu.Controls.Add(num_Thread);
			gr_DichVu.Controls.Add(label9);
			gr_DichVu.Controls.Add(num_Max_DeleyNext);
			gr_DichVu.Controls.Add(label5);
			gr_DichVu.Controls.Add(num_Min_DeleyNext);
			gr_DichVu.Controls.Add(label3);
			gr_DichVu.Controls.Add(lb_link);
			gr_DichVu.Controls.Add(label8);
			gr_DichVu.Controls.Add(label7);
			gr_DichVu.Controls.Add(lb_path_avt);
			gr_DichVu.Controls.Add(lb_pathPost);
			gr_DichVu.Controls.Add(lb_IDInss);
			gr_DichVu.Controls.Add(cb_avt);
			gr_DichVu.Controls.Add(num_Post);
			gr_DichVu.Controls.Add(label1);
			gr_DichVu.Controls.Add(cb_postMedia);
			gr_DichVu.Controls.Add(num_follow);
			gr_DichVu.Controls.Add(label4);
			gr_DichVu.Controls.Add(cb_follow);
			gr_DichVu.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			gr_DichVu.Location = new System.Drawing.Point(12, 12);
			gr_DichVu.Name = "gr_DichVu";
			gr_DichVu.Size = new System.Drawing.Size(386, 255);
			gr_DichVu.TabIndex = 59;
			gr_DichVu.TabStop = false;
			groupBox1.Controls.Add(rad_SDRequest);
			groupBox1.Controls.Add(rad_SDChrome);
			groupBox1.Location = new System.Drawing.Point(20, 139);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(349, 42);
			groupBox1.TabIndex = 80;
			groupBox1.TabStop = false;
			rad_SDRequest.AutoSize = true;
			rad_SDRequest.Checked = true;
			rad_SDRequest.Location = new System.Drawing.Point(206, 16);
			rad_SDRequest.Name = "rad_SDRequest";
			rad_SDRequest.Size = new System.Drawing.Size(115, 19);
			rad_SDRequest.TabIndex = 1;
			rad_SDRequest.TabStop = true;
			rad_SDRequest.Text = "Sử dụng Request";
			rad_SDRequest.UseVisualStyleBackColor = true;
			rad_SDChrome.AutoSize = true;
			rad_SDChrome.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			rad_SDChrome.Location = new System.Drawing.Point(30, 15);
			rad_SDChrome.Name = "rad_SDChrome";
			rad_SDChrome.Size = new System.Drawing.Size(118, 19);
			rad_SDChrome.TabIndex = 0;
			rad_SDChrome.Text = "Sử dụng Chrome ";
			rad_SDChrome.UseVisualStyleBackColor = true;
			num_Thread.Location = new System.Drawing.Point(191, 225);
			num_Thread.Name = "num_Thread";
			num_Thread.Size = new System.Drawing.Size(37, 23);
			num_Thread.TabIndex = 79;
			num_Thread.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label9.AutoSize = true;
			label9.ForeColor = System.Drawing.Color.DarkBlue;
			label9.Location = new System.Drawing.Point(17, 227);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(156, 15);
			label9.TabIndex = 78;
			label9.Text = "Số tài khoản chạy cùng lúc: ";
			num_Max_DeleyNext.Location = new System.Drawing.Point(267, 187);
			num_Max_DeleyNext.Name = "num_Max_DeleyNext";
			num_Max_DeleyNext.Size = new System.Drawing.Size(37, 23);
			num_Max_DeleyNext.TabIndex = 64;
			num_Max_DeleyNext.Value = new decimal(new int[4] { 60, 0, 0, 0 });
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(234, 189);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(27, 15);
			label5.TabIndex = 63;
			label5.Text = "đến";
			num_Min_DeleyNext.Location = new System.Drawing.Point(191, 187);
			num_Min_DeleyNext.Name = "num_Min_DeleyNext";
			num_Min_DeleyNext.Size = new System.Drawing.Size(37, 23);
			num_Min_DeleyNext.TabIndex = 62;
			num_Min_DeleyNext.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.DarkBlue;
			label3.Location = new System.Drawing.Point(17, 189);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(176, 15);
			label3.TabIndex = 61;
			label3.Text = "Thời gian Delay chuyển acc từ:  ";
			label8.AutoSize = true;
			label8.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			label8.Location = new System.Drawing.Point(211, 115);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(130, 15);
			label8.TabIndex = 59;
			label8.Text = "Hình ảnh đúng tỷ lệ ins";
			label7.AutoSize = true;
			label7.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			label7.Location = new System.Drawing.Point(171, 115);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(43, 15);
			label7.TabIndex = 58;
			label7.Text = "Chú ý: ";
			lb_path_avt.AutoSize = true;
			lb_path_avt.Cursor = System.Windows.Forms.Cursors.Hand;
			lb_path_avt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lb_path_avt.Image = (System.Drawing.Image)resources.GetObject("lb_path_avt.Image");
			lb_path_avt.Location = new System.Drawing.Point(137, 107);
			lb_path_avt.Name = "lb_path_avt";
			lb_path_avt.Size = new System.Drawing.Size(33, 26);
			lb_path_avt.TabIndex = 57;
			lb_path_avt.Text = "   ";
			lb_path_avt.Click += new System.EventHandler(lb_path_avt_Click);
			cb_avt.AutoSize = true;
			cb_avt.Checked = true;
			cb_avt.CheckState = System.Windows.Forms.CheckState.Checked;
			cb_avt.Image = (System.Drawing.Image)resources.GetObject("cb_avt.Image");
			cb_avt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_avt.Location = new System.Drawing.Point(20, 114);
			cb_avt.Name = "cb_avt";
			cb_avt.Size = new System.Drawing.Size(75, 19);
			cb_avt.TabIndex = 53;
			cb_avt.Text = "     Avatar";
			cb_avt.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			base.ClientSize = new System.Drawing.Size(410, 312);
			base.Controls.Add(btn_Cancel);
			base.Controls.Add(btn_ok);
			base.Controls.Add(gr_DichVu);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "DichVuIns";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Dịch vụ Ins";
			base.Load += new System.EventHandler(DichVuIns_Load);
			((System.ComponentModel.ISupportInitialize)num_Post).EndInit();
			((System.ComponentModel.ISupportInitialize)num_follow).EndInit();
			gr_DichVu.ResumeLayout(false);
			gr_DichVu.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)num_Thread).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Max_DeleyNext).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Min_DeleyNext).EndInit();
			ResumeLayout(false);
		}
	}
}
