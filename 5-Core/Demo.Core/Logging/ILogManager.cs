namespace Demo.Core.Logging
{
    public interface ILogManager
    {
        public void Debug(Exception ex, string message);
        public void Debug(string message);
        public void Info(Exception ex, string message);
        public void Info(string message);
        public void Warn(Exception ex, string message);
        public void Warn(string message);
        public void Warn(string message, string transactionId);
        public void Error(Exception ex, string message);

        public void Error(string message);
        //public void Error(string message, string transactionId);
        public void Error(string message, Dictionary<string, string> pairs);
    }
}
