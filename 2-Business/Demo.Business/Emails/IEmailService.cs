using Demo.DTO.EMail;

namespace Demo.Business.Emails
{
    public interface IEmailService
    {
         Task<bool> SendQuoteEmailAfterAddQuote(QuoteEmailContentDto dto);
        Task<bool> SendEmailAfterAddVendor(ContactEmailContactDto dto);
        //Task<bool> CheckSmtpHealthAsync();
    }
}
