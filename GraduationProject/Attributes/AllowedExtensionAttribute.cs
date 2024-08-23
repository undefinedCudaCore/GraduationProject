using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Atributes
{
    public class AllowedExtensionAttribute : ValidationAttribute
    {
        private readonly string[] _extentions;
        public AllowedExtensionAttribute(string[] extentions)
        {
            _extentions = extentions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                if (!_extentions.Contains(extention.ToLower()))
                {
                    return new ValidationResult($"This photo is not allowed{string.Join(", ", _extentions)}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
