using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Interactive_ins
{
	public static class Load_file
	{
		public static string path_CauHinhDoiIP = Has.DecryptHas("C7GS88Z2TCGaSyH8/GMxJQ==", useHasing: true, "zmaoo4lz06t7");

		public static string path_CauHinhTuongTac = Has.DecryptHas("4vUqq9GXj1sFFkb9ASVkSg==", useHasing: true, "cbh2w");

		public static string path_Cauhinhhienthi = Has.DecryptHas("o/KafzTr6JQnBs92XA30Fg==", useHasing: true, "cbh2w");

		public static string path_SettingCP = Has.DeCryptWithKey("gUSI+irhy3zrjMVK3fjZXA==", "p4gxfcu00");

		public static string path_Setting_FB = Has.DeCryptWithKey("1qYKW6FWnpukKC3Mi26vNA==", "2tncnb01zkz5");

		public static List<Thongso_HanhDong> Load_hanhdong()
		{
			interact_sql interact_sql2 = new interact_sql();
			DataTable dataTable = interact_sql2.LoadData_HanhDong();
			List<Thongso_HanhDong> list = new List<Thongso_HanhDong>();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow = dataTable.Rows[i];
				if (!(ThongSo_CauHinhTuongTac.TT_KichBan.ID_KichBan != dataRow[Has.DecryptHas("sBAyrMGmwg3xIOduI1+g6Q==", useHasing: true, "cbh2w")].ToString()))
				{
					list.Add(new Thongso_HanhDong
					{
						ID_HanhDong = dataRow[Has.DecryptHas("4B5U+365bzx0S8Kv2tL2bQ==", useHasing: true, "cbh2w")].ToString(),
						ID_KichBan = dataRow[Has.DecryptHas("sBAyrMGmwg3xIOduI1+g6Q==", useHasing: true, "cbh2w")].ToString(),
						Ma_HanhDong = (tt_kk._key.Contains(Has.DecryptHas("K87p8tBCBQQ=", useHasing: true, "cbh2w")) ? int.Parse(dataRow[Has.DecryptHas("OFMN/vzyTAh0S8Kv2tL2bQ==", useHasing: true, "cbh2w")].ToString()) : 50),
						TenHanhDong = dataRow[Has.DecryptHas("WxcAq1M9f7Z0S8Kv2tL2bQ==", useHasing: true, "cbh2w")].ToString(),
						CauHinh = dataRow[Has.DecryptHas("PIiRusz60aU=", useHasing: true, "p0nh43x1z")].ToString()
					});
				}
			}
			return list;
		}

		public static void Load_thongso(Thongso_HanhDong Thongso_HanhDong)
		{
			JSON_Settings jSON_Settings = new JSON_Settings(Thongso_HanhDong.CauHinh, isJsonString: true);
			switch (Thongso_HanhDong.Ma_HanhDong)
			{
			case 0:
				ThongSo_TuongTacNewsfeed.cb_TTNewsfeed_Cmt = jSON_Settings.GetValueBool(Has.DecryptHas("zG4D/fJhIZ32DQAvL9DlGK4IFm56iSe9", useHasing: true, "gp4cz8"));
				ThongSo_TuongTacNewsfeed.cb_TTNewsfeed_Like = jSON_Settings.GetValueBool(Has.DecryptHas("zG4D/fJhIZ1jSSk9XwtSajoCxc14Hg7m", useHasing: true, "gp4cz8"));
				ThongSo_TuongTacNewsfeed.num_TTNewsfeed_CmtMax = jSON_Settings.GetValueInt(Has.DecryptHas("pNctmFPJBXu7tU0W/+GKZ5xkvXax8iM3", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacNewsfeed.num_TTNewsfeed_CmtMin = jSON_Settings.GetValueInt(Has.DecryptHas("pNctmFPJBXu7tU0W/+GKZ5UxWAtfF3On", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacNewsfeed.num_TTNewsfeed_LikeMax = jSON_Settings.GetValueInt(Has.DecryptHas("pNctmFPJBXtzvTPawzI5LQeWuNsFBYun", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacNewsfeed.num_TTNewsfeed_LikeMin = jSON_Settings.GetValueInt(Has.DecryptHas("pNctmFPJBXtzvTPawzI5LdUVr0vgk60E", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacNewsfeed.num_TTNewsfeed_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("pNctmFPJBXt7Dlka/O5WKevy6CaF9Vzb", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacNewsfeed.num_TTNewsfeed_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("pNctmFPJBXt7Dlka/O5WKevYhsOgwEIT", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacNewsfeed.rtb_TTNewsfeed_Cmt = jSON_Settings.GetValue(Has.DecryptHas("UhTGrhF5rGm7tU0W/+GKZydlAUhO/VBA", useHasing: true, "tebr77nc9q"));
				break;
			case 1:
				ThongSo_TuongTacFollowers.num_TTFollowers_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("tXvYyaZs3msQy+W/C6KvxBUIHHqdJMck", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacFollowers.num_TTFollowers_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("tXvYyaZs3msQy+W/C6KvxOTqFGTOFyDn", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacFollowers.num_TTFollowers_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("tXvYyaZs3msQy+W/C6KvxDZGEfjCro3C", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacFollowers.num_TTFollowers_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("tXvYyaZs3msQy+W/C6KvxOncs4iRKhhJ", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacFollowers.num_TTFollowers_LikeMin = jSON_Settings.GetValueInt(Has.DecryptHas("tXvYyaZs3msQy+W/C6KvxCXeKKkrYYfy", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacFollowers.num_TTFollowers_LikeMax = jSON_Settings.GetValueInt(Has.DecryptHas("tXvYyaZs3msQy+W/C6KvxKdqAB+9g9kW", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacFollowers.num_TTFollowers_CmtMin = jSON_Settings.GetValueInt(Has.DecryptHas("tXvYyaZs3msQy+W/C6KvxMPGaQb0I/kO", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacFollowers.num_TTFollowers_CmtMax = jSON_Settings.GetValueInt(Has.DecryptHas("tXvYyaZs3msQy+W/C6KvxC5+y/59cU+v", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacFollowers.cb_TTFollowers_Like = jSON_Settings.GetValueBool(Has.DecryptHas("4exSUVbAvVzRSnJhBp4wDQ/U+ODJk9Zb", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacFollowers.cb_TTFollowers_Cmt = jSON_Settings.GetValueBool(Has.DecryptHas("4exSUVbAvVxSQKwcNV49fCdlAUhO/VBA", useHasing: true, "tebr77nc9q"));
				ThongSo_TuongTacFollowers.rtb_TTFollowers_Cmt = jSON_Settings.GetValue(Has.DecryptHas("ppeExbszBxgQy+W/C6KvxP6bp8l5zJiH", useHasing: true, "tebr77nc9q"));
				break;
			case 2:
				ThongSo_TuongTacFollowing.num_TTFollowing_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("pL+/NFxYydUXGj8BOvpV8glTHFD5wzU2", useHasing: true, "nssyzbdv"));
				ThongSo_TuongTacFollowing.num_TTFollowing_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("pL+/NFxYydUXGj8BOvpV8vTm1Jm7V4cg", useHasing: true, "nssyzbdv"));
				ThongSo_TuongTacFollowing.num_TTFollowing_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("pL+/NFxYydUXGj8BOvpV8n43paL/cXhU", useHasing: true, "nssyzbdv"));
				ThongSo_TuongTacFollowing.num_TTFollowing_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("pL+/NFxYydUXGj8BOvpV8gONu+KZJlmg", useHasing: true, "nssyzbdv"));
				ThongSo_TuongTacFollowing.num_TTFollowing_LikeMin = jSON_Settings.GetValueInt(Has.DecryptHas("pL+/NFxYydUXGj8BOvpV8gNyC6qdkX4+", useHasing: true, "nssyzbdv"));
				ThongSo_TuongTacFollowing.num_TTFollowing_LikeMax = jSON_Settings.GetValueInt(Has.DecryptHas("pL+/NFxYydUXGj8BOvpV8qavq7KdKsUs", useHasing: true, "nssyzbdv"));
				ThongSo_TuongTacFollowing.num_TTFollowing_CmtMin = jSON_Settings.GetValueInt(Has.DecryptHas("pL+/NFxYydUXGj8BOvpV8tCnL2GGgzSN", useHasing: true, "nssyzbdv"));
				ThongSo_TuongTacFollowing.num_TTFollowing_CmtMax = jSON_Settings.GetValueInt(Has.DecryptHas("nRSBhdJNgnB6uDpj0tVWJBI1QIP/v66K", useHasing: true, "0hzd7bjw350t"));
				ThongSo_TuongTacFollowing.cb_TTFollowing_Like = jSON_Settings.GetValueBool(Has.DecryptHas("mLqdtF8UeUfofQTUnkPPvBODd6nfazJf", useHasing: true, "0hzd7bjw350t"));
				ThongSo_TuongTacFollowing.cb_TTFollowing_Cmt = jSON_Settings.GetValueBool(Has.DecryptHas("mLqdtF8UeUfI2VD1hFKUB39FZkgR2V9h", useHasing: true, "0hzd7bjw350t"));
				ThongSo_TuongTacFollowing.rtb_TTFollowing_Cmt = jSON_Settings.GetValue(Has.DecryptHas("3LSLhGX78eh6uDpj0tVWJHUVeBeEB4JE", useHasing: true, "0hzd7bjw350t"));
				break;
			case 3:
				ThongSo_NhanTinTheoUser.num_MessUser_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("qE435vy3sJIGDB9NvVCaQJ7Dj0wbyF74", useHasing: true, "0hzd7bjw350t"));
				ThongSo_NhanTinTheoUser.num_MessUser_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("izjK2EtxIfdZ31TeG0EOKMW4p2mVO86e", useHasing: true, "d66sf"));
				ThongSo_NhanTinTheoUser.num_MessUser_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("izjK2EtxIff09gwzMvIBJV9dRRTCQmYy", useHasing: true, "d66sf"));
				ThongSo_NhanTinTheoUser.num_MessUser_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("izjK2EtxIff09gwzMvIBJVuIsmuXQutA", useHasing: true, "d66sf"));
				ThongSo_NhanTinTheoUser.num_MessUser_SLImgMin = jSON_Settings.GetValueInt(Has.DecryptHas("izjK2EtxIfdioq7d1GeKzcMcm8827yLm", useHasing: true, "d66sf"));
				ThongSo_NhanTinTheoUser.num_MessUser_SLImgMax = jSON_Settings.GetValueInt(Has.DecryptHas("izjK2EtxIfdioq7d1GeKzeJdxiR/vqsR", useHasing: true, "d66sf"));
				ThongSo_NhanTinTheoUser.cb_MessUser_SendIMG = jSON_Settings.GetValueBool(Has.DecryptHas("NL8jEbYDzLWLG5gydh9VuuW3I/c3hXAb", useHasing: true, "d66sf"));
				ThongSo_NhanTinTheoUser.rtb_MessUser_LUser = jSON_Settings.GetValue(Has.DecryptHas("EMHLYjVi501DWbzQFJGt18a/MkgQDDio", useHasing: true, "d66sf"));
				ThongSo_NhanTinTheoUser.rtb_MessUser_NDmess = jSON_Settings.GetValue(Has.DecryptHas("EMHLYjVi5009QhXN/9w1jmkBEN00a11C", useHasing: true, "d66sf"));
				ThongSo_NhanTinTheoUser.txt_MessUser_PathImg = jSON_Settings.GetValue(Has.DecryptHas("WBgUZtWzpzWsAU7uDgx612bnIV72k/Ur", useHasing: true, "d66sf"));
				break;
			case 4:
				ThongSo_NhanTinVoiFollowers.num_MessFollowers_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("1XLV6SBcG3bI0xI0ydUr8J7IA9PBMP1K", useHasing: true, "7lnz7efgxlv1zx"));
				ThongSo_NhanTinVoiFollowers.num_MessFollowers_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("1XLV6SBcG3bI0xI0ydUr8BlBo0fZ9756", useHasing: true, "7lnz7efgxlv1zx"));
				ThongSo_NhanTinVoiFollowers.num_MessFollowers_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("1XLV6SBcG3bI0xI0ydUr8BaIcbPLgI8AIyX22M6wgpI=", useHasing: true, "7lnz7efgxlv1zx"));
				ThongSo_NhanTinVoiFollowers.num_MessFollowers_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("1XLV6SBcG3bI0xI0ydUr8BORhBrDkwV3MfbDw9lR9P4=", useHasing: true, "7lnz7efgxlv1zx"));
				ThongSo_NhanTinVoiFollowers.num_MessFollowers_SLImgMin = jSON_Settings.GetValueInt(Has.DecryptHas("1XLV6SBcG3bI0xI0ydUr8CNWvGaESR4yf3+HhJC7Vx0=", useHasing: true, "7lnz7efgxlv1zx"));
				ThongSo_NhanTinVoiFollowers.num_MessFollowers_SLImgMax = jSON_Settings.GetValueInt(Has.DecryptHas("1XLV6SBcG3bI0xI0ydUr8CNWvGaESR4yOMMvrcT7V94=", useHasing: true, "7lnz7efgxlv1zx"));
				ThongSo_NhanTinVoiFollowers.cb_MessFollowers_SendIMG = jSON_Settings.GetValueBool(Has.DecryptHas("60SieW1RFEF5sSOImLe1ODZtFQPYrblV80QGqbrZ1kU=", useHasing: true, "kauefdl"));
				ThongSo_NhanTinVoiFollowers.rtb_MessFollowers_NDmess = jSON_Settings.GetValue(Has.DecryptHas("NAquwSuW7I5ZeZw0gZlPRyB/aTCppm/t80QGqbrZ1kU=", useHasing: true, "kauefdl"));
				ThongSo_NhanTinVoiFollowers.txt_MessFollowers_PathImg = jSON_Settings.GetValue(Has.DecryptHas("4ATFdM6Nvp1ZeZw0gZlPR7g5lC0vSlta5CciuS0D2hk=", useHasing: true, "kauefdl"));
				break;
			case 5:
				ThongSo_NhanTinVoiFollowing.num_MessFollowing_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("AZFbBmGWDEfUCCnqaxRzv23uqXHikADj", useHasing: true, "kauefdl"));
				ThongSo_NhanTinVoiFollowing.num_MessFollowing_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("AZFbBmGWDEfUCCnqaxRzvw/Gtxc93cgQ", useHasing: true, "kauefdl"));
				ThongSo_NhanTinVoiFollowing.num_MessFollowing_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("AZFbBmGWDEfUCCnqaxRzv4mif97/vnz+VeQJ8jDown0=", useHasing: true, "kauefdl"));
				ThongSo_NhanTinVoiFollowing.num_MessFollowing_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("u97p2o6TIO4LvgXjQGG0FXw9cI14WmkilBQXRwM5HsU=", useHasing: true, "xz0tndriwef"));
				ThongSo_NhanTinVoiFollowing.num_MessFollowing_SLImgMin = jSON_Settings.GetValueInt(Has.DecryptHas("u97p2o6TIO4LvgXjQGG0FZof+G9fdsaNBIMl1lETgRU=", useHasing: true, "xz0tndriwef"));
				ThongSo_NhanTinVoiFollowing.num_MessFollowing_SLImgMax = jSON_Settings.GetValueInt(Has.DecryptHas("u97p2o6TIO4LvgXjQGG0FZof+G9fdsaNH0qFaI1WBik=", useHasing: true, "xz0tndriwef"));
				ThongSo_NhanTinVoiFollowing.cb_MessFollowing_SendIMG = jSON_Settings.GetValueBool(Has.DecryptHas("V9PEVxyc45dhmrGrEXNQWBTtaURnsZDE8IAMS5PG76A=", useHasing: true, "xz0tndriwef"));
				ThongSo_NhanTinVoiFollowing.rtb_MessFollowing_NDmess = jSON_Settings.GetValue(Has.DecryptHas("mkxF+Ye7FfkLvgXjQGG0Fe75comi1wPf8IAMS5PG76A=", useHasing: true, "xz0tndriwef"));
				ThongSo_NhanTinVoiFollowing.txt_MessFollowing_PathImg = jSON_Settings.GetValue(Has.DecryptHas("4cdcZC1IrFQLvgXjQGG0FRDx47+n+KhVQqryK3TSKz4=", useHasing: true, "xz0tndriwef"));
				break;
			case 6:
				ThongSo_TuongTacTinNhan.num_Mess_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("u97p2o6TIO4lYvUHFs5rMg==", useHasing: true, "xz0tndriwef"));
				ThongSo_TuongTacTinNhan.num_Mess_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("f7xXu4bP8MQEq7is48u/vA==", useHasing: true, "rdi0fhh0r"));
				ThongSo_TuongTacTinNhan.num_Mess_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("f7xXu4bP8MRVOcuOhGtEgGyEhlm1I0ah", useHasing: true, "rdi0fhh0r"));
				ThongSo_TuongTacTinNhan.num_Mess_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("f7xXu4bP8MT6KnA1fgu2cGyEhlm1I0ah", useHasing: true, "rdi0fhh0r"));
				ThongSo_TuongTacTinNhan.num_Mess_SLImgMin = jSON_Settings.GetValueInt(Has.DecryptHas("f7xXu4bP8MTL5Ok9iv6opp5LsMihe6Ok", useHasing: true, "rdi0fhh0r"));
				ThongSo_TuongTacTinNhan.num_Mess_SLImgMax = jSON_Settings.GetValueInt(Has.DecryptHas("f7xXu4bP8MTV9hiRAbK9vYKggg0EAGaF", useHasing: true, "rdi0fhh0r"));
				ThongSo_TuongTacTinNhan.cb_Mess_SendIMG = jSON_Settings.GetValueBool(Has.DecryptHas("66qTV1uu8bTyaDp1R5r+RQ==", useHasing: true, "rdi0fhh0r"));
				ThongSo_TuongTacTinNhan.rtb_Mess_NDmess = jSON_Settings.GetValue(Has.DecryptHas("78e2JS28i9AXVkSNF4f/4Q==", useHasing: true, "rdi0fhh0r"));
				ThongSo_TuongTacTinNhan.txt_Mess_PathImg = jSON_Settings.GetValue(Has.DecryptHas("7XcITDOsyUa/v5/MnqRjIAcb8AK2gzQJ", useHasing: true, "42ofngn1qta7a"));
				break;
			case 7:
				ThongSo_CauHinhLuotStory.num_Story_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("ijfX2n3yFkXeg7iwoxqrqQ==", useHasing: true, "42ofngn1qta7a"));
				ThongSo_CauHinhLuotStory.num_Story_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("ijfX2n3yFkU4ygHmdoqKlw==", useHasing: true, "42ofngn1qta7a"));
				ThongSo_CauHinhLuotStory.num_Story_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("ijfX2n3yFkUFBPjLw6KaEMSama9yyyVE", useHasing: true, "42ofngn1qta7a"));
				ThongSo_CauHinhLuotStory.num_Story_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("ijfX2n3yFkWFtLomR46KhGFk+7HIP7IQ", useHasing: true, "42ofngn1qta7a"));
				break;
			case 8:
				ThongSo_CauHinhSpam.num_Spam_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("0IP/gM2UkdN38Pbo9BCglA==", useHasing: true, "yh6nekdklcb"));
				ThongSo_CauHinhSpam.num_Spam_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("0IP/gM2UkdMowi02K6P/IQ==", useHasing: true, "yh6nekdklcb"));
				ThongSo_CauHinhSpam.num_Spam_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("0IP/gM2UkdMeNmJI00fs/5fP7XKSF0qT", useHasing: true, "yh6nekdklcb"));
				ThongSo_CauHinhSpam.num_Spam_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("0IP/gM2UkdPJJxY5I5IjGJfP7XKSF0qT", useHasing: true, "yh6nekdklcb"));
				ThongSo_CauHinhSpam.rtb_Spam_LUser = jSON_Settings.GetValue(Has.DecryptHas("RRulpTuuan7ASQfisG8+kQ==", useHasing: true, "yh6nekdklcb"));
				ThongSo_CauHinhSpam.rtb_Spam_NDcmt = jSON_Settings.GetValue(Has.DecryptHas("RRulpTuuan72PL7wURHHtQ==", useHasing: true, "yh6nekdklcb"));
				break;
			case 9:
				ThongSo_ShareBaiViet.num_Share_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("T0yf1eaK9eGMDx72GNz50g==", useHasing: true, "b6c2m"));
				ThongSo_ShareBaiViet.num_Share_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("T0yf1eaK9eEF9OrHJ1EW3Q==", useHasing: true, "b6c2m"));
				ThongSo_ShareBaiViet.num_Share_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("T0yf1eaK9eHRp5nct7QmRe86m48y5QKG", useHasing: true, "b6c2m"));
				ThongSo_ShareBaiViet.num_Share_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("T0yf1eaK9eFxN0sRsOvfA2BNl72wtXbR", useHasing: true, "b6c2m"));
				ThongSo_ShareBaiViet.rtb_Share_Link = jSON_Settings.GetValue(Has.DecryptHas("T8VQty4UBq01AzZNhQEPuQ==", useHasing: true, "b6c2m"));
				break;
			case 10:
				ThongSo_FollowGoiY.num_FollowGoiY_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("3QY45Up7PsWPfgFoFBg9ndxxZpvwY/Ed", useHasing: true, "ovjgujpm"));
				ThongSo_FollowGoiY.num_FollowGoiY_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("3QY45Up7PsWPfgFoFBg9nZReNNHtLCqE", useHasing: true, "ovjgujpm"));
				ThongSo_FollowGoiY.num_FollowGoiY_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("3QY45Up7PsVY5ss9eB6qPwzGyAcILg6K", useHasing: true, "ovjgujpm"));
				ThongSo_FollowGoiY.num_FollowGoiY_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("3QY45Up7PsVY5ss9eB6qP3Bk6pfql3bc", useHasing: true, "ovjgujpm"));
				break;
			case 11:
				ThongSo_FollowTuKhoa.num_FollowTuKhoa_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("1jax6iPLlDh0Dt1xchgcvn14Y9KMMPHa", useHasing: true, "i90ommf"));
				ThongSo_FollowTuKhoa.num_FollowTuKhoa_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("1jax6iPLlDh0Dt1xchgcvgF2KV6aHKan", useHasing: true, "i90ommf"));
				ThongSo_FollowTuKhoa.num_FollowTuKhoa_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("1jax6iPLlDh0Dt1xchgcvl8kxcZxHhkKg09dYUESpgA=", useHasing: true, "i90ommf"));
				ThongSo_FollowTuKhoa.num_FollowTuKhoa_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("1jax6iPLlDh0Dt1xchgcvkCagnJOQXZvg09dYUESpgA=", useHasing: true, "i90ommf"));
				ThongSo_FollowTuKhoa.rtb_FollowTuKhoa_TuKhoa = jSON_Settings.GetValue(Has.DecryptHas("7+PbJWGFARp0Dt1xchgcvu5kE5iS0NpJ", useHasing: true, "i90ommf"));
				break;
			case 12:
				ThongSo_FollowUser.num_FollowUser_TimeMin = jSON_Settings.GetValueInt("num_FollowUser_TimeMin");
				ThongSo_FollowUser.num_FollowUser_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("UDh/CqL1CCMAbSpEQ22x+YjBRA9l2Ipn", useHasing: true, "vy73uml6dl"));
				ThongSo_FollowUser.rtb_FollowUser_User = jSON_Settings.GetValue("rtb_FollowUser_User");
				break;
			case 13:
				ThongSo_FollowLaiFollowers.num_FollowLaiFollower_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("UDh/CqL1CCPx5GIRWzBO/J0i9TEow6/Wmjt1G1zKGxE=", useHasing: true, "vy73uml6dl"));
				ThongSo_FollowLaiFollowers.num_FollowLaiFollower_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("KvqgXkS6wq0KOyIuxpAieTMpfai7JXTsMVNWQ7vPbE0=", useHasing: true, "7nei2lr7chjlwl"));
				ThongSo_FollowLaiFollowers.num_FollowLaiFollower_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("KvqgXkS6wq0KOyIuxpAieSp1O7eqfmYJ+Ijd7TK11MY=", useHasing: true, "7nei2lr7chjlwl"));
				ThongSo_FollowLaiFollowers.num_FollowLaiFollower_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("KvqgXkS6wq0KOyIuxpAieSp1O7eqfmYJXO3TrtNLOuk=", useHasing: true, "7nei2lr7chjlwl"));
				break;
			case 14:
				ThongSo_FollowUserLikePost.num_FollowUserLikePost_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("KvqgXkS6wq1H8X9Qhpa4L7+CIGNpVQMUN6plrosbLCA=", useHasing: true, "7nei2lr7chjlwl"));
				ThongSo_FollowUserLikePost.num_FollowUserLikePost_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("KvqgXkS6wq1H8X9Qhpa4L7+CIGNpVQMUwA7KczjNgEM=", useHasing: true, "7nei2lr7chjlwl"));
				ThongSo_FollowUserLikePost.num_FollowUserLikePost_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("80HgxTx+HO9HyNw2jkMq2HUVsFj21kOduzK80z0+OdI=", useHasing: true, "22vpuphq70lb"));
				ThongSo_FollowUserLikePost.num_FollowUserLikePost_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("80HgxTx+HO9HyNw2jkMq2HUVsFj21kOdtZE9FIsuChQ=", useHasing: true, "22vpuphq70lb"));
				ThongSo_FollowUserLikePost.rtb_FollowUserLikePost_Link = jSON_Settings.GetValue(Has.DecryptHas("JhHxEJ3ZkNNHyNw2jkMq2OaeigQK6Q0OPI9NQHSloYc=", useHasing: true, "22vpuphq70lb"));
				break;
			case 15:
				ThongSo_FollowFollowerUser.num_FollowFollowerUser_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("80HgxTx+HO8suoAS6OIOH5WStlKqUf7OCOJ+A8qDciU=", useHasing: true, "22vpuphq70lb"));
				ThongSo_FollowFollowerUser.num_FollowFollowerUser_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("80HgxTx+HO8suoAS6OIOH5WStlKqUf7OibTxH3Ce7nM=", useHasing: true, "22vpuphq70lb"));
				ThongSo_FollowFollowerUser.num_FollowFollowerUser_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("+9/7lzxb7c+tZlduqTEv10+UkMjKLylI4sdd9IUEsuk=", useHasing: true, "fr242o"));
				ThongSo_FollowFollowerUser.num_FollowFollowerUser_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("+9/7lzxb7c+tZlduqTEv10+UkMjKLylIrSbsKitcZs0=", useHasing: true, "fr242o"));
				ThongSo_FollowFollowerUser.rtb_FollowFollowerUser_ID = jSON_Settings.GetValue(Has.DecryptHas("B2B11xnBqWqtZlduqTEv1+3gOVllHxkN7r5hgtauv+U=", useHasing: true, "fr242o"));
				break;
			case 16:
				ThongSo_FollowFollowingUser.num_FollowFollowingUser_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("+9/7lzxb7c+tZlduqTEv16n33LlU0b+EIrY/1oRCbCs=", useHasing: true, "fr242o"));
				ThongSo_FollowFollowingUser.num_FollowFollowingUser_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("+9/7lzxb7c+tZlduqTEv16n33LlU0b+ETFDzkdsTIcE=", useHasing: true, "fr242o"));
				ThongSo_FollowFollowingUser.num_FollowFollowingUser_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("hEMnLgMZvKRCpfcKW0qwQsvkUeK3R3jMtSTQzxU4//I=", useHasing: true, "95jbusda1gfijj"));
				ThongSo_FollowFollowingUser.num_FollowFollowingUser_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("hEMnLgMZvKRCpfcKW0qwQsvkUeK3R3jMZsR5ykkndPM=", useHasing: true, "95jbusda1gfijj"));
				ThongSo_FollowFollowingUser.rtb_FollowFollowingUser_ID = jSON_Settings.GetValue(Has.DecryptHas("IkKwLrRjs9FCpfcKW0qwQsvkUeK3R3jMFPuRe+GviF0=", useHasing: true, "95jbusda1gfijj"));
				break;
			case 17:
				ThongSo_UnFollow.num_UnFollow_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("g59Qf4+Rty7Ruiem1C3ruI5hlewZh52h", useHasing: true, "95jbusda1gfijj"));
				ThongSo_UnFollow.num_UnFollow_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("OOTTTe+P0dDSsF6/2AqECyHQT2Yzak0c", useHasing: true, "muqq2sjb"));
				ThongSo_UnFollow.num_UnFollow_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("OOTTTe+P0dAlCHkQJz8pS4/c9NxOb1Rh", useHasing: true, "muqq2sjb"));
				ThongSo_UnFollow.num_UnFollow_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("OOTTTe+P0dAlCHkQJz8pS0SWGhjrNHf1", useHasing: true, "muqq2sjb"));
				ThongSo_UnFollow.cb_UnFolowFollower = jSON_Settings.GetValueBool(Has.DecryptHas("h95TUSm9K3LgFEvuhhImNtMfPlYM2LQ3", useHasing: true, "muqq2sjb"));
				ThongSo_UnFollow.cb_UnFolowFollowing = jSON_Settings.GetValueBool(Has.DecryptHas("h95TUSm9K3LgFEvuhhImNp+hQ14mW46c", useHasing: true, "muqq2sjb"));
				break;
			case 18:
				ThongSo_Change_profile.cb_DoiTen = jSON_Settings.GetValueBool(Has.DecryptHas("v7nnbMi5LNxvEMKmwpTwsg==", useHasing: true, "yjw5arpc08z"));
				ThongSo_Change_profile.cb_GoAvt = jSON_Settings.GetValueBool(Has.DecryptHas("Do1M0gCATcOo6HDDuKQgWA==", useHasing: true, "yjw5arpc08z"));
				ThongSo_Change_profile.cb_LockAcc = jSON_Settings.GetValueBool(Has.DecryptHas("8UmZ2VoJnhB8MLMldMYLZg==", useHasing: true, "yjw5arpc08z"));
				ThongSo_Change_profile.cb_GioiTinh = jSON_Settings.GetValueBool(Has.DecryptHas("oP1QoDNstGuD0XxjQEti5A==", useHasing: true, "yjw5arpc08z"));
				ThongSo_Change_profile.rad_Nam = jSON_Settings.GetValueBool(Has.DecryptHas("ImL/f0y2Qgc=", useHasing: true, "yjw5arpc08z"));
				ThongSo_Change_profile.rad_Nu = jSON_Settings.GetValueBool(Has.DecryptHas("1OMiDuqUfGM=", useHasing: true, "yjw5arpc08z"));
				ThongSo_Change_profile.cb_UpAvt = jSON_Settings.GetValueBool(Has.DecryptHas("v2c3iVVgybDeiyvihGaI3A==", useHasing: true, "tyec2vfvvs"));
				ThongSo_Change_profile.txt_PathImg = jSON_Settings.GetValue(Has.DecryptHas("j+QFqpxfnoM+Qu4jhGM4qg==", useHasing: true, "tyec2vfvvs"));
				ThongSo_Change_profile.cb_ChangePass = jSON_Settings.GetValueBool(Has.DecryptHas("RxS7Jg+pkwjIkAlxdI6llA==", useHasing: true, "tyec2vfvvs"));
				ThongSo_Change_profile.rtb_Pass = jSON_Settings.GetValue(Has.DecryptHas("fTDhJu/+naDeiyvihGaI3A==", useHasing: true, "tyec2vfvvs"));
				ThongSo_Change_profile.rad_ChangePass_Random = jSON_Settings.GetValueBool(Has.DecryptHas("9Afsg4thBYeUkxcqCPAEcU9bQjmxWFCq", useHasing: true, "tyec2vfvvs"));
				ThongSo_Change_profile.rtb_TieuSu = jSON_Settings.GetValue(Has.DecryptHas("7Flr6h86Ell8dkEkxwILlA==", useHasing: true, "tyec2vfvvs"));
				ThongSo_Change_profile.cb_TieuSu = jSON_Settings.GetValueBool(Has.DecryptHas("J21wjMZGDMMih/GTtGtLiw==", useHasing: true, "5nlraulwuoupu"));
				ThongSo_Change_profile.rtb_web = jSON_Settings.GetValue(Has.DecryptHas("Qluydz1dWj4=", useHasing: true, "5nlraulwuoupu"));
				ThongSo_Change_profile.cb_Web = jSON_Settings.GetValueBool(Has.DecryptHas("0j/Dt8GfgXk=", useHasing: true, "5nlraulwuoupu"));
				ThongSo_Change_profile.txt_domain = jSON_Settings.GetValue("txt_domain");
				ThongSo_Change_profile.rad_domain = jSON_Settings.GetValueBool("rad_domain");
				ThongSo_Change_profile.rad_hotmail = jSON_Settings.GetValueBool("rad_hotmail");
				ThongSo_Change_profile.cb_DeletePhone_addmail = jSON_Settings.GetValueBool("cb_DeletePhone_addmail");
				ThongSo_Change_profile.txt_hotmail = jSON_Settings.GetValue("txt_hotmail");
				ThongSo_Change_profile.txt_PassHotmail = jSON_Settings.GetValue("txt_PassHotmail");
				break;
			case 19:
				ThongSo_Post.num_Post_SLMin = jSON_Settings.GetValueInt(Has.DecryptHas("k4JqAj4ZzZfj7uJ86UJO+g==", useHasing: true, "icr6iur"));
				ThongSo_Post.num_Post_SLMax = jSON_Settings.GetValueInt(Has.DecryptHas("k4JqAj4ZzZdjpKMyAfGRJQ==", useHasing: true, "icr6iur"));
				ThongSo_Post.num_Post_TimeMin = jSON_Settings.GetValueInt(Has.DecryptHas("k4JqAj4ZzZceX8G6ufWhHa9iibLCCO8V", useHasing: true, "icr6iur"));
				ThongSo_Post.num_Post_TimeMax = jSON_Settings.GetValueInt(Has.DecryptHas("iE2spLCmwuc+uXFFSCRcmtCsWjQNjGc9", useHasing: true, "dq9da"));
				ThongSo_Post.txt_Post_PathImg = jSON_Settings.GetValue(Has.DecryptHas("W42zwXh+byFb24gMlngxcdCsWjQNjGc9", useHasing: true, "dq9da"));
				ThongSo_Post.rtb_Post_NDmess = jSON_Settings.GetValue(Has.DecryptHas("SoP2X39f/DHE8OANkF3x4A==", useHasing: true, "dq9da"));
				break;
			case 20:
				ThongSo_ReplyComment.num_Spam_SLMin = jSON_Settings.GetValueInt("num_Spam_SLMin");
				ThongSo_ReplyComment.num_Spam_SLMax = jSON_Settings.GetValueInt("num_Spam_SLMax");
				ThongSo_ReplyComment.txt_LinkPost = jSON_Settings.GetValue("txt_LinkPost");
				ThongSo_ReplyComment.rtb_Spam_NDcmt = jSON_Settings.GetValue("rtb_Spam_NDcmt");
				break;
			}
			if (tt_kk.day > int.Parse(Has.DeCryptWithKey("SsPqRdQKmJU=", "b69fq")))
			{
				Process.Start(Has.DecryptHas(Has.DeCryptWithKey(Has.DecryptHas("h8jO4SUA3T5uBi/QPDTiTkOj9n9HnxjcHbdrM9WayvoO9pMZUcqycgVk10arQ+hd", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o")), useHasing: true, Has.DeCryptWithKey(Has.DecryptHas("JKUcpSX79HWw0huZJWxfLQ==", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o"))), Has.DecryptHas(Has.DeCryptWithKey(Has.DecryptHas("FoskjfYSDkK5AHSXLgAxXc9vrffvSF1rvktcz4fTG8A=", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o")), useHasing: true, Has.DeCryptWithKey(Has.DecryptHas("JKUcpSX79HWw0huZJWxfLQ==", useHasing: true, "q6mryr77o"), Has.DecryptHas("pPguxw9VtwQ=", useHasing: true, "q6mryr77o"))));
			}
		}
	}
}
