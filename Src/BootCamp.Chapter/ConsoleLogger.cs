using System;
using System.Collections.Generic;
using System.Text;

namespace BootCamp.Chapter
{
    internal class ConsoleLogger : ILogger
    {
        bool isFirstLog = true;
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (isFirstLog)
            {
                Console.Write(DateTime.Now.ToString("MM/dd/yyyy") + " ");
                isFirstLog = false;
            }
            Console.Write(DateTime.Now.ToString("HH:mm:ss"));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" - {message}");
            Console.ResetColor();
        }
    }
}
