using NLog;
namespace Demo.Core.Logging
{
    public class NLogManager : ILogManager
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public NLogManager()
        {

        }
        public void Debug(Exception ex, string message)
        {
            logger.Log(LogLevel.Debug, ex, message);
        }

        public void Debug(string message)
        {
            logger.Log(LogLevel.Debug, message);
        }

        public void Error(Exception ex, string message)
        {
            logger.Log(LogLevel.Error, ex, message);
        }

        public void Error(string message)
        {
            logger.Log(LogLevel.Error, message);
        }
        public void Error(string message, Dictionary<string, string> pairs)
        {
            logger.Error((message + "{Arguments}"), pairs);
        }
        public void Info(Exception ex, string message)
        {
            logger.Log(LogLevel.Info, ex, message);
        }

        public void Info(string message)
        {
            logger.Log(LogLevel.Info, message);
        }

        public void Warn(Exception ex, string message)
        {
            logger.Log(LogLevel.Warn, ex, message);
        }

        public void Warn(string message, string transactionId)
        {
            LogEventInfo theEvent = new LogEventInfo(LogLevel.Error, "", message);
            theEvent.Properties["TransactionId"] = transactionId;
            logger.Log(LogLevel.Warn, theEvent);
        }

        public void Warn(string message)
        {
            logger.Log(LogLevel.Warn, message);
        }
    }
}
