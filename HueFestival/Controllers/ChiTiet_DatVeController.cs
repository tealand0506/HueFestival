using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTiet_DatVeController : ControllerBase
    {
        private readonly IChiTiet_DatVeRepository _CTDVrepository;
        private readonly HueFestival_DbContext _context;
        public ChiTiet_DatVeController( HueFestival_DbContext context, IChiTiet_DatVeRepository CTDVrepository)
        {
            _context = context;
            _CTDVrepository = CTDVrepository;
        }


        [HttpPost("DatVe")]
        public async Task<object> DatVe ([FromForm]ChiTiet_DatVeDTO ctdvDTO)
        {
            var ChiTietDatVe = await _CTDVrepository.DatVe(ctdvDTO);
            var ThongTinKhachHang = _context.KhachHangs.FirstOrDefault(kh => kh.IdKhachHang == ctdvDTO.IdKhachHang);
            var ThongTinVe = _context.ThongTin_Ves.FirstOrDefault(ve => ve.IdVe == ctdvDTO.IdVe);
            return Ok(new { ChiTietDatVe, ThongTinKhachHang, ThongTinVe});
        }

    }
}
