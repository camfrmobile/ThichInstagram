using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Interactive_ins.Properties;

namespace Interactive_ins
{
	public class CauHinhHienThi : Form
	{
		private IContainer components = null;

		private PictureBox pictureBox1;

		private Button btnMinimize;

		private Panel pnlHeader;

		private Label label2;

		private Label label1;

		private CheckBox cb_avatar;

		private CheckBox cb_Post;

		private CheckBox cb_tinhtrang;

		private CheckBox cb_proxy;

		private CheckBox cb_PassMail;

		private CheckBox cb_Following;

		private CheckBox cb_mail;

		private CheckBox cb_Followers;

		private CheckBox cb_Cookie;

		private CheckBox cb_fullname;

		private Button btnCancel;

		private Button btnAdd;

		private CheckBox cb_ID;

		private CheckBox cb_2FA;

		private CheckBox cb_CheckPoin;

		public CauHinhHienThi()
		{
			InitializeComponent();
		}

		private void btnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			JSON_Settings jSON_Settings = new JSON_Settings(Load_file.path_Cauhinhhienthi);
			jSON_Settings.Add("cb_fullname", cb_fullname.Checked.ToString());
			jSON_Settings.Add("cb_ID", cb_ID.Checked.ToString());
			jSON_Settings.Add("cb_PassMail", cb_PassMail.Checked.ToString());
			jSON_Settings.Add("cb_Cookie", cb_Cookie.Checked.ToString());
			jSON_Settings.Add("cb_mail", cb_mail.Checked.ToString());
			jSON_Settings.Add("cb_proxy", cb_proxy.Checked.ToString());
			jSON_Settings.Add("cb_Followers", cb_Followers.Checked.ToString());
			jSON_Settings.Add("cb_Following", cb_Following.Checked.ToString());
			jSON_Settings.Add("cb_tinhtrang", cb_tinhtrang.Checked.ToString());
			jSON_Settings.Add("cb_avatar", cb_avatar.Checked.ToString());
			jSON_Settings.Add("cb_Post", cb_Post.Checked.ToString());
			jSON_Settings.Add("cb_2FA", cb_2FA.Checked.ToString());
			jSON_Settings.Add("cb_CheckPoin", cb_CheckPoin.Checked.ToString());
			Close();
		}

