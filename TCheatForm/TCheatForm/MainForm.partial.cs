using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCheatForm.Operations;

namespace TCheatForm
{
	// ReSharper disable LocalizableElement
	public partial class MainForm
	{
		private Timer _screenShotTimer;
		private CancellationTokenSource _keysWorkingThreadCancellationTokenSource;

		private const string GoToGameFile = "GoToGame.jpg";
		private const string GoToGameTempFile = "GoToGameTemp.jpg";
		private const string StartGameFile = "StartGame.jpg";
		private const string StartGameTempFile = "StartGameTemp.jpg";
		private const string SmallPointsFile = "SmallPoints.jpg";
		private const string SmallPointsTempFile = "SmallPointsTemp.jpg";
		private const string CheckBox1StFile = "CheckBox1St.jpg";
		private const string CheckBox1StTempFile = "CheckBox1StTemp.jpg";
		private const string CheckBox2NdFile = "CheckBox2nd.jpg";
		private const string CheckBox2NdTempFile = "CheckBox2ndTemp.jpg";
		private const string CheckBox3RdFile = "CheckBox3rd.jpg";
		private const string CheckBox3RdTempFile = "CheckBox3rdTemp.jpg";
		private const string SaveResult1StFile = "SaveResult1st.jpg";
		private const string SaveResult1StTempFile = "SaveResult1stTemp.jpg";
		private const string SaveResult2NdFile = "SaveResult2nd.jpg";
		private const string SaveResult2NdTempFile = "SaveResult2ndTemp.jpg";
		private const string PlayOneMoreTimeFile = "PlayOneMoreTime.jpg";
		private const string PlayOneMoreTimeTempFile = "PlayOneMoreTimeTemp.jpg";

		private const string GlobalNumberFormat = "0000";

		private int _timeBetweenGetColors;
		private int _keyPress;
		private int _colorPlace;

		private int _pointsCounter;
		private string PointsFile
		{
			get
			{
				return string.Format("Results\\{0}_time_{1}ms_key_press_{2}ms_color_pos_{3}.jpg",
				                     (++_pointsCounter).ToString(GlobalNumberFormat), _timeBetweenGetColors, _keyPress, _colorPlace);
			}
		}

		private int _iterationCounter;
		private string Iteration
		{
			get
			{
				return (++_iterationCounter).ToString(GlobalNumberFormat);
			}
		}

		private const int TimerDueTime = 2500;
		private bool _runKeys = true;

		private void ScreenShots()
		{
			_screenShotTimer.Stop();

			ScreenShot.Capture(DesktopLocation.X + 378, DesktopLocation.Y + 638, DesktopLocation.X + 825, DesktopLocation.Y + 713, SaveResult1StTempFile);
			ScreenShot.Capture(DesktopLocation.X + 369, DesktopLocation.Y + 630, DesktopLocation.X + 820, DesktopLocation.Y + 714, PlayOneMoreTimeTempFile);

			if (_runKeys)
			{
				ScreenShot.Capture(DesktopLocation.X + 42, DesktopLocation.Y + 111, DesktopLocation.X + 197, DesktopLocation.Y + 182, SmallPointsTempFile);
				ScreenShot.Capture(DesktopLocation.X + 378, DesktopLocation.Y + 589, DesktopLocation.X + 825, DesktopLocation.Y + 713, GoToGameTempFile);
				ScreenShot.Capture(DesktopLocation.X + 379, DesktopLocation.Y + 402, DesktopLocation.X + 814, DesktopLocation.Y + 500, StartGameTempFile);
				ScreenShot.Capture(DesktopLocation.X + 374, DesktopLocation.Y + 654, DesktopLocation.X + 817, DesktopLocation.Y + 712, SaveResult2NdTempFile);
				ScreenShot.Capture(DesktopLocation.X + 115, DesktopLocation.Y + 546, DesktopLocation.X + 169, DesktopLocation.Y + 591, CheckBox1StTempFile);
				ScreenShot.Capture(DesktopLocation.X + 410, DesktopLocation.Y + 546, DesktopLocation.X + 460, DesktopLocation.Y + 591, CheckBox2NdTempFile);
				ScreenShot.Capture(DesktopLocation.X + 714, DesktopLocation.Y + 546, DesktopLocation.X + 760, DesktopLocation.Y + 591, CheckBox3RdTempFile);
			}

			if (_runKeys && ScreenShot.Compare(GoToGameFile, GoToGameTempFile))
			{
				Task.Factory.StartNew(() =>
				{
					DiagnosticMessage("Found go to game button.");
					IterationMessage();
					Mouse.SetCursorPosition(DesktopLocation.X + 615, DesktopLocation.Y + 651);
					Mouse.LeftClick();
				}).Wait();
			}

			if (_runKeys && ScreenShot.Compare(StartGameFile, StartGameTempFile))
			{
				Task.Factory.StartNew(() =>
				{
					DiagnosticMessage("Found start game button.");
					Mouse.SetCursorPosition(DesktopLocation.X + 597, DesktopLocation.Y + 451);
					Mouse.LeftClick();
				}).Wait();
			}

			if (_runKeys && ScreenShot.Compare(SmallPointsFile, SmallPointsTempFile))
			{
				Task.Factory.StartNew(RunKeys);
				MouseSafePosition();

				_runKeys = false;
			}

			if (ScreenShot.Compare(SaveResult1StFile, SaveResult1StTempFile))
			{
				Task.Factory.StartNew(() =>
				{
					StopKeys();

					DiagnosticMessage("Saving result to file.");
					KeysOffMessage();
						
					ScreenShot.Capture(DesktopLocation.X + 133, DesktopLocation.Y + 324, DesktopLocation.X + 571, DesktopLocation.Y + 479, PointsFile);
					Mouse.SetCursorPosition(DesktopLocation.X + 602, DesktopLocation.Y + 676);
					Mouse.LeftClick();
					MouseSafePosition();
				}).Wait();
			}

			if (_runKeys && ScreenShot.Compare(SaveResult2NdFile, SaveResult2NdTempFile))
			{
				var saveResultsTask = new Task(() =>
				{
					Mouse.SetCursorPosition(DesktopLocation.X + 596, DesktopLocation.Y + 683);
					Mouse.LeftClick();
					MouseSafePosition();
				});

				DiagnosticMessage("Saving result to portal.");
				
				if (ScreenShot.Compare(CheckBox1StFile, CheckBox1StTempFile) && ScreenShot.Compare(CheckBox2NdFile, CheckBox2NdTempFile) 
					&& ScreenShot.Compare(CheckBox3RdFile, CheckBox3RdTempFile))
				{
					Task.Factory.StartNew(() =>
					{
						Mouse.SetCursorPosition(DesktopLocation.X + 142, DesktopLocation.Y + 569);
						Mouse.LeftClick();
						Mouse.SetCursorPosition(DesktopLocation.X + 435, DesktopLocation.Y + 569);
						Mouse.LeftClick();
						Mouse.SetCursorPosition(DesktopLocation.X + 737, DesktopLocation.Y + 569);
						Mouse.LeftClick();
					}).Wait();
				}
				saveResultsTask.Start();
			}

			if (ScreenShot.Compare(PlayOneMoreTimeFile, PlayOneMoreTimeTempFile))
			{
				Task.Factory.StartNew(() =>
				{
					StopKeys();

					IterationMessage();
					DiagnosticMessage("Starting game one more time.");
					KeysOffMessage();

					Mouse.SetCursorPosition(DesktopLocation.X + 595, DesktopLocation.Y + 672);
					Mouse.LeftClick();
					MouseSafePosition();
				}).Wait();
			}

			_screenShotTimer.DelayedStart(TimerDueTime);
		}

