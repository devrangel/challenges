using Backend.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<ICollection<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task CreateAsync(Course course);
        Task UpdateAsync(Course course);
        Task RemoveAsync(Course course);
    }
}
