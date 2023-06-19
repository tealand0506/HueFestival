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
    public class ThongTin_VeController : ControllerBase
    {
        private readonly IVeRepository _veRepository;
        private readonly HueFestival_DbContext _context;

        public ThongTin_VeController(IVeRepository veRepository, HueFestival_DbContext context)
        {
            _veRepository = veRepository;
            _context = context;
        }


        // GET: api/<ThongTin_VeController>
        [HttpGet("DS_Ve")]
        public async Task<IActionResult> DanhSachVe()
        {
            try
            {
                var dsVe = await _veRepository.DanhSachThongTinVe();
                return Ok(dsVe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<ThongTin_VeController>/5
        [HttpGet("PhatHanhVe/{id}")]
        public async Task<object> TimVeTheoId(int id)
        {

            var Ve = await _veRepository.GetByIdThongTinVe(id);
            return Ve;
        }

        // POST api/<ThongTin_VeController>
        [HttpPost]
        public async Task<object> PhatHanhVe([FromForm] ThongTin_VeDTO Ve)
        {

            if(_context.ThongTin_Ves.Any(kt => kt.IdCTr == Ve.IdCTr && kt.IdLoai_Ve ==Ve.IdLoai_ve))
            {
                return Ok(new
                {
                    Message = "CHƯƠNG TRÌNH "+Ve.IdCTr+" LOẠI "+Ve.IdLoai_ve+" ĐÃ CÓ SẲN!"
                });
            }


            var ThongTin_Ve = await _veRepository.PostThongTinVe(Ve);
            return Ok(new
            {
                Message = "PHÁT HÀNH VÉ THÀNH CÔNG!!!",
                ThongTin_Ve
            }
            );
        }


        // PUT api/<ThongTin_VeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ThongTin_VeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
