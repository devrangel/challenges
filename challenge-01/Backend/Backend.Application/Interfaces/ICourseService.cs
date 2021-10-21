using Backend.Application.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Application.Interfaces
{
    public interface ICourseService
    {
        Task<ICollection<GetCourseDTO>> GetAllAsync();
        Task<GetCourseDTO> GetByIdAsync(int id);
        Task<ICollection<GetCourseDTO>> GetByModule(int id);
        Task<List<Tuple<string, string>>> CreateAsync(PostCourseDTO courseDto);
        Task<List<Tuple<string, string>>> UpdateAsync(PutCourseDTO courseDto);
        Task RemoveAsync(int id);
    }
}
