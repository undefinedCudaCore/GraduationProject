namespace GraduationProject.Domain.Models
{
    internal class UserInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }

        public int UserId { get; set; }
        public IList<UserResidence> UserResidences { get; set; }
    }
}
