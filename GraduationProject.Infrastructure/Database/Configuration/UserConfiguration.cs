using GraduationProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationProject.Infrastructure.Database.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            //PK
            builder.HasKey(u => u.UserId);

            //Since using GUID we want to generate ID inside out application
            builder.Property(u => u.UserId)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Salt)
                .IsRequired();

            builder.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.CreationDateTime)
                .IsRequired();

            builder.Property(u => u.InformationId)
                .IsRequired();

            // Index
            builder.HasIndex(u => u.Username)
            .IsUnique();

            ////Seed data
            //builder.HasData(
            //    new User
            //    {
            //        UserId = new Guid("88685614-3690-4835-a749-a3fa0c3a18a7"),
            //        Username = "JohnDoe",
            //        Password = new byte[] { (byte)4, (byte)3, (byte)2 },
            //        Salt = new byte[] { (byte)4, (byte)3, (byte)2 },
            //        Role = "User",
            //        CreationDateTime = DateTime.Now,
            //        UserInformation = new UserInformation
            //        {
            //            UserInformationId = new Guid("3dcd569f-5cb1-4f64-9ed0-5f02c7a2e250"),
            //            FirstName = "John",
            //            LastName = "Doe",
            //            PersonalCode = 12345678912,
            //            PhoneNumber = "112",
            //            EmailAddress = "john@doe.com",
            //            FileName = "pic01.jpg",
            //            FileData = new byte[] { (byte)4, (byte)3, (byte)2 },
            //            UserId = new Guid("88685614-3690-4835-a749-a3fa0c3a18a7"),
            //            UserResidences = new List<UserResidence>()
            //            {
            //                new UserResidence
            //                {
            //                    UserInformationId = new Guid("40ad82b2-758e-4a4c-91ba-b50720a7f6b2"),
            //                    City = "New York",
            //                    Street = "Oston road",
            //                    HouseNumber = "54",
            //                    ApartmentNumber = "02",
            //                    UserResidenceId = new Guid("3dcd569f-5cb1-4f64-9ed0-5f02c7a2e250"),
            //                }
            //            }
            //        }
            //    },
            //    new User
            //    {
            //        UserId = new Guid("ba9a2ff3-b87e-4b18-adfc-aea8d7be538b"),
            //        Username = "DohnJoe",
            //        Password = new byte[] { (byte)4, (byte)3, (byte)2 },
            //        Salt = new byte[] { (byte)4, (byte)3, (byte)2 },
            //        Role = "Admin",
            //        CreationDateTime = DateTime.Now,
            //        UserInformation = new UserInformation
            //        {
            //            UserInformationId = new Guid("24268096-3e58-4076-9ada-b9c7fc13baf7"),
            //            FirstName = "Dohn",
            //            LastName = "Joe",
            //            PersonalCode = 12345678912,
            //            PhoneNumber = "112",
            //            EmailAddress = "dohn@joe.com",
            //            FileName = "pic02.jpg",
            //            FileData = new byte[] { (byte)4, (byte)3, (byte)2 },
            //            UserId = new Guid("ba9a2ff3-b87e-4b18-adfc-aea8d7be538b"),
            //            UserResidences = new List<UserResidence>()
            //            {
            //                new UserResidence
            //                {
            //                    UserInformationId = new Guid("1cde07c2-9f98-48cf-aea7-d3c8cfab2607"),
            //                    City = "Old York",
            //                    Street = "New road",
            //                    HouseNumber = "33",
            //                    ApartmentNumber = "99",
            //                    UserResidenceId = new Guid("24268096-3e58-4076-9ada-b9c7fc13baf7"),
            //                }
            //            }
            //        }
            //    }
            //);
        }
    }
}
