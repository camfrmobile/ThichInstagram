using System;
using System.Runtime.InteropServices;

namespace Interactive_ins
{
	public class User32Helper
	{
		[DllImport("user32.dll", SetLastError = true)]
		public static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
	}
}
