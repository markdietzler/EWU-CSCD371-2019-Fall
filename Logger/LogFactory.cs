namespace Logger
{
    public class LogFactory
    {
        private string logFilePath;
        
        public BaseLogger CreateLogger(string className)
        {
            
            //return null if log file path is null;
            if (logFilePath is null)
            {
                return null;
            }

            return new FileLogger(logFilePath) { ClassName = className };
        }

        public void ConfigureFileLogger(string filePath)
        {
            logFilePath = filePath;
        }
    }
}
