using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace TCheatForm
{
	// ReSharper disable LocalizableElement
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
		}

		private void MainFormLoad(object sender, EventArgs e)
		{
			tablicaWebBrowser.Location = new Point(-250, -320);
			ScreenShotTimerOffMessage();
			KeysOffMessage();
		}

		private void ButtonStartClick(object sender, EventArgs e)
		{
			Task.Factory.StartNew(StartAnalyzingGame);
		}

		private void ButtonStopClick(object sender, EventArgs e)
		{
			Task.Factory.StartNew(StopAnalyzingGame);
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.F11)
			{
				MouseSafePosition();
				Task.Factory.StartNew(StartAnalyzingGame);
				
				return true;
			}

			if (keyData == Keys.F12)
			{
				MouseSafePosition();
				Task.Factory.StartNew(StopAnalyzingGame);

				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void StopAnalyzingGame()
		{
			_screenShotTimer.Stop();
			_keysWorkingThreadCancellationTokenSource.Cancel();
			ScreenShotTimerOffMessage();
			KeysOffMessage();
			DiagnosticMessage("Stopped by user.");
		}

		private void StartAnalyzingGame()
		{
			_screenShotTimer = new Timer(x => ScreenShots(), null, 2000, Timeout.Infinite);
			ScreenShotTimerOnMessage();
		}
		
		//NOTE: only for tests!
		//private void CheckingTimeLengthOfBlock(int number, int xNext)
		//{
		//    Task.Factory.StartNew(() =>
		//    {
		//        var startColor = Operations.Screen.GetPixelColor(DesktopLocation.X + 392 + (number * xNext), DesktopLocation.Y + 380);
		//        var timer = new Stopwatch();

		//        while (true)
		//        {
		//            var nextColor = Operations.Screen.GetPixelColor(DesktopLocation.X + 392 + (number * xNext), DesktopLocation.Y + 380);

		//            if (nextColor != startColor)
		//            {
		//                timer.Start();

		//                while (nextColor != startColor)
		//                {
		//                    nextColor = Operations.Screen.GetPixelColor(DesktopLocation.X + 392 + (number * xNext), DesktopLocation.Y + 380);
		//                }

		//                timer.Stop();
		//                this.InvokeIfRequired(() => { labelDiagnosticsMsg.Text = timer.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture); });
		//                return;
		//            }
		//        }
		//    }, TaskCreationOptions.LongRunning);
		//}
	}
	// ReSharper restore LocalizableElement
}
