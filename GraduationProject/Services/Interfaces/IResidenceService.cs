using GraduationProject.Domain.Models;
using GraduationProject.Dto;

namespace GraduationProject.Services.Interfaces
{
    public interface IResidenceService
    {
        public Task<IEnumerable<Residence>> GetAllResidencesAsync();
        public Task<Residence?> GetResidenceByIdAsync(Guid id);
        public Task AddUserResidenceAsync(CreateUserResidenceDto request, string user);
    }
}
