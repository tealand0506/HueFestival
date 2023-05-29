using HueFestival.DataTransferObject;
using HueFestival.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaDiemController : ControllerBase
    {
        private readonly HueFestival_DbContext _context;

        public DiaDiemController(HueFestival_DbContext context)
        {
            _context = context;
        }
        // GET: api/<DiaDiemController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsDiaDiem = _context.DiaDiems.ToList();
            return Ok(dsDiaDiem);
        }

        // GET api/<DiaDiemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaDiem>> GetByID(int id)
        {
            var GetbyIdDiaDiem = await _context.DiaDiems.FindAsync(id);

            if (GetbyIdDiaDiem == null)
            {
                return NotFound();
            }

            return GetbyIdDiaDiem;
        }

        // POST api/<DiaDiemController>
        [HttpPost]
        public IActionResult AddDiaDiem(DiaDiemDTO model)
        {
            try
            {
                var DiaDiem = new DiaDiemDTO
                {
                    TenDiaDiem = model.TenDiaDiem
                };
                _context.Add(DiaDiem);
                _context.SaveChanges();
                return Ok(DiaDiem);
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
