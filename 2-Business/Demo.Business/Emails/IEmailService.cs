using Demo.DTO.EMail;

namespace Demo.Business.Emails
{
    public interface IEmailService
    {
        Task<bool> SendSignUpSuccessEmail(EmailContentDto dto);
        //Task<bool> CheckSmtpHealthAsync();
    }
}
