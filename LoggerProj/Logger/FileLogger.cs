using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string filePath;

        public FileLogger(string filePath)
        {
            this.filePath = filePath;

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }
        }

        public override void Log(LogLevel logLevel, string message)
        {
            string log = $"{DateTime.Now.ToString()} {ClassName} {logLevel} {message}";

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(log);
            }
        }
    }
}