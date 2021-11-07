using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreStock.Application.Models.User;
using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using System.Collections.Generic;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateUser([FromBody] UserRequestModel request)
        {
            await _userService.CreateUser(request);

            return Created(string.Empty, "Usuário criado com Sucesso!");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserRequestModel request)
        {
            await _userService.UpdateUser(id, request);

            return Ok("Usuário atualizado com suceso!");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> GetUserById([FromRoute] int id)
        {
            var user = await _userService.GetUserById(id);

            return Ok(user);
        }

        [HttpGet("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            var users = await _userService.GetAllUsers();

            return Ok(users);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
    }
}
