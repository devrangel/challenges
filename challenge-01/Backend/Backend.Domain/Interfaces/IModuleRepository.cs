using Backend.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Domain.Interfaces
{
    public interface IModuleRepository
    {
        Task<ICollection<Module>> GetAllAsync();
        Task<Module> GetByIdAsync(int id);
        Task CreateAsync(Module module);
        Task UpdateAsync(Module module);
        Task RemoveAsync(Module module);
    }
}
