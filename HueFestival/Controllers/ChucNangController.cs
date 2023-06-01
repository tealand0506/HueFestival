using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using HueFestival.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucNangController : ControllerBase
    {
        private readonly IChucNangRepository _chucNangRepository;

        public ChucNangController(IChucNangRepository chucNangRepository)
        {
            _chucNangRepository = chucNangRepository;
        }   
        

        [HttpGet]
        public async Task<ActionResult<List<ChucNang>>> GetAllChucNangAsync()
        {
            var chucNangList = await _chucNangRepository.GetAllChucNangAsync();
            if (chucNangList == null)
            {
                return NotFound();
            }
            return Ok(chucNangList);
        }

        [HttpPost("Them-ChucNang")]
        public async Task<ActionResult<ChucNang>> PostChucNangAsync(string TenChucNang)
        {
            var result = await _chucNangRepository.PostChucNangAsync(TenChucNang);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("CapNhat-ChucNang/{id}")]
        public async Task<ActionResult> PutChucNangAsync(int id, [FromBody] ChucNang chucNang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _chucNangRepository.PutChucNangAsync(chucNang, id);
            return Ok();
        }

        [HttpDelete("Xoa-ChucNang/{id}")]
        public async Task<ActionResult> DeleteChucNangAsync(int id)
        {
            await _chucNangRepository.DeleteChucNangAsync(id);
            return Ok();
        }
    }
}
