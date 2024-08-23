using GraduationProject.Domain.Models;
using GraduationProject.Infrastructure.Database;
using GraduationProject.Infrastructure.Interfaces.IServices.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Infrastructure.Services.Repositories
{
    public class UserResidenceRepository : IUserResidenceRepository
    {
        private readonly UserDbContext _dbContext;

        public UserResidenceRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUserResidenceAsync(Residence residence)
        {
            _dbContext.Add(residence);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Residence?> GetUserResidenceByInformationIdAsync(Guid id)
        {
            return await _dbContext.Residences.FirstOrDefaultAsync(x => x.InformationId == id);
        }

        public async Task<IList<Residence>> GetUserResidencesAsync()
        {
            return await _dbContext.Residences.ToListAsync();
        }

    }
}
