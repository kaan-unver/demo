namespace Demo.Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, int statusCode, string code, string transactionId, List<string> messages) : base(data, false, statusCode, code, transactionId, messages)
        {

        }
        public ErrorDataResult(T data, int statusCode, string code, string transactionId, string message) : base(data, false, statusCode, code, transactionId, message)
        {

        }

        public ErrorDataResult(T data, int statusCode) : base(data, false, statusCode)
        {

        }

        public ErrorDataResult(int statusCode, string code, string transactionId, List<string> messages) : base(default, false, statusCode, code, transactionId, messages)
        {

        }
        public ErrorDataResult(int statusCode, string code, string transactionId, string message) : base(default, false, statusCode, code, transactionId, message)
        {

        }

        public ErrorDataResult(int statusCode) : base(default, false, statusCode)
        {

        }
        public ErrorDataResult(bool response, int statusCode, string code, string transactionId, string message) : base(default, false, statusCode, code , transactionId, message
           )
        {

        }

        public ErrorDataResult() :  base(default, false)
        {
        }
    }
}
