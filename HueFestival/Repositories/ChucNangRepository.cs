using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using HueFestival.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class ChucNangRepository : Repository<ChucNang>, IChucNangRepository
    {
        private readonly HueFestival_DbContext _context;

        public ChucNangRepository(HueFestival_DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ChucNang>> GetAllChucNangAsync()
        {
            return await _context.Set<ChucNang>().ToListAsync();
        }

        public async Task<ChucNang> PostChucNangAsync(string TenChucNang)
        {
            var ThemChucNang = new ChucNang
            {
                TenChucNang = TenChucNang
            };
            await PostAsync(ThemChucNang);
            return ThemChucNang;
        }

        public async Task PutChucNangAsync(ChucNang chucNang, int id)
        {
            var existingChucNang = await _context.Set<ChucNangDTO>().FindAsync(id);
            if (existingChucNang != null)
            {
                _context.Entry(existingChucNang).CurrentValues.SetValues(chucNang);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteChucNangAsync(int id)
        {
            var existingChucNang = await _context.Set<ChucNangDTO>().FindAsync(id);
            if (existingChucNang != null)
            {
                _context.Set<ChucNangDTO>().Remove(existingChucNang);
                await _context.SaveChangesAsync();
            }
        }
    }
}
