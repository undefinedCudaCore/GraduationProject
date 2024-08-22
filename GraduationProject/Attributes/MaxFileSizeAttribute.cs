﻿using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Atributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult($"File too big {_maxFileSize}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
