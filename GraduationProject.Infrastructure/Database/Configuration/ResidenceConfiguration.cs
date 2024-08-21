using GraduationProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.Infrastructure.Database.Configuration
{
    internal class ResidenceConfiguration : IEntityTypeConfiguration<Residence>
    {
        public void Configure(EntityTypeBuilder<Residence> builder)
        {
            builder.ToTable("residence");

            //PK
            builder.HasKey(ur => ur.ResidenceId);

            //Since using GUID we want to generate ID inside out application
            builder.Property(ur => ur.ResidenceId)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(ur => ur.City)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ur => ur.Street)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ur => ur.HouseNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(ur => ur.ApartmentNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(ur => ur.InformationId)
                .IsRequired();
        }
    }
}
