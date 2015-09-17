using System;
using System.Runtime.InteropServices;

namespace TCheatForm.Operations
{
	public static class Win32
	{
		#region Mouse
		[Flags]
		public enum MouseEventFlags
		{
			LeftDown = 0x00000002,
			LeftUp = 0x00000004
			//not needed
			/*MiddleDown = 0x00000020,
			MiddleUp = 0x00000040,
			Move = 0x00000001,
			Absolute = 0x00008000,
			RightDown = 0x00000008,
			RightUp = 0x00000010*/
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct MousePoint
		{
			internal readonly int X;
			public readonly int Y;

			public MousePoint(int x, int y)
			{
				X = x;
				Y = y;
			}
		}

		[DllImport("user32.dll", EntryPoint = "SetCursorPos")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetCursorPos(int x, int y);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCursorPos(out MousePoint lpMousePoint);

		[DllImport("user32.dll")]
		public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
		#endregion

		#region Keyboard
		[DllImport("user32.dll")]
		public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
		#endregion

		#region Screen
		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);

		[DllImport("user32.dll")]
		public static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

		[DllImport("gdi32.dll")]
		public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);
		#endregion
	}
}