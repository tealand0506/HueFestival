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
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangRepository _khachHangRepository;
        private readonly HueFestival_DbContext _context;
        public KhachHangController(IKhachHangRepository khachHangRepository, HueFestival_DbContext context)
        {
            _khachHangRepository = khachHangRepository;
            _context = context;
        }

        // GET: api/<KhachHangController>
        [HttpGet("DS_KhachHang")]
         public async Task<IActionResult> DsKhachHang()
        {

            try
            {
                var dsKhachHang = await _khachHangRepository.GetAllKhachHangAsync();
                return Ok(dsKhachHang);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<KhachHangController>/5
        [HttpGet("TimKhachHang/{id}")]
        public async Task<KhachHang?> TimKhachHang_ID(int id)
        {

            var khachHang = await _khachHangRepository.GetByIdKhachHangAsync(id);
            return khachHang;
        }

        // POST api/<KhachHangController>
        [HttpPost("ThemKhachHang")]
        public async Task<object> ThemKhachHang([FromForm] KhachHangDTO kh)
        {
            if(kh.SDT.Length != 11 || kh.CCCD.Length !=12)
            {
                return Ok(new
                {
                    Message = "MÃ CCCD HOẶC SDT KHÔNG HỢP LỆ!"
                });
            }
            else if (_context.KhachHangs.Any(cccd => cccd.CCCD == kh.CCCD))
            {
                return Ok(new
                {
                    Message = "THÔNG TIN CỦA KHÁCH HÀNG "+ kh.HoTen +" ĐÃ CÓ SẲN!"
                });
            }


            var themKhachHang = await _khachHangRepository.PostKhachHangAsync(kh);
            return Ok(new
            {
                Message = "THÊM THÔNG TIN THÀNH CÔNG!",
                themKhachHang
            }
            );
        }

        // PUT api/<KhachHangController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<KhachHangController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
