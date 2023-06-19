using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class HoTroRepository : Repository<HoTro>, IHoTroRepository
    {
        private readonly HueFestival_DbContext _context;
        public HoTroRepository(HueFestival_DbContext context) : base(context) { 
        _context = context;
        }

        public async Task<List<HoTro>> DanhSachHoTro()
        {
            return await GetAllAsync();
        }
        public async Task<HoTro?> XuatHoTroTheoID(int id)
        {
            var HoTro = await _dbSet.FirstOrDefaultAsync(ht => ht.IdHoTro == id);
            return HoTro;
        }
        public async Task<HoTro> ThemHoTro(HoTroDTO ht)
        {
            var themHoTro = new HoTro
            {
                HoTroName = ht.HoTroName,
                NoiDung = ht.NoiDung,
            };
            await PostAsync(themHoTro);
            return themHoTro;
        }
        public async Task XoaHoTro(HoTro ht)
        {
            await DeleteAsync(ht);
        }
        public async Task SuaHoTro(HoTroDTO htCanSua, HoTro htMoi)
        {
            htCanSua.HoTroName = htMoi.HoTroName;
            htCanSua.NoiDung = htMoi.NoiDung;

        }
    }
}
