using HueFestival.Models;
using HueFestival.Repositories;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoanNTController : ControllerBase
    {
        private readonly IDoanNTRepository _doanNTRepository;
        public DoanNTController(IDoanNTRepository doanNTRepository)
        {
            _doanNTRepository = doanNTRepository;
        }


        // GET: api/<DoanNTController>
        [HttpGet("DS_DoanNT")]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var dsDoanNT = await _doanNTRepository.GetAllDoanNT();
                return Ok(dsDoanNT);
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

        // GET api/<DoanNTController>/5
        [HttpGet("LayDoanNT/{id}")]
        public async Task<object> GetDiaDiemByIdSubMenu(int id)
        {
            var diaDiems = await _doanNTRepository.GetByIdDoanNT(id);
            return diaDiems;
        }

        // POST api/<DoanNTController>
        [HttpPost("Them_LoaiDiaDiem")]
        public async Task<IActionResult> AddLoai_DiaDiem(string TenDoan)
        {
            try
            {
                var ThemDoanNT = await _doanNTRepository.PostDoanNT(TenDoan);
                return Ok(ThemDoanNT);
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

        // PUT api/<DoanNTController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoanNTController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
