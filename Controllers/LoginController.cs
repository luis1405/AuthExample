using AuthenticationAndAuthorization.Models;
using AuthenticationAndAuthorization.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAndAuthorization.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UsuarioLogin user)
        {
            return Ok(_loginService.Login(user));
        }

        [HttpPost("registrar")]
        public ActionResult<User> Registrar(User user)
        {
            return Ok(_loginService.Registrar(user));
        }
    }
}
