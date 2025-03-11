namespace Demo.Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, int statusCode, string code, string transactionId, List<string> messages) : base(success, statusCode, code, transactionId, messages)
        {
            Data = data;
        }
        public DataResult(T data, bool success, int statusCode, string code, string transactionId, string message) : base(success, statusCode,code, transactionId, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success,int statusCode) : base(success,statusCode)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
