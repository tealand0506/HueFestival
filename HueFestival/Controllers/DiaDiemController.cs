using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaDiemController : ControllerBase
    {
        private readonly IDiaDiemRepository _diaDiemRepository;


        public DiaDiemController(IDiaDiemRepository diaDiemRepository)
        {
            _diaDiemRepository = diaDiemRepository;
        }
        // GET: api/<DiaDiemController>
        [HttpGet("DS_DiaDiem")]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var dsDiaDiem = await _diaDiemRepository.GetAllDiaDiemAsync();
                return Ok(dsDiaDiem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        // GET api/<DiaDiemController>/5
        [HttpGet("Lay_LoaiDD/{id}")]
        public async Task<object> GetDiaDiemByIdSubMenu(int id)
        {
            var diaDiem = await _diaDiemRepository.GetDiaDiemById(id);
            return diaDiem;
        }

        // POST api/<DiaDiemController>
       /*[HttpPost]
        public IActionResult AddDiaDiem(DiaDiemDTO model)
        {

        }
        */

    }
}
