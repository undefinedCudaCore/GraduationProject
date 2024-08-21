namespace GraduationProject.Domain.Models
{
    internal class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public string Role { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;
        public UserInformation UserInformation { get; set; }
    }
}
