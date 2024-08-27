using GraduationProject.Domain.Models;
using GraduationProject.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public UserController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Register(string username, string password, string role)
        {
            _userService.Register(username, password, role);

            return Ok();
        }
        [HttpGet("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Login(string username, string password)
        {

            if (_userService.Login(username, password, out string role))
            {
                return Ok(_jwtService.GenerateToken(username, role));
            }
            return Unauthorized();
        }

        [HttpGet("get_all_users")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0ad9ab6d-d7dd-4089-9b60-052e603889a7")]
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userService.GetAllUsersAsync();
        }

        [HttpDelete("delete_user")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0ad9ab6d-d7dd-4089-9b60-052e603889a7")]
        public async Task<IActionResult> DeleteUser([FromForm] Guid userId)
        {
            _userService.UserToRemoveAsync(userId);

            return NoContent();
        }
    }
}
