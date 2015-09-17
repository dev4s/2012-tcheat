namespace TCheatForm.Operations
{
	public static class Mouse
	{
		public static void SetCursorPosition(int x, int y)
		{
			Win32.SetCursorPos(x, y);
		}

		private static Win32.MousePoint GetCursorPosition()
		{
			Win32.MousePoint currentMousePoint;
			var gotPoint = Win32.GetCursorPos(out currentMousePoint);
			if (!gotPoint) { currentMousePoint = new Win32.MousePoint(0, 0); }
			return currentMousePoint;
		}

		private static void MouseEvent(Win32.MouseEventFlags value)
		{
			var position = GetCursorPosition();

			Win32.mouse_event ((int)value, position.X, position.Y, 0, 0);
		}

		public static void LeftClick()
		{
			MouseEvent(Win32.MouseEventFlags.LeftDown | Win32.MouseEventFlags.LeftUp);
		}
	}
}