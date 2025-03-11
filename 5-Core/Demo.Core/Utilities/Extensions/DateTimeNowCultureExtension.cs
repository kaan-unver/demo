using Microsoft.Extensions.Configuration;
namespace Demo.Core.Utilities.Extensions
{
    public static class DateTimeNowCultureExtension
    {
        public static DateTime GetDateTimeNow(this DateTime now)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                                              .AddJsonFile("appsettings.json", optional: false).Build();

            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById(configuration["DefaultTimeZone"]);
            return TimeZoneInfo.ConvertTimeFromUtc(now, cstZone);
        }
    }
}
