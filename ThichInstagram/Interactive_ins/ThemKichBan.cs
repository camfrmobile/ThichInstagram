using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class ThemKichBan : Form
	{
		private IContainer components = null;

		private Label label1;

		private TextBox txt_ThemKichBan;

		private Button button1;

		private Button button2;

		public ThemKichBan()
		{
			InitializeComponent();
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			interact_sql interact_sql2 = new interact_sql();
			if (interact_sql2.Select_Data_KichBan(txt_ThemKichBan.Text).TenKichBan != txt_ThemKichBan.Text)
			{
				interact_sql2.Add_data_KichBan(txt_ThemKichBan.Text);
				Close();
			}
			else
			{
				txt_ThemKichBan.Clear();
				MessageBox.Show("Trùng với tên đã có vui lòng đặt tên khác !");
			}
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ThemKichBan_Load(object sender, EventArgs e)
		{
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label1.Text = "Tên kịch bản : ";
				button2.Text = "Lưu";
				button1.Text = "Thoát";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.ThemKichBan));
			label1 = new System.Windows.Forms.Label();
			txt_ThemKichBan = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(29, 27);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(77, 15);
			label1.TabIndex = 0;
			label1.Text = "Script name :";
			txt_ThemKichBan.Location = new System.Drawing.Point(132, 24);
			txt_ThemKichBan.Name = "txt_ThemKichBan";
			txt_ThemKichBan.Size = new System.Drawing.Size(142, 23);
			txt_ThemKichBan.TabIndex = 1;
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(161, 60);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 272;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(57, 60);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 271;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(305, 100);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_ThemKichBan);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "ThemKichBan";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "More script";
			base.Load += new System.EventHandler(ThemKichBan_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
