using Backend.Domain.Entities;
using System.Threading.Tasks;

namespace Backend.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetAuthUser(string email, string password);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(User user);
    }
}
