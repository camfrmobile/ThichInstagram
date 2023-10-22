using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Interactive_ins.Properties;

namespace Interactive_ins
{
	public class fHanhDong : Form
	{
		private string ID_KichBan = null;

		private IContainer components = null;

		private GroupBox gr_tuongtac_mess;

		private Button btn_TTNewsfeed;

		private Button btn_TTFollowing;

		private Button btn_TTFollowers;

		private Button btn_TTMess;

		private Button btn_TTStory;

		private Button btn_MessFollowing;

		private Button btn_MessFollowers;

		private Button btn_MessUser;

		private GroupBox gr_Spam_Seeding;

		private Button btn_ShareViet;

		private Button btn_SpamBaiViet;

		private GroupBox gr_Follow;

		private Button btn_UnFollow;

		private Button btn_FollowFollowing_User;

		private Button btn_FollowFollower_User;

		private Button btn_FollowUserLikePost;

		private Button btn_FollowFollower;

		private Button btn_FollowUser;

		private Button btn_FollowKey;

		private Button btn_FollowGoiY;

		private GroupBox groupBox1;

		private Button btn_Post;

		private Button btn_ChangeThongTin;

		private PictureBox pictureBox1;

		private PictureBox pictureBox2;

		private PictureBox pictureBox3;

		private PictureBox pictureBox4;

		private Button btn_ReplyCmt;

		public fHanhDong(string ID_KichBan)
		{
			InitializeComponent();
			this.ID_KichBan = ID_KichBan;
		}

		private void btn_TTNewsfeed_Click(object sender, EventArgs e)
		{
			TuongTacNewsfeed tuongTacNewsfeed = new TuongTacNewsfeed(ID_KichBan);
			tuongTacNewsfeed.ShowDialog();
		}

		private void btn_TTFollowers_Click(object sender, EventArgs e)
		{
			TuongTacFollowers tuongTacFollowers = new TuongTacFollowers(ID_KichBan);
			tuongTacFollowers.ShowDialog();
		}

		private void btn_TTFollowing_Click(object sender, EventArgs e)
		{
			TuongTacFollowing tuongTacFollowing = new TuongTacFollowing(ID_KichBan);
			tuongTacFollowing.ShowDialog();
		}

		private void btn_MessUser_Click(object sender, EventArgs e)
		{
			NhanTinTheoUser nhanTinTheoUser = new NhanTinTheoUser(ID_KichBan);
			nhanTinTheoUser.ShowDialog();
		}

		private void btn_MessFollowers_Click(object sender, EventArgs e)
		{
			NhanTinVoiFollowers nhanTinVoiFollowers = new NhanTinVoiFollowers(ID_KichBan);
			nhanTinVoiFollowers.ShowDialog();
		}

		private void btn_MessFollowing_Click(object sender, EventArgs e)
		{
			NhanTinVoiFollowing nhanTinVoiFollowing = new NhanTinVoiFollowing(ID_KichBan);
			nhanTinVoiFollowing.ShowDialog();
		}

		private void btn_TTMess_Click(object sender, EventArgs e)
		{
			TuongTacTinNhan tuongTacTinNhan = new TuongTacTinNhan(ID_KichBan);
			tuongTacTinNhan.ShowDialog();
		}

		private void btn_TTStory_Click(object sender, EventArgs e)
		{
			CauHinhLuotStory cauHinhLuotStory = new CauHinhLuotStory(ID_KichBan);
			cauHinhLuotStory.ShowDialog();
		}

		private void btn_SpamBaiViet_Click(object sender, EventArgs e)
		{
			CauHinhSpam cauHinhSpam = new CauHinhSpam(ID_KichBan);
			cauHinhSpam.ShowDialog();
		}

		private void btn_ShareViet_Click(object sender, EventArgs e)
		{
			ShareBaiViet shareBaiViet = new ShareBaiViet(ID_KichBan);
			shareBaiViet.ShowDialog();
		}

		private void btn_FollowGoiY_Click(object sender, EventArgs e)
		{
			FollowGoiY followGoiY = new FollowGoiY(ID_KichBan);
			followGoiY.ShowDialog();
		}

