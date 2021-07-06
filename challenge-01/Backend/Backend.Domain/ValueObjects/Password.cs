using Backend.Domain.Validations;

namespace Backend.Domain.ValueObjects
{
    public class Password
    {
        public string KeyPassword { get; private set; }

        // Para o EF
        protected Password()
        {

        }

        public Password(string password)
        {
            DomainValidation.LessThanMinLength("Password", password, 8);
            DomainValidation.GreaterThanMaxLength("Password", password, 50);

            KeyPassword = password;
        }
    }
}
