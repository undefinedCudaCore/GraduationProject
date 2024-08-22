using GraduationProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public UserController(IUserService accountService, IJwtService jwtService)
        {
            _userService = accountService;
            _jwtService = jwtService;
        }
        [HttpPost("register")]
        public ActionResult Register(string username, string password, string role)
        {
            _userService.Register(username, password, role);

            return Ok();
        }
        [HttpGet("login")]
        public ActionResult Login(string username, string password)
        {

            if (_userService.Login(username, password))
            {
                return Ok(_jwtService.GenerateToken(username));
            }
            return Unauthorized();
        }
    }

}
