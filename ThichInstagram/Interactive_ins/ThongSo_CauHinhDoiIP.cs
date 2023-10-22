using System.Collections.Generic;

namespace Interactive_ins
{
	public static class ThongSo_CauHinhDoiIP
	{
		public static int num_Thread_ChangeIP { get; set; }

		public static bool rad_ChangIP_No { get; set; }

		public static bool rad_ChangIP_HMA { get; set; }

		public static bool rad_ChangIP_Dcom { get; set; }

		public static bool rad_ChangIP_Proxy { get; set; }

		public static bool rad_ChangIP_Tinsoft { get; set; }

		public static bool rad_ChangIP_ShopLike { get; set; }

		public static bool rad_Dcom_Thuong { get; set; }

		public static bool rad_Dcom_Hilink { get; set; }

		public static string txt_Name_Dcom { get; set; }

		public static string txt_URL { get; set; }

		public static List<string> rtb_KeyShoplike { get; set; }

		public static List<string> rtb_KeyTinsoft { get; set; }

		public static bool rad_ChangIP_Xproxy { get; set; }

		public static bool rad_Xproxy_Http { get; set; }

		public static bool rad_Xproxy_Sock5 { get; set; }

		public static string txt_Service_Url { get; set; }

		public static List<string> rtb_Xproxy_Proxy { get; set; }

		public static bool rad_ChangIP_Minproxy { get; set; }

		public static List<string> rtb_KeyMinproxy { get; set; }

		public static int cbb_SelecTypeIP { get; set; }
	}
}
