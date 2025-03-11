namespace Demo.Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }
        List<string> Messages { get; }
        int StatusCode { get; }
        string Code { get; }
        string TransactionId { get; }
    }
}
