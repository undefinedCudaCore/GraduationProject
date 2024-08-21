using GraduationProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.Infrastructure.Database.Configuration
{
    internal class InformationConfiguration : IEntityTypeConfiguration<Information>
    {
        public void Configure(EntityTypeBuilder<Information> builder)
        {
            builder.ToTable("information");

            //PK
            builder.HasKey(ui => ui.InformationId);

            //Since using GUID we want to generate ID inside out application
            builder.Property(ui => ui.InformationId)
                .IsRequired()
                .ValueGeneratedNever();

            builder.HasMany(s => s.Residences)
                .WithOne(s => s.Information)
                .HasForeignKey(s => s.ResidenceId);

            builder.Property(ui => ui.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ui => ui.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ui => ui.PersonalCode)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(ui => ui.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ui => ui.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ui => ui.FileName)
                .IsRequired();

            builder.Property(ui => ui.FileData)
            .IsRequired();

            builder.Property(ui => ui.CreationDateTime)
            .IsRequired();
        }
    }
}
