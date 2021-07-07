using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.Modules
{
    public class PostModuleDTO
    {
        [Required(ErrorMessage = "{0} is required")]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ImageSrc { get; set; }

        public PostModuleDTO(string name, string imageSrc)
        {
            Name = name;
            ImageSrc = imageSrc;
        }
    }
}
