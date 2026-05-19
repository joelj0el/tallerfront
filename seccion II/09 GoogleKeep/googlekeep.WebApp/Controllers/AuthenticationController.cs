using FluentNHibernate.Conventions;
using googlekeep.WebApp.models;
using Microsoft.AspNetCore.Mvc;

namespace googlekeep.WebApp.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        //private readonly UsuarioBusiness usuarioBusiness;
        public AuthenticationController()
        {
            //usuarioBusiness = new UsuarioBusiness();
        }
        [Route("login/{email}/{password}")]
        [HttpPost]
        public IActionResult login(string email, string password)
        {
            // validar el modelo
            //if (entity.password.IsEmpty() || entity.email.IsEmpty())
            //    return BadRequest("Completar las credenciales!");
            // verificar si existe en la base de datos
            return Ok();
        }
        [Route("loginv2")]
        [HttpPost]
        public IActionResult loginBack([FromBody] AuthenticationModel entity)
        {
            // validar el modelo
            if (entity.password.IsEmpty() || entity.email.IsEmpty())
                return BadRequest("Completar las credenciales!");
            // verificar si existe en la base de datos
            return Ok();
        }
    }
}
