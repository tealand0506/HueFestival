using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaDiemController : ControllerBase
    {
        private readonly IDiaDiemRepository _diaDiemRepository;
        private readonly HueFestival_DbContext _context;

        public DiaDiemController(IDiaDiemRepository diaDiemRepository, HueFestival_DbContext context)
        {
            _diaDiemRepository = diaDiemRepository;
            _context = context;
        }
        // GET: api/<DiaDiemController>
        [HttpGet("DS_DiaDiem")]
        public async Task<IActionResult> DanhSachDiaDiem()
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
        [HttpGet("TimDiaDiem/{id}")]
        public async Task<object> XuatDiaDiemTheoID(int id)
        {
            
            var diaDiem = await _diaDiemRepository.GetDiaDiemById(id);
            return diaDiem;
        }

        // POST api/<DiaDiemController>
        [HttpPost("Them_DiaDiem")]
        public async Task<object> ThemDiaDiem([FromForm] DiaDiemDTO dd)
        {
            
            if (_context.DiaDiems.Any(l => l.TenDiaDiem == dd.TenDiaDiem))
            {
                return Ok(new
                {
                    Message = "ĐỊA ĐIỂM NÀY ĐÃ TỒN TẠI!"
                });
            }
            
            
            var addDiaDiem = await _diaDiemRepository.PostDiaDiemAsync(dd);
            return Ok(new
            {
                Message = "THÊM ĐỊA ĐIỂM THÀNH CÔNG!",
                addDiaDiem
            }
            );
        }

        [HttpPut("CapNhatDiaDiem/{id}")]
        public async Task<IActionResult> CapNhatDiaDiem( int id, [FromForm] DiaDiemDTO ddMoi)
        {
            var ddCanSua = await _diaDiemRepository.GetDiaDiemById(id);
            if(ddCanSua == null)
            {
                return Ok("ĐỊA ĐIỂM CÓ ID = "+id+" KHÔNG TỒN TẠI!");
            }

            await _diaDiemRepository.PutDiaDiemAsync(ddCanSua, ddMoi);
            return Ok("CẬP NHẬT THÀNH CÔNG ĐỊA ĐIỂM " + ddCanSua.TenDiaDiem);
        }

        [HttpDelete("XoaDiaDiem/{id}")]
        public async Task<IActionResult> XoaDiaDiem(int id)
        {
            var ddCanXoa = await _diaDiemRepository.GetDiaDiemById(id);
            if (ddCanXoa == null)
            {
                return Ok("ĐỊA ĐIỂM CÓ ID = " + id + " KHÔNG TỒN TẠI!");
            }

            await _diaDiemRepository.DeleteDiaDiemAsync(ddCanXoa);
            return Ok("XÓA THÀNH CÔNG ĐỊA ĐIỂM CÓ ID = " + id);
        }
    }
}
