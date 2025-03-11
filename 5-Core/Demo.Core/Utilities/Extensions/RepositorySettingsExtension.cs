
using Microsoft.Extensions.Configuration;

namespace Demo.Core.Utilities.Extensions
{
    public static class RepositorySettingsExtension
    {
        public static bool GetManagerFlag()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                                              .AddJsonFile("appsettings.json", optional: false).Build();

            return false;
        }
    }
}
