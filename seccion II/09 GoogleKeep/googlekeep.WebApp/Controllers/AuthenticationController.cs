using FluentNHibernate.Conventions;
using FluentNHibernate.Data;
using googlekeep.Business;
using googlekeep.WebApp.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace googlekeep.WebApp.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UsuarioBusiness usuarioBusiness;
        private readonly IConfiguration _config;
        public AuthenticationController(IConfiguration config)
        {
            usuarioBusiness = new UsuarioBusiness();
            _config = config;
        }
        [Route("login/{email}/{password}")]
        [HttpPost]
        public IActionResult login(string email, string password)
        {
            // validar el modelo
            if (password.IsEmpty() || email.IsEmpty())
                return BadRequest("Invalid credentials!");
            // verificar si existe en la base de datos
            usuarioBusiness.Login(email, password);
            return Ok();
        }
        [Route("loginv2")]
        [HttpPost]
        public IActionResult loginBack([FromBody] AuthenticationModel entity)
        {
            // validar el modelo
            if (entity.password.IsEmpty() || entity.email.IsEmpty())
                return BadRequest("Invalid credentials!");
            // verificar si existe en la base de datos
            usuarioBusiness.Login(entity.email, entity.password);
            return Ok();
        }

        [Route("verifycode/{email}/{code}")]
        [HttpPost]
        public IActionResult VerifyCode(string email, string code)
        {
            if (code.IsEmpty() || email.IsEmpty())
                return BadRequest("Invalid credentials!");
            var result = usuarioBusiness.isValidCode(email, Convert.ToInt32(code.Trim()));
            if(result)
            {
                //Generamos JWT
                var token = GenerateJWT(email);
                return Ok(token);
            } else
                return BadRequest("Invalid credentials!");
        }

        private string GenerateJWT(string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, email)
                //new Claim(ClaimTypes.Role.user.Role)
            };
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claim,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
