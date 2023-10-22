using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class CheckLive : Form
	{
		public delegate void send(bool rad_CheckLive_TG, bool rad_CheckLive_NO, bool rad_CheckLive_Chrome, bool rad_CheckLive_Request);

		public static string path_data_live = "data/Data_Live.ini";

		public send send_data;

		private IContainer components = null;

		private Button btn_cancel;

		private Button btn_ok;

		private GroupBox gr_CheckLive_Request;

		private RadioButton rad_CheckLive_NO;

		private RadioButton rad_CheckLive_TG;

		private GroupBox gr_Acc_CheckLive;

		private Button btn_add;

		private Label label1;

		private TextBox txt_pass;

		private Label lb;

		private TextBox txt_user;

		private DataGridView dgv_Acc_CheckLive;

		private DataGridViewTextBoxColumn STT;

		private DataGridViewTextBoxColumn User;

		private DataGridViewTextBoxColumn Pass;

		private DataGridViewTextBoxColumn TinhTrang;

		private Button btn_Check;

		private ContextMenuStrip ctxmain;

		private ToolStripMenuItem ctx_Delete;

		private ToolStripMenuItem ctx_DeleteAll;

		private Label lb_Load_CheckLive;

		private RadioButton rad_CheckLive_Chrome;

		private RadioButton rad_CheckLive_Request;

		public CheckLive()
		{
			InitializeComponent();
		}

		private void save_INI()
		{
		}

		private void load_data_live()
		{
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			save_INI();
			send_data(rad_CheckLive_TG.Checked, rad_CheckLive_NO.Checked, rad_CheckLive_Chrome.Checked, rad_CheckLive_Request.Checked);
			Close();
		}

		public void Load_Data_dgv()
		{
		}

		private void Load_dgvacc()
		{
		}

		private void CheckLive_Load(object sender, EventArgs e)
		{
			Load_Data_dgv();
			if (File.Exists(path_data_live))
			{
				load_data_live();
			}
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void rad_CheckLive_TG_CheckedChanged(object sender, EventArgs e)
		{
			if (rad_CheckLive_TG.Checked)
			{
				gr_Acc_CheckLive.Enabled = true;
			}
			else
			{
				gr_Acc_CheckLive.Enabled = false;
			}
		}

		private void btn_add_Click(object sender, EventArgs e)
		{
		}

		private void dgv_Acc_CheckLive_MouseUp(object sender, MouseEventArgs e)
		{
			if (dgv_Acc_CheckLive.SelectedCells.Count == 0 || e.Button != MouseButtons.Right)
			{
				return;
			}
			DataGridView.HitTestInfo hitTestInfo = dgv_Acc_CheckLive.HitTest(e.X, e.Y);
			if (dgv_Acc_CheckLive.SelectedCells.Count < 2)
			{
				dgv_Acc_CheckLive.ClearSelection();
				try
				{
					dgv_Acc_CheckLive[hitTestInfo.ColumnIndex, hitTestInfo.RowIndex].Selected = true;
				}
				catch
				{
				}
			}
			ctxmain.Show(dgv_Acc_CheckLive, new Point(e.X, e.Y));
		}

		private void ctx_Delete_Click(object sender, EventArgs e)
		{
		}

		private void ctx_DeleteAll_Click(object sender, EventArgs e)
		{
		}

		private async void btn_Check_Click(object sender, EventArgs e)
		{
		}

		private void rad_CheckLive_Chrome_CheckedChanged(object sender, EventArgs e)
		{
			if (rad_CheckLive_Chrome.Checked)
			{
				gr_CheckLive_Request.Enabled = false;
			}
			else
			{
				gr_CheckLive_Request.Enabled = true;
			}
		}

		private void rad_CheckLive_Request_CheckedChanged(object sender, EventArgs e)
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.CheckLive));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			gr_CheckLive_Request = new System.Windows.Forms.GroupBox();
			gr_Acc_CheckLive = new System.Windows.Forms.GroupBox();
			lb_Load_CheckLive = new System.Windows.Forms.Label();
			btn_Check = new System.Windows.Forms.Button();
			dgv_Acc_CheckLive = new System.Windows.Forms.DataGridView();
			STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
			User = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
			TinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
			btn_add = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			txt_pass = new System.Windows.Forms.TextBox();
			lb = new System.Windows.Forms.Label();
			txt_user = new System.Windows.Forms.TextBox();
			rad_CheckLive_NO = new System.Windows.Forms.RadioButton();
			rad_CheckLive_TG = new System.Windows.Forms.RadioButton();
			btn_cancel = new System.Windows.Forms.Button();
			btn_ok = new System.Windows.Forms.Button();
			ctxmain = new System.Windows.Forms.ContextMenuStrip(components);
			ctx_Delete = new System.Windows.Forms.ToolStripMenuItem();
			ctx_DeleteAll = new System.Windows.Forms.ToolStripMenuItem();
			rad_CheckLive_Chrome = new System.Windows.Forms.RadioButton();
			rad_CheckLive_Request = new System.Windows.Forms.RadioButton();
			gr_CheckLive_Request.SuspendLayout();
			gr_Acc_CheckLive.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgv_Acc_CheckLive).BeginInit();
			ctxmain.SuspendLayout();
			SuspendLayout();
			gr_CheckLive_Request.Controls.Add(gr_Acc_CheckLive);
			gr_CheckLive_Request.Controls.Add(rad_CheckLive_NO);
			gr_CheckLive_Request.Controls.Add(rad_CheckLive_TG);
			gr_CheckLive_Request.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold);
			gr_CheckLive_Request.Location = new System.Drawing.Point(12, 62);
			gr_CheckLive_Request.Name = "gr_CheckLive_Request";
			gr_CheckLive_Request.Size = new System.Drawing.Size(581, 324);
			gr_CheckLive_Request.TabIndex = 71;
			gr_CheckLive_Request.TabStop = false;
			gr_Acc_CheckLive.Controls.Add(lb_Load_CheckLive);
			gr_Acc_CheckLive.Controls.Add(btn_Check);
			gr_Acc_CheckLive.Controls.Add(dgv_Acc_CheckLive);
			gr_Acc_CheckLive.Controls.Add(btn_add);
			gr_Acc_CheckLive.Controls.Add(label1);
			gr_Acc_CheckLive.Controls.Add(txt_pass);
			gr_Acc_CheckLive.Controls.Add(lb);
			gr_Acc_CheckLive.Controls.Add(txt_user);
			gr_Acc_CheckLive.Enabled = false;
			gr_Acc_CheckLive.Location = new System.Drawing.Point(15, 82);
			gr_Acc_CheckLive.Name = "gr_Acc_CheckLive";
			gr_Acc_CheckLive.Size = new System.Drawing.Size(559, 231);
			gr_Acc_CheckLive.TabIndex = 77;
			gr_Acc_CheckLive.TabStop = false;
			lb_Load_CheckLive.AutoSize = true;
			lb_Load_CheckLive.Cursor = System.Windows.Forms.Cursors.Hand;
			lb_Load_CheckLive.Enabled = false;
			lb_Load_CheckLive.Font = new System.Drawing.Font("Segoe UI Semibold", 13f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lb_Load_CheckLive.Image = (System.Drawing.Image)resources.GetObject("lb_Load_CheckLive.Image");
			lb_Load_CheckLive.Location = new System.Drawing.Point(520, 16);
			lb_Load_CheckLive.Name = "lb_Load_CheckLive";
			lb_Load_CheckLive.Size = new System.Drawing.Size(27, 25);
			lb_Load_CheckLive.TabIndex = 85;
			lb_Load_CheckLive.Text = "   ";
			btn_Check.ForeColor = System.Drawing.Color.Crimson;
			btn_Check.Location = new System.Drawing.Point(434, 17);
			btn_Check.Name = "btn_Check";
			btn_Check.Size = new System.Drawing.Size(78, 27);
			btn_Check.TabIndex = 84;
			btn_Check.Text = "Check";
			btn_Check.UseVisualStyleBackColor = true;
			btn_Check.Click += new System.EventHandler(btn_Check_Click);
			dgv_Acc_CheckLive.AllowUserToAddRows = false;
			dgv_Acc_CheckLive.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			dgv_Acc_CheckLive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgv_Acc_CheckLive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dgv_Acc_CheckLive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv_Acc_CheckLive.Columns.AddRange(STT, User, Pass, TinhTrang);
			dgv_Acc_CheckLive.EnableHeadersVisualStyles = false;
			dgv_Acc_CheckLive.Location = new System.Drawing.Point(8, 57);
			dgv_Acc_CheckLive.Name = "dgv_Acc_CheckLive";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgv_Acc_CheckLive.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgv_Acc_CheckLive.RowHeadersVisible = false;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dgv_Acc_CheckLive.RowsDefaultCellStyle = dataGridViewCellStyle3;
			dgv_Acc_CheckLive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			dgv_Acc_CheckLive.Size = new System.Drawing.Size(539, 167);
			dgv_Acc_CheckLive.TabIndex = 83;
			dgv_Acc_CheckLive.MouseUp += new System.Windows.Forms.MouseEventHandler(dgv_Acc_CheckLive_MouseUp);
			STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			STT.DataPropertyName = "STT";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			STT.DefaultCellStyle = dataGridViewCellStyle4;
			STT.FillWeight = 20f;
			STT.HeaderText = "STT";
			STT.Name = "STT";
			STT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			User.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			User.DataPropertyName = "User";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			User.DefaultCellStyle = dataGridViewCellStyle5;
			User.FillWeight = 40f;
			User.HeaderText = "User";
			User.Name = "User";
			Pass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			Pass.DataPropertyName = "Pass";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			Pass.DefaultCellStyle = dataGridViewCellStyle6;
			Pass.FillWeight = 11f;
			Pass.HeaderText = "Pass";
			Pass.Name = "Pass";
			TinhTrang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			TinhTrang.DataPropertyName = "TinhTrang";
			TinhTrang.FillWeight = 35f;
			TinhTrang.HeaderText = "Tình Trạng";
			TinhTrang.Name = "TinhTrang";
			btn_add.ForeColor = System.Drawing.Color.RoyalBlue;
			btn_add.Location = new System.Drawing.Point(346, 17);
			btn_add.Name = "btn_add";
			btn_add.Size = new System.Drawing.Size(78, 27);
			btn_add.TabIndex = 82;
			btn_add.Text = "+ Add";
			btn_add.UseVisualStyleBackColor = true;
			btn_add.Click += new System.EventHandler(btn_add_Click);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.Teal;
			label1.Location = new System.Drawing.Point(175, 22);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(33, 15);
			label1.TabIndex = 81;
			label1.Text = "Pass:";
			txt_pass.Location = new System.Drawing.Point(220, 17);
			txt_pass.Name = "txt_pass";
			txt_pass.Size = new System.Drawing.Size(112, 23);
			txt_pass.TabIndex = 80;
			lb.AutoSize = true;
			lb.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lb.ForeColor = System.Drawing.Color.Teal;
			lb.Location = new System.Drawing.Point(5, 22);
			lb.Name = "lb";
			lb.Size = new System.Drawing.Size(33, 15);
			lb.TabIndex = 79;
			lb.Text = "User:";
			txt_user.Location = new System.Drawing.Point(52, 18);
			txt_user.Name = "txt_user";
			txt_user.Size = new System.Drawing.Size(112, 23);
			txt_user.TabIndex = 78;
			rad_CheckLive_NO.AutoSize = true;
			rad_CheckLive_NO.Checked = true;
			rad_CheckLive_NO.Location = new System.Drawing.Point(23, 24);
			rad_CheckLive_NO.Name = "rad_CheckLive_NO";
			rad_CheckLive_NO.Size = new System.Drawing.Size(490, 19);
			rad_CheckLive_NO.TabIndex = 70;
			rad_CheckLive_NO.TabStop = true;
			rad_CheckLive_NO.Text = "Check Live - Get thông tin không cần acc trung gian (Nhanh - Chậm tuỳ nhân phẩm :)) )";
			rad_CheckLive_NO.UseVisualStyleBackColor = true;
			rad_CheckLive_TG.AutoSize = true;
			rad_CheckLive_TG.ForeColor = System.Drawing.Color.Crimson;
			rad_CheckLive_TG.Location = new System.Drawing.Point(23, 57);
			rad_CheckLive_TG.Name = "rad_CheckLive_TG";
			rad_CheckLive_TG.Size = new System.Drawing.Size(377, 19);
			rad_CheckLive_TG.TabIndex = 69;
			rad_CheckLive_TG.Text = "Sử dụng Acc trung gian (1 check 100) - Check Live + Get Thông tin";
			rad_CheckLive_TG.UseVisualStyleBackColor = true;
			rad_CheckLive_TG.CheckedChanged += new System.EventHandler(rad_CheckLive_TG_CheckedChanged);
			btn_cancel.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
			btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			btn_cancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			btn_cancel.Image = (System.Drawing.Image)resources.GetObject("btn_cancel.Image");
			btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btn_cancel.Location = new System.Drawing.Point(330, 392);
			btn_cancel.Name = "btn_cancel";
			btn_cancel.Size = new System.Drawing.Size(87, 42);
			btn_cancel.TabIndex = 73;
			btn_cancel.Text = "    Cancel";
			btn_cancel.UseVisualStyleBackColor = false;
			btn_cancel.Click += new System.EventHandler(btn_cancel_Click);
			btn_ok.BackColor = System.Drawing.Color.SlateBlue;
			btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			btn_ok.ForeColor = System.Drawing.SystemColors.ButtonFace;
			btn_ok.Image = (System.Drawing.Image)resources.GetObject("btn_ok.Image");
			btn_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btn_ok.Location = new System.Drawing.Point(204, 392);
			btn_ok.Name = "btn_ok";
			btn_ok.Size = new System.Drawing.Size(87, 42);
			btn_ok.TabIndex = 72;
			btn_ok.Text = "OK";
			btn_ok.UseVisualStyleBackColor = false;
			btn_ok.Click += new System.EventHandler(btn_ok_Click);
			ctxmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { ctx_Delete, ctx_DeleteAll });
			ctxmain.Name = "ctxmain";
			ctxmain.Size = new System.Drawing.Size(126, 48);
			ctx_Delete.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_Delete.Image = (System.Drawing.Image)resources.GetObject("ctx_Delete.Image");
			ctx_Delete.Name = "ctx_Delete";
			ctx_Delete.Size = new System.Drawing.Size(125, 22);
			ctx_Delete.Text = "Delete";
			ctx_Delete.Click += new System.EventHandler(ctx_Delete_Click);
			ctx_DeleteAll.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_DeleteAll.Image = (System.Drawing.Image)resources.GetObject("ctx_DeleteAll.Image");
			ctx_DeleteAll.Name = "ctx_DeleteAll";
			ctx_DeleteAll.Size = new System.Drawing.Size(125, 22);
			ctx_DeleteAll.Text = "Delete All";
			ctx_DeleteAll.Click += new System.EventHandler(ctx_DeleteAll_Click);
			rad_CheckLive_Chrome.AutoSize = true;
			rad_CheckLive_Chrome.Checked = true;
			rad_CheckLive_Chrome.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			rad_CheckLive_Chrome.Location = new System.Drawing.Point(27, 12);
			rad_CheckLive_Chrome.Name = "rad_CheckLive_Chrome";
			rad_CheckLive_Chrome.Size = new System.Drawing.Size(156, 19);
			rad_CheckLive_Chrome.TabIndex = 74;
			rad_CheckLive_Chrome.TabStop = true;
			rad_CheckLive_Chrome.Text = "Check Live bằng Chrome";
			rad_CheckLive_Chrome.UseVisualStyleBackColor = true;
			rad_CheckLive_Chrome.CheckedChanged += new System.EventHandler(rad_CheckLive_Chrome_CheckedChanged);
			rad_CheckLive_Request.AutoSize = true;
			rad_CheckLive_Request.Location = new System.Drawing.Point(27, 42);
			rad_CheckLive_Request.Name = "rad_CheckLive_Request";
			rad_CheckLive_Request.Size = new System.Drawing.Size(156, 19);
			rad_CheckLive_Request.TabIndex = 75;
			rad_CheckLive_Request.Text = "Check Live bằng Request";
			rad_CheckLive_Request.UseVisualStyleBackColor = true;
			rad_CheckLive_Request.CheckedChanged += new System.EventHandler(rad_CheckLive_Request_CheckedChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			base.ClientSize = new System.Drawing.Size(609, 445);
			base.Controls.Add(rad_CheckLive_Request);
			base.Controls.Add(rad_CheckLive_Chrome);
			base.Controls.Add(btn_cancel);
			base.Controls.Add(btn_ok);
			base.Controls.Add(gr_CheckLive_Request);
			Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "CheckLive";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Check Live";
			base.Load += new System.EventHandler(CheckLive_Load);
			gr_CheckLive_Request.ResumeLayout(false);
			gr_CheckLive_Request.PerformLayout();
			gr_Acc_CheckLive.ResumeLayout(false);
			gr_Acc_CheckLive.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgv_Acc_CheckLive).EndInit();
			ctxmain.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
