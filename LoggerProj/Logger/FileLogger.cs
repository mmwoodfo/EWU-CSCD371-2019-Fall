using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string _FilePath;

        public FileLogger(string filePath)
        {
            _FilePath = filePath;
            File.Create(filePath).Dispose();
        }

        public override void Log(LogLevel logLevel, string message)
        {
            string log = $"{DateTime.Now} {ClassName} {logLevel} {message}";

            using (StreamWriter sw = new StreamWriter(_FilePath, true))
            {
                sw.WriteLine(log);
            }
        }
    }
}