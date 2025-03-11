namespace Demo.Business.Exceptions
{
    public class InternalServerException : Exception
    {
      
        public InternalServerException(string message,Exception ex=null):base(message, ex)
        {
        }
    }
}
