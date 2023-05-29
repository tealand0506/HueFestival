using HueFestival.DataTransferObject;
using HueFestival.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Loai_DiaDiemController : ControllerBase
    {
        private readonly HueFestival_DbContext _context;

        public Loai_DiaDiemController(HueFestival_DbContext context)
        {
            _context = context;
        }
        // GET: api/<DiaDiemController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai_DiaDiem = _context.LoaiDiaDiems.ToList();
            return Ok(dsLoai_DiaDiem);
        }

        // GET api/<Loai_DiaDiemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Loai_DiaDiemController>
        [HttpPost]
        public IActionResult AddLoai_DiaDiem(Loai_DiaDiemDTO model)
        {
            try
            {
                var Loai_DiaDiem = new Loai_DiaDiemDTO
                {
                    TuaDe = model.TuaDe
                };
                _context.Add(Loai_DiaDiem);
                _context.SaveChanges();
                return Ok(Loai_DiaDiem);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<Loai_DiaDiemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Loai_DiaDiemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
