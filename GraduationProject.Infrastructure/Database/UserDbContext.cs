using GraduationProject.Domain.Models;
using GraduationProject.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Infrastructure.Database
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Residence> Residences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new InformationConfiguration());
            modelBuilder.ApplyConfiguration(new ResidenceConfiguration());
        }
    }
}
