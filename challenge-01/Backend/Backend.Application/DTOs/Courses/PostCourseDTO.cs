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
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int ModuleId { get; set; }

        public PostCourseDTO(string name, DateTime date, int moduleId)
        {
            Name = name;
            Date = date;
            ModuleId = moduleId;
        }
    }
}
