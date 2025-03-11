using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Demo.Business.Helpers
{
    internal static class PasswordHelper
    {
        internal static string ComputeHash(string password)
        {
            int iteration = 3;
            string pepper = "Demo_marifet_pepper";
            if (iteration <= 0) return password;

            using var sha256 = SHA256.Create();
            var passwordSaltPepper = $"{password}{pepper}";
            var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
            var byteHash = sha256.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);

        }
        public static bool CheckStrength(string password)
        {
            /*int score = 0;
            if (password.Length < 1)
                return PasswordScore.Blank;
            if (password.Length < 4)
                return PasswordScore.VeryWeak;
            if (password.Length >= 8)
                return false;
            if (password.Length >= 12)
                return false;*/

            if (!Regex.Match(password, "[0-9]").Success)
                return false;
            if (!Regex.Match(password, "[a-z]").Success || !Regex.Match(password, "[A-Z]").Success)
                return false;
            if (!Regex.Match(password, "[!,@,#,$,^,*,?,_,\\-\\(\\)\\.]").Success)
                return false;

            return true;
        }
    }
}
