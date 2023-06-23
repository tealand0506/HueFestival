using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin_QuanLy")]
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuRepository _chucVuRepository;

        public ChucVuController(IChucVuRepository chucVuRepository)
        {
            _chucVuRepository = chucVuRepository;
        }


        [HttpGet("DanhSach-ChucVu")]
        public async Task<IActionResult> DanhSachChucVu()
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
        public async Task<ActionResult<ChucVu>> ThemChucVu(ChucVuDTO chucVuMoi)
        {
            var result = await _chucVuRepository.PostChucVuAsync(chucVuMoi);

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
        public async Task<IActionResult> SuaChucVu(int id, ChucVuDTO chucVu)
        {
            var cvCanSua = await _chucVuRepository.GetByIdChecVuAsynnc(id);
            if(cvCanSua == null)
            {
                return Ok("KHÔNG TÌM THẤY CHỨC VỤ CÓ ID = " + id);
            }
            await _chucVuRepository.PutChucVuAsync(cvCanSua, chucVu);

            return Ok("CẬP NHẬT THÀNH CÔNG CHỨC VỤ " + chucVu.TenChucVu);
        }

        [HttpDelete("Xoa-ChucVu/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var cvCanXoa = await _chucVuRepository.GetByIdChecVuAsynnc(id);
            if (cvCanXoa == null)
            {
                return Ok("KHÔNG TÌM THẤY CHỨC VỤ CÓ ID = " + id);
            }
            await _chucVuRepository.DeleteChucVuAsync(cvCanXoa);

            return Ok("XÓA THÀNH CÔNG CHỨC VỤ ID = " + id);
        }
    }
}
