using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace API.Validations
{
    public class FileSizeValidation: ValidationAttribute
    {
        private readonly int _maxFileSizeInMB;
        public FileSizeValidation(int maxFileSizeInMB)
        {
            _maxFileSizeInMB = maxFileSizeInMB;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if(formFile == null)
            {
                return ValidationResult.Success;
            }

            if(formFile.Length > _maxFileSizeInMB*1024*1024)
            {
                return new ValidationResult($"Maximum filse size allowed is {_maxFileSizeInMB}MB");
            }

            return ValidationResult.Success;
        }
    }
}