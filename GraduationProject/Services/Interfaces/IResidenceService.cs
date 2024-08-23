using GraduationProject.Domain.Models;

namespace GraduationProject.Services.Interfaces
{
    public interface IResidenceService
    {
        public Task<IEnumerable<Residence>> GetAllResidencesAsync();
        public Task<Residence?> GetResidenceByIdAsync(Guid id);

    }
}
