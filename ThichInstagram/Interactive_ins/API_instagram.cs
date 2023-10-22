using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InstagramApiSharp.API;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;

namespace Interactive_ins
{
	public class API_instagram
	{
		private ThongTin thongtin = null;

		public int dem = 0;

		public static string path_Follow = "data\\Following.txt";

		public static string path_img = "img";

		public static string path_imgAvt = "img avt";

		private IInstaApi api { get; set; }

		public API_instagram(ThongTin thongtin)
		{
			this.thongtin = thongtin;
		}

		private void Creat_IInstaApi(string proxy)
		{
			UserSessionData userSessionData = new UserSessionData
			{
				UserName = thongtin.User,
				Password = thongtin.Pass
			};
		}

		public async Task<bool> Login_cookie(string proxy = null)
		{
			if (string.IsNullOrEmpty(thongtin.cookie))
			{
				return false;
			}
			Creat_IInstaApi(proxy);
			return (await api.LoginWithCookiesAsync(thongtin.cookie)).Succeeded;
		}

		public async Task<bool> Login_user(string proxy = null)
		{
			Creat_IInstaApi(proxy);
			return (await api.LoginAsync()).Succeeded;
		}

		public async Task<bool> Check_Live(List<ThongTin> thongtin)
		{
			if (!(await Login_cookie()) && !(await Login_user()))
			{
				return false;
			}
			foreach (ThongTin item in thongtin)
			{
				LayThongTin(item);
			}
			return true;
		}

		private async Task<ThongTin> LayThongTin(ThongTin thongtin)
		{
			new SQLite();
			IResult<InstaUserInfo> result = await api.UserProcessor.GetUserInfoByUsernameAsync(thongtin.User);
			if (result.Succeeded)
			{
				thongtin.User = result.Value.Username;
				thongtin.FullName = result.Value.FullName;
				thongtin.ID = result.Value.Pk.ToString();
				thongtin.Avatar = (string.IsNullOrEmpty(result.Value.ProfilePicId) ? "Không" : "Có");
				thongtin.BaiViet = result.Value.MediaCount.ToString();
				thongtin.Following = result.Value.FollowingCount.ToString();
				thongtin.TinhTrang = "Live !";
				thongtin.TrangThai = result.Info.Message;
				thongtin.Color = 1;
			}
			else
			{
				thongtin.TinhTrang = "Not Live !";
				thongtin.TrangThai = result.Info.Message;
				thongtin.Color = 0;
			}
			dem++;
			Form1.remote.Change_Row(thongtin);
			return thongtin;
		}

		public async Task<bool> DichVuIns(ThongTin thongtin)
		{
			new SQLite();
			thongtin.TrangThai = "Tiến trình đang chạy !";
			Form1.remote.Change_Row(thongtin);
			if (!(await Login_cookie(thongtin.proxy)) && !(await Login_user(thongtin.proxy)))
			{
				thongtin.TrangThai = "Không đăng nhập được kiểm tra lại !";
				Form1.remote.Change_Row(thongtin);
				return false;
			}
			thongtin.TinhTrang = "Live !";
			thongtin.Color = 1;
			return true;
		}

		private async Task<IResult<InstaMedia>> InsertImage(string path)
		{
			InstaImageUpload mediaImage = new InstaImageUpload
			{
				Height = 1080,
				Width = 1080,
				Uri = new Uri(Path.GetFullPath(path), UriKind.Absolute).LocalPath
			};
			return await api.MediaProcessor.UploadPhotoAsync(mediaImage, "<3 <3 <3 ... !");
		}

		private async Task<IResult<InstaFriendshipFullStatus>> following(string ID)
		{
			return await api.UserProcessor.FollowUserAsync(long.Parse(ID));
		}

		private async Task<IResult<InstaUserEdit>> change_avt(string path)
		{
			byte[] pictureBytes = File.ReadAllBytes(path);
			return await api.AccountProcessor.ChangeProfilePictureAsync(pictureBytes);
		}

		public static string Name_Img(string folder_img)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(folder_img);
			FileInfo[] files = directoryInfo.GetFiles();
			Random random = new Random();
			return files[random.Next(0, files.Length)].FullName;
		}

		private string ID()
		{
			string text = null;
			Random random = new Random();
			string[] array = File.ReadAllLines(path_Follow);
			while (string.IsNullOrEmpty(text))
			{
				text = array[random.Next(0, array.Count())].Trim();
			}
			return text;
		}
	}
}
