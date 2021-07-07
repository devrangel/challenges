using Backend.Application.DTOs.Courses;
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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository courseRepository)
        {
            _repository = courseRepository;
        }
        
        public async Task<ICollection<GetCourseDTO>> GetAllAsync()
        {
            var courses = await _repository.GetAllAsync();

            if(courses == null)
            {
                return null;
            }

            ICollection<GetCourseDTO> dtos = new List<GetCourseDTO>();

            foreach(var course in courses)
            {
                var dto = new GetCourseDTO(
                    course.Id,
                    course.Name.ValueName,
                    course.Description.Message,
                    course.Minutes,
                    course.ImageSrc,
                    course.Date,
                    course.ModuleId);

                dtos.Add(dto);
            }

            return dtos;
        }
        
        public async Task<GetCourseDTO> GetByIdAsync(int id)
        {
            var course = await _repository.GetByIdAsync(id);

            if (course == null)
            {
                return null;
            }

            var dto = new GetCourseDTO(
                    course.Id,
                    course.Name.ValueName,
                    course.Description.Message,
                    course.Minutes,
                    course.ImageSrc,
                    course.Date,
                    course.ModuleId);

            return dto;
        }

        public async Task<ICollection<GetCourseDTO>> GetByModule(int id)
        {
            var courses = await _repository.GetByModule(id);

            if (courses == null)
            {
                return null;
            }

            ICollection<GetCourseDTO> dtos = new List<GetCourseDTO>();

            foreach (var course in courses)
            {
                var dto = new GetCourseDTO(
                    course.Id,
                    course.Name.ValueName,
                    course.Description.Message,
                    course.Minutes,
                    course.ImageSrc,
                    course.Date,
                    course.ModuleId);

                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<List<Tuple<string, string>>> CreateAsync(PostCourseDTO courseDto)
        {
            var name = new Name(courseDto.Name);
            var description = new Description(courseDto.Description);
            var minutes = courseDto.Minutes;
            var imageSrc = courseDto.ImageSrc;
            int moduleId = courseDto.ModuleId;
            var date = courseDto.Date;

            if(DomainValidation.Length() == 0)
            {
                await _repository.CreateAsync(new Course(name, description, minutes, imageSrc, moduleId, date));
                return new List<Tuple<string, string>>();
            }

            return DomainValidation.GetNotificationsAndClear();
        }

        public async Task<List<Tuple<string, string>>> UpdateAsync(GetCourseDTO courseDto)
        {
            var model = await _repository.GetByIdAsync(courseDto.Id);

            if (model == null)
            {
                return null;
            }

            model.Update(courseDto.Name, courseDto.Description, courseDto.Minutes, courseDto.ImageSrc, courseDto.ModuleId, courseDto.Date);

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
