using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
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


        // GET: api/<AccountController>
        [HttpGet("DS_TaiKhoan")]
        public async Task<IActionResult> DanhSachTaiKhoan()
        {
            var dsTaiKhoan = await _accountRepository.GetAllTaiKhoan();
            return Ok(dsTaiKhoan);
        }

        [HttpPost("DangNhap")]
        public async Task<ActionResult> DangNhapTaiKhoan([FromForm] string Emaill, [FromForm] string Pass)
        {
            var TaiKhoan = await _accountRepository.DangNhap(Emaill, Pass);
            if (TaiKhoan != null)
            {
                return Ok(new { message = "ĐĂNG NHẬP THÀNH CÔNG", TaiKhoan }) ;
            }
            return Ok("ĐĂNG NHẬP KHÔNG THÀNH CÔNG");
        }

        // POST api/<AccountController>
        [HttpPost]  
        public async Task<object> ThemTaiKhoon([FromForm] AccountDTO Acc)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(tk => tk.TenDN == Acc.TenDN);
            if (account != null)
            {
                return Ok("TÊN ĐĂNG NHẬP NÀY ĐÃ TỒN TẠI");
            }
            if (_context.ChucVus.FirstOrDefault(cv => cv.IdChucVu != Acc.IdChucVu) == null)
            {
                return Ok("CHỨC VỤ NÀY KHÔNG TỒN TẠI");
            }
            var TaiKhoan = await _accountRepository.AddAccountAsync(Acc);
            return Ok(TaiKhoan);
        }

        // PUT api/<AccountController>/5
        [HttpPut("DoiMatKhau")]
        public async Task<object> SuaMatKhau([FromForm] string TenDN, string mk, string mkMoi)
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
        public void XoaTaiKhoan(int id)
        {
        }
    }
}
