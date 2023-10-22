using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class CauHinhTuongTac : Form
	{
		private JSON_Settings json_CauHinhDoiIP = new JSON_Settings(Load_file.path_CauHinhTuongTac);

		private IContainer components = null;

		private GroupBox groupBox1;

		private Label label11;

		private CheckBox cb_RandomHanhDong;

		private ComboBox cbb_KieuTuongTac;

		private GroupBox groupBox3;

		private GroupBox groupBox2;

		private ContextMenuStrip ctxmain;

		private ToolStripMenuItem ctx_Themkichban;

		private ToolStripMenuItem ctx_Delete_kichban;

		private DataGridView dgv_KichBan;

		private DataGridView dgv_HanhDong;

		private ContextMenuStrip ctxmain_1;

		private ToolStripMenuItem ctx_ThemHanhDong;

		private ToolStripMenuItem ctx_Sua_hanhdong;

		private ToolStripMenuItem ctx_Delete_hanhdong;

		private ToolStripMenuItem ctx_Sua_kichban;

		private Label label3;

		private NumericUpDown num_ThreadTimeout_TimeMax;

		private Label label2;

		private NumericUpDown num_ThreadTimeout_TimeMin;

		private Label label4;

		private DataGridViewTextBoxColumn STT;

		private DataGridViewTextBoxColumn ID_KichBan;

		private DataGridViewTextBoxColumn TenKichBan;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn ID_HanhDong;

		private DataGridViewTextBoxColumn ID_KB;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn CauHinh;

		private Button btnCancel;

		private Button btnAdd;

		private CheckBox cb_SDProfile;

		private Label label10;

		private NumericUpDown num_ChromeY;

		private NumericUpDown num_ChromeX;

		private Label label1;

		private RadioButton rad_EN;

		private RadioButton rad_VI;

		private Label label9;

		private TextBox txt_cookiecheck;

		private Label label5;

		private CheckBox cb_checkTT;

		private TextBox txt_PathProfile;

		private CheckBox cb_addform;

		public CauHinhTuongTac()
		{
			InitializeComponent();
		}

		private void save_INI()
		{
			json_CauHinhDoiIP.Add("cb_RandomHanhDong", cb_RandomHanhDong.Checked.ToString());
			json_CauHinhDoiIP.Add("cbb_KieuTuongTac", cbb_KieuTuongTac.Text);
			json_CauHinhDoiIP.Add("num_ThreadTimeout_TimeMin", num_ThreadTimeout_TimeMin.Value.ToString());
			json_CauHinhDoiIP.Add("num_ThreadTimeout_TimeMax", num_ThreadTimeout_TimeMax.Value.ToString());
			json_CauHinhDoiIP.Add("rad_VI", rad_VI.Checked.ToString());
			json_CauHinhDoiIP.Add("rad_EN", rad_EN.Checked.ToString());
			json_CauHinhDoiIP.Add("num_ChromeX", num_ChromeX.Value.ToString());
			json_CauHinhDoiIP.Add("num_ChromeY", num_ChromeY.Value.ToString());
			json_CauHinhDoiIP.Add("cb_SDProfile", cb_SDProfile.Checked.ToString());
			json_CauHinhDoiIP.Add("txt_PathProfile", txt_PathProfile.Text);
			json_CauHinhDoiIP.Add("cb_checkTT", cb_checkTT.Checked.ToString());
			json_CauHinhDoiIP.Add("txt_cookiecheck", txt_cookiecheck.Text);
			json_CauHinhDoiIP.Add("cb_addform", cb_addform.Checked.ToString());
		}

		private void btn_okTT_Click(object sender, EventArgs e)
		{
			save_INI();
			interact_sql interact_sql2 = new interact_sql();
			string tenKichBan = cbb_KieuTuongTac.SelectedItem?.ToString();
			ThongSo_CauHinhTuongTac.TT_KichBan = interact_sql2.Select_Data_KichBan(tenKichBan);
			ThongSo_CauHinhTuongTac.cb_RandomHanhDong = cb_RandomHanhDong.Checked;
			ThongSo_CauHinhTuongTac.L_HanhDong = Load_file.Load_hanhdong();
			Close();
		}

		private void btn_CancelTT_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void CauHinhTuongTac_Load(object sender, EventArgs e)
		{
			interact_sql interact_sql2 = new interact_sql();
			interact_sql2.Check_table();
			Load_dgv_KichBan();
			LoadHanhDong();
			cb_RandomHanhDong.Checked = json_CauHinhDoiIP.GetValueBool("cb_RandomHanhDong");
			cbb_KieuTuongTac.SelectedItem = json_CauHinhDoiIP.GetValue("cbb_KieuTuongTac");
			num_ThreadTimeout_TimeMin.Value = json_CauHinhDoiIP.GetValueInt("num_ThreadTimeout_TimeMin");
			num_ThreadTimeout_TimeMax.Value = json_CauHinhDoiIP.GetValueInt("num_ThreadTimeout_TimeMax");
			rad_VI.Checked = json_CauHinhDoiIP.GetValueBool("rad_VI");
			rad_EN.Checked = json_CauHinhDoiIP.GetValueBool("rad_EN");
			num_ChromeX.Value = json_CauHinhDoiIP.GetValueInt("num_ChromeX");
			num_ChromeY.Value = json_CauHinhDoiIP.GetValueInt("num_ChromeY");
			cb_SDProfile.Checked = json_CauHinhDoiIP.GetValueBool("cb_SDProfile");
			txt_PathProfile.Text = json_CauHinhDoiIP.GetValue("txt_PathProfile");
			cb_checkTT.Checked = json_CauHinhDoiIP.GetValueBool("cb_checkTT");
			txt_cookiecheck.Text = json_CauHinhDoiIP.GetValue("txt_cookiecheck");
			cb_addform.Checked = json_CauHinhDoiIP.GetValueBool("cb_addform");
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				groupBox3.Text = "Tên kịch bản";
				groupBox2.Text = "Tên hành động";
				groupBox1.Text = "Cài đặt";
				label11.Text = "Chọn kịch bản : ";
				cb_RandomHanhDong.Text = "Random hành động . ";
				label4.Text = "Thời gian chờ luồng : ";
				btnAdd.Text = "Lưu";
				btnCancel.Text = "Thoát";
				cb_checkTT.Text = "Lấy thông tin ACC khi chạy tương tác";
				label5.Text = "Cookie trung gian : ";
				label9.Text = "Ngôn ngữ : ";
				groupBox1.Text = "Cài đặt chung";
				label1.Text = "Sắp xếp cửa sổ Chrome :";
			}
		}

		private void Load_dgv_KichBan()
		{
			interact_sql interact_sql2 = new interact_sql();
			DataTable dataTable = interact_sql2.LoadData_KichBan();
			dgv_KichBan.Invoke((MethodInvoker)delegate
			{
				dgv_KichBan.Rows.Clear();
				cbb_KieuTuongTac.Items.Clear();
			});
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow row = dataTable.Rows[i];
				dgv_KichBan.Invoke((MethodInvoker)delegate
				{
					dgv_KichBan.Rows.Add(dgv_KichBan.RowCount + 1, row["ID_KichBan"], row["TenKichBan"]);
					cbb_KieuTuongTac.Items.Add(row["TenKichBan"]);
				});
			}
			dgv_KichBan.EndEdit();
		}

		private void dgv_acc_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}
			DataGridView.HitTestInfo hitTestInfo = dgv_KichBan.HitTest(e.X, e.Y);
			if (dgv_KichBan.SelectedCells.Count < 2)
			{
				dgv_KichBan.ClearSelection();
				try
				{
					dgv_KichBan[hitTestInfo.ColumnIndex, hitTestInfo.RowIndex].Selected = true;
				}
				catch
				{
				}
			}
			ctxmain.Show(dgv_KichBan, new Point(e.X, e.Y));
		}

		private void dgv_HanhDong_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}
			DataGridView.HitTestInfo hitTestInfo = dgv_HanhDong.HitTest(e.X, e.Y);
			if (dgv_HanhDong.SelectedCells.Count < 2)
			{
				dgv_HanhDong.ClearSelection();
				try
				{
					dgv_HanhDong[hitTestInfo.ColumnIndex, hitTestInfo.RowIndex].Selected = true;
				}
				catch
				{
				}
			}
			ctxmain_1.Show(dgv_HanhDong, new Point(e.X, e.Y));
		}

		private void ctx_Themkichban_Click(object sender, EventArgs e)
		{
			ThemKichBan themKichBan = new ThemKichBan();
			themKichBan.ShowDialog();
			Load_dgv_KichBan();
		}

		private void dgv_KichBan_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				LoadHanhDong();
			}
		}

		private void LoadHanhDong()
		{
			try
			{
				interact_sql interact_sql2 = new interact_sql();
				DataTable dataTable = interact_sql2.LoadData_HanhDong();
				dgv_HanhDong.Invoke((MethodInvoker)delegate
				{
					dgv_HanhDong.Rows.Clear();
				});
				string text = dgv_KichBan.SelectedRows[0].Cells["ID_KichBan"].Value.ToString();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow row = dataTable.Rows[i];
					if (!(text != row["ID_KichBan"].ToString()))
					{
						dgv_HanhDong.Invoke((MethodInvoker)delegate
						{
							dgv_HanhDong.Rows.Add(dgv_HanhDong.RowCount + 1, row["ID_HanhDong"], row["ID_KichBan"], row["TenHanhDong"], row["CauHinh"]);
						});
					}
				}
				dgv_HanhDong.EndEdit();
			}
			catch
			{
			}
		}

		private void ctx_Sua_kichban_Click(object sender, EventArgs e)
		{
			SuaKichBan suaKichBan = new SuaKichBan(dgv_KichBan.SelectedRows[0].Cells["ID_KichBan"].Value.ToString());
			suaKichBan.ShowDialog();
			Load_dgv_KichBan();
		}

		private void ctx_Delete_kichban_Click(object sender, EventArgs e)
		{
			interact_sql interact_sql2 = new interact_sql();
			foreach (DataGridViewRow selectedRow in dgv_KichBan.SelectedRows)
			{
				string iD_KichBan = selectedRow.Cells["ID_KichBan"].Value.ToString();
				interact_sql2.Delete_Data_KichBan(iD_KichBan);
				interact_sql2.Delete_Data_HanhDong_1(iD_KichBan);
			}
			Load_dgv_KichBan();
		}

		private void ctx_nhanban_kichban_Click(object sender, EventArgs e)
		{
			interact_sql interact_sql2 = new interact_sql();
			foreach (DataGridViewCell selectedCell in dgv_KichBan.SelectedCells)
			{
				string tenKichBan = dgv_KichBan.SelectedRows[selectedCell.RowIndex].Cells["TenKichBan"].ToString();
				Thongso_KichBan thongso_KichBan = interact_sql2.Select_Data_KichBan(tenKichBan);
				Thongso_HanhDong thongso_HanhDong = interact_sql2.Select_Data_HanhDong(thongso_KichBan.ID_KichBan);
				interact_sql2.Add_data_KichBan(tenKichBan);
			}
		}

		private void ctx_ThemHanhDong_Click(object sender, EventArgs e)
		{
			try
			{
				fHanhDong fHanhDong2 = new fHanhDong(dgv_KichBan.SelectedRows[0].Cells["ID_KichBan"].Value.ToString());
				fHanhDong2.ShowDialog();
				LoadHanhDong();
			}
			catch
			{
				MessageBox.Show("Vui lòng chọn kịch bản (Please choose a scenario) !");
			}
		}

		private void ctx_Delete_hanhdong_Click(object sender, EventArgs e)
		{
			interact_sql interact_sql2 = new interact_sql();
			foreach (DataGridViewRow selectedRow in dgv_HanhDong.SelectedRows)
			{
				string iD_HanhDong = selectedRow.Cells["ID_HanhDong"].Value.ToString();
				interact_sql2.Delete_Data_HanhDong(iD_HanhDong);
			}
			LoadHanhDong();
		}

		private void ctx_Sua_hanhdong_Click(object sender, EventArgs e)
		{
			interact_sql interact_sql2 = new interact_sql();
			foreach (DataGridViewRow selectedRow in dgv_HanhDong.SelectedRows)
			{
				string iD_HanhDong = selectedRow.Cells["ID_HanhDong"].Value.ToString();
				Thongso_HanhDong thongso_HanhDong = interact_sql2.Select_Data_HanhDong(iD_HanhDong);
				hanhdong(thongso_HanhDong);
			}
			LoadHanhDong();
		}

		private void hanhdong(Thongso_HanhDong Thongso_HanhDong)
		{
			switch (Thongso_HanhDong.Ma_HanhDong)
			{
			case 0:
			{
				TuongTacNewsfeed tuongTacNewsfeed = new TuongTacNewsfeed(Thongso_HanhDong);
				tuongTacNewsfeed.ShowDialog();
				break;
			}
			case 1:
			{
				TuongTacFollowers tuongTacFollowers = new TuongTacFollowers(Thongso_HanhDong);
				tuongTacFollowers.ShowDialog();
				break;
			}
			case 2:
			{
				TuongTacFollowing tuongTacFollowing = new TuongTacFollowing(Thongso_HanhDong);
				tuongTacFollowing.ShowDialog();
				break;
			}
			case 3:
			{
				NhanTinTheoUser nhanTinTheoUser = new NhanTinTheoUser(Thongso_HanhDong);
				nhanTinTheoUser.ShowDialog();
				break;
			}
			case 4:
			{
				NhanTinVoiFollowers nhanTinVoiFollowers = new NhanTinVoiFollowers(Thongso_HanhDong);
				nhanTinVoiFollowers.ShowDialog();
				break;
			}
			case 5:
			{
				NhanTinVoiFollowing nhanTinVoiFollowing = new NhanTinVoiFollowing(Thongso_HanhDong);
				nhanTinVoiFollowing.ShowDialog();
				break;
			}
			case 6:
			{
				TuongTacTinNhan tuongTacTinNhan = new TuongTacTinNhan(Thongso_HanhDong);
				tuongTacTinNhan.ShowDialog();
				break;
			}
			case 7:
			{
				CauHinhLuotStory cauHinhLuotStory = new CauHinhLuotStory(Thongso_HanhDong);
				cauHinhLuotStory.ShowDialog();
				break;
			}
			case 8:
			{
				CauHinhSpam cauHinhSpam = new CauHinhSpam(Thongso_HanhDong);
				cauHinhSpam.ShowDialog();
				break;
			}
			case 9:
			{
				ShareBaiViet shareBaiViet = new ShareBaiViet(Thongso_HanhDong);
				shareBaiViet.ShowDialog();
				break;
			}
			case 10:
			{
				FollowGoiY followGoiY = new FollowGoiY(Thongso_HanhDong);
				followGoiY.ShowDialog();
				break;
			}
			case 11:
			{
				FollowTuKhoa followTuKhoa = new FollowTuKhoa(Thongso_HanhDong);
				followTuKhoa.ShowDialog();
				break;
			}
			case 12:
			{
				FollowUser followUser = new FollowUser(Thongso_HanhDong);
				followUser.ShowDialog();
				break;
			}
			case 13:
			{
				FollowLaiFollowers followLaiFollowers = new FollowLaiFollowers(Thongso_HanhDong);
				followLaiFollowers.ShowDialog();
				break;
			}
			case 14:
			{
				FollowUserLikePost followUserLikePost = new FollowUserLikePost(Thongso_HanhDong);
				followUserLikePost.ShowDialog();
				break;
			}
			case 15:
			{
				FollowFollowerUser followFollowerUser = new FollowFollowerUser(Thongso_HanhDong);
				followFollowerUser.ShowDialog();
				break;
			}
			case 16:
			{
				FollowFollowingUser followFollowingUser = new FollowFollowingUser(Thongso_HanhDong);
				followFollowingUser.ShowDialog();
				break;
			}
			case 17:
			{
				UnFollow unFollow = new UnFollow(Thongso_HanhDong);
				unFollow.ShowDialog();
				break;
			}
			case 18:
			{
				Change_profile change_profile = new Change_profile(Thongso_HanhDong);
				change_profile.ShowDialog();
				break;
			}
			case 19:
			{
				Post post = new Post(Thongso_HanhDong);
				post.ShowDialog();
				break;
			}
			case 20:
			{
				ReplyCMT replyCMT = new ReplyCMT(Thongso_HanhDong);
				replyCMT.ShowDialog();
				break;
			}
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
			components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.CauHinhTuongTac));
			groupBox1 = new System.Windows.Forms.GroupBox();
			label3 = new System.Windows.Forms.Label();
			num_ThreadTimeout_TimeMax = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			num_ThreadTimeout_TimeMin = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			cb_RandomHanhDong = new System.Windows.Forms.CheckBox();
			cbb_KieuTuongTac = new System.Windows.Forms.ComboBox();
			label11 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			dgv_KichBan = new System.Windows.Forms.DataGridView();
			STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ID_KichBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			TenKichBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			groupBox2 = new System.Windows.Forms.GroupBox();
			dgv_HanhDong = new System.Windows.Forms.DataGridView();
			dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ID_HanhDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ID_KB = new System.Windows.Forms.DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			CauHinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ctxmain = new System.Windows.Forms.ContextMenuStrip(components);
			ctx_Themkichban = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Sua_kichban = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Delete_kichban = new System.Windows.Forms.ToolStripMenuItem();
			ctxmain_1 = new System.Windows.Forms.ContextMenuStrip(components);
			ctx_ThemHanhDong = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Sua_hanhdong = new System.Windows.Forms.ToolStripMenuItem();
			ctx_Delete_hanhdong = new System.Windows.Forms.ToolStripMenuItem();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			cb_SDProfile = new System.Windows.Forms.CheckBox();
			label10 = new System.Windows.Forms.Label();
			num_ChromeY = new System.Windows.Forms.NumericUpDown();
			num_ChromeX = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			rad_EN = new System.Windows.Forms.RadioButton();
			rad_VI = new System.Windows.Forms.RadioButton();
			label9 = new System.Windows.Forms.Label();
			txt_cookiecheck = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			cb_checkTT = new System.Windows.Forms.CheckBox();
			txt_PathProfile = new System.Windows.Forms.TextBox();
			cb_addform = new System.Windows.Forms.CheckBox();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_ThreadTimeout_TimeMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_ThreadTimeout_TimeMin).BeginInit();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgv_KichBan).BeginInit();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgv_HanhDong).BeginInit();
			ctxmain.SuspendLayout();
			ctxmain_1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)num_ChromeY).BeginInit();
			((System.ComponentModel.ISupportInitialize)num_ChromeX).BeginInit();
			SuspendLayout();
			groupBox1.Controls.Add(cb_addform);
			groupBox1.Controls.Add(cb_SDProfile);
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(num_ChromeY);
			groupBox1.Controls.Add(num_ChromeX);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(rad_EN);
			groupBox1.Controls.Add(rad_VI);
			groupBox1.Controls.Add(label9);
			groupBox1.Controls.Add(txt_cookiecheck);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(cb_checkTT);
			groupBox1.Controls.Add(txt_PathProfile);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(num_ThreadTimeout_TimeMax);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(num_ThreadTimeout_TimeMin);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(cb_RandomHanhDong);
			groupBox1.Controls.Add(cbb_KieuTuongTac);
			groupBox1.Controls.Add(label11);
			groupBox1.Location = new System.Drawing.Point(411, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(348, 340);
			groupBox1.TabIndex = 71;
			groupBox1.TabStop = false;
			groupBox1.Text = "Option";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(259, 83);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 15);
			label3.TabIndex = 219;
			label3.Text = "( s ) ";
			num_ThreadTimeout_TimeMax.Location = new System.Drawing.Point(210, 81);
			num_ThreadTimeout_TimeMax.Name = "num_ThreadTimeout_TimeMax";
			num_ThreadTimeout_TimeMax.Size = new System.Drawing.Size(43, 23);
			num_ThreadTimeout_TimeMax.TabIndex = 218;
			num_ThreadTimeout_TimeMax.Value = new decimal(new int[4] { 30, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(179, 83);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 15);
			label2.TabIndex = 217;
			label2.Text = "-->";
			num_ThreadTimeout_TimeMin.Location = new System.Drawing.Point(130, 81);
			num_ThreadTimeout_TimeMin.Name = "num_ThreadTimeout_TimeMin";
			num_ThreadTimeout_TimeMin.Size = new System.Drawing.Size(43, 23);
			num_ThreadTimeout_TimeMin.TabIndex = 216;
			num_ThreadTimeout_TimeMin.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(9, 83);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(98, 15);
			label4.TabIndex = 215;
			label4.Text = "Thread Timeout :";
			cb_RandomHanhDong.AutoSize = true;
			cb_RandomHanhDong.Location = new System.Drawing.Point(130, 47);
			cb_RandomHanhDong.Name = "cb_RandomHanhDong";
			cb_RandomHanhDong.Size = new System.Drawing.Size(158, 19);
			cb_RandomHanhDong.TabIndex = 2;
			cb_RandomHanhDong.Text = "Random order of action .";
			cb_RandomHanhDong.UseVisualStyleBackColor = true;
			cbb_KieuTuongTac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbb_KieuTuongTac.FormattingEnabled = true;
			cbb_KieuTuongTac.Location = new System.Drawing.Point(130, 20);
			cbb_KieuTuongTac.Name = "cbb_KieuTuongTac";
			cbb_KieuTuongTac.Size = new System.Drawing.Size(203, 21);
			cbb_KieuTuongTac.TabIndex = 1;
			label11.AutoSize = true;
			label11.ForeColor = System.Drawing.Color.DarkRed;
			label11.Location = new System.Drawing.Point(10, 23);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(92, 15);
			label11.TabIndex = 0;
			label11.Text = "Select scenario :";
			groupBox3.Controls.Add(dgv_KichBan);
			groupBox3.Location = new System.Drawing.Point(12, 12);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(177, 340);
			groupBox3.TabIndex = 72;
			groupBox3.TabStop = false;
			groupBox3.Text = "Scenario List";
			dgv_KichBan.AllowUserToAddRows = false;
			dgv_KichBan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			dgv_KichBan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgv_KichBan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dgv_KichBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv_KichBan.Columns.AddRange(STT, ID_KichBan, TenKichBan);
			dgv_KichBan.Dock = System.Windows.Forms.DockStyle.Fill;
			dgv_KichBan.EnableHeadersVisualStyles = false;
			dgv_KichBan.Location = new System.Drawing.Point(3, 19);
			dgv_KichBan.Name = "dgv_KichBan";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgv_KichBan.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgv_KichBan.RowHeadersVisible = false;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dgv_KichBan.RowsDefaultCellStyle = dataGridViewCellStyle3;
			dgv_KichBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dgv_KichBan.Size = new System.Drawing.Size(171, 318);
			dgv_KichBan.TabIndex = 59;
			dgv_KichBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgv_KichBan_CellClick);
			dgv_KichBan.MouseUp += new System.Windows.Forms.MouseEventHandler(dgv_acc_MouseUp);
			STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			STT.DataPropertyName = "STT";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			STT.DefaultCellStyle = dataGridViewCellStyle4;
			STT.FillWeight = 10f;
			STT.HeaderText = "STT";
			STT.Name = "STT";
			STT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			ID_KichBan.HeaderText = "ID_KichBan";
			ID_KichBan.Name = "ID_KichBan";
			ID_KichBan.Visible = false;
			TenKichBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			TenKichBan.DataPropertyName = "TenKichBan";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			TenKichBan.DefaultCellStyle = dataGridViewCellStyle5;
			TenKichBan.FillWeight = 40f;
			TenKichBan.HeaderText = "Script Name";
			TenKichBan.Name = "TenKichBan";
			groupBox2.Controls.Add(dgv_HanhDong);
			groupBox2.Location = new System.Drawing.Point(195, 12);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(201, 340);
			groupBox2.TabIndex = 73;
			groupBox2.TabStop = false;
			groupBox2.Text = "Action List";
			dgv_HanhDong.AllowUserToAddRows = false;
			dgv_HanhDong.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			dgv_HanhDong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgv_HanhDong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
			dgv_HanhDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv_HanhDong.Columns.AddRange(dataGridViewTextBoxColumn1, ID_HanhDong, ID_KB, dataGridViewTextBoxColumn2, CauHinh);
			dgv_HanhDong.Dock = System.Windows.Forms.DockStyle.Fill;
			dgv_HanhDong.EnableHeadersVisualStyles = false;
			dgv_HanhDong.Location = new System.Drawing.Point(3, 19);
			dgv_HanhDong.Name = "dgv_HanhDong";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgv_HanhDong.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
			dgv_HanhDong.RowHeadersVisible = false;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dgv_HanhDong.RowsDefaultCellStyle = dataGridViewCellStyle8;
			dgv_HanhDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dgv_HanhDong.Size = new System.Drawing.Size(195, 318);
			dgv_HanhDong.TabIndex = 60;
			dgv_HanhDong.MouseUp += new System.Windows.Forms.MouseEventHandler(dgv_HanhDong_MouseUp);
			dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewTextBoxColumn1.DataPropertyName = "STT";
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
			dataGridViewTextBoxColumn1.FillWeight = 10f;
			dataGridViewTextBoxColumn1.HeaderText = "STT";
			dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			ID_HanhDong.HeaderText = "ID_HanhDong";
			ID_HanhDong.Name = "ID_HanhDong";
			ID_HanhDong.Visible = false;
			ID_KB.HeaderText = "ID_KB";
			ID_KB.Name = "ID_KB";
			ID_KB.Visible = false;
			dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewTextBoxColumn2.DataPropertyName = "HanhDong";
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle10;
			dataGridViewTextBoxColumn2.FillWeight = 40f;
			dataGridViewTextBoxColumn2.HeaderText = "Act";
			dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			CauHinh.HeaderText = "CauHinh";
			CauHinh.Name = "CauHinh";
			CauHinh.Visible = false;
			ctxmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { ctx_Themkichban, ctx_Sua_kichban, ctx_Delete_kichban });
			ctxmain.Name = "ctxmain";
			ctxmain.Size = new System.Drawing.Size(141, 70);
			ctx_Themkichban.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_Themkichban.Image = (System.Drawing.Image)resources.GetObject("ctx_Themkichban.Image");
			ctx_Themkichban.Name = "ctx_Themkichban";
			ctx_Themkichban.Size = new System.Drawing.Size(140, 22);
			ctx_Themkichban.Text = "Add script";
			ctx_Themkichban.Click += new System.EventHandler(ctx_Themkichban_Click);
			ctx_Sua_kichban.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_Sua_kichban.Image = (System.Drawing.Image)resources.GetObject("ctx_Sua_kichban.Image");
			ctx_Sua_kichban.Name = "ctx_Sua_kichban";
			ctx_Sua_kichban.Size = new System.Drawing.Size(140, 22);
			ctx_Sua_kichban.Text = "Edit script";
			ctx_Sua_kichban.Click += new System.EventHandler(ctx_Sua_kichban_Click);
			ctx_Delete_kichban.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_Delete_kichban.Image = (System.Drawing.Image)resources.GetObject("ctx_Delete_kichban.Image");
			ctx_Delete_kichban.Name = "ctx_Delete_kichban";
			ctx_Delete_kichban.Size = new System.Drawing.Size(140, 22);
			ctx_Delete_kichban.Text = "Delete script";
			ctx_Delete_kichban.Click += new System.EventHandler(ctx_Delete_kichban_Click);
			ctxmain_1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { ctx_ThemHanhDong, ctx_Sua_hanhdong, ctx_Delete_hanhdong });
			ctxmain_1.Name = "ctxmain";
			ctxmain_1.Size = new System.Drawing.Size(137, 70);
			ctx_ThemHanhDong.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_ThemHanhDong.Image = (System.Drawing.Image)resources.GetObject("ctx_ThemHanhDong.Image");
			ctx_ThemHanhDong.Name = "ctx_ThemHanhDong";
			ctx_ThemHanhDong.Size = new System.Drawing.Size(136, 22);
			ctx_ThemHanhDong.Text = "Add action";
			ctx_ThemHanhDong.Click += new System.EventHandler(ctx_ThemHanhDong_Click);
			ctx_Sua_hanhdong.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_Sua_hanhdong.Image = (System.Drawing.Image)resources.GetObject("ctx_Sua_hanhdong.Image");
			ctx_Sua_hanhdong.Name = "ctx_Sua_hanhdong";
			ctx_Sua_hanhdong.Size = new System.Drawing.Size(136, 22);
			ctx_Sua_hanhdong.Text = "Edit action";
			ctx_Sua_hanhdong.Click += new System.EventHandler(ctx_Sua_hanhdong_Click);
			ctx_Delete_hanhdong.Font = new System.Drawing.Font("Segoe UI Semibold", 9f);
			ctx_Delete_hanhdong.Image = (System.Drawing.Image)resources.GetObject("ctx_Delete_hanhdong.Image");
			ctx_Delete_hanhdong.Name = "ctx_Delete_hanhdong";
			ctx_Delete_hanhdong.Size = new System.Drawing.Size(136, 22);
			ctx_Delete_hanhdong.Text = "Clear action";
			ctx_Delete_hanhdong.Click += new System.EventHandler(ctx_Delete_hanhdong_Click);
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(398, 370);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 129;
			btnCancel.Text = "Close";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btn_CancelTT_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(289, 370);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 128;
			btnAdd.Text = "Save";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btn_okTT_Click);
			cb_SDProfile.AutoSize = true;
			cb_SDProfile.Location = new System.Drawing.Point(15, 198);
			cb_SDProfile.Name = "cb_SDProfile";
			cb_SDProfile.Size = new System.Drawing.Size(87, 19);
			cb_SDProfile.TabIndex = 231;
			cb_SDProfile.Text = "Path Profile";
			cb_SDProfile.UseVisualStyleBackColor = true;
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			label10.Location = new System.Drawing.Point(249, 160);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(14, 15);
			label10.TabIndex = 230;
			label10.Text = "X";
			num_ChromeY.Location = new System.Drawing.Point(274, 155);
			num_ChromeY.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
			num_ChromeY.Name = "num_ChromeY";
			num_ChromeY.Size = new System.Drawing.Size(59, 23);
			num_ChromeY.TabIndex = 229;
			num_ChromeY.Value = new decimal(new int[4] { 2, 0, 0, 0 });
			num_ChromeX.Location = new System.Drawing.Point(174, 155);
			num_ChromeX.Maximum = new decimal(new int[4] { 30, 0, 0, 0 });
			num_ChromeX.Name = "num_ChromeX";
			num_ChromeX.Size = new System.Drawing.Size(59, 23);
			num_ChromeX.TabIndex = 228;
			num_ChromeX.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(11, 157);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(154, 15);
			label1.TabIndex = 227;
			label1.Text = "Arrange a Chrome window :";
			rad_EN.AutoSize = true;
			rad_EN.Checked = true;
			rad_EN.Location = new System.Drawing.Point(159, 121);
			rad_EN.Name = "rad_EN";
			rad_EN.Size = new System.Drawing.Size(40, 19);
			rad_EN.TabIndex = 226;
			rad_EN.TabStop = true;
			rad_EN.Text = "EN";
			rad_EN.UseVisualStyleBackColor = true;
			rad_VI.AutoSize = true;
			rad_VI.Location = new System.Drawing.Point(96, 120);
			rad_VI.Name = "rad_VI";
			rad_VI.Size = new System.Drawing.Size(37, 19);
			rad_VI.TabIndex = 225;
			rad_VI.Text = "VI";
			rad_VI.UseVisualStyleBackColor = true;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(11, 121);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(68, 15);
			label9.TabIndex = 224;
			label9.Text = "Language : ";
			txt_cookiecheck.Location = new System.Drawing.Point(130, 232);
			txt_cookiecheck.Name = "txt_cookiecheck";
			txt_cookiecheck.Size = new System.Drawing.Size(203, 23);
			txt_cookiecheck.TabIndex = 223;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(12, 235);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(108, 15);
			label5.TabIndex = 222;
			label5.Text = "Cookie Check Live :";
			cb_checkTT.AutoSize = true;
			cb_checkTT.Location = new System.Drawing.Point(15, 270);
			cb_checkTT.Name = "cb_checkTT";
			cb_checkTT.Size = new System.Drawing.Size(208, 19);
			cb_checkTT.TabIndex = 221;
			cb_checkTT.Text = "Check Information When Running";
			cb_checkTT.UseVisualStyleBackColor = true;
			txt_PathProfile.Location = new System.Drawing.Point(130, 194);
			txt_PathProfile.Name = "txt_PathProfile";
			txt_PathProfile.Size = new System.Drawing.Size(203, 23);
			txt_PathProfile.TabIndex = 220;
			cb_addform.AutoSize = true;
			cb_addform.Location = new System.Drawing.Point(15, 304);
			cb_addform.Name = "cb_addform";
			cb_addform.Size = new System.Drawing.Size(162, 19);
			cb_addform.TabIndex = 232;
			cb_addform.Text = "Add Chrome in form view";
			cb_addform.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(772, 412);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox3);
			base.Controls.Add(groupBox1);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			ForeColor = System.Drawing.SystemColors.ControlText;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "CauHinhTuongTac";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Interactive Configuration";
			base.Load += new System.EventHandler(CauHinhTuongTac_Load);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)num_ThreadTimeout_TimeMax).EndInit();
			((System.ComponentModel.ISupportInitialize)num_ThreadTimeout_TimeMin).EndInit();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgv_KichBan).EndInit();
			groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgv_HanhDong).EndInit();
			ctxmain.ResumeLayout(false);
			ctxmain_1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)num_ChromeY).EndInit();
			((System.ComponentModel.ISupportInitialize)num_ChromeX).EndInit();
			ResumeLayout(false);
		}
	}
}
