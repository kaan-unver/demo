
using Microsoft.AspNetCore.Http;
using System.Drawing.Imaging;
using System.Drawing;
using Demo.Business.Helpers.Extensions;
using Demo.Core.Constants;

namespace Demo.Business.Helpers
{
    internal static class FileHelper
    {
        internal static async Task<string> SaveImage(IFormFile imageFile, string folderName)
        {
            string newFileName = Guid.NewGuid().ToString();
            if (!Directory.Exists($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}{folderName}"))
            {
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}{folderName}");
            }

            using (var stream = new MemoryStream())
            {
                await imageFile.CopyToAsync(stream);
                using (var originalImage = Image.FromStream(stream))
                {
                    int width = 100; int height = 100;
                    Image imageToSave = originalImage;
                    if (originalImage.Width != width || originalImage.Height != 100)
                    {
                        var resizedImage = new Bitmap(width, height);
                        using (var graphics = Graphics.FromImage(resizedImage))
                        {
                            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            graphics.DrawImage(originalImage, 0, 0, width, height);
                        }
                        imageToSave = resizedImage;
                    }
                    string filePath = newFileName.CombinePathAndFile(folderName, Constants.JPG); //newFileName.CombinePathAndFile(""); //Path.Combine(folderName, newFileName + Constants.JPG);

                    var imageFormat = imageFile.ContentType != Constants.ContentTypeJpg ? ImageFormat.Jpeg : originalImage.RawFormat;

                    imageToSave.Save(filePath, imageFormat);
                }
            }

            return newFileName;
        }
    

        internal static async Task<string> SavePdf(IFormFile pdfFile, string folderName)
        {
            string newFileName = Guid.NewGuid().ToString();

        
            if (!Directory.Exists($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}{folderName}"))
            {
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}{folderName}");
            }

            string filePath = newFileName.CombinePathAndFile(folderName, Constants.PDF); 

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }

            return newFileName;
        }


    }
}
