namespace Demo.Core.Utilities.Extensions
{
    public static class StringExtension
    {
        public static T Parse<T>(this string s, IFormatProvider? provider = null) where T : IParsable<T>
        {
            return T.Parse(s, provider);
        }
        public static List<string> ConvertToListFromString(this string value)
        {
            return value.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        public static string ConvertToStringFromList(this List<string> value)
        {
            return string.Join(",", value);
        }

    }
}
