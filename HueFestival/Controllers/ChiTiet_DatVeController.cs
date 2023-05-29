using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CHiTiet_DatVeController : ControllerBase
    {
        // GET: api/<CHiTiet_DatVeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CHiTiet_DatVeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CHiTiet_DatVeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CHiTiet_DatVeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CHiTiet_DatVeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
