using GraduationProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.Infrastructure.Database.Configuration
{
    internal class UserResidenceConfiguration : IEntityTypeConfiguration<UserResidence>
    {
        public void Configure(EntityTypeBuilder<UserResidence> builder)
        {
            throw new NotImplementedException();
        }
    }
}
