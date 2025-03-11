namespace Demo.Business.Exceptions
{
    public class UnAuthorizedExceptionForEndpoint : Exception
    {
        public UnAuthorizedExceptionForEndpoint(string message) : base(message)
        {

        }
    }
}
