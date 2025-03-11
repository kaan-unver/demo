
namespace Demo.Business.Helpers.Extensions
{
    public static class PhoneNumExtension
    {
        public static string GetPhoneNumWithCountryCode(this string phoneNum)
        {
            return phoneNum.Split("+")[1];
        }
    }
}
