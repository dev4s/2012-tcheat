using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace TCheatForm
{
	public static class ScreenShot
	{
		public static void Capture(int startx, int starty, int stopx, int stopy, string fileName)
		{
			var width = stopx - startx;
			var height = stopy - starty;

			using (var bitmap = new Bitmap(width, height))
			{
				using (var g = Graphics.FromImage(bitmap))
				{
					g.CopyFromScreen(startx, starty, 0, 0, bitmap.Size);
				}

				var fullFileName = GetFullPath() + "\\" + fileName;
				bitmap.Save(fullFileName, ImageFormat.Jpeg);
			}
		}

		public static bool Compare(string firstFileName, string secondFileName)
		{
			string first, second;

			using (var firstBitmap = new Bitmap(GetFullPath() + "\\" + firstFileName))
			{
				using (var secondBitmap = new Bitmap(GetFullPath() + "\\" + secondFileName))
				{
					using (var ms = new MemoryStream())
					{
						secondBitmap.Save(ms, ImageFormat.Jpeg);
						second = Convert.ToBase64String(ms.ToArray());
						ms.Position = 0;

						firstBitmap.Save(ms, ImageFormat.Jpeg);
						first = Convert.ToBase64String(ms.ToArray());
					}
				}
			}
			
			return first.Equals(second);
		}

		private static string GetFullPath()
		{
			return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		}
	}
}