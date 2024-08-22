namespace GraduationProject.Domain.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public string Role { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;
        public Guid InformationId { get; set; }
        public Information Information { get; set; }
    }
}