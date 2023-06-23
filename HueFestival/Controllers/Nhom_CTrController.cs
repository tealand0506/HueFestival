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
    public class Nhom_CTrController : ControllerBase
    {

        private readonly INhom_CTrRepository _nhomCTRepsitory;
        public Nhom_CTrController (INhom_CTrRepository nhomCTRepsitory)
        {
            _nhomCTRepsitory = nhomCTRepsitory;
        }
        // GET: api/<Nhom_CTrController>
        [HttpGet("DanhSachNhomCTr")]
        public async Task<IActionResult> DanhSachNhomChuongTrinh()
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
        [HttpGet("XuatNhomCT_ThemID/{id}")]
        public async Task<object?> XuatNhomCT_ThemID(int id)
        {
            var nhomCT = await _nhomCTRepsitory.GetByIdNhom_CTrRepository(id);
            return nhomCT;
        }


        // POST api/<Nhom_CTrController>
        [HttpPost("ThemNhomCT")]
        public async Task<IActionResult> ThemNhomCTr(Nhom_CTrDTO nhom)
        {
            try
            {
                var themNhomCT = await _nhomCTRepsitory.PostNhom_CTrRepository(nhom);
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
        [HttpPut("SuaNhomChuongTrinh/{id}")]
        public async Task<IActionResult> SuaNhomChuongTrinh(int id, [FromForm] Nhom_CTrDTO NhomMoi)
        {
            //kiểm tra tồn tại của 
            var NhomCanSua = await _nhomCTRepsitory.GetByIdNhom_CTrRepository(id);
            if (NhomCanSua == null)
            {
                return Ok(new
                {
                    Message = "NHÓM CHƯƠNG TRÌNH CÓ ID = "+id+" KHÔNG TỒN TẠI!"
                });
            }

            await _nhomCTRepsitory.PutNhom_CTrRepository(NhomCanSua, NhomMoi);
            return Ok(new
            {
                Message = "CẬP NHẬT NHÓM CHƯƠN TRÌNH THÀNH CÔNG!"
            });
        }

        // DELETE api/<Nhom_CTrController>/5
        [HttpDelete("XoaNhomChuongTrinh/{id}")]
        public async Task<IActionResult> XoaNhomChuongTrinh(int id)
        {
            //kiểm tra tồn tại của 
            var NhomCanXoa = await _nhomCTRepsitory.GetByIdNhom_CTrRepository(id);
            if (NhomCanXoa == null)
            {
                return Ok(new
                {
                    Message = "ID NÀY KHÔNG TỒN TẠI!"
                });
            }

            await _nhomCTRepsitory.DeleteNhom_CTrRepository(NhomCanXoa);
            return Ok(new { Message = "XÓA NHÓM CHUONG TRÌNH HÀNH CÔNG!" });
        }
    }
}
