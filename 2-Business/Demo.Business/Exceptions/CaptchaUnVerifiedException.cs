namespace Demo.Business.Exceptions
{
    public class CaptchaUnVerifiedException : Exception
    {
        public CaptchaUnVerifiedException(string message) : base(message)
        {

        }
    }
}
