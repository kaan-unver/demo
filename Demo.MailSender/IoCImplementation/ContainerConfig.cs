

using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Demo.Business.Abstract.Messages;
using Demo.Business.Concrete.Messages;
using Demo.Business.Emails;
using Demo.Business.Mapping;
using Demo.Caching.Messages;
using Demo.Core.ConfigManager;
using Demo.Core.Logging;
using Demo.Infrastructure.Abstract.Messages;
using Demo.Infrastructure.Concrete.EF.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ALPDemo.MailSender.IoCImplementation
{
    public static class ContainerConfig
    {
        public static Autofac.IContainer ConfigureIoc(IServiceCollection services)
        {

            var serviceCollection = new ServiceCollection()
                .AddMemoryCache()
                .AddAutoMapper(typeof(MapProfile));


            var builder = new ContainerBuilder();
            builder.Populate(serviceCollection);

            builder.RegisterType<Mapper>().As<IMapper>();
            builder.RegisterType<NLogManager>().As<ILogManager>();
            builder.RegisterType<ConfigurationManager>().As<IConfiguration>();
            builder.RegisterType<EmailService>().As<IEmailService>();
            builder.RegisterType<RazorTemplateRenderer>().As<ITemplateRenderer>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
            builder.RegisterType<MessageManager>().As<IMessageManager>();
            builder.RegisterType<MessageRepository>().As<IMessageRepository>();
            builder.RegisterType<MessageCacheService>().As<IMessageCacheService>();
            builder.RegisterType<Demo.Core.ConfigManager.ConfigManager>().As<IConfigManager>();




            var container = builder.Build();

            return container;


        }
    }
}
