using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DeviceId;

namespace Interactive_ins
{
	public class Key : Form
	{
		private string import = "";

		private IContainer components = null;

		private Button button1;

		private Label label4;

		private TextBox textBox1;

		private Label label3;

		private Label lb_link;

		private Button btn_Go;

		private Label label1;

		private TextBox txt_Key;

		public Key()
		{
			InitializeComponent();
		}

		private void lb_link_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.facebook.com/nhat.ghost/");
		}

		private void btn_Go_Click(object sender, EventArgs e)
		{
			U_ke.ke_U = new DeviceIdBuilder().AddMachineName().AddProcessorId().AddMotherboardSerialNumber()
				.AddSystemDriveSerialNumber()
				.ToString();
			import = (tt_kk._key = txt_Key.Text);
			if (GClass1.method1(import) == 0)
			{
				Hide();
				iniFile iniFile2 = new iniFile("data/Key");
				iniFile2.Write("", "Key", import);
				Form1 form = new Form1();
				form.ShowDialog();
				Close();
			}
		}

		private void Key_Load(object sender, EventArgs e)
		{
			textBox1.Text = "2Sl8F4BfwIGOxZmbfo";
			if (!File.Exists("data/Key"))
			{
				return;
			}
			iniFile obj = new iniFile("data/Key");
			req._req++;
			string value = (tt_kk._key = obj.Read("", "Key"));
			if (!string.IsNullOrEmpty(value))
			{
				U_ke.ke_U = "Uyennguyen";
				switch (GClass1.method1(value))
				{
				case 0:
					Hide();
					new Form1().ShowDialog();
					import = value;
					Close();
					break;
				case 2:
					File.Delete("data/Key");
					break;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(new DeviceIdBuilder().AddMachineName().AddProcessorId().AddMotherboardSerialNumber()
				.AddSystemDriveSerialNumber()
				.ToString()
				.Remove(1, 25));
		}

		private void lb_link_Click_1(object sender, EventArgs e)
		{
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
			button1 = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			lb_link = new System.Windows.Forms.Label();
			btn_Go = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			txt_Key = new System.Windows.Forms.TextBox();
			SuspendLayout();
			button1.ForeColor = System.Drawing.Color.DarkBlue;
			button1.Location = new System.Drawing.Point(474, 14);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(52, 31);
			button1.TabIndex = 104;
			button1.Text = "Copy";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			label4.AutoSize = true;
			label4.ForeColor = System.Drawing.Color.DarkBlue;
			label4.Location = new System.Drawing.Point(11, 23);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(84, 13);
			label4.TabIndex = 103;
			label4.Text = "Machine code : ";
			textBox1.Location = new System.Drawing.Point(102, 19);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(354, 20);
			textBox1.TabIndex = 102;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.Maroon;
			label3.Location = new System.Drawing.Point(133, 90);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(109, 15);
			label3.TabIndex = 100;
			label3.Text = "Liên hệ ( Contact ) :";
			lb_link.AutoSize = true;
			lb_link.Cursor = System.Windows.Forms.Cursors.Hand;
			lb_link.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
			lb_link.ForeColor = System.Drawing.Color.Blue;
			lb_link.Location = new System.Drawing.Point(265, 90);
			lb_link.Name = "lb_link";
			lb_link.Size = new System.Drawing.Size(29, 15);
			lb_link.TabIndex = 99;
			lb_link.Text = "Link";
			lb_link.Click += new System.EventHandler(lb_link_Click_1);
			btn_Go.ForeColor = System.Drawing.Color.DarkBlue;
			btn_Go.Location = new System.Drawing.Point(474, 56);
			btn_Go.Name = "btn_Go";
			btn_Go.Size = new System.Drawing.Size(52, 31);
			btn_Go.TabIndex = 98;
			btn_Go.Text = "Go!";
			btn_Go.UseVisualStyleBackColor = true;
			btn_Go.Click += new System.EventHandler(btn_Go_Click);
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.Color.DarkBlue;
			label1.Location = new System.Drawing.Point(11, 62);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(62, 13);
			label1.TabIndex = 97;
			label1.Text = "Write Key : ";
			txt_Key.Location = new System.Drawing.Point(102, 58);
			txt_Key.Name = "txt_Key";
			txt_Key.Size = new System.Drawing.Size(354, 20);
			txt_Key.TabIndex = 96;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(537, 119);
			base.Controls.Add(button1);
			base.Controls.Add(label4);
			base.Controls.Add(textBox1);
			base.Controls.Add(label3);
			base.Controls.Add(lb_link);
			base.Controls.Add(btn_Go);
			base.Controls.Add(label1);
			base.Controls.Add(txt_Key);
			base.Name = "Key";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Key";
			base.Load += new System.EventHandler(Key_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
