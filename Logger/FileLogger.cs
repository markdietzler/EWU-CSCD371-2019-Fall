using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string pathToLogFile;

        public FileLogger(string newLogFilePath)
        {
            pathToLogFile = newLogFilePath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            if (!(pathToLogFile is null) && File.Exists(pathToLogFile))
            {
                string output = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt") + " " + ClassName + " " + logLevel + ": " + message;
                File.AppendAllText(pathToLogFile, output);
            }
        }
    }
}