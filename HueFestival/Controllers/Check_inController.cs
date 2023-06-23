using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HueFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Check_inController : ControllerBase
    {
        private readonly ICheckInRepository _repository;
        public Check_inController(ICheckInRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<Check_inController>
        [HttpGet]
        [Authorize(Policy = "Admin_QuanLy")]
        public async Task<object> DanhSachCheckIn()
        {
            var dsCheckin= await _repository.danhSachCheckIn();
            return dsCheckin;
        }


        // POST api/<Check_inController>
        [HttpPost]
        [Authorize(Policy = "Admin_QuanLy_NhanVien")]
        public async Task<object> Checkin([FromForm] string QRcode)
        {
            var checkin = await _repository.Check_In(QRcode);
            return Ok(checkin);
        }

  
    }
}