		private void btn_FollowKey_Click(object sender, EventArgs e)
		{
			FollowTuKhoa followTuKhoa = new FollowTuKhoa(ID_KichBan);
			followTuKhoa.ShowDialog();
		}

		private void btn_FollowUser_Click(object sender, EventArgs e)
		{
			FollowUser followUser = new FollowUser(ID_KichBan);
			followUser.ShowDialog();
		}

		private void btn_FollowFollower_Click(object sender, EventArgs e)
		{
			FollowLaiFollowers followLaiFollowers = new FollowLaiFollowers(ID_KichBan);
			followLaiFollowers.ShowDialog();
		}

		private void btn_FollowUserLikePost_Click(object sender, EventArgs e)
		{
			FollowUserLikePost followUserLikePost = new FollowUserLikePost(ID_KichBan);
			followUserLikePost.ShowDialog();
		}

		private void btn_FollowFollower_User_Click(object sender, EventArgs e)
		{
			FollowFollowerUser followFollowerUser = new FollowFollowerUser(ID_KichBan);
			followFollowerUser.ShowDialog();
		}

		private void btn_FollowFollowing_User_Click(object sender, EventArgs e)
		{
			FollowFollowingUser followFollowingUser = new FollowFollowingUser(ID_KichBan);
			followFollowingUser.ShowDialog();
		}

		private void btn_UnFollow_Click(object sender, EventArgs e)
		{
			UnFollow unFollow = new UnFollow(ID_KichBan);
			unFollow.ShowDialog();
		}

		private void fHanhDong_Load(object sender, EventArgs e)
		{
			if (ThongSo_CauHinhTuongTac.rad_VI)
			{
				btn_TTNewsfeed.Text = "Tương tác Newsfeed";
				btn_TTFollowers.Text = "Tương tác Followers";
				btn_TTFollowing.Text = "Tương tác Following";
				btn_MessUser.Text = "Nhắn tin Users";
				btn_MessFollowers.Text = "Nhắn tin Followers";
				btn_MessFollowing.Text = "Nhắn tin Following";
				btn_TTMess.Text = "Trả lời tin nhắn";
				btn_TTStory.Text = "Lướt Story";
				btn_ShareViet.Text = "Chia sẻ bài viết";
				btn_FollowGoiY.Text = "Follow theo đề xuất";
				btn_FollowKey.Text = "Follow theo keyword";
				btn_FollowUser.Text = "Follow theo Users";
				btn_FollowFollower.Text = "Follow lại Follower";
				btn_FollowUserLikePost.Text = "Follow User like bài viết";
				btn_FollowFollower_User.Text = "Follow Followers của User";
				btn_FollowFollowing_User.Text = "Follow Following của User";
				btn_UnFollow.Text = "Bỏ Follow";
				btn_ChangeThongTin.Text = "Chỉnh sửa thông tin";
			}
		}

		private void btn_ChangeThongTin_Click(object sender, EventArgs e)
		{
			Change_profile change_profile = new Change_profile(ID_KichBan);
			change_profile.ShowDialog();
		}

		private void btn_Post_Click(object sender, EventArgs e)
		{
			Post post = new Post(ID_KichBan);
			post.ShowDialog();
		}

		private void gr_tuongtac_mess_Enter(object sender, EventArgs e)
		{
		}

