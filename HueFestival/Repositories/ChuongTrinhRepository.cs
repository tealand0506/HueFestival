#nullable enable
using AutoMapper;
using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace HueFestival.Repositories
{
   public class ChuongTrinhRepository : Repository<ChuongTrinh>, IChuongTrinhRepository
    { 
        private readonly HueFestival_DbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;
    
        public ChuongTrinhRepository(HueFestival_DbContext context, IMapper mapper, IWebHostEnvironment environment) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }
        public async Task<List<ChuongTrinh?>> GetAllChuongTrinh()
        {
            var ct = await _context.ChuongTrinhs
                .Include(c => c.ChiTiet_CTrs)
                    .ThenInclude(c => c.DiaDiems)
                .Include(c => c.ChiTiet_CTrs)
                    .ThenInclude(c => c.Nhom_CTrs)
                .Include(c => c.HinhAnh_CTrs).ToListAsync();
            return ct;
        }
        public async Task<ChuongTrinh?> GetByIdChuongTrinh(int Id)
        {
            var ct = await _context.ChuongTrinhs
               .Include(c => c.ChiTiet_CTrs)
                   .ThenInclude(c => c.DiaDiems)
               .Include(c => c.ChiTiet_CTrs)
                   .ThenInclude(c => c.Nhom_CTrs)
               .Include(c => c.HinhAnh_CTrs).FirstOrDefaultAsync(c => c.IdCTr == Id);
      
            return ct;
        }
        public async Task<ChuongTrinh?> PostChuongTrinh(ChuongTrinhDTO ctDTO, List<IFormFile> HinhAnh)
        {

            var ct = new ChuongTrinh
            {
                TenCtr = ctDTO.TenCtr,
                MoTa = ctDTO.MoTa,
                TypeInOff = ctDTO.TypeInOff,
                Arrange = ctDTO.Arrange
            };

            try
            {
                _context.ChuongTrinhs.Add(ct);
                await _context.SaveChangesAsync();

                var dsHinhAnh = new List<HinhAnh_CTr>();

                foreach (var imageFile in HinhAnh)
                {
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                        var filePath = Path.Combine("wwwroot\\HinhAnhChuongTrinh", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(stream);
                        }

                        var ThemHinhAnh = new HinhAnh_CTr
                        {
                            Path = filePath,
                            IdCTr = ct.IdCTr
                        };

                        dsHinhAnh.Add(ThemHinhAnh);
                    }
                }

                ct.HinhAnh_CTrs = dsHinhAnh;

                await _context.SaveChangesAsync();

                var ChiTietCT = new ChiTiet_CTr
                {
                    Time = TimeSpan.Parse(ctDTO.Time),
                    fDate = DateTime.Parse(ctDTO.fDate),
                    tDate = DateTime.Parse(ctDTO.tDate),
                    IdDiaDiem = ctDTO.IdDiaDiem,
                    IdNhomCTr = ctDTO.IdNhomCT,
                    IdDoan = ctDTO.IdDoan,
                    IdCTr = ct.IdCTr
                };
                _context.ChiTiet_CTrs.Add(ChiTietCT);
                await _context.SaveChangesAsync();
              
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }

                throw new Exception(innerException.Message);
            }

            return ct;
        }
       public async Task PutChuongTrinh(ChuongTrinh ctCanSua, string TenCtr, string MoTa)
        {
            ctCanSua.TenCtr = TenCtr;
            ctCanSua.MoTa = MoTa;
            await PutAsync(ctCanSua);
        }
        
        public async Task DeleteChuongTrinh(ChuongTrinh CT)
        {
            await DeleteAsync(CT);
        }
        
    }
}
