using Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities
{
    public class Module : Entity
    {
        public Name Name { get; private set; }
        public ICollection<Course> Courses { get; private set; }

        // Para o EF
        protected Module()
        {

        }

        public Module(Name name)
        {
            Name = name;
            Courses = new List<Course>();
        }

        public void Update(string name)
        {
            Name = new Name(name);
        }
    }
}
