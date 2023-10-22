using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class CheckTT : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private Button btnCancel;

		private Button btnAdd;

		public CheckTT(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public CheckTT(Thongso_HanhDong Thongso_HanhDong)
		{
			InitializeComponent();
			this.Thongso_HanhDong = Thongso_HanhDong;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void CheckTT_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.CheckTT));
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			SuspendLayout();
			txt_TenHanhDong.Location = new System.Drawing.Point(120, 21);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 216;
			txt_TenHanhDong.Text = "Follow suggestions ";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(18, 24);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 215;
			label11.Text = "Action name :";
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(166, 67);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 218;
			btnCancel.Text = "Close";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(57, 67);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 217;
			btnAdd.Text = "Save";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(300, 113);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "CheckTT";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "CheckTT";
			base.Load += new System.EventHandler(CheckTT_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