		private void StopKeys()
		{
			_keysWorkingThreadCancellationTokenSource.Cancel();
			_runKeys = true;
		}

		private void RunKeys()
		{
			Thread.Sleep(3100);

			_keysWorkingThreadCancellationTokenSource = new CancellationTokenSource();

			const int xStartPosition = 392;
			const int xNextPosition = 270;

			var randomColorPlace = Extensions.GetRandom(332, 382);
			var randomTimeBetweenGetColor = Extensions.GetRandom(10, 300);
			var randomKeyPress = Extensions.GetRandom(10, 400);

			_colorPlace = randomColorPlace;
			_timeBetweenGetColors = randomTimeBetweenGetColor;
			_keyPress = randomKeyPress;

			//NOTE: Those are somehow a good values, but i need some more random values
			//const int timeBetweenGetColor = 25;
			//var randomKeyPress = Extensions.GetRandom(220 - timeBetweenGetColor, 265 - timeBetweenGetColor);

			DiagnosticMessage(string.Format("Keys running (Time between get color = {0}ms, Key Press = {1}ms, Y color place = {2}px).", 
											randomTimeBetweenGetColor, randomKeyPress, randomColorPlace));
			KeysOnMessage();

			var pixelsWar = Enumerable.Range(0, 4)
				.Select(i =>
						new PixelWar(i, randomColorPlace, xStartPosition, xNextPosition, 
									 DesktopLocation, randomKeyPress, randomTimeBetweenGetColor))
				.ToArray();

			foreach (var pixelWar in pixelsWar)
			{
				var war = pixelWar;
				Task.Factory.StartNew(() =>
				{
					while (true)
					{
						if (_keysWorkingThreadCancellationTokenSource.IsCancellationRequested)
						{
							break;
						}
						war.GetColor();
					}
				});
			}
		}

		private void MouseSafePosition()
		{
			Mouse.SetCursorPosition(DesktopLocation.X + 1320, DesktopLocation.Y + 42);
		}

		private void DiagnosticMessage(string text)
		{
			labelDiagnosticsMsg.InvokeIfRequired(() => labelDiagnosticsMsg.Text = text);
		}

		private void KeysOnMessage()
		{
			labelKeys.InvokeIfRequired(() => labelKeys.Text = "On");
		}

		private void KeysOffMessage()
		{
			labelKeys.InvokeIfRequired(() => labelKeys.Text = "Off");
		}

		private void IterationMessage()
		{
			labelIterationNumber.InvokeIfRequired(() => labelIterationNumber.Text = Iteration);
		}

		private void ScreenShotTimerOffMessage()
		{
			labelScreenShotTimer.InvokeIfRequired(() => labelScreenShotTimer.Text = "Off");
		}

		private void ScreenShotTimerOnMessage()
		{
			labelScreenShotTimer.InvokeIfRequired(() => labelScreenShotTimer.Text = "On");
		}
	}
	// ReSharper restore LocalizableElement
}