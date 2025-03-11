
namespace Demo.Business.Helpers.Extensions
{


    public static class ChangeToDbCharacterExtension
    {
        public static string ChangeToDbCharacter(this string type)
        {
            return type == "order" ? "Sipariş" : "Tamir";
        }
    }
}
