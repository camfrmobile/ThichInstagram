using System.Runtime.InteropServices;

namespace Interactive_ins
{
	[StructLayout(LayoutKind.Explicit)]
	public struct MOUSEKEYBDHARDWAREINPUT
	{
		[FieldOffset(0)]
		public HARDWAREINPUT Hardware;

		[FieldOffset(0)]
		public KEYBDINPUT Keyboard;

		[FieldOffset(0)]
		public MOUSEINPUT Mouse;
	}
}
