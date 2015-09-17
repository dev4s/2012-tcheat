using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace TCheat
{
	static class Win32
	{
		[DllImport("user32.dll")]
		static extern IntPtr GetDC(IntPtr hwnd);

		[DllImport("user32.dll")]
		static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

		[DllImport("gdi32.dll")]
		static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

		[DllImport("user32.dll")]
		static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

		static public uint GetPixelColor(int x, int y)
		{
			var hdc = GetDC(IntPtr.Zero);
			var pixel = GetPixel(hdc, x, y);
			ReleaseDC(IntPtr.Zero, hdc);
			return pixel;
		}

		static private void PressKey(byte key, int sleepFor)
		{
			keybd_event(key, 0, 0, (UIntPtr)0);
			Thread.Sleep(sleepFor);
			keybd_event(key, 0, 2, (UIntPtr)0);
		}

		static public void PressV(int sleepFor)
		{
			PressKey(0x56, sleepFor);
		}

		static public void PressB(int sleepFor)
		{
			PressKey(0x42, sleepFor);
		}

		static public void PressN(int sleepFor)
		{
			PressKey(0x4E, sleepFor);
		}

		static public void PressM(int sleepFor)
		{
			PressKey(0x4D, sleepFor);
		}
	}
}