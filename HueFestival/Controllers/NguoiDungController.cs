using System.Net;
using System.Net.Mail;
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
    [Authorize(Policy = "Admin_QuanLy")]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungRepository _INguoiDungRepository;
        private readonly IAccountRepository _IAccountRepository;
        private readonly HueFestival_DbContext _context;

        public NguoiDungController(IAccountRepository IAccountRepository,  INguoiDungRepository INguoiDungRepository, HueFestival_DbContext context)
        {
            _IAccountRepository = IAccountRepository;
            _INguoiDungRepository = INguoiDungRepository;
            _context = context;
        }

        //danh sach nguoi dung theo chuc vu
        [HttpGet("DanhSachNguoiDung")]
        public async Task<IActionResult> DanhSachNguoiDung()
        {
            var dsNguoiDung = await _INguoiDungRepository.GetNguoiDungByChucVuAsync();
            if(dsNguoiDung == null)
            {
                return NotFound();
            }
            return Ok(dsNguoiDung);
        }

        
        //nguoi dung ID
        [HttpGet("NguoiDungTheoID/{id}")]
        public async Task<IActionResult> NguoiDungTheoId(int id)
        {
            var nguoiDung = await _INguoiDungRepository.GetNguoiDungbyIdAsync(id);
            if(nguoiDung == null)
            {
                return NotFound("NGƯỜI DÙNG CÓ ID= "+ id+"KHÔNG TỒN TẠI!");
            }
            return Ok(nguoiDung);
        }

        //tao nguoi dung - acc
        [HttpPost("ThemNguoiDungMoi")]
        public async Task<IActionResult> ThemNguoiDung([FromForm]NguoiDungDTO nd)
        {
            var themTaiKhoan = await _IAccountRepository.PostAccountAsync(nd.SDT,nd.Email, nd.IdChucVu);
            var themNguoiDung = await _INguoiDungRepository.PostNguoiDungAsync(nd, themTaiKhoan.IdAcc);
            string chucVu = await _context.ChucVus
                                 .Where(cv => cv.IdChucVu == themNguoiDung.IdChucVu)
                                 .Select(cv => cv.TenChucVu)
                                 .FirstOrDefaultAsync();
            string ThongBao = "ĐÃ TẠO THÀNH CÔNG THÔNG TIN NGƯỜI DÙNG:'"+nd.HoTen+"' CHỨC VỤ: "+chucVu+"\n\n ĐĂNG NHẬP VỚI: \nTÊN ĐĂNG NHẬP LÀ '"+nd.Email+"' \nMẬT KHẨU LÀ '"+nd.SDT+"'";
            
            return Ok(ThongBao);
        }
        // private void ThongBaoDangNhap(string NoiDung, string ThongTin, string emailNhan )
        // {
        //     string emailGui = "tealandtran1510@gmail.com";

        //     //email của người gửi
        //     string emailPassword = "__";
        //     string emailHost = "smtp.example.com";
        //     int emailPort = 993 ;

        //     // Tạo đối tượng MailMessage để gửi email
        //     MailMessage message = new MailMessage(emailGui, emailNhan, NoiDung, ThongTin);
        //     message.IsBodyHtml = true;

        //     // Khai báo đối tượng SmtpClient để gửi email
        //     SmtpClient smtpClient = new SmtpClient(emailHost, emailPort);
        //     smtpClient.UseDefaultCredentials = false;
        //     smtpClient.Credentials = new NetworkCredential(emailGui, emailPassword);
        //     smtpClient.EnableSsl = true;

        //     // Gửi email
        //     smtpClient.Send(message);
        // }

    }
}