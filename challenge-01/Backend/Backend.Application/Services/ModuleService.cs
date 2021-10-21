using Backend.Application.DTOs.Modules;
using Backend.Application.Interfaces;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Validations;
using Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Application.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _repository;

        public ModuleService(IModuleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<GetModuleDTO>> GetAllAsync()
        {
            var (modules, courses) = await _repository.GetAllAsync();

            if (modules == null)
            {
                return null;
            }

            ICollection<GetModuleDTO> dtos = new List<GetModuleDTO>();

            int totalCourses = 0;
            foreach (var module in modules)
            {
                foreach(var course in courses)
                {
                    if(course.ModuleId == module.Id)
                    {
                        totalCourses++;
                    }
                }

                var dto = new GetModuleDTO(
                    module.Id,
                    module.Name.ValueName,
                    totalCourses
                );

                dtos.Add(dto);
                totalCourses = 0;
            }

            return dtos;
        }
        
        public async Task<GetModuleDTO> GetByIdAsync(int id)
        {
            var (module, courses) = await _repository.GetByIdAsyncWithHours(id);

            if (module == null)
            {
                return null;
            }

            int totalCourses = 0;
            foreach (var course in courses)
            {
                totalCourses++;
            }

            return new GetModuleDTO(
                module.Id, 
                module.Name.ValueName,
                totalCourses
           );
        }
        
        public async Task<List<Tuple<string, string>>> CreateAsync(PostModuleDTO moduleDto)
        {
            var name = new Name(moduleDto.Name);

            if (DomainValidation.Length() == 0)
            {
                await _repository.CreateAsync(new Module(name));
                return new List<Tuple<string, string>>();
            }

            return DomainValidation.GetNotificationsAndClear();
        }

        public async Task<List<Tuple<string, string>>> UpdateAsync(PutModuleDTO moduleDto)
        {
            var model = await _repository.GetByIdAsync(moduleDto.Id);

            if (model == null)
            {
                return null;
            }

            model.Update(moduleDto.Name);

            if (DomainValidation.Length() == 0)
            {
                await _repository.UpdateAsync(model);
                return new List<Tuple<string, string>>();
            }

            return DomainValidation.GetNotificationsAndClear();
        }

        public async Task RemoveAsync(int id)
        {
            var model = await _repository.GetByIdAsync(id);

            await _repository.RemoveAsync(model);
        }
    }
}
