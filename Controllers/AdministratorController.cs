using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AuthenticationAndAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequireAdministratorRole")]
    public class AdministratorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string response = "solo administradores";
            if(User.IsInRole("SuperAdmin")) // si se centa con ambos roles 
            {
                response += ", eres super admin";
            }
            return Ok(response);
        }
    }
}
