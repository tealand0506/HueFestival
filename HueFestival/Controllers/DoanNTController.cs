using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin_QuanLy")]
    public class DoanNTController : ControllerBase
    {
        private readonly IDoanNTRepository _doanNTRepository;
        public DoanNTController(IDoanNTRepository doanNTRepository)
        {
            _doanNTRepository = doanNTRepository;
        }


        // GET: api/<DoanNTController>
        [HttpGet("DanhSachDoanNgheThuat")]
        public async Task<IActionResult> DanhSachDoanNgheThuat()
        {

            try
            {
                var dsDoanNT = await _doanNTRepository.GetAllDoanNTAsync();
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
        [HttpGet("DoanNgheThuatTheoID/{id}")]
        public async Task<object> DoanNgheThuatTheoID(int id)
        {
            var diaDiems = await _doanNTRepository.GetByIdDoanNTAsync(id);
            return diaDiems;
        }

        // POST api/<DoanNTController>
        [HttpPost("ThemDoanNgheThuat")]
        public async Task<IActionResult> ThemDoanNgheThuat(DoanNTDTO doanNTMoi)
        {
            try
            {
                var ThemDoanNT = await _doanNTRepository.PostDoanNTAsync(doanNTMoi);
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
        [HttpPut("CapNhatDoanNT/{id}")]
        public async Task<IActionResult> CapNhatDoanNT(int id, [FromBody] DoanNTDTO doanNTMoi)
        {
            var doanNTCanSua = await _doanNTRepository.GetByIdDoanNTAsync(id);
            if(doanNTCanSua == null)
            {
                return Ok("ĐOÀN NGHỆ THUẬT CÓ ID = " + id + " KHÔNG TỒN TẠI!");
            }

            await _doanNTRepository.PutDoanNTAsync(doanNTCanSua, doanNTMoi);
            return Ok("CẬP NHẬT THÀNH CÔNG ĐOÀN NGHỆ THUẬT CÓ ID = " +doanNTMoi.TenDoan);
        }

        // DELETE api/<DoanNTController>/5
        [HttpDelete("XoaDoanNT/{id}")]
        public async Task<IActionResult> XoaDoanNT(int id)
        {
            var doanNTCanXoa = await _doanNTRepository.GetByIdDoanNTAsync(id);
            if (doanNTCanXoa == null)
            {
                return Ok("ĐOÀN NGHỆ THUẬT CÓ ID = " + id + " KHÔNG TỒN TẠI!");
            }

            await _doanNTRepository.DeleteAsync(doanNTCanXoa);
            return Ok("NGÀY XƯA BÀ TẬP GÌ MÀ BẢ KHỎE THẾ Ạ");
        }
    }
}
