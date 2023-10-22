using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Interactive_ins.Properties;

namespace Interactive_ins
{
	public class Setting_CP : Form
	{
		private IContainer components = null;

		private GroupBox groupBox6;

		private Label label3;

		private TextBox txt_PassHotmail;

		private Label label2;

		private TextBox txt_hotmail;

		private Label label1;

		private TextBox txt_domain;

		private Button btn_Cancel;

		private Button btn_OK;

		private Label Lb_WriteProxy;

		private Label label6;

		private Label lb_ChangeIP;

		private Label label4;

		private CheckBox cb_LockAcc;

		public Setting_CP()
		{
			InitializeComponent();
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btn_OK_Click(object sender, EventArgs e)
		{
			JSON_Settings jSON_Settings = new JSON_Settings(Load_file.path_SettingCP);
			jSON_Settings.Add("txt_domain", txt_domain.Text);
			jSON_Settings.Add("txt_hotmail", txt_hotmail.Text);
			jSON_Settings.Add("txt_PassHotmail", txt_PassHotmail.Text);
			jSON_Settings.Add("cb_LockAcc", cb_LockAcc.Checked.ToString());
			Close();
		}

		private void Setting_CP_Load(object sender, EventArgs e)
		{
			JSON_Settings jSON_Settings = new JSON_Settings(Load_file.path_SettingCP);
			try
			{
				txt_domain.Text = jSON_Settings.GetValue("txt_domain");
				txt_hotmail.Text = jSON_Settings.GetValue("txt_hotmail");
				txt_PassHotmail.Text = jSON_Settings.GetValue("txt_PassHotmail");
				cb_LockAcc.Checked = jSON_Settings.GetValueBool("cb_LockAcc");
			}
			catch
			{
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label4.Text = "Đổi IP : ";
				label6.Text = "Nhập Proxy : ";
				cb_LockAcc.Text = "Khóa Acc";
				btn_OK.Text = "Lưu";
				btn_Cancel.Text = "Thoát";
			}
		}

		private void lb_ChangeIP_Click(object sender, EventArgs e)
		{
			CauHinhDoiIP cauHinhDoiIP = new CauHinhDoiIP();
			cauHinhDoiIP.ShowDialog();
		}

		private void Lb_WriteProxy_Click(object sender, EventArgs e)
		{
			SQLite sQLite = new SQLite();
			List<ThongTin> list = sQLite.Select_Data_checkselec(enum_thongtin.checkselec.ToString(), 1.ToString());
			if (list.Count == 0)
			{
				MessageBox.Show("Please select the account to add proxy !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			NhapProxy nhapProxy = new NhapProxy(0, list);
			nhapProxy.ShowDialog();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.Setting_CP));
			groupBox6 = new System.Windows.Forms.GroupBox();
			label3 = new System.Windows.Forms.Label();
			txt_PassHotmail = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txt_hotmail = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			txt_domain = new System.Windows.Forms.TextBox();
			btn_Cancel = new System.Windows.Forms.Button();
			btn_OK = new System.Windows.Forms.Button();
			Lb_WriteProxy = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			lb_ChangeIP = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			cb_LockAcc = new System.Windows.Forms.CheckBox();
			groupBox6.SuspendLayout();
			SuspendLayout();
			groupBox6.Controls.Add(label3);
			groupBox6.Controls.Add(txt_PassHotmail);
			groupBox6.Controls.Add(label2);
			groupBox6.Controls.Add(txt_hotmail);
			groupBox6.Controls.Add(label1);
			groupBox6.Controls.Add(txt_domain);
			groupBox6.Location = new System.Drawing.Point(12, 115);
			groupBox6.Name = "groupBox6";
			groupBox6.Size = new System.Drawing.Size(292, 160);
			groupBox6.TabIndex = 140;
			groupBox6.TabStop = false;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(12, 118);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(39, 15);
			label3.TabIndex = 143;
			label3.Text = "Pass : ";
			txt_PassHotmail.Location = new System.Drawing.Point(84, 114);
			txt_PassHotmail.Name = "txt_PassHotmail";
			txt_PassHotmail.Size = new System.Drawing.Size(180, 23);
			txt_PassHotmail.TabIndex = 142;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(12, 73);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(59, 15);
			label2.TabIndex = 141;
			label2.Text = "Hotmail : ";
			txt_hotmail.Location = new System.Drawing.Point(84, 69);
			txt_hotmail.Name = "txt_hotmail";
			txt_hotmail.Size = new System.Drawing.Size(180, 23);
			txt_hotmail.TabIndex = 140;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 29);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 15);
			label1.TabIndex = 139;
			label1.Text = "Domain : ";
			txt_domain.Location = new System.Drawing.Point(84, 25);
			txt_domain.Name = "txt_domain";
			txt_domain.Size = new System.Drawing.Size(180, 23);
			txt_domain.TabIndex = 138;
			btn_Cancel.BackColor = System.Drawing.Color.Maroon;
			btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btn_Cancel.FlatAppearance.BorderSize = 0;
			btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btn_Cancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btn_Cancel.ForeColor = System.Drawing.Color.White;
			btn_Cancel.Location = new System.Drawing.Point(169, 292);
			btn_Cancel.Name = "btn_Cancel";
			btn_Cancel.Size = new System.Drawing.Size(92, 29);
			btn_Cancel.TabIndex = 142;
			btn_Cancel.Text = "Cancel";
			btn_Cancel.UseVisualStyleBackColor = false;
			btn_Cancel.Click += new System.EventHandler(btn_Cancel_Click);
			btn_OK.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btn_OK.Cursor = System.Windows.Forms.Cursors.Hand;
			btn_OK.FlatAppearance.BorderSize = 0;
			btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btn_OK.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btn_OK.ForeColor = System.Drawing.Color.White;
			btn_OK.Location = new System.Drawing.Point(65, 292);
			btn_OK.Name = "btn_OK";
			btn_OK.Size = new System.Drawing.Size(92, 29);
			btn_OK.TabIndex = 141;
			btn_OK.Text = "Save";
			btn_OK.UseVisualStyleBackColor = false;
			btn_OK.Click += new System.EventHandler(btn_OK_Click);
			Lb_WriteProxy.AutoSize = true;
			Lb_WriteProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			Lb_WriteProxy.Font = new System.Drawing.Font("Segoe UI Semibold", 13f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			Lb_WriteProxy.Image = (System.Drawing.Image)resources.GetObject("Lb_WriteProxy.Image");
			Lb_WriteProxy.Location = new System.Drawing.Point(132, 48);
			Lb_WriteProxy.Name = "Lb_WriteProxy";
			Lb_WriteProxy.Size = new System.Drawing.Size(27, 25);
			Lb_WriteProxy.TabIndex = 191;
			Lb_WriteProxy.Text = "   ";
			Lb_WriteProxy.Click += new System.EventHandler(Lb_WriteProxy_Click);
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(24, 53);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(78, 15);
			label6.TabIndex = 190;
			label6.Text = "Write Proxy : ";
			lb_ChangeIP.AutoSize = true;
			lb_ChangeIP.Cursor = System.Windows.Forms.Cursors.Hand;
			lb_ChangeIP.Font = new System.Drawing.Font("Segoe UI Semibold", 13f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lb_ChangeIP.Image = (System.Drawing.Image)resources.GetObject("lb_ChangeIP.Image");
			lb_ChangeIP.Location = new System.Drawing.Point(132, 12);
			lb_ChangeIP.Name = "lb_ChangeIP";
			lb_ChangeIP.Size = new System.Drawing.Size(27, 25);
			lb_ChangeIP.TabIndex = 189;
			lb_ChangeIP.Text = "   ";
			lb_ChangeIP.Click += new System.EventHandler(lb_ChangeIP_Click);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(24, 17);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(70, 15);
			label4.TabIndex = 188;
			label4.Text = "Change IP : ";
			cb_LockAcc.AutoSize = true;
			cb_LockAcc.Image = Interactive_ins.Properties.Resources._lock;
			cb_LockAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			cb_LockAcc.Location = new System.Drawing.Point(27, 90);
			cb_LockAcc.Name = "cb_LockAcc";
			cb_LockAcc.Size = new System.Drawing.Size(92, 19);
			cb_LockAcc.TabIndex = 192;
			cb_LockAcc.Text = "      Lock Acc";
			cb_LockAcc.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(318, 338);
			base.Controls.Add(cb_LockAcc);
			base.Controls.Add(Lb_WriteProxy);
			base.Controls.Add(label6);
			base.Controls.Add(lb_ChangeIP);
			base.Controls.Add(label4);
			base.Controls.Add(btn_Cancel);
			base.Controls.Add(btn_OK);
			base.Controls.Add(groupBox6);
			Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Setting_CP";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Setting Checkpoin";
			base.Load += new System.EventHandler(Setting_CP_Load);
			groupBox6.ResumeLayout(false);
			groupBox6.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
