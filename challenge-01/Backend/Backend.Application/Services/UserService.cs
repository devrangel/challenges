using Backend.Application.Auth;
using Backend.Application.DTOs.Users;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetUserDTO> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if(user == null)
            {
                return null;
            }

            var dto = new GetUserDTO(
                user.Id, 
                user.Username.FirstName, 
                user.Username.LastName, 
                user.Email.Address,
                user.Role.RoleValue);

            return dto;
        }

        public async Task<dynamic> GetAuthUser(AuthUserDTO user)
        {
            var model = await _repository.GetAuthUser(user.Email, user.Password);
            
            if(model == null)
            {
                return null;
            }

            var token = TokenService.GenerateToken(model);

            var dto = new GetUserDTO(
                model.Id,
                model.Username.FirstName,
                model.Username.LastName,
                model.Email.Address,
                model.Role.RoleValue);

            return new
            {
                user = dto,
                token = token
            };
        }

        public async Task<List<Tuple<string, string>>> CreateAsync(PostUserDTO userDto)
        {
            var username = new Username(userDto.FirstName, userDto.LastName);
            var email = new Email(userDto.Email);
            var password = new Password(userDto.Password);

            // Por padrao sempre criar um novo usuario como student
            var role = new Role("student");

            if(DomainValidation.Length() == 0)
            {
                await _repository.CreateAsync(new User(username, email, password, role));
                return new List<Tuple<string, string>>();
            }

            return DomainValidation.GetNotificationsAndClear();
        }

        public async Task<List<Tuple<string, string>>> UpdateAsync(PutUserDTO userDto)
        {
            var model = await _repository.GetByIdAsync(userDto.Id);

            if(model == null)
            {
                return null;
            }

            model.Update(userDto.FirstName, userDto.LastName, userDto.Email);

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
