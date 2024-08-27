using GraduationProject.Domain.Models;
using GraduationProject.Dto;

namespace GraduationProject.Services.Interfaces
{
    public interface IInformationService
    {
        public Task<IEnumerable<Information>> GetAllInformationsAsync();
        public Task AddUserInformationAsync(CreateUserInformationDto request, string user);
        public Task<Information?> GetOneUserInformationByUserIdAsync(Guid id);
        public Task UpdateUserFirstNameAsync(Guid userId, string firstName, string user);
        public Task UpdateUserLastNameAsync(Guid userId, string lastName, string user);
        public Task UpdateUserPersonalCodeAsync(Guid userId, long personalCode, string user);
        public Task UpdateUserPhoneNumberAsync(Guid userId, string phoneNumber, string user);
        public Task UpdateUserEmailAddressAsync(Guid userId, string emailAddress, string user);
        public Task UpdateUserImageAsync(Guid userId, UserImageDto image, string user);
    }
}
