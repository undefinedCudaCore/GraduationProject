using GraduationProject.Domain.Models;
using GraduationProject.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Infrastructure.Database
{
    internal class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
        public DbSet<UserResidence> UserResidences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserInformationConfiguration());
            modelBuilder.ApplyConfiguration(new UserResidenceConfiguration());
        }
    }
}
