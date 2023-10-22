using System.Collections.Generic;

namespace Interactive_ins
{
	public static class ThongSo_CauHinhTuongTac
	{
		public static Thongso_KichBan TT_KichBan { get; set; }

		public static List<Thongso_HanhDong> L_HanhDong { get; set; }

		public static bool cb_RandomHanhDong { get; set; }

		public static int num_ThreadTimeout_TimeMin { get; set; }

		public static int num_ThreadTimeout_TimeMax { get; set; }

		public static string txt_PathProfile { get; set; }

		public static bool cb_checkTT { get; set; }

		public static string txt_cookiecheck { get; set; }

		public static bool rad_VI { get; set; }

		public static bool rad_EN { get; set; }

		public static int num_ChromeY { get; set; }

		public static int num_ChromeX { get; set; }

		public static bool cb_SDProfile { get; set; }

		public static bool cb_addform { get; set; }
	}
}
