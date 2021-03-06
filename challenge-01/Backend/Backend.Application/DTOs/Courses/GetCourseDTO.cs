using System;

namespace Backend.Application.DTOs.Courses
{
    public class GetCourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ModuleId { get; set; }

        public GetCourseDTO(int id, string name, DateTime date, int moduleId)
        {
            Id = id;
            Name = name;
            Date = date;
            ModuleId = moduleId;
        }
    }
}
