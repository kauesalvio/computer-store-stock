using FluentAssertions;
using NSubstitute;
using StoreStock.Application.Models.User;
using StoreStock.Application.Services;
using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StoreStock.UnitTests
{
    public class UserTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _userService = new UserService(_userRepository);
        }

        [Fact]
        public async Task Should_create_user()
        {
            var request = new UserRequestModel();

            await _userService.CreateUser(request);

            await _userRepository
                .Received(1)
                .Create(Arg.Is<User>(x => x.Name == request.Name &&
                                        x.Email == request.Email &&
                                        x.Password == request.Password));
        }

        [Fact]
        public async Task Should_throw_exception_when_try_create_user()
        {
            var mensagemDeErroEsperada = "Preencha corretamente os campos para cadastrar um funcionário.";

            Func<Task> func = () => _userService.CreateUser(null);

            await func.Should().ThrowAsync<Exception>().WithMessage(mensagemDeErroEsperada);
        }

        [Fact]
        public async Task Should_get_all()
        {
            await _userService.GetAllUsers();

            await _userRepository
                .Received(1).GetAll();
        }
    }
}
