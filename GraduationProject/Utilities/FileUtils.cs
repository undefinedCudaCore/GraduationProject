namespace GraduationProject.Utilities
{
    public class FileUtils
    {
        public static async Task<byte[]> ConvertToByteArray(IFormFile? file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
