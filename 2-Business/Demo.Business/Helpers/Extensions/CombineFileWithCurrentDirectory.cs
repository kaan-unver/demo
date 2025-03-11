

using Demo.Core.Constants;

namespace Demo.Business.Helpers.Extensions
{
    public static class CombineFileWithCurrentDirectory
    {

        public static string CombinePathAndFile(this string fileName, string folderName, string extension)
        {
            return $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}{folderName}{Path.DirectorySeparatorChar}{fileName + extension}";
        }
    }
}
