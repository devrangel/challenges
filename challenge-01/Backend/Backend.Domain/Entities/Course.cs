using Backend.Domain.ValueObjects;
using System;

namespace Backend.Domain.Entities
{
    public class Course : Entity
    {
        public Name Name { get; private set; }
        public Description Description { get; private set; }
        public uint Minutes { get; private set; }
        public string ImageSrc { get; private set; }
        public DateTime Date { get; private set; }

        public int ModuleId { get; private set; }
        public Module Module { get; private set; }

        // Para o EF
        protected Course()
        {

        }

        public Course(Name name, Description description, uint minutes, string imageSrc, int moduleId, DateTime date)
        {
            Name = name;
            Description = description;
            Minutes = minutes;
            ImageSrc = imageSrc;
            ModuleId = moduleId;
            Date = date;
        }

        public void Update(string name, string description, uint minutes, string imageSrc, int moduleId, DateTime date)
        {
            Name = new Name(name);
            Description = new Description(description);
            Minutes = minutes;
            ImageSrc = imageSrc;
            ModuleId = moduleId;
            Date = date;
        }
    }
}