		private void CauHinhHienThi_Load(object sender, EventArgs e)
		{
			JSON_Settings jSON_Settings = new JSON_Settings(Load_file.path_Cauhinhhienthi);
			try
			{
				cb_fullname.Checked = jSON_Settings.GetValueBool("cb_fullname");
				cb_ID.Checked = jSON_Settings.GetValueBool("cb_ID");
				cb_PassMail.Checked = jSON_Settings.GetValueBool("cb_PassMail");
				cb_Cookie.Checked = jSON_Settings.GetValueBool("cb_Cookie");
				cb_mail.Checked = jSON_Settings.GetValueBool("cb_mail");
				cb_proxy.Checked = jSON_Settings.GetValueBool("cb_proxy");
				cb_Followers.Checked = jSON_Settings.GetValueBool("cb_Followers");
				cb_Following.Checked = jSON_Settings.GetValueBool("cb_Following");
				cb_tinhtrang.Checked = jSON_Settings.GetValueBool("cb_tinhtrang");
				cb_avatar.Checked = jSON_Settings.GetValueBool("cb_avatar");
				cb_Post.Checked = jSON_Settings.GetValueBool("cb_Post");
				cb_2FA.Checked = jSON_Settings.GetValueBool("cb_2FA");
				cb_CheckPoin.Checked = jSON_Settings.GetValueBool("cb_CheckPoin");
			}
			catch
			{
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label2.Text = "Cấu hình hiển thị";
				label1.Text = "Chọn các cột để hiển thị!";
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
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
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			pnlHeader = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			cb_avatar = new System.Windows.Forms.CheckBox();
			cb_Post = new System.Windows.Forms.CheckBox();
			cb_tinhtrang = new System.Windows.Forms.CheckBox();
			cb_proxy = new System.Windows.Forms.CheckBox();
			cb_PassMail = new System.Windows.Forms.CheckBox();
			cb_Following = new System.Windows.Forms.CheckBox();
			cb_mail = new System.Windows.Forms.CheckBox();
			cb_Followers = new System.Windows.Forms.CheckBox();
			cb_Cookie = new System.Windows.Forms.CheckBox();
			cb_fullname = new System.Windows.Forms.CheckBox();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			cb_ID = new System.Windows.Forms.CheckBox();
			cb_2FA = new System.Windows.Forms.CheckBox();
			cb_CheckPoin = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			pnlHeader.SuspendLayout();
			SuspendLayout();
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = Interactive_ins.Properties.Resources.instagram__2_;
			pictureBox1.Location = new System.Drawing.Point(3, 3);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 17;
			pictureBox1.TabStop = false;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = Interactive_ins.Properties.Resources.icons8_close_window_25px;
			btnMinimize.Location = new System.Drawing.Point(348, 0);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 32);
			btnMinimize.TabIndex = 9;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(label2);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Location = new System.Drawing.Point(2, 2);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(380, 32);
			pnlHeader.TabIndex = 25;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold);
			label2.Location = new System.Drawing.Point(119, 8);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(145, 16);
			label2.TabIndex = 18;
			label2.Text = "Display Configuration";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f);
			label1.Location = new System.Drawing.Point(100, 48);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(182, 16);
			label1.TabIndex = 62;
			label1.Text = "Select the columns to display !";
			cb_avatar.AutoSize = true;
			cb_avatar.Checked = true;
			cb_avatar.CheckState = System.Windows.Forms.CheckState.Checked;
			cb_avatar.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_avatar.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_avatar.Location = new System.Drawing.Point(41, 155);
			cb_avatar.Name = "cb_avatar";
			cb_avatar.Size = new System.Drawing.Size(64, 20);
			cb_avatar.TabIndex = 60;
			cb_avatar.Text = "Avatar";
			cb_avatar.UseVisualStyleBackColor = true;
			cb_Post.AutoSize = true;
			cb_Post.Checked = true;
			cb_Post.CheckState = System.Windows.Forms.CheckState.Checked;
			cb_Post.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_Post.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_Post.Location = new System.Drawing.Point(158, 155);
			cb_Post.Name = "cb_Post";
			cb_Post.Size = new System.Drawing.Size(51, 20);
			cb_Post.TabIndex = 59;
			cb_Post.Text = "Post";
			cb_Post.UseVisualStyleBackColor = true;
			cb_tinhtrang.AutoSize = true;
			cb_tinhtrang.Checked = true;
			cb_tinhtrang.CheckState = System.Windows.Forms.CheckState.Checked;
			cb_tinhtrang.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_tinhtrang.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_tinhtrang.Location = new System.Drawing.Point(263, 129);
			cb_tinhtrang.Name = "cb_tinhtrang";
			cb_tinhtrang.Size = new System.Drawing.Size(72, 20);
			cb_tinhtrang.TabIndex = 58;
			cb_tinhtrang.Text = "Live/Die";
			cb_tinhtrang.UseVisualStyleBackColor = true;
			cb_proxy.AutoSize = true;
			cb_proxy.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_proxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_proxy.Location = new System.Drawing.Point(263, 103);
			cb_proxy.Name = "cb_proxy";
			cb_proxy.Size = new System.Drawing.Size(58, 20);
			cb_proxy.TabIndex = 57;
			cb_proxy.Text = "Proxy";
			cb_proxy.UseVisualStyleBackColor = true;
			cb_PassMail.AutoSize = true;
			cb_PassMail.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_PassMail.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_PassMail.Location = new System.Drawing.Point(263, 77);
			cb_PassMail.Name = "cb_PassMail";
			cb_PassMail.Size = new System.Drawing.Size(80, 20);
			cb_PassMail.TabIndex = 56;
			cb_PassMail.Text = "Pass Mail";
			cb_PassMail.UseVisualStyleBackColor = true;
			cb_Following.AutoSize = true;
			cb_Following.Checked = true;
			cb_Following.CheckState = System.Windows.Forms.CheckState.Checked;
			cb_Following.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_Following.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_Following.Location = new System.Drawing.Point(158, 129);
			cb_Following.Name = "cb_Following";
			cb_Following.Size = new System.Drawing.Size(81, 20);
			cb_Following.TabIndex = 55;
			cb_Following.Text = "Following";
			cb_Following.UseVisualStyleBackColor = true;
			cb_mail.AutoSize = true;
			cb_mail.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_mail.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_mail.Location = new System.Drawing.Point(158, 103);
			cb_mail.Name = "cb_mail";
			cb_mail.Size = new System.Drawing.Size(50, 20);
			cb_mail.TabIndex = 54;
			cb_mail.Text = "Mail";
			cb_mail.UseVisualStyleBackColor = true;
			cb_Followers.AutoSize = true;
			cb_Followers.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_Followers.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_Followers.Location = new System.Drawing.Point(41, 129);
			cb_Followers.Name = "cb_Followers";
			cb_Followers.Size = new System.Drawing.Size(82, 20);
			cb_Followers.TabIndex = 53;
			cb_Followers.Text = "Followers";
			cb_Followers.UseVisualStyleBackColor = true;
			cb_Cookie.AutoSize = true;
			cb_Cookie.Checked = true;
			cb_Cookie.CheckState = System.Windows.Forms.CheckState.Checked;
			cb_Cookie.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_Cookie.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_Cookie.Location = new System.Drawing.Point(41, 103);
			cb_Cookie.Name = "cb_Cookie";
			cb_Cookie.Size = new System.Drawing.Size(65, 20);
			cb_Cookie.TabIndex = 52;
			cb_Cookie.Text = "Cookie";
			cb_Cookie.UseVisualStyleBackColor = true;
			cb_fullname.AutoSize = true;
			cb_fullname.Checked = true;
			cb_fullname.CheckState = System.Windows.Forms.CheckState.Checked;
			cb_fullname.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_fullname.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_fullname.Location = new System.Drawing.Point(41, 77);
			cb_fullname.Name = "cb_fullname";
			cb_fullname.Size = new System.Drawing.Size(84, 20);
			cb_fullname.TabIndex = 51;
			cb_fullname.Text = "Full Name";
			cb_fullname.UseVisualStyleBackColor = true;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(201, 216);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 50;
			btnCancel.Text = "Đo\u0301ng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(97, 216);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 49;
			btnAdd.Text = "Lưu";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			cb_ID.AutoSize = true;
			cb_ID.Checked = true;
			cb_ID.CheckState = System.Windows.Forms.CheckState.Checked;
			cb_ID.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_ID.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_ID.Location = new System.Drawing.Point(158, 77);
			cb_ID.Name = "cb_ID";
			cb_ID.Size = new System.Drawing.Size(39, 20);
			cb_ID.TabIndex = 61;
			cb_ID.Text = "ID";
			cb_ID.UseVisualStyleBackColor = true;
			cb_2FA.AutoSize = true;
			cb_2FA.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_2FA.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_2FA.Location = new System.Drawing.Point(263, 155);
			cb_2FA.Name = "cb_2FA";
			cb_2FA.Size = new System.Drawing.Size(49, 20);
			cb_2FA.TabIndex = 63;
			cb_2FA.Text = "2FA";
			cb_2FA.UseVisualStyleBackColor = true;
			cb_CheckPoin.AutoSize = true;
			cb_CheckPoin.Checked = true;
			cb_CheckPoin.CheckState = System.Windows.Forms.CheckState.Checked;
			cb_CheckPoin.Cursor = System.Windows.Forms.Cursors.Hand;
			cb_CheckPoin.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cb_CheckPoin.Location = new System.Drawing.Point(41, 181);
			cb_CheckPoin.Name = "cb_CheckPoin";
			cb_CheckPoin.Size = new System.Drawing.Size(85, 20);
			cb_CheckPoin.TabIndex = 64;
			cb_CheckPoin.Text = "CheckPoin";
			cb_CheckPoin.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(386, 260);
			base.Controls.Add(cb_CheckPoin);
			base.Controls.Add(cb_2FA);
			base.Controls.Add(label1);
			base.Controls.Add(cb_avatar);
			base.Controls.Add(cb_Post);
			base.Controls.Add(cb_tinhtrang);
			base.Controls.Add(cb_proxy);
			base.Controls.Add(cb_PassMail);
			base.Controls.Add(cb_Following);
			base.Controls.Add(cb_mail);
			base.Controls.Add(cb_Followers);
			base.Controls.Add(cb_Cookie);
			base.Controls.Add(cb_fullname);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(cb_ID);
			base.Controls.Add(pnlHeader);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.MaximizeBox = false;
			base.Name = "CauHinhHienThi";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "fAddFile";
			base.Load += new System.EventHandler(CauHinhHienThi_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
