
namespace Demo.Core.Utilities.Extensions
{
    public static class GenerateOperationNoExtension
    {
        public static string GenerateOperationNo(this int id)
        {
            return $"MRFSEVK{id}";
        }
    }
}
