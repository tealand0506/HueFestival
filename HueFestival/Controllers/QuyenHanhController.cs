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
    public class QuyenHanhController : ControllerBase
    {
        private readonly IQuyenHanhRepository _quyenHanhRepository;
        public QuyenHanhController(IQuyenHanhRepository quyenHanhRepository)
        {
            _quyenHanhRepository =  quyenHanhRepository;
        }


            [HttpGet("DS-QuyenhHanh")]
            public async Task<IActionResult> GetAllAsync()
            {
                try
                {
                    var DSQuyenHanh = await _quyenHanhRepository.GetAllQuyenHanhWithNameAsync();
                    return Ok(DSQuyenHanh);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            // POST api/<QuyenHanhController>
            [HttpPost("Them_QuyenHanh")]
            public async Task<IActionResult> ThemQuyenHanh(QuyenHanhDTO QH_Dto)
            {
                if (QH_Dto == null)
                {
                    return BadRequest();
                }

                await _quyenHanhRepository.PostQuyenHanhAsync(QH_Dto);

                return Ok();
            }
            
            // PUT api/<QuyenHanhController>/5  
            [HttpPut("CapNhat-QuyenHanh/{id}")]
            public async Task<ActionResult<QuyenHanh>> UpdateNhom(QuyenHanhDTO QH_DTO, int id)
            {
                if (QH_DTO == null || QH_DTO.IdChucVu != id)
                {
                    return BadRequest();
                }   

                await _quyenHanhRepository.PutQuyenHanhAsync( QH_DTO, id);

                return NoContent();
            }
            
            // DELETE api/<QuyenHanhController>/5   
            [HttpDelete("Xoa-QUyenHanh/{id}")]
            public async Task<IActionResult> DeleteQuyenHanhAsync(int id)
            {
                await _quyenHanhRepository.DeleteQuyenHanhAsync(id);

                return NoContent();
            }
    }
}
