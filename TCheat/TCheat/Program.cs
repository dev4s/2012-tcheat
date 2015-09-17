using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TCheat
{
	static class Program
	{
		static void Main()
		{
			var thisProcess = Process.GetCurrentProcess();
			thisProcess.PriorityClass = ProcessPriorityClass.High;

			Thread.Sleep(6500);

			var pixelsWar = Enumerable.Range(0, 4).Select(x => new PixelWar(x)).ToArray();

			foreach (var pixelWar in pixelsWar)
			{
				var war = pixelWar;
				Task.Factory.StartNew(() =>
										{
											while (true)
											{
												war.GetColor();
											}
										});
			}

			Console.WriteLine("Press any key to abort.");
			Console.ReadKey();
		}
	}
}