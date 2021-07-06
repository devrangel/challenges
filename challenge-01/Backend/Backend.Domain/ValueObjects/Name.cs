using Backend.Domain.Validations;

namespace Backend.Domain.ValueObjects
{
    public class Name
    {
        public string ValueName { get; private set; }

        // Para o EF
        protected Name()
        {

        }

        public Name(string name)
        {
            DomainValidation.IsNullOrEmpty("Name", name);
            DomainValidation.LessThanMinLength("Name", name, 3);
            DomainValidation.GreaterThanMaxLength("Name", name, 30);
            DomainValidation.HasNumber("Name", name);

            ValueName = name;
        }
    }
}
