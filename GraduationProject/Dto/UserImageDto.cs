using GraduationProject.Atributes;

namespace GraduationProject.Dto
{
    public class UserImageDto
    {
        [AllowedExtension([".jpeg", ".jpg", ".png"])]
        public IFormFile Image { get; set; }
    }
}
