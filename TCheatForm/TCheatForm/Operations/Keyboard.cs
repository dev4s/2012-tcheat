using System;
using System.Threading;

namespace TCheatForm.Operations
{
	static class Keyboard
	{
		static private void PressKey(byte key, int sleepFor)
		{
			Win32.keybd_event(key, 0, 0, (UIntPtr)0);
			Thread.Sleep(sleepFor); //TODO: change it...
			Win32.keybd_event(key, 0, 2, (UIntPtr)0);
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