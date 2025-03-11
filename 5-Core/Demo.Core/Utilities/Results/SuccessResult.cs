namespace Demo.Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //public SuccessResult(int statusCode,List<string> messages) : base(true, statusCode,messages)
        //{
        //}
        public SuccessResult(int statusCode, string code, string transactionId, string message) : base(true, statusCode, code, transactionId, message)
        {
        }
        public SuccessResult(int statusCode) : base(true, statusCode)
        {

        }

        public SuccessResult(): base(true)
        {
        }
    }
}
