using Backend.Domain.Validations;

namespace Backend.Domain.ValueObjects
{
    public class Username
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        // Para o EF
        protected Username()
        {

        }

        public Username(string firstName, string lastName)
        {
            DomainValidation.IsNullOrEmpty("FirstName", firstName);
            DomainValidation.LessThanMinLength("FirstName", firstName, 3);
            DomainValidation.GreaterThanMaxLength("FirstName", firstName, 20);
            DomainValidation.HasNumber("FirstName", firstName);

            DomainValidation.IsNullOrEmpty("LastName", lastName);
            DomainValidation.LessThanMinLength("LastName", lastName, 3);
            DomainValidation.GreaterThanMaxLength("LastName", lastName, 20);
            DomainValidation.HasNumber("LastName", lastName);

            FirstName = firstName;
            LastName = lastName;
        }
    }
}
