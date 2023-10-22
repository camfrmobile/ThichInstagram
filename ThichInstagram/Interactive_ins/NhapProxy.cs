using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Interactive_ins.Properties;

namespace Interactive_ins
{
	public class NhapProxy : Form
	{
		private int ma;

		private List<ThongTin> thongtin = null;

		private IContainer components = null;

		private ComboBox cbbTypeProxy;

		private Label label3;

		private RichTextBox txtProxy;

		private Label label8;

		private Label lblStatus;

		private Button btnCancel;

		private Button btnAdd;

		private PictureBox pictureBox1;

		private Button btnMinimize;

		private Panel pnlHeader;

		private Label label4;

		private NumericUpDown nudTaiKhoanPerUa;

		private Label label1;

		private Label label2;

		public NhapProxy(int ma, List<ThongTin> thongtin)
		{
			InitializeComponent();
			this.thongtin = thongtin;
			this.ma = ma;
		}

		private void btnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<string> list = new List<string>();
			list = txtProxy.Text?.Split('\n').ToList();
			list?.RemoveAll((string x) => x == "");
			int num = 0;
			foreach (string item in list)
			{
				for (int i = 0; (decimal)i < nudTaiKhoanPerUa.Value; i++)
				{
					if (num == thongtin.Count)
					{
						break;
					}
					if (cbbTypeProxy.SelectedIndex == 0)
					{
						thongtin[num].proxy = "0|" + item;
					}
					else
					{
						thongtin[num].proxy = "1|" + item;
					}
					num++;
				}
			}
			if (ma == 0)
			{
				sQLite._Update_Data(thongtin);
			}
			else if (ma == 1)
			{
				sQLite._Update_Data_FB(thongtin);
			}
			if (num != thongtin.Count)
			{
				MessageBox.Show("Not enough proxies !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			Close();
		}

		private void NhapProxy_Load(object sender, EventArgs e)
		{
			cbbTypeProxy.SelectedIndex = 0;
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label4.Text = "Nhập Proxy";
				lblStatus.Text = "Danh sách Proxy : ";
				label3.Text = "Loại Proxy : ";
				btnAdd.Text = "Lưu";
				btnCancel.Text = "Thoát";
				label2.Text = "User:Pass không dùng cho Reg Ins";
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
			cbbTypeProxy = new System.Windows.Forms.ComboBox();
			label3 = new System.Windows.Forms.Label();
			txtProxy = new System.Windows.Forms.RichTextBox();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			pnlHeader = new System.Windows.Forms.Panel();
			label4 = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			nudTaiKhoanPerUa = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTaiKhoanPerUa).BeginInit();
			SuspendLayout();
			cbbTypeProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbTypeProxy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbTypeProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbTypeProxy.FormattingEnabled = true;
			cbbTypeProxy.Items.AddRange(new object[2] { "HTTP", "Sock5" });
			cbbTypeProxy.Location = new System.Drawing.Point(157, 290);
			cbbTypeProxy.Name = "cbbTypeProxy";
			cbbTypeProxy.Size = new System.Drawing.Size(140, 24);
			cbbTypeProxy.TabIndex = 137;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(31, 293);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(84, 16);
			label3.TabIndex = 131;
			label3.Text = "Proxy Type : ";
			txtProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtProxy.Location = new System.Drawing.Point(34, 65);
			txtProxy.Name = "txtProxy";
			txtProxy.Size = new System.Drawing.Size(409, 181);
			txtProxy.TabIndex = 129;
			txtProxy.Text = "";
			txtProxy.WordWrap = false;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Tahoma", 8.5f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(236, 251);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(203, 14);
			label8.TabIndex = 126;
			label8.Text = "( Host:Port or Host:Port:User:Pass )";
			lblStatus.AutoSize = true;
			lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.Location = new System.Drawing.Point(30, 46);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(71, 16);
			lblStatus.TabIndex = 127;
			lblStatus.Text = "List Proxy :";
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(249, 368);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 125;
			btnCancel.Text = "Close";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(140, 368);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 124;
			btnAdd.Text = "Save";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(label4);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Location = new System.Drawing.Point(2, 2);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(473, 32);
			pnlHeader.TabIndex = 128;
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold);
			label4.ForeColor = System.Drawing.Color.Black;
			label4.Location = new System.Drawing.Point(184, 8);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(93, 16);
			label4.TabIndex = 78;
			label4.Text = "  Write Proxy";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = Interactive_ins.Properties.Resources.instagram__2_;
			pictureBox1.Location = new System.Drawing.Point(4, 1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 77;
			pictureBox1.TabStop = false;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = Interactive_ins.Properties.Resources.icons8_close_window_25px;
			btnMinimize.Location = new System.Drawing.Point(441, 0);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 32);
			btnMinimize.TabIndex = 9;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
			nudTaiKhoanPerUa.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			nudTaiKhoanPerUa.Location = new System.Drawing.Point(156, 330);
			nudTaiKhoanPerUa.Name = "nudTaiKhoanPerUa";
			nudTaiKhoanPerUa.Size = new System.Drawing.Size(69, 23);
			nudTaiKhoanPerUa.TabIndex = 139;
			nudTaiKhoanPerUa.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(30, 332);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(98, 16);
			label1.TabIndex = 138;
			label1.Text = "Account/proxy :";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 8.5f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(243, 269);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(172, 14);
			label2.TabIndex = 140;
			label2.Text = "User:Pass not apply for reg ins";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.ControlLight;
			base.ClientSize = new System.Drawing.Size(477, 412);
			base.Controls.Add(label2);
			base.Controls.Add(nudTaiKhoanPerUa);
			base.Controls.Add(label1);
			base.Controls.Add(cbbTypeProxy);
			base.Controls.Add(label3);
			base.Controls.Add(txtProxy);
			base.Controls.Add(label8);
			base.Controls.Add(lblStatus);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(pnlHeader);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "NhapProxy";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "fAddFile";
			base.Load += new System.EventHandler(NhapProxy_Load);
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTaiKhoanPerUa).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
