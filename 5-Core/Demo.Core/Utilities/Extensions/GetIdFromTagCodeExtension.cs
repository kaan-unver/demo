
namespace Demo.Business.Helpers.Extensions
{

    public static class GetIdFromTagCodeExtension
    {

        public static int GetIdFromTagCode(this string code)
        {
            var numericPart = code.Substring(8).TrimStart('0');
            return int.TryParse(numericPart, out int result) ? result : 0;
        }
    }
}
