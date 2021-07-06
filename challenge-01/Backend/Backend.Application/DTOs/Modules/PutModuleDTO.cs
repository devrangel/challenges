using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.Modules
{
    public class PutModuleDTO
    {
        [Required(ErrorMessage = "{0} is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        public PutModuleDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
