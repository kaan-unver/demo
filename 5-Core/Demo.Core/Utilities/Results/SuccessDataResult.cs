namespace Demo.Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //public SuccessDataResult(T data, int statusCode, List<string> messages,string code) : base(data, true, statusCode, messages)
        //{

        //}
        public SuccessDataResult(T data, int statusCode, string code,string transactionId, List<string> messages) : base(data, true, statusCode, code, transactionId, messages)
        {

        }
        public SuccessDataResult(T data, int statusCode, string code, string transactionId, string message) : base(data, true, statusCode, code, transactionId, message)
        {

        }
        public SuccessDataResult(int statusCode, string code, string transactionId, List<string> messages) : base(default, true, statusCode, code,transactionId, messages)
        {

        }
        public SuccessDataResult(int statusCode, string code, string transactionId, string message) : base(default, true, statusCode, code,transactionId, message)
        {

        }
        public SuccessDataResult(T data, int statusCode) : base(data, true, statusCode)
        {

        }
        public SuccessDataResult(int statusCode) : base(default, true, statusCode)
        {

        }

        public SuccessDataResult(T data): base(data, true)
        {
        }
    }
}
