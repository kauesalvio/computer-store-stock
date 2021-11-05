using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using System.Threading.Tasks;

namespace StoreStock.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userService.CreateUser(user);

            return Created("Usuário criado com sucesso!", null);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            await _userService.UpdateUser(user);

            return Ok("Usuário atualizado com suceso!");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById([FromBody] int id)
        {
            await _userService.GetUserById(id);

            return Ok();
        }

        [HttpGet("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUser()
        {
            await _userService.GetAllUsers();

            return Ok();
        }
    }
}
