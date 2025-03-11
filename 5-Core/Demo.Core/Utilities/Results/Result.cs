using System.Text.Json.Serialization;

namespace Demo.Core.Utilities.Results
{
    public class Result : IResult
    {
    
        public Result(bool success,int statusCode)
        {
            Success = success;
            StatusCode = statusCode;
        }

        public Result(bool success, int statusCode, string code, string transcationId, List<string> messages) : this(success, statusCode)
        {
            Messages = messages;
            TransactionId = transcationId;
            Code = code;
        }
        public Result(bool success, int statusCode, string code, string transcationId, string message) : this(success, statusCode)
        {
            Messages.Add(message);
            Code = code;
            TransactionId = transcationId;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }        
        public string Code { get; }
        public string TransactionId { get;}
        public List<string> Messages { get; } = new List<string> { };

        [JsonIgnore]
        public int StatusCode { get; }

    }
}
