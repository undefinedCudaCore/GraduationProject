using GraduationProject.Domain.Models;
using GraduationProject.Dto;

namespace GraduationProject.Services.Interfaces
{
    public interface IResidenceService
    {
        public Task<IEnumerable<Residence>> GetAllResidencesAsync();
        public Task<Residence?> GetResidenceByInfoIdAsync(Guid id);
        public Task<Residence?> GetResidenceByResidenceIdAsync(Guid id);
        public Task AddUserResidenceAsync(CreateUserResidenceDto request, string user);
        public Task UpdateUserCityAsync(Guid userId, Guid residenceId, string street, string user);
        public Task UpdateUserStreetAsync(Guid userId, Guid residenceId, string street, string user);
        public Task UpdateUserHouseNumberAsync(Guid userId, Guid residenceId, string houseNumber, string user);
        public Task UpdateUseApartmentNumberAsync(Guid userId, Guid residenceId, string apartmentNumber, string user);
    }
}
