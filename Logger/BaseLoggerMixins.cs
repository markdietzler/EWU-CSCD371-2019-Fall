using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger newBaseLogger, string message, params object[] args)
        {
            if (newBaseLogger is null)
                throw new ArgumentNullException("Baselogger is null!");

            newBaseLogger.Log(LogLevel.Error, string.Format(message, args));
        }

        public static void Warning(this BaseLogger newBaseLogger, string message, params object[] args)
        {
            if(newBaseLogger is null)
            {
                throw new ArgumentNullException("Null logger given!");
            }

            newBaseLogger.Log(LogLevel.Warning, string.Format(message, args));
        }

        public static void Information(this BaseLogger newBaseLogger, string message, params object[] args)
        {
            if (newBaseLogger is null)
            {
                throw new ArgumentNullException("Null logger given to information logger!");
            }

            newBaseLogger.Log(LogLevel.Information, string.Format(message, args));
        }

        public static void Debug(this BaseLogger newBaseLogger, string message, params object[] args)
        {
            if (newBaseLogger is null)
            {
                throw new ArgumentNullException("Null logger given!");
            }

            newBaseLogger.Log(LogLevel.Debug, string.Format(message, args));
        }
    }
}
