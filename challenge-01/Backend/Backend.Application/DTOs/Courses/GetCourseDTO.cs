using System;

namespace Backend.Application.DTOs.Courses
{
    public class GetCourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int ModuleId { get; set; }

        public GetCourseDTO(int id, string name, string description, DateTime date, int moduleId)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            ModuleId = moduleId;
        }
    }
}
