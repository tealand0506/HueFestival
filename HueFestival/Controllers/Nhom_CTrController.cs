using HueFestival.Models;
using HueFestival.Repositories;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Nhom_CTrController : ControllerBase
    {

        private readonly INhom_CTrRepository _nhomCTRepsitory;
        public Nhom_CTrController (INhom_CTrRepository nhomCTRepsitory)
        {
            _nhomCTRepsitory = nhomCTRepsitory;
        }
        // GET: api/<Nhom_CTrController>
        [HttpGet("DS_NhomCTr")]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var dsNhomCT = await _nhomCTRepsitory.GetAllNhom_CTrRepository();
                return Ok(dsNhomCT);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<Nhom_CTrController>/5
        [HttpGet("NhomCT/{id}")]
        public async Task<object> GetDiaDiemByIdSubMenu(int id)
        {
            var nhomCT = await _nhomCTRepsitory.GetByIdNhom_CTrRepository(id);
            return nhomCT;
        }


        // POST api/<Nhom_CTrController>
        [HttpPost("Them_NhomCT")]
        public async Task<IActionResult> AddLoai_DiaDiem(string tenNhom)
        {
            try
            {
                var themNhomCT = await _nhomCTRepsitory.PostNhom_CTrRepository(tenNhom);
                return Ok(themNhomCT);
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
