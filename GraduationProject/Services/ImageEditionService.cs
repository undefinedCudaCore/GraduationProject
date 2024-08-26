using GraduationProject.Dto;
using GraduationProject.Services.Interfaces;
using System.Drawing;
using System.Drawing.Imaging;

namespace GraduationProject.Services
{
    public class ImageEditionService : IImageEditionService
    {
        public async Task<byte[]> ResizeImageAsync(UserImageDto imgDto)
        {
            try
            {
                using var thumbnailMemoryStream = new MemoryStream();
                await imgDto.Image.CopyToAsync(thumbnailMemoryStream);
                thumbnailMemoryStream.Position = 0;
                using Bitmap bitmap = new Bitmap(thumbnailMemoryStream);
                Size thumbnailSize = GetThumbnailSize(bitmap);
                using var thumbnail = bitmap.GetThumbnailImage(thumbnailSize.Width, thumbnailSize.Height, null, IntPtr.Zero);
                using var byteMemoryStream = new MemoryStream();
                thumbnail.Save(byteMemoryStream, ImageFormat.Jpeg);
                return byteMemoryStream.ToArray();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        private static Size GetThumbnailSize(Bitmap oem)
        {
            try
            {
                const int maximumPixels = 200;
                int oemWidth = oem.Width;
                int oemHeight = oem.Height;
                double fact;
                if (oemWidth > oemHeight)
                {
                    fact = (double)maximumPixels / oemWidth;
                }
                else
                {
                    fact = (double)maximumPixels / oemHeight;
                }
                return new Size((int)(oemWidth * fact), (int)(oemHeight * fact));
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