		private void btn_ReplyCmt_Click(object sender, EventArgs e)
		{
			ReplyCMT replyCMT = new ReplyCMT(ID_KichBan);
			replyCMT.ShowDialog();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interactive_ins.fHanhDong));
			gr_tuongtac_mess = new System.Windows.Forms.GroupBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btn_TTMess = new System.Windows.Forms.Button();
			btn_TTStory = new System.Windows.Forms.Button();
			btn_MessFollowing = new System.Windows.Forms.Button();
			btn_MessFollowers = new System.Windows.Forms.Button();
			btn_MessUser = new System.Windows.Forms.Button();
			btn_TTFollowing = new System.Windows.Forms.Button();
			btn_TTFollowers = new System.Windows.Forms.Button();
			btn_TTNewsfeed = new System.Windows.Forms.Button();
			gr_Spam_Seeding = new System.Windows.Forms.GroupBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			btn_ShareViet = new System.Windows.Forms.Button();
			btn_SpamBaiViet = new System.Windows.Forms.Button();
			gr_Follow = new System.Windows.Forms.GroupBox();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			btn_UnFollow = new System.Windows.Forms.Button();
			btn_FollowFollowing_User = new System.Windows.Forms.Button();
			btn_FollowFollower_User = new System.Windows.Forms.Button();
			btn_FollowUserLikePost = new System.Windows.Forms.Button();
			btn_FollowFollower = new System.Windows.Forms.Button();
			btn_FollowUser = new System.Windows.Forms.Button();
			btn_FollowKey = new System.Windows.Forms.Button();
			btn_FollowGoiY = new System.Windows.Forms.Button();
			groupBox1 = new System.Windows.Forms.GroupBox();
			pictureBox4 = new System.Windows.Forms.PictureBox();
			btn_Post = new System.Windows.Forms.Button();
			btn_ChangeThongTin = new System.Windows.Forms.Button();
			btn_ReplyCmt = new System.Windows.Forms.Button();
			gr_tuongtac_mess.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			gr_Spam_Seeding.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			gr_Follow.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			SuspendLayout();
			gr_tuongtac_mess.Controls.Add(pictureBox1);
			gr_tuongtac_mess.Controls.Add(btn_TTMess);
			gr_tuongtac_mess.Controls.Add(btn_TTStory);
			gr_tuongtac_mess.Controls.Add(btn_MessFollowing);
			gr_tuongtac_mess.Controls.Add(btn_MessFollowers);
			gr_tuongtac_mess.Controls.Add(btn_MessUser);
			gr_tuongtac_mess.Controls.Add(btn_TTFollowing);
			gr_tuongtac_mess.Controls.Add(btn_TTFollowers);
			gr_tuongtac_mess.Controls.Add(btn_TTNewsfeed);
			gr_tuongtac_mess.ImeMode = System.Windows.Forms.ImeMode.On;
			gr_tuongtac_mess.Location = new System.Drawing.Point(12, 12);
			gr_tuongtac_mess.Name = "gr_tuongtac_mess";
			gr_tuongtac_mess.Size = new System.Drawing.Size(217, 408);
			gr_tuongtac_mess.TabIndex = 0;
			gr_tuongtac_mess.TabStop = false;
			gr_tuongtac_mess.Text = "Interactive - Message";
			gr_tuongtac_mess.Enter += new System.EventHandler(gr_tuongtac_mess_Enter);
			pictureBox1.Image = Interactive_ins.Properties.Resources.pasted_image_0;
			pictureBox1.Location = new System.Drawing.Point(18, 22);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(181, 107);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 8;
			pictureBox1.TabStop = false;
			btn_TTMess.Location = new System.Drawing.Point(18, 326);
			btn_TTMess.Name = "btn_TTMess";
			btn_TTMess.Size = new System.Drawing.Size(181, 23);
			btn_TTMess.TabIndex = 7;
			btn_TTMess.Text = "Reply The Message";
			btn_TTMess.UseVisualStyleBackColor = true;
			btn_TTMess.Click += new System.EventHandler(btn_TTMess_Click);
			btn_TTStory.Location = new System.Drawing.Point(18, 355);
			btn_TTStory.Name = "btn_TTStory";
			btn_TTStory.Size = new System.Drawing.Size(181, 23);
			btn_TTStory.TabIndex = 6;
			btn_TTStory.Text = "View Story";
			btn_TTStory.UseVisualStyleBackColor = true;
			btn_TTStory.Click += new System.EventHandler(btn_TTStory_Click);
			btn_MessFollowing.Location = new System.Drawing.Point(18, 297);
			btn_MessFollowing.Name = "btn_MessFollowing";
			btn_MessFollowing.Size = new System.Drawing.Size(181, 23);
			btn_MessFollowing.TabIndex = 5;
			btn_MessFollowing.Text = "Message Following";
			btn_MessFollowing.UseVisualStyleBackColor = true;
			btn_MessFollowing.Click += new System.EventHandler(btn_MessFollowing_Click);
			btn_MessFollowers.Location = new System.Drawing.Point(18, 268);
			btn_MessFollowers.Name = "btn_MessFollowers";
			btn_MessFollowers.Size = new System.Drawing.Size(181, 23);
			btn_MessFollowers.TabIndex = 4;
			btn_MessFollowers.Text = "Message Followers";
			btn_MessFollowers.UseVisualStyleBackColor = true;
			btn_MessFollowers.Click += new System.EventHandler(btn_MessFollowers_Click);
			btn_MessUser.Location = new System.Drawing.Point(18, 239);
			btn_MessUser.Name = "btn_MessUser";
			btn_MessUser.Size = new System.Drawing.Size(181, 23);
			btn_MessUser.TabIndex = 3;
			btn_MessUser.Text = "Message Users";
			btn_MessUser.UseVisualStyleBackColor = true;
			btn_MessUser.Click += new System.EventHandler(btn_MessUser_Click);
			btn_TTFollowing.Location = new System.Drawing.Point(18, 210);
			btn_TTFollowing.Name = "btn_TTFollowing";
			btn_TTFollowing.Size = new System.Drawing.Size(181, 23);
			btn_TTFollowing.TabIndex = 2;
			btn_TTFollowing.Text = "Interactive Following";
			btn_TTFollowing.UseVisualStyleBackColor = true;
			btn_TTFollowing.Click += new System.EventHandler(btn_TTFollowing_Click);
			btn_TTFollowers.Location = new System.Drawing.Point(18, 181);
			btn_TTFollowers.Name = "btn_TTFollowers";
			btn_TTFollowers.Size = new System.Drawing.Size(181, 23);
			btn_TTFollowers.TabIndex = 1;
			btn_TTFollowers.Text = "Interactive Followers";
			btn_TTFollowers.UseVisualStyleBackColor = true;
			btn_TTFollowers.Click += new System.EventHandler(btn_TTFollowers_Click);
			btn_TTNewsfeed.ForeColor = System.Drawing.Color.DarkRed;
			btn_TTNewsfeed.Location = new System.Drawing.Point(18, 152);
			btn_TTNewsfeed.Name = "btn_TTNewsfeed";
			btn_TTNewsfeed.Size = new System.Drawing.Size(181, 23);
			btn_TTNewsfeed.TabIndex = 0;
			btn_TTNewsfeed.Text = "Interactive Newsfeed";
			btn_TTNewsfeed.UseVisualStyleBackColor = true;
			btn_TTNewsfeed.Click += new System.EventHandler(btn_TTNewsfeed_Click);
			gr_Spam_Seeding.Controls.Add(btn_ReplyCmt);
			gr_Spam_Seeding.Controls.Add(pictureBox2);
			gr_Spam_Seeding.Controls.Add(btn_ShareViet);
			gr_Spam_Seeding.Controls.Add(btn_SpamBaiViet);
			gr_Spam_Seeding.Location = new System.Drawing.Point(235, 12);
			gr_Spam_Seeding.Name = "gr_Spam_Seeding";
			gr_Spam_Seeding.Size = new System.Drawing.Size(217, 408);
			gr_Spam_Seeding.TabIndex = 7;
			gr_Spam_Seeding.TabStop = false;
			gr_Spam_Seeding.Text = "Spam - Seeding";
			pictureBox2.Image = Interactive_ins.Properties.Resources.images;
			pictureBox2.Location = new System.Drawing.Point(19, 22);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(181, 107);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 9;
			pictureBox2.TabStop = false;
			btn_ShareViet.Location = new System.Drawing.Point(19, 210);
			btn_ShareViet.Name = "btn_ShareViet";
			btn_ShareViet.Size = new System.Drawing.Size(181, 23);
			btn_ShareViet.TabIndex = 1;
			btn_ShareViet.Text = "Share Posts";
			btn_ShareViet.UseVisualStyleBackColor = true;
			btn_ShareViet.Click += new System.EventHandler(btn_ShareViet_Click);
			btn_SpamBaiViet.ForeColor = System.Drawing.Color.DarkRed;
			btn_SpamBaiViet.Location = new System.Drawing.Point(19, 152);
			btn_SpamBaiViet.Name = "btn_SpamBaiViet";
			btn_SpamBaiViet.Size = new System.Drawing.Size(181, 23);
			btn_SpamBaiViet.TabIndex = 0;
			btn_SpamBaiViet.Text = "Spam Posts User";
			btn_SpamBaiViet.UseVisualStyleBackColor = true;
			btn_SpamBaiViet.Click += new System.EventHandler(btn_SpamBaiViet_Click);
			gr_Follow.Controls.Add(pictureBox3);
			gr_Follow.Controls.Add(btn_UnFollow);
			gr_Follow.Controls.Add(btn_FollowFollowing_User);
			gr_Follow.Controls.Add(btn_FollowFollower_User);
			gr_Follow.Controls.Add(btn_FollowUserLikePost);
			gr_Follow.Controls.Add(btn_FollowFollower);
			gr_Follow.Controls.Add(btn_FollowUser);
			gr_Follow.Controls.Add(btn_FollowKey);
			gr_Follow.Controls.Add(btn_FollowGoiY);
			gr_Follow.Location = new System.Drawing.Point(458, 12);
			gr_Follow.Name = "gr_Follow";
			gr_Follow.Size = new System.Drawing.Size(217, 408);
			gr_Follow.TabIndex = 7;
			gr_Follow.TabStop = false;
			gr_Follow.Text = "Follow";
			pictureBox3.Image = Interactive_ins.Properties.Resources.follow_por_follow;
			pictureBox3.Location = new System.Drawing.Point(18, 22);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(181, 107);
			pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox3.TabIndex = 10;
			pictureBox3.TabStop = false;
			btn_UnFollow.Location = new System.Drawing.Point(18, 355);
			btn_UnFollow.Name = "btn_UnFollow";
			btn_UnFollow.Size = new System.Drawing.Size(181, 23);
			btn_UnFollow.TabIndex = 7;
			btn_UnFollow.Text = "UnFollow";
			btn_UnFollow.UseVisualStyleBackColor = true;
			btn_UnFollow.Click += new System.EventHandler(btn_UnFollow_Click);
			btn_FollowFollowing_User.Location = new System.Drawing.Point(18, 326);
			btn_FollowFollowing_User.Name = "btn_FollowFollowing_User";
			btn_FollowFollowing_User.Size = new System.Drawing.Size(181, 23);
			btn_FollowFollowing_User.TabIndex = 6;
			btn_FollowFollowing_User.Text = "Follow user's following";
			btn_FollowFollowing_User.UseVisualStyleBackColor = true;
			btn_FollowFollowing_User.Click += new System.EventHandler(btn_FollowFollowing_User_Click);
			btn_FollowFollower_User.Location = new System.Drawing.Point(18, 297);
			btn_FollowFollower_User.Name = "btn_FollowFollower_User";
			btn_FollowFollower_User.Size = new System.Drawing.Size(181, 23);
			btn_FollowFollower_User.TabIndex = 5;
			btn_FollowFollower_User.Text = "Follow user's followers";
			btn_FollowFollower_User.UseVisualStyleBackColor = true;
			btn_FollowFollower_User.Click += new System.EventHandler(btn_FollowFollower_User_Click);
			btn_FollowUserLikePost.Location = new System.Drawing.Point(18, 268);
			btn_FollowUserLikePost.Name = "btn_FollowUserLikePost";
			btn_FollowUserLikePost.Size = new System.Drawing.Size(181, 23);
			btn_FollowUserLikePost.TabIndex = 4;
			btn_FollowUserLikePost.Text = "Follow user like post";
			btn_FollowUserLikePost.UseVisualStyleBackColor = true;
			btn_FollowUserLikePost.Click += new System.EventHandler(btn_FollowUserLikePost_Click);
			btn_FollowFollower.Location = new System.Drawing.Point(18, 239);
			btn_FollowFollower.Name = "btn_FollowFollower";
			btn_FollowFollower.Size = new System.Drawing.Size(181, 23);
			btn_FollowFollower.TabIndex = 3;
			btn_FollowFollower.Text = "Follow back Followers";
			btn_FollowFollower.UseVisualStyleBackColor = true;
			btn_FollowFollower.Click += new System.EventHandler(btn_FollowFollower_Click);
			btn_FollowUser.Location = new System.Drawing.Point(18, 210);
			btn_FollowUser.Name = "btn_FollowUser";
			btn_FollowUser.Size = new System.Drawing.Size(181, 23);
			btn_FollowUser.TabIndex = 2;
			btn_FollowUser.Text = "Follow by user";
			btn_FollowUser.UseVisualStyleBackColor = true;
			btn_FollowUser.Click += new System.EventHandler(btn_FollowUser_Click);
			btn_FollowKey.Location = new System.Drawing.Point(18, 181);
			btn_FollowKey.Name = "btn_FollowKey";
			btn_FollowKey.Size = new System.Drawing.Size(181, 23);
			btn_FollowKey.TabIndex = 1;
			btn_FollowKey.Text = "Follow by keyword";
			btn_FollowKey.UseVisualStyleBackColor = true;
			btn_FollowKey.Click += new System.EventHandler(btn_FollowKey_Click);
			btn_FollowGoiY.ForeColor = System.Drawing.Color.DarkRed;
			btn_FollowGoiY.Location = new System.Drawing.Point(18, 152);
			btn_FollowGoiY.Name = "btn_FollowGoiY";
			btn_FollowGoiY.Size = new System.Drawing.Size(181, 23);
			btn_FollowGoiY.TabIndex = 0;
			btn_FollowGoiY.Text = "Follow suggestions ";
			btn_FollowGoiY.UseVisualStyleBackColor = true;
			btn_FollowGoiY.Click += new System.EventHandler(btn_FollowGoiY_Click);
			groupBox1.Controls.Add(pictureBox4);
			groupBox1.Controls.Add(btn_Post);
			groupBox1.Controls.Add(btn_ChangeThongTin);
			groupBox1.Location = new System.Drawing.Point(681, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(217, 408);
			groupBox1.TabIndex = 8;
			groupBox1.TabStop = false;
			groupBox1.Text = "Other function";
			pictureBox4.Image = Interactive_ins.Properties.Resources.blue_fiction_ebooks_new_content_arts___entertainment_facebook_post__2__4747791907ef4b929ed2f1a184da2d54_1024x1024;
			pictureBox4.Location = new System.Drawing.Point(17, 22);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new System.Drawing.Size(181, 107);
			pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox4.TabIndex = 11;
			pictureBox4.TabStop = false;
			btn_Post.Location = new System.Drawing.Point(17, 181);
			btn_Post.Name = "btn_Post";
			btn_Post.Size = new System.Drawing.Size(181, 23);
			btn_Post.TabIndex = 1;
			btn_Post.Text = "Post";
			btn_Post.UseVisualStyleBackColor = true;
			btn_Post.Click += new System.EventHandler(btn_Post_Click);
			btn_ChangeThongTin.ForeColor = System.Drawing.Color.DarkRed;
			btn_ChangeThongTin.Location = new System.Drawing.Point(17, 152);
			btn_ChangeThongTin.Name = "btn_ChangeThongTin";
			btn_ChangeThongTin.Size = new System.Drawing.Size(181, 23);
			btn_ChangeThongTin.TabIndex = 0;
			btn_ChangeThongTin.Text = "Edit information";
			btn_ChangeThongTin.UseVisualStyleBackColor = true;
			btn_ChangeThongTin.Click += new System.EventHandler(btn_ChangeThongTin_Click);
			btn_ReplyCmt.ForeColor = System.Drawing.Color.Black;
			btn_ReplyCmt.Location = new System.Drawing.Point(19, 181);
			btn_ReplyCmt.Name = "btn_ReplyCmt";
			btn_ReplyCmt.Size = new System.Drawing.Size(181, 23);
			btn_ReplyCmt.TabIndex = 10;
			btn_ReplyCmt.Text = "Reply Comment";
			btn_ReplyCmt.UseVisualStyleBackColor = true;
			btn_ReplyCmt.Click += new System.EventHandler(btn_ReplyCmt_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(911, 432);
			base.Controls.Add(groupBox1);
			base.Controls.Add(gr_Follow);
			base.Controls.Add(gr_Spam_Seeding);
			base.Controls.Add(gr_tuongtac_mess);
			Font = new System.Drawing.Font("Segoe UI Semibold", 8.5f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "fHanhDong";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Instagram interaction function";
			base.Load += new System.EventHandler(fHanhDong_Load);
			gr_tuongtac_mess.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			gr_Spam_Seeding.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			gr_Follow.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			ResumeLayout(false);
		}
	}
}
