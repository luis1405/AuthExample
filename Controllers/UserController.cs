using AuthenticationAndAuthorization.Models;
using AuthenticationAndAuthorization.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAndAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userService;

        public UserController(UserRepository userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]//este endpoint es accesible sin autenticacion
        public ActionResult<string> Get() => 
            Ok("acceso anonimo, cualquiera lo ve");

        [Authorize(Policy = "FemaleOnly")] // solo usuarion femeninos
        [HttpGet("isFemale")]
        public ActionResult<string> IsFemale() =>
            Ok("solo usuarios genero=Femenino");

        [HttpPost]
        public ActionResult<string> Post() =>        
            Ok("cualquier usuario logeado");
        
    }
}
