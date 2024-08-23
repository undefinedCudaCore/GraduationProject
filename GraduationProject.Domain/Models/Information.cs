namespace GraduationProject.Domain.Models
{
    public class Information
    {
        public Information()
        {
        }

        public Information(Guid informationId, string firstName, string lastName, long personalCode, string phoneNumber, string emailAddress, string? fileName, byte[]? fileData, IList<Residence> residences)
        {
            InformationId = informationId;
            FirstName = firstName;
            LastName = lastName;
            PersonalCode = personalCode;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            FileName = fileName;
            FileData = fileData;
            Residences = residences;
        }

        public Guid InformationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public IList<Residence> Residences { get; set; } = new List<Residence>();
    }
}
