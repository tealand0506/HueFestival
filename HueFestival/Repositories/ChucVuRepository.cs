using HueFestival.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repository
{
    public class ChucVuRepository : Repository<ChucVu>, IChucVuRepository
    {
        private readonly HueFestival_DbContext _context;

        public ChucVuRepository(HueFestival_DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ChucVu>> GetAllChucVuAsync()
        {
            return await _context.Set<ChucVu>().ToListAsync();
        }



        public async Task<ChucVu> PostChucVuAsync(string TenChucVu)
        {
            var ThemChucVu = new ChucVu
            {
                TenChucVu = TenChucVu
            };
            await PostAsync(ThemChucVu);
            return ThemChucVu;
        }

        public async Task PutChucVuAsync(ChucVu chucVu, int id)
        {
            var CapNhatChucVu = await _context.Set<ChucVu>().FindAsync(id);
            if (CapNhatChucVu != null)  
            {
                CapNhatChucVu.TenChucVu = chucVu.TenChucVu;
                _context.Set<ChucVu>().Update(CapNhatChucVu);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteChucVuAsync(int id)
        {
            var chucVu = await _context.Set<ChucVu>().FindAsync(id);
            if (chucVu != null)
            {
                _context.Set<ChucVu>().Remove(chucVu);
                await _context.SaveChangesAsync();
            }
        }
    }
}

