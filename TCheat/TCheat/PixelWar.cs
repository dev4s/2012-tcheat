using System.Threading;

namespace TCheat
{
	public class PixelWar
	{
		private readonly int _pixelWarId;
		private readonly uint _normalColor;
		private int _mCounter;

		public PixelWar(int i)
		{
			_pixelWarId = i;
			_normalColor = GetColorFromScreen();
		}

		private uint GetColorFromScreen()
		{
			//return Win32.GetPixelColor(1948 + (_pixelWarId * 166), 482);
			return Win32.GetPixelColor(571 + (_pixelWarId * 138), 332);
		}

		public void GetColor()
		{
			var color = GetColorFromScreen();

			if (color == _normalColor) return;
			switch (_pixelWarId)
			{
				case 0:
					Win32.PressV(10);
					//SendKeys.SendWait("{v}");
					break;

				case 1:
					Win32.PressB(10);
					//SendKeys.SendWait("{b}");
					break;

				case 2:
					Win32.PressN(10);
					//SendKeys.SendWait("{n}");
					break;

				case 3:
					++_mCounter;
					if (_mCounter == 45)
					{
						Win32.PressM(2100);
						_mCounter = 0;
					}
					else
					{
						Win32.PressM(10);
					}
					break;
			}
			Thread.Sleep(150);
		}
	}
}