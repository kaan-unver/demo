using Demo.Core.ConfigManager;
using Demo.DTO.EMail;
using Demo.Core.Logging;
using System.Net.Mail;
using System.Net;
using System.Runtime.Intrinsics.X86;
namespace Demo.Business.Emails
{
    public class EmailService : IEmailService
    {
        private readonly ITemplateRenderer _templateRenderer;
        private readonly IConfigManager _configManager;
        private readonly ILogManager _logger;

        public EmailService(ITemplateRenderer templateRenderer, IConfigManager configManager, ILogManager logger)
        {
            _templateRenderer = templateRenderer;
            _configManager = configManager;
            _logger = logger;
        }

        public async Task<bool> SendQuoteEmailAfterAddQuote(QuoteEmailContentDto dto)
        {

            var emailBody = await _templateRenderer.RenderTemplateAsync(dto.TemplatePath, dto);
            return await SendMailOperation(dto, emailBody);
        }
        public async Task<bool> SendEmailAfterAddVendor(ContactEmailContactDto dto)
        {
            var emailBody = await _templateRenderer.RenderTemplateAsync(dto.TemplatePath, dto);
            return await SendMailOperation(dto, emailBody);
        }


        //public async Task<bool> CheckSmtpHealthAsync()
        //{
        //    using (var client = new SmtpClient())
        //    {
        //        try
        //        {
        //            await client.ConnectAsync(_configManager.EmailHost, _configManager.EmailPort, SecureSocketOptions.None);
        //            await client.DisconnectAsync(true);
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.Warn($@"Mail gönderilemedi.     Bilgiler: EmailHost: {_configManager.EmailHost}  EmailPort: {_configManager.EmailPort}  
        //                 UseSSL :{_configManager.EmailUseSSL}  EmailFrom: {_configManager.EmailFrom} Password : {_configManager.EmailPassword}
        //                 Hata Message: {ex.Message} InnerException : {ex.InnerException}");
        //            return false;
        //        }
        //    }
        //}

        #region Private Methods
        private async Task<bool> SendMailOperation(EmailContentDto dto, string emailBody)
        {
            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(_configManager.EmailFrom, _configManager.EmailFromTitle),
                    Subject = dto.Subject,
                    Body = emailBody,
                    IsBodyHtml = true
                };
                message.To.Add(new MailAddress(dto.ContactEmail));

                using var smtpClient = new System.Net.Mail.SmtpClient(_configManager.EmailHost, _configManager.EmailPort)
                {
                    Credentials = new NetworkCredential(_configManager.EmailFrom, _configManager.EmailPassword),
                    EnableSsl = _configManager.EmailUseSSL
                };
                await smtpClient.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Warn($@"Mail gönderilemedi.     Bilgiler: ContactName: {dto.ContactName}  ContactEmail: {dto.ContactEmail}  
                                Hata: {ex.Message}");
                return false;
            }

        }
        #endregion
    }
}
