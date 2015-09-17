using System.Drawing;
using System.Threading;
using TCheatForm.Operations;

namespace TCheatForm
{
	public class PixelWar
	{
		private readonly int _pixelWarId;
		private readonly uint _normalColor;
		private readonly int _yColorPosition;
		private readonly Point _desktopLocation;
		private readonly int _keyPressTime;
		private readonly int _timeBetweenGetColor;

		private readonly int _xColorStartPosition;
		private readonly int _xColorNextPosition;

		private int _mCounter;

		public PixelWar(int i, int yColorPosition, int xColorStartPosition, int xColorNexPosition, 
						Point desktopLocation, int keyPressTime, int timeBetweenGetColor)
		{
			_pixelWarId = i;
			_yColorPosition = yColorPosition;
			_desktopLocation = desktopLocation;
			_keyPressTime = keyPressTime;
			_timeBetweenGetColor = timeBetweenGetColor;

			_xColorStartPosition = xColorStartPosition;
			_xColorNextPosition = xColorNexPosition;

			_normalColor = GetColorFromScreen();
		}

		private uint GetColorFromScreen()
		{
			return Screen.GetPixelColor(_desktopLocation.X + _xColorStartPosition + (_pixelWarId * _xColorNextPosition), _desktopLocation.Y + _yColorPosition);
		}

		private readonly object _lockLongM = new object();
		public void GetColor()
		{
			var color = GetColorFromScreen();

			if (color == _normalColor) return;
			switch (_pixelWarId)
			{
				case 0:
					Keyboard.PressV(_keyPressTime);
					break;

				case 1:
					Keyboard.PressB(_keyPressTime);
					break;

				case 2:
					Keyboard.PressN(_keyPressTime);
					break;

				case 3:
					Interlocked.Increment(ref _mCounter);
					if (_mCounter == 45)
					{
						lock (_lockLongM)
						{
							Keyboard.PressM(1950);
							Interlocked.Exchange(ref _mCounter, 0);
						}
					}
					else
					{
						Keyboard.PressM(_keyPressTime);
					}
					break;
			}
			Thread.Sleep(_timeBetweenGetColor);
		}
	}
}