using System;

namespace Otchi.Ebml
{
    public static class ConsoleExtension
    {
        public static void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}