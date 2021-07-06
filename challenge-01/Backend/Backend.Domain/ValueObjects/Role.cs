using Backend.Domain.Validations;

namespace Backend.Domain.ValueObjects
{
    public class Role
    {
        public string RoleValue{ get; private set; }

        // Para o EF
        protected Role()
        {

        }

        public Role(string roleValue)
        {
            DomainValidation.IsValidRole("Role", roleValue);

            RoleValue = roleValue;
        }
    }
}
