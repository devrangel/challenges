using Backend.Domain.ValueObjects;

namespace Backend.Domain.Entities
{
    public class User : Entity
    {
        public Username Username { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public Role Role { get; private set; }

        // Para o EF
        protected User()
        {

        }

        public User(Username username, Email email, Password password, Role role)
        {
            Username = username;
            Email = email;
            Password = password;
            Role = role;
        }

        public void Update(string firstName, string lastName, string email)
        {
            Username = new Username(firstName, lastName);
            Email = new Email(email);
        }
    }
}
