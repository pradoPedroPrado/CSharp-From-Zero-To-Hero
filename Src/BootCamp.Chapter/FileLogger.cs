using System;
using System.IO;

namespace BootCamp.Chapter
{
    internal class FileLogger : ILogger
    {
        bool isFirstLog = true;
        string path;
        public void Log(string message)
        {
            if (isFirstLog)
            {
                string directory = Directory.GetCurrentDirectory() + @"\logs";
                Directory.CreateDirectory(directory);
                path = $@"{directory}\{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")} Log.txt";
                if (!File.Exists(path))
                {
                    var log = File.Create(path);
                    log.Close();
                }
                isFirstLog = false;
            }
            File.AppendAllText(path, $"{DateTime.Now.ToString("HH:mm:ss")} - {message}{Environment.NewLine}");
        }
    }
}
