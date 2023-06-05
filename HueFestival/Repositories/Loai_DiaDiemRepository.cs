using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class Loai_DiaDiemRepository : Repository<Loai_DiaDiem>
    {
        private readonly HueFestival_DbContext _context;
        public Loai_DiaDiemRepository(HueFestival_DbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Loai_DiaDiem>> GetAllLoai_DiaDiemAsync()
        {
            return await GetAllAsync();
        }
        public async Task<Loai_DiaDiem> GetByIdLoai_DiaDiemAsync(int Id)
        {
            var ldd = await _dbSet.FirstOrDefaultAsync(x => x.IdLoai_DD == Id);
            return ldd;
        }
        public async Task<Loai_DiaDiem> PostLoai_DiaDiemAsync(Loai_DiaDiem ldd)
        {
            // them ham chen file anh -> pathImage

            var themLoai_DiaDiem = new Loai_DiaDiem
            {
                TuaDe = ldd.TuaDe,
                PathImage = ldd.PathImage,
            };
            await PostAsync(themLoai_DiaDiem);
            return themLoai_DiaDiem;
        }
        public async Task PutLoai_DiaDiemAsync(Loai_DiaDiem ldd_CanDoi, Loai_DiaDiem ldd_Moi)
        {
            //goi ham xoa file
            //them file moi -> pahtImage

            ldd_CanDoi.TuaDe = ldd_Moi.TuaDe;
            ldd_CanDoi.PathImage = ldd_Moi.PathImage;

            await PutAsync(ldd_CanDoi);
        }
        public async Task DeleteLoai_DiaDiemAsync(Loai_DiaDiem ldd)
        {
            //Xoa HinhAnh
            await DeleteAsync(ldd);
        }

    }
}
