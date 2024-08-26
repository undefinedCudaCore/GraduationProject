using GraduationProject.Domain.Models;
using GraduationProject.Dto;

namespace GraduationProject.Services.Interfaces
{
    public interface IInformationService
    {
        public Task<IEnumerable<Information>> GetAllInformationsAsync();
        public Task AddUserInformationAsync(CreateUserInformationDto request, string user);
        public Task<Information?> GetOneUserInformationByUserIdAsync(Guid id);
        public Task UpdateUserFirstNameAsync(Guid userId, string firstName);
        public Task UpdateUserLastNameAsync(Guid userId, string lastName);
        public Task UpdateUserPersonalCodeAsync(Guid userId, long personalCode);
        public Task UpdateUserPhoneNumberAsync(Guid userId, string phoneNumber);
        public Task UpdateUserEmailAddressAsync(Guid userId, string emailAddress);
        public Task UpdateUserImageAsync(Guid userId, UserImageDto image);
    }
}
