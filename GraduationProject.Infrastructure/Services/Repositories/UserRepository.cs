using GraduationProject.Domain.Models;
using GraduationProject.Infrastructure.Database;
using GraduationProject.Infrastructure.Interfaces.IServices.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Infrastructure.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        public User Get(string username)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Username == username);
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public Guid GetUserId(string username)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Username == username).UserId;
        }

        public async Task RemoveUserAsync(Guid id)
        {
            var userToRemove = _dbContext.Users.FirstOrDefault(u => u.UserId == id);

            if (userToRemove == null)
            {
                return;
            }

            _dbContext.Users.Remove(userToRemove);
            await _dbContext.SaveChangesAsync();
        }
    }
}
