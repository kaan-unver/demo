
namespace Demo.Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(int statusCode, string code, string transactionId, List<string> messages) : base(false, statusCode, code, transactionId, messages)
        {
        }
        public ErrorResult(int statusCode,string code, string transactionId, string message) : base(false, statusCode,code, transactionId, message)
        {
        
        }
        public ErrorResult(int statusCode) : base(false, statusCode)
        {

        }

        public ErrorResult():base(false)
        {
        }
    }
}
