using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Nhom_CTrController : ControllerBase
    {
        // GET: api/<Nhom_CTrController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Nhom_CTrController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Nhom_CTrController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Nhom_CTrController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Nhom_CTrController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
