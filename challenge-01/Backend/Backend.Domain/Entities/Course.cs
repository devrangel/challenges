using Backend.Domain.ValueObjects;
using System;

namespace Backend.Domain.Entities
{
    public class Course : Entity
    {
        public Name Name { get; private set; }
        public DateTime Date { get; private set; }

        public int ModuleId { get; private set; }
        public Module Module { get; private set; }

        // Para o EF
        protected Course()
        {

        }

        public Course(Name name, DateTime date, int moduleId)
        {
            Name = name;
            Date = date;
            ModuleId = moduleId;
        }

        public void Update(string name, DateTime date, int moduleId)
        {
            Name = new Name(name);
            ModuleId = moduleId;
            Date = date;
        }
    }
}
