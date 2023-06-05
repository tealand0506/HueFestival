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
    public class Loai_DiaDiemController : ControllerBase
    {
        
        private readonly ILoai_DiaDiemRepository _LoaiDiaDiemRepository;

        public Loai_DiaDiemController(ILoai_DiaDiemRepository LDiaDiemRepository)
        {
            _LoaiDiaDiemRepository = LDiaDiemRepository;
        }
        // GET: api/<DiaDiemController>
        [HttpGet("DS_LoaiDiaDiem")]
        public async Task<IActionResult> GetAll()
        {
            
            try
            {
                var dsLoai_DiaDiem = await _LoaiDiaDiemRepository.GetAllLoai_DiaDiemAsync();
                return Ok(dsLoai_DiaDiem);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<Loai_DiaDiemController>/5
        [HttpGet("Lay_LoaiDD/{id}")]
        public async Task<object> GetDiaDiemByIdSubMenu(int IdLoaiDD)
        {
            var diaDiem = await _LoaiDiaDiemRepository.GetByIdLoai_DiaDiemAsync(IdLoaiDD);
            return diaDiem;
        }


        // POST api/<Loai_DiaDiemController>
        [HttpPost("Them_LoaiDiaDiem")]
        public async Task<IActionResult> AddLoai_DiaDiem(Loai_DiaDiem ldd)
        {
            try
            {
                var themLoaiDiaDiem = await _LoaiDiaDiemRepository.PostLoai_DiaDiemAsync(ldd);
                return Ok(themLoaiDiaDiem);
            }
            catch (IOException ex)
            {
                   return BadRequest(ex.Message);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
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
