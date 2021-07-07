using System;

namespace Backend.Application.DTOs.Courses
{
    public class GetCourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Minutes { get; set; }
        public string ImageSrc { get; set; }
        public DateTime Date { get; set; }
        public int ModuleId { get; set; }

        public GetCourseDTO(int id, string name, string description, uint minutes, string imageSrc, DateTime date, int moduleId)
        {
            Id = id;
            Name = name;
            Description = description;
            Minutes = minutes;
            ImageSrc = imageSrc;
            Date = date;
            ModuleId = moduleId;
        }
    }
}
