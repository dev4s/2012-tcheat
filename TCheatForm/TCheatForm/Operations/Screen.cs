using System;

namespace TCheatForm.Operations
{
	public class Screen
	{
		static public uint GetPixelColor(int x, int y)
		{
			var hdc = Win32.GetDC(IntPtr.Zero);
			var pixel = Win32.GetPixel(hdc, x, y);
			Win32.ReleaseDC(IntPtr.Zero, hdc);
			return pixel;
		}
	}
}