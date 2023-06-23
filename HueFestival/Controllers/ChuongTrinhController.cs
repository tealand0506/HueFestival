#nullable enable
using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin_QuanLy")]
    public class ChuongTrinhController : ControllerBase
    {
        private readonly IChuongTrinhRepository _chuongTrinhRepository;
        public ChuongTrinhController(IChuongTrinhRepository chuongTrinhRepository)
        {
            _chuongTrinhRepository = chuongTrinhRepository;
        }
        // GET: api/<ChuongTrinhController>
        [HttpGet("DanhSach_ChuongTrinh")]
        public async Task<IActionResult> DanhSachChuongTrinh()
        {
            var dsChuongTrinh = await _chuongTrinhRepository.GetAllChuongTrinh();
            if (dsChuongTrinh != null)
            {
                return Ok(dsChuongTrinh);
            }
            return NotFound();
        }

        // GET api/<ChuongTrinhController>/5
        [HttpGet("ChuongTrinh/{id}")]
        public async Task<IActionResult> chuongTrinhByID(int id)
        {
            try
            {
                var ChuongTrinh = await _chuongTrinhRepository.GetByIdChuongTrinh(id);
                if (ChuongTrinh != null)
                {
                    return Ok(ChuongTrinh);
                }
                return NotFound("Không tìm thấy chương trình có ID = " + id);
            }
            catch { return BadRequest(); }

        }

        // POST api/<ChuongTrinhController>
        [HttpPost("Them_ChuongTrinh")]
        public async Task<IActionResult> Them_ChuongTrinh([FromForm] ChuongTrinhDTO ctDTO, List<IFormFile> dsHinhAnh)
        {
            try
            {                
                var ChuongTrinh = await _chuongTrinhRepository.PostChuongTrinh(ctDTO, dsHinhAnh);
                return Ok(ChuongTrinh);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ChuongTrinhController>/5
        [HttpPut("CapNhatChuongTrinh/{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] string TenCtr, [FromForm] string MoTa)
        {
            var ctCanSua = await _chuongTrinhRepository.GetByIdChuongTrinh(id);
            if(ctCanSua == null)
            {
                return NotFound($"Không tìm được chương trình với Id={id}");
            }
            await _chuongTrinhRepository.PutChuongTrinh(ctCanSua, TenCtr, MoTa);
            return Ok($"Cập nhật thành công chuong tình có ID={id}");
        }

        // DELETE api/<ChuongTrinhController>/5
        [HttpDelete("XoaChuongTrinh/{id}")]
        public async void Delete(int id)
        {
            var ctCanXoa = await _chuongTrinhRepository.GetByIdChuongTrinh(id);
            if(ctCanXoa != null)
            {
                await _chuongTrinhRepository.DeleteChuongTrinh(ctCanXoa);
            }
        }
    }
}   
