using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        
        private readonly HueFestival_DbContext _context;

        public AccountController(IAccountRepository accountRepository, HueFestival_DbContext context)
        {
            _accountRepository = accountRepository;
            _context = context;
        }


        //GET: api/<AccountController>
        [HttpGet("DS_TaiKhoan")]
        [Authorize(Policy = "Admin_QuanLy")]
        public async Task<IActionResult> DanhSachTaiKhoan()
        {
            var dsTaiKhoan = await _accountRepository.GetAllTaiKhoan();
            return Ok(dsTaiKhoan);
        }

        [HttpPost("DangNhap")]
        public async Task<ActionResult> DangNhapTaiKhoan([FromForm] AccountDTO DangNhap)
        {
            var TaiKhoan = await _accountRepository.DangNhap(DangNhap);
            if (TaiKhoan == null)
            {
                return Ok("ĐĂNG NHẬP KHÔNG THÀNH CÔNG");
            }
            var ChucVu = _context.NguoiDungs.Where(nd => nd.IdAccount == TaiKhoan.IdAcc).Select(nd => nd.ChucVus).FirstOrDefault();
            var MaToken = await _accountRepository.TaoMaToken(TaiKhoan, ChucVu);
            return Ok(new { message = "ĐĂNG NHẬP THÀNH CÔNG", TaiKhoan, MaToken }) ;
        }


        // PUT api/<AccountController>/5
        [HttpPut("DoiMatKhau")]
        [Authorize(Policy = "Admin_QuanLy_NhanVien")]
        public async Task<object> DoiMatKhau([FromForm] string TenDN, string mk, string mkMoi)
        {

            var acc = await _accountRepository.CheckUsernameAsync(TenDN);
            if (acc == null)
            {
                return Ok("TÊN ĐĂNG NHẬP NÀY KHÔNG TỒN TẠI!");
            }

            else if (acc.Password != mk)
            {
                return Ok("MẬT KHẨU CŨ KHÔNG KHỚP!");
            }

            await _accountRepository.DoiMatKhau(acc, mkMoi);
            return acc;
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin_QuanLy")]
        public async Task<IActionResult> XoaTaiKhoan(int id)
        {
            var acc = await _accountRepository.GetAccountByIDAsync(id);
            if(acc == null)
            {
                return NotFound("KHONG TIM THAY ACCOUNT CO ID = "+id);
            }

            await _accountRepository.DeleteAccountAsync(acc);
            return Ok("XOA TAI KHOAN THANH CONG!");
        }
    }
}
