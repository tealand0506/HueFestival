using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class DoanNTRepository : Repository<DoanNT>, IDoanNTRepository
    {
        private readonly HueFestival_DbContext _context;
        public DoanNTRepository(HueFestival_DbContext context) : base(context) {
            _context = context;
        }


        public async Task<List<DoanNT>> GetAllDoanNTAsync()
        {
            return await GetAllAsync();
        }
        public async Task<DoanNT?> GetByIdDoanNTAsync(int Id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.IdDoan == Id);
        }
        public async Task<DoanNT> PostDoanNTAsync(DoanNTDTO doanNTMoi)
        {
            var themDoanNT = new DoanNT
            {
                TenDoan = doanNTMoi.TenDoan,
            };
            await PostAsync(themDoanNT);
            return themDoanNT;
        }
        public async Task PutDoanNTAsync(DoanNT doanCanSua, DoanNTDTO doanMoi)
        {
            doanCanSua.TenDoan = doanMoi.TenDoan;
            await PutAsync(doanCanSua);
        }
        public async Task DeleteDoanNTAsync(DoanNT doan)
        {
            DeleteAsync(doan);
        }
    }
}
