using ALPDemo.MailSender.IoCImplementation;
using Autofac.Extensions.DependencyInjection;
using Demo.Business.Abstract.Messages;
using Demo.Business.Emails;
using Demo.Caching.Messages;
using Demo.Core.ConfigManager;
using Demo.Core.Logging;
using Demo.DTO.EMail;
using Demo.Infrastructure.Abstract.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System.Net.Mail;
using System.Net;

class Program
{
    private static IConfiguration _config;
    private static IServiceProvider _serviceProvider;

    public static async Task Main()
    {
        ConfigureLogging();
        ConfigureServices();
        ResolveDependices();

        //await ProcessVendorEmailsAsync();
    }

    private static void ConfigureLogging()
    {
        var path = $"nlog.config";
        LogManager.Setup().LoadConfigurationFromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path));
    }

    private static void ConfigureServices()
    {
        var container = ContainerConfig.ConfigureIoc(new ServiceCollection());
        _serviceProvider = new AutofacServiceProvider(container);
        var logger = _serviceProvider.GetRequiredService<ILogManager>();
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false);
        logger.Warn(AppDomain.CurrentDomain.BaseDirectory);
        _config = builder.Build();


    }

    //private static async Task SendEmailsForRequestsAsync(List<Guid> requestIds)
    //{
    //    ResolveDependices();
    //    var quoteManager = _serviceProvider.GetRequiredService<IQuoteManager>();
    //    var quoteRepository = _serviceProvider.GetRequiredService<IQuoteRepository>();
    //    var logger = _serviceProvider.GetRequiredService<ILogManager>();
    //    var templateRenderer = _serviceProvider.GetRequiredService<ITemplateRenderer>();

    //    //if (!CheckSmtpHealthAsync().GetAwaiter().GetResult())
    //    //{
    //    //    logger.Warn("SMTP health check failed. Emails will not be sent.");
    //    //    return;
    //    //}

    //    var data = quoteRepository.GetVendorsForEmailByIds(requestIds);

    //    foreach (var item in data)
    //    {
    //        foreach (var vendor in item.Vendors)
    //        {
    //            var dto = new QuoteEmailContentDto
    //            {
    //                Subject = vendor.IsDomestic ? "Tedarikçi Geçerlilik Tarihi Hatırlatma" : "Supplier Validity Date Reminder",
    //                ReqQuoteNo = item.ReqQuoteNo,
    //                DocDueDate = item.DocDueDate,
    //                ContactEmail = vendor.ContactEmail,
    //                ContactName = vendor.ContactName,
    //                ApplicationUrl = _config["ApplicationUrl"],
    //                TemplatePath = GetTemplatePath(vendor.IsDomestic),
    //                IsDomestic = vendor.IsDomestic,
    //            };

    //            var emailBody = await templateRenderer.RenderTemplateAsync(dto.TemplatePath, dto);
    //            await SendEmailAsync(dto, emailBody);
    //        }
    //    }
    //}

    private static void ResolveDependices()
    {
        _serviceProvider.GetRequiredService<IConfigManager>();
        _serviceProvider.GetRequiredService<IEmailService>();
        _serviceProvider.GetRequiredService<IHttpContextAccessor>();
        _serviceProvider.GetRequiredService<IMessageRepository>();
        _serviceProvider.GetRequiredService<IMessageCacheService>();
        _serviceProvider.GetRequiredService<IMessageManager>();
    }

    private static string GetTemplatePath(bool isDomestic)
    {
        return isDomestic
            ? Path.Combine("Emails", "Templates", "ExpiryReminderTemplate_TR.cshtml")
            : Path.Combine("Emails", "Templates", "ExpiryReminderTemplate_EN.cshtml");
    }

    //private static async Task<bool> CheckSmtpHealthAsync()
    //{
    //    using var client = new SmtpClient();
    //    try
    //    {
    //        await client.ConnectAsync(
    //            _config["Email:Host"],
    //            int.Parse(_config["Email:Port"]),
    //            bool.Parse(_config["Email:UseSSL"]));
    //        await client.DisconnectAsync(true);
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}

}
