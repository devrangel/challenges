using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infra.Data.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Module>> GetAllAsync()
        {
            return await _context.Modules
                .AsNoTracking()
                .OrderBy(x => x.Name.ValueName)
                .ToListAsync();
        }

        public async Task<Module> GetByIdAsync(int id)
        {
            return await _context.Modules
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task CreateAsync(Module module)
        {
            _context.Modules.Add(module);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Module module)
        {
            _context.Modules.Update(module);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Module module)
        {
            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();
        }
    }
}
