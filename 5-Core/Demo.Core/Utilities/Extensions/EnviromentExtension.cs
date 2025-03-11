namespace Demo.Core.Utilities.Extensions
{
    public static class EnviromentExtension
    {
        public static string GetEnviromentValue(this string envrimonetKey)
        {
            return Environment.GetEnvironmentVariable(envrimonetKey) ?? string.Empty;
        }
    }
}
