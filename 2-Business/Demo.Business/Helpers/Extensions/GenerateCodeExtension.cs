

namespace Demo.Business.Helpers.Extensions
{

    public static class GenerateCodeExtension
    {
        public static int GenerateCode()
        {
            Random random = new Random();
            return random.Next(10000, 100000);
        }

    }
}
