using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HinhAnh_CTrController : ControllerBase
    {
        private readonly HueFestival_DbContext _context;
        private readonly IHinhAnhCTRepository _hinhAnhRepository;
        public HinhAnh_CTrController(HueFestival_DbContext context, IHinhAnhCTRepository hinhAnhCTRepository)
        {
            _context = context;
            _hinhAnhRepository = hinhAnhCTRepository;
        }
        // GET: api/<HinhAnh_CTrController>
        [HttpGet]
        public async Task<IActionResult> DanhSachHinhAnhCuaCT (int idCT)
        {
            var HinhAnh_CTr = await _hinhAnhRepository.GetHinhAnhByCT(idCT);
            return HinhAnh_CTr == null ? NotFound() : Ok(HinhAnh_CTr);
        }
    }
}
