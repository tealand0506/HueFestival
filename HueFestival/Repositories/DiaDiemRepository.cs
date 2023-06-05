using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class DiaDiemRepository : Repository<DiaDiem>, IDiaDiemRepository
    {
        private readonly HueFestival_DbContext _context;
        public DiaDiemRepository(HueFestival_DbContext context ) : base(context)
        {
            _context = context;
        }


        public async Task<List<DiaDiem>> GetAllDiaDiemAsync()
        {
            return await TruyXuatTheoLoai(dd => dd.LoaiDiaDiems!);
        }
        public async Task<DiaDiem> PostDiaDiemAsync(DiaDiem dd)
        {
            // them ham chen file anh -> pathImage

            var themDD = new DiaDiem
            {
                TenDiaDiem = dd.TenDiaDiem,
                MoTa = dd.MoTa,
                DiaChi = dd.DiaChi,
                PathImage = dd.PathImage,
                IdLoaiDD = dd.IdLoaiDD,
            };
            await PostAsync(themDD);
            return themDD;
        }

        public async Task PutDiaDiemAsync(DiaDiem DD_CanDoi, DiaDiem DD_Moi)
        {
            //goi ham xoa file
            //them file moi -> pahtImage

            //gan dia diem gtri mi cho dia diem can doi
            DD_CanDoi.TenDiaDiem = DD_Moi.TenDiaDiem;
            DD_CanDoi.MoTa = DD_Moi.MoTa;
            DD_CanDoi.DiaChi = DD_Moi.DiaChi;
            DD_CanDoi.PathImage = DD_Moi.PathImage;
            DD_CanDoi.IdLoaiDD = DD_Moi.IdLoaiDD;

            await PutAsync(DD_CanDoi); 
        }
        public async Task DeleteDiaDiemAsync(DiaDiem DD)
        {
            //Xoa hinh anh
            await DeleteAsync(DD);
        }
        public async Task<DiaDiem?> GetDiaDiemById(int Id)
        {
            var diaDiem = await _dbSet.FirstOrDefaultAsync(x => x.IdDiaDiem == Id);
            return diaDiem;
        }

        // ham chen file
        // ham xoa file
    }
}
