using Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Backend.Domain.Entities
{
    public class Module : Entity
    {
        public Name Name { get; private set; }
        public string ImageSrc { get; private set; }
        public ICollection<Course> Courses { get; private set; }

        // Para o EF
        protected Module()
        {

        }

        public Module(Name name, string imageSrc)
        {
            Name = name;
            ImageSrc = imageSrc;
        }

        public void Update(string name, string imageSrc)
        {
            Name = new Name(name);
            ImageSrc = imageSrc;
        }
    }
}
