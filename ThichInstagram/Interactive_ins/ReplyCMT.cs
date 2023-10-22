using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class ReplyCMT : Form
	{
		private string ID_KichBan = null;

		private Thongso_HanhDong Thongso_HanhDong = null;

		private string Json_CauHinh = "";

		private IContainer components = null;

		private Button btnCancel;

		private Button btnAdd;

		private TextBox txt_TenHanhDong;

		private Label label11;

		private GroupBox groupBox3;

		private RichTextBox rtb_Spam_NDcmt;

		private Label label10;

		private TextBox txt_LinkPost;

		private NumericUpDown num_Spam_SLMin;

		private Label label1;

		private Label label8;

		private NumericUpDown num_Spam_SLMax;

		private Label label9;

		public ReplyCMT(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		public ReplyCMT(Thongso_HanhDong Thongso_HanhDong)
		{
			InitializeComponent();
			this.Thongso_HanhDong = Thongso_HanhDong;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			File.Delete("settings\\Cache.json");
			interact_sql interact_sql2 = new interact_sql();
			JSON_Settings jSON_Settings = new JSON_Settings("Cache");
			jSON_Settings.Add("txt_TenHanhDong", txt_TenHanhDong.Text);
			jSON_Settings.Add("txt_LinkPost", txt_LinkPost.Text);
			jSON_Settings.Add("num_Spam_SLMin", num_Spam_SLMin.Value.ToString());
			jSON_Settings.Add("num_Spam_SLMax", num_Spam_SLMax.Value.ToString());
			jSON_Settings.Add("rtb_Spam_NDcmt", rtb_Spam_NDcmt.Text);
			Json_CauHinh = File.ReadAllText("settings\\Cache.json");
			if (Thongso_HanhDong == null)
			{
				Thongso_HanhDong = new Thongso_HanhDong();
			}
			Thongso_HanhDong.ID_KichBan = (string.IsNullOrEmpty(ID_KichBan) ? Thongso_HanhDong.ID_KichBan : ID_KichBan);
			Thongso_HanhDong.TenHanhDong = txt_TenHanhDong.Text;
			Thongso_HanhDong.CauHinh = Json_CauHinh;
			Thongso_HanhDong.Ma_HanhDong = 20;
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

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ReplyCMT_Load(object sender, EventArgs e)
		{
			if (Thongso_HanhDong != null)
			{
				JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
				txt_TenHanhDong.Text = Thongso_HanhDong.TenHanhDong;
				txt_LinkPost.Text = jSON_Settings.GetValue("txt_LinkPost");
				num_Spam_SLMin.Value = jSON_Settings.GetValueInt("num_Spam_SLMin");
				num_Spam_SLMax.Value = jSON_Settings.GetValueInt("num_Spam_SLMax");
				rtb_Spam_NDcmt.Text = jSON_Settings.GetValue("rtb_Spam_NDcmt");
			}
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				label11.Text = "Tên hành động : ";
				label10.Text = "Link bài viết : ";
				label1.Text = "Số lượng Spam : ";
				btnAdd.Text = "Lưu";
				btnCancel.Text = "Thoát";
				groupBox3.Text = "Nội dung comment :";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.ReplyCMT));
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			txt_TenHanhDong = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			rtb_Spam_NDcmt = new System.Windows.Forms.RichTextBox();
			label10 = new System.Windows.Forms.Label();
			txt_LinkPost = new System.Windows.Forms.TextBox();
			num_Spam_SLMin = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			num_Spam_SLMax = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_Spam_SLMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_Spam_SLMax).BeginInit();
			SuspendLayout();
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(166, 306);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 222;
			btnCancel.Text = "Close";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(57, 306);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 221;
			btnAdd.Text = "Save";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			txt_TenHanhDong.Location = new System.Drawing.Point(121, 15);
			txt_TenHanhDong.Name = "txt_TenHanhDong";
			txt_TenHanhDong.Size = new System.Drawing.Size(159, 23);
			txt_TenHanhDong.TabIndex = 220;
			txt_TenHanhDong.Text = "Reply Comment";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(19, 18);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(81, 15);
			label11.TabIndex = 219;
			label11.Text = "Action name :";
			groupBox3.Controls.Add(rtb_Spam_NDcmt);
			groupBox3.Location = new System.Drawing.Point(22, 114);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(286, 180);
			groupBox3.TabIndex = 208;
			groupBox3.TabStop = false;
			groupBox3.Text = "Comment content :";
			rtb_Spam_NDcmt.Dock = System.Windows.Forms.DockStyle.Fill;
			rtb_Spam_NDcmt.Location = new System.Drawing.Point(3, 19);
			rtb_Spam_NDcmt.Name = "rtb_Spam_NDcmt";
			rtb_Spam_NDcmt.Size = new System.Drawing.Size(280, 158);
			rtb_Spam_NDcmt.TabIndex = 0;
			rtb_Spam_NDcmt.Text = "";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(18, 51);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(61, 15);
			label10.TabIndex = 209;
			label10.Text = "Link post :";
			txt_LinkPost.Location = new System.Drawing.Point(121, 48);
			txt_LinkPost.Name = "txt_LinkPost";
			txt_LinkPost.Size = new System.Drawing.Size(159, 23);
			txt_LinkPost.TabIndex = 223;
			num_Spam_SLMin.Location = new System.Drawing.Point(121, 85);
			num_Spam_SLMin.Name = "num_Spam_SLMin";
			num_Spam_SLMin.Size = new System.Drawing.Size(43, 23);
			num_Spam_SLMin.TabIndex = 225;
			num_Spam_SLMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(19, 87);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(103, 15);
			label1.TabIndex = 224;
			label1.Text = "Amount of spam :";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(250, 87);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(42, 15);
			label8.TabIndex = 228;
			label8.Text = "( cmt )";
			num_Spam_SLMax.Location = new System.Drawing.Point(201, 85);
			num_Spam_SLMax.Name = "num_Spam_SLMax";
			num_Spam_SLMax.Size = new System.Drawing.Size(43, 23);
			num_Spam_SLMax.TabIndex = 227;
			num_Spam_SLMax.Value = new decimal(new int[4] { 20, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(170, 87);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 15);
			label9.TabIndex = 226;
			label9.Text = "-->";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(332, 347);
			base.Controls.Add(num_Spam_SLMin);
			base.Controls.Add(label1);
			base.Controls.Add(label8);
			base.Controls.Add(num_Spam_SLMax);
			base.Controls.Add(label9);
			base.Controls.Add(txt_LinkPost);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(txt_TenHanhDong);
			base.Controls.Add(label11);
			base.Controls.Add(groupBox3);
			base.Controls.Add(label10);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "ReplyCMT";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Reply Comment";
			base.Load += new System.EventHandler(ReplyCMT_Load);
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)num_Spam_SLMin).EndInit();
			((System.ComponentModel.ISupportInitialize)num_Spam_SLMax).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
