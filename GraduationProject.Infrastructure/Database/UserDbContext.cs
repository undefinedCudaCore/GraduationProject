using GraduationProject.Domain.Models;
using GraduationProject.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Infrastructure.Database
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<Residence> Residences { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InformationConfiguration());
            modelBuilder.ApplyConfiguration(new ResidenceConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
