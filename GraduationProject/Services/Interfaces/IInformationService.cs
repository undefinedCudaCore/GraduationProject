using GraduationProject.Dto;

namespace GraduationProject.Services.Interfaces
{
    public interface IInformationService
    {
        public Task<FileStream> CreateInformationAsync(CreateUserInformationDto request);
    }
}
