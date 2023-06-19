using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class Nhom_CTrRepository : Repository<Nhom_CTr>, INhom_CTrRepository
    {
        private readonly HueFestival_DbContext _context;
        public Nhom_CTrRepository(HueFestival_DbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Nhom_CTr>> GetAllNhom_CTrRepository()
        {
            return await GetAllAsync();
        }
        public async Task<Nhom_CTr?> GetByIdNhom_CTrRepository(int Id)
        {
            var Nhom = await _dbSet.FirstOrDefaultAsync(x => x.IdNhomCTr == Id);
            return Nhom;
        }
        public async Task<Nhom_CTr> PostNhom_CTrRepository(Nhom_CTrDTO Nhom)
        {
            var ThemNhomCTr = new Nhom_CTr
            {
                TenNhom_CTr = Nhom.TenNhom_CTr
            };
            await PostAsync(ThemNhomCTr);
            return ThemNhomCTr;
        }
        public async Task PutNhom_CTrRepository(Nhom_CTr nhomCanDoi, Nhom_CTrDTO nhomMoi)
        {
            nhomCanDoi.TenNhom_CTr = nhomMoi.TenNhom_CTr;
            await PutAsync(nhomCanDoi);
        }
        public async Task DeleteNhom_CTrRepository(Nhom_CTr nhom)
        {
            await DeleteAsync(nhom);
        }
    }
}
