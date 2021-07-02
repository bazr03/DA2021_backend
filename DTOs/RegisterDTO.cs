using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(120)]
        public string Username { get; set; }
        [Required]
        [StringLength(8, MinimumLength =4)]
        public string Password { get; set; }
    }
}