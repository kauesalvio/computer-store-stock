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

        [HttpPost("provider")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userService.CreateUser(user);

            return Ok();
        }

        [HttpPost("user/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            _userService.Update(user);

            return Ok();
        }

        [HttpGet("userById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById([FromBody] int id)
        {
            await _userService.GetUserId(id);

            return Ok();
        }

        [HttpGet("getAllUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUser()
        {
            await _userService.GetAll();

            return Ok();
        }
    }
}
