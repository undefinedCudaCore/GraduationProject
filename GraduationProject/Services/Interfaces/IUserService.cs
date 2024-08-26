using GraduationProject.Domain.Models;

namespace GraduationProject.Services.Interfaces
{
    public interface IUserService
    {
        void Register(string username, string password, string role);
        bool Login(string username, string password, out string role);
        public Task<IEnumerable<User>> GetAllUsersAsync();
        public void UserToRemoveAsync(Guid id);
    }
}
