using Backend.Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Application.Interfaces
{
    public interface IUserService
    {
        Task<GetUserDTO> GetByIdAsync(int id);
        Task<dynamic> GetAuthUser(AuthUserDTO user);
        Task<List<Tuple<string, string>>> CreateAsync(PostUserDTO userDto);
        Task<List<Tuple<string, string>>> UpdateAsync(PutUserDTO userDto);
        Task RemoveAsync(int id);
    }
}
