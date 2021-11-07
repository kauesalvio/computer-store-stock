using StoreStock.Application.Models.User;
using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreStock.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(UserRequestModel request)
        {
            if (request is null)
                throw new Exception($"Preencha corretamente os campos para cadastrar um funcionário.");

            var user = UserMapping.MapUserRequestForUser(request);

            await _userRepository.Create(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await CheckIfUserExist(id);

            return user;
        }

        public async Task UpdateUser(int id, UserRequestModel request)
        {
            var user = await CheckIfUserExist(id);

            user.Update(request.Name, request.Email, request.Password);

            _userRepository.Update(user);
        }

        public async Task DeleteUser(int id)
        {
            var user = await CheckIfUserExist(id);

            _userRepository.Delete(user);
        }

        private async Task<User> CheckIfUserExist(int id)
        {
            var userDb = await _userRepository.GetById(id);
            if (userDb is null)
            {
                throw new Exception($"O Usuário com o id {id} não foi encontrado!");
            }

            return userDb;
        }
    }
}
