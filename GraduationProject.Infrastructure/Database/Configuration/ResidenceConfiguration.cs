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

            builder.HasOne(ur => ur.Information)
                .WithMany(ur => ur.Residences)
                .HasForeignKey(ur => ur.InformationId);

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


            //Seed data
            //builder.HasData(
            //    new Residence
            //    {
            //        ResidenceId = new Guid("24268096-3e58-4076-9ada-b9c7fc13baf7"),
            //        City = "New York",
            //        Street = "Oston road",
            //        HouseNumber = "54",
            //        ApartmentNumber = "02",
            //        InformationId = new Guid("40ad82b2-758e-4a4c-91ba-b50720a7f6b2"),
            //    }
            //    ,
            //    new Residence
            //    {
            //        ResidenceId = new Guid("e58dedf0-2fee-42c2-bf7b-2c3b89eb1e96"),
            //        City = "Old York",
            //        Street = "New road",
            //        HouseNumber = "33",
            //        ApartmentNumber = "99",
            //        InformationId = new Guid("ec760583-0fd1-42b1-a212-65378a465c7d"),
            //    }
            //);
        }
    }
}
