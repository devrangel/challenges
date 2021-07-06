using Backend.Domain.ValueObjects;
using System;

namespace Backend.Domain.Entities
{
    public class Course : Entity
    {
        public Name Name { get; private set; }
        public Description Description { get; private set; }
        public DateTime Date { get; private set; }
         
        public int ModuleId { get; private set; }
        public Module Module { get; private set; }

        // Para o EF
        protected Course()
        {

        }

        public Course(Name name, Description description, int moduleId, DateTime date)
        {
            Name = name;
            Description = description;
            ModuleId = moduleId;
            Date = date;
        }

        public void Update(string name, string description, int moduleId, DateTime date)
        {
            Name = new Name(name);
            Description = new Description(description);
            ModuleId = moduleId;
            Date = date;
        }
    }
}
