using google.server.Business;
using Microsoft.AspNetCore.Mvc;


namespace googlekeep.WebApp.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly UsuarioBusiness usuarioBusiness;
        public ValuesController()
        {
            usuarioBusiness = new UsuarioBusiness();
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = usuarioBusiness.GetAll();
            return Ok(result);
        }

        // SaveOrUpdate

        // Delete

        // GetById

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
