using HueFestival.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
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
            return await GetAllAsync();
        }

        public async Task<ChucVu?> GetByIdChecVuAsynnc(int id)
        {
            var chucVu = await _dbSet.FirstOrDefaultAsync(cv => cv.IdChucVu == id);
            return chucVu;
        }

        public async Task<ChucVu> PostChucVuAsync(ChucVuDTO ChucVuMoi)
        {
            var ThemChucVu = new ChucVu
            {
                TenChucVu = ChucVuMoi.TenChucVu
            };
            await PostAsync(ThemChucVu);
            return ThemChucVu;
        }

        public async Task PutChucVuAsync(ChucVu chucVuCanSua, ChucVuDTO ChucVuMoi)
        {
            chucVuCanSua.TenChucVu = ChucVuMoi.TenChucVu;

            await PutAsync(chucVuCanSua);
        }

        public async Task DeleteChucVuAsync(ChucVu chucVu)
        {
            await DeleteAsync(chucVu);            
        }
    }
}

