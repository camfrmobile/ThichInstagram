using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Interactive_ins
{
	public class Poin
	{
		private readonly object khoa_poin = new object();

		private int chieurong = Screen.PrimaryScreen.WorkingArea.Width;

		private int chieudai = Screen.PrimaryScreen.WorkingArea.Height;

		public static int dem;

		public static int dem_X;

		public static int dem_Y;

		public static int _X;

		public int X()
		{
			lock (khoa_poin)
			{
				if (dem == 0)
				{
					dem++;
					return _X;
				}
				if (dem_X >= ThongSo_CauHinhTuongTac.num_ChromeX - 1)
				{
					dem_Y++;
					dem_X = (_X = 0);
					return _X;
				}
				dem_X++;
				_X += 440;
			}
			return _X;
		}

		public int Y()
		{
			int num = 0;
			if (dem_Y > ThongSo_CauHinhTuongTac.num_ChromeY - 1)
			{
				dem_Y = 0;
			}
			return dem_Y * chieudai / ThongSo_CauHinhTuongTac.num_ChromeY;
		}

		public static void FillIndexPossition(ref List<int> lstPossition, int indexPos)
		{
			List<int> list = lstPossition;
			lock (list)
			{
				lstPossition[indexPos] = 0;
			}
		}

		public static int GetIndexOfPossitionApp(ref List<int> lstPossition)
		{
			int result = 0;
			List<int> list = lstPossition;
			lock (list)
			{
				for (int i = 0; i < lstPossition.Count; i++)
				{
					if (lstPossition[i] == 0)
					{
						result = i;
						lstPossition[i] = 1;
						break;
					}
				}
			}
			return result;
		}

		public static Point GetPointFromIndexPosition(int indexPos, int column, int row)
		{
			int width = Screen.PrimaryScreen.WorkingArea.Width;
			int height = Screen.PrimaryScreen.WorkingArea.Height;
			Point result = default(Point);
			while (indexPos >= column * row)
			{
				indexPos -= column * row;
			}
			switch (row)
			{
			case 1:
				result.Y = 0;
				break;
			case 2:
				if (indexPos < column)
				{
					result.Y = 0;
				}
				else if (indexPos < column * 2)
				{
					result.Y = height / 2;
					indexPos -= column;
				}
				break;
			case 3:
				if (indexPos < column)
				{
					result.Y = 0;
				}
				else if (indexPos < column * 2)
				{
					result.Y = height / 3;
					indexPos -= column;
				}
				else if (indexPos < column * 3)
				{
					result.Y = height / 3 * 2;
					indexPos -= column * 2;
				}
				break;
			case 4:
				if (indexPos < column)
				{
					result.Y = 0;
				}
				else if (indexPos < column * 2)
				{
					result.Y = height / 4;
					indexPos -= column;
				}
				else if (indexPos < column * 3)
				{
					result.Y = height / 4 * 2;
					indexPos -= column * 2;
				}
				else if (indexPos < column * 4)
				{
					result.Y = height / 4 * 3;
					indexPos -= column * 3;
				}
				break;
			case 5:
				if (indexPos < column)
				{
					result.Y = 0;
				}
				else if (indexPos < column * 2)
				{
					result.Y = height / 5;
					indexPos -= column;
				}
				else if (indexPos < column * 3)
				{
					result.Y = height / 5 * 2;
					indexPos -= column * 2;
				}
				else if (indexPos < column * 4)
				{
					result.Y = height / 5 * 3;
					indexPos -= column * 3;
				}
				else
				{
					result.Y = height / 5 * 4;
					indexPos -= column * 4;
				}
				break;
			}
			int num = width / column;
			result.X = indexPos * num - 10;
			return result;
		}
	}
}
