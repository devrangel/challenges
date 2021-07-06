using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.Users
{
    public class PostUserDTO
    {
        [Required(ErrorMessage = "{0} is required")]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }

        public PostUserDTO(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
