using AutoMapper;
using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
   public class ChuongTrinhRepository : Repository<ChuongTrinh>
    { 
        private readonly HueFestival_DbContext _context;
        private readonly IMapper _mapper;
    

        public ChuongTrinhRepository(HueFestival_DbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ChuongTrinh>> GetAllChuongTrinh()
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
        public async Task<ChuongTrinh> PostChuongTrinh(ChuongTrinhDTO ctDTO, List<IFormFile> imageFiles)
        {
            var ct = _mapper.Map<ChuongTrinh>(ctDTO);

            try
            {
                _context.ChuongTrinhs.Add(ct);
                await _context.SaveChangesAsync();

                var chuongTrinhImages = new List<HinhAnh_CTr>();

                foreach (var imageFile in imageFiles)
                {

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine("Uploads\\ChuongTrinhImage", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    var hinhAnh_CTr = new HinhAnh_CTr
                    {
                        Path = fileName,
                        IdCtr = ct.IdCTr
                    };

                    chuongTrinhImages.Add(hinhAnh_CTr);

                }

                ct.HinhAnh_CTrs = chuongTrinhImages;

                await _context.SaveChangesAsync();

                var ctct = new ChiTiet_CTr
                {
                    Time = TimeSpan.Parse(ctDTO.Time),
                    fDate = DateTime.Parse(ctDTO.fDate),
                    tDate = DateTime.Parse(ctDTO.tDate),
                    IdDiaDiem = ctDTO.IdDiaDiem,
                    IdNhomCTr = ctDTO.IdNhomCTr,
                    IdCtr = ct.IdCTr,
                };
                _context.ChiTiet_CTrs.Add(ctct);
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
        /*public async Task PutChuongTrinh(ChuongTrinh CT)
        {

        }
        public async Task DeleteChuongTrinh(ChuongTrinh CT)
        {

        }
        */
    }
}
