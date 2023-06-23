using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin_QuanLy")]
    public class Loai_DiaDiemController : ControllerBase
    {
        
        private readonly ILoai_DiaDiemRepository _LoaiDiaDiemRepository;
        private readonly HueFestival_DbContext _context;

        public Loai_DiaDiemController(ILoai_DiaDiemRepository LDiaDiemRepository, HueFestival_DbContext context)
        {
            _LoaiDiaDiemRepository = LDiaDiemRepository;
            _context = context;
        }
        // GET: api/<DiaDiemController>
        [HttpGet("DS_LoaiDiaDiem")]
        public async Task<IActionResult> DanhSachLoaiDiaDiem()
        {
            
            try
            {
                var dsLoai_DiaDiem = await _LoaiDiaDiemRepository.GetAllLoai_DiaDiemAsync();
                return Ok(dsLoai_DiaDiem);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<Loai_DiaDiemController>/5
        [HttpGet("Lay_LoaiDD/{id}")]
        public async Task<object> XuatLoaiDiaDiemTheoID(int id)
        {
            var diaDiem = await _LoaiDiaDiemRepository.GetByIdLoai_DiaDiemAsync(id);
            return diaDiem;
        }


        // POST api/<Loai_DiaDiemController>
        [HttpPost("Them_LoaiDiaDiem")]
        public async Task<IActionResult> ThemLoaiDiaDiem([FromForm] Loai_DiaDiemDTO ldd)
        {
            if (_context.Loai_DiaDiems.Any(l => l.TuaDe == ldd.TuaDe))
            {
                return Ok(new
                {
                    Message = "LOẠI ĐỊA ĐIỂM NÀY ĐÃ TỒN TẠI!"
                });
            }


            await _LoaiDiaDiemRepository.PostLoai_DiaDiemAsync(ldd);
            return Ok(new
            {
                Message = "THÊM LOẠI ĐỊA ĐIỂM THÀNH CÔNG!",                
            }
            );
        }

        // PUT api/<Loai_DiaDiemController>/5
        [HttpPut("CapNhat_LoaiDiaDiem/{id}")]
        public async Task<IActionResult> SuaLoaiDiaDiem(int id, [FromForm] Loai_DiaDiemDTO lddMoi)
        {
            //kiểm tra tồn tại của 
            var LDD_CanSua = await _LoaiDiaDiemRepository.GetByIdLoai_DiaDiemAsync(id);
            if (LDD_CanSua == null)
            {
                return Ok("LOẠI ĐỊA ĐIỂM CÓ ID= "+id+" KHÔNG TỒN TẠI!");
            }
           
            await _LoaiDiaDiemRepository.PutLoai_DiaDiemAsync(LDD_CanSua, lddMoi);
            return Ok(new
            {
                Message = "CẬP NHẬT THÀNH CÔNG!"
            });
        }

        // DELETE api/<Loai_DiaDiemController>/5
        [HttpDelete("Xoa_LoaiDiadiem/{id}")]
        public async Task<IActionResult> XoaLoaiDiaDiem(int id)
        {
            //kiểm tra tồn tại của 
            var LDD_CanXoa = await _LoaiDiaDiemRepository.GetByIdLoai_DiaDiemAsync(id);
            if (LDD_CanXoa == null)
            {
                return Ok(new
                {
                    Message = "ID NÀY KHÔNG TỒN TẠI!"
                });
            }
            await _LoaiDiaDiemRepository.DeleteLoai_DiaDiemAsync(LDD_CanXoa);
            return Ok(new { Message = "LOẠI ĐỊA ĐIỂM '"+ LDD_CanXoa.TuaDe + "' ĐÃ ĐƯỢC XÓA!" });
        }
    }
}
