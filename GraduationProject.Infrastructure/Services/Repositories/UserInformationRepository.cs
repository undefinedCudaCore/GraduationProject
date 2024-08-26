using GraduationProject.Domain.Models;
using GraduationProject.Infrastructure.Database;
using GraduationProject.Infrastructure.Interfaces.IServices.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Infrastructure.Services.Repositories
{
    public class UserInformationRepository : IUserInformationRepository
    {
        private readonly UserDbContext _dbContext;

        public UserInformationRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUserInformationAsync(Information information)
        {
            _dbContext.Add(information);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Information?> GetUserInformationByUserIdAsync(Guid id)
        {
            return await _dbContext.Informations.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<IList<Information>> GetUserInformationsAsync()
        {
            return await _dbContext.Informations.ToListAsync();
        }
        public Information Get(Guid id)
        {
            return _dbContext.Informations.FirstOrDefault(x => x.InformationId == id);
        }

        public async Task UpdateAsync(Information information)
        {
            _dbContext.Update(information);
            await _dbContext.SaveChangesAsync();
        }
    }
}
