

namespace Demo.Core.Utilities.Extensions
{
    public static class GenerateCodeForTagExtension
    {

        public static string GenerateCodeForTag(this int id, string key)
        {
            int totalLength = 20;
            int prefixLength = 4;
            int idLength = id.ToString().Length;
            string currentYear = DateTime.Now.Year.ToString();
            int paddingLength = totalLength - prefixLength- currentYear.Length - idLength;

            return $"MRF{key}{currentYear}{new string('0', paddingLength)}{id}";
        }
    }
}


