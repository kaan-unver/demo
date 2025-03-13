using Autofac;
using System.Reflection;
using Demo.Business.Mapping;
using Demo.Caching.Messages;
using Demo.Core.ConfigManager;
using Demo.Core.Logging;
using Demo.Infrastructure.Context;
using Demo.Business.Emails;

namespace Demo.Api.IoC
{
    public class RepoServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConfigManager>().As<IConfigManager>();
            builder.RegisterType<NLogManager>().As<ILogManager>();
            builder.RegisterType<MessageCacheService>().As<IMessageCacheService>();
            var apiAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(DemoContext))!).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(MapProfile))!).Where(x => x.Name.EndsWith("Manager")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<EmailService>().As<IEmailService>();
            builder.RegisterType<RazorTemplateRenderer>().As<ITemplateRenderer>();
        }
    }
}
