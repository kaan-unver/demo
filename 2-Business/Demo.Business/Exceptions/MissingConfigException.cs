namespace Demo.Business.Exceptions
{
    public class MissingConfigException : Exception
    {
        public MissingConfigException(string message) : base(message)
        {

        }
    }
}
