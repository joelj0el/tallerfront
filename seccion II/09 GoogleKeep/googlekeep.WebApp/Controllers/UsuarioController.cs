using googlekeep.Business;
using googlekeep.Entity;
using googlekeep.WebApp.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace googlekeep.WebApp.Controllers
{
    [Route("api/usuario")]
    [Authorize]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioBusiness usuarioBusiness;
        public UsuarioController()
        {
            usuarioBusiness = new UsuarioBusiness();
        }
        // GET: api/<ValuesController>
        [Route("getall")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = usuarioBusiness.getAll();
            return Ok(result);
        }

        // SaveOrUpdate
        [Route("save")]
        [HttpPost]
        public IActionResult SaveOrUpdate([FromBody] UsuarioModel entity)
        {
            // implementar metodo de guardado o actualización
            var usuarioEntity = usuarioBusiness.getById(entity.id) ?? new Usuario();
            usuarioEntity.id = entity.id;
            usuarioEntity.name = entity.name;
            usuarioEntity.email = entity.email;
            usuarioEntity.password = entity.password;
            var result = usuarioBusiness.SaveOrUpdate(usuarioEntity);
            entity.id = result.id; // Asignar el ID generado al modelo
            return Ok(entity);
        }

        //POST api/usuario/delete/6
        // Delete
        [Route("delete/{entityId}")]
        [HttpPost]
        public IActionResult Delete(int entityId)
        {
            var usuarioEntity = usuarioBusiness.getById(entityId);
            if (usuarioEntity == null)
                throw new Exception("User not found!");
            usuarioBusiness.delete(usuarioEntity);
            return Ok();
        }

        //POST api/usuario/getbyid/6
        // GetById
        [Route("getbyid/{entityId}")]
        [HttpPost]
        public IActionResult GetById(int entityId)
        {
            var usuarioEntity = usuarioBusiness.getById(entityId);
            return Ok(usuarioEntity);
        }

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
