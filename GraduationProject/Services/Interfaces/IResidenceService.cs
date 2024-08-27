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
        public Task UpdateUserCityAsync(Guid userId, string street);
        public Task UpdateUserStreetAsync(Guid userId, string street);
        public Task UpdateUserHouseNumberAsync(Guid userId, string houseNumber);
        public Task UpdateUseApartmentNumberAsync(Guid userId, string apartmentNumber);
    }
}
