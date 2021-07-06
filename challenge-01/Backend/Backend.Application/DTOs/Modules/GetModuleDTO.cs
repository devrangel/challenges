using System.Collections.Generic;
using Backend.Domain.Entities;

namespace Backend.Application.DTOs.Modules
{
    public class GetModuleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GetModuleDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
