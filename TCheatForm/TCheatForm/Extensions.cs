using System;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace TCheatForm
{
	public static class Extensions
	{
		public static void InvokeIfRequired(this Control control, Action action)
		{
			if (control.InvokeRequired)
			{
				control.Invoke(action);
			}
			else
			{
				action();
			}
		}

		//public static void InvokeIfRequired<T>(this Control control, Action<T> action, T parameter)
		//{
		//    if (control.InvokeRequired)
		//    {
		//        control.Invoke(action, parameter);
		//    }
		//    else
		//    {
		//        action(parameter);
		//    }
		//}

		public static void Stop(this Timer timer)
		{
			timer.Change(Timeout.Infinite, Timeout.Infinite);
		}

		public static void DelayedStart(this Timer timer, int delayTime)
		{
			timer.Change(delayTime, Timeout.Infinite);
		}

		public static int GetRandom(int min, int max)
		{
			return new Random(Guid.NewGuid().GetHashCode()).Next(min, max + 1);
		}
	}
}