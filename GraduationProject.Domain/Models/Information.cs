namespace GraduationProject.Domain.Models
{
    public class Information
    {
        public Guid InformationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;

        public IList<Residence> Residences { get; set; } = new List<Residence>();
    }
}
