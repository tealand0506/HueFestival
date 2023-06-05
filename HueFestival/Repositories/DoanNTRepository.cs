using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class DoanNTRepository : Repository<DoanNT>
    {
        private readonly HueFestival_DbContext _context;
        public DoanNTRepository(HueFestival_DbContext context) : base(context) {
            _context = context;
        }


        public async Task<List<DoanNT>> GetAllDoanNT()
        {
            return await GetAllAsync();
        }
        public async Task<DoanNT?> GetByIdDoanNT(int Id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.IdDoan == Id);
        }
        public async Task<DoanNT> PostDoanNT(string TenDoan)
        {
            var themDoanNT = new DoanNT
            {
                TenDoan = TenDoan,
            };
            await PostAsync(themDoanNT);
            return themDoanNT;
        }
        public async Task PutDoanNT(DoanNT doanCanSua, DoanNT doanMoi)
        {
            doanCanSua.TenDoan = doanMoi.TenDoan;
            await PutAsync(doanCanSua);
        }
        public async Task DeleteDoanNT(DoanNT doan)
        {
            DeleteAsync(doan);
        }
    }
}
