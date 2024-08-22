using GraduationProject.Atributes;

namespace GraduationProject.Dto
{
    public class CreateUserInformationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        [MaxFileSize(15 * 1024 * 1024)] //15MB
        [AllowedExtrention([".jpeg", ".jpg", ".png"])]
        public IFormFile Image { get; set; }
    }
}
