using GraduationProject.Domain.Models;
using GraduationProject.Infrastructure.Database;
using GraduationProject.Infrastructure.Interfaces.IServices.IRepositories;

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

    }
}
