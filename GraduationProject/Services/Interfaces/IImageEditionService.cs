using GraduationProject.Dto;

namespace GraduationProject.Services.Interfaces
{
    public interface IImageEditionService
    {
        public Task<byte[]> ResizeImageAsync(UserImageDto imgDto);
    }
}
