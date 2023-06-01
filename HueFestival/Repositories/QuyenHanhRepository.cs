using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HueFestival.Repositories
{
    public class QuyenHanhRepository : Repository<QuyenHanh>, IQuyenHanhRepository
    {
        private readonly HueFestival_DbContext _context;

        public QuyenHanhRepository(HueFestival_DbContext context) : base(context)
        {
            _context = context;
        }

       
        public async Task<List<Tuple<string, string>>> GetAllQuyenHanhWithNameAsync()
        {
            var quyenHanhs = await _context.Set<QuyenHanh>()
                                             .Join(_context.Set<ChucVu>(),
                                                   qh => qh.IdChucVu,
                                                   cv => cv.IdChucVu,
                                                   (qh, cv) => new { QuyenHanh = qh, ChucVu = cv })
                                             .Join(_context.Set<ChucNang>(),
                                                   qh_cv => qh_cv.QuyenHanh.IdChucNang,
                                                   cn => cn.IdchucNang,
                                                   (qh_cv, cn) => new { ChucVu = qh_cv.ChucVu, ChucNang = cn })
                                             .Select(qh_cn => Tuple.Create(qh_cn.ChucVu.TenChucVu, qh_cn.ChucNang.TenChucNang))
                                             .ToListAsync();

            return quyenHanhs;
        }

        public async Task<QuyenHanh> PostQuyenHanhAsync(int IdChucNang, int IdChucVu)
        {
            /*
            var ThemQuyenHanh = new QuyenHanh
            {
                ThemQuyenHanh.IdChucVu = IdChucNang,
                ThemQuyenHanh.IdChucNang = IdChucVu.
            };
            await PostAsync(ThemChucVu);
            return ThemChucVu;
            */
            return Ok();
        }

        private QuyenHanh Ok()
        {
            throw new NotImplementedException();
        }

        public async Task PutQuyenHanhAsync(QuyenHanh quyenHanh, int id)
        {

            var CapNhatQuyenHanh = await _context.Set<QuyenHanh>().FindAsync(id);

            if (CapNhatQuyenHanh != null)
            {
                CapNhatQuyenHanh.IdChucVu = quyenHanh.IdChucVu;
                CapNhatQuyenHanh.IdChucNang = quyenHanh.IdChucNang;

                _context.Entry(CapNhatQuyenHanh).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteQuyenHanhAsync(int id)
        {
            var quyenHanh = await _context.Set<QuyenHanhDTO>().FindAsync(id);

            if (quyenHanh != null)
            {
                _context.Set<QuyenHanhDTO>().Remove(quyenHanh);
                await _context.SaveChangesAsync();
            }
        }
    }
}
