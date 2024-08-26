using GraduationProject.Domain.Models;

namespace GraduationProject.Infrastructure.Interfaces.IServices.IRepositories
{
    public interface IUserRepository
    {
        void Add(User user);
        User Get(string username);
        public Guid GetUserId(string username);
        public Task<IEnumerable<User>> GetAllAsync();
        public Task RemoveUserAsync(Guid id);
    }
}
