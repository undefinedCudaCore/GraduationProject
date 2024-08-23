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

            builder.HasOne(ui => ui.User)
                .WithOne(ui => ui.Information)
                .HasForeignKey<Information>(ui => ui.InformationId)
                .IsRequired();

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


            //Seed data
            //builder.HasData(
            //    new Information
            //    {
            //        InformationId = new Guid("40ad82b2-758e-4a4c-91ba-b50720a7f6b2"),
            //        FirstName = "John",
            //        LastName = "Doe",
            //        PersonalCode = 12345678912,
            //        PhoneNumber = "112",
            //        EmailAddress = "john@doe.com",
            //        FileName = "pic01.jpg",
            //        FileData = new byte[] { (byte)4, (byte)3, (byte)2 },
            //    }
            //    ,
            //    new Information
            //    {
            //        InformationId = new Guid("ec760583-0fd1-42b1-a212-65378a465c7d"),
            //        FirstName = "Dohn",
            //        LastName = "Joe",
            //        PersonalCode = 12345678912,
            //        PhoneNumber = "112",
            //        EmailAddress = "dohn@joe.com",
            //        FileName = "pic02.jpg",
            //        FileData = new byte[] { (byte)4, (byte)3, (byte)2 },
            //    }
            //);
        }
    }
}
