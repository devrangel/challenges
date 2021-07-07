using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.Courses
{
    public class PostCourseDTO
    {
        [Required(ErrorMessage = "{0} is required")]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MinLength(1)]
        [MaxLength(140)]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public uint Minutes { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ImageSrc { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int ModuleId { get; set; }

        public PostCourseDTO(string name, string description, uint minutes, string imageSrc, DateTime date, int moduleId)
        {
            Name = name;
            Description = description;
            Minutes = minutes;
            ImageSrc = imageSrc;
            Date = date;
            ModuleId = moduleId;
        }
    }
}
