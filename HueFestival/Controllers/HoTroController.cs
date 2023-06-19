using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoTroController : ControllerBase
    {
        private readonly HueFestival_DbContext _context;
        private readonly IHoTroRepository _hoTroRepository;
        public HoTroController(HueFestival_DbContext context, IHoTroRepository hoTroRepository)
        {
            _context = context;
            _hoTroRepository = hoTroRepository;
        }

        [HttpGet("DanhSachHoTro")]
        public async Task<IActionResult> DanhSachHoTro()
        {
            var dsHoTro = await _hoTroRepository.DanhSachHoTro();
            return Ok(dsHoTro);
        }

        [HttpGet("XuatHoTroTheoID/{id}")]
        public async Task<HoTro?> XuatHoTroTheoID(int id)
        {
            var HoTro = await _hoTroRepository.XuatHoTroTheoID(id);
            return HoTro;
        }

        [HttpPost("ThemHoTo")]
        public async Task<IActionResult> ThemHoTro([FromForm] HoTroDTO hoTro)
        {
            var themHoTro = await _hoTroRepository.ThemHoTro(hoTro);
            return Ok(themHoTro);
        }

        [HttpDelete("XoaHoTro/{id}")]
        public async Task<IActionResult> XoaHoTro(int id)
        {
            var HoTroCanXoa = await _hoTroRepository.XuatHoTroTheoID(id);
            if(HoTroCanXoa == null)
            {
                return Ok("KHÔNG TÌM THẤY HỖ TRỢ CÓ ID = "+id);
            }
            await _hoTroRepository.XoaHoTro(HoTroCanXoa);
            return Ok("ĐÃ XÓA THÀNH CÔNG HỖ TRỢ "+ HoTroCanXoa.HoTroName);
        }

        [HttpPut("CapNhatHoTro/{id}")]
        public async Task<IActionResult> CapNhatHoTro(int id, [FromForm] HoTroDTO HoTroMoi)
        {
            var HoTroCanSua = await _hoTroRepository.XuatHoTroTheoID(id);
            if (HoTroCanSua == null)
            {
                return Ok("KHÔNG TÌM THẤY HỖ TRỢ CÓ ID = " + id);
            }
            await _hoTroRepository.SuaHoTro(HoTroMoi,HoTroCanSua);
            return Ok("CẬP NHẬT THÀNH CÔNG HỖ TRỢ '" + HoTroCanSua.HoTroName+"'");
        }
    }
}
