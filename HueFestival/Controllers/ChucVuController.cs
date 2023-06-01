using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuRepository _chucVuRepository;

        public ChucVuController(IChucVuRepository chucVuRepository)
        {
            _chucVuRepository = chucVuRepository;
        }


        [HttpGet("DanhSach-ChucVu")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var chucVuList = await _chucVuRepository.GetAllChucVuAsync();
                return Ok(chucVuList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Them-ChucVu")]
        public async Task<ActionResult<ChucVu>> PostChucVuAsync(string TenChucVu)
        {
            var result = await _chucVuRepository.PostChucVuAsync(TenChucVu);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("CapNhat-ChucVu{id}")]
        public async Task<IActionResult> PutAsync(int id, ChucVu chucVu)
        {
            if (chucVu == null || id != chucVu.IdChucVu)
            {
                return BadRequest();
            }

            await _chucVuRepository.PutChucVuAsync(chucVu, id);

            return NoContent();
        }

        [HttpDelete("Xoa-ChucVu/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _chucVuRepository.DeleteChucVuAsync(id);

            return NoContent();
        }
    }
}
