using GraduationProject.Domain.Models;
using GraduationProject.Dto;

namespace GraduationProject.Services.Interfaces
{
    public interface IInformationService
    {
        public Task<IEnumerable<Information>> GetAllInformationsAsync();
        public Task AddUserInformationAsync(CreateUserInformationDto request, string user);
        public Task<Information?> GetOneUserInformationByUserIdAsync(Guid id);
    }
}
