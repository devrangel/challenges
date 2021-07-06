using Backend.Domain.Validations;

namespace Backend.Domain.ValueObjects
{
    public class Description
    {
        public string Message { get; private set; }

        // Para o EF
        protected Description()
        {

        }

        public Description(string description)
        {
            DomainValidation.IsNullOrEmpty("Description", description);
            DomainValidation.GreaterThanMaxLength("Description", description, 140);

            Message = description;
        }
    }
}
