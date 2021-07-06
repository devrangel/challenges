using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.Users
{
    public class PutUserDTO
    {
        [Required(ErrorMessage = "{0} is required")]
        public int Id { get; set; }

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

        public PutUserDTO(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
