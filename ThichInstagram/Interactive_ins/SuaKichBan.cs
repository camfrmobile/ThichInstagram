using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class SuaKichBan : Form
	{
		private string ID_KichBan = "";

		private IContainer components = null;

		private TextBox txt_SuaKichBan;

		private Label label1;

		private Button button1;

		private Button button2;

		public SuaKichBan()
		{
			InitializeComponent();
		}

		public SuaKichBan(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			interact_sql interact_sql2 = new interact_sql();
			if (interact_sql2.Select_Data_KichBan(txt_SuaKichBan.Text) != null)
			{
				interact_sql2.Update_Data_KichBan(txt_SuaKichBan.Text, ID_KichBan);
				Close();
			}
			else
			{
				MessageBox.Show("Trùng với tên đã có vui lòng đặt tên khác !");
			}
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void SuaKichBan_Load(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.SuaKichBan));
			txt_SuaKichBan = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			SuspendLayout();
			txt_SuaKichBan.Location = new System.Drawing.Point(120, 21);
			txt_SuaKichBan.Name = "txt_SuaKichBan";
			txt_SuaKichBan.Size = new System.Drawing.Size(142, 23);
			txt_SuaKichBan.TabIndex = 74;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(17, 24);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(77, 15);
			label1.TabIndex = 73;
			label1.Text = "Script name :";
			button1.BackColor = System.Drawing.Color.Maroon;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(152, 62);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(92, 29);
			button1.TabIndex = 270;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(btn_Cancel_Click);
			button2.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Location = new System.Drawing.Point(48, 62);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(92, 29);
			button2.TabIndex = 269;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(btn_ok_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(282, 101);
			base.Controls.Add(button1);
			base.Controls.Add(button2);
			base.Controls.Add(txt_SuaKichBan);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "SuaKichBan";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Edit script";
			base.Load += new System.EventHandler(SuaKichBan_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
