using Backend.Application.DTOs.Modules;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Application.Interfaces
{
    public interface IModuleService
    {
        Task<ICollection<GetModuleDTO>> GetAllAsync();
        Task<GetModuleDTO> GetByIdAsync(int id);
        Task<List<Tuple<string, string>>> CreateAsync(PostModuleDTO moduleDto);
        Task<List<Tuple<string, string>>> UpdateAsync(PutModuleDTO moduleDto);
        Task RemoveAsync(int id);
    }
}
