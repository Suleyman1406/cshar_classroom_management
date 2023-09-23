using System;
namespace ClassroomManagement.Business.Helpers.Extensions
{
	public static class ConsoleExtension
	{
		public static void WriteLine(this ConsoleColor consoleColor,string text = "")
		{
			Console.ForegroundColor = consoleColor;
			Console.WriteLine(text);
			Console.ResetColor();
		}
        public static void Write(this ConsoleColor consoleColor, string text)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(text);
            Console.ResetColor();
        }

    }
}

