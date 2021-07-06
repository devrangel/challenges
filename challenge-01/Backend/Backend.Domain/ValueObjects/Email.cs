using Backend.Domain.Validations;

namespace Backend.Domain.ValueObjects
{
    public class Email
    {
        public string Address { get; private set; }

        // Para o EF
        protected Email()
        {

        }

        public Email(string email)
        {
            DomainValidation.IsNullOrEmpty("Email", email);
            DomainValidation.LessThanMinLength("Email", email, 3);

            // Nao é checado no UserDTO para que seja validado no Domain
            DomainValidation.HasAt("Email", email);

            Address = email;
        }
    }
}
