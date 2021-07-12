using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace API.Validations
{
    public class FileTypeValidation: ValidationAttribute
    {
        private readonly List<string> _validTypes;
        public FileTypeValidation(List<string> validTypes)
        {
            _validTypes = validTypes;
        }

        public FileTypeValidation(GroupFileType groupFileType)
        {
            if(groupFileType == GroupFileType.Image)
            {
                _validTypes = new List<string> {"image/jpeg", "image/jpg", "image/png", "image/gif", "application/octet-stream"};
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFIle = value as IFormFile;

            if(formFIle == null)
            {
                return ValidationResult.Success;
            }

            if(!_validTypes.Contains(formFIle.ContentType))
            {
                return new ValidationResult($"Valid file types are: {string.Join(", ", _validTypes)}");
            }

            return ValidationResult.Success;
        }
    }
}