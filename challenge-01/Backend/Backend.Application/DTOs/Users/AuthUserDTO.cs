using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.Users
{
    public class AuthUserDTO
    {
        [Required(ErrorMessage = "{0} is required")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }

        public AuthUserDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
