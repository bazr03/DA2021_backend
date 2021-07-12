using API.Validations;
using Microsoft.AspNetCore.Http;

namespace API.DTOs
{
    public class PhotoCreationDTO
    {
        [FileSizeValidation(maxFileSizeInMB:4)]
        [FileTypeValidation(GroupFileType.Image)]
        public IFormFile File { get; set; }
    }
}